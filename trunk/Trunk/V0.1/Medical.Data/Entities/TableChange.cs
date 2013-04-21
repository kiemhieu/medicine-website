using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("TableChange")]
    public class TableChange
    {
        public long No { get; set; }
        public int Id { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ClinicId { get; set; }
    }
}
