using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicinePlanRepository
    {
        void Delete(int id);
        Medical.Data.Entities.MedicinePlan Get(int id);
        System.Collections.Generic.List<Medical.Data.Entities.MedicinePlan> GetAll();
        Medical.Data.Entities.MedicinePlan GetById(int id);
        void Insert(Medical.Data.Entities.MedicinePlan MedicinePlan);
        void Update(Medical.Data.Entities.MedicinePlan medicinePlan);
    }
}
