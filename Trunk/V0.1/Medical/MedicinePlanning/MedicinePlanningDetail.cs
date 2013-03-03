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
using Medical.Forms.Enums;

namespace Medical.MedicinePlanning
{
    public partial class MedicinePlanningDetail : Form
    {
        private IClinicRepository clinicRepo = new ClinicRepository();
        private IUserRepository userRepo = new UserRepository();
        private IMedicinePlanRepository planingRepo = new MedicinePlanRepository();
        private IMedicinePlanDetailRepository planingDetailRepo = new MedicinePlanDetailRepository();
        private IMedicineRepository medicineRepo = new MedicineRepository();
        private IWareHouseRepository warehouseRepo = new WareHouseRepository();
        private IMedicineDeliveryRepository deliveryRepo = new MedicineDeliveryRepository();
        
        private ViewModes mode;
        private int planningId;
        private Medical.Data.Entities.MedicinePlan medicinePlan;
        private List<Medical.Data.Entities.MedicinePlanDetail> medicinePlanDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicinePlanningDetail"/> class.
        /// </summary>
        public MedicinePlanningDetail()
        {
            InitializeComponent();
            this.mode = ViewModes.Add;
        }

        public MedicinePlanningDetail(int medicinePlanId) : this()
        {
            this.mode = ViewModes.Update;
            this.planningId = medicinePlanId;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            bdsMedicine.DataSource = this.medicineRepo.GetAll();

            // Init Clinic combobox
            var clinic = this.clinicRepo.GetAll();
            clinic.Insert(0, new Clinic() { Id = 0, Name = "Tất cả" });
            this.bdsClinic.DataSource = clinic;
            this.cboClinic.SelectedValue = AppContext.CurrentClinic.Id;
            
            // Init User
            var users = userRepo.GetAll();
            clinic.Insert(0, new Clinic() { Id = 0, Name = "..." });
            this.bdsEmployee.DataSource = users;

            // Get status
            bdsStatus.DataSource = MedicinePlaningStatus.GetPlanningStatus();

            // Init data
            if (this.mode == ViewModes.Add)
            {
                // Medicine plan
                this.medicinePlan = new Data.Entities.MedicinePlan();
                this.medicinePlan.Date = DateTime.Today;
                this.medicinePlan.ClinicId = AppContext.CurrentClinic.Id;

                var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                date = date.AddMonths(1);
                this.medicinePlan.Month = date.Month;
                this.medicinePlan.Year = date.Year;

                this.medicinePlan.Status = 0;

                ReloadPlannedInfo();
            } else {
                this.medicinePlan = this.planingRepo.Get(this.planningId);
                if (this.medicinePlan == null) throw new Exception("Dự trù thuốc không tồn tại");
                bdsPlanning.DataSource = this.medicinePlan;

                this.medicinePlanDetails = this.planingDetailRepo.GetByPlanId(this.planningId);
                bdsPlanningDetail.DataSource = this.medicinePlanDetails;

                this.txtYear.Enabled = false;
                this.txtMonth.Enabled = false;
            }
        }
      
        private void ReloadPlannedInfo()
        {
            // Medicine plan detail
            var medicines = this.medicineRepo.GetAll();
            var stocks = warehouseRepo.GetAll(AppContext.CurrentClinic.Id);

            DateTime startDate1 = new DateTime(this.medicinePlan.Year, this.medicinePlan.Month, 1);
            DateTime endDate1 = startDate1.AddMonths(1).AddDays(-1);
            var currentMonthDeliverTotal = deliveryRepo.GetMedicineDeliveryTotal(AppContext.CurrentClinic.Id, startDate1, endDate1);

            DateTime endDate2 = startDate1.AddDays(-1);
            DateTime startDate2 = startDate1.AddMonths(-1);
            var lastMonthDeliverTotal = deliveryRepo.GetMedicineDeliveryTotal(AppContext.CurrentClinic.Id, startDate2, endDate2);

            // Create Medicine Planning Detail
            this.medicinePlanDetails = new List<MedicinePlanDetail>();
            foreach (Medicine medicine in medicines)
            {
                MedicinePlanDetail medicinePlanDetail = new MedicinePlanDetail();
                medicinePlanDetail.MedicineId = medicine.Id;
                medicinePlanDetail.Version = 0;

                foreach (var medicineInStock in stocks)
                {
                    if (medicineInStock.Id != medicine.Id) continue;
                    medicinePlanDetail.InStock = medicineInStock.Volumn;
                    break;
                }

                foreach (var currentMonthUsage in currentMonthDeliverTotal)
                {
                    if (currentMonthUsage.MedicineId != medicine.Id) continue;
                    medicinePlanDetail.CurrentMonthUsage = currentMonthUsage.Quantity;
                    break;
                }

                foreach (var lastMonthUsage in lastMonthDeliverTotal)
                {
                    if (lastMonthUsage.MedicineId != medicine.Id) continue;
                    medicinePlanDetail.CurrentMonthUsage = lastMonthUsage.Quantity;
                    break;
                }

                medicinePlanDetail.Required = medicinePlanDetail.LastMonthUsage - medicinePlanDetail.CurrentMonthUsage - medicinePlanDetail.InStock;
                if (medicinePlanDetail.Required < 0) medicinePlanDetail.Required = 0;
                this.medicinePlanDetails.Add(medicinePlanDetail);
            }

            bdsPlanning.DataSource = this.medicinePlan;
            bdsPlanningDetail.DataSource = this.medicinePlanDetails;
        }

        private void MedicinePlanningDetail_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void grdPlanning_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void grdPlanning_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX) sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.mode == ViewModes.Add) {
                    planingRepo.Insert(this.medicinePlan, this.medicinePlanDetails);
                    MessageBox.Show("Insert successfully");
                    this.Close();
                } 
                else
                {
                    this.medicinePlan.Status = MedicinePlaningStatus.ReEdited;
                    planingRepo.Update(this.medicinePlan, this.medicinePlanDetails);
                    MessageBox.Show("Update successfully");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMonth_ValueChanged(object sender, EventArgs e)
        {
            ReloadPlannedInfo();
        }

        private void txtYear_ValueChanged(object sender, EventArgs e)
        {
            ReloadPlannedInfo();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            this.planingRepo.UpdateStatus(this.planningId, MedicinePlaningStatus.Approved);
        }

        private void btnUnApproved_Click(object sender, EventArgs e)
        {
            this.planingRepo.UpdateStatus(this.planningId, MedicinePlaningStatus.NotApproved);
        }
    }
}
