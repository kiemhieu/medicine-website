using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;

using Medical.Data.Repositories;
using Medical.Forms.UI;
using WeifenLuo.WinFormsUI.Docking;
namespace Medical
{
    public partial class PatientManageForm : DockContent
    {

        private readonly IPatientRepository patientRepo = new PatientRepository();
        private readonly ClinicRepository repClinic = new ClinicRepository();
        public PatientManageForm()
        {
            InitializeComponent();
            BindClinic();
        }

        public PatientManageForm(string searchCondition)
            : this()
        {
            this.txtPatientName.Text = searchCondition;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                Searh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void Searh()
        {
            if (AppContext.LoggedInUser.Role >  MedicineRoles.SupperManager)
                this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?)this.txtBirthYear.ValueObject, AppContext.CurrentClinic.Id);
            else this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?)this.txtBirthYear.ValueObject, SelectedClinic.Id);

        }

        private void PatientBrowseForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                Searh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        public Patient SelectedPatient { get; private set; }

        private void grdPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectedPatient = (Patient)this.bdgPatient.List[e.RowIndex];
            if (this.SelectedPatient == null) return;
            var historyForm = new CheckUpHistory(SelectedPatient.Id);
            historyForm.ShowDialog(this);
            this.bdgPatient.Clear();
            if (AppContext.LoggedInUser.Role > MedicineRoles.SupperManager)
                this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?)this.txtBirthYear.ValueObject, AppContext.CurrentClinic.Id);
            else this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?)this.txtBirthYear.ValueObject);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.bdgPatient.EndEdit();
            var patient = (Patient)this.bdgPatient.Current;
            if (patient == null)
            {
                MessageDialog.Instance.ShowMessage(this, "M001", "Bệnh nhân");
                return;
            }
            var frmedit = new PatientRegister(patient);
            frmedit.ShowDialog();
            this.bdgPatient.Clear();
            this.bdgPatient.DataSource = patientRepo.GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.bdgPatient.EndEdit();
            var patient = (Patient)this.bdgPatient.Current;
            if (patient == null)
            {
                MessageDialog.Instance.ShowMessage(this, "M001", "loại thuốc");
                return;
            }

            var dialogResult = MessageDialog.Instance.ShowMessage(this, "Q003", String.Format("Bệnh nhân {0}", patient.Name));

            if (dialogResult == DialogResult.No) return;
            try
            {
                this.patientRepo.Delete(patient.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.bdgPatient.Clear();
            if (AppContext.LoggedInUser.Role > MedicineRoles.SupperManager)
                this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?)this.txtBirthYear.ValueObject, AppContext.CurrentClinic.Id);
            else this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?)this.txtBirthYear.ValueObject);

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var frmedit = new PatientRegister();
            frmedit.ShowDialog();
            this.bdgPatient.Clear();
            if (AppContext.LoggedInUser.Role > MedicineRoles.SupperManager)
                this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?)this.txtBirthYear.ValueObject, AppContext.CurrentClinic.Id);
            else this.bdgPatient.DataSource = patientRepo.GetByNameAndYear(this.txtPatientName.Text, (int?)this.txtBirthYear.ValueObject);

        }
        public Medical.Data.Entities.Clinic SelectedClinic { get; private set; }

        private void cboClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedClinic = (Clinic)this.bdsClinic.List[cboClinic.SelectedIndex];
            if (this.SelectedClinic == null) return;
        }
        private void BindClinic()
        {
            if (AppContext.LoggedInUser.Role > MedicineRoles.SupperManager)
            {
                cboClinic.DataSource = new List<Clinic> { repClinic.GetById(AppContext.CurrentClinic.Id) };
            }
            else
                bdsClinic.DataSource = repClinic.GetAll();
            if (bdsClinic.Count > 0) this.SelectedClinic = ((Clinic)bdsClinic.Current);
            else this.SelectedClinic = AppContext.CurrentClinic;

        }

        private void btnCheckingHistory_Click(object sender, EventArgs e)
        {
            var selected = (Patient)this.bdgPatient.DataSource;
            if (selected == null) return;
            var historyForm = new CheckUpHistory(selected.Id);
            historyForm.ShowDialog(this);
        }

    }
}
