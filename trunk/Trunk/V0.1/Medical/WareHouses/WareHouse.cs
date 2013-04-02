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
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.WareHouses {
    public partial class WareHouse : DockContent
    {

        private IClinicRepository clinicRepo = new ClinicRepository();
        private IUserRepository userRepo = new UserRepository();
        private IMedicineRepository medicineRepo = new MedicineRepository();
        private IWareHouseRepository warehouseRepo = new WareHouseRepository();

        public WareHouse() {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            // Init Clinic combobox
            var clinic = this.clinicRepo.GetAll();
            this.bdsClinic.DataSource = clinic;
            this.cboClinic.SelectedValue = AppContext.CurrentClinic.Id;

            // Init AutoCompleteSource
            var medicinesName = medicineRepo.GetMedicinesName();
            var completeSource = new AutoCompleteStringCollection();
            completeSource.AddRange(medicinesName.ToArray());
            txtMedicine.AutoCompleteCustomSource = completeSource;
        }

        private void WareHouse_Load(object sender, EventArgs e)
        {
            var clinicId = (int) cboClinic.SelectedValue;
            LoadData(clinicId, string.Empty);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var clinicId = (int)cboClinic.SelectedValue;
            var medicine = txtMedicine.Text.Trim();
            LoadData(clinicId, medicine);
        }

        private void LoadData(int clinicId, String medicineName)
        {
            var warehouseList = this.warehouseRepo.Get(clinicId, medicineName);
            this.bdsWareHouse.DataSource = warehouseList;
            this.bdsWareHouse.ResetBindings(false);
            this.dataGridViewX1.ResetBindings();
        }

        private void dataGridViewX1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                // TODO: Set error and warning icon and good icon follow the quantity remain on stock
                gridView.Rows[r.Index].Cells[0].Value = global::Medical.Properties.Resources.accept;
            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var warehouse = this.bdsWareHouse.Current as Data.Entities.WareHouse;
            if (warehouse == null) return;

            var warehouseDetail = new WareHouseDetail(warehouse.Id);
            warehouseDetail.ShowDialog(this);
        }

        private void cboClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            var clinicId = (int)cboClinic.SelectedValue;
            var medicine = txtMedicine.Text.Trim();
            LoadData(clinicId, medicine);
        }
    }
}
