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

namespace Medical {
    public partial class PatientBrowseForm : Form {

        private IPatientRepository patientRepo = new PatientRepository();

        public PatientBrowseForm() {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            try {
                this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?) this.txtBirthYear.ValueObject);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
