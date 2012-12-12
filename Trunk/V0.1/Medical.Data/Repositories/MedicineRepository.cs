using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class MedicineRepository : RepositoryBase, IMedicineRepository
    {

        public Medicine GetById(int id)
        {
            return this.Context.Medicines.FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="clinic">The clinic.</param>
        /// <returns></returns>
        public bool Login(string username, string password, int clinic)
        {
            var user =
                this.Context.Users.FirstOrDefault(
                    x =>
                    x.UserName.Equals(username) && x.Password.Equals(password) && x.Active == true &&
                    x.ClinicId == clinic);
            return user != null;
        }

        public void Insert(Medicine medicine)
        {
            medicine.CreatedBy = AppContext.LoggedInUser.Id;
            medicine.LastUpdatedBy = AppContext.LoggedInUser.Id;
            medicine.CreatedDate = DateTime.Now;
            medicine.LastUpdatedDate = DateTime.Now;
            medicine.Version = 0;
            this.Context.Medicines.Add(medicine);
            this.Context.SaveChanges();
        }

        public void Update(Medicine medicine)
        {
            var oldMedicine = this.Context.Medicines.FirstOrDefault(x => x.Id == medicine.Id);
            if (oldMedicine == null) return;
            oldMedicine.Name = medicine.Name;
            oldMedicine.TradeName = medicine.TradeName;
            oldMedicine.Unit = medicine.Unit;
            oldMedicine.Content = medicine.Content;
            oldMedicine.ContentUnit = medicine.ContentUnit;
            oldMedicine.LastUpdatedDate = DateTime.Now;
            oldMedicine.Version++;
            this.Context.SaveChanges();
        }


        public void Delete(int id)
        {
            var oldMedicine = this.Context.Medicines.FirstOrDefault(x => x.Id == id);
            this.Context.Medicines.Remove(oldMedicine);
            this.Context.SaveChanges();
        }

        public List<Medicine> Get(int type)
        {
            switch (type)
            {
                case 0:
                    return this.Context.Medicines.ToList();
                case 1:
                    return this.Context.Medicines.Where(x => x.Type == true).ToList();
                default:
                    return this.Context.Medicines.Where(x => x.Type == false).ToList();
            }
        }


        public List<Medicine> GetAll()
        {
            return this.Context.Medicines.ToList();
        }

        public List<Medicine> GetByName(string name)
        {
            return Context.Medicines.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}
