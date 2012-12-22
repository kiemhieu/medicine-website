using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicinePlanDetailRepository
    {
        void Delete(int id);
        Medical.Data.Entities.MedicinePlanDetail Get(int id);
        System.Collections.Generic.List<Medical.Data.Entities.MedicinePlanDetail> GetAll();
        Medical.Data.Entities.MedicinePlanDetail GetById(int id);
        void Insert(Medical.Data.Entities.MedicinePlanDetail MedicinePlanDetail);
        void Update(Medical.Data.Entities.MedicinePlanDetail medicinePlanDetail);
    }
}
