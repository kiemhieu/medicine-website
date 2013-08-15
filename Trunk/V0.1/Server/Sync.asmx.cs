using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        private String GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }

        [WebMethod]
        public DataSet GetMasterData()
        {
            String[] tables = new string[] { "Define", "Medicine","Figure", "FigureDetail"};
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
            String connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            message = String.Empty;
            DataTable dt = dataset.Tables[0];
            String tableName = dt.TableName;
            switch (tableName)
            {
                case "Patient" :
                    SqlConnection connection = new SqlConnection(connectionString);
                    PatientAdapter patientAdapter = new PatientAdapter(connection);
                    patientAdapter.Sync(clinicId, dt);
                    break;
                default:
                    break;

            }
            return true;
        }

        [WebMethod]
        public bool TestConnection()
        {
            return true;
        }

        [WebMethod]
        public bool Remove(int clinicId, DataSet ds, out String message)
        {
            DataTable dt = ds.Tables[0];
            Dictionary<String, List<int>> table = new Dictionary<string, List<int>>();
            foreach (DataRow row in dt.Rows)
            {
                String key = Convert.ToString(row["TableName"]);
                List<int> ids = table[key];
                if (ids == null)
                {
                    ids = new List<int> {Convert.ToInt32(row["Id"])};
                    table.Add(key, ids);
                }
                else
                {
                    ids.Add(Convert.ToInt32(row["Id"]));
                }
            }
            return true;
        }

        private bool Remove(int clinicId, String key, List<int> ids)
        {
            AdapterBase adapter;
            SqlConnection connection = new SqlConnection(GetConnectionString());
            switch (key)
            {
                case "Patient" :
                    adapter = new PatientAdapter(connection);
                case "":
            }
        }


    }
}
