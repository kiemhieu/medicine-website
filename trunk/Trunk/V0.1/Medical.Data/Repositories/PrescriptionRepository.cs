using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class PrescriptionRepository : RepositoryBase, IPrescriptionRepository
    {

        /// <summary>
        /// Inserts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Insert(Prescription user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Update(Prescription user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the last by patient.
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <returns></returns>
        public Prescription GetLastByPatient(int patientId)
        {
            return this.Context.Prescription.Where(x => x.PatientId == patientId).OrderByDescending(x => x.Date).Take(1).FirstOrDefault();
        }

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Prescription GetCurrent(int id)
        {
            return this.Context.Prescription.FirstOrDefault(x => x.Id == id && x.Date == DateTime.Today);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Prescription> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
