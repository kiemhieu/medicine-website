﻿using System;
using System.Windows.Forms;
using Medical.Data.Repositories;
using Medical.MedicineForm;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Warehouse
{
    public partial class frmWareHouse : DockContent
    {
        public int IdWareHouse;
        public int IdMedicine;
        public string medicineName = "";
        private WareHouseRepository whRepository = new WareHouseRepository();
        public frmWareHouse()
        {
            InitializeComponent();
            BuildGrid();
            FillToGrid();
        }

        private void BuildGrid()
        {
            grd.AutoGenerateColumns = false;

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

            var clmMinAllowed = new DataGridViewTextBoxColumn { HeaderText = "Người cập nhật", DataPropertyName = "LastUpdatedUser", Name = "LastUpdatedUser" };
            clmMedicineName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmMinAllowed);

            var clmLastUpdatedUser = new DataGridViewTextBoxColumn { HeaderText = "Thời gian cập nhật", DataPropertyName = "LastUpdatedDate", Name = "LastUpdatedDate" };
            clmLastUpdatedUser.ReadOnly = true;
            clmLastUpdatedUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmLastUpdatedUser);
        }

        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            lblID.Text = grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null ? "0" : grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString();

        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (grd.Rows[e.RowIndex].Cells["MedicineId"].Value == null)
            {
                IdWareHouse = 0;
                IdMedicine = 0;
            }

            else
            {
                IdWareHouse = int.Parse(grd.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                IdMedicine = int.Parse(grd.Rows[e.RowIndex].Cells["MedicineId"].Value.ToString());
            }
            lblID.Text = IdWareHouse.ToString();

            if (IdWareHouse > 0)
            {
                frmWareHouseEdit frmEdit = new frmWareHouseEdit(IdWareHouse, IdMedicine);                
                frmEdit.ShowDialog();
            }
            FillToGrid();
        }
        private void FillToGrid()
        {
            //this.grd.Refresh();
            //this.grd.Parent.Refresh();
            //if (grd.Rows.Count == 0)
            //{ }
            //else
            //{

            //    grd.Rows[0].Selected = true;
            //    lblID.Text = grd.Rows[0].Cells["idDataGridViewTextBoxColumn"].Value.ToString();
            //}
            grd.DataSource = whRepository.GetAll();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmWareHouseEdit frmedit = new frmWareHouseEdit();            
            frmedit.ShowDialog();
            FillToGrid();
        }
      
        /// <summary>
        /// Handles the ButtonCustomClick event of the textBoxX1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void textBoxX1_ButtonCustomClick(object sender, EventArgs e)
        {            
            frmWareHouseEdit frmedit = new frmWareHouseEdit();
            frmedit.ShowDialog();
        }
    }
}
