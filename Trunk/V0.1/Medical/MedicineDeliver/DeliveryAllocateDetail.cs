using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;

namespace Medical.MedicineDeliver
{
    public partial class DeliveryAllocateDetail : Form
    {
        private IWareHouseRepository _warehouseRepo = new WareHouseRepository();
        private IWareHouseDetailRepository _warehouseDetailRepo = new WareHouseDetailRepository();

        private MedicineDeliveryDetail _medicineDeliverDetail;
        private WareHouse _warehouse;
        private List<WareHouseDetail> _warehouseDetail;
        private List<MedicineDeliveryDetailAllocate> _allocateDetails;

        public DeliveryAllocateDetail(MedicineDeliveryDetail medicineDeliverDetail, List<MedicineDeliveryDetailAllocate> allocateDetails)
        {
            InitializeComponent();
            this._medicineDeliverDetail = medicineDeliverDetail;
            this._allocateDetails = allocateDetails;
        }

        private void Initialize()
        {
            this._warehouse = this._warehouseRepo.GetByIdMedicine(this._medicineDeliverDetail.MedicineId, AppContext.CurrentClinic.Id);
            this._warehouseDetail =
                this._warehouseDetailRepo.GetByMedicine(
                    new List<int>(new int[] {this._medicineDeliverDetail.MedicineId}), AppContext.CurrentClinic.Id);
            /*
            foreach (var dele arehouseDetail)
            {
                
            }
             */

        }
    }
}
