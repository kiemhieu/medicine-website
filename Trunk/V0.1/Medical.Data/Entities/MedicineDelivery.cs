using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("MedicineDelivery")]
    public class MedicineDelivery
    {
        public long Id { get; set; }
        public int ClinicId { get; set; }
        public int PatienId { get; set; }
        public long? PrescriptionId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdateBy { get; set; }
        public int Version { get; set; }
  }
}
