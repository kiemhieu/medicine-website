using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class DefineRepository : RepositoryBase, IDefineRepository
    {
        public List<Define> GetUnit()
        {
            return this.Context.Defines.Where(x => x.GroupId == Definication.Unit).ToList();
        }

        public List<Define> GetContentUnit()
        {
            return this.Context.Defines.Where(x => x.GroupId == Definication.ContentUnit).ToList();
        }

        public List<Define> GetPlanningStatus()
        {
            return this.Context.Defines.Where(x => x.GroupId == Definication.MedicinePlanningStatus).ToList();
        }
    }
}
