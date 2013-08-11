using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Server.Sync
{
    public class PatientAdapter : AdapterBase
    {
        public PatientAdapter(SqlConnection connection) : base(connection)
        {
        }


        public override void Sync(DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand CreateSelectCommand(SqlConnection connection, List<int> ids)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand CreateInsertCommand(SqlConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
