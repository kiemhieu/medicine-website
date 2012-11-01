using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IWareHouseMinimumAllowRepository
    {
        void Insert(WareHouseMinimumAllow user);
        void Update(WareHouseMinimumAllow user);
        void Delete(int id);
        List<WareHouseMinimumAllow> GetAll();
    }
}
