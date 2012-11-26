using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IPrescriptionRepository
    {
        void Insert(Prescription user);
        void Update(Prescription user);
        void Delete(int id);
        Prescription GetLastByPatient(int patientId);
        Prescription GetCurrent(int id);
        List<Prescription> GetAll();

    }
}
