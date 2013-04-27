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

        private readonly IPatientRepository patientRepo = new PatientRepository();
        
        private int ClinicId=0;
        public PatientBrowseForm() {
            InitializeComponent();
            
        }

        public PatientBrowseForm(string searchCondition)
            : this()
        {
            this.txtPatientName.Text = searchCondition;
        }
        public PatientBrowseForm(string searchCondition, int clinicId)
            : this()
        {
            ClinicId = clinicId;
            this.txtPatientName.Text = searchCondition;
        }
        private void btnSearch_Click(object sender, EventArgs e) {
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

        private void Searh() {
            if (ClinicId == null || ClinicId < 1) this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?)this.txtBirthYear.ValueObject, AppContext.CurrentClinic.Id);
            else
            this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?)this.txtBirthYear.ValueObject, this.ClinicId);
        }

        private void PatientBrowseForm_Shown(object sender, EventArgs e) {
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

        private void grdPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectedPatient = (Patient) this.bdgPatient.List[e.RowIndex];
            if (this.SelectedPatient == null) return;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
