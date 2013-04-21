using System;
using System.Windows.Forms;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data;
using Medical.Data.Entities;
using System.Collections.Generic;

namespace Medical.Forms.UI
{
    public partial class frmSynchr : Form
    {
        public int IdClinic;
        private ClinicRepository clinicRepository = new ClinicRepository();
        private ClinicRepository clinicServerRepository = new ClinicRepository(true);

        private MedicineRepository medicineRep = new MedicineRepository();
        private MedicineRepository medicineServerRep = new MedicineRepository(true);

        private TableChangeRepository tableChangeServerRep = new TableChangeRepository(true);

        public frmSynchr()
        {
            InitializeComponent();
            FillToGrid();
        }
    
        private void FillToGrid()
        {
            if (AppContext.LoggedInUser.Role > MedicineRoles.SupperManager)
            {
                bdsClinic.DataSource = new List<Clinic> { clinicRepository.GetById(AppContext.CurrentClinic.Id) };
            }
            else
                bdsClinic.DataSource = clinicRepository.GetAll();
            this.grd.Refresh();
            this.grd.Parent.Refresh();

            if (bdsClinic.Count > 0) this.Clinic = (Clinic)bdsClinic.Current;
        }

        private void btnSynch_Click(object sender, System.EventArgs e)
        {
            if (this.Clinic == null || this.Clinic.Id == 0) return;
            var dialogResult = Medical.Forms.UI.MessageDialog.Instance.ShowMessage(this, "Q009", this.Clinic.Name);
            if (dialogResult == DialogResult.No) return;

            // Update tu server
            List<TableChange> lstServer =  tableChangeServerRep.GetByClinicId(1);

            Medicine _clientEntiy;
            Medicine _serverEntity;
            if (lstServer.Count > 0)
            {
                foreach (TableChange ent in lstServer)
                {
                    switch (ent.TableName.ToString())
                    {
                        case "Medicine":
                           _serverEntity = medicineServerRep.GetById(ent.Id);
                            if(ent.Action.Equals("I"))
                            {
                                if ((Medicine)medicineRep.GetById(ent.Id) == null)
                                {
                                    _clientEntiy = new Medicine();
                                    _clientEntiy = medicineRep.CopyEntity(_clientEntiy, _serverEntity);
                                    medicineRep.Insert(_clientEntiy);
                                }
                            }
                            if (ent.Action.Equals("U"))
                            {
                                if ((Medicine)medicineRep.GetById(ent.Id) != null)
                                {
                                    _clientEntiy = medicineRep.GetById(ent.Id);
                                    _clientEntiy = medicineRep.CopyEntity(_serverEntity, _clientEntiy);
                                    medicineRep.Update(_clientEntiy);
                                }
                            }
                            break;
                        case "Clinic":
                            break;
                    }
                }
            }
            
        }




        /// <summary>
        /// Gets the ChangePassword.
        /// </summary>
        public Clinic Clinic { get; private set; }
    }
}
