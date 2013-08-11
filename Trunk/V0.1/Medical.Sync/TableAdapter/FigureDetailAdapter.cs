using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.TableAdapter
{
    public class FigureDetailAdapter : AdapterBase
    {
        public FigureDetailAdapter(SqlConnection connection) : base(connection)
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
                    orgRow["FigureId"] = row["FigureId"];
                    orgRow["MedicineId"] = row["MedicineId"];
                    orgRow["Volumn"] = row["Volumn"];
                    orgRow["Version"] = row["Version"];
                    isExist = true;
                    Console.WriteLine("Update row Id: " + row["Id"]);
                    break;
                }

                if (isExist) continue;
                DataRow newRow = original.NewRow();
                newRow["Id"] = row["Id"];
                newRow["FigureId"] = row["FigureId"];
                newRow["MedicineId"] = row["MedicineId"];
                newRow["Volumn"] = row["Volumn"];
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
            return new SqlCommand("Select * from FigureDetail", connection);
        }

        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" UPDATE FigureDetail ");
            commandBuilder.Append(" SET ");
            commandBuilder.Append("  FigureId = @figureId ");
            commandBuilder.Append("  ,MedicineId = @medicineId ");
            commandBuilder.Append("  ,Volumn = @volumn ");
            commandBuilder.Append("  ,Version = @version ");
            commandBuilder.Append(" WHERE Id = @id");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@figureId", SqlDbType.Int, 4, "FigureId");
            sqlCommand.Parameters.Add("@medicineId", SqlDbType.Int, 4, "MedicineId");
            sqlCommand.Parameters.Add("@volumn", SqlDbType.Int, 4, "Volumn");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            // Add key
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original };
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from FigureDetail Where Id = @id", connection);
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original };
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        protected override SqlCommand CreateInsertCommand(SqlConnection connection)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append(" INSERT INTO FigureDetail ");
            commandBuilder.Append("   (Id ");
            commandBuilder.Append("   ,FigureId ");
            commandBuilder.Append("   ,MedicineId ");
            commandBuilder.Append("   ,Volumn ");
            commandBuilder.Append("   ,Version) ");
            commandBuilder.Append("  VALUES ");
            commandBuilder.Append("   (@id ");
            commandBuilder.Append("   ,@figureId ");
            commandBuilder.Append("   ,@medicineId ");
            commandBuilder.Append("   ,@volumn ");
            commandBuilder.Append("   ,@version) ");

            SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), connection);

            // Add parameter
            sqlCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            sqlCommand.Parameters.Add("@figureId", SqlDbType.Int, 4, "FigureId");
            sqlCommand.Parameters.Add("@medicineId", SqlDbType.Int, 4, "MedicineId");
            sqlCommand.Parameters.Add("@volumn", SqlDbType.Int, 4, "Volumn");
            sqlCommand.Parameters.Add("@version", SqlDbType.Int, 4, "Version");

            return sqlCommand;
        }
    }
}
