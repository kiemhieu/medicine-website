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
        public DbSet<MedicineDelivery> MedicineDeliveries { get; set; }
        public DbSet<Figure> Figures { get; set; }
        public DbSet<FigureDetail> FigureDetails { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<WareHouseDetail> WareHouseDetails { get; set; }
        public DbSet<WareHouseMinimumAllow> WareHouseMinimumAllows { get; set; }
        public DbSet<WareHousePaper> WareHousePapers { get; set; }
        public DbSet<WareHousePaperDetail> WareHousePaperDetails { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public DbSet<VMedicineDeliverList> VMedicineDeliverList { get; set; }
    }
}

