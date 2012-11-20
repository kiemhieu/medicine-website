using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories {
    public class MedicineRepository : RepositoryBase, IMedicineRepository
    {

       public Medicine GetById(int id)
        {
            var medicine = this.Context.Medicines.FirstOrDefault(x => x.Id.Equals(id));
            return medicine;
        }

        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="clinic">The clinic.</param>
        /// <returns></returns>
        public bool Login(string username, string password, int clinic) {
            var user =
                this.Context.Users.FirstOrDefault(
                    x =>
                    x.UserName.Equals(username) && x.Password.Equals(password) && x.Active == true &&
                    x.ClinicId == clinic);
            return user != null;
        }

        public void Insert(Medicine medicine)
        {
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

    
        public void Delete(int id) {
            var oldMedicine = this.Context.Medicines.FirstOrDefault(x => x.Id == id);
            this.Context.Medicines.Remove(oldMedicine);
            this.Context.SaveChanges();
        }

        List<Medicine> IMedicineRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Medicine> GetAll() {
            return this.Context.Medicines.ToList();
        }
        public List<Medicine> GetByName(string name)
        {
            return Context.Medicines.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}
