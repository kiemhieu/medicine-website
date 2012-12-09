using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("Medicine")]
    public class Medicine
    {
        public int Id { get; set; }
        //public string MedicineCode { get; set; }
        public string Name { get; set; }
        public int? Content { get; set; }
        public int? ContentUnit { get; set; }
        public int Unit { get; set; }
        public string TradeName { get; set; }
        public string Description { get; set; }
        public bool Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public int Version { get; set; }

        
        [NotMapped]
        public String TypeMedicine
        {
            get { return this.Type ? "ARV" : "Nhiễm trùng cơ hội"; }
        }

        [NotMapped]
        public int No { get; set; }
  }
}
