using System;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data.Repositories;
using System.Windows.Forms;

namespace Medical.Warehouse
{
    public partial class frmInventory : DockContent
    {
        private ClinicRepository clinicRepository = new ClinicRepository();
        public frmInventory()
        {
            InitializeComponent();
            dpkFromDate.Value = DateTime.Now.Date;
            dpkToDate.Value = DateTime.Now.Date;
            cboClinic.DataSource = clinicRepository.GetAll();
            InitGrid();
        }

        private void InitGrid()
        {
            var clmMedicineName = new DataGridViewTextBoxColumn { HeaderText = "Tên thuốc", DataPropertyName = "MedicineName", Name = "MedicineName" };
            clmMedicineName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmMedicineName);

            var clmUnitName = new DataGridViewTextBoxColumn { HeaderText = "Đơn vị", DataPropertyName = "UnitName", Name = "UnitName" };
            clmUnitName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmUnitName);

            var clmImport = new DataGridViewTextBoxColumn { HeaderText = "Số thuốc nhập", DataPropertyName = "InStock", Name = "InStock" };
            clmImport.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmImport);

            var clmExport = new DataGridViewTextBoxColumn { HeaderText = "Số thuốc xuất", DataPropertyName = "CurrentMonthUsage", Name = "CurrentMonthUsage" };
            clmExport.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmExport);

            var clmRemainig = new DataGridViewTextBoxColumn { HeaderText = "Số thuốc còn trong kho", DataPropertyName = "Remaining", Name = "Remaining" };
            clmRemainig.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmRemainig);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            WareHouseRepository whRepository = new WareHouseRepository();
            int clinicId = 0;
            if (cboClinic.SelectedValue != null)
                int.TryParse(cboClinic.SelectedValue.ToString(), out clinicId);
            grd.DataSource = whRepository.GetInventory(clinicId, dpkFromDate.Value.Date, dpkToDate.Value.Date);
        }
    }
}
