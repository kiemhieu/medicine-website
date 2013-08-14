using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// <summary>
        /// Gets or sets the worker.
        /// </summary>
        /// <value>
        /// The worker.
        /// </value>
        public BackgroundWorker Worker { get; set; }

        /// <summary>
        /// Updates the specified progress.
        /// </summary>
        /// <param name="progress">The progress.</param>
        /// <param name="message">The message.</param>
        private void Update(int progress, String message)
        {
            if (this.Worker == null) return;
            this.Worker.ReportProgress(progress, message);
        }

        public void DoSyncMaster()
        {
            Update(0, "Kiểm tra kết nối tới server...");
            SyncSoap sync = new SyncSoapClient();
            if (!TestConnection(sync))
            {
                Update(0, "Không kết nối được tới máy chủ. Kiểm tra lại đường truyền");
                return;
            }

            Update(2, "Tải về dữ liệu");
            var dataset = sync.GetMasterData();
            var connection = new SqlConnection(GetConnectionString());

            Update(5, "Cập nhập dữ liệu ");
            var adapter = new DefineAdapter(connection);
            adapter.Sync(dataset.Tables[0]);

            Update(10, "Cập nhập dữ liệu thuốc ");
            var medicineAdater = new MedicineAdapter(connection);
            medicineAdater.Sync(dataset.Tables[1]);

            Update(15, "Cập nhập dữ liệu phác đồ ");
            var figureAdapter = new FigureAdapter(connection);
            figureAdapter.Sync(dataset.Tables[2]);

            Update(20, "Cập nhập dữ liệu phác đồ ");
            var figureDetailAdapter = new FigureDetailAdapter(connection);
            figureDetailAdapter.Sync(dataset.Tables[3]);
        }

        public void DoSync(int clinicId)
        {
            Update(25, "Cập nhập dữ liệu bệnh nhân ");
            DoSync("Patient", clinicId);

            Update(30, "Cập nhập dữ liệu phát thuốc ");
            DoSync("MedicineDelivery", clinicId);

            Update(40, "Cập nhập dữ liệu phát thuốc ");
            DoSync("MedicineDeliveryDetail", clinicId);

            Update(50, "Cập nhập dữ liệu dự trù thuốc ");
            DoSync("MedicinePlan", clinicId);

            Update(60, "Cập nhập dữ liệu dự trù thuốc ");
            DoSync("MedicinePlanDetail", clinicId);

            Update(70, "Cập nhập dữ liệu kho thuốc ");
            DoSync("WareHouse", clinicId);

            Update(80, "Cập nhập dữ liệu dự trù thuốc ");
            DoSync("WareHouseIO", clinicId);

            Update(90, "Cập nhập dữ liệu dự trù thuốc ");
            DoSync("WareHouseIODetail", clinicId);

            Update(100, "Đồng bộ dữ liệu thành công ");
        }

        public bool TestConnection(SyncSoap connection)
        {
            try
            {
                if (connection == null) connection = new SyncSoapClient();
                return connection.TestConnection();    
            } catch(Exception ex)
            {
                return false;
            }
            
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
            //do
            //{
                var message = String.Empty;
                var ds = new DataSet();
                var table = clientAdapter.GetData(key, 500, out counting);
                ds.Tables.Add(table);
                var result = syncObject.SyncTable(out message, clinicId, ds);
                if (result) clientAdapter.Update(table);
                else
                    throw new Exception(message);
            //} while (counting > 0);
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
