using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

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
    }
}

