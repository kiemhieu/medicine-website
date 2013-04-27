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

        private void CheckOnDate_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            var patientList = prescriptionRepo.GetAllOnLate(this.txtPatientName.Text);
            var index = 1;
            foreach (var item in patientList)
            {
                item.No = index++;
            }
            this.bdsCheckOnDate.DataSource = patientList;
            this.bdsCheckOnDate.ResetBindings(true);
            this.dataGridViewX1.Refresh();
        }
    }
}
