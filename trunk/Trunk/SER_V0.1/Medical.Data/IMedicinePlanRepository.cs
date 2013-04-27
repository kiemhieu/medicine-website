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
        MedicinePlan Get(int id);
        List<MedicinePlan> Get(int? clinicId, int? year, int? month);
        List<MedicinePlan> GetAll();
        List<MedicinePlan> GetUncompletedPlan(int? clinicId);
        MedicinePlan GetById(int id);
        void Insert(MedicinePlan MedicinePlan);
        void Insert(MedicinePlan medicinePlan, List<MedicinePlanDetail> medicinePlanDetails);
        void Update(MedicinePlan medicinePlan, List<MedicinePlanDetail> medicinePlanDetails);
        void Update(MedicinePlan medicinePlan);
        void UpdateStatus(int medicineDetailPlanningId, int status);
    }
}
