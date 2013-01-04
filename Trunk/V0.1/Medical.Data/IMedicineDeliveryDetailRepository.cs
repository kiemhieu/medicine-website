using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicineDeliveryDetailRepository
    {
        List<MedicineDeliveryDetail> GetByDelivery(long deliveryId);
    }
}
