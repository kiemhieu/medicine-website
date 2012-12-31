using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;


namespace Medical.Data.Repositories
{
    public class WareHouseExportAllocateRepository : RepositoryBase, IWareHouseExportAllocateRepository
    {

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public WareHouseExportAllocate Get(int id)
        {
            return Context.WareHouseExportAllocates.FirstOrDefault(x => x.Id.Equals(id));
        }

        public WareHouseExportAllocate GetById(int id)
        {
            return this.Context.WareHouseExportAllocates.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Insert(WareHouseExportAllocate WareHouseExportAllocate)
        {
            WareHouseExportAllocate.Version = 0;
            this.Context.WareHouseExportAllocates.Add(WareHouseExportAllocate);
            this.Context.SaveChanges();
        }

        public void Update(WareHouseExportAllocate WareHouseExportAllocate)
        {
            try
            {
                var oldWareHouseExportAllocate = this.Context.WareHouseExportAllocates.FirstOrDefault(x => x.Id == WareHouseExportAllocate.Id);
                if (oldWareHouseExportAllocate == null) return;
                oldWareHouseExportAllocate.Version++;
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void Delete(long id)
        {
            try
            {
                var oldWareHouseExportAllocate = this.Context.WareHouseExportAllocates.FirstOrDefault(x => x.Id == id);
                this.Context.WareHouseExportAllocates.Remove(oldWareHouseExportAllocate);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<WareHouseExportAllocate> GetAll()
        {
            return this.Context.WareHouseExportAllocates.ToList();
        }

        public List<WareHouseExportAllocate> GetByPaperDetailId(int id)
        {
            return this.Context.WareHouseExportAllocates.Where(c => c.WareHoudePaperDetailId == id).ToList();
        }       
    }
}
