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

        private readonly IClinicRepository _clinicRepo = new ClinicRepository();
        private readonly IMedicineRepository _medicineRepo = new MedicineRepository();
        private readonly IWareHouseRepository _warehouseRepo = new WareHouseRepository();

        public WareHouse() {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            // Init Clinic combobox
            var clinic = this._clinicRepo.GetAll();
            this.bdsClinic.DataSource = clinic;
            this.cboClinic.SelectedValue = AppContext.CurrentClinic.Id;

            // Init AutoCompleteSource
            var medicinesName = _medicineRepo.GetMedicinesName();
            var completeSource = new AutoCompleteStringCollection();
            completeSource.AddRange(medicinesName.ToArray());
            txtMedicine.AutoCompleteCustomSource = completeSource;
        }

        private void WareHouseLoad(object sender, EventArgs e)
        {
            if (cboClinic.SelectedValue == null) return;
            var clinicId = (int) cboClinic.SelectedValue;
            LoadData(clinicId, string.Empty);
        }

        private void BtnSearchClick(object sender, EventArgs e)
        {
            if (cboClinic.SelectedValue == null) return;
            var clinicId = (int)cboClinic.SelectedValue;
            var medicine = txtMedicine.Text.Trim();
            LoadData(clinicId, medicine);
        }

        private void LoadData(int clinicId, String medicineName)
        {
            var warehouseList = this._warehouseRepo.Get(clinicId, medicineName);
            this.bdsWareHouse.DataSource = warehouseList;
            this.bdsWareHouse.ResetBindings(false);
            this.dataGridViewX1.ResetBindings();

            /*
            this.errorProvider1.Clear();
            foreach (var wareHouse in warehouseList)
            {
                wareHouse.ValidateMinimumAllowedQty();
            }
            this.errorProvider1.UpdateBinding();
             */
        }

        private void DataGridViewX1DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        private void DataGridViewX1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var warehouse = this.bdsWareHouse.Current as Data.Entities.WareHouse;
            if (warehouse == null) return;

            var warehouseDetail = new WareHouseDetail(warehouse.Id);
            warehouseDetail.ShowDialog(this);
        }

        private void CboClinicSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClinic.SelectedValue == null) return;
            var clinicId = (int)cboClinic.SelectedValue;
            var medicine = txtMedicine.Text.Trim();
            LoadData(clinicId, medicine);
        }

        private void DataGridViewX1CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridViewX;
            if (grid == null) return;

            var row = grid.Rows[e.RowIndex];

            var quantity = (int) row.Cells[4].Value;
            var minimum = (int) row .Cells[3].Value;
            if (quantity == 0 || quantity < minimum)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.SelectionForeColor = Color.Red;
            } else
            {
                row.DefaultCellStyle.ForeColor = Color.Green;
                row.DefaultCellStyle.SelectionForeColor = Color.Green;
            }
        }
    }
}
