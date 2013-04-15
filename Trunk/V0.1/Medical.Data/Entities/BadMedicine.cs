using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Medical.Data.Entities.Views;

namespace Medical.Data.Entities
{
    [Table("BadMedicine")]
    public class BadMedicine : EntityBase
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int MedicineId { get; set; }
        public string LotNo { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int Qty { get; set; }
        public int Version { get; set; }

        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }
  }
}
