using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.EntitiyExtend
{
    public class MedicineDeliveryAllocationEntity
    {
        private MedicineDeliveryDetail deliveryDetail;
        private List<MedicineDeliveryDetailAllocate> allocatedList;
        private WareHouse _warehouse;
        private List<WareHouseDetail> _wareHouseDetails;

        public MedicineDeliveryAllocationEntity(List<MedicineDeliveryDetailAllocate> allocatedList, MedicineDeliveryDetail deliveryDetail, List<WareHouseDetail> wareHouseDetails, WareHouse warehouse)
        {
            this.allocatedList = allocatedList;
            this._warehouse = warehouse;
            this._wareHouseDetails = wareHouseDetails;
            this.deliveryDetail = deliveryDetail;
        }

        public long? Id
        {
            get { return this.deliveryDetail == null ? (long?)null : this.deliveryDetail.Id; }
        }

        public int? No { set; get; }
        public int? SubNo { set; get; }
        public String MedicineName { get; set; }
        public int? MedicineId { get; set; }
        public String LotNo { get; set; }
        public DateTime ExpiredDate { get; set; }

        public int? Qty {
            get { return this.deliveryDetail == null ? (int?)null : this.deliveryDetail.Volumn; }
        }

        public int InStockQty 
        { 
            get { return this._wareHouseDetails.Sum(x => x.CurrentVolumn); }
        }

        public int AllocatedQty 
        { 
            get
            {
                return this.allocatedList == null ? 0 : this.allocatedList.Sum(x => x.Volumn);
            }
        }
    }
}
