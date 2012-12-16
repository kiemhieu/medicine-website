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

namespace Medical.Warehouse
{
    public partial class frmImport : DockContent
    {
        private ClinicRepository repClinic;
        private DefineRepository repDefine;
        private MedicineRepository repMedicine;
        private WareHouseDetailRepository repwhDetail;
        private WareHousePaperRepository repwhPaper;
        private WareHousePaperDetailRepository repwhPaperDetail;
        private int ClinicId;
        private int WHPaperId;
        public frmImport()
        {

            repClinic = new ClinicRepository();
            repDefine = new DefineRepository();
            repMedicine = new MedicineRepository();
            repwhDetail = new WareHouseDetailRepository();
            repwhPaper = new WareHousePaperRepository();
            repwhPaperDetail = new WareHousePaperDetailRepository();

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

            var txtSoLuong = new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "TotalVolumn", Name = "TotalVolumn" };
            grd.Columns.Add(txtSoLuong);

            var txtSoLuongHong = new DataGridViewTextBoxColumn { HeaderText = "Số lượng hỏng", DataPropertyName = "BadVolumn", Name = "BadVolumn" };
            grd.Columns.Add(txtSoLuongHong);

            var txtSoLuongThuc = new DataGridViewTextBoxColumn { HeaderText = "Số lượng thực", DataPropertyName = "RealityVolumn", Name = "RealityVolumn" };
            txtSoLuongThuc.ReadOnly = true;
            grd.Columns.Add(txtSoLuongThuc);


            var cbDonVi = new DataGridViewComboBoxColumn
            {
                DataSource = repDefine.GetUnit(),
                DisplayMember = "Name",
                ValueMember = "Id",
                DataPropertyName = "Id",
                HeaderText = "Đơn vị",
                Name = "Unit"
            };
            grd.Columns.Add(cbDonVi);

            var txtDonGia = new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = "UnitPrice", Name = "UnitPrice" };
            grd.Columns.Add(txtDonGia);

            var txtThanhTien = new DataGridViewTextBoxColumn { HeaderText = "Thành tiền", DataPropertyName = "Amount", Name = "Amount" };
            txtThanhTien.ReadOnly = true;
            grd.Columns.Add(txtThanhTien);

            var txtGhiChu = new DataGridViewTextBoxColumn { HeaderText = "Ghi chú", DataPropertyName = "Note", Name = "Note" };
            txtGhiChu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(txtGhiChu);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Insert into WareHousePaper
            try
            {
                WareHousePaper whPaper = GetWareHousePaperEntity();
                repwhPaper.Insert(whPaper);

            }
            catch (Exception)
            {

                throw;
            }

        }

        private WareHousePaper GetWareHousePaperEntity()
        {
            WareHousePaper whPaper = new WareHousePaper();
            whPaper.Id = 0;
            whPaper.No = txtNo.Text.Trim();
            whPaper.Note = txtNote.Text.Trim();
            whPaper.Recipient = txtRecipient.Text.Trim();
            whPaper.ClinicId = int.Parse(cbClinic.SelectedValue.ToString());
            whPaper.Deliverer = txtDeliverer.Text.Trim();
            whPaper.Type = 1;
            return whPaper;
        }

        private WareHousePaperDetail GetWareHousePaperDetailEntity(int GridIndex)
        {
            if (GridIndex < 0) return new WareHousePaperDetail();

            WareHousePaperDetail whPaperDetail = new WareHousePaperDetail();
            whPaperDetail.Id = 0;
            whPaperDetail.Amount = int.Parse(grd.Rows[0].Cells["Amount"].Value.ToString());
            whPaperDetail.BadVolumn = int.Parse(grd.Rows[0].Cells["BadVolumn"].Value.ToString());
            whPaperDetail.LotNo = grd.Rows[0].Cells["LotNo"].Value.ToString();
            whPaperDetail.MedicineId = int.Parse(grd.Rows[0].Cells["MedicineId"].Value.ToString());
            whPaperDetail.Note = grd.Rows[0].Cells["Note"].Value.ToString();
            whPaperDetail.PaperId = this.WHPaperId;
            return whPaperDetail;
        }

        private void cbClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClinic.SelectedIndex < 0) return;
            ClinicId = int.Parse(cbClinic.SelectedValue.ToString());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            WareHousePaper wareHousePaper = new WareHousePaper();
            wareHousePaper.ClinicId = 0;
            wareHousePaper.Date = dateImport.Value;
            wareHousePaper.Deliverer = txtDeliverer.Text;
            wareHousePaper.Recipient = txtRecipient.Text;
            wareHousePaper.Type = 0;
            wareHousePaper.Version = 0;
            wareHousePaper.No = txtNo.Text;
            wareHousePaper.Note = txtNote.Text;
            WareHousePaperRepository wareHousePaperRepository = new WareHousePaperRepository();
            wareHousePaperRepository.Insert(wareHousePaper);
            foreach (DataGridViewRow row in grd.Rows)
            {
                if (ValidateRowData(row))
                {
                    WareHousePaperDetail item = new WareHousePaperDetail();
                    item.PaperId = wareHousePaper.Id;                    
                    item.LotNo = row.Cells["LotNo"].Value.ToString();
                    item.MedicineId = int.Parse(row.Cells["MedicineId"].Value.ToString());
                    item.TotalVolumn = int.Parse(row.Cells["TotalVolumn"].Value.ToString());
                    item.BadVolumn = int.Parse(row.Cells["BadVolumn"].Value.ToString());
                    item.RealityVolumn = int.Parse(row.Cells["RealityVolumn"].Value.ToString());
                    item.Unit = int.Parse(row.Cells["Unit"].Value.ToString());
                    item.UnitPrice = int.Parse(row.Cells["UnitPrice"].Value.ToString());
                    item.Amount = int.Parse(row.Cells["Amount"].Value.ToString());
                    if (row.Cells["Note"].Value != null)
                        item.Note = row.Cells["Note"].Value.ToString();
                    repwhPaperDetail.Insert(item);
                }
            }
        }

        private void grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int totalVolumn = 0;
            int badVolumn = 0;
            int realityVolumn = 0;
            int unitPrice = 0;
            if (grd.Columns[e.ColumnIndex].Name == "TotalVolumn" || grd.Columns[e.ColumnIndex].Name == "BadVolumn")
            {
                if (grd.Rows[e.RowIndex].Cells["TotalVolumn"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["TotalVolumn"].Value.ToString(), out totalVolumn) && grd.Rows[e.RowIndex].Cells["BadVolumn"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["BadVolumn"].Value.ToString(), out badVolumn))
                {
                    grd.Rows[e.RowIndex].Cells["RealityVolumn"].Value = totalVolumn - badVolumn;
                }
            }

            if (grd.Columns[e.ColumnIndex].Name == "UnitPrice")
            {
                if (grd.Rows[e.RowIndex].Cells["RealityVolumn"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["RealityVolumn"].Value.ToString(), out realityVolumn) && grd.Rows[e.RowIndex].Cells["UnitPrice"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString(), out unitPrice))
                {
                    grd.Rows[e.RowIndex].Cells["Amount"].Value = realityVolumn * unitPrice;
                }
            }
        }

        private bool ValidateRowData(DataGridViewRow row)
        {
            int totalVolumn = 0;
            int badVolumn = 0;
            if (row.Cells["LotNo"].Value == null || row.Cells["MedicineId"].Value == null || row.Cells["TotalVolumn"].Value == null || row.Cells["BadVolumn"].Value == null
                || row.Cells["Unit"].Value == null || !int.TryParse(row.Cells["TotalVolumn"].Value.ToString(), out totalVolumn) || !int.TryParse(row.Cells["BadVolumn"].Value.ToString(), out badVolumn))
            {
                return false;
            }

            return true;
        }
    }
}
