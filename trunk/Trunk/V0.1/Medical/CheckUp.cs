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

        private IPrescriptionRepository prescriptionRepo = new PrescriptionRepository();
        private Prescription lastPrescription;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckUp"/> class.
        /// </summary>
        public CheckUp() {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnRegister_Click(object sender, EventArgs e) {
            var registerform = new PatientRegister();
            registerform.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the btnCheckingHistory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCheckingHistory_Click(object sender, EventArgs e) {
            var historyForm = new CheckUpHistory();
            historyForm.ShowDialog(this);
        }

        /// <summary>
        /// Handles the Click event of the btnCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCheck_Click(object sender, EventArgs e) {
            var checkUpRegister = new CheckUpRegister();
            checkUpRegister.ShowDialog(this);
        }

        /// <summary>
        /// Handles the ButtonCustomClick event of the textBoxX1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void textBoxX1_ButtonCustomClick(object sender, EventArgs e) {
            var patientBrowse = new PatientBrowseForm(this.txtSeachName.Text);
            var result = patientBrowse.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.Yes) {
                this.bdsPrescription.Clear();
                this.bdsPrescriptionDetail.Clear();

                var patient = patientBrowse.SelectedPatient;
                this.bdsPatient.DataSource = patient;
                if (patient != null) {
                    lastPrescription = prescriptionRepo.GetLastByPatient(patient.Id);
                    if (lastPrescription != null) {
                        this.bdsPrescription.DataSource = lastPrescription;
                        if (lastPrescription.PrescriptionDetails != null) this.bdsPrescriptionDetail.DataSource = lastPrescription.PrescriptionDetails;
                    }
                }
            }
        }
    }
}
