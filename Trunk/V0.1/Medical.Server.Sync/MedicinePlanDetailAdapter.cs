using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Server.Sync
{
    public class MedicinePlanDetailAdapter : AdapterBase
    {
        public MedicinePlanDetailAdapter(SqlConnection connection) : base(connection)
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
                    orgRow["PlanId"] = row["PlanId"];
                    orgRow["MedicineId"] = row["MedicineId"];
                    orgRow["InStock"] = row["InStock"];
                    orgRow["LastMonthUsage"] = row["LastMonthUsage"];
                    orgRow["CurrentMonthUsage"] = row["CurrentMonthUsage"];
                    orgRow["Required"] = row["Required"];
                    orgRow["UnitPrice"] = row["UnitPrice"];
                    orgRow["Amount"] = row["Amount"];
                    orgRow["Version"] = row["Version"];
                    orgRow["LastUpdatedDate"] = row["LastUpdatedDate"];
                    isExist = true;
                    Console.WriteLine("Update row Id: " + row["Id"]);
                    break;
                }

                if (isExist) continue;
                DataRow newRow = original.NewRow();
                newRow["Id"] = row["Id"];
                newRow["PlanId"] = row["PlanId"];
                newRow["ClinicId"] = row["ClinicId"];
                newRow["MedicineId"] = row["MedicineId"];
                newRow["InStock"] = row["InStock"];
                newRow["LastMonthUsage"] = row["LastMonthUsage"];
                newRow["CurrentMonthUsage"] = row["CurrentMonthUsage"];
                newRow["Required"] = row["Required"];
                newRow["UnitPrice"] = row["UnitPrice"];
                newRow["Amount"] = row["Amount"];
                newRow["Version"] = row["Version"];
                newRow["LastUpdatedDate"] = row["LastUpdatedDate"];
                Console.WriteLine("Add row Id: " + row["Id"]);
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

            String commandBuilder = String.Format("Select * from MedicinePlanDetail Where Id in ({0}) And ClinicId = @clinicId", idString);
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
            commandBuilder.Append(" UPDATE MedicinePlanDetail ");
            commandBuilder.Append(" SET ");
            commandBuilder.Append("  MedicineId = @medicineId ");
            commandBuilder.Append("  ,InStock = @inStock ");
            commandBuilder.Append("  ,LastMonthUsage = @lastMonthUsage ");
            commandBuilder.Append("  ,CurrentMonthUsage = @currentMonthUsage ");
            commandBuilder.Append("  ,Required = @required ");
            commandBuilder.Append("  ,UnitPrice = @unitPrice ");
            commandBuilder.Append("  ,Amount = @amount ");
            commandBuilder.Append("  ,Version = @version ");
            commandBuilder.Append("  ,LastUpdatedDate = @lastUpdatedDate ");
            commandBuilder.Append(" WHERE Id = @id AND ClinicId = @clinicId ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@medicineId", SqlDbType.Int, 4, "MedicineId");
            sqlCommand.Parameters.Add("@inStock", SqlDbType.Int, 4, "InStock");
            sqlCommand.Parameters.Add("@lastMonthUsage", SqlDbType.Int, 4, "LastMonthUsage");
            sqlCommand.Parameters.Add("@currentMonthUsage", SqlDbType.Int, 4, "CurrentMonthUsage");
            sqlCommand.Parameters.Add("@required", SqlDbType.Int, 4, "Required");
            sqlCommand.Parameters.Add("@unitPrice", SqlDbType.Int, 4, "UnitPrice");
            sqlCommand.Parameters.Add("@amount", SqlDbType.Int, 4, "Amount");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");

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
            SqlCommand sqlCommand = new SqlCommand("Delete from MedicinePlanDetail Where Id = @id and ClinicId = @clinicId", connection);
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
            commandBuilder.Append(" INSERT INTO MedicinePlanDetail ");
            commandBuilder.Append("   (Id ");
            commandBuilder.Append("   ,PlanId ");
            commandBuilder.Append("   ,ClinicId ");
            commandBuilder.Append("   ,MedicineId ");
            commandBuilder.Append("   ,InStock ");
            commandBuilder.Append("   ,LastMonthUsage ");
            commandBuilder.Append("   ,CurrentMonthUsage ");
            commandBuilder.Append("   ,Required ");
            commandBuilder.Append("   ,UnitPrice ");
            commandBuilder.Append("   ,Amount ");
            commandBuilder.Append("   ,Version ");
            commandBuilder.Append("   ,LastUpdatedDate) ");
            commandBuilder.Append("  VALUES ");
            commandBuilder.Append("   (@id ");
            commandBuilder.Append("   ,@planId ");
            commandBuilder.Append("   ,@clinicId ");
            commandBuilder.Append("   ,@medicineId ");
            commandBuilder.Append("   ,@inStock ");
            commandBuilder.Append("   ,@lastMonthUsage ");
            commandBuilder.Append("   ,@currentMonthUsage ");
            commandBuilder.Append("   ,@required ");
            commandBuilder.Append("   ,@unitPrice ");
            commandBuilder.Append("   ,@amount ");
            commandBuilder.Append("   ,@version ");
            commandBuilder.Append("   ,@lastUpdatedDate) ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            sqlCommand.Parameters.Add("@planId", SqlDbType.Int, 4, "PlanId");
            sqlCommand.Parameters.Add("@clinicId", SqlDbType.Int, 4, "ClinicId");
            sqlCommand.Parameters.Add("@medicineId", SqlDbType.Int, 4, "MedicineId");
            sqlCommand.Parameters.Add("@inStock", SqlDbType.Int, 4, "InStock");
            sqlCommand.Parameters.Add("@lastMonthUsage", SqlDbType.Int, 4, "LastMonthUsage");
            sqlCommand.Parameters.Add("@currentMonthUsage", SqlDbType.Int, 4, "CurrentMonthUsage");
            sqlCommand.Parameters.Add("@required", SqlDbType.Int, 4, "Required");
            sqlCommand.Parameters.Add("@unitPrice", SqlDbType.Int, 4, "UnitPrice");
            sqlCommand.Parameters.Add("@amount", SqlDbType.Int, 4, "Amount");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            return sqlCommand;
        }
    }
}
