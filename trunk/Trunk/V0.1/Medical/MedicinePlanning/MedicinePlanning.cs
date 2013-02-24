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
            // Init Clinic combobox
            List<Clinic> clinic = this.clinicRepo.GetAll();
            clinic.Insert(0, new Clinic(){Id = 0, Name = "Tất cả"});
            this.bdsClinic.DataSource = clinic;
            this.cboClinic.SelectedValue = AppContext.CurrentClinic.Id;

            // Set current year for first time initialize
            this.txtYear.Value = DateTime.Today.Year;

            this.bdsStatus.DataSource = this.defineRepo.GetPlanningStatus();
            this.bdsUser.DataSource = this.userRepo.GetAll();

            var planningList = medicinePlanRepo.Get(this.ClinicId, this.Year, this.Month);
            this.bdsPlanning.DataSource = planningList;
        }

        private void MedicinePlanning_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnAddPlanning_Click(object sender, EventArgs e)
        {
            var detail =new MedicinePlanningDetail();
            detail.ShowDialog(this);
        }

        #region Properties
        private int? ClinicId
        {
            get { return this.cboClinic.SelectedValue == null ? (int?)null : Convert.ToInt32(this.cboClinic.SelectedValue); }
        }

        private int? Year
        {
            get { return this.txtYear.ValueObject == null ? (int?)null : this.txtYear.Value; }
        }

        private int? Month
        {
            get { return this.txtMonth.ValueObject == null ? (int?)null : this.txtMonth.Value; }
        }

        #endregion
    }
}
