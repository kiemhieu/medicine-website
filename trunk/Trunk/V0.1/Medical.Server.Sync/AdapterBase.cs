using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Medical.Server.Sync
{
    public abstract class AdapterBase
    {
        private SqlConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterBase"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        protected AdapterBase(SqlConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Syncs the specified data table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public abstract void Sync(DataTable dataTable);

        /// <summary>
        /// Removes the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void Remove(List<int> list)
        {
            SqlDataAdapter adapter = this.BuildAdapter(list);
            DataTable removedTable = new DataTable("removed");
            adapter.Fill(removedTable);
            if (removedTable.Rows == null || removedTable.Rows.Count == 0) return;
            foreach (DataRow row in removedTable.Rows)
            {
                row.Delete();
            }
            adapter.Update(removedTable);
        }

        /// <summary>
        /// Builds the adapter.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
        protected SqlDataAdapter BuildAdapter(List<int> list)
        {

            SqlDataAdapter adapter = new SqlDataAdapter
                                         {
                                             SelectCommand = CreateSelectCommand(connection, list),
                                             InsertCommand = CreateInsertCommand(connection),
                                             UpdateCommand = CreateUpdateCommand(connection),
                                             DeleteCommand = CreateDeleteCommand(connection)
                                         };
            return adapter;
        }

        /// <summary>
        /// Creates the select command.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        protected abstract SqlCommand CreateSelectCommand(SqlConnection connection, List<int> ids);


        /// <summary>
        /// Creates the select command.
        /// </summary>
        /// <returns></returns>
        protected abstract SqlCommand CreateSelectCommand(SqlConnection connection);

        /// <summary>
        /// Creates the update command.
        /// </summary>
        /// <returns></returns>
        protected abstract SqlCommand CreateUpdateCommand(SqlConnection connection);

        /// <summary>
        /// Creates the delete command.
        /// </summary>
        /// <returns></returns>
        protected abstract SqlCommand CreateDeleteCommand(SqlConnection connection);


        /// <summary>
        /// Creates the insert command.
        /// </summary>
        /// <returns></returns>
        protected abstract SqlCommand CreateInsertCommand(SqlConnection connection);

    }
}
