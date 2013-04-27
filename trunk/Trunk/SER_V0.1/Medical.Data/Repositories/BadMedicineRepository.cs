using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;


namespace Medical.Data.Repositories {
    public class BadMedicineRepository : RepositoryBase, IBadMedicineRepository
    {

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public BadMedicine Get(int id) {
            return Context.BadMedicines.FirstOrDefault(x => x.Id.Equals(id));
        }

        public BadMedicine GetById(int id) {
            return this.Context.BadMedicines.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Insert(BadMedicine entity) {
          
            entity.Version = 0;
            this.Context.BadMedicines.Add(entity);
            this.Context.SaveChanges();
        }

        public void Update(BadMedicine entity)
        {
            try {
                var oldEntity = this.Context.BadMedicines.FirstOrDefault(x => x.Id == entity.Id);
                if (oldEntity == null) return;

                oldEntity.ClinicId = entity.ClinicId;
                oldEntity.MedicineId = entity.MedicineId;
                oldEntity.LotNo = entity.LotNo;
                oldEntity.ExpiredDate = entity.ExpiredDate;
                oldEntity.Qty = entity.Qty;
                oldEntity.Version++;
                this.Context.SaveChanges();
            } catch (Exception ex) {

                throw;
            }

        }


        public void Delete(int id) {
            try {
                var oldEntity = this.Context.BadMedicines.FirstOrDefault(x => x.Id == id);
                this.Context.BadMedicines.Remove(oldEntity);
                this.Context.SaveChanges();
            } catch (Exception) {

                throw;
            }

        }

        public List<BadMedicine> GetAll() {
            return this.Context.BadMedicines.ToList();
        }
    }
}
