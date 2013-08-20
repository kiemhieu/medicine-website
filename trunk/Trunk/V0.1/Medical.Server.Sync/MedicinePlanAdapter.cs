using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Server.Sync
{
    public class MedicinePlanAdapter : AdapterBase
    {
        public MedicinePlanAdapter(SqlConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Syncs the specified data table.
        /// </summary>
        /// <param name="clinicId">The clinic id.</param>
        /// <param name="dataTable">The data table.</param>
        public override void Sync(int clinicId, DataTable dataTable)
        {
            List<int> ids = new List<int>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                ids.Add(Convert.ToInt32(dataRow["Id"]));
            }

            SqlDataAdapter adapter = BuildAdapter(clinicId, ids);
            DataTable original = new DataTable();
            adapter.Fill(original);

            List<int> updatedId = new List<int>();
            foreach (DataRow row in dataTable.Rows)
            {
                bool isExist = false;
                updatedId.Add(Convert.ToInt32(row["Id"]));
                foreach (DataRow orgRow in original.Rows)
                {
                    if (!row["Id"].Equals(orgRow["Id"])) continue;
                    orgRow["ClinicId"] = row["ClinicId"];
                    orgRow["Year"] = row["Year"];
                    orgRow["Month"] = row["Month"];
                    orgRow["Date"] = row["Date"];
                    orgRow["Note"] = row["Note"];
                    orgRow["Status"] = row["Status"];
                    orgRow["ApproveId"] = row["ApproveId"];
                    orgRow["ApproveDate"] = row["ApproveDate"];
                    orgRow["CreatedDate"] = row["CreatedDate"];
                    orgRow["CreatedUser"] = row["CreatedUser"];
                    orgRow["LastUpdatedDate"] = row["LastUpdatedDate"];
                    orgRow["LastUpdatedUser"] = row["LastUpdatedUser"];
                    orgRow["Version"] = row["Version"];
                    orgRow["LastSync"] = row["LastSync"];
                    isExist = true;
                    Console.WriteLine("Update row Id: " + row["Id"]);
                    break;
                }

                if (isExist) continue;
                DataRow newRow = original.NewRow();
                newRow["Id"] = row["Id"];
                newRow["ClinicId"] = row["ClinicId"];
                newRow["Year"] = row["Year"];
                newRow["Month"] = row["Month"];
                newRow["Date"] = row["Date"];
                newRow["Note"] = row["Note"];
                newRow["Status"] = row["Status"];
                newRow["ApproveId"] = row["ApproveId"];
                newRow["ApproveDate"] = row["ApproveDate"];
                newRow["CreatedDate"] = row["CreatedDate"];
                newRow["CreatedUser"] = row["CreatedUser"];
                newRow["LastUpdatedDate"] = row["LastUpdatedDate"];
                newRow["LastUpdatedUser"] = row["LastUpdatedUser"];
                newRow["Version"] = row["Version"];
                newRow["LastSync"] = row["LastSync"];
                original.Rows.Add(newRow);
            }

            foreach (DataRow row in original.Rows)
            {
                int id = Convert.ToInt32(row["Id"]);
                if (updatedId.Contains(id)) continue;
                Console.WriteLine("Delete row Id: " + row["Id"]);
                row.Delete();
            }

            adapter.Update(original);
            Console.WriteLine("UPDATE OK");
        }

        /// <summary>
        /// Creates the select command.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="clinicId">The clinic id.</param>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        protected override SqlCommand CreateSelectCommand(SqlConnection connection, int clinicId, List<int> ids)
        {
            String idString = "0";
            if (ids != null && ids.Count > 0)
            {
                idString = String.Join(",", ids);
            }

            String commandBuilder = String.Format("Select * from MedicinePlan Where Id in ({0}) And ClinicId = @clinicId", idString);
            SqlCommand sqlCommand = new SqlCommand(commandBuilder, connection);
            SqlParameter parameter = new SqlParameter("@clinicId", SqlDbType.Int, 4) { Value = clinicId };
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the update command.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append("UPDATE MedicalServer.dbo.MedicinePlan ");
            commandBuilder.Append("   SET  ");
            commandBuilder.Append("       Year = @year ");
            commandBuilder.Append("      ,Month = @month ");
            commandBuilder.Append("      ,Date = @date ");
            commandBuilder.Append("      ,Note = @note ");
            commandBuilder.Append("      ,Status = @status ");
            commandBuilder.Append("      ,ApproveId = @approveId ");
            commandBuilder.Append("      ,ApproveDate = @approveDate ");
            commandBuilder.Append("      ,CreatedDate = @createdDate ");
            commandBuilder.Append("      ,CreatedUser = @createdUser ");
            commandBuilder.Append("      ,LastUpdatedDate = @lastUpdatedDate ");
            commandBuilder.Append("      ,LastUpdatedUser = @lastUpdatedUser ");
            commandBuilder.Append("      ,Version = @version ");
            commandBuilder.Append(" WHERE Id = @id AND ClinicId = @clinicId ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@year", SqlDbType.Int, 4, "Year");
            sqlCommand.Parameters.Add("@month", SqlDbType.Int, 4, "Month");
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime, 8, "Date");
            sqlCommand.Parameters.Add("@note", SqlDbType.NVarChar, 150, "Note");
            sqlCommand.Parameters.Add("@status", SqlDbType.Int, 4, "Status");
            sqlCommand.Parameters.Add("@approveId", SqlDbType.Int, 4, "ApproveId");
            sqlCommand.Parameters.Add("@approveDate", SqlDbType.DateTime, 8, "ApproveDate");
            sqlCommand.Parameters.Add("@createdDate", SqlDbType.DateTime, 8, "CreatedDate");
            sqlCommand.Parameters.Add("@createdUser", SqlDbType.Int, 4, "CreatedUser");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            sqlCommand.Parameters.Add("@lastUpdatedUser", SqlDbType.Int, 4, "LastUpdatedUser");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");
            sqlCommand.Parameters.Add("@lastSync", SqlDbType.DateTime, 8, "LastSync");

            // Add key
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@clinicId", SqlDbType.Int, 4, "ClinicId") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }

        /// <summary>
        /// Creates the delete command.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from MedicinePlan Where Id = @id and ClinicId = @clinicId", connection);
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@clinicId", SqlDbType.Int, 4, "ClinicId") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }

        /// <summary>
        /// Creates the insert command.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected override SqlCommand CreateInsertCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" INSERT INTO MedicinePlan ");
            commandBuilder.Append("           (Id");
            commandBuilder.Append("           ,ClinicId ");
            commandBuilder.Append("           ,Year ");
            commandBuilder.Append("           ,Month ");
            commandBuilder.Append("           ,Date ");
            commandBuilder.Append("           ,Note ");
            commandBuilder.Append("           ,Status ");
            commandBuilder.Append("           ,ApproveId ");
            commandBuilder.Append("           ,ApproveDate ");
            commandBuilder.Append("           ,CreatedDate ");
            commandBuilder.Append("           ,CreatedUser ");
            commandBuilder.Append("           ,LastUpdatedDate ");
            commandBuilder.Append("           ,LastUpdatedUser ");
            commandBuilder.Append("           ,Version ");
            commandBuilder.Append("           ,LastSync) ");
            commandBuilder.Append("     VALUES ");
            commandBuilder.Append("           (@id");
            commandBuilder.Append("           ,@clinicId ");
            commandBuilder.Append("           ,@year ");
            commandBuilder.Append("           ,@month ");
            commandBuilder.Append("           ,@date ");
            commandBuilder.Append("           ,@note ");
            commandBuilder.Append("           ,@status ");
            commandBuilder.Append("           ,@approveId ");
            commandBuilder.Append("           ,@approveDate ");
            commandBuilder.Append("           ,@createdDate ");
            commandBuilder.Append("           ,@createdUser ");
            commandBuilder.Append("           ,@lastUpdatedDate ");
            commandBuilder.Append("           ,@lastUpdatedUser ");
            commandBuilder.Append("           ,@version ");
            commandBuilder.Append("           ,@lastSync) ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            sqlCommand.Parameters.Add("@clinicId", SqlDbType.Int, 4, "ClinicId");
            sqlCommand.Parameters.Add("@year", SqlDbType.Int, 4, "Year");
            sqlCommand.Parameters.Add("@month", SqlDbType.Int, 4, "Month");
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime, 8, "Date");
            sqlCommand.Parameters.Add("@note", SqlDbType.NVarChar, 150, "Note");
            sqlCommand.Parameters.Add("@status", SqlDbType.Int, 4, "Status");
            sqlCommand.Parameters.Add("@approveId", SqlDbType.Int, 4, "ApproveId");
            sqlCommand.Parameters.Add("@approveDate", SqlDbType.DateTime, 8, "ApproveDate");
            sqlCommand.Parameters.Add("@createdDate", SqlDbType.DateTime, 8, "CreatedDate");
            sqlCommand.Parameters.Add("@createdUser", SqlDbType.Int, 4, "CreatedUser");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            sqlCommand.Parameters.Add("@lastUpdatedUser", SqlDbType.Int, 4, "LastUpdatedUser");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");
            sqlCommand.Parameters.Add("@lastSync", SqlDbType.DateTime, 8, "LastSync");
            return sqlCommand;
        }
    }
}
