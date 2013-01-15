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
    public partial class frmImportDetail : DockContent
    {
        private ClinicRepository repClinic;
        private DefineRepository repDefine;
        private MedicineRepository repMedicine;
        private WareHouseDetailRepository repwhDetail;
        private WareHouseRepository repwh;
        private WareHousePaperRepository repwhPaper;
        private WareHousePaperDetailRepository repwhPaperDetail;
        private int ClinicId;
        public frmImportDetail(int importId)
        {

            repClinic = new ClinicRepository();
            repDefine = new DefineRepository();
            repMedicine = new MedicineRepository();
            repwh = new WareHouseRepository();
            repwhDetail = new WareHouseDetailRepository();
            repwhPaper = new WareHousePaperRepository();
            repwhPaperDetail = new WareHousePaperDetailRepository();

            InitializeComponent();
            repClinic = new ClinicRepository();
            cbClinic.DataSource = repClinic.GetAll();
            dateImport.Value = DateTime.Now.Date;

            try
            {
                InitGrid();
                LoadData(importId);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void InitGrid()
        {
            // add column thuoc            
            var txtMed = new DataGridViewTextBoxColumn { HeaderText = "Thuốc", DataPropertyName = "MedicineName", Name = "MedicineName" };
            grd.Columns.Add(txtMed);            

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

        private void LoadData(int importId)
        {
            if (importId > 0)
            {
                var item = repwhPaper.Get(importId);
                if (item != null)
                {
                    txtNo.Text = item.No;
                    txtNote.Text = item.Note;
                    //txtRecipient.Text = item.Recipient;
                    // txtDeliverer.Text = item.Deliverer;
                    dateImport.Value = item.Date;
                    cbClinic.SelectedIndex = GetComboIndex(cbClinic, item.ClinicId);

                    grd.DataSource = repwhPaperDetail.GetByPaperId(importId);
                }
            }
        }

        private int GetComboIndex(ComboBox cbo, int value)
        {
            int i = 0;
            foreach (Clinic item in cbo.Items)
            {
                if (item.Id == value)
                {
                    return i;
                }

                i++;
            }

            return 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
