using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical {

    public partial class CheckUp : DockContent
    {
        private readonly IPrescriptionRepository _prescriptionRepo;
        private readonly IPrescriptionDetailRepository _prescriptionDetailRepo;
        private IPatientRepository _patientRepo;
        private Prescription _lastPrescription;
        private Patient _selectedPatient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckUp"/> class.
        /// </summary>
        public CheckUp() {
            InitializeComponent();
            _prescriptionRepo = new PrescriptionRepository();
            _prescriptionDetailRepo = new PrescriptionDetailRepository();
            _patientRepo = new PatientRepository();
        }

        /// <summary>
        /// Handles the Click event of the btnRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnRegisterClick(object sender, EventArgs e) {
            var registerform = new PatientRegister();
            var result = registerform.ShowDialog();
            if (result != DialogResult.Yes) return;
            this._selectedPatient = registerform.Patient;
            UpdateForm(registerform.Patient);
            UpdateButtonStatus();
        }

        /// <summary>
        /// Handles the Click event of the btnCheckingHistory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnCheckingHistoryClick(object sender, EventArgs e) {
            if (this._selectedPatient == null) return;
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
        private void BtnCheckClick(object sender, EventArgs e)
        {
            if (this._selectedPatient == null) return;
            var checkUpRegister = new CheckUpRegister(this._selectedPatient);
            var result = checkUpRegister.ShowDialog(this);
            if (result == DialogResult.Cancel) return;
            UpdateForm(this._selectedPatient);
            
        }

        /// <summary>
        /// Handles the ButtonCustomClick event of the textBoxX1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TextBoxX1ButtonCustomClick(object sender, EventArgs e) {
            var patientBrowse = new PatientBrowseForm();
            var result = patientBrowse.ShowDialog(this);
            if (result != DialogResult.Yes) return;
            this._selectedPatient = patientBrowse.SelectedPatient;
            UpdateForm(patientBrowse.SelectedPatient);
            UpdateButtonStatus();
        }

        /// <summary>
        /// Datas the grid view x1 data binding complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewBindingCompleteEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1DataBindingComplete(object sender, System.Windows.Forms.DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        /// <summary>
        /// Checks up load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CheckUpLoad(object sender, EventArgs e)
        {
            UpdateButtonStatus();
        }

        /// <summary>
        /// Updates the button status.
        /// </summary>
        private void UpdateButtonStatus()
        {
            if (this._selectedPatient != null)
            {
                this.btnCheck.Enabled = true;
                this.btnCheckingHistory.Enabled = true;
            }
            else
            {
                this.btnCheck.Enabled = false;
                this.btnCheckingHistory.Enabled = false;
            }
        }

        /// <summary>
        /// Updates the form.
        /// </summary>
        /// <param name="patient">The patient.</param>
        private void UpdateForm(Patient patient)
        {
            Patient ptn = _patientRepo.GetById(patient.Id);
            this.bdsPatient.DataSource = ptn;
            _lastPrescription = _prescriptionRepo.GetLastByPatient(ptn.Id);

            if (_lastPrescription != null)
            {
                this.bdsPrescription.DataSource = _lastPrescription;
                var detailList = _prescriptionDetailRepo.GetByPrescription(_lastPrescription.Id);
                foreach (var detailItem in detailList)
                {
                    detailItem.MedicineName = detailItem.Medicine.Name;
                    detailItem.TradeName = detailItem.Medicine.TradeName;
                    detailItem.UnitName = detailItem.Medicine.Define.Name;
                }

                //this.bdsPrescription.DataSource = this.bdsPrescription;
                this.bdsPrescriptionDetail.DataSource = detailList;
                this.bdsPrescriptionDetail.ResetBindings(false);
                this.dataGridViewX1.Refresh();
            }
            else
            {
                this.bdsPrescription.Clear();
                this.bdsPrescriptionDetail.Clear();
            }



        }
    }
}
