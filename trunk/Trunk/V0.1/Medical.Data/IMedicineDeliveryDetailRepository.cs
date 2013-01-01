using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicineDeliveryDetailRepository
    {
        void Insert(MedicineDeliveryDetail medicineDeliveryDetail);
        void Update(MedicineDeliveryDetail user);
        void Delete(int id);
        List<MedicineDeliveryDetail> GetAll();
    }
}
