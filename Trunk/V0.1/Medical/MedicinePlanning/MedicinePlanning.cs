using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
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
        private IMedicineDeliveryRepository medicineDeliveryRepo = new MedicineDeliveryRepository();


        public MedicinePlanning() {
            InitializeComponent();
        }

        private void Initialize()
        {
            // Init Clinic combobox
            var clinic = this.clinicRepo.GetAll();
            clinic.Insert(0, new Clinic(){Id = 0, Name = "Tất cả"});
            this.bdsClinic.DataSource = clinic;
            this.cboClinic.SelectedValue = AppContext.CurrentClinic.Id;

            // Set current year for first time initialize
            this.txtYear.Value = DateTime.Today.Year;

            this.bdsStatus.DataSource = MedicinePlaningStatus.GetPlanningStatus();
            this.bdsUser.DataSource = this.userRepo.GetAll();

            var planningList = medicinePlanRepo.Get(this.ClinicId, this.Year, this.Month);
            this.bdsPlanning.DataSource = planningList;

            // var deliveryTotal = medicineDeliveryRepo.GetMedicineDeliveryTotal(1, new DateTime(2013, 01, 01), new DateTime(2014, 01, 01));
            // Console.WriteLine(deliveryTotal.Count);
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

        private void dataGridViewX1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
