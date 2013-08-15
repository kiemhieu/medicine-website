using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Server.Sync
{
    public class WareHouseIOAdapter : AdapterBase
    {
        public WareHouseIOAdapter(SqlConnection connection) : base(connection)
        {
        }

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
                    orgRow["Type"] = row["Type"];
                    orgRow["Date"] = row["Date"];
                    orgRow["No"] = row["No"];
                    orgRow["Person"] = row["Person"];
                    orgRow["Phone"] = row["Phone"];
                    orgRow["Address"] = row["Address"];
                    orgRow["Note"] = row["Note"];
                    orgRow["AttachmentNo"] = row["AttachmentNo"];
                    orgRow["CreatedUser"] = row["CreatedUser"];
                    orgRow["CreatedDate"] = row["CreatedDate"];
                    orgRow["Version"] = row["Version"];
                    isExist = true;
                    Console.WriteLine("Update row Id: " + row["Id"]);
                    break;
                }

                if (isExist) continue;
                DataRow newRow = original.NewRow();
                newRow["Id"] = row["Id"];
                newRow["Type"] = row["Type"];
                newRow["ClinicId"] = row["ClinicId"];
                newRow["Date"] = row["Date"];
                newRow["No"] = row["No"];
                newRow["Person"] = row["Person"];
                newRow["Phone"] = row["Phone"];
                newRow["Address"] = row["Address"];
                newRow["Note"] = row["Note"];
                newRow["AttachmentNo"] = row["AttachmentNo"];
                newRow["CreatedUser"] = row["CreatedUser"];
                newRow["CreatedDate"] = row["CreatedDate"];
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

        protected override SqlCommand CreateSelectCommand(SqlConnection connection, int clinicId, List<int> ids)
        {
            String idString = "0";
            if (ids != null && ids.Count > 0)
            {
                idString = String.Join(",", ids);
            }
            String commandBuilder = String.Format("Select * from WareHouseIO Where Id in ({0}) And ClinicId = @clinicId", idString);
            SqlCommand sqlCommand = new SqlCommand(commandBuilder, connection);
            SqlParameter parameter = new SqlParameter("@clinicId", SqlDbType.Int, 4) { Value = clinicId };
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" UPDATE WareHouseIO ");
            commandBuilder.Append(" SET ");
            commandBuilder.Append("  Type = @type ");
            commandBuilder.Append("  ,Date = @date ");
            commandBuilder.Append("  ,No = @no ");
            commandBuilder.Append("  ,Person = @person ");
            commandBuilder.Append("  ,Phone = @phone ");
            commandBuilder.Append("  ,Address = @address ");
            commandBuilder.Append("  ,Note = @note ");
            commandBuilder.Append("  ,AttachmentNo = @attachmentNo ");
            commandBuilder.Append("  ,CreatedUser = @createdUser ");
            commandBuilder.Append("  ,CreatedDate = @createdDate ");
            commandBuilder.Append("  ,Version = @version ");
            commandBuilder.Append(" WHERE Id = @id AND ClinicId = @clinicId ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@type", SqlDbType.Char, 1, "Type");
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime, 8, "Date");
            sqlCommand.Parameters.Add("@no", SqlDbType.VarChar, 20, "No");
            sqlCommand.Parameters.Add("@person", SqlDbType.NVarChar, 100, "Person");
            sqlCommand.Parameters.Add("@phone", SqlDbType.VarChar, 20, "Phone");
            sqlCommand.Parameters.Add("@address", SqlDbType.VarChar, 120, "Address");
            sqlCommand.Parameters.Add("@note", SqlDbType.NVarChar, 250, "Note");
            sqlCommand.Parameters.Add("@attachmentNo", SqlDbType.NVarChar, 50, "AttachmentNo");
            sqlCommand.Parameters.Add("@createdUser", SqlDbType.Int, 4, "CreatedUser");
            sqlCommand.Parameters.Add("@createdDate", SqlDbType.DateTime, 8, "CreatedDate");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            // Add key
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@clinicId", SqlDbType.Int, 4, "ClinicId") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }

        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from WareHouseIO Where Id = @id and ClinicId = @clinicId", connection);
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@clinicId", SqlDbType.Int, 4, "ClinicId") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }

        protected override SqlCommand CreateInsertCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" INSERT INTO WareHouseIO ");
            commandBuilder.Append("   (Id ");
            commandBuilder.Append("   ,Type ");
            commandBuilder.Append("   ,ClinicId ");
            commandBuilder.Append("   ,Date ");
            commandBuilder.Append("   ,No ");
            commandBuilder.Append("   ,Person ");
            commandBuilder.Append("   ,Phone ");
            commandBuilder.Append("   ,Address ");
            commandBuilder.Append("   ,Note ");
            commandBuilder.Append("   ,AttachmentNo ");
            commandBuilder.Append("   ,CreatedUser ");
            commandBuilder.Append("   ,CreatedDate ");
            commandBuilder.Append("   ,Version) ");
            commandBuilder.Append("  VALUES ");
            commandBuilder.Append("   (@id ");
            commandBuilder.Append("   ,@type ");
            commandBuilder.Append("   ,@clinicId ");
            commandBuilder.Append("   ,@date ");
            commandBuilder.Append("   ,@no ");
            commandBuilder.Append("   ,@person ");
            commandBuilder.Append("   ,@phone ");
            commandBuilder.Append("   ,@address ");
            commandBuilder.Append("   ,@note ");
            commandBuilder.Append("   ,@attachmentNo ");
            commandBuilder.Append("   ,@createdUser ");
            commandBuilder.Append("   ,@createdDate ");
            commandBuilder.Append("   ,@version) ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            sqlCommand.Parameters.Add("@type", SqlDbType.Char, 1, "Type");
            sqlCommand.Parameters.Add("@clinicId", SqlDbType.Int, 4, "ClinicId");
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime, 8, "Date");
            sqlCommand.Parameters.Add("@no", SqlDbType.VarChar, 20, "No");
            sqlCommand.Parameters.Add("@person", SqlDbType.NVarChar, 100, "Person");
            sqlCommand.Parameters.Add("@phone", SqlDbType.VarChar, 20, "Phone");
            sqlCommand.Parameters.Add("@address", SqlDbType.VarChar, 120, "Address");
            sqlCommand.Parameters.Add("@note", SqlDbType.NVarChar, 250, "Note");
            sqlCommand.Parameters.Add("@attachmentNo", SqlDbType.NVarChar, 50, "AttachmentNo");
            sqlCommand.Parameters.Add("@createdUser", SqlDbType.Int, 4, "CreatedUser");
            sqlCommand.Parameters.Add("@createdDate", SqlDbType.DateTime, 8, "CreatedDate");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            return sqlCommand;
        }
    }
}
