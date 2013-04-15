using System;
using System.Windows.Forms;
using Medical.Data.Repositories;
using Medical.MedicineForm;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections.Generic;
using Medical.Data;
using Medical.Data.Entities;

namespace Medical.Warehouse
{
    public partial class frmWareHouse : DockContent
    {
        public int IdWareHouse;
        public int IdMedicine;
        private int minAllowed;
        public string medicineName = "";
        public int rowIndex;
        private WareHouseRepository whRepository = new WareHouseRepository();
        private ClinicRepository clinicRepository = new ClinicRepository();
        public frmWareHouse()
        {
            InitializeComponent();
            LoadToCiline();
            BuildGrid();
            FillToGrid();
        }

        private void LoadToCiline()
        {
            if (AppContext.LoggedInUser.Role > MedicineRoles.SupperManager)
            {
                cboClinic.DataSource = new List<Clinic> {clinicRepository.GetById(AppContext.CurrentClinic.Id)};
            }
            else
                cboClinic.DataSource = clinicRepository.GetAll();
        }

        private void BuildGrid()
        {
            var clmId = new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Name = "Id" };
            clmId.Visible = false;
            grd.Columns.Add(clmId);

            var clmClinicId = new DataGridViewTextBoxColumn { HeaderText = "ClinicId", DataPropertyName = "ClinicId", Name = "ClinicId" };
            clmClinicId.Visible = false;
            grd.Columns.Add(clmClinicId);

            var clmClinicName = new DataGridViewTextBoxColumn { HeaderText = "Phòng khám", DataPropertyName = "ClinicName", Name = "ClinicName" };
            clmClinicName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmClinicName);

            var clmMedicineId = new DataGridViewTextBoxColumn { HeaderText = "MedicineId", DataPropertyName = "MedicineId", Name = "MedicineId" };
            clmMedicineId.Visible = false;
            grd.Columns.Add(clmMedicineId);

            var clmMedicineName = new DataGridViewTextBoxColumn { HeaderText = "Tên thuốc", DataPropertyName = "MedicineName", Name = "MedicineName" };
            clmMedicineName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmMedicineName);

            var clmVolumn = new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "Volumn", Name = "Volumn" };
            clmVolumn.ReadOnly = true;
            grd.Columns.Add(clmVolumn);

            var clmMinAllowed = new DataGridViewTextBoxColumn { HeaderText = "Số lượng thấp nhất cho phép", DataPropertyName = "MinAllowed", Name = "MinAllowed" };
            clmMinAllowed.ReadOnly = true;
            grd.Columns.Add(clmMinAllowed);

            var clmLastUpdatedUser = new DataGridViewTextBoxColumn { HeaderText = "Người cập nhật", DataPropertyName = "LastUpdatedUser", Name = "LastUpdatedUser" };
            clmLastUpdatedUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmLastUpdatedUser);

            var clmLastUpdatedDate = new DataGridViewTextBoxColumn { HeaderText = "Thời gian cập nhật", DataPropertyName = "LastUpdatedDate", Name = "LastUpdatedDate" };
            clmLastUpdatedDate.ReadOnly = true;
            clmLastUpdatedDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmLastUpdatedDate);
        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            rowIndex = e.RowIndex;

            if (grd.Rows[e.RowIndex].Cells["MedicineId"].Value == null)
            {
                IdWareHouse = 0;
                IdMedicine = 0;
                minAllowed = 0;
            }
            else
            {
                IdWareHouse = int.Parse(grd.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                IdMedicine = int.Parse(grd.Rows[e.RowIndex].Cells["MedicineId"].Value.ToString());
                minAllowed = int.Parse(grd.Rows[e.RowIndex].Cells["MinAllowed"].Value.ToString());
            }

            if (IdWareHouse > 0)
            {
                int clinicId = 0;
                int.TryParse(cboClinic.SelectedValue.ToString(), out clinicId);
                frmWareHouseEdit frmEdit = new frmWareHouseEdit(clinicId, IdWareHouse, IdMedicine, minAllowed);
                frmEdit.StartPosition = FormStartPosition.CenterScreen;
                frmEdit.ShowDialog();

                if (rowIndex < 0)
                    FillToGrid();
                else
                    grd.Rows[rowIndex].Cells["MinAllowed"].Value = frmEdit.MinAllowed;
            }
        }

        private void FillToGrid()
        {
            grd.DataSource = whRepository.GetAll();
        }

        /// <summary>
        /// Handles the ButtonCustomClick event of the textBoxX1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void textBoxX1_ButtonCustomClick(object sender, EventArgs e)
        {
            int clinicId = 0;
            int.TryParse(cboClinic.SelectedValue.ToString(), out clinicId);
            frmWareHouseEdit frmedit = new frmWareHouseEdit(clinicId, 0, 0, 0);
            frmedit.StartPosition = FormStartPosition.CenterScreen;
            frmedit.ShowDialog();
            if (frmedit.IsOK)
            {
                FillToGrid();
            }
        }

        private void cboClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            grd.DataSource = whRepository.GetByClinicId(int.Parse(cboClinic.SelectedValue.ToString()));
        }
    }
}
