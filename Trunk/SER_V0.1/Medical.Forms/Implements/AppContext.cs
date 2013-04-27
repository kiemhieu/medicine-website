using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Forms.Entities;

namespace Medical.Forms.Implements {
    public class AppContext {
        public static ClinicSetting CurrentClinic { get; set; }
        public static User LoggedInUser { get; set; }
        public static bool Authenticated { get; set; }
    }
}
