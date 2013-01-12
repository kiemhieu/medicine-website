using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHouseIO")]
    public class WareHouseIO
    {
        [Key]
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public String Type { get; set; }
        public DateTime Date { get; set; }
        public String No { get; set; }
        public String Person { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String Note { get; set; }
        public String AttachmentNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public int Version { get; set; }
        public ICollection<WareHouseIODetail> WareHousePaperDetails { get; set; }
        //private Medicine Medicine { get; set; }
        //private Clinic Clinic { get; set; }
        //public string MedicineName { get { return this.Medicine.Name; } }
        //public string ClinicName { get { return this.Clinic.Name; } }
        [NotMapped]
        public string TypeName
        {
            get
            {
                if (this.Type == "I")
                    return "Nhập kho";
                else
                    return "Xuất kho";
            }
        }
    }
}
