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
        /// Inserts the specified prescription.
        /// </summary>
        /// <param name="prescription">The prescription.</param>
        public void Insert(Prescription prescription)
        {
            try
            {
                prescription.Version = 0;
                prescription.LastUpdatedDate = DateTime.Now;
                prescription.CreatedDate = DateTime.Now;

                foreach (var item in prescription.PrescriptionDetails)
                {
                    item.Version = 0;
                }
                this.Context.Prescription.Add(prescription);
                this.Context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Updates the specified prescription.
        /// </summary>
        /// <param name="prescription">The prescription.</param>
        public void Update(Prescription prescription)
        {
            var originalPres = this.Context.Prescription.FirstOrDefault(x => x.Id == prescription.Id);
            if (originalPres == null) throw new Exception("Không tồn tại dữ liệu trong CSDL.");
            originalPres.RecheckDate = prescription.RecheckDate;
            originalPres.Note = prescription.Note;
            originalPres.DoctorId  = prescription.DoctorId;
            originalPres.FigureId = prescription.FigureId;
            originalPres.Version++;

            foreach (var orginItem in originalPres.PrescriptionDetails)
            {
                var item = prescription.PrescriptionDetails.FirstOrDefault(x => x.Id == orginItem.Id);
                if (item == null) { this.Context.PrescriptionDetails.Remove(orginItem); }
                else
                {
                    item.MedicineId = 
                }

            }

            foreach (var orginItem in prescription.PrescriptionDetails)
            {
                var item = originalPres.PrescriptionDetails.FirstOrDefault(x => x.Id == orginItem.Id);
                
            }
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
