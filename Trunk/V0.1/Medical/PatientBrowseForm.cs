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

namespace Medical {

    public partial class PatientBrowseForm : Form {

        private readonly IPatientRepository _patientRepo = new PatientRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientBrowseForm"/> class.
        /// </summary>
        public PatientBrowseForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientBrowseForm"/> class.
        /// </summary>
        /// <param name="searchCondition">The search condition.</param>
        public PatientBrowseForm(string searchCondition)
            : this()
        {
            this.txtPatientName.Text = searchCondition;
        }

        /// <summary>
        /// BTNs the search click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnSearchClick(object sender, EventArgs e) {
            try {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                Searh();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                this.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// Searhes this instance.
        /// </summary>
        private void Searh() {
            this.bdgPatient.DataSource = _patientRepo.Search(this.txtID.Text, 
                this.txtPatientName.Text, 
                (int?)this.txtBirthYear.ValueObject, 
                AppContext.CurrentClinic.Id);
        }

        private void PatientBrowseFormShown(object sender, EventArgs e) {
            try {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                Searh();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                this.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        public Patient SelectedPatient { get; private set; }

        private void GrdPatientCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectedPatient = (Patient) this.bdgPatient.List[e.RowIndex];
            if (this.SelectedPatient == null) return;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void TxtPatientNameTextChanged(object sender, EventArgs e)
        {
            this.bdgPatient.Filter = "Name='" + this.txtPatientName.Text + "'";
            this.grdPatient.DataSource = this.bdgPatient;
        }
    }
}
