using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories {
    public class PrescriptionRepository : RepositoryBase, IPrescriptionRepository {
        public void Insert(Prescription user) {
            throw new NotImplementedException();
        }

        public void Update(Prescription user) {
            throw new NotImplementedException();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public Prescription GetLastByPatient(int patientId) {
            return this.Context.Prescription.Where(x => x.PatientId == patientId).OrderByDescending(x => x.Date).Take(1).FirstOrDefault();
        }

        public Prescription GetCurrent(int id) {
            return this.Context.Prescription.FirstOrDefault(x => x.Id == id && x.Date == DateTime.Today);
        }

        public List<Prescription> GetAll() {
            throw new NotImplementedException();
        }
    }
}
