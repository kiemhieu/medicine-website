using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("FigureDetail")]
    public class FigureDetail
    {
        public int Id { get; set; }
        public int? FigureId { get; set; }
        public int? MedicineId { get; set; }
        public int? Volumn { get; set; }
        public bool Enable { get; set; }
        public int Version { get; set; }
  }
}
