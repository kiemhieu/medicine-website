﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHouseDetail")]
    public class WareHouseDetail
    {
        public long Id { get; set; }
        public int ClinicId { get; set; }
        public int MedicineId { get; set; }
        public string LotNo { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public int? Volumn { get; set; }
        public int BadVolumn { get; set; }
        public int UnitPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; } 
        public int Version { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual Clinic Clinic { get; set; }
        [NotMapped]
        public string MedicineName { get { return this.Medicine.Name; } }
        [NotMapped]
        public string ClinicName { get { return this.Clinic.Name; } }
    }
}