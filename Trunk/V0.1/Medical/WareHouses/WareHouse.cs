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
using Medical.Forms.UI;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.WareHouses {
    public partial class WareHouse : DockContent
    {

        private readonly IClinicRepository _clinicRepo = new ClinicRepository();
        private readonly IMedicineRepository _medicineRepo = new MedicineRepository();
        private readonly IWareHouseRepository _warehouseRepo = new WareHouseRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="WareHouse"/> class.
        /// </summary>
        public WareHouse() {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
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

        /// <summary>
        /// Wares the house load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void WareHouseLoad(object sender, EventArgs e)
        {
            if (cboClinic.SelectedValue == null) return;
            var clinicId = (int) cboClinic.SelectedValue;
            LoadData(clinicId, string.Empty);
        }

        /// <summary>
        /// BTNs the search click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnSearchClick(object sender, EventArgs e)
        {
            if (cboClinic.SelectedValue == null) return;
            var clinicId = (int)cboClinic.SelectedValue;
            var medicine = txtMedicine.Text.Trim();
            LoadData(clinicId, medicine);
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="clinicId">The clinic id.</param>
        /// <param name="medicineName">Name of the medicine.</param>
        private void LoadData(int clinicId, String medicineName)
        {
            var warehouseList = this._warehouseRepo.Get(clinicId, medicineName);
            this.bdsWareHouse.DataSource = warehouseList;
            this.bdsWareHouse.ResetBindings(true);
            // this.dataGridViewX1.ResetBindings();
            this.dataGridViewX1.Refresh();

            /*
            this.errorProvider1.Clear();
            foreach (var wareHouse in warehouseList)
            {
                wareHouse.ValidateMinimumAllowedQty();
            }
            this.errorProvider1.UpdateBinding();
             */
        }

        /// <summary>
        /// Datas the grid view x1 data binding complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewBindingCompleteEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        /// <summary>
        /// Datas the grid view x1 cell double click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var warehouse = this.bdsWareHouse.Current as Data.Entities.WareHouse;
            if (warehouse == null) return;

            var warehouseDetail = new WareHouseDetail(warehouse.Id);
            warehouseDetail.ShowDialog(this);
        }

        /// <summary>
        /// Cboes the clinic selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CboClinicSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClinic.SelectedValue == null) return;
            var clinicId = (int)cboClinic.SelectedValue;
            var medicine = txtMedicine.Text.Trim();
            LoadData(clinicId, medicine);
        }

        /// <summary>
        /// Datas the grid view x1 cell formatting.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellFormattingEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Mnus the setup click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MnuSetupClick(object sender, EventArgs e)
        {
            try
            {
                var warehouse = this.bdsWareHouse.Current as Medical.Data.Entities.WareHouse;
                if (warehouse == null) return;
                var setupForm = new WareHouseSetUp(warehouse.Id);
                setupForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageDialog.Instance.ShowMessage(this, "ERR0002", ex.Message);
            }
            finally
            {
                var clinicId = (int)cboClinic.SelectedValue;
                var medicine = txtMedicine.Text.Trim();
                LoadData(clinicId, medicine);
            }
        }

        /// <summary>
        /// Datas the grid view x1 rows added.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewRowsAddedEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridViewX1.Rows[e.RowIndex].ContextMenuStrip = ctmMenu;
        }

        /// <summary>
        /// Datas the grid view x1 row context menu strip needed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewRowContextMenuStripNeededEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            dataGridViewX1.Rows[e.RowIndex].Selected = true;
            e.ContextMenuStrip = ctmMenu;
        }
    }
}
