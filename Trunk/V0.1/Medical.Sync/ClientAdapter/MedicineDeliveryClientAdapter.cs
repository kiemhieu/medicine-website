﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.ClientAdapter
{
    public class MedicineDeliveryClientAdapter : ClientAdapterBase
    {
        public MedicineDeliveryClientAdapter(SqlConnection connection) : base(connection)
        {
        }

        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            String commandBuilder = String.Format("Select * from MedicineDelivery Where LastSync IS NULL OR LastSync < LastUpdatedDate");
            SqlCommand sqlCommand = new SqlCommand(commandBuilder, connection);
            return sqlCommand;
        }

        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" UPDATE MedicineDelivery SET LastSync = GETDATE() WHERE Id = @id ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            // sqlCommand.Parameters.Add("@lastSync", SqlDbType.DateTime, 8, "LastSync");
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }
    }
}
