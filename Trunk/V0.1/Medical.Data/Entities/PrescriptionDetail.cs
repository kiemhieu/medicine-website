using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("PrescriptionDetail")]
    public class PrescriptionDetail
    {
        public long Id { get; set; }
        public long PrescriptionId { get; set; }
        public int? FigureDetailId { get; set; }
        public int MedicineId { get; set; }
        public int Day { get; set; }
        public int VolumnPerDay { get; set; }
        public int Amount { get; set; }
        public int Version { get; set; }
  }
}
