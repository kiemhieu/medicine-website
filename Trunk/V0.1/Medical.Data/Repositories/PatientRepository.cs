using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
//using Medical.Forms.Implements;

namespace Medical.Data.Repositories
{
    public class PatientRepository : RepositoryBase, IPatientRepository
    {

        /// <summary>
        /// Inserts the specified user.
        /// </summary>
        /// <param name="patient">The user.</param>
        public void Insert(Patient patient)
        {
            patient.StartDate = DateTime.Today;
            patient.Version = 0;
            patient.ClinicId = AppContext.CurrentClinic.Id;
            patient.CreatedDate = DateTime.Now;
            patient.CreatedUser = AppContext.LoggedInUser.Id;
            patient.LastUpdatedDate = DateTime.Now;
            patient.LastUpdatedUser = AppContext.LoggedInUser.Id;
            this.Context.Patients.Add(patient);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Update(Patient patient)
        {
            var origin = this.Context.Patients.FirstOrDefault(x => x.Id == patient.Id);
            if (origin == null) return;
            origin.Address = patient.Address;
            origin.BirthYear = patient.BirthYear;
            origin.ClinicId = patient.ClinicId;
            origin.Code = patient.Code;
            origin.Description = patient.Description;
            origin.SetInfo(true);
            this.Context.SaveChanges();
            this.Context.Entry(origin).Reload();
        }

        public void Delete(int id)
        {
            try
            {
                var oldPatient = this.Context.Patients.FirstOrDefault(x => x.Id == id);
                this.Context.Patients.Remove(oldPatient);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Patient GetById(int id)
        {
            return this.Context.Patients.FirstOrDefault(x => x.Id == id);
        }

        public List<Patient> GetAll()
        {
            return this.Context.Patients.ToList();
        }

        /// <summary>
        /// Gets the by name and year.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public List<Patient> GetByNameAndYear(string name, int? year)
        {
            return Context.Patients.Where(x => (x.Name.Contains(name) || String.IsNullOrEmpty(name)) && (!year.HasValue || x.BirthYear == year.Value)).ToList();
        }

        public List<Patient> GetByNameAndYear(string name, int? year, int clinicId)
        {
            return Context.Patients.Where(x => (x.Name.Contains(name) || String.IsNullOrEmpty(name)) && (!year.HasValue || x.BirthYear == year.Value) && x.ClinicId == clinicId).ToList();
        }
    }
}
