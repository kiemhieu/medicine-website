using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class PrescriptionDetailRepository: RepositoryBase, IPrescriptionDetailRepository
    {
        /// <summary>
        /// Inserts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Insert(PrescriptionDetail user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Update(PrescriptionDetail user)
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
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<PrescriptionDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<PrescriptionDetail> GetByPrescription(int prescriptionId)
        {
            return this.Context.PrescriptionDetails.Where(x => x.PrescriptionId == prescriptionId).ToList();
        }
    }
}
