using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities.Views {

    [Table("VPatientLastPrescription")]
    public class VPatientLastPrescription {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public int ClinicId { get; set; }
        public DateTime LatestRecheckDate { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public int BirthYear { get; set; }
        public String Phone { get; set; }
        public String Sexual { get; set; }
        public String Address { get; set; }
        public DateTime StartDate { get; set; }
        public String Description { get; set; }
        public DateTime CheckDate { get; set; }
    }
}
