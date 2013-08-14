using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Server.Sync
{
    public class MedicineDeliveryDetailAdapter : AdapterBase
    {
        public MedicineDeliveryDetailAdapter(SqlConnection connection) : base(connection)
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
                    if (!row["Id"].Equals(orgRow["Id"]) || row["MedicineDeliveryId"].Equals(orgRow["MedicineDeliveryId"])) continue;
                    orgRow["PrescriptionDetailId"] = row["PrescriptionDetailId"];
                    orgRow["MedicineId"] = row["MedicineId"];
                    orgRow["Volumn"] = row["Volumn"];
                    orgRow["Unit"] = row["Unit"];
                    orgRow["LastUpdatedDate"] = row["LastUpdatedDate"];
                    orgRow["Version"] = row["Version"];
                    isExist = true;
                    Console.WriteLine("Update row Id: " + row["Id"]);
                    break;
                }

                if (isExist) continue;
                DataRow newRow = original.NewRow();
                newRow["ClinicId"] = clinicId;
                newRow["Id"] = row["Id"];
                newRow["MedicineDeliveryId"] = row["MedicineDeliveryId"];
                newRow["PrescriptionDetailId"] = row["PrescriptionDetailId"];
                newRow["MedicineId"] = row["MedicineId"];
                newRow["Volumn"] = row["Volumn"];
                newRow["Unit"] = row["Unit"];
                newRow["LastUpdatedDate"] = row["LastUpdatedDate"];
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
            String commandBuilder = String.Format("Select * from MedicineDeliveryDetail Where Id in ({0}) And ClinicId = @clinicId", idString);
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
            commandBuilder.Append(" UPDATE MedicineDeliveryDetail ");
            commandBuilder.Append(" SET ");
            commandBuilder.Append("  PrescriptionDetailId = @prescriptionDetailId ");
            commandBuilder.Append("  ,MedicineId = @medicineId ");
            commandBuilder.Append("  ,Volumn = @volumn ");
            commandBuilder.Append("  ,Unit = @unit ");
            commandBuilder.Append("  ,LastUpdatedDate = @lastUpdatedDate ");
            commandBuilder.Append("  ,Version = @version ");
            commandBuilder.Append(" WHERE ClinicId = @clinicId AND ");
            commandBuilder.Append("  Id = @id AND ");
            commandBuilder.Append("  MedicineDeliveryId = @medicineDeliveryId  ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@prescriptionDetailId", SqlDbType.BigInt, 8, "PrescriptionDetailId");
            sqlCommand.Parameters.Add("@medicineId", SqlDbType.Int, 4, "MedicineId");
            sqlCommand.Parameters.Add("@volumn", SqlDbType.Int, 4, "Volumn");
            sqlCommand.Parameters.Add("@unit", SqlDbType.Int, 4, "Unit");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            // Add key
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.BigInt, 8, "Id") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@clinicId", SqlDbType.Int, 4, "ClinicId") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@medicineDeliveryId", SqlDbType.BigInt, 8, "MedicineDeliveryId") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }

        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from Patient Where Id = @id and ClinicId = @clinicId AND MedicineDeliveryId = @medicineDeliveryId", connection);
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.BigInt, 8, "Id") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@clinicId", SqlDbType.Int, 4, "ClinicId") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@medicineDeliveryId", SqlDbType.BigInt, 8, "MedicineDeliveryId") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }

        protected override SqlCommand CreateInsertCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" INSERT INTO MedicineDeliveryDetail ");
            commandBuilder.Append("   (ClinicId ");
            commandBuilder.Append("   ,Id ");
            commandBuilder.Append("   ,MedicineDeliveryId ");
            commandBuilder.Append("   ,PrescriptionDetailId ");
            commandBuilder.Append("   ,MedicineId ");
            commandBuilder.Append("   ,Volumn ");
            commandBuilder.Append("   ,Unit ");
            commandBuilder.Append("   ,LastUpdatedDate ");
            commandBuilder.Append("   ,Version) ");
            commandBuilder.Append("  VALUES ");
            commandBuilder.Append("   (@clinicId ");
            commandBuilder.Append("   ,@id ");
            commandBuilder.Append("   ,@medicineDeliveryId ");
            commandBuilder.Append("   ,@prescriptionDetailId ");
            commandBuilder.Append("   ,@medicineId ");
            commandBuilder.Append("   ,@volumn ");
            commandBuilder.Append("   ,@unit ");
            commandBuilder.Append("   ,@lastUpdatedDate ");
            commandBuilder.Append("   ,@version) ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@clinicId", SqlDbType.Int, 4, "ClinicId");
            sqlCommand.Parameters.Add("@id", SqlDbType.BigInt, 8, "Id");
            sqlCommand.Parameters.Add("@medicineDeliveryId", SqlDbType.BigInt, 8, "MedicineDeliveryId");
            sqlCommand.Parameters.Add("@prescriptionDetailId", SqlDbType.BigInt, 8, "PrescriptionDetailId");
            sqlCommand.Parameters.Add("@medicineId", SqlDbType.Int, 4, "MedicineId");
            sqlCommand.Parameters.Add("@volumn", SqlDbType.Int, 4, "Volumn");
            sqlCommand.Parameters.Add("@unit", SqlDbType.Int, 4, "Unit");
            sqlCommand.Parameters.Add("@lastUpdatedDate", SqlDbType.DateTime, 8, "LastUpdatedDate");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            return sqlCommand;

            
        }
    }
}
