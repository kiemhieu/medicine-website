using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("MedicineDelivery")]
    public class MedicineDelivery : EntityBase
    {
        public long Id { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public long? PrescriptionId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; }
        public int Version { get; set; }
  }
}
