using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHouse")]
    public class WareHouse
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int MedicineId { get; set; }
        public int Volumn { get; set; }
        public int? MinAllowed { get; set; }
        public int? Version { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int? LastUpdatedUser { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual ICollection<WareHouseDetail> WareHouseDetails { get; set; }
        [NotMapped]
        public string MedicineName { get { return this.Medicine.Name; } }
        [NotMapped]
        public string ClinicName { get { return this.Clinic.Name; } }
    }
}
