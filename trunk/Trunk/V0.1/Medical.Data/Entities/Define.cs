using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("Define")]
    public class Define
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
  }
}
