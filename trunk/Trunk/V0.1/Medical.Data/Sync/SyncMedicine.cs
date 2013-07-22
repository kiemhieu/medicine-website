using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Data.Repositories;

namespace Medical.Data.Sync
{
    public class SyncMedicine
    {
        public void Sync()
        {
            MedicalContext clientRepo = new MedicalContext();
            Medical2Context serverRepo = new Medical2Context();

            List<Medicine> clientsMedicines = clientRepo.Medicines.OrderBy(x=>x.Id).ToList();
            List<Medicine> serverMedicines = serverRepo.Medicines.OrderBy(x => x.Id).ToList();

            foreach (Medicine org in  clientsMedicines)
            {
                bool isExist = false;
                foreach (Medicine target in serverMedicines)
                {
                    if (org.Id != target.Id) continue;
                    isExist = true;
                    update(org, target);
                    Console.WriteLine("Update: " + org.Id);
                }

                if (isExist) continue;
                clientRepo.Medicines.Remove(org);
                Console.WriteLine("Delete: " + org.Id);
            }

            foreach (Medicine target in serverMedicines)
            {
                bool isExist = false;
                foreach (Medicine org in clientsMedicines)
                {
                    if (org.Id != target.Id) continue;
                    isExist = true;
                }

                if (isExist) continue;
                Medicine news = clone(target);
                clientRepo.Medicines.Add(news);
                Console.WriteLine("Add: " + target.Id);
            }

            clientRepo.SaveChanges();
        }

        private void update(Medicine original, Medicine target)
        {
            
            original.No = target.No;
            original.Name = target.Name;
            original.Content = target.Content;
            original.ContentUnit = target.ContentUnit;
            original.Unit = target.Unit;
            original.TradeName = target.TradeName;
            original.Description = target.Description;
            original.Type = target.Type;
            original.CreatedDate = target.CreatedDate;
            original.CreatedBy = target.CreatedBy;
            original.LastUpdatedDate = target.LastUpdatedDate;
            original.LastUpdatedBy = target.LastUpdatedBy;
            original.Version = target.Version;

        }

        private Medicine clone(Medicine original)
        {
            Medicine medicine = new Medicine();
            update(medicine, original);
            medicine.Id = original.Id;
            return medicine;
        }
    }
}
