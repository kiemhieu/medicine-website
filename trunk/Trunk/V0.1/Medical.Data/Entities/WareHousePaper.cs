using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHousePaper")]
    public class WareHousePaper
    {
        [Key]
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
        public string No { get; set; }
        public string Recipient { get; set; }
        public string Deliverer { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; }
        public int Version { get; set; }
        public ICollection<WareHousePaperDetail> WareHousePaperDetails { get; set; }
        //private Medicine Medicine { get; set; }
        //private Clinic Clinic { get; set; }
        //public string MedicineName { get { return this.Medicine.Name; } }
        //public string ClinicName { get { return this.Clinic.Name; } }
        [NotMapped]
        public string TypeName
        {
            get
            {
                if (this.Type == 0)
                    return "Xuất kho";
                else
                    return "Nhập kho";
            }
        }
    }
}
