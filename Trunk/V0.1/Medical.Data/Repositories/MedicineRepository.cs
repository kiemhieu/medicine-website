using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class MedicineRepository : RepositoryBase, IMedicineRepository
    {

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Medicine GetById(int id)
        {
            return this.Context.Medicines.FirstOrDefault(x => x.Id.Equals(id));
        }

        /*
        public bool Login(string username, string password, int clinic)
        {
            var user =
                this.Context.Users.FirstOrDefault(
                    x =>
                    x.UserName.Equals(username) && x.Password.Equals(password) && x.Active == true &&
                    x.ClinicId == clinic);
            return user != null;
        }
        */

        /// <summary>
        /// Inserts the specified medicine.
        /// </summary>
        /// <param name="medicine">The medicine.</param>
        public void Insert(Medicine medicine)
        {
            medicine.SetInfo(false);
            this.Context.Medicines.Add(medicine);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified medicine.
        /// </summary>
        /// <param name="medicine">The medicine.</param>
        public void Update(Medicine medicine)
        {
            var origin = this.Context.Medicines.FirstOrDefault(x => x.Id == medicine.Id);
            if (origin == null) return;
            origin.Name = medicine.Name;
            origin.TradeName = medicine.TradeName;
            origin.Unit = medicine.Unit;
            origin.Content = medicine.Content;
            origin.ContentUnit = medicine.ContentUnit;
            origin.SetInfo(true);
            this.Context.SaveChanges();
            this.Context.Entry(origin).Reload();
        }


        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Delete(int id)
        {
            var oldMedicine = this.Context.Medicines.FirstOrDefault(x => x.Id == id);
            this.Context.Medicines.Remove(oldMedicine);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Gets the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
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


        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Medicine> GetAll()
        {
            return this.Context.Medicines.ToList();
        }

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public List<Medicine> GetByName(string name)
        {
            return Context.Medicines.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}
