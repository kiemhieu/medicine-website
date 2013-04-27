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

namespace Medical.Test
{
    public partial class frmImportWH : DockContent
    {
        private ClinicRepository repClinic;
        private MedicineRepository repMedicine;
        private WareHouseDetailRepository repwhDetail;
        private WareHousePaperRepository repwhPaper;
        private WareHousePaperDetailRepository repwhPaperDetail;
        private int ClinicId;
        private int WHPaperId;
        public frmImportWH()
        {

            repClinic = new ClinicRepository();
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
        private void  FillToComboboxClinic(int clinicId)
        {
            if (clinicId > 0)
            {
                bindingSource2.DataSource = repClinic.GetById(clinicId);

            }
            else bindingSource2.DataSource = repClinic.GetAll();
        }
        
        private  void InitGrid()
        {
            // add column thuoc
            var cbMed = new DataGridViewComboBoxColumn
            {
                DataSource = repMedicine.GetAll(),
                DisplayMember = "Name",
                ValueMember = "Id",
                DataPropertyName = "MedicineId",
                HeaderText = "Thuốc"
            };
            grd.Columns.Add(cbMed);

            var txtLotno = new DataGridViewTextBoxColumn { HeaderText = "Số lô", DataPropertyName ="LotNo"};
            grd.Columns.Add(txtLotno);

            var txtSoLuong = new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "TotalVolumn" };
            grd.Columns.Add(txtSoLuong);

            var txtSoLuongHong = new DataGridViewTextBoxColumn { HeaderText = "Số lượng hỏng", DataPropertyName = "BadVolumn" };
            grd.Columns.Add(txtSoLuongHong);

            var txtSoLuongThuc = new DataGridViewTextBoxColumn { HeaderText = "Số lượng thực", DataPropertyName = "RealityVolumn" };
            grd.Columns.Add(txtSoLuongThuc);

            var cbDonVi = new DataGridViewComboBoxColumn
            {
                //DataSource = repMedicine.GetAll(),
                DisplayMember = "Name",
                ValueMember = "Id",
                DataPropertyName = "Id",
                HeaderText = "Đơn vị"
            };
            grd.Columns.Add(cbDonVi);

            var txtDonGia = new DataGridViewTextBoxColumn { HeaderText = "Đơn giá",DataPropertyName = "UnitPrice" };
            grd.Columns.Add(txtDonGia);

            var txtThanhTien = new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = "Amount" };
            grd.Columns.Add(txtThanhTien);

            var txtGhiChu = new DataGridViewTextBoxColumn { HeaderText = "Ghi chú", DataPropertyName = "Note" };
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
            // whPaperDetail.BadVolumn = int.Parse(grd.Rows[0].Cells["BadVolumn"].Value.ToString());
            whPaperDetail.LotNo = grd.Rows[0].Cells["LotNo"].Value.ToString();
            whPaperDetail.MedicineId = int.Parse(grd.Rows[0].Cells["MedicineId"].Value.ToString());
            whPaperDetail.Note = grd.Rows[0].Cells["Note"].Value.ToString();
            // whPaperDetail.PaperId = this.WHPaperId;
            return whPaperDetail;
        }

        private void cbClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbClinic.SelectedIndex < 0) return;
            ClinicId = int.Parse(cbClinic.SelectedValue.ToString());
        }
    }
}
