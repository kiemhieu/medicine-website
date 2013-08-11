using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.TableAdapter
{
    public class FigureAdapter : AdapterBase
    {
        public FigureAdapter(SqlConnection connection) : base(connection)
        {
        }

        public override void Sync(DataTable dataTable)
        {
            SqlDataAdapter adapter = BuildAdapter();
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
                    orgRow["Name"] = row["Name"];
                    orgRow["ClinicId"] = row["ClinicId"];
                    orgRow["Description"] = row["Description"];
                    orgRow["LastUpdatedDate"] = row["LastUpdatedDate"];
                    orgRow["LastUpdatedUser"] = row["LastUpdatedUser"];
                    orgRow["Version"] = row["Version"];
                    isExist = true;
                    Console.WriteLine("Update row Id: " + row["Id"]);
                    break;
                }

                if (isExist) continue;
                DataRow newRow = original.NewRow();
                newRow["Id"] = row["Id"];
                newRow["Name"] = row["Name"];
                newRow["ClinicId"] = row["ClinicId"];
                newRow["Description"] = row["Description"];
                newRow["LastUpdatedDate"] = row["LastUpdatedDate"];
                newRow["LastUpdatedUser"] = row["LastUpdatedUser"];
                newRow["Version"] = row["Version"];
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
        }

        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            return new SqlCommand("Select * from Figure", connection);
        }

        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" UPDATE Figure ");
            commandBuilder.Append(" SET ");
            commandBuilder.Append("  Name = @name ");
            commandBuilder.Append("  ,ClinicId = @clinicId ");
            commandBuilder.Append("  ,Description = @description ");
            commandBuilder.Append("  ,LastUpdatedDate = @lastUpdatedDate ");
            commandBuilder.Append("  ,LastUpdatedUser = @lastUpdatedUser ");
            commandBuilder.Append("  ,Version = @version ");
            commandBuilder.Append(" WHERE Id = @id ");
            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50, "Name");
            sqlCommand.Parameters.Add("@clinicId", SqlDbType.Int, 4, "ClinicId");
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, 250, "Description");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            sqlCommand.Parameters.Add("@lastUpdatedUser", SqlDbType.Int, 4, "LastUpdatedUser");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            // Add key
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original };
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from FigureDetail Where FigureId = @id; Delete from Figure Where Id = @id", connection);
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original };
            sqlCommand.Parameters.Add(parameter);
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
            commandBuilder.Append(" INSERT INTO Figure ");
            commandBuilder.Append("   (Id ");
            commandBuilder.Append("   ,Name ");
            commandBuilder.Append("   ,ClinicId ");
            commandBuilder.Append("   ,Description ");
            commandBuilder.Append("   ,LastUpdatedDate ");
            commandBuilder.Append("   ,LastUpdatedUser ");
            commandBuilder.Append("   ,Version) ");
            commandBuilder.Append("  VALUES ");
            commandBuilder.Append("   (@id ");
            commandBuilder.Append("   ,@name ");
            commandBuilder.Append("   ,@clinicId ");
            commandBuilder.Append("   ,@description ");
            commandBuilder.Append("   ,@lastUpdatedDate ");
            commandBuilder.Append("   ,@lastUpdatedUser ");
            commandBuilder.Append("   ,@version) ");
            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);


            // Add parameter
            sqlCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50, "Name");
            sqlCommand.Parameters.Add("@clinicId", SqlDbType.Int, 4, "ClinicId");
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, 250, "Description");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            sqlCommand.Parameters.Add("@lastUpdatedUser", SqlDbType.Int, 4, "LastUpdatedUser");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            return sqlCommand;
        }
    }
}
