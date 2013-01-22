using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Data
{
    public class Definication
    {
        public const int ContentUnit = 1;
        public const int Unit = 2;
        public const int MedicinePlanningStatus = 3;
        
    }

    public class MedicinePlaningStatus
    {
        public const int Draft = 1;
        public const int Approving = 2;
        public const int Approved = 3;
        public const int RequireChang = 4;
    }
}
