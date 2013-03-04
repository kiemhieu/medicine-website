using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical.WareHouses {
    public partial class WareHouseDetail : Form
    {
        private int clinicId;
        private int medicineId;

        public WareHouseDetail(int clinicId, int medicineId) {
            InitializeComponent();

            this.clinicId = clinicId;
            this.medicineId = medicineId;
        }

        private void Initialize()
        {
            
        }

        private void WareHouseDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
