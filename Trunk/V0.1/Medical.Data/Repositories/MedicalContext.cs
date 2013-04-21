using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;

namespace Medical.Data.Repositories
{
    public class MedicalContext: DbContext
    {
        public DbSet<Clinic> Clinics { get; set; }               
        public DbSet<User> Users { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicinePlan> MedicinePlans { get; set; }
        public DbSet<MedicinePlanDetail> MedicinePlanDetails { get; set; }
        public DbSet<MedicineDelivery> MedicineDeliveries { get; set; }
        public DbSet<MedicineDeliveryDetail> MedicineDeliveryDetails { get; set; }
        public DbSet<BadMedicine> BadMedicines { get; set; }
        public DbSet<Figure> Figures { get; set; }
        public DbSet<FigureDetail> FigureDetails { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<WareHouseDetail> WareHouseDetails { get; set; }
        public DbSet<WareHouseMinimumAllow> WareHouseMinimumAllows { get; set; }
        public DbSet<WareHouseIO> WareHouseIO { get; set; }
        public DbSet<WareHouseIODetail> WareHouseIODetail { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public DbSet<VMedicineDeliverList> VMedicineDeliverList { get; set; }
        public DbSet<WareHouseExportAllocate> WareHouseExportAllocates { get; set; } 
        public DbSet<VMedicineDeliveryDetailList> VMedicineDeliveryDetailList { get; set; }
        public DbSet<VMedicineDeliveryDetailAllocated> VMedicineDeliveryDetailAllocated { get; set; }
        public DbSet<Define> Defines { get; set; }
        public DbSet<MedicineDeliveryDetailAllocate> MedicineDeliveryDetailAllocates { get; set; }
        public DbSet<VWareHouseDetail> VWareHouseDetails { get; set; }
        public DbSet<VPatientLastPrescription> VPatientLastPrescription { get; set; }
        public DbSet<TableChange> TableChanges { get; set; } 
    }
}

