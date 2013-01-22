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

namespace Medical.MedicinePlanning {
    public partial class MedicinePlanning : DockContent
    {

        private IDefineRepository defineRepo = new DefineRepository();
        private IClinicRepository clinicRepo = new ClinicRepository();
        private IUserRepository userRepo = new UserRepository();
        private IMedicinePlanRepository medicinePlanRepo = new MedicinePlanRepository();


        public MedicinePlanning() {
            InitializeComponent();
        }

        private void Initialize()
        {
            List<Clinic> clinic = this.clinicRepo.GetAll();
            clinic.Insert(0, new Clinic(){Id = 0, Name = "Tất cả"});
            this.bdsClinic.DataSource = clinic;
            this.cboClinic.SelectedValue = AppContext.CurrentClinic.Id;

            this.bdsStatus.DataSource = this.defineRepo.GetPlanningStatus();

            this.bdsUser.DataSource = this.userRepo.GetAll();

            this.bdsPlanning.DataSource = this.medicinePlanRepo.GetUncompletedPlan((int)cboClinic.SelectedValue);
        }

        private void MedicinePlanning_Load(object sender, EventArgs e)
        {
            Initialize();
        }
    }
}
