using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IPatientRepository
    {
        void Insert(Patient user);
        void Update(Patient user);
        void Delete(int id);
        List<Patient> GetAll();
        List<Patient> GetByNameAndYear(string name, int? year);
    }
}
