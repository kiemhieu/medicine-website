using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IWareHousePaperRepository
    {
        void Insert(WareHousePaper user);
        void Update(WareHousePaper user);
        void Delete(int id);
        List<WareHousePaper> GetAll();
    }
}
