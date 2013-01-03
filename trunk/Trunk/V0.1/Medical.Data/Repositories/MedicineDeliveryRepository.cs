using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Medical.Data.Entities;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace Medical.Data.Repositories
{
    public class MedicineDeliveryRepository : RepositoryBase, IMedicineDeliveryRepository
    {
        public void Insert(MedicineDelivery medicineDelivery, List<MedicineDeliveryDetail> medicineDeliveryDetails) {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted })) {

                // Insert DeliveryDetail
                // Get WareHouseDetail
                // Allocate Qty
                // Insert Allocate
                // Update WareHouseDetail
                // Update WareHouse
                medicineDelivery.SetInfo(false);
                this.Context.MedicineDeliveries.Add(medicineDelivery);
                this.Context.SaveChanges();

                // Get WareHouse Detail by MedicineID to allocated
                var medicineId = new List<int>();
                foreach (var detailItem in medicineDeliveryDetails) {
                    detailItem.MedicineDeliveryId = medicineDelivery.Id;
                    detailItem.SetInfo(false);
                    detailItem.Medicine = null;
                    this.Context.MedicineDeliveryDetails.Add(detailItem);
                    if (!medicineId.Contains(detailItem.MedicineId)) medicineId.Add(detailItem.MedicineId);
                }
                this.Context.SaveChanges();

                // Get WareHouse
                var warehouseList = this.Context.WareHouses.Where(x => medicineId.Contains(x.MedicineId) && x.ClinicId == AppContext.CurrentClinic.Id);
                var warehouseIdList = warehouseList.Select(x => x.Id).ToList();


                // Get WareHouseDetail
                var wareHouseDetails =
                    this.Context.WareHouseDetails.Where(x => medicineId.Contains(x.MedicineId) && x.CurrentVolumn > 0 && warehouseIdList.Contains(x.WareHouseId)).
                        ToList();

                // Allocated
                var allocateList = new List<MedicineDeliveryDetailAllocate>();
                foreach (var detailItem in medicineDeliveryDetails) {
                    // Update WareHouse
                    var warehouseItem = warehouseList.FirstOrDefault(x => x.MedicineId == detailItem.MedicineId);
                    if (warehouseItem == null) throw new Exception("Data is incompleted");
                    warehouseItem.Volumn -= detailItem.AllocatedQty;

                    // Update WareHouseAllocated
                    var allocatedWareHouseDetail = detailItem.AllocatedWareHouseDetail;
                    foreach (var wareHouseDetailItem in allocatedWareHouseDetail) {
                        int qty = wareHouseDetailItem.AllocatedQty;
                        List<WareHouseDetail> wareHouseDetailAllocatedList =
                            wareHouseDetails.Where(
                                x =>
                                x.MedicineId == wareHouseDetailItem.MedicineId &&
                                x.ExpiredDate == wareHouseDetailItem.ExpiredDate &&
                                (x.LotNo == wareHouseDetailItem.LotNo ||
                                 (String.IsNullOrEmpty(x.LotNo) && String.IsNullOrEmpty(wareHouseDetailItem.LotNo)))).ToList();

                        foreach (var allocatedItem in wareHouseDetailAllocatedList) {
                            var allocated = new MedicineDeliveryDetailAllocate {
                                MedicineDeliveryDetailId = detailItem.Id,
                                WareHouseDetailId = allocatedItem.Id,
                                Unit = allocatedItem.Unit
                            };

                            if (wareHouseDetailItem.AllocatedQty <= allocatedItem.CurrentVolumn) {
                                allocated.Volumn = qty;
                                allocatedItem.CurrentVolumn -= qty;
                                qty = 0;
                            } else {
                                allocated.Volumn = allocatedItem.CurrentVolumn;
                                qty -= allocatedItem.CurrentVolumn;
                                allocatedItem.CurrentVolumn = 0;
                            }
                            allocateList.Add(allocated);
                            if (qty == 0) break;
                        }

                        if (qty != 0) { throw new DataException("Cannot allocated because of data changed, please update data before saved.");}
                    }
                }

                foreach (var allocatedItem in allocateList)
                {
                    allocatedItem.SetInfo(false);
                    this.Context.MedicineDeliveryDetailAllocates.Add(allocatedItem);
                }

                this.Context.SaveChanges();
                scope.Complete();
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
