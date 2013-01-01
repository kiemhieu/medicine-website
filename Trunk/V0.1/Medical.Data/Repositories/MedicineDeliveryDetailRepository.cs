using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class MedicineDeliveryDetailRepository : RepositoryBase, IMedicineDeliveryDetailRepository
    {
        public void Insert(MedicineDeliveryDetail medicineDeliveryDetail)
        {
            // Insert DeliveryDetail
            // Get WareHouseDetail
            // Allocate Qty
            // Insert Allocate
            // Update WareHouseDetail
            // Update WareHouse
            var warehouseDetailAllocatedList = medicineDeliveryDetail.AllocatedWareHouseDetail;




        }

        public void Update(MedicineDeliveryDetail user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MedicineDeliveryDetail> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
