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

        private StringBuilder messageBuilder;

        public Sync()
        {
            messageBuilder = new StringBuilder();
        }

        /// <summary>
        /// Does the sync master.
        /// </summary>
        public void DoSyncMaster()
        {
            try
            {
                messageBuilder.Clear();
                messageBuilder.AppendLine("Start sync at " + DateTime.Now);
                Update(0, "Kiểm tra kết nối tới server...");
                SyncSoap sync = new SyncSoapClient();
                String message;
                if (!TestConnection(out message))
                {
                    Update(0, "Không kết nối được tới máy chủ. Kiểm tra lại đường truyền (" + message + ")");
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
            catch (Exception ex)
            {
                Update(100, "Error: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Does the sync.
        /// </summary>
        /// <param name="clinicId">The clinic id.</param>
        public void DoSync(int clinicId)
        {
            try
            {
                Update(25, "Cập nhập dữ liệu bệnh nhân ");
                DoSync("Patient", clinicId);

                Update(30, "Cập nhập dữ liệu phát thuốc ");
                DoSync("MedicineDelivery", clinicId);

                Update(35, "Cập nhập dữ liệu phát thuốc ");
                DoSync("MedicineDeliveryDetail", clinicId);

                Update(40, "Cập nhập dữ liệu dự trù thuốc ");
                DoSync("MedicinePlan", clinicId);

                Update(45, "Cập nhập dữ liệu dự trù thuốc ");
                DoSync("MedicinePlanDetail", clinicId);

                Update(50, "Cập nhập dữ liệu kho thuốc ");
                DoSync("WareHouse", clinicId);

                Update(55, "Cập nhập dữ liệu dự trù thuốc ");
                DoSync("WareHouseIO", clinicId);

                Update(60, "Cập nhập dữ liệu dự trù thuốc ");
                DoSync("WareHouseIODetail", clinicId);

                //Update(100, "Đồng bộ dữ liệu thành công ");
            }
            catch (Exception ex)
            {
                Update(100, "Error: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Does the remove.
        /// </summary>
        /// <param name="clinicId">The clinic id.</param>
        public void DoRemove(int clinicId)
        {
            try
            {
                Update(65, "Cập nhập dữ liệu bệnh nhân ");
                DoRemove("Patient", clinicId);

                Update(70, "Cập nhập dữ liệu phát thuốc ");
                DoRemove("MedicineDelivery", clinicId);

                Update(75, "Cập nhập dữ liệu phát thuốc ");
                DoRemove("MedicineDeliveryDetail", clinicId);

                Update(80, "Cập nhập dữ liệu dự trù thuốc ");
                DoRemove("MedicinePlan", clinicId);

                Update(85, "Cập nhập dữ liệu dự trù thuốc ");
                DoRemove("MedicinePlanDetail", clinicId);

                Update(90, "Cập nhập dữ liệu kho thuốc ");
                DoRemove("WareHouse", clinicId);

                Update(95, "Cập nhập dữ liệu dự trù thuốc ");
                DoRemove("WareHouseIO", clinicId);

                Update(98, "Cập nhập dữ liệu dự trù thuốc ");
                DoRemove("WareHouseIODetail", clinicId);

                Update(100, "Đồng bộ dữ liệu thành công ");
            }
            catch (Exception ex)
            {
                Update(100, "Error: " + ex.Message);
                throw;
            }
            // UpdateSyncResult(clinicId);
        }

        /// <summary>
        /// Does the remove.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="clinicId">The clinic id.</param>
        /// <exception cref="System.Exception"></exception>
        private void DoRemove(String key, int clinicId)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            TableChangeClientAdapter clientAdapter = new TableChangeClientAdapter(connection, key);
            SyncSoap syncObject = new SyncSoapClient();
            int counting = 0;
            string message;
            var ds = new DataSet();
            var table = clientAdapter.GetData(key, 500, out counting);
            ds.Tables.Add(table);
            var result = syncObject.Remove(out message, clinicId, ds);
            if (result) clientAdapter.Update(table);
            else
                throw new Exception(message);
        }

        /// <summary>
        /// Tests the connection.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public bool TestConnection(out String message)
        {
            try
            {
                message = String.Empty;
                SyncSoap sync = new SyncSoapClient();
                return sync.TestConnection();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns></returns>
        private String GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MedicalContext"].ConnectionString;
        }

        /// <summary>
        /// Gets the sync table.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="clinicId">The clinic id.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        private void DoSync(String key, int clinicId)
        {
            ClientAdapterBase clientAdapter = CreateAdapter(key);
            SyncSoap syncObject = new SyncSoapClient();
            int counting = 0;
            string message;
            var ds = new DataSet();
            var table = clientAdapter.GetData(key, 500, out counting);
            ds.Tables.Add(table);
            var result = syncObject.SyncTable(out message, clinicId, ds);
            if (result) clientAdapter.Update(table);
            else
                throw new Exception(message);
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

        /// <summary>
        /// Updates the specified progress.
        /// </summary>
        /// <param name="progress">The progress.</param>
        /// <param name="message">The message.</param>
        private void Update(int progress, String message)
        {
            if (this.Worker == null) return;
            this.Worker.ReportProgress(progress, message);
            messageBuilder.AppendLine(message);
        }

        /// <summary>
        /// Updates the sync result.
        /// </summary>
        /// <param name="clinicId">The clinic id.</param>
        /// <param name="message">The message.</param>
        public void UpdateSyncResult(int clinicId)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand
                                     {
                                         Connection = connection,
                                         CommandText = "UPDATE Clinic SET LastSyncTime = GETDATE(), SyncMessage = @message WHERE Id = @id"
                                     };
            command.Parameters.Add(new SqlParameter("@message", messageBuilder.ToString()));
            command.Parameters.Add(new SqlParameter("@id", clinicId));
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
            } finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
            
        }

        
    }
}
