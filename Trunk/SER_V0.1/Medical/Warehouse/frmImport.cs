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
    public partial class frmImport : DockContent
    {
        private ClinicRepository repClinic;
        private DefineRepository repDefine;
        private MedicineRepository repMedicine;
        private WareHouseDetailRepository repwhDetail;
        private WareHouseRepository repwh;
        private WareHouseIORepository _repwhIo;
        private WareHouseIODetailRepository _repwhIoDetail;
        private int ClinicId;
        private int WHPaperId;
        public frmImport()
        {

            repClinic = new ClinicRepository();
            repDefine = new DefineRepository();
            repMedicine = new MedicineRepository();
            repwh = new WareHouseRepository();
            repwhDetail = new WareHouseDetailRepository();
            _repwhIo = new WareHouseIORepository();
            _repwhIoDetail = new WareHouseIODetailRepository();

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
            // add column thuoc
            var cbMed = new DataGridViewComboBoxColumn
            {
                DataSource = repMedicine.GetAll(),
                DisplayMember = "Name",
                ValueMember = "Id",
                DataPropertyName = "MedicineId",
                HeaderText = "Thuốc",
                Name = "MedicineId"
            };
            grd.Columns.Add(cbMed);

            var txtLotno = new DataGridViewTextBoxColumn { HeaderText = "Số lô", DataPropertyName = "LotNo", Name = "LotNo" };
            grd.Columns.Add(txtLotno);

            var txtSoLuong = new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "Volumn", Name = "Volumn" };
            grd.Columns.Add(txtSoLuong);

            var clmUnit = new DataGridViewTextBoxColumn { HeaderText = "UnitID", DataPropertyName = "Unit", Name = "Unit" };
            clmUnit.Visible = false;            
            grd.Columns.Add(clmUnit);

            var clmUnitName = new DataGridViewTextBoxColumn { HeaderText = "Đơn vị", DataPropertyName = "UnitName", Name = "UnitName" };
            clmUnitName.ReadOnly = true;
            grd.Columns.Add(clmUnitName);

            var txtDonGia = new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = "UnitPrice", Name = "UnitPrice" };
            grd.Columns.Add(txtDonGia);

            var txtThanhTien = new DataGridViewTextBoxColumn { HeaderText = "Thành tiền", DataPropertyName = "Amount", Name = "Amount" };
            txtThanhTien.ReadOnly = true;
            grd.Columns.Add(txtThanhTien);

            var dtExpireDate = new DataGridViewDateTimeInputColumn { HeaderText = "Ngày hết hạn", DataPropertyName = "ExpireDate", Name = "ExpireDate" };
            grd.Columns.Add(dtExpireDate);

            var txtGhiChu = new DataGridViewTextBoxColumn { HeaderText = "Ghi chú", DataPropertyName = "Note", Name = "Note" };
            txtGhiChu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(txtGhiChu);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Insert into WareHousePaper
            try
            {
                WareHouseIO whIo = GetWareHousePaperEntity();
                _repwhIo.Insert(whIo);

            }
            catch (Exception)
            {

                throw;
            }

        }

        private WareHouseIO GetWareHousePaperEntity()
        {
            WareHouseIO whIo = new WareHouseIO();
            whIo.Id = 0;
            whIo.No = txtNo.Text.Trim();
            whIo.Note = txtNote.Text.Trim();
            //whIo.Recipient = txtRecipient.Text.Trim();
            whIo.ClinicId = int.Parse(cbClinic.SelectedValue.ToString());
            //whIo.Deliverer = txtDeliverer.Text.Trim();
            //whIo.Type = 0;
            return whIo;
        }

        private WareHouseIODetail GetWareHousePaperDetailEntity(int GridIndex)
        {
            if (GridIndex < 0) return new WareHouseIODetail();

            WareHouseIODetail whIoDetail = new WareHouseIODetail();
            whIoDetail.Id = 0;
            whIoDetail.Amount = int.Parse(grd.Rows[0].Cells["Amount"].Value.ToString());
            // whIoDetail.Volumn = int.Parse(grd.Rows[0].Cells["Volumn"].Value.ToString());
            whIoDetail.LotNo = grd.Rows[0].Cells["LotNo"].Value.ToString();
            whIoDetail.MedicineId = int.Parse(grd.Rows[0].Cells["MedicineId"].Value.ToString());
            //whIoDetail.Note = grd.Rows[0].Cells["Note"].Value.ToString();
            //whIoDetail.WareHousePaperId = this.WHPaperId;
            return whIoDetail;
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
                WareHouseIO wareHouseIo = new WareHouseIO();
                wareHouseIo.ClinicId = int.Parse(cbClinic.SelectedValue.ToString());
                wareHouseIo.Date = dateImport.Value.Date;
                // wareHouseIo.Deliverer = txtDeliverer.Text;
                //wareHouseIo.Recipient = txtRecipient.Text;
                //wareHouseIo.Type = 0;
                wareHouseIo.Version = 0;
                wareHouseIo.No = txtNo.Text;
                wareHouseIo.Note = txtNote.Text;
                WareHouseIORepository wareHouseIoRepository = new WareHouseIORepository();
                wareHouseIoRepository.Insert(wareHouseIo);

                //Insert data to WareHousePaperDetail
                foreach (DataGridViewRow row in grd.Rows)
                {
                    if (ValidateRowData(row))
                    {
                        WareHouseIODetail item = new WareHouseIODetail();
                        //item.WareHousePaperId = wareHouseIo.Id;
                        item.LotNo = row.Cells["LotNo"].Value.ToString();
                        //item.Type = 0;
                        item.MedicineId = int.Parse(row.Cells["MedicineId"].Value.ToString());
                        //item.Volumn = int.Parse(row.Cells["Volumn"].Value.ToString());
                        //item.Unit = int.Parse(row.Cells["Unit"].Value.ToString());
                        item.UnitPrice = int.Parse(row.Cells["UnitPrice"].Value.ToString());
                        item.Amount = int.Parse(row.Cells["Amount"].Value.ToString());
                        item.ExpireDate = DateTime.Parse(row.Cells["ExpireDate"].Value.ToString());
                        if (row.Cells["Note"].Value != null)
                            //item.Note = row.Cells["Note"].Value.ToString();
                        item.CreatedDate = wareHouseIo.CreatedDate;
                        _repwhIoDetail.Insert(item);

                        //Insert data to WareHouse
                        var wareHouse = repwh.GetByIdMedicine(item.MedicineId, wareHouseIo.ClinicId);
                        if (wareHouse != null)
                        {
                            //wareHouse.Volumn += item.Volumn;
                            repwh.Update(wareHouse);
                        }
                        else
                        {
                            wareHouse = new WareHouse();
                            wareHouse.MedicineId = item.MedicineId;
                            wareHouse.ClinicId = wareHouseIo.ClinicId;
                            //wareHouse.Volumn = item.Volumn;
                            wareHouse.MinAllowed = 0;
                            repwh.Insert(wareHouse);
                        }

                        //Insert data to WareHouseDetail
                        WareHouseDetail wareHouseDetail = new WareHouseDetail();
                        wareHouseDetail.MedicineId = item.MedicineId;
                        wareHouseDetail.WareHouseId = wareHouse.Id;
                        wareHouseDetail.WareHouseIODetailId = item.Id;
                        wareHouseDetail.LotNo = item.LotNo;
                        wareHouseDetail.ExpiredDate = item.ExpireDate;
                        //wareHouseDetail.OriginalVolumn = item.Volumn;
                        //wareHouseDetail.CurrentVolumn = item.Volumn;
                        wareHouseDetail.BadVolumn = 0;
                        //wareHouseDetail.Unit = item.Unit;
                        wareHouseDetail.UnitPrice = item.UnitPrice.Value;
                        wareHouseDetail.CreatedDate = DateTime.Now;
                        wareHouseDetail.LastUpdatedDate = DateTime.Now;
                        repwhDetail.Insert(wareHouseDetail);
                    }
                }

                MessageBox.Show("Nhập kho thành công!");
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
            int volumn = 0;
            int unitPrice = 0;

            if (grd.Columns[e.ColumnIndex].Name == "MedicineId")
            {
                if (grd.Rows[e.RowIndex].Cells["MedicineId"].Value != null)
                {
                    var medicine = repMedicine.GetById(int.Parse(grd.Rows[e.RowIndex].Cells["MedicineId"].Value.ToString()));
                    grd.Rows[e.RowIndex].Cells["Unit"].Value = medicine.Define.Id;
                    grd.Rows[e.RowIndex].Cells["UnitName"].Value = medicine.Define.Name;
                }
            }

            if (grd.Columns[e.ColumnIndex].Name == "Volumn" || grd.Columns[e.ColumnIndex].Name == "UnitPrice")
            {
                if (grd.Rows[e.RowIndex].Cells["Volumn"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["Volumn"].Value.ToString(), out volumn) && grd.Rows[e.RowIndex].Cells["UnitPrice"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString(), out unitPrice))
                {
                    grd.Rows[e.RowIndex].Cells["Amount"].Value = unitPrice * volumn;
                }
            }
        }

        private bool ValidateRowData(DataGridViewRow row)
        {
            int volumn = 0;
            DateTime dtExpireDate = new DateTime();
            if (row.Cells["LotNo"].Value == null || row.Cells["MedicineId"].Value == null || row.Cells["Volumn"].Value == null || !int.TryParse(row.Cells["Volumn"].Value.ToString(), out volumn)
                || row.Cells["ExpireDate"].Value == null || !DateTime.TryParse(row.Cells["ExpireDate"].Value.ToString(), out dtExpireDate) || row.Cells["Unit"].Value == null)
            {
                return false;
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
    }
}
