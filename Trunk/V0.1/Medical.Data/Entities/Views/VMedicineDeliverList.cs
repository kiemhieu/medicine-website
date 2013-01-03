using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities.Views
{
    [Table("VMedicineDeliverList")]
    public class VMedicineDeliverList
    {
        public long Id { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public DateTime RecheckDate { get; set; }
        public long? DeliverId { get; set; }
        public String DoctorName { get; set; }
        public DateTime? DeliverDate { get; set; }
        public DateTime? DeliverTime { get; set; }
        public DateTime? CheckTime { get; set; }
        public String PatientName { get; set; }
        public String Code { get; set; }
        public int? BirthYear { get; set; }
        public String Address { get; set; }
        public String Sexual { get; set; }

        [NotMapped]
        public Boolean IsDelivered
        {
            get { return this.DeliverId.HasValue; }
        }

        [NotMapped]
        public int No { get; set; }

        [NotMapped]
        public String Sex
        {
            get
            {
                if (string.IsNullOrEmpty(this.Sexual)) return null;
                switch (this.Sexual)
                {
                    case "F":
                        return "Nữ";
                    case "M":
                        return "Nam";
                }
                return null;
            }
        }
    }
}
