using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.ClientAdapter
{
    public class MedicinePlanClientAdapter : ClientAdapterBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MedicinePlanClientAdapter"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public MedicinePlanClientAdapter(SqlConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Creates the select command.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            String commandBuilder = String.Format("Select * from MedicinePlan Where LastSync IS NULL OR LastSync < LastUpdatedDate");
            SqlCommand sqlCommand = new SqlCommand(commandBuilder, connection);
            return sqlCommand;
        }

        /// <summary>
        /// Creates the update command.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" UPDATE MedicinePlan SET LastSync = GETDATE() WHERE Id = @id ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            // sqlCommand.Parameters.Add("@lastSync", SqlDbType.DateTime, 8, "LastSync");
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }
    }
}
