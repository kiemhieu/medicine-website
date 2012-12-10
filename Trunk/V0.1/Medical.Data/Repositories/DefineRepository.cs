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
    }
}
