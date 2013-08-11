using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private String GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MedicalContext"].ConnectionString;
        }

        public String Test()
        {
            SyncSoap sync = new SyncSoapClient();
            return sync.GetConnectionString();
        }
}
}
