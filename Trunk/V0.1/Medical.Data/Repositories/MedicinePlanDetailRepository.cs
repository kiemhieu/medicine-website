using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;


namespace Medical.Data.Repositories
{
    public class MedicinePlanDetailRepository : RepositoryBase, Medical.Data.IMedicinePlanDetailRepository
    {

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public MedicinePlanDetail Get(int id)
        {
            return Context.MedicinePlanDetails.FirstOrDefault(x => x.Id.Equals(id));
        }

        public MedicinePlanDetail GetById(int id)
        {
            return this.Context.MedicinePlanDetails.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Insert(MedicinePlanDetail MedicinePlanDetail)
        {
            MedicinePlanDetail.Version = 0;
            this.Context.MedicinePlanDetails.Add(MedicinePlanDetail);
            this.Context.SaveChanges();
        }

        public void Update(MedicinePlanDetail medicinePlanDetail)
        {
            try
            {
                var oldMedicinePlanDetail = this.Context.MedicinePlanDetails.FirstOrDefault(x => x.Id == medicinePlanDetail.Id);
                if (oldMedicinePlanDetail == null) return;
                oldMedicinePlanDetail.PlanId = medicinePlanDetail.PlanId;
                oldMedicinePlanDetail.MedicineId = medicinePlanDetail.MedicineId;
                oldMedicinePlanDetail.InStock = medicinePlanDetail.InStock;
                oldMedicinePlanDetail.LastMonthUsage = medicinePlanDetail.LastMonthUsage;
                oldMedicinePlanDetail.CurrentMonthUsage = medicinePlanDetail.CurrentMonthUsage;
                oldMedicinePlanDetail.Required = medicinePlanDetail.Required;
                oldMedicinePlanDetail.UnitPrice = medicinePlanDetail.UnitPrice;
                oldMedicinePlanDetail.UnitPrice = medicinePlanDetail.UnitPrice;
                oldMedicinePlanDetail.Amount = medicinePlanDetail.Amount;
                oldMedicinePlanDetail.LastUpdatedDate = DateTime.Now;
                oldMedicinePlanDetail.Version++;
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
                var oldMedicinePlanDetail = this.Context.MedicinePlanDetails.FirstOrDefault(x => x.Id == id);
                this.Context.MedicinePlanDetails.Remove(oldMedicinePlanDetail);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<MedicinePlanDetail> GetAll()
        {
            return this.Context.MedicinePlanDetails.ToList();
        }
    }
}
