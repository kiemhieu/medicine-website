using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
//using Medical.Forms.Implements;


namespace Medical.Data.Repositories
{
    public class WareHouseRepository : RepositoryBase, IWareHouseRepository
    {
        public WareHouse Get(int id)
        {
            var whDetail = this.Context.WareHouses.FirstOrDefault(x => x.Id.Equals(id));
            return whDetail;
        }
        public WareHouse GetById(int id)
        {
            var whDetail = this.Context.WareHouses.FirstOrDefault(x => x.Id.Equals(id));
            return whDetail;
        }



        public void Insert(WareHouse whItem)
        {
            try
            {
                this.Context.WareHouses.Add(whItem);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void Update(WareHouse whItem)
        {
            try
            {
                var oldWh = this.Context.WareHouses.FirstOrDefault(x => x.Id == whItem.Id);
                if (oldWh == null) return;
                oldWh.ClinicId = whItem.ClinicId;
                oldWh.MedicineId = whItem.MedicineId;
                oldWh.Volumn = whItem.Volumn;
                oldWh.MinAllowed = whItem.MinAllowed;
                oldWh.LastUpdatedUser = whItem.LastUpdatedUser;
                oldWh.LastUpdatedDate = DateTime.Now;
                oldWh.Version++;
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void Delete(int id)
        {
            try
            {
                var oldWHDetail = this.Context.WareHouses.FirstOrDefault(x => x.Id == id);
                this.Context.WareHouses.Remove(oldWHDetail);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<WareHouse> GetAll()
        {
            try
            {
                List<WareHouse> lst = this.Context.WareHouses.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public WareHouse GetByIdMedicine(int idMedicine)
        {
            try
            {
                WareHouse item =
                    this.Context.WareHouses.Where(x => x.MedicineId.Equals(idMedicine)).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public WareHouse GetByIdMedicine(int idMedicine, int clinicId)
        {
            try
            {
                var item =
                    this.Context.WareHouses.Where(x => x.MedicineId.Equals(idMedicine) && x.ClinicId.Equals(clinicId)).FirstOrDefault();
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<WareHouse> GetByMedicineId(List<int> medicineId, int clinicId)
        {
            return this.Context.WareHouses.Where(x => medicineId.Contains(x.MedicineId) && x.ClinicId == clinicId).ToList();
        }

        public List<WareHouse> GetByClinicId(int clinicId)
        {
            return this.Context.WareHouses.Where(x => x.ClinicId == clinicId).ToList();
        }

        public List<MedicinePlanDetail> GetInventory(int clinicId, DateTime fromDate, DateTime toDate)
        {
            fromDate = fromDate.AddDays(-1);
            toDate = toDate.AddDays(1);
            List<MedicinePlanDetail> list = new List<MedicinePlanDetail>();
            try
            {
                List<int> listId = new List<int>();
                if (clinicId > 0)
                {
                    listId = (from c in Context.WareHouses where c.ClinicId == clinicId select c.MedicineId).ToList();
                }
                else
                {
                    listId = (from c in Context.Medicines select c.Id).ToList();
                }

                foreach (int id in listId)
                {
                    list.Add(
                                new MedicinePlanDetail
                                {
                                    UnitName = Context.Medicines.Where(c => c.Id == id).FirstOrDefault().Define.Name,
                                    MedicineName = Context.Medicines.Where(c => c.Id == id).FirstOrDefault().Name,
                                    InStock = GetInventory(0, id, fromDate, toDate),
                                    CurrentMonthUsage = GetInventory(1, id, fromDate, toDate)
                                }
                            );
                }

            }
            catch (Exception ex)
            { }

            return list;
        }

        private int GetInventory(int type, int medicineId, DateTime fromDate, DateTime toDate)
        {
            var item = (from p in Context.WareHousePaperDetails
                        where p.MedicineId == medicineId && p.Type == type && p.CreatedDate < toDate && p.CreatedDate > fromDate
                        group p by p.MedicineId into g
                        select new { Volumn = g.Sum(p => p.Volumn) }).FirstOrDefault();
            return item != null ? item.Volumn : 0;
        }

        public List<MedicinePlanDetail> GetByPlan(int clinicId, int year, int month)
        {
            List<MedicinePlanDetail> list = new List<MedicinePlanDetail>();
            try
            {
                var listWareHouse = (from x in Context.WareHouses where x.ClinicId == clinicId select x).ToList();

                foreach (WareHouse whItem in listWareHouse)
                {
                    MedicinePlanDetail item = new MedicinePlanDetail();
                    item.MedicineId = whItem.MedicineId;
                    item.MedicineName = whItem.MedicineName;
                    item.InStock = whItem.Volumn;
                    item.LastMonthUsage = GetMedicineInMonth(year, month - 1, 1, whItem.MedicineId);
                    item.CurrentMonthUsage = GetMedicineInMonth(year, month, 1, whItem.MedicineId);
                    list.Add(item);
                }
            }
            catch (Exception ex)
            { }

            return list;
        }

        private int GetMedicineInMonth(int year, int month, int type, int medicineId)
        {
            var s = from c in Context.WareHousePaperDetails
                    where c.MedicineId == medicineId && c.Type == type && c.CreatedDate.Year == year && c.CreatedDate.Month == month
                    group c by c.MedicineId into g
                    select new { TotalInStock = g.Sum(x => x.Volumn) };
            if (s.FirstOrDefault() != null)
                return s.FirstOrDefault().TotalInStock;

            return 0;
        }
    }
}
