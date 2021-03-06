﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities {
    [Table("Prescription")]
    public class Prescription : EntityBase {

        public long Id { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public int FigureId { get; set; }
        public String Note { get; set; }
        public DateTime RecheckDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; }
        public int Version { get; set; }

        public virtual List<PrescriptionDetail> PrescriptionDetails { get; set; }
        public virtual Figure Figure { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }


        [ForeignKey("DoctorId")]
        public virtual User Doctor { get; set; }

        [NotMapped]
        public String FigureName
        {
            get { return this.Figure == null ? "" : this.Figure.Name; }
        }

        [NotMapped]
        public String DoctorName
        {
            get { return this.Doctor == null ? "" : this.Doctor.Name; }
        }

        [NotMapped]
        public String PatientName {
            get { return this.Patient == null ? "" : this.Patient.Name; }
        }

        [NotMapped]
        public int No { get; set; }
    }
}
