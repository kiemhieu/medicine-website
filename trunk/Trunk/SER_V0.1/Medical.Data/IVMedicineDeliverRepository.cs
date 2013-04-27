using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities.Views;

namespace Medical.Data
{
    public interface IVMedicineDeliverRepository
    {
        List<VMedicineDeliverList> Get(DateTime dateTime);
        List<VMedicineDeliverList> Get(DateTime dateTime, int type);
    }
}
