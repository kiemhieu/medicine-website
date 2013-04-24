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
using Medical.Data.Entities.Views;
using Medical.Data.Repositories;

namespace Medical.WareHouseIE
{
    public partial class MedicineOutputChooser : Form
    {
        IVWareHouseDetailRespository vwarehouseDetailRepo = new VWareHouseDetailRepository();
        IMedicineRepository medicineRepo = new MedicineRepository();
        WareHouseRepository warehouseRepo = new WareHouseRepository();

        private Medicine medicine;
        private WareHouse warehouse;
        private VWareHouseDetail selectedWareHouseDetail;

        public MedicineOutputChooser(int medicineId)
        {
            InitializeComponent();

            // Get Medicine
            this.medicine = medicineRepo.GetById(medicineId);
            if (this.medicine == null) throw new Exception("Medicine dose not exist");
            this.txtMedicine.Text = this.medicine.Name;
            this.txtTradeName.Text = this.medicine.TradeName;
            this.txtUnit.Text = this.medicine.Define == null ? String.Empty : this.medicine.Define.Name;

            // Get Warehouse
            this.warehouse = warehouseRepo.GetByIdMedicine(medicineId, AppContext.CurrentClinic.Id);
            this.txtInstock.Text = this.warehouse == null ? "0" : this.warehouse.Volumn.ToString();

            var vwarehouseDetail = this.vwarehouseDetailRepo.GetByMedicine(medicineId, AppContext.CurrentClinic.Id);
            this.bdsVWarehouseDetail.DataSource = vwarehouseDetail;

        }

        private void MedicineOutputChooserLoad(object sender, EventArgs e)
        {

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
            this.selectedWareHouseDetail = (VWareHouseDetail)this.bdsVWarehouseDetail.Current;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            this.selectedWareHouseDetail = (VWareHouseDetail)this.bdsVWarehouseDetail.Current;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        public VWareHouseDetail SelectedVWareHouseDetail
        {
            get { return this.selectedWareHouseDetail; }
        }
    }
}
