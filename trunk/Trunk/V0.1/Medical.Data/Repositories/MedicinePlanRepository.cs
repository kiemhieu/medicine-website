using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;


namespace Medical.Data.Repositories
{
    public class MedicinePlanRepository : RepositoryBase, Medical.Data.IMedicinePlanRepository
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

        public MedicinePlan GetById(int id)
        {
            return this.Context.MedicinePlans.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Insert(MedicinePlan MedicinePlan)
        {
            MedicinePlan.CreatedDate = DateTime.Now;
            MedicinePlan.CreatedUser = AppContext.LoggedInUser.Id;            
            MedicinePlan.LastUpdatedDate = DateTime.Now;
            MedicinePlan.Version = 0;
            this.Context.MedicinePlans.Add(MedicinePlan);
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
    }
}
