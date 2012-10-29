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
    }
}
