using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IPatientRepository
    {
        void Insert(Patient patient);
        void Update(Patient user);
        void Delete(int id);
        Patient GetById(int id);
        List<Patient> GetAll();
        List<Patient> GetByNameAndYear(string name, int? year);
        List<Patient> GetByNameAndYear(string name, int? year, int clinicId);
        List<Patient> Search(String id, string name, int? year, int clinicId);
        Boolean IsDuplicateCode(String code);
    }
}
