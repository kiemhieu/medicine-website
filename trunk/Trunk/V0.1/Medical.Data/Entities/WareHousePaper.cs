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
        public long Id { get; set; }
        public int ClinicId { get; set; }
        public decimal Type { get; set; }
        public DateTime Date { get; set; }
        public string No { get; set; }
        public string Recipient { get; set; }
        public string Deliverer { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CrearedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; }
        public int Version { get; set; }
    }
}
