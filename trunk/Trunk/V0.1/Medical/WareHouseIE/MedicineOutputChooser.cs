using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical.WareHouseIE
{
    public partial class MedicineOutputChooser : Form
    {
        // IVWareHouseDetailRepository vwarehouseDetailRepo = new VWarehouseDetailRepository();

        private int medicineId;

        public MedicineOutputChooser(int medicineId)
        {
            InitializeComponent();
            this.medicineId = medicineId;

        }

        private void MedicineOutputChooserLoad(object sender, EventArgs e)
        {

        }
    }
}
