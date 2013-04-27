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

        public List<MedicinePlan> GetUncompletedPlan(int? clinicId)
        {
            return !clinicId.HasValue || clinicId.Value == 0 ? this.Context.MedicinePlans.Where(x => x.Status != MedicinePlaningStatus.Approved).ToList() : this.Context.MedicinePlans.Where(x => x.Status != MedicinePlaningStatus.Approved && x.ClinicId == clinicId.Value).ToList();
        }

        public MedicinePlan GetById(int id)
        {
            return this.Context.MedicinePlans.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Insert(MedicinePlan MedicinePlan)
        {
            MedicinePlan.CreatedDate = DateTime.Now;
            MedicinePlan.CreatedUser = AppContext.LoggedInUser.Id;
            MedicinePlan.LastUpdatedDate = DateTime.Now;
            MedicinePlan.LastUpdatedUser = AppContext.LoggedInUser.Id;
            MedicinePlan.Version = 0;
            this.Context.MedicinePlans.Add(MedicinePlan);
            this.Context.SaveChanges();
        }

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

        public void UpdateStatus(int medicineDetailPlanningId, int status)
        {
            var medicinePlanning = this.Context.MedicinePlans.FirstOrDefault(x => x.Id == medicineDetailPlanningId);
            if (medicinePlanning == null) throw new Exception("Dự trù không tồn tại");
            medicinePlanning.Status = status;
            medicinePlanning.SetInfo(true);
            this.Context.SaveChanges();
        }

        public void Update(MedicinePlan medicinePlan)
        {
            try
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
            catch (Exception ex)
            {

                throw;
            }

        }

        public void Delete(int id)
        {
            try
            {
                var oldMedicinePlan = this.Context.MedicinePlans.FirstOrDefault(x => x.Id == id);
                this.Context.MedicinePlans.Remove(oldMedicinePlan);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<MedicinePlan> GetAll()
        {
            return this.Context.MedicinePlans.ToList();
        }

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
