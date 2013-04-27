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
    public partial class frmExportDetail : DockContent
    {
        private ClinicRepository repClinic;
        private DefineRepository repDefine;
        private MedicineRepository repMedicine;
        private WareHouseDetailRepository repwhDetail;
        private WareHouseRepository repwh;
        private WareHouseIORepository _repwhIo;
        private WareHouseIODetailRepository _repwhIoDetail;
        private WareHouseExportAllocateRepository whExport;
        private int whPaperId;
        public bool Status;
        public frmExportDetail(int exportId)
        {

            repClinic = new ClinicRepository();
            repDefine = new DefineRepository();
            repMedicine = new MedicineRepository();
            repwh = new WareHouseRepository();
            repwhDetail = new WareHouseDetailRepository();
            _repwhIo = new WareHouseIORepository();
            _repwhIoDetail = new WareHouseIODetailRepository();
            whExport = new WareHouseExportAllocateRepository();
            InitializeComponent();
            repClinic = new ClinicRepository();
            cbClinic.DataSource = repClinic.GetAll();
            dateImport.Value = DateTime.Now.Date;
            whPaperId = exportId;
            try
            {
                InitGrid();
                LoadData(exportId);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Status = false;
            if (MessageBox.Show("", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                var listPaperDetail = _repwhIoDetail.GetByIOId(whPaperId);
                foreach (var paperDetail in listPaperDetail)
                {
                    var listExport = whExport.GetByPaperDetailId(paperDetail.Id);
                    foreach (var export in listExport)
                    {
                        WareHouseDetail wareHouseDetail = repwhDetail.GetById(export.WareHouseDetailId);
                        wareHouseDetail.CurrentVolumn += export.Volumn;
                        repwhDetail.Update(wareHouseDetail);

                        WareHouse wareHouse = repwh.GetById(wareHouseDetail.WareHouseId);
                        wareHouse.Volumn += export.Volumn;
                        repwh.Update(wareHouse);

                        whExport.Delete(export.Id);
                    }

                    _repwhIoDetail.Delete(paperDetail.Id);
                }

                _repwhIo.Delete(whPaperId);
                Status = true;
                this.Close();
            }
        }

        private void LoadData(int exportId)
        {
            if (exportId > 0)
            {
                var item = _repwhIo.Get(exportId);
                if (item != null)
                {
                    txtNo.Text = item.No;
                    txtNote.Text = item.Note;
                    //txtRecipient.Text = item.Recipient;
                    //txtDeliverer.Text = item.Deliverer;
                    dateImport.Value = item.Date;
                    cbClinic.SelectedIndex = GetComboIndex(cbClinic, item.ClinicId);
                    grd.DataSource = _repwhIoDetail.GetByIOId(exportId);
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
    }
}
