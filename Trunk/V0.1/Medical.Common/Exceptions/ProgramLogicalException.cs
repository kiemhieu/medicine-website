using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Common.Exceptions {
    public class ProgramLogicalException : Exception{
        public ProgramLogicalException(String message) : base(message)
        {
            
        }
    }
}
