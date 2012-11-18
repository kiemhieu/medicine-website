using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical {
    public partial class CheckUp : DockContent {


        public CheckUp() {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            var registerform = new PatientRegister();
            registerform.ShowDialog();
        }

        private void btnCheckingHistory_Click(object sender, EventArgs e) {
            var historyForm = new CheckUpHistory();
            historyForm.ShowDialog(this);
        }

        private void btnCheck_Click(object sender, EventArgs e) {
            var checkUpRegister = new CheckUpRegister();
            checkUpRegister.ShowDialog(this);
        }

        private void textBoxX1_ButtonCustomClick(object sender, EventArgs e) {
            var patientBrowse = new PatientBrowseForm(this.txtSeachName.Text);
            var result = patientBrowse.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.Yes) {
                this.bdsPatient.DataSource = patientBrowse.SelectedPatient;
            }
        }
    }
}
