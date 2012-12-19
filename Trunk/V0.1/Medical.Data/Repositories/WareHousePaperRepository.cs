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

        public WareHousePaper Get(int id)
        {
            var whPaper = this.Context.WareHousePapers.FirstOrDefault(x => x.Id.Equals(id));
            return whPaper;
        }
        public WareHousePaper GetById(int id)
        {
            var whPaper = this.Context.WareHousePapers.FirstOrDefault(x => x.Id.Equals(id));
            return whPaper;
        }



        public void Insert(WareHousePaper whPaper)
        {
            //whPaper.CreatedUser = AppContext.LoggedInUser.Id;
            whPaper.CreatedDate = DateTime.Now;
            //whPaper.LastUpdatedUser = AppContext.LoggedInUser.Id;
            whPaper.LastUpdatedDate = DateTime.Now;
            whPaper.Version = 0;
            this.Context.WareHousePapers.Add(whPaper);
            this.Context.SaveChanges();
        }

        public void Update(WareHousePaper whPaper)
        {
            try
            {
                var oldwhPaper = this.Context.WareHousePapers.FirstOrDefault(x => x.Id == whPaper.Id);
                if (oldwhPaper == null) return;
                oldwhPaper.Type = whPaper.Type;
                oldwhPaper.ClinicId = whPaper.ClinicId;
                oldwhPaper.CreatedUser = whPaper.CreatedUser;
                oldwhPaper.CreatedDate = whPaper.CreatedDate;
                oldwhPaper.Date = whPaper.Date;
                oldwhPaper.No = whPaper.No;
                oldwhPaper.Recipient = whPaper.Recipient;
                oldwhPaper.Deliverer = whPaper.Deliverer;
                oldwhPaper.Note = whPaper.Note;
                oldwhPaper.LastUpdatedUser = 1;
                // oldwhPaper.LastUpdatedUser = AppContext.LoggedInUser.Id;
                oldwhPaper.LastUpdatedDate = DateTime.Now;
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


        public List<WareHousePaper> GetAll()
        {
            try
            {
                List<WareHousePaper> lst = this.Context.WareHousePapers.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<WareHousePaper> GetByClinicID(int idClinic)
        {
            try
            {
                List<WareHousePaper> lst =
                    this.Context.WareHousePapers.Where(x => x.ClinicId.Equals(idClinic)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<WareHousePaper> Search(int type, DateTime fromDate, DateTime toDate)
        {
            try
            {
                return this.Context.WareHousePapers.Where(x => x.Type == type && x.Date >= fromDate && x.Date <= toDate).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
