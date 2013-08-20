using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using Medical.Server.Sync;

namespace Server
{
    /// <summary>
    /// Summary description for Sync
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Sync : WebService
    {
        private const String ConnectionStringName = "DefaultConnection";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataSet GetMasterData()
        {
            String[] tables = new string[] { "Define", "Medicine","Figure", "FigureDetail", "MedicinePlan"};
            DataSet dataset = new DataSet("Tables");
            SqlConnection connection = new SqlConnection(GetConnectionString());

            foreach (var table in tables)
            {
                String sql = String.Format("Select * from {0}", table);
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable(table);
                adapter.Fill(dt);
                dataset.Tables.Add(dt);
            }
            return dataset;
        }

        [WebMethod]
        public bool SyncTable(int clinicId, DataSet dataset, out String message)
        {
            message = String.Empty;
            DataTable dt = dataset.Tables[0];
            String key = dt.TableName;
            try
            {
                AdapterBase adapter = CreateAdapter(key);
                adapter.Sync(clinicId, dt);
                return true;
            }
            catch(Exception ex)
            {
                message = BuildExceptionMessage(ex);
                return false;
            }
        }

        [WebMethod]
        public bool TestConnection()
        {
            return true;
        }

        [WebMethod]
        public bool Remove(int clinicId, DataSet ds, out String message)
        {
            try
            {
                var dt = ds.Tables[0];
                String key = dt.TableName;
                message = String.Empty;

                List<int> ids = new List<int>();
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    ids.Add(id);
                }
                var adapter = CreateAdapter(key);
                adapter.Remove(clinicId, ids);
                return true;
            }
            catch (Exception ex)
            {
                message = BuildExceptionMessage(ex);
                return false;
            }
        }

        /// <summary>
        /// Creates the adapter.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private AdapterBase CreateAdapter(String key)
        {
            var connection = new SqlConnection(GetConnectionString());
            switch (key)
            {
                case "Patient":
                    return new PatientAdapter(connection);
                case "MedicineDelivery":
                    return new MedicineDeliveryAdapter(connection);
                case "MedicineDeliveryDetail":
                    return new MedicineDeliveryDetailAdapter(connection);
                case "MedicinePlan":
                    return new MedicinePlanAdapter(connection);
                case "MedicinePlanDetail":
                    return new MedicinePlanDetailAdapter(connection);
                case "WareHouse":
                    return new WareHouseAdapter(connection);
                case "WareHouseIO":
                    return new WareHouseIOAdapter(connection);
                case "WareHouseIODetail":
                    return new WareHouseIODetailAdapter(connection);
            }
            return null;
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns></returns>
        private String GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }

        /// <summary>
        /// Exceptions the builder.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        private String BuildExceptionMessage(Exception ex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(ex.Message);
            builder.Append(ex.Source);
            builder.Append(ex.StackTrace);

            Exception exx = ex.InnerException;
            while (exx != null)
            {
                builder.Append(exx.Message);
                builder.Append(exx.Source);
                builder.Append(exx.StackTrace);
                exx = exx.InnerException;
            }

            return builder.ToString();
        }

    }
}
