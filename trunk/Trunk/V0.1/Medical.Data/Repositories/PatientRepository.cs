using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Forms.Implements;

namespace Medical.Data.Repositories {
    public class PatientRepository : RepositoryBase, IPatientRepository {

        public void Insert(Patient user) {
             user.StartDate = DateTime.Today;
            user.Version = 0;
            user.ClinicId = AppContext.CurrentClinic.Id;
            user.CreatedDate = DateTime.Now;
            user.CreatedUser = AppContext.LoggedInUser.Id;
            user.LastUpdatedDate = DateTime.Now;
            user.LastUpdatedUser = AppContext.LoggedInUser.Id;
            this.Context.Patients.Add(user);
            this.Context.SaveChanges();
        }

        public void Update(Patient user) {
            throw new NotImplementedException();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public Patient GetById(int id)
        {
            return this.Context.Patients.FirstOrDefault(x => x.Id == id);
        }

        public List<Patient> GetAll() {
            throw new NotImplementedException();
        }

        public List<Patient> GetByNameAndYear(string name, int? year) {
            return Context.Patients.Where(x => (x.Name.Contains(name) || String.IsNullOrEmpty(name)) && (!year.HasValue || x.BirthYear == year.Value)).ToList();
        }

    }
}
