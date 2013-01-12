using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IWareHousePaperRepository
    {
        void Insert(WareHouseIO user);
        void Update(WareHouseIO user);
        void Delete(int id);
        List<WareHouseIO> GetAll();
    }
}
