using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface ITableChangeRepository
    {
        void Insert(TableChange user);
        void Update(TableChange user);
        void Delete(int id);
        List<TableChange> GetAll();
        TableChange Get(long no);
        List<TableChange> GetByClinicId_TableName_Action(int clinicId, string tableName, string action);
        List<TableChange> GetByClinicId_TableName(int clinicId, string tableName);
        List<TableChange> GetByClinicId_Action(int clinicId, string action);
        List<TableChange> GetByClinicId(int clinicId);
    }
}
