using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.TableAdapter
{
    public class MedicinePlanAdapter : AdapterBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicinePlanAdapter"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public MedicinePlanAdapter(SqlConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Syncs the specified data table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Sync(DataTable dataTable)
        {
            // SqlConnection connection = new SqlConnection("");
            SqlDataAdapter adapter = BuildAdapter();
            DataTable original = new DataTable();
            adapter.Fill(original);

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataRow orgRow in original.Rows)
                {
                    if (!row["Id"].Equals(orgRow["Id"]) && Convert.ToInt32(row["Version"]) <= Convert.ToInt32(orgRow["Version"])) continue;
                    orgRow["Version"] = row["Version"];
                    orgRow["Status"] = row["Status"];
                    Console.WriteLine("Update row Id: " + row["Id"]);
                    break;
                }
            }

            adapter.Update(original);
        }

        /// <summary>
        /// Creates the select command.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected override SqlCommand CreateSelectCommand(SqlConnection connection)
        {
            return new SqlCommand("Select * from MedicinePlan", connection);
        }

        /// <summary>
        /// Creates the update command.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected override SqlCommand CreateUpdateCommand(SqlConnection connection)
        {
            var sqlCommand = new SqlCommand("Update MedicinePlan Set Status = @status Where Id = @id", connection);

            // Add parameter
            sqlCommand.Parameters.Add("@status", SqlDbType.Int, 4, "Status");

            // Add key
            var parameter = new SqlParameter("@id", SqlDbType.Int, 4, "Id") { SourceVersion = DataRowVersion.Original };
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        /// <summary>
        /// Creates the delete command.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override SqlCommand CreateDeleteCommand(SqlConnection connection)
        {
            return null;
        }

        /// <summary>
        /// Creates the insert command.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override SqlCommand CreateInsertCommand(SqlConnection connection)
        {
            return null;
        }
    }
}
