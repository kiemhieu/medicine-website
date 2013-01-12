using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
//using Medical.Forms.Implements;


namespace Medical.Data.Repositories
{
    public class WareHousePaperRepository : RepositoryBase, IWareHousePaperRepository
    {

        public WareHouseIO Get(int id)
        {
            var whPaper = this.Context.WareHousePapers.FirstOrDefault(x => x.Id.Equals(id));
            return whPaper;
        }
        public WareHouseIO GetById(int id)
        {
            var whPaper = this.Context.WareHousePapers.FirstOrDefault(x => x.Id.Equals(id));
            return whPaper;
        }



        public void Insert(WareHouseIO whIo)
        {
            //whPaper.CreatedUser = AppContext.LoggedInUser.Id;
            whIo.CreatedDate = DateTime.Now;
            //whPaper.LastUpdatedUser = AppContext.LoggedInUser.Id;
            // whIo.LastUpdatedDate = DateTime.Now;
            whIo.Version = 0;
            this.Context.WareHousePapers.Add(whIo);
            this.Context.SaveChanges();
        }

        public void Update(WareHouseIO whIo)
        {
            try
            {
                var oldwhPaper = this.Context.WareHousePapers.FirstOrDefault(x => x.Id == whIo.Id);
                if (oldwhPaper == null) return;
                oldwhPaper.Type = whIo.Type;
                oldwhPaper.ClinicId = whIo.ClinicId;
                oldwhPaper.CreatedUser = whIo.CreatedUser;
                oldwhPaper.CreatedDate = whIo.CreatedDate;
                oldwhPaper.Date = whIo.Date;
                oldwhPaper.No = whIo.No;
                // oldwhPaper.Recipient = whIo.Recipient;
                // oldwhPaper.Deliverer = whIo.Deliverer;
                oldwhPaper.Note = whIo.Note;
                // oldwhPaper.LastUpdatedUser = 1;
                // oldwhPaper.LastUpdatedUser = AppContext.LoggedInUser.Id;
                // oldwhPaper.LastUpdatedDate = DateTime.Now;
                oldwhPaper.Version++;
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
                var oldwhPaper = this.Context.WareHousePapers.FirstOrDefault(x => x.Id == id);
                this.Context.WareHousePapers.Remove(oldwhPaper);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }


        public List<WareHouseIO> GetAll()
        {
            try
            {
                List<WareHouseIO> lst = this.Context.WareHousePapers.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<WareHouseIO> GetByClinicID(int idClinic)
        {
            try
            {
                List<WareHouseIO> lst =
                    this.Context.WareHousePapers.Where(x => x.ClinicId.Equals(idClinic)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<WareHouseIO> Search(int type, DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (type >= 0)
                    // return this.Context.WareHousePapers.Where(x => x.Type == type && x.Date >= fromDate.Date && x.Date <= toDate).ToList();
                    return this.Context.WareHousePapers.Where(x => x.Date >= fromDate.Date && x.Date <= toDate).ToList();

                else
                    return this.Context.WareHousePapers.Where(x => x.Date >= fromDate.Date && x.Date <= toDate).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
