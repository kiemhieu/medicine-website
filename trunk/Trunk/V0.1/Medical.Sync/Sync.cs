using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medical.Sync.ClientAdapter;
using Medical.Sync.SyncService;
using Medical.Sync.TableAdapter;

namespace Medical.Sync
{
    public class Sync
    {
        public void DoSyncMaster()
        {
            Console.WriteLine("Get data from server");
            SyncSoap sync = new SyncSoapClient();
            DataSet dataset = sync.GetMasterData();

            Console.WriteLine("Create connection");
            SqlConnection connection = new SqlConnection(GetConnectionString());

            Console.WriteLine("Start sync");
            DefineAdapter adapter = new DefineAdapter(connection);
            adapter.Sync(dataset.Tables[0]);

            MedicineAdapter medicineAdater = new MedicineAdapter(connection);
            medicineAdater.Sync(dataset.Tables[1]);

            FigureAdapter figureAdapter = new FigureAdapter(connection);
            figureAdapter.Sync(dataset.Tables[2]);

            FigureDetailAdapter figureDetailAdapter = new FigureDetailAdapter(connection);
            figureDetailAdapter.Sync(dataset.Tables[3]);

            Console.WriteLine("Completed");
        }

        public void DoSyncData()
        {

        }

        private String GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MedicalContext"].ConnectionString;
        }

        public String Test()
        {
            SyncSoap sync = new SyncSoapClient();
            return sync.GetConnectionString();
        }

        public DataTable GetSyncTable(String key)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            ClientAdapterBase clientAdapter;
            SyncSoap syncObject = new SyncSoapClient();
            switch (key)
            {
                case "Patient" :
                    clientAdapter = new PatienAdapter(connection);
                    int counting = 0;
                    do
                    {
                        DataTable table = clientAdapter.GetData("Patient", 100, out counting);
                        DataSet ds = new DataSet();
                        ds.Tables.Add(table);
                        String message = String.Empty;
                        bool result = syncObject.SyncTable(out message, 12, ds);
                        if (result)
                        {
                            clientAdapter.Update(table);
                        }
                    } while (counting > 0);
                    break;
            }
            return null;
        }

        private DateTime? GetLastTimeSync(String key)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand selectCommand = new SqlCommand("Select * from TableSyncTime Where Name = @name");
            SqlParameter parameter = new SqlParameter("@name", SqlDbType.VarChar, 50) {Value = key};
            selectCommand.Parameters.Add(parameter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count == 0) return null;
            if (table.Rows[0]["LastSync"] == DBNull.Value) return null;
            return Convert.ToDateTime(table.Rows[0]["LastSync"]);
        }
    }
}
