using System;
using System.Collections.Generic;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical {
    public partial class CheckUp : DockContent {

        private IPrescriptionRepository prescriptionRepo = new PrescriptionRepository();
        private IPrescriptionDetailRepository prescriptionDetailRepo = new PrescriptionDetailRepository();
        private Prescription lastPrescription;
        private Patient selectedPatient;

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
            var result = registerform.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.Yes) return;
            UpdateForm(registerform.Patient);
        }

        /// <summary>
        /// Handles the Click event of the btnCheckingHistory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCheckingHistory_Click(object sender, EventArgs e) {
            var selected = (Patient)this.bdsPatient.Current;
            if (selected == null) return;
            var historyForm = new CheckUpHistory(selected.Id);
            historyForm.ShowDialog(this);
        }

        /// <summary>
        /// Handles the Click event of the btnCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (this.bdsPatient.DataSource is Patient)
            {
                var selected = (Patient) this.bdsPatient.DataSource;
                if (selected == null) return;
                var checkUpRegister = new CheckUpRegister(selected);
                checkUpRegister.ShowDialog(this);
                UpdateForm((Patient)this.bdsPatient.DataSource);
            }
        }

        /// <summary>
        /// Handles the ButtonCustomClick event of the textBoxX1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void textBoxX1_ButtonCustomClick(object sender, EventArgs e) {
            var patientBrowse = new PatientBrowseForm();
            var result = patientBrowse.ShowDialog(this);
            if (result != System.Windows.Forms.DialogResult.Yes) return;

            UpdateForm(patientBrowse.SelectedPatient);
        }

        /// <summary>
        /// Updates the form.
        /// </summary>
        /// <param name="patient">The patient.</param>
        private void UpdateForm(Patient patient)
        {
            this.bdsPrescription.Clear();
            this.bdsPrescriptionDetail.Clear();
            this.bdsPatient.DataSource = patient;
            this.selectedPatient = patient;

            if (patient == null)
            {
                this.btnCheck.Enabled = false;
                return;
            }

            this.btnCheck.Enabled = true;
            lastPrescription = prescriptionRepo.GetLastByPatient(patient.Id);

            if (lastPrescription == null) return;
            this.bdsPrescription.DataSource = lastPrescription;

            List<PrescriptionDetail> detailList = prescriptionDetailRepo.GetByPrescription(lastPrescription.Id);
            if (detailList != null)
            {
                for (int i = 0; i < detailList.Count; i++)
                {
                    detailList[i].No = i + 1;
                }
                this.bdsPrescriptionDetail.DataSource = detailList;
            }
        }
    }
}
