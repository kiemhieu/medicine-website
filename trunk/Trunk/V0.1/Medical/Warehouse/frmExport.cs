using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data;
using Medical.Data.Entities;
using DevComponents.DotNetBar.Controls;

namespace Medical.Warehouse
{
    public partial class frmExport : DockContent
    {
        private ClinicRepository repClinic;
        private DefineRepository repDefine;
        private MedicineRepository repMedicine;
        private WareHouseDetailRepository repwhDetail;
        private WareHouseRepository repwh;
        private WareHousePaperRepository repwhPaper;
        private WareHousePaperDetailRepository repwhPaperDetail;
        private WareHouseExportAllocateRepository whExport;
        private int ClinicId;
        private int WHPaperId;
        public frmExport()
        {

            repClinic = new ClinicRepository();
            repDefine = new DefineRepository();
            repMedicine = new MedicineRepository();
            repwh = new WareHouseRepository();
            repwhDetail = new WareHouseDetailRepository();
            repwhPaper = new WareHousePaperRepository();
            repwhPaperDetail = new WareHousePaperDetailRepository();
            whExport = new WareHouseExportAllocateRepository();
            InitializeComponent();
            repClinic = new ClinicRepository();
            FillToComboboxClinic(0);
            dateImport.Value = DateTime.Now.Date;


            try
            {
                InitGrid();
                //bindingSource3.DataSource = repMedicine.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        private void FillToComboboxClinic(int clinicId)
        {
            if (clinicId > 0)
            {
                bindingSource2.DataSource = repClinic.GetById(clinicId);

            }
            else bindingSource2.DataSource = repClinic.GetAll();
        }

        private void InitGrid()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            // add column thuoc
            var cbMed = new DataGridViewComboBoxColumn
            {
                DataSource = repwh.GetByClinicId(AppContext.CurrentClinic.Id),
                DisplayMember = "MedicineName",
                ValueMember = "MedicineId",
                DataPropertyName = "MedicineId",
                HeaderText = "Thuốc",
                Name = "MedicineId"
            };
            cbMed.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(cbMed);

            var clMedicineId = new DataGridViewTextBoxColumn { HeaderText = "Mã thuốc", DataPropertyName = "MedicineIdHidden", Name = "MedicineIdHidden" };
            clMedicineId.Visible = false;
            grd.Columns.Add(clMedicineId);

            var clmInStock = new DataGridViewTextBoxColumn { HeaderText = "Số lượng trong kho", DataPropertyName = "Volumn", Name = "Volumn" };
            clmInStock.ReadOnly = true;
            clmInStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmInStock);

            var clmExport = new DataGridViewTextBoxColumn { HeaderText = "Số lượng xuất kho", DataPropertyName = "Export", Name = "Export" };
            clmExport.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmExport);

            var clmMinAllowed = new DataGridViewTextBoxColumn { HeaderText = "Số lượng thấp nhất cho phép", DataPropertyName = "MinAllowed", Name = "MinAllowed" };
            clmMinAllowed.ReadOnly = true;
            clmMinAllowed.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmMinAllowed);

            var btnDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            btnDelete.Width = 50;
            btnDelete.HeaderText = "Xóa";
            btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            btnDelete.Name = "Delete";
            btnDelete.SortMode = DataGridViewColumnSortMode.NotSortable;
            grd.Columns.Add(btnDelete);
        }

        private void cbClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClinic.SelectedIndex < 0) return;
            ClinicId = int.Parse(cbClinic.SelectedValue.ToString());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert data to WareHousePaper
                WareHousePaper wareHousePaper = new WareHousePaper();
                wareHousePaper.ClinicId = int.Parse(cbClinic.SelectedValue.ToString());
                wareHousePaper.Date = dateImport.Value.Date;
                wareHousePaper.Deliverer = txtDeliverer.Text;
                wareHousePaper.Recipient = txtRecipient.Text;
                wareHousePaper.Type = 1;
                wareHousePaper.Version = 0;
                wareHousePaper.No = txtNo.Text;
                wareHousePaper.Note = txtNote.Text;
                WareHousePaperRepository wareHousePaperRepository = new WareHousePaperRepository();
                wareHousePaperRepository.Insert(wareHousePaper);

                foreach (DataGridViewRow row in grd.Rows)
                {
                    if (row.Cells["Volumn"].Value != null)
                    {
                        int medicineId = int.Parse(row.Cells["MedicineIdHidden"].Value.ToString());
                        int export = int.Parse(row.Cells["Export"].Value.ToString());
                        //update data to WareHouse
                        var wareHouse = repwh.GetByIdMedicine(medicineId, AppContext.CurrentClinic.Id);
                        if (wareHouse != null)
                        {
                            wareHouse.Volumn -= export;
                            repwh.Update(wareHouse);
                        }

                        var list = repwhDetail.GetMeicineExport(wareHouse.Id, medicineId);

                        foreach (var obj in list)
                        {
                            if (obj.CurrentVolumn >= export)
                            {
                                //Update whDetail
                                obj.CurrentVolumn -= export;
                                repwhDetail.Update(obj);

                                //Insert data to WareHousePaperDetail
                                WareHousePaperDetail item = new WareHousePaperDetail();
                                item.WareHousePaperId = wareHousePaper.Id;
                                item.LotNo = obj.LotNo;
                                item.Type = 1;
                                item.MedicineId = obj.MedicineId;
                                item.Volumn = export;
                                item.Unit = obj.Unit;
                                item.UnitPrice = obj.UnitPrice;
                                item.ExpireDate = obj.ExpiredDate;
                                repwhPaperDetail.Insert(item);

                                //Insert whExportAllocate
                                WareHouseExportAllocate wareHouseExportAllocate = new WareHouseExportAllocate();
                                wareHouseExportAllocate.WareHouseDetailId = obj.Id;
                                wareHouseExportAllocate.WareHoudePaperDetailId = item.Id;
                                wareHouseExportAllocate.Volumn = export;
                                wareHouseExportAllocate.Unit = obj.Unit;
                                whExport.Insert(wareHouseExportAllocate);
                                break;
                            }
                            else
                            {
                                //Insert data to WareHousePaperDetail
                                WareHousePaperDetail item = new WareHousePaperDetail();
                                item.WareHousePaperId = wareHousePaper.Id;
                                item.LotNo = obj.LotNo;
                                item.Type = 1;
                                item.MedicineId = obj.MedicineId;
                                item.Volumn = obj.CurrentVolumn;
                                item.Unit = obj.Unit;
                                item.UnitPrice = obj.UnitPrice;
                                item.ExpireDate = obj.ExpiredDate;
                                repwhPaperDetail.Insert(item);

                                export -= obj.CurrentVolumn;

                                //Update whDetail
                                obj.CurrentVolumn = 0;
                                repwhDetail.Update(obj);

                                //Insert whExportAllocate
                                WareHouseExportAllocate wareHouseExportAllocate = new WareHouseExportAllocate();
                                wareHouseExportAllocate.WareHouseDetailId = obj.Id;
                                wareHouseExportAllocate.WareHoudePaperDetailId = item.Id;
                                wareHouseExportAllocate.Volumn = obj.CurrentVolumn;
                                wareHouseExportAllocate.Unit = obj.Unit;
                                whExport.Insert(wareHouseExportAllocate);
                            }
                        }
                    }
                }

                MessageBox.Show("Xuất kho thành công!");
                dateImport.Value = DateTime.Now;
                txtDeliverer.Text = string.Empty;
                txtNo.Text = string.Empty;
                txtNote.Text = string.Empty;
                txtRecipient.Text = string.Empty;
                grd.Rows.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (grd.Columns[e.ColumnIndex].Name == "MedicineId")
            {
                if (grd.Rows[e.RowIndex].Cells["MedicineId"].Value != null)
                {
                    if (ValidateRowData(grd.Rows[e.RowIndex].Cells["MedicineId"].Value.ToString()))
                    {
                        var medicine = repwh.GetByIdMedicine(int.Parse(grd.Rows[e.RowIndex].Cells["MedicineId"].Value.ToString()), AppContext.CurrentClinic.Id);
                        grd.Rows[e.RowIndex].Cells["Volumn"].Value = medicine.Volumn;
                        grd.Rows[e.RowIndex].Cells["MinAllowed"].Value = medicine.MinAllowed;
                        grd.Rows[e.RowIndex].Cells["MedicineIdHidden"].Value = medicine.MedicineId;
                        grd.Rows[e.RowIndex].Cells["Export"].ReadOnly = false;
                    }
                    else
                    {
                        MessageBox.Show("Loại thuốc này đã tồn tại trong danh sách xuất kho");
                        grd.Rows[e.RowIndex].Cells["Export"].ReadOnly = true;
                    }
                }
            }
            else if (grd.Columns[e.ColumnIndex].Name == "Export")
            {
                int export = 0;
                if (grd.Rows[e.RowIndex].Cells["Export"].Value != null && !int.TryParse(grd.Rows[e.RowIndex].Cells["Export"].Value.ToString(), out export))
                {
                    grd.Rows[e.RowIndex].Cells["Export"].Value = 0;
                }
            }
        }

        private bool ValidateRowData(string medicineId)
        {
            foreach (DataGridViewRow row in grd.Rows)
            {
                if (row.Cells["MedicineIdHidden"].Value != null && row.Cells["MedicineIdHidden"].Value.ToString() == medicineId)
                {
                    return false;
                }
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grd.DataSource = null;
            txtNo.Text = string.Empty;
            txtDeliverer.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtRecipient.Text = string.Empty;
            dateImport.Value = DateTime.Now;
        }

        private void grd_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && grd.Rows.Count > 1 && !grd.Rows[e.RowIndex].IsNewRow && grd.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "Xác nhận trước khi xóa", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    grd.AllowUserToDeleteRows = true;
                    grd.Rows.Remove(grd.Rows[e.RowIndex]);
                }
            }
        }       
    }
}
