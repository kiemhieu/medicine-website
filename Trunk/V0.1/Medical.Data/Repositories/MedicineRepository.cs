using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class MedicineRepository : RepositoryBase, IMedicineRepository
    {
        
          public MedicineRepository() : base()
        {
        }

          public MedicineRepository(bool serverContext)
              : base(serverContext)
        {
            
        }
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

        public List<string> GetMedicinesName()
        {
            return this.Context.Medicines.Select(x => x.Name).ToList();
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
            try
            {
                var s = Context.Medicines.Where(x => x.Name.Contains(name)).ToList();
                return s;
            }
            catch
            { 
                
            }
            return null;
        }

        public Medicine CopyEntity(Medicine entCopy, Medicine entReturn)
        {
            entReturn.Content = entCopy.Content;
            entReturn.ContentUnit = entCopy.ContentUnit;
            entReturn.CreatedBy = entCopy.CreatedBy;
            entReturn.CreatedDate = entCopy.CreatedDate;
            entReturn.Description = entCopy.Description;
            entReturn.LastUpdatedBy = entCopy.LastUpdatedBy;
            entReturn.LastUpdatedDate = entCopy.LastUpdatedDate;
            entReturn.Name = entCopy.Name;
            entReturn.TradeName = entCopy.TradeName;
            entReturn.Type = entCopy.Type;
            entReturn.Unit = entCopy.Unit;
            entReturn.Version = entCopy.Version;
            return entReturn;
        }

        public List<Medicine> GetWithInventoryVolume(int clinicId)
        {
            List<WareHouse> lstWH = this.Context.WareHouses.Where(x => x.ClinicId == clinicId).ToList();


            List<Medicine> lstMedicine = GetAll();
            foreach (Medicine medEnt in lstMedicine)
            {
                medEnt.InventoryVolumn = 0;
                foreach(WareHouse whEnt in lstWH)
                {
                    if (whEnt.MedicineId == medEnt.Id)
                    {
                        medEnt.InventoryVolumn = whEnt.Volumn ;
                    }
                }
            }
            return lstMedicine;
        }

        public int GetInventoryVolumeWareHouseByMedicineId(int clinicId,int medicineId)
        {
            int inventoryVolume = 0;
            WareHouse whEnt = this.Context.WareHouses.FirstOrDefault(x => x.ClinicId == clinicId && x.MedicineId == medicineId);
            if (whEnt != null) inventoryVolume = whEnt.Volumn;
            return inventoryVolume;
        }

        public void Sync()
        {
            
        }
    }
}
