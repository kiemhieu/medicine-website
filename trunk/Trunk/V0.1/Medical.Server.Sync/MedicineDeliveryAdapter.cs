using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Server.Sync
{
    public class MedicineDeliveryAdapter : AdapterBase
    {
        public MedicineDeliveryAdapter(SqlConnection connection) : base(connection)
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
                    orgRow["ClinicId"] = row["ClinicId"];
                    orgRow["PatientId"] = row["PatientId"];
                    orgRow["PrescriptionId"] = row["PrescriptionId"]; 
                    orgRow["Date"] = row["Date"];
                    orgRow["CreatedDate"] = row["CreatedDate"];
                    orgRow["CreatedUser"] = row["CreatedUser"];
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
                newRow["ClinicId"] = row["ClinicId"];
                newRow["PatientId"] = row["PatientId"];
                newRow["PrescriptionId"] = row["PrescriptionId"]; 
                newRow["Date"] = row["Date"];
                newRow["CreatedDate"] = row["CreatedDate"];
                newRow["CreatedUser"] = row["CreatedUser"];
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
            Console.WriteLine("UPDATE OK");
        }

        protected override SqlCommand CreateSelectCommand(SqlConnection connection, int clinicId, List<int> ids)
        {
            String idString = "0";
            if (ids != null && ids.Count > 0)
            {
                idString = String.Join(",", ids);
            }
            String commandBuilder = String.Format("Select * from MedicineDelivery Where Id in ({0}) And ClinicId = @clinicId", idString);
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
            commandBuilder.Append(" UPDATE MedicineDelivery ");
            commandBuilder.Append(" SET ");
            commandBuilder.Append("  PatientId = @patientId ");
            commandBuilder.Append("  ,PrescriptionId = @prescriptionId ");
            commandBuilder.Append("  ,Date = @date ");
            commandBuilder.Append("  ,CreatedDate = @createdDate ");
            commandBuilder.Append("  ,CreatedUser = @createdUser ");
            commandBuilder.Append("  ,LastUpdatedDate = @lastUpdatedDate ");
            commandBuilder.Append("  ,LastUpdatedUser = @lastUpdatedUser ");
            commandBuilder.Append("  ,Version = @version ");
            commandBuilder.Append(" WHERE Id = @id AND ClinicId = @clinicId  ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@patientId", SqlDbType.Int, 4, "PatientId");
            sqlCommand.Parameters.Add("@prescriptionId", SqlDbType.BigInt, 8, "PrescriptionId");
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime, 8, "Date");
            sqlCommand.Parameters.Add("@createdDate", SqlDbType.DateTime, 8, "CreatedDate");
            sqlCommand.Parameters.Add("@createdUser", SqlDbType.Int, 4, "CreatedUser");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            sqlCommand.Parameters.Add("@lastUpdatedUser", SqlDbType.Int, 4, "LastUpdatedUser");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            // Add key
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.BigInt, 8, "Id") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@clinicId", SqlDbType.Int, 4, "ClinicId") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }

        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from Patient Where Id = @id and ClinicId = @clinicId", connection);
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.BigInt, 8, "Id") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@clinicId", SqlDbType.Int, 4, "ClinicId") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }

        protected override SqlCommand CreateInsertCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" INSERT INTO MedicineDelivery ");
            commandBuilder.Append("   (Id ");
            commandBuilder.Append("   ,ClinicId ");
            commandBuilder.Append("   ,PatientId ");
            commandBuilder.Append("   ,PrescriptionId ");
            commandBuilder.Append("   ,Date ");
            commandBuilder.Append("   ,CreatedDate ");
            commandBuilder.Append("   ,CreatedUser ");
            commandBuilder.Append("   ,LastUpdatedDate ");
            commandBuilder.Append("   ,LastUpdatedUser ");
            commandBuilder.Append("   ,Version) ");
            commandBuilder.Append("  VALUES ");
            commandBuilder.Append("   (@id ");
            commandBuilder.Append("   ,@clinicId ");
            commandBuilder.Append("   ,@patientId ");
            commandBuilder.Append("   ,@prescriptionId ");
            commandBuilder.Append("   ,@date ");
            commandBuilder.Append("   ,@createdDate ");
            commandBuilder.Append("   ,@createdUser ");
            commandBuilder.Append("   ,@lastUpdatedDate ");
            commandBuilder.Append("   ,@lastUpdatedUser ");
            commandBuilder.Append("   ,@version) ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@id", SqlDbType.BigInt, 8, "Id");
            sqlCommand.Parameters.Add("@clinicId", SqlDbType.Int, 4, "ClinicId");
            sqlCommand.Parameters.Add("@patientId", SqlDbType.Int, 4, "PatientId");
            sqlCommand.Parameters.Add("@prescriptionId", SqlDbType.BigInt, 8, "PrescriptionId");
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime, 8, "Date");
            sqlCommand.Parameters.Add("@createdDate", SqlDbType.DateTime, 8, "CreatedDate");
            sqlCommand.Parameters.Add("@createdUser", SqlDbType.Int, 4, "CreatedUser");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            sqlCommand.Parameters.Add("@lastUpdatedUser", SqlDbType.Int, 4, "LastUpdatedUser");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            return sqlCommand;
        }
    }
}
