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
using Medical.Forms.Enums;

namespace Medical.MedicineDeliver
{
    public partial class DeliveryRegister : Form
    {
        private List<MedicineDeliveryAllocationEntity> medDeliveryAllocationList;
        // Repositpry
        private IPrescriptionRepository _prescriptionRepo = new PrescriptionRepository();
        private IPrescriptionDetailRepository _prescriptionDetailRepo = new PrescriptionDetailRepository();
        private IMedicineDeliveryRepository _medicineDeliveryRepo = new MedicineDeliveryRepository();
        private IMedicineDeliveryDetailRepository _medicineDeliveryDetailRepo = new MedicineDeliveryDetailRepository();
        private IMedicineDeliveryDetailAllocateRepository _medicineDeliveryDetailAllocateRepo = new MedicineDeliveryDetailAllocateRepository();
        private IWareHouseDetailRepository _warehouseDetailAllocateRepo = new WareHouseDetailRepository();
        private IWareHouseRepository _warehouseRepo = new WareHouseRepository();
        private IWareHouseDetailRepository _warehouseDetailRepo = new WareHouseDetailRepository();

        // Entity & List
        private Prescription _prescription;
        private List<PrescriptionDetail> _prescriptionDetailList;
        private MedicineDelivery _medicineDelivery;
        private List<MedicineDeliveryDetail> _medicineDeliveryDetailList;
        private List<MedicineDeliveryDetailAllocate> _mdecidineDeliveryDetailAllocate;
        private List<WareHouse> _warehouseList;
        private List<WareHouseDetail> _warehouseDetailList;

        private long _prescriptionId;
        private ViewModes _formMode;

        public DeliveryRegister(long prescriptionId)
        {
            InitializeComponent();
            this._prescriptionId = prescriptionId;
            Initialize();
            this.bindingSource1.DataSource = this.medDeliveryAllocationList;
        }

        private void Initialize()
        {
            medDeliveryAllocationList = new List<MedicineDeliveryAllocationEntity>();

            this._prescription = _prescriptionRepo.Get(this._prescriptionId);
            this._prescriptionDetailList = _prescriptionDetailRepo.GetByPrescription(this._prescriptionId);
            if (_prescription == null || this._prescriptionDetailList == null) throw new Exception("Data dosenot existed");

            this._medicineDelivery = this._medicineDeliveryRepo.GetByPrescriptionId(this._prescriptionId);
            this._formMode = this._medicineDelivery == null ? ViewModes.Add : ViewModes.View;

            if (this._formMode == ViewModes.Add)
            {
                // Createe MachineDelivery
                // Create MachineDeliveryDetail
                // Craete MedicindeDeliveryDetailAllocate
                // Get WareHouseDetail
                // Get WareHouse;
                // this._warehouseDetailList  = this._warehouseDetailRepo
                var medincineIdList = this._prescriptionDetailList.Select(item => item.MedicineId).ToList();
                this._warehouseList = this._warehouseRepo.GetByMedicineId(medincineIdList, AppContext.CurrentClinic.Id);
                this._warehouseDetailList = this._warehouseDetailRepo.GetByMedicine(medincineIdList, AppContext.CurrentClinic.Id);
                this._medicineDelivery = CreatePrescription(this._prescription);
                this._medicineDeliveryDetailList = CreateMedicineDeliveryDetail(this._prescriptionDetailList);
                this._mdecidineDeliveryDetailAllocate = AutoAllocate(this._medicineDeliveryDetailList, this._warehouseDetailList);

                // var item = this._warehouseDetailList.Select(x => new { x.MedicineId, x.LotNo, x.ExpiredDate}).GroupBy(x => new { x.MedicineId, x.LotNo, x.ExpiredDate }).ToList();

                int no = 1;
                foreach (var deliveryItem in this._medicineDeliveryDetailList)
                {
                    var allocatedList = this._mdecidineDeliveryDetailAllocate.Where(x => x.MedicineDeliveryDetailId == deliveryItem.Id).ToList();
                    var warehouse = this._warehouseList.FirstOrDefault(x => x.MedicineId == deliveryItem.MedicineId);
                    var warehouseDetailList = this._warehouseDetailList.Where(x => x.MedicineId == deliveryItem.MedicineId).ToList();
                    var displayItem = new MedicineDeliveryAllocationEntity(allocatedList, deliveryItem, warehouseDetailList, warehouse);
                    displayItem.No = no++;
                    //displayItem.MedicineName = deliveryItem.M
                    medDeliveryAllocationList.Add(displayItem);

                    var itemList = this._warehouseDetailList.Where(x => x.MedicineId == deliveryItem.MedicineId).GroupBy(x => new { x.LotNo, x.ExpiredDate }).ToList();

                    int subNo = 1;
                    foreach (var itm in itemList)
                    {
                        var whDetailList = warehouseDetailList.Where(x => x.LotNo == itm.First().LotNo && x.ExpiredDate == itm.First().ExpiredDate).ToList();
                        var idList = whDetailList.Select(x => x.Id).ToList();
                        var aldList = allocatedList.Where(x => idList.Contains(x.WareHouseDetailId)).ToList();
                        var subItem = new MedicineDeliveryAllocationEntity(aldList, null, whDetailList, warehouse)
                                          {
                                              LotNo = itm.First().LotNo,
                                              ExpiredDate = itm.First().ExpiredDate
                                          };
                        subItem.SubNo = subNo++;
                        medDeliveryAllocationList.Add(subItem);
                    }
                }

            }
        }

        private MedicineDelivery CreatePrescription(Prescription prescription)
        {
            var medicineDelivery = new MedicineDelivery();
            medicineDelivery.ClinicId = AppContext.CurrentClinic.Id;
            medicineDelivery.Date = DateTime.Today;
            medicineDelivery.PatientId = prescription.PatientId;
            medicineDelivery.PrescriptionId = prescription.Id;
            return medicineDelivery;
        }

        private List<MedicineDeliveryDetail> CreateMedicineDeliveryDetail(List<PrescriptionDetail> prescriptionDetails)
        {
            var medicineDeliveryList = new List<MedicineDeliveryDetail>();
            int index = 0;
            foreach (var prescriptionDetail in prescriptionDetails)
            {
                var medicineDeliveryDetail = new MedicineDeliveryDetail
                                                 {
                                                     Id = ++index,
                                                     MedicineId = prescriptionDetail.MedicineId,
                                                     PrescriptionDetailId = prescriptionDetail.Id,
                                                     Unit = prescriptionDetail.Medicine.Unit,
                                                     Volumn = prescriptionDetail.Amount,
                                                     NotAllocatedQty = prescriptionDetail.Amount
                                                 };
                medicineDeliveryList.Add(medicineDeliveryDetail);
            }
            return medicineDeliveryList;
        }

        private List<MedicineDeliveryDetailAllocate> AutoAllocate(List<MedicineDeliveryDetail> medicineDeliveryDetails, List<WareHouseDetail> wareHouseDetails)
        {
            var allocatedItems = new List<MedicineDeliveryDetailAllocate>();
            foreach (var deliveryDetailItem in medicineDeliveryDetails)
            {
                deliveryDetailItem.Allocated = new List<MedicineDeliveryDetailAllocate>();
                var warehouseDetailList =
                    wareHouseDetails.Where(x => x.MedicineId == deliveryDetailItem.MedicineId).
                                        OrderBy(x => x.ExpiredDate).
                                        OrderBy(x => x.Id).ToList();

                foreach (var t in warehouseDetailList)
                {
                    t.DeliveryAllocate = new List<MedicineDeliveryDetailAllocate>();
                    if (deliveryDetailItem.Volumn <= t.CurrentVolumn)
                    {
                        var allocatedItem = new MedicineDeliveryDetailAllocate
                                                {
                                                    MedicineDeliveryDetailId = deliveryDetailItem.Id,
                                                    Unit = deliveryDetailItem.Unit,
                                                    Volumn = deliveryDetailItem.Volumn,
                                                    WareHouseDetailId = t.Id
                                                };
                        deliveryDetailItem.NotAllocatedQty = 0;
                        allocatedItems.Add(allocatedItem);
                        t.CurrentVolumn -= deliveryDetailItem.Volumn;
                        deliveryDetailItem.Allocated.Add(allocatedItem);
                        t.DeliveryAllocate.Add(allocatedItem);
                    }
                    else
                    {
                        var allocatedItem = new MedicineDeliveryDetailAllocate
                                                {
                                                    MedicineDeliveryDetailId = deliveryDetailItem.Id,
                                                    Unit = deliveryDetailItem.Unit,
                                                    Volumn = t.CurrentVolumn,
                                                    WareHouseDetailId = t.Id
                                                };
                        deliveryDetailItem.NotAllocatedQty -= allocatedItem.Volumn;
                        allocatedItems.Add(allocatedItem);
                        t.CurrentVolumn = 0;
                        deliveryDetailItem.Allocated.Add(allocatedItem);
                        t.DeliveryAllocate.Add(allocatedItem);
                    }
                    if (deliveryDetailItem.NotAllocatedQty == 0) break;
                }
            }

            return allocatedItems;
        }

        private void DeliveryRegister_Load(object sender, EventArgs e)
        {
            /*
            List<MedicineDeliveryDetail> deliveryList = new List<MedicineDeliveryDetail>();
            for (int i = 0; i < 10; i++)
            {
                var item = new MedicineDeliveryDetail();
                item.Id = i;
                item.MedicineId = i;
                deliveryList.Add(item);
            }
            this.bindingSource1.DataSource = deliveryList;

            this.advTree1.Nodes[0
             */
        }
    }
}

