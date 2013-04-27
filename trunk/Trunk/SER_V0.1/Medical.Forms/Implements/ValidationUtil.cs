using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Medical.Forms.Implements {
    public class ValidationUtil {

        public static bool IsAlphanumeric(string value) {
            var pattern = new Regex("[^0-9a-zA-Z]");
            return !pattern.IsMatch(value);
        }

        public static bool isPhoneNumber(string value)
        {
             var pattern = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
            return !pattern.IsMatch(value);
            
        }

    }
}
