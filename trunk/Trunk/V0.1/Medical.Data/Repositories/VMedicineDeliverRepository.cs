using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities.Views;

namespace Medical.Data.Repositories
{
    public class VMedicineDeliverRepository : RepositoryBase, IVMedicineDeliverRepository
    {
        public List<VMedicineDeliverList> Get(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<VMedicineDeliverList> Get(DateTime dateTime, int type)
        {
            switch (type)
            {
                case 0:
                    return
                        this.Context.VMedicineDeliverList.Where(
                            x => x.ClinicId == AppContext.CurrentClinic.Id && x.Date == dateTime).ToList();
                case 1:
                    return
                        this.Context.VMedicineDeliverList.Where(
                            x => x.ClinicId == AppContext.CurrentClinic.Id && x.Date == dateTime && x.DeliverId.HasValue == false).
                            ToList();
                default:
                    return
                        this.Context.VMedicineDeliverList.Where(
                            x => x.ClinicId == AppContext.CurrentClinic.Id && x.Date == dateTime && x.DeliverId.HasValue == true).
                            ToList();
            }
        }
    }
}
