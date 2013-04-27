using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;

namespace Medical.Data
{
    public interface IMedicineDeliveryDetailRepository
    {
        List<MedicineDeliveryDetail> GetByDelivery(long deliveryId);

        List<VMedicineDeliveryDetailAllocated> GetDeliveryDetailAllocateds(List<long> deliveryDetailIdList);
    }
}
