using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("Patient")]
    public class Patient
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? BirthYear { get; set; }
        public char? Sexual { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CrearedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int? LastUpdatedUser { get; set; }
        public int Version { get; set; }
    }
}
