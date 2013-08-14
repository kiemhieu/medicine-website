using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Server.Sync
{
    public class WareHouseIODetailAdapter : AdapterBase
    {
        public WareHouseIODetailAdapter(SqlConnection connection) : base(connection)
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
                    orgRow["WareHouseIOId"] = row["WareHouseIOId"];
                    orgRow["MedicineId"] = row["MedicineId"];
                    orgRow["LotNo"] = row["LotNo"];
                    orgRow["ExpireDate"] = row["ExpireDate"];
                    orgRow["Qty"] = row["Qty"];
                    orgRow["UnitPrice"] = row["UnitPrice"];
                    orgRow["Unit"] = row["Unit"];
                    orgRow["Amount"] = row["Amount"];
                    orgRow["CreatedDate"] = row["CreatedDate"];
                    orgRow["Version"] = row["Version"];
                    orgRow["Type"] = row["Type"];
                    isExist = true;
                    Console.WriteLine("Update row Id: " + row["Id"]);
                    break;
                }

                if (isExist) continue;
                DataRow newRow = original.NewRow();
                newRow["Id"] = row["Id"];
                newRow["WareHouseIOId"] = row["WareHouseIOId"];
                newRow["ClinicId"] = clinicId;
                newRow["MedicineId"] = row["MedicineId"];
                newRow["LotNo"] = row["LotNo"];
                newRow["ExpireDate"] = row["ExpireDate"];
                newRow["Qty"] = row["Qty"];
                newRow["UnitPrice"] = row["UnitPrice"];
                newRow["Unit"] = row["Unit"];
                newRow["Amount"] = row["Amount"];
                newRow["CreatedDate"] = row["CreatedDate"];
                newRow["Version"] = row["Version"];
                newRow["Type"] = row["Type"];
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
            String commandBuilder = String.Format("Select * from WareHouseIODetail Where Id in ({0}) And ClinicId = @clinicId", idString);
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
            commandBuilder.Append(" UPDATE WareHouseIODetail ");
            commandBuilder.Append(" SET ");
            commandBuilder.Append("  MedicineId = @medicineId ");
            commandBuilder.Append("  ,LotNo = @lotNo ");
            commandBuilder.Append("  ,ExpireDate = @expireDate ");
            commandBuilder.Append("  ,Qty = @qty ");
            commandBuilder.Append("  ,UnitPrice = @unitPrice ");
            commandBuilder.Append("  ,Unit = @unit ");
            commandBuilder.Append("  ,Amount = @amount ");
            commandBuilder.Append("  ,CreatedDate = @createdDate ");
            commandBuilder.Append("  ,Version = @version ");
            commandBuilder.Append("  ,Type = @type ");
            commandBuilder.Append(" WHER Id = @id  AND WareHouseIOId = @wareHouseIOId AND ClinicId = @clinicId ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@medicineId", SqlDbType.Int, 4, "MedicineId");
            sqlCommand.Parameters.Add("@lotNo", SqlDbType.Char, 20, "LotNo");
            sqlCommand.Parameters.Add("@expireDate", SqlDbType.DateTime, 8, "ExpireDate");
            sqlCommand.Parameters.Add("@qty", SqlDbType.Int, 4, "Qty");
            sqlCommand.Parameters.Add("@unitPrice", SqlDbType.Int, 4, "UnitPrice");
            sqlCommand.Parameters.Add("@unit", SqlDbType.Int, 4, "Unit");
            sqlCommand.Parameters.Add("@amount", SqlDbType.Int, 4, "Amount");
            sqlCommand.Parameters.Add("@createdDate", SqlDbType.DateTime, 8, "CreatedDate");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");
            sqlCommand.Parameters.Add("@type", SqlDbType.NVarChar, 50, "Type");

            // Add key
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@clinicId", SqlDbType.Int, 4, "ClinicId") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@WareHouseIOId", SqlDbType.Int, 4, "WareHouseIOId") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }

        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from Patient Where Id = @id and ClinicId = @clinicId AND WareHouseIOId = wareHouseIOId", connection);
            sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@clinicId", SqlDbType.Int, 4, "ClinicId") { SourceVersion = DataRowVersion.Original });
            sqlCommand.Parameters.Add(new SqlParameter("@WareHouseIOId", SqlDbType.Int, 4, "WareHouseIOId") { SourceVersion = DataRowVersion.Original });
            return sqlCommand;
        }

        protected override SqlCommand CreateInsertCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" INSERT INTO MedicalServer.dbo.WareHouseIODetail ");
            commandBuilder.Append("   (Id ");
            commandBuilder.Append("   ,WareHouseIOId ");
            commandBuilder.Append("   ,ClinicId ");
            commandBuilder.Append("   ,MedicineId ");
            commandBuilder.Append("   ,LotNo ");
            commandBuilder.Append("   ,ExpireDate ");
            commandBuilder.Append("   ,Qty ");
            commandBuilder.Append("   ,UnitPrice ");
            commandBuilder.Append("   ,Unit ");
            commandBuilder.Append("   ,Amount ");
            commandBuilder.Append("   ,CreatedDate ");
            commandBuilder.Append("   ,Version ");
            commandBuilder.Append("   ,Type) ");
            commandBuilder.Append("  VALUES ");
            commandBuilder.Append("   (@id ");
            commandBuilder.Append("   ,@wareHouseIOId ");
            commandBuilder.Append("   ,@clinicId ");
            commandBuilder.Append("   ,@medicineId ");
            commandBuilder.Append("   ,@lotNo ");
            commandBuilder.Append("   ,@expireDate ");
            commandBuilder.Append("   ,@qty ");
            commandBuilder.Append("   ,@unitPrice ");
            commandBuilder.Append("   ,@unit ");
            commandBuilder.Append("   ,@amount ");
            commandBuilder.Append("   ,@createdDate ");
            commandBuilder.Append("   ,@version ");
            commandBuilder.Append("   ,@type) ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
           sqlCommand.Parameters.Add("@wareHouseIOId", SqlDbType.Int, 4, "WareHouseIOId");
           sqlCommand.Parameters.Add("@clinicId", SqlDbType.Int, 4, "ClinicId");
           sqlCommand.Parameters.Add("@medicineId", SqlDbType.Int, 4, "MedicineId");
           sqlCommand.Parameters.Add("@lotNo", SqlDbType.Char, 20, "LotNo");
           sqlCommand.Parameters.Add("@expireDate", SqlDbType.DateTime, 8, "ExpireDate");
           sqlCommand.Parameters.Add("@qty", SqlDbType.Int, 4, "Qty");
           sqlCommand.Parameters.Add("@unitPrice", SqlDbType.Int, 4, "UnitPrice");
           sqlCommand.Parameters.Add("@unit", SqlDbType.Int, 4, "Unit");
           sqlCommand.Parameters.Add("@amount", SqlDbType.Int, 4, "Amount");
           sqlCommand.Parameters.Add("@createdDate", SqlDbType.DateTime, 8, "CreatedDate");
           sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");
           sqlCommand.Parameters.Add("@type", SqlDbType.NVarChar, 50, "Type");

            return sqlCommand;
        }
    }
}
