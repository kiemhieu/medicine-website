using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Repositories;

namespace Medical.WareHouses {
    public partial class WareHouseSetUp : Form
    {

        private int warehouseId;
        private WareHouse warehouse;
        private IWareHouseRepository _warehouseRepo = new WareHouseRepository();
        
        public WareHouseSetUp(int warehouseId) {
            InitializeComponent();
            this.warehouseId = warehouseId;
            warehouse = _warehouseRepo.GetById()
        }
    }
}
