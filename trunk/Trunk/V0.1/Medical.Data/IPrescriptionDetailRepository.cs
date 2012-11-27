using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IPrescriptionDetailRepository
    {
        void Insert(PrescriptionDetail user);
        void Update(PrescriptionDetail user);
        void Delete(int id);
        List<PrescriptionDetail> GetAll();
        List<PrescriptionDetail> GetByPrescription(int prescriptionId);
    }
}
