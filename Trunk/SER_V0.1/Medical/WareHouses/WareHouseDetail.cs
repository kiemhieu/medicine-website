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
using Medical.Data.Repositories;

namespace Medical.WareHouses {
    public partial class WareHouseDetail : Form
    {
        private int warehouseId;

        private IDefineRepository defineRepo = new DefineRepository();
        private IMedicineRepository medicineRepo = new MedicineRepository();
        private IWareHouseRepository warehouseRepo = new WareHouseRepository();
        private IVWareHouseDetailRespository vwarehouseDetailRepo = new VWareHouseDetailRepository();

        public WareHouseDetail(int id) {
            InitializeComponent();
            this.warehouseId = id;
            Initialize();
        }

        private void Initialize()
        {
            this.bdsUnit.DataSource = this.defineRepo.GetUnit();
        }

        private void WareHouseDetail_Load(object sender, EventArgs e)
        {
            var warehouse = this.warehouseRepo.Get(this.warehouseId);
            if (warehouse == null) throw new Exception("Không tồn tại số dư trong kho");

            this.bdsMedicine.DataSource = warehouse.Medicine;
            this.bdsWarehouse.DataSource = warehouse;

            var warehouseDetail = this.vwarehouseDetailRepo.GetByMedicine(warehouse.MedicineId, warehouse.ClinicId);
            this.bdsWareHouseDetail.DataSource = warehouseDetail;
        }

        private void dataGridViewX1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                // TODO: Set error and warning icon and good icon follow the quantity remain on stock
                DateTime time = (DateTime) gridView.Rows[r.Index].Cells[2].Value;
                if (time == null)
                {
                    gridView.Rows[r.Index].Cells[0].Value = global::Medical.Properties.Resources.attention;    
                }
                else if (time >  DateTime.Now)
                {
                    gridView.Rows[r.Index].Cells[0].Value = global::Medical.Properties.Resources.check;    
                }
                else if (time <= DateTime.Now)
                {
                    gridView.Rows[r.Index].Cells[0].Value = global::Medical.Properties.Resources.bonus;
                }
                
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
