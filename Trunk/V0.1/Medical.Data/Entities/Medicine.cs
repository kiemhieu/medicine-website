using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("Medicine")]
    public class Medicine : EntityBase
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
        public String ContentString
        {
            get { return string.Format("{0}{1}", this.Content, this.ContentUnitDefile == null ? "" : "(" + this.ContentUnitDefile.Name + ")"); }
        }

        [ForeignKey("ContentUnit")]
        public virtual Define ContentUnitDefile { get; set; }
        
        [NotMapped]
        public String TypeMedicine
        {
            get { return this.Type ? "ARV" : "NTCH"; }
        }

        [NotMapped]
        public int No { get; set; }        
  }
}
