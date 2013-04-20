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
        private readonly IClinicRepository _clinicRepo = new ClinicRepository();
        private readonly IUserRepository _userRepo = new UserRepository();
        private readonly IMedicinePlanRepository _planingRepo = new MedicinePlanRepository();
        private readonly IMedicinePlanDetailRepository _planingDetailRepo = new MedicinePlanDetailRepository();
        private readonly IMedicineRepository _medicineRepo = new MedicineRepository();
        private readonly IWareHouseRepository _warehouseRepo = new WareHouseRepository();
        private readonly IMedicineDeliveryRepository _deliveryRepo = new MedicineDeliveryRepository();
        
        private readonly ViewModes _mode;
        private readonly int _planningId;
        private Medical.Data.Entities.MedicinePlan _medicinePlan;
        private List<Medical.Data.Entities.MedicinePlanDetail> _medicinePlanDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicinePlanningDetail"/> class.
        /// </summary>
        public MedicinePlanningDetail()
        {
            InitializeComponent();
            this._mode = ViewModes.Add;
        }

        public MedicinePlanningDetail(int medicinePlanId) : this()
        {
            this._mode = ViewModes.Update;
            this._planningId = medicinePlanId;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            bdsMedicine.DataSource = this._medicineRepo.GetAll();

            // Init Clinic combobox
            var clinic = this._clinicRepo.GetAll();
            clinic.Insert(0, new Clinic() { Id = 0, Name = "Tất cả" });
            this.bdsClinic.DataSource = clinic;
            this.cboClinic.SelectedValue = AppContext.CurrentClinic.Id;
            
            // Init User
            var users = _userRepo.GetAll();
            clinic.Insert(0, new Clinic() { Id = 0, Name = "..." });
            this.bdsEmployee.DataSource = users;

            // Get status
            bdsStatus.DataSource = MedicinePlaningStatus.GetPlanningStatus();

            InitializeData();

        }

        private void InitializeData()
        {
            // Init data
            if (this._mode == ViewModes.Add)
            {
                // Medicine plan
                this._medicinePlan = new Data.Entities.MedicinePlan();
                this._medicinePlan.Date = DateTime.Today;
                this._medicinePlan.ClinicId = AppContext.CurrentClinic.Id;

                var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0);
                date = date.AddMonths(1);
                this._medicinePlan.Month = date.Month;
                this._medicinePlan.Year = date.Year;
                this._medicinePlan.Status = 0;

                ReloadPlannedInfo();
            }
            else
            {
                this._medicinePlan = this._planingRepo.Get(this._planningId);
                if (this._medicinePlan == null) throw new Exception("Dự trù thuốc không tồn tại");
                bdsPlanning.DataSource = this._medicinePlan;

                this._medicinePlanDetails = this._planingDetailRepo.GetByPlanId(this._planningId);
                var medicines = this._medicineRepo.GetAll();

                foreach (var planDetail in _medicinePlanDetails)
                {
                    foreach (var medicine in medicines)
                    {
                        if (medicine.Id != planDetail.MedicineId) continue;
                        planDetail.TradeName = medicine.TradeName;
                        planDetail.MedicineName = medicine.Define.Name;

                        var medicinePlanDetail = new MedicinePlanDetail
                                                     {
                                                         MedicineId = medicine.Id,
                                                         Version = 0,
                                                         MedicineName = medicine.Name,
                                                         UnitName = medicine.Define.Name,
                                                         TradeName = medicine.TradeName
                                                     };
                    }

                }

                bdsPlanningDetail.DataSource = this._medicinePlanDetails;

                this.txtYear.Enabled = false;
                this.txtMonth.Enabled = false;
            }
        }
      
        private void ReloadPlannedInfo()
        {
            // Medicine plan detail
            var medicines = this._medicineRepo.GetAll();
            var stocks = _warehouseRepo.GetAll(AppContext.CurrentClinic.Id);

            var startDate1 = new DateTime(this._medicinePlan.Year, this._medicinePlan.Month, 1);
            var endDate1 = startDate1.AddMonths(1).AddDays(-1);
            var currentMonthDeliverTotal = _deliveryRepo.GetMedicineDeliveryTotal(AppContext.CurrentClinic.Id, startDate1, endDate1);

            var endDate2 = startDate1.AddDays(-1);
            var startDate2 = startDate1.AddMonths(-1);
            var lastMonthDeliverTotal = _deliveryRepo.GetMedicineDeliveryTotal(AppContext.CurrentClinic.Id, startDate2, endDate2);

            // Create Medicine Planning Detail
            this._medicinePlanDetails = new List<MedicinePlanDetail>();
            foreach (var medicine in medicines)
            {
                var medicinePlanDetail = new MedicinePlanDetail {MedicineId = medicine.Id, Version = 0, MedicineName = medicine.Name, UnitName =  medicine.Define.Name, TradeName = medicine.TradeName};

                var warehouseList = stocks.Where(x => x.MedicineId == medicine.Id).ToList();
                foreach (var medicineInStock in warehouseList)
                {
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
                this._medicinePlanDetails.Add(medicinePlanDetail);
            }

            bdsPlanning.DataSource = this._medicinePlan;
            bdsPlanningDetail.DataSource = this._medicinePlanDetails;
        }

        private void MedicinePlanningDetailLoad(object sender, EventArgs e)
        {
            Initialize();
        }

        private void GrdPlanningRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void GrdPlanningDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX) sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (this._mode == ViewModes.Add) {
                    _planingRepo.Insert(this._medicinePlan, this._medicinePlanDetails);
                    MessageBox.Show("Insert successfully");
                    this.Close();
                } 
                else
                {
                    this._medicinePlan.Status = MedicinePlaningStatus.ReEdited;
                    _planingRepo.Update(this._medicinePlan, this._medicinePlanDetails);
                    MessageBox.Show("Update successfully");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtMonthValueChanged(object sender, EventArgs e)
        {
            ReloadPlannedInfo();
        }

        private void TxtYearValueChanged(object sender, EventArgs e)
        {
            ReloadPlannedInfo();
        }

        private void BtnApprovedClick(object sender, EventArgs e)
        {
            this._planingRepo.UpdateStatus(this._planningId, MedicinePlaningStatus.Approved);
        }

        private void btnUnApproved_Click(object sender, EventArgs e)
        {
            this._planingRepo.UpdateStatus(this._planningId, MedicinePlaningStatus.NotApproved);
        }
    }
}

