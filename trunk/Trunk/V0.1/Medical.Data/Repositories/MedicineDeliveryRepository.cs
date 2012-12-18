using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class MedicineDeliveryRepository : RepositoryBase, IMedicineDeliveryRepository
    {
        public void Insert(MedicineDelivery user)
        {
            throw new NotImplementedException();
        }

        public void Update(MedicineDelivery user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MedicineDelivery> GetAll()
        {
            throw new NotImplementedException();
        }

        public MedicineDelivery GetByPrescriptionId(int prescriptionId)
        {
            return this.Context.MedicineDeliveries.FirstOrDefault(x => x.PrescriptionId == prescriptionId);
        }
    }
}
