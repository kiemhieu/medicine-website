using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.ClientAdapter
{
    public class TableChangeClientAdapter : ClientAdapterBase
    {
        public TableChangeClientAdapter(SqlConnection connection) : base(connection)
        {
        }

        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            var commandBuilder = String.Format("Select * from TableChange");
            var sqlCommand = new SqlCommand(commandBuilder, connection);
            return sqlCommand;
        }

        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            var commandBuilder = new StringBuilder();
            commandBuilder.Append(" DELETE FROM TableChange WHERE No = @no ");

            var sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            // sqlCommand.Parameters.Add("@lastSync", SqlDbType.DateTime, 8, "LastSync");
            sqlCommand.Parameters.Add(new SqlParameter("@no", SqlDbType.Int, 4, "No") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }
    }
}
