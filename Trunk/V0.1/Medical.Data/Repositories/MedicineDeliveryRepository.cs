using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class MedicineDeliveryRepository : RepositoryBase, IMedicineDeliveryRepository
    {
        public void Insert(MedicineDelivery medicineDelivery, List<MedicineDeliveryDetail> medicineDeliveryDetails)
        {
            // Insert DeliveryDetail
            // Get WareHouseDetail
            // Allocate Qty
            // Insert Allocate
            // Update WareHouseDetail
            // Update WareHouse
            medicineDelivery.SetInfo(false);
            this.Context.MedicineDeliveries.Add(medicineDelivery);
            this.Context.SaveChanges();

            var medicineId = new List<int>();
            foreach (var detailItem in medicineDeliveryDetails)
            {
                detailItem.MedicineDeliveryId = medicineDelivery.Id;
                if (!medicineId.Contains(detailItem.MedicineId)) medicineId.Add(detailItem.MedicineId);
            }

            var wareHouseDetails =
                this.Context.WareHouseDetails.Where(x => medicineId.Contains(x.MedicineId) && x.CurrentVolumn > 0).
                    ToList();

            List<MedicineDeliveryDetailAllocate> allocateList= new List<MedicineDeliveryDetailAllocate>();
            foreach (var detailItem in medicineDeliveryDetails)
            {
                var allocatedWareHouseDetail = detailItem.AllocatedWareHouseDetail;
                foreach (var wareHouseDetailItem in allocatedWareHouseDetail)
                {
                    int qty = wareHouseDetailItem.AllocatedQty;
                    List<WareHouseDetail> wareHouseDetailAllocatedList =
                        wareHouseDetails.Where(
                            x =>
                            x.MedicineId == wareHouseDetailItem.MedicineId &&
                            x.ExpiredDate == wareHouseDetailItem.ExpiredDate &&
                            (x.LotNo == wareHouseDetailItem.LotNo ||
                             (String.IsNullOrEmpty(x.LotNo) && String.IsNullOrEmpty(wareHouseDetailItem.LotNo)))).ToList();
                    
                    foreach (var allocatedItem in wareHouseDetailAllocatedList)
                    {
                        MedicineDeliveryDetailAllocate allocated = new MedicineDeliveryDetailAllocate();
                        
                        allocated.MedicineDeliveryDetailId = detailItem.Id;
                        allocated.WareHouseDetailId = allocatedItem.Id;
                        allocated.Unit = allocatedItem.Unit;
                        if (wareHouseDetailItem.AllocatedQty <= allocatedItem.CurrentVolumn)
                        {
                            allocated.Volumn = qty;
                            allocatedItem.CurrentVolumn -= qty;
                            qty = 0;
                        }
                        else
                        {
                            allocated.Volumn = allocatedItem.CurrentVolumn;
                            qty -= allocatedItem.CurrentVolumn;
                            allocatedItem.CurrentVolumn = 0;
                        }
                    }
                    

                }
            }

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

        public MedicineDelivery GetByPrescriptionId(long prescriptionId)
        {
            return this.Context.MedicineDeliveries.FirstOrDefault(x => x.PrescriptionId == prescriptionId);
        }
    }
}
