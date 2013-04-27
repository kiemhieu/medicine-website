using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;
using Medical.Forms.Common;
using Medical.Forms.Enums;
using Medical.Forms.UI;

namespace Medical.MedicineDeliver
{
    public partial class DeliveryRegister : Form
    {
        private List<MedicineDeliveryAllocationEntity> _medDeliveryAllocationList;
        // Repositpry
        private IPrescriptionRepository _prescriptionRepo = new PrescriptionRepository();
        private IPrescriptionDetailRepository _prescriptionDetailRepo = new PrescriptionDetailRepository();
        private IMedicineDeliveryRepository _medicineDeliveryRepo = new MedicineDeliveryRepository();
        private IMedicineDeliveryDetailRepository _medicineDeliveryDetailRepo = new MedicineDeliveryDetailRepository();
        private IMedicineDeliveryDetailAllocateRepository _medicineDeliveryDetailAllocateRepo = new MedicineDeliveryDetailAllocateRepository();
        private IWareHouseDetailRepository _warehouseDetailAllocateRepo = new WareHouseDetailRepository();
        private IWareHouseRepository _warehouseRepo = new WareHouseRepository();
        private IWareHouseDetailRepository _warehouseDetailRepo = new WareHouseDetailRepository();
        private IMedicineRepository _medicineRepo = new MedicineRepository();
        private IVWareHouseDetailRespository _vWareHouseDetailRepo = new VWareHouseDetailRepository();

        // Entity & List
        private Prescription _prescription;
        private List<PrescriptionDetail> _prescriptionDetailList;
        private MedicineDelivery _medicineDelivery;
        private List<MedicineDeliveryDetail> _medicineDeliveryDetailList;
        private List<MedicineDeliveryDetailAllocate> _mdecidineDeliveryDetailAllocate;
        private List<WareHouse> _warehouseList;
        private List<WareHouseDetail> _warehouseDetailList;
        private List<VWareHouseDetail> _vWareHouseDetailList;
        private List<VMedicineDeliveryDetailAllocated> _vMedicineDeliveryDetailAllocateds;

        private long _prescriptionId;
        private ViewModes _formMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryRegister"/> class.
        /// </summary>
        /// <param name="prescriptionId">The prescription id.</param>
        public DeliveryRegister(long prescriptionId)
        {
            InitializeComponent();
            this._prescriptionId = prescriptionId;
            this.Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            this._vWareHouseDetailList = new List<VWareHouseDetail>();
            this.bdsMedicine.DataSource = _medicineRepo.GetAll();
            this._medDeliveryAllocationList = new List<MedicineDeliveryAllocationEntity>();
            this._prescription = _prescriptionRepo.Get(this._prescriptionId);
            this.bdsPrescription.DataSource = this._prescription;
            this._prescriptionDetailList = _prescriptionDetailRepo.GetByPrescription(this._prescriptionId);
            if (_prescription == null || this._prescriptionDetailList == null) throw new Exception("Data done not existed");

            this._medicineDelivery = this._medicineDeliveryRepo.GetByPrescriptionId(this._prescriptionId);
            this._formMode = this._medicineDelivery == null ? ViewModes.Add : ViewModes.View;

            if (this._formMode == ViewModes.Add)
            {
                // Createe MachineDelivery
                // Create MachineDeliveryDetail
                // Craete MedicindeDeliveryDetailAllocate
                // Get WareHouseDetail
                // Get WareHouse;
                // this._warehouseDetailList  = this._warehouseDetailRepo
                var medincineIdList = this._prescriptionDetailList.Select(item => item.MedicineId).ToList();
                this._warehouseList = this._warehouseRepo.GetByMedicineId(medincineIdList, AppContext.CurrentClinic.Id);
                this._vWareHouseDetailList = this._vWareHouseDetailRepo.GetByMedicine(medincineIdList);
                this._medicineDelivery = CreatePrescription(this._prescription);
                this._medicineDeliveryDetailList = CreateMedicineDeliveryDetail(this._prescriptionDetailList);
                this.AutoAllocate(this._medicineDeliveryDetailList, this._vWareHouseDetailList);
                // this._warehouseDetailList = this._warehouseDetailRepo.GetByMedicine(medincineIdList, AppContext.CurrentClinic.Id);)
                // this._mdecidineDeliveryDetailAllocate = AutoAllocate(this._medicineDeliveryDetailList, this._warehouseDetailList);
                // var item = this._warehouseDetailList.Select(x => new { x.MedicineId, x.LotNo, x.ExpiredDate}).GroupBy(x => new { x.MedicineId, x.LotNo, x.ExpiredDate }).ToList();

                var no = 1;
                foreach (var deliveryItem in this._medicineDeliveryDetailList)
                {
                    // var allocatedList = this._mdecidineDeliveryDetailAllocate.Where(x => x.MedicineDeliveryDetailId == deliveryItem.Id).ToList();
                    var warehouse = this._warehouseList.FirstOrDefault(x => x.MedicineId == deliveryItem.MedicineId);
                    var item = new MedicineDeliveryAllocationEntity(no++, deliveryItem, warehouse);
                    this._medDeliveryAllocationList.Add(item);

                    var subNo = 1;
                    foreach (var itm in deliveryItem.AllocatedWareHouseDetail)
                    {
                        var subItem = new MedicineDeliveryAllocationEntity(subNo++, itm);
                        _medDeliveryAllocationList.Add(subItem);
                    }
                }
                this.bindingSource1.DataSource = this._medDeliveryAllocationList;
            } else {
                var medincineIdList = this._prescriptionDetailList.Select(item => item.MedicineId).ToList();
                this._warehouseList = this._warehouseRepo.GetByMedicineId(medincineIdList, AppContext.CurrentClinic.Id);
                this._vWareHouseDetailList = this._vWareHouseDetailRepo.GetByMedicine(medincineIdList);
                
                this._medicineDelivery = this._medicineDeliveryRepo.GetByPrescriptionId(this._prescription.Id);
                this._medicineDeliveryDetailList = this._medicineDeliveryDetailRepo.GetByDelivery(this._medicineDelivery.Id);
                var deliveryDetailList = this._medicineDeliveryDetailList.Select(x => x.Id).ToList();
                this._vMedicineDeliveryDetailAllocateds = this._medicineDeliveryDetailRepo.GetDeliveryDetailAllocateds(deliveryDetailList);
                // this._mdecidineDeliveryDetailAllocate = AutoAllocate(this._medicineDeliveryDetailList, this._warehouseDetailList);
                // var item = this._warehouseDetailList.Select(x => new { x.MedicineId, x.LotNo, x.ExpiredDate}).GroupBy(x => new { x.MedicineId, x.LotNo, x.ExpiredDate }).ToList();
                // this._warehouseDetailList = this._warehouseDetailRepo.GetByMedicine(medincineIdList, AppContext.CurrentClinic.Id);)

                var no = 1;
                foreach (var deliveryItem in this._medicineDeliveryDetailList) {
                    // var allocatedList = this._mdecidineDeliveryDetailAllocate.Where(x => x.MedicineDeliveryDetailId == deliveryItem.Id).ToList();
                    var warehouse = this._warehouseList.FirstOrDefault(x => x.MedicineId == deliveryItem.MedicineId);
                    var item = new MedicineDeliveryAllocationEntity(no++, deliveryItem, warehouse);
                    this._medDeliveryAllocationList.Add(item);

                    List<VMedicineDeliveryDetailAllocated> allocatedWareHouseDetailList =
                        this._vMedicineDeliveryDetailAllocateds.Where(x => x.MedicineDeliveryDetailId == deliveryItem.Id)
                            .ToList();
                    var subNo = 1;
                    foreach (var itm in allocatedWareHouseDetailList) {
                        var subItem = new MedicineDeliveryAllocationEntity(subNo++, itm);
                        _medDeliveryAllocationList.Add(subItem);
                    }
                }
                this.dataGridViewX1.Columns[6].Visible = false;
                this.dataGridViewX1.Columns[8].Visible = false;
                this.bindingSource1.DataSource = this._medDeliveryAllocationList;


            }
        }

        /// <summary>
        /// Creates the prescription.
        /// </summary>
        /// <param name="prescription">The prescription.</param>
        /// <returns></returns>
        private MedicineDelivery CreatePrescription(Prescription prescription)
        {
            var medicineDelivery = new MedicineDelivery
                                       {
                                           ClinicId = AppContext.CurrentClinic.Id,
                                           Date = DateTime.Today,
                                           PatientId = prescription.PatientId,
                                           PrescriptionId = prescription.Id
                                       };
            return medicineDelivery;
        }

        /// <summary>
        /// Creates the medicine delivery detail.
        /// </summary>
        /// <param name="prescriptionDetails">The prescription details.</param>
        /// <returns></returns>
        private List<MedicineDeliveryDetail> CreateMedicineDeliveryDetail(List<PrescriptionDetail> prescriptionDetails)
        {
            var index = 0;
            return prescriptionDetails.Select(prescriptionDetail => new MedicineDeliveryDetail
                                                                        {
                                                                            // Id = ++index, 
                                                                            MedicineId = prescriptionDetail.MedicineId, 
                                                                            Medicine = prescriptionDetail.Medicine, 
                                                                            PrescriptionDetailId = prescriptionDetail.Id, 
                                                                            Unit = prescriptionDetail.Medicine.Unit, 
                                                                            Volumn = prescriptionDetail.Amount, 
                                                                            NotAllocatedQty = prescriptionDetail.Amount
                                                                        }).ToList();
        }

        /// <summary>
        /// Autoes the allocate.
        /// </summary>
        /// <param name="medicineDeliveryDetails">The medicine delivery details.</param>
        /// <param name="wareHouseDetails">The ware house details.</param>
        /// <returns></returns>
        private void AutoAllocate(List<MedicineDeliveryDetail> medicineDeliveryDetails, List<VWareHouseDetail> wareHouseDetails)
        {
            foreach (var deliveryDetailItem in medicineDeliveryDetails)
            {
                deliveryDetailItem.AllocatedWareHouseDetail = new List<VWareHouseDetail>();
                var warehouseDetailList = wareHouseDetails.Where(x => x.MedicineId == deliveryDetailItem.MedicineId).OrderBy(x => x.ExpiredDate).OrderBy(x => x.Id).ToList();
                foreach (var t in warehouseDetailList)
                {
                    if (deliveryDetailItem.NotAllocatedQty <= 0) break;
                    if (deliveryDetailItem.NotAllocatedQty <= t.Qty)
                    {
                        var allocated = new VWareHouseDetail
                                            {
                                                MedicineId = t.MedicineId,
                                                ClinicId = t.ClinicId,
                                                LotNo = t.LotNo,
                                                ExpiredDate = t.ExpiredDate,
                                                Qty = t.Qty,
                                                AllocatedQty = deliveryDetailItem.NotAllocatedQty,
                                                InStockQty =  t.InStockQty
                                            };
                        deliveryDetailItem.NotAllocatedQty = 0;
                        deliveryDetailItem.AllocatedWareHouseDetail.Add(allocated);
                        deliveryDetailItem.NotAllocatedQty = 0;
                    }
                    else
                    {
                        var allocated = new VWareHouseDetail
                                            {
                                                MedicineId = t.MedicineId,
                                                ClinicId = t.ClinicId,
                                                LotNo = t.LotNo,
                                                ExpiredDate = t.ExpiredDate,
                                                Qty = t.Qty,
                                                AllocatedQty = t.Qty,
                                                InStockQty = t.InStockQty
                                            };
                        deliveryDetailItem.NotAllocatedQty -= allocated.AllocatedQty;
                        deliveryDetailItem.AllocatedWareHouseDetail.Add(allocated);
                    }
                    if (deliveryDetailItem.NotAllocatedQty == 0) break;
                }
            }
        }

        private void DeliveryRegister_Load(object sender, EventArgs e)
        {
           if (this._formMode == ViewModes.Add)
           {
               this.btnDelete.Visible = false;
               this.btnSave.Visible = true;
           }
           else
           {
               this.btnDelete.Visible = true;
               this.btnSave.Visible = false;  
           }
        }

        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = this.dataGridViewX1.Rows[e.RowIndex];
            if (row.Cells[1].Value == null) row.DefaultCellStyle.BackColor = Color.PaleTurquoise;
            // row.DefaultCellStyle.BackColor = Color.Gray;

        }

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /*
            if (e.RowIndex <= 0) return;
            
            var row = this.dataGridView1.Rows[e.RowIndex];
            if (row.Cells[1].Value != null) 
            {
                if (e.ColumnIndex == 2)
                {
                    e.PaintBackground(e.ClipBounds, true);
                    Rectangle r = e.CellBounds;
                    Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(2, 1, true);
                    r.Width += r1.Width - 1;
                    r.Height -= 1;

                    using (SolidBrush brBk = new SolidBrush(e.CellStyle.BackColor))
                    using (SolidBrush brFr = new SolidBrush(e.CellStyle.ForeColor))
                    {

                        e.Graphics.FillRectangle(brBk, r);
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        // e.Graphics.DrawString("cell merged", e.CellStyle.Font, brFr, r, sf);
                    }

                    e.Handled = true;
                }

                if (e.ColumnIndex == 3)
                {
                    using (Pen p = new Pen(this.dataGridView1.GridColor))
                    {
                        e.Graphics.DrawLine(p, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                            e.CellBounds.Right, e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(p, e.CellBounds.Right - 1, e.CellBounds.Top,
                            e.CellBounds.Right - 1, e.CellBounds.Bottom);

                    }
                    e.Handled = true;
                }
                if (e.ColumnIndex == 4)
                {
                    using (Pen p = new Pen(this.dataGridView1.GridColor))
                    {
                        e.Graphics.DrawLine(p, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                            e.CellBounds.Right, e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(p, e.CellBounds.Right - 1, e.CellBounds.Top,
                            e.CellBounds.Right - 1, e.CellBounds.Bottom);

                    }
                    e.Handled = true;
                }
             
            }
             * */

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewX1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this._formMode != ViewModes.Add) return;
            MedicineDeliveryAllocationEntity ent = (MedicineDeliveryAllocationEntity) this.bindingSource1.Current;
            if (ent.SubNo != null) return;
            DeliveryAllocateDetail detailDialog = new DeliveryAllocateDetail(ent.MedicineDeliveryDetail);
            detailDialog.ShowDialog(this);
            if (detailDialog.DialogResult == DialogResult.Cancel) return;
            ent.MedicineDeliveryDetail.AllocatedWareHouseDetail = detailDialog.Result;

            var no = 1;
            this._medDeliveryAllocationList= new List<MedicineDeliveryAllocationEntity>();
            foreach (var deliveryItem in this._medicineDeliveryDetailList) {
                // var allocatedList = this._mdecidineDeliveryDetailAllocate.Where(x => x.MedicineDeliveryDetailId == deliveryItem.Id).ToList();
                var warehouse = this._warehouseList.FirstOrDefault(x => x.MedicineId == deliveryItem.MedicineId);
                var item = new MedicineDeliveryAllocationEntity(no++, deliveryItem, warehouse);
                this._medDeliveryAllocationList.Add(item);

                var subNo = 1;
                foreach (var itm in deliveryItem.AllocatedWareHouseDetail) {
                    var subItem = new MedicineDeliveryAllocationEntity(subNo++, itm);
                    _medDeliveryAllocationList.Add(subItem);
                }
            }
            this.bindingSource1.DataSource = this._medDeliveryAllocationList;
            this.bindingSource1.ResetBindings(true);
            this.dataGridViewX1.ResetBindings();
        }

        private void dataGridViewX1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            /*
            MessageBox.Show(this.dataGridViewX1.Rows[e.RowIndex].Cells[8].Value + ": " +
                            this.dataGridViewX1.Rows[e.RowIndex].Cells[8].ValueType);
            var a = ((DataGridViewButtonCell) this.dataGridViewX1.Rows[e.RowIndex].Cells[10]);
            a.UseColumnTextForButtonValue = true;
            a.DetachEditingControl();

             */

            // var b = ((DataGridViewButtonXCell)this.dataGridViewX1.Rows[e.RowIndex].Cells[10]);

            /*
            for(int i = e.RowIndex;i<e.RowCount + e.RowIndex; i++)
            {
                var a = ((DataGridViewDisableButtonXCell)this.dataGridViewX1.Rows[i].Cells[11]);
                if (i == 6) a.Enabled = false;
            }
             */
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!ValidateForms()) return;
            this._medicineDeliveryRepo.Insert(this._medicineDelivery, this._medicineDeliveryDetailList);
        }

        private bool ValidateForms()
        {
            var result = true;
            var list = (List<MedicineDeliveryAllocationEntity>) this.bindingSource1.List;
            foreach (var item in list)
            {
                item.Validate();
                if (item.IsValid == false) result = false;
            }

            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var dialogResult = MessageDialog.Instance.ShowMessage(this, "Q003", "bản ghi cấp thuốc này");
            if (dialogResult == DialogResult.No) return;
            this._medicineDeliveryRepo.Delete(this._medicineDelivery.Id);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!ValidateForms()) return;
            var dialogResult = MessageDialog.Instance.ShowMessage(this, "Q004", this._prescription.Patient.Name);
            this._medicineDeliveryRepo.Insert(this._medicineDelivery, this._medicineDeliveryDetailList);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

