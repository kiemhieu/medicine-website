using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHousePaperDetail")]
    public class WareHousePaperDetail
    {
        [Key]
        public int Id { get; set; }
        public int WareHousePaperId { get; set; }
        public int Type { get; set; }
        public int MedicineId { get; set; }
        public string LotNo { get; set; }
        public int Volumn { get; set; }        
        public int Unit { get; set; }
        public int? UnitPrice { get; set; }
        public int Amount { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Version { get; set; }        
        public virtual Medicine Medicine { get; set; }      
        public virtual WareHousePaper WareHousePaper { get; set; }
        //public string MedicineName { get { return this.Medicine.Name; } }
        //public string WareHousePaperNo { get { return this.WareHousePaper.No; } }
  }
}
