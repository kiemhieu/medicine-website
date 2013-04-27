using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;

namespace Medical.Data
{
    public interface IPrescriptionRepository
    {
        void Insert(Prescription prescription);
        void Update(Prescription prescription);
        void Delete(long id);
        Prescription Get(long id);
        Prescription GetCurrent(int patientId);
        Prescription GetLastByPatient(int patientId);
        List<Prescription> GetAll();
        List<VPatientLastPrescription> GetAllOnLate(String patientName);
        List<Prescription> GetAll(int patientId);
        List<Prescription> GetAll(DateTime dateTime);

    }
}
