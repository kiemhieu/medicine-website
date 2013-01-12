﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHousePaperDetail")]
    public class WareHouseIODetail
    {
        [Key]
        public int Id { get; set; }
        public int WareHouseIOId { get; set; }
        public int MedicineId { get; set; }
        public string LotNo { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Qty { get; set; }
        public int? UnitPrice { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Version { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual WareHouseIO WareHouseIO { get; set; }

        [NotMapped]
        public string MedicineName { get { return this.Medicine.Name; } }

        [NotMapped]
        public string UnitName { get { return this.Medicine.Define.Name; } }
        //public string WareHousePaperNo { get { return this.WareHousePaper.No; } }
    }
}