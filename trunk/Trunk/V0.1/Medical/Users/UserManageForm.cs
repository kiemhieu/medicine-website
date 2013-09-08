using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
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

        private readonly IUserRepository _userRepo = new UserRepository();

        public UserManageForm()
        {
            InitializeComponent();

            var roles = new List<Item>()
                            {
                                new Item(Data.Role.Administrator, "System admin"),
                                new Item(Data.Role.Doctor, "Doctor"),
                                new Item(Data.Role.Manager, "Supervisor"),
                                new Item(Data.Role.Pharmacist, "Pharmacist")
                            };
            bdsRole.DataSource = roles;
        }

        public UserManageForm(string searchCondition)
            : this()
        {
            
        }


        /// <summary>
        /// Searhes this instance.
        /// </summary>
        private void Searh() {
            this.bdgUser.DataSource = _userRepo.Get(AppContext.CurrentClinicId);
            this.bdgUser.ResetBindings(true);
            this.grdUser.ResetBindings();
            this.grdUser.Refresh();
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
            User user = (User)this.bdgUser.Current;
            if (user == null) return;
            var frmedit = new UserRegister(user);
            frmedit.ShowDialog();
            if (frmedit.DialogResult != DialogResult.Yes) return;
            Searh();
            // this.Close();
        }

        private void BtnRegisterClick(object sender, EventArgs e)
        {
            var frmedit = new UserRegister();
            frmedit.ShowDialog();
            if (frmedit.DialogResult != DialogResult.Yes) return;
            Searh();
            // this.bdgUser.Clear();
            //this.bdgUser.DataSource = userRepo.GetAll();
        }

        private void GrdUserDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

    }
}
