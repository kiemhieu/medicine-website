using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicineDeliveryRepository
    {
        void Insert(MedicineDelivery medicineDelivery, List<MedicineDeliveryDetail> medicineDeliveryDetails);
        void Update(MedicineDelivery user);
        void Delete(long id);
        List<MedicineDelivery> GetAll();
        MedicineDelivery GetByPrescriptionId(long prescriptionId);
    }
}
