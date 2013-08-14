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

        public void DoSync(int clinicId)
        {
            DoSync("Patient", clinicId);
            DoSync("MedicineDelivery", clinicId);
            DoSync("MedicineDeliveryDetail", clinicId);
            DoSync("MedicinePlan", clinicId);
            DoSync("MedicinePlanDetail", clinicId);
            DoSync("WareHouse", clinicId);
            DoSync("WareHouseIO", clinicId);
            DoSync("WareHouseIODetail", clinicId);
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

        /// <summary>
        /// Gets the sync table.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="clinicId">The clinic id.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable DoSync(String key, int clinicId)
        {
            ClientAdapterBase clientAdapter = CreateAdapter(key);
            SyncSoap syncObject = new SyncSoapClient();
            int counting = 0;
            do
            {
                var message = String.Empty;
                var ds = new DataSet();
                var table = clientAdapter.GetData("Patient", 100, out counting);
                ds.Tables.Add(table);
                var result = syncObject.SyncTable(out message, clinicId, ds);
                if (result) clientAdapter.Update(table);
                else
                    throw new Exception(message);
            } while (counting > 0);
            return null;
        }

        /// <summary>
        /// Creates the adapter.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private ClientAdapterBase CreateAdapter(String key)
        {
            var connection = new SqlConnection(GetConnectionString());
            switch (key)
            {
                case "Patient":
                    return  new PatienAdapter(connection);
                case "MedicineDelivery":
                    return new MedicineDeliveryClientAdapter(connection);
                case "MedicineDeliveryDetail":
                    return new MedicineDeliveryDetailClientAdapter(connection);
                case "MedicinePlan":
                    return new MedicinePlanClientAdapter(connection);
                case "MedicinePlanDetail":
                    return new MedicinePlanDetailClientAdapter(connection);
                case "WareHouse":
                    return new WareHouseClientAdapter(connection);
                case "WareHouseIO":
                    return new WareHouseIOClientAdapter(connection);
                case "WareHouseIODetail":
                    return new WareHouseIODetailClientAdapter(connection);
            }
            return null;
        }
        
    }
}
