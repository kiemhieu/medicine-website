using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

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
        public String GetConnectionString()
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

    }
}
