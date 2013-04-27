using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;

namespace Medical.Data.Repositories
{
    public class MedicineDeliveryDetailRepository : RepositoryBase, IMedicineDeliveryDetailRepository
    {
        public List<MedicineDeliveryDetail> GetByDelivery(long deliveryId)
        {
            return this.Context.MedicineDeliveryDetails.Where(x => x.MedicineDeliveryId == deliveryId).ToList();
        }

        public List<VMedicineDeliveryDetailAllocated> GetDeliveryDetailAllocateds(List<long> deliveryDetailIdList)
        {
            return this.Context.VMedicineDeliveryDetailAllocated.Where(x => deliveryDetailIdList.Contains(x.MedicineDeliveryDetailId)).ToList();
        }
    }
}
