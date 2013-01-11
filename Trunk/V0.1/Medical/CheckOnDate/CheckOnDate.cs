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
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.CheckOnDate {
    public partial class CheckOnDate : DockContent {

        private IPrescriptionRepository prescriptionRepo = new PrescriptionRepository();

        public CheckOnDate() {
            InitializeComponent();
        }

        private void CheckOnDate_Load(object sender, EventArgs e) {
            
        }
    }
}
