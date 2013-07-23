using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;
using Medical.Forms.UI;
using WeifenLuo.WinFormsUI.Docking;
namespace Medical.Users
{
    public partial class UserManageForm : DockContent
    {

        private readonly IUserRepository userRepo = new UserRepository();

        public UserManageForm()
        {
            InitializeComponent();
        }

        public UserManageForm(string searchCondition)
            : this()
        {
            
        }


        /// <summary>
        /// Searhes this instance.
        /// </summary>
        private void Searh() {
            this.bdgUser.DataSource = userRepo.Get(AppContext.CurrentClinicId);
        }

        /// <summary>
        /// Patients the browse form shown.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        public User SelectedUser { get; private set; }

        private void GrdPatientCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectedUser = (User) this.bdgUser.List[e.RowIndex];
            if (this.SelectedUser == null) return;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.bdgUser.EndEdit();
            var _user = (User)this.bdgUser.Current;
            if (_user == null)
            {
                MessageDialog.Instance.ShowMessage(this, "M001", "Bệnh nhân");
                return;
            }
            var frmedit = new UserRegister(_user);
            frmedit.ShowDialog();
            this.bdgUser.Clear();
            this.bdgUser.DataSource = userRepo.GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.bdgUser.EndEdit();
            var _user = (User)this.bdgUser.Current;
            if (_user == null)
            {
                MessageDialog.Instance.ShowMessage(this, "M001", "loại thuốc");
                return;
            }

            var dialogResult = MessageDialog.Instance.ShowMessage(this, "Q003", String.Format("Bệnh nhân {0}", _user.Name));

            if (dialogResult == DialogResult.No) return;
            try
            {
                this.userRepo.Delete(_user.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.bdgUser.Clear();
            this.bdgUser.DataSource = userRepo.GetAll();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var frmedit = new UserRegister();
            frmedit.ShowDialog();
           // this.bdgUser.Clear();
            //this.bdgUser.DataSource = userRepo.GetAll();
        }

        private void grdUser_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

    }
}
