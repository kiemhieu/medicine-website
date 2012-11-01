using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicineDeliveryRepository
    {
        void Insert(MedicineDelivery user);
        void Update(MedicineDelivery user);
        void Delete(int id);
        List<MedicineDelivery> GetAll();
    }
}
