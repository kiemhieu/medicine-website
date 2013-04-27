using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;


namespace Medical.Data.Repositories
{
    public class TableChangeRepository : RepositoryBase, ITableChangeRepository
    {

        public TableChangeRepository()
            : base()
        {
        }

        public TableChangeRepository(bool serverContext)
            : base(serverContext)
        {

        }

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public TableChange Get(long no)
        {
            return Context.TableChanges.FirstOrDefault(x => x.No.Equals(no));
        }

        public TableChange GetById(long no)
        {
            return this.Context.TableChanges.FirstOrDefault(x => x.No.Equals(no));
        }

        public List<TableChange> GetByClinicId_TableName_Action(int clinicId, string tableName, string action)
        {
            return this.Context.TableChanges.Where(x => x.ClinicId.Equals(clinicId) && x.TableName.Equals(tableName) && x.Action.Equals(action)).ToList();
        }
        public List<TableChange> GetByClinicId_Action(int clinicId, string action)
        {
            return this.Context.TableChanges.Where(x => x.ClinicId.Equals(clinicId) && x.Action.Equals(action)).ToList();
        }
        public List<TableChange> GetByClinicId(int clinicId)
        {
            return this.Context.TableChanges.Where(x => x.ClinicId.Equals(clinicId)).ToList();
        }
        public List<TableChange> GetByClinicId_TableName(int clinicId, string tableName)
        {
            return this.Context.TableChanges.Where(x => x.ClinicId.Equals(clinicId) && x.TableName.Equals(tableName)).ToList();
        }
        public void Insert(TableChange TableChange)
        {
            TableChange.CreatedDate = DateTime.Now;
            this.Context.TableChanges.Add(TableChange);
            this.Context.SaveChanges();
        }

        public void Update(TableChange TableChange)
        {
            try
            {
                var oldTableChange = this.Context.TableChanges.FirstOrDefault(x => x.No == TableChange.No);
                if (oldTableChange == null) return;
                oldTableChange.Id = TableChange.Id;
                oldTableChange.TableName = TableChange.TableName;

                oldTableChange.Action = TableChange.Action;
                oldTableChange.CreatedDate = TableChange.CreatedDate;
                oldTableChange.ClinicId = TableChange.ClinicId;
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public void Delete(int no)
        {
            try
            {
                var oldTableChange = this.Context.TableChanges.FirstOrDefault(x => x.No == no);
                this.Context.TableChanges.Remove(oldTableChange);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<TableChange> GetAll()
        {
            return this.Context.TableChanges.ToList();
        }
    }
}
