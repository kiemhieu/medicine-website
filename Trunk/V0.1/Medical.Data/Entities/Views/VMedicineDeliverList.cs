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
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int Date { get; set; }
        public int RecheckDate { get; set; }
        public int? DeliverId { get; set; }
        public String DoctorName { get; set; }
        public DateTime? DeliverDate { get; set; }
        public DateTime? DeliverTime { get; set; }
        public DateTime? CheckTime { get; set; }
    }
}
