using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;

namespace Medical.Data.EntitiyExtend
{
    public class MedicineDeliveryAllocationEntity
    {
        private WareHouse _warehouse;

        // private List<MedicineDeliveryDetailAllocate> allocatedList;
        // private List<WareHouseDetail> _wareHouseDetails;
        public MedicineDeliveryAllocationEntity(int no, MedicineDeliveryDetail deliveryDetail, WareHouse warehouse) {
            this._warehouse = warehouse;
            this.MedicineDeliveryDetail = deliveryDetail;
            this.No = no;
        }

        public MedicineDeliveryAllocationEntity(int subNo, VWareHouseDetail vWareHouseDetail) {
            this.VWareHouseDetail = vWareHouseDetail;
            this.SubNo = subNo;
        }

        public long? DeliverDetailId
        {
            get { return this.MedicineDeliveryDetail == null ? (long?) null : this.MedicineDeliveryDetail.Id; }
        }

        public int? No { set; get; }

        public int? SubNo { set; get; }

        public String MedicineName { get
        {
            return (this.MedicineDeliveryDetail == null || this.MedicineDeliveryDetail.Medicine == null)
                       ? String.Empty
                       : this.MedicineDeliveryDetail.Medicine.Name;
        }}

        public String LotNo { get { return this.VWareHouseDetail == null ? null : this.VWareHouseDetail.LotNo; } }

        public DateTime? ExpiredDate { get { return this.VWareHouseDetail == null ? (DateTime?) null : this.VWareHouseDetail.ExpiredDate; } }

        public int? Qty {
            get { return this.MedicineDeliveryDetail == null ? (int?)null : this.MedicineDeliveryDetail.Volumn; }
        }

        public int? RemainQty {
            get { return this.InStockQty - this.AllocatedQty; }
        }

        public int InStockQty {
            get {
                if (this._warehouse != null) return this._warehouse.Volumn;
                return this.VWareHouseDetail != null ? this.VWareHouseDetail.Qty : 0;
            }
        }

        public int AllocatedQty 
        { 
            get
            {
                if (this.MedicineDeliveryDetail != null) return this.MedicineDeliveryDetail.AllocatedWareHouseDetail.Sum(x=>x.AllocatedQty);
                return this.VWareHouseDetail != null ? this.VWareHouseDetail.AllocatedQty : 0;
            }
        }

        public MedicineDeliveryDetail MedicineDeliveryDetail { get; private set; }

        public VWareHouseDetail VWareHouseDetail { get; private set; }

        public String UnitName
        {
            get
            {
                return this.MedicineDeliveryDetail != null ? this.MedicineDeliveryDetail.Medicine.Define.Name : null;
            }
        }
    }
}
