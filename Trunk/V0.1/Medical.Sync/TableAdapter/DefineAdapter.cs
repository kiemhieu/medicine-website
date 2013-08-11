using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.TableAdapter
{
    public class DefineAdapter : AdapterBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefineAdapter"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public DefineAdapter(SqlConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Syncs the specified define.
        /// </summary>
        /// <param name="define">The define.</param>
        public override void Sync(DataTable define)
        {
            // SqlConnection connection = new SqlConnection("");
            SqlDataAdapter adapter = BuildAdapter();
            DataTable original = new DataTable();
            adapter.Fill(original);

            List<int> updatedId = new List<int>();
            foreach (DataRow row in define.Rows)
            {
                bool isExist = false;
                updatedId.Add(Convert.ToInt32(row["Id"]));
                foreach (DataRow orgRow in original.Rows)
                {
                    if (!row["Id"].Equals(orgRow["Id"])) continue;
                    orgRow["GroupId"] = row["GroupId"];
                    orgRow["Name"] = row["Name"];
                    orgRow["Description"] = row["Description"];
                    isExist = true;
                    Console.WriteLine("Update row Id: " + row["Id"]);
                    break;
                }

                if (isExist) continue;
                DataRow newRow = original.NewRow();
                newRow["Id"] = row["Id"];
                newRow["GroupId"] = row["GroupId"];
                newRow["Name"] = row["Name"];
                newRow["Description"] = row["Description"];
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

        /// <summary>
        /// Creates the select command.
        /// </summary>
        /// <returns></returns>
        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            return new SqlCommand("Select * from Define", connection);
        }

        /// <summary>
        /// Creates the update command.
        /// </summary>
        /// <returns></returns>
        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Update Define Set GroupId = @groupId, Name = @name, Description = @description Where Id = @id", connection);

            // Add parameter
            sqlCommand.Parameters.Add("@groupId", SqlDbType.Int, 4, "GroupId");
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50, "Name");
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, 100, "Description");

            // Add key
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int, 4, "Id") {SourceVersion = DataRowVersion.Original};
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        /// <summary>
        /// Creates the delete command.
        /// </summary>
        /// <returns></returns>
        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from Define Where Id = @id", connection);
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original };
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        /// <summary>
        /// Creates the insert command.
        /// </summary>
        /// <returns></returns>
        protected override SqlCommand CreateInsertCommand(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("Insert into Define (Id, GroupId, Name, Description) Values (@id, @groupId, @name, @description)", connection);

            // Add parameter
            sqlCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            sqlCommand.Parameters.Add("@groupId", SqlDbType.Int, 4, "GroupId");
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50, "Name");
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, 100, "Description");
            return sqlCommand;
        }
    }
}
