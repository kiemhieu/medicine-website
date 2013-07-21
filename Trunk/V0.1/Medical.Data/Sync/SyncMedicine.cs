using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Repositories;

namespace Medical.Data.Sync
{
    public class SyncMedicine
    {
        public void Sync()
        {
            IMedicineRepository clientRepo = new MedicineRepository();
            IMedicineRepository serverRepo = new MedicineRepository(true);

        }
    }
}
