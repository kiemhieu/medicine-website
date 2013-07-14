using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Medical.Data.Entities;
using Medical.Data.EntitiyExtend;
using IsolationLevel = System.Transactions.IsolationLevel;


namespace Medical.Data.Repositories
{
    public class MedicinePlanRepository : RepositoryBase, IMedicinePlanRepository
    {

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public MedicinePlan Get(int id)
        {
            return Context.MedicinePlans.FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Gets the by clinic.
        /// </summary>
        /// <param name="clinicId">The clinic id.</param>
        /// <returns></returns>
        public List<MedicinePlan> GetByClinic(int clinicId)
        {
            return Context.MedicinePlans.Where(x => x.ClinicId== clinicId).ToList();
        }

        /// <summary>
        /// Gets the specified clinic id.
        /// </summary>
        /// <param name="clinicId">The clinic id.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public List<MedicinePlan> Get(int? clinicId, int? year, int? month)
        {
            // var item = this.Context.Database.SqlQuery<Item>("Test");
            var medicinePlans = clinicId.HasValue
                ? this.Context.MedicinePlans.Where(x => x.ClinicId == clinicId.Value)
                : this.Context.MedicinePlans;

            medicinePlans = year.HasValue
                ? medicinePlans.Where(x => x.Year == year.Value)
                : medicinePlans;
            medicinePlans = month.HasValue
                ? medicinePlans.Where(x => x.Month == month.Value)
                : medicinePlans;
            return medicinePlans.ToList();
        }

        /// <summary>
        /// Gets the uncompleted plan.
        /// </summary>
        /// <param name="clinicId">The clinic id.</param>
        /// <returns></returns>
        public List<MedicinePlan> GetUncompletedPlan(int? clinicId)
        {
            return !clinicId.HasValue || clinicId.Value == 0 ? this.Context.MedicinePlans.Where(x => x.Status != MedicinePlaningStatus.Approved).ToList() : this.Context.MedicinePlans.Where(x => x.Status != MedicinePlaningStatus.Approved && x.ClinicId == clinicId.Value).ToList();
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public MedicinePlan GetById(int id)
        {
            return this.Context.MedicinePlans.FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Inserts the specified medicine plan.
        /// </summary>
        /// <param name="medicinePlan">The medicine plan.</param>
        public void Insert(MedicinePlan medicinePlan)
        {
            medicinePlan.CreatedDate = DateTime.Now;
            medicinePlan.CreatedUser = AppContext.LoggedInUser.Id;
            medicinePlan.LastUpdatedDate = DateTime.Now;
            medicinePlan.LastUpdatedUser = AppContext.LoggedInUser.Id;
            medicinePlan.Version = 0;
            this.Context.MedicinePlans.Add(medicinePlan);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Inserts the specified medicine plan.
        /// </summary>
        /// <param name="medicinePlan">The medicine plan.</param>
        /// <param name="medicinePlanDetails">The medicine plan details.</param>
        public void Insert(MedicinePlan medicinePlan, List<MedicinePlanDetail> medicinePlanDetails)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                medicinePlan.SetInfo(false);
                this.Context.MedicinePlans.Add(medicinePlan);
                this.Context.SaveChanges();

                foreach (var detail in medicinePlanDetails)
                {
                    detail.PlanId = medicinePlan.Id;
                    detail.SetInfo(false);
                    this.Context.MedicinePlanDetails.Add(detail);
                }
                this.Context.SaveChanges();
                scope.Complete();
            }
        }

        /// <summary>
        /// Updates the specified medicine plan.
        /// </summary>
        /// <param name="medicinePlan">The medicine plan.</param>
        /// <param name="medicinePlanDetails">The medicine plan details.</param>
        /// <exception cref="System.Exception">Dự trù không tồn tại</exception>
        public void Update(MedicinePlan medicinePlan, List<MedicinePlanDetail> medicinePlanDetails)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                var plan = this.Context.MedicinePlans.FirstOrDefault(x => x.Id == medicinePlan.Id);
                if (plan == null) throw new Exception("Dự trù không tồn tại");
                plan.Note = medicinePlan.Note;
                plan.Status = MedicinePlaningStatus.ReEdited;
                plan.SetInfo(true);

                var detailList =this.Context.MedicinePlanDetails.Where(x => x.PlanId == plan.Id).ToList();
                foreach (var detail in medicinePlanDetails)
                {
                    foreach (var original in detailList)
                    {
                        if (original.Id != detail.Id) continue;
                        original.Required = detail.Required;
                        original.SetInfo(true);
                        break;
                    }
                }
                this.Context.SaveChanges();
                scope.Complete();
            }
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="medicineDetailPlanningId">The medicine detail planning id.</param>
        /// <param name="status">The status.</param>
        /// <exception cref="System.Exception">Dự trù không tồn tại</exception>
        public void UpdateStatus(int medicineDetailPlanningId, int status)
        {
            var medicinePlanning = this.Context.MedicinePlans.FirstOrDefault(x => x.Id == medicineDetailPlanningId);
            if (medicinePlanning == null) throw new Exception("Dự trù không tồn tại");
            medicinePlanning.Status = status;
            medicinePlanning.SetInfo(true);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified medicine plan.
        /// </summary>
        /// <param name="medicinePlan">The medicine plan.</param>
        public void Update(MedicinePlan medicinePlan)
        {
            var oldMedicinePlan = this.Context.MedicinePlans.FirstOrDefault(x => x.Id == medicinePlan.Id);
            if (oldMedicinePlan == null) return;
            oldMedicinePlan.Year = medicinePlan.Year;
            oldMedicinePlan.Month = medicinePlan.Month;
            oldMedicinePlan.Date = medicinePlan.Date;
            oldMedicinePlan.ClinicId = medicinePlan.ClinicId;
            oldMedicinePlan.ApproveId = medicinePlan.ApproveId;
            oldMedicinePlan.Status = medicinePlan.Status;
            oldMedicinePlan.Note = medicinePlan.Note;
            oldMedicinePlan.LastUpdatedUser = AppContext.LoggedInUser.Id;
            oldMedicinePlan.LastUpdatedDate = DateTime.Now;
            oldMedicinePlan.Version++;
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Delete(int id)
        {
            var oldMedicinePlan = this.Context.MedicinePlans.FirstOrDefault(x => x.Id == id);
            this.Context.MedicinePlans.Remove(oldMedicinePlan);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<MedicinePlan> GetAll()
        {
            return this.Context.MedicinePlans.ToList();
        }

        /// <summary>
        /// Filters the plan.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="clinicId">The clinic id.</param>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public List<MedicinePlan> FilterPlan(int year, int month, int clinicId, string status)
        {
            /*
            if (clinicId > 0 && !string.IsNullOrEmpty(status))
                return this.Context.MedicinePlans.Where(c => c.Year == year && c.Month == month && c.ClinicId == clinicId && c.Status == status).ToList();
            else if (clinicId > 0)
                return this.Context.MedicinePlans.Where(c => c.Year == year && c.Month == month && c.ClinicId == clinicId).ToList();
            else if (!string.IsNullOrEmpty(status))
                return this.Context.MedicinePlans.Where(c => c.Year == year && c.Month == month && c.Status == status).ToList();

             */
            return null;
        }
    }
}
