using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Medical.Common
{
    public class Validation
    {
        public static bool CheckNulOrEmpty(String value)
        {
            return !String.IsNullOrEmpty(value);
        }

        public static bool CheckAlphaNumeric(String value)
        {
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            return (r.IsMatch(value));
        }

        public static bool CheckAlpha(String value)
        {
            Regex r = new Regex("^[a-zA-Z]*$");
            return (r.IsMatch(value));
        }

        public static bool CheckPhoneNumber(String value)
        {
            Regex r = new Regex(@"^(\d{3,4})[ -]?(\d{3})[ -]?(\d{4}) x(\d*)");
            return (r.IsMatch(value));
        }
    }
}
