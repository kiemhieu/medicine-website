using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.TableAdapter
{
    public class MedicineAdapter : AdapterBase
    {
        public MedicineAdapter(SqlConnection connection) : base(connection)
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
                    orgRow["Type"] = row["Type"];
                    orgRow["Name"] = row["Name"];
                    orgRow["Content"] = row["Content"];
                    orgRow["ContentUnit"] = row["ContentUnit"];
                    orgRow["Unit"] = row["Unit"];
                    orgRow["TradeName"] = row["TradeName"];
                    orgRow["Description"] = row["Description"];
                    orgRow["CreatedDate"] = row["CreatedDate"];
                    orgRow["CreatedBy"] = row["CreatedBy"];
                    orgRow["LastUpdatedDate"] = row["LastUpdatedDate"];
                    orgRow["LastUpdatedBy"] = row["LastUpdatedBy"];
                    orgRow["Version"] = row["Version"];
                    isExist = true;
                    Console.WriteLine("Update row Id: " + row["Id"]);
                    break;
                }

                if (isExist) continue;
                DataRow newRow = original.NewRow();
                newRow["Id"] = row["Id"];
                newRow["Type"] = row["Type"];
                newRow["Name"] = row["Name"];
                newRow["Content"] = row["Content"];
                newRow["ContentUnit"] = row["ContentUnit"];
                newRow["Unit"] = row["Unit"];
                newRow["TradeName"] = row["TradeName"];
                newRow["Description"] = row["Description"];
                newRow["CreatedDate"] = row["CreatedDate"];
                newRow["CreatedBy"] = row["CreatedBy"];
                newRow["LastUpdatedDate"] = row["LastUpdatedDate"];
                newRow["LastUpdatedBy"] = row["LastUpdatedBy"];
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
            Console.WriteLine("UPDATE OK");

        }

        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            return new SqlCommand("Select * from Medicine", connection);
        }

        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" Update Medicine Set ");
            commandBuilder.Append(" Type = @type, ");
            commandBuilder.Append(" Name = @name, ");
            commandBuilder.Append(" Content = @content , ");
            commandBuilder.Append(" ContentUnit = @contentUnit, ");
            commandBuilder.Append(" Unit = @unit, ");
            commandBuilder.Append(" TradeName = @tradeName, ");
            commandBuilder.Append(" Description = @description, ");
            commandBuilder.Append(" CreatedDate = @createdDate, ");
            commandBuilder.Append(" CreatedBy = @createdBy, ");
            commandBuilder.Append(" LastUpdatedDate = @lastUpdatedDate, ");
            commandBuilder.Append(" LastUpdatedBy = @lastUpdatedBy, ");
            commandBuilder.Append(" Version = @version ");
            commandBuilder.Append(" Where Id = @id ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@type", SqlDbType.Bit, 1, "Type");
            sqlCommand.Parameters.Add("@name", SqlDbType.VarChar, 200, "Name");
            sqlCommand.Parameters.Add("@content", SqlDbType.Int, 4, "Content");
            sqlCommand.Parameters.Add("@contentUnit", SqlDbType.Int, 4, "ContentUnit");
            sqlCommand.Parameters.Add("@unit", SqlDbType.Int, 4, "Unit");
            sqlCommand.Parameters.Add("@tradeName", SqlDbType.NVarChar, 200, "TradeName");
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, 400, "Description");
            sqlCommand.Parameters.Add("@createdDate", SqlDbType.DateTime, 8, "CreatedDate");
            sqlCommand.Parameters.Add("@createdBy", SqlDbType.Int, 4, "CreatedBy");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            sqlCommand.Parameters.Add("@lastUpdatedBy", SqlDbType.Int, 4, "LastUpdatedBy");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            // Add key
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original };
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from Medicine Where Id = @id", connection);
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original };
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        protected override SqlCommand CreateInsertCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" INSERT INTO Medicine ");
            commandBuilder.Append("   (Id ");
            commandBuilder.Append("   ,Type ");
            commandBuilder.Append("   ,Name ");
            commandBuilder.Append("   ,Content ");
            commandBuilder.Append("   ,ContentUnit ");
            commandBuilder.Append("   ,Unit ");
            commandBuilder.Append("   ,TradeName ");
            commandBuilder.Append("   ,Description ");
            commandBuilder.Append("   ,CreatedDate ");
            commandBuilder.Append("   ,CreatedBy ");
            commandBuilder.Append("   ,LastUpdatedDate ");
            commandBuilder.Append("   ,LastUpdatedBy ");
            commandBuilder.Append("   ,Version) ");
            commandBuilder.Append("  VALUES ");
            commandBuilder.Append("   (@Id ");
            commandBuilder.Append("   ,@Type ");
            commandBuilder.Append("   ,@Name ");
            commandBuilder.Append("   ,@Content ");
            commandBuilder.Append("   ,@ContentUnit ");
            commandBuilder.Append("   ,@Unit ");
            commandBuilder.Append("   ,@TradeName ");
            commandBuilder.Append("   ,@Description ");
            commandBuilder.Append("   ,@CreatedDate ");
            commandBuilder.Append("   ,@CreatedBy ");
            commandBuilder.Append("   ,@LastUpdatedDate ");
            commandBuilder.Append("   ,@LastUpdatedBy ");
            commandBuilder.Append("   ,@Version) ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            sqlCommand.Parameters.Add("@type", SqlDbType.Bit, 1, "Type");
            sqlCommand.Parameters.Add("@name", SqlDbType.VarChar, 200, "Name");
            sqlCommand.Parameters.Add("@content", SqlDbType.Int, 4, "Content");
            sqlCommand.Parameters.Add("@contentUnit", SqlDbType.Int, 4, "ContentUnit");
            sqlCommand.Parameters.Add("@unit", SqlDbType.Int, 4, "Unit");
            sqlCommand.Parameters.Add("@tradeName", SqlDbType.NVarChar, 200, "TradeName");
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, 400, "Description");
            sqlCommand.Parameters.Add("@createdDate", SqlDbType.DateTime, 8, "CreatedDate");
            sqlCommand.Parameters.Add("@createdBy", SqlDbType.Int, 4, "CreatedBy");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            sqlCommand.Parameters.Add("@lastUpdatedBy", SqlDbType.Int, 4, "LastUpdatedBy");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            return sqlCommand;
        }
    }
}
