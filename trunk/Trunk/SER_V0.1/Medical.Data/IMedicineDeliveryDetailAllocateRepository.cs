using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicineDeliveryDetailAllocateRepository
    {
        List<MedicineDeliveryDetailAllocate> GetList(List<int> deliveryDetailId);

    }
}
