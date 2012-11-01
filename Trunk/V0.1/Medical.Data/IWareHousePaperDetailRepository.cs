using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IWareHousePaperDetailRepository
    {
        void Insert(WareHousePaperDetail user);
        void Update(WareHousePaperDetail user);
        void Delete(int id);
        List<WareHousePaperDetail> GetAll();
    }
}
