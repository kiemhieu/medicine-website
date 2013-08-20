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
        private String key;
        public TableChangeClientAdapter(SqlConnection connection, String key) : base(connection)
        {
            this.key = key;
            this.adapter = BuildAdapter();

        }

        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            var commandBuilder = String.Format("Select * from TableChange Where TableName = @tableName");
            var sqlCommand = new SqlCommand(commandBuilder, connection);
            var parameter = new SqlParameter("@tableName", SqlDbType.VarChar, 50) { Value = this.key };
            sqlCommand.Parameters.Add(parameter);
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
