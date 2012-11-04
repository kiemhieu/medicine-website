using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Forms.Entities {
    public class ClinicSetting {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
    }
}
