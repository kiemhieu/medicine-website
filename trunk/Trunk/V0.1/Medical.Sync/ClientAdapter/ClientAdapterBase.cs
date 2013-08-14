using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.ClientAdapter
{
    public abstract class  ClientAdapterBase
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;

        protected ClientAdapterBase(SqlConnection connection)
        {
            this.connection = connection;
            this.adapter = BuildAdapter();
        }

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
                UpdateCommand = CreateUpdateCommand(connection),
            };
            return adapter;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="maxRow">The max row.</param>
        /// <param name="counting">The counting.</param>
        /// <returns></returns>
        public DataTable GetData(String keyName, int maxRow, out int counting)
        {
            DataTable dataTable = new DataTable(keyName);
            counting = maxRow <= 0 ? this.adapter.Fill(dataTable) : this.adapter.Fill(0, maxRow, new DataTable[] { dataTable });
            if (counting > 0) UpdateSyncTime(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Updates the sync time.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public void UpdateSyncTime(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                dataRow["LastSync"] = DateTime.Now;
                dataRow.SetModified();
            }
        }

        /// <summary>
        /// Writes the data base.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public void Update(DataTable dataTable)
        {
            this.adapter.Update(dataTable);
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

    }
}
