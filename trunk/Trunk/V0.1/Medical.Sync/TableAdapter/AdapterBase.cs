using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.TableAdapter
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
        /// Builds the adapter.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
        protected SqlDataAdapter BuildAdapter()
        {
            SqlDataAdapter adapter = new SqlDataAdapter
                                         {
                                             SelectCommand = CreateSelectCommand(connection),
                                             InsertCommand = CreateInsertCommand(connection),
                                             UpdateCommand = CreateUpdateCommand(connection),
                                             DeleteCommand = CreateDeleteCommand(connection)
                                         };
            return adapter;
        }

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
