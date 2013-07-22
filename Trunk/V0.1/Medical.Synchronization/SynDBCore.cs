using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using Medical.Synchronization.Basic;

namespace Medical.Synchronization
{
    /// <summary>
    /// Summary description for SynDBCore
    /// </summary>
    public class SynDBCore<T> where T : class
    {  
        #region Values member
        private static bool bReadTableName = false;
        private static string TableName = string.Empty;
        #endregion

        /// <summary>
        /// Send all data to server
        /// </summary>
        /// <param name="ClientID"></param>
        /// <param name="KeyColumn"></param>
        /// <returns></returns>
        public static bool SendAllToSV(string ClientID, string KeyColumn)
        {
            List<T> list = GetAllToSend(KeyColumn);
            if (list != null)
            {
                foreach (T obj in list)
                    if (!SendToSV(ClientID, obj)) return false;
            }
            return true;
        }

        /// <summary>
        /// Send an object to server
        /// </summary>
        /// <param name="ClientID"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool SendToSV(string ClientID, T obj)
        {
            //Parameter root - ClientID
            List<SqlParameter> parames = new List<SqlParameter>();
            SqlParameter param0 = new SqlParameter("@ClientID", ClientID);
            parames.Add(param0);

            //Another parameter in table which is referenced
            string tableName = GetTableName();
            string SQL = "INSERT INTO " + tableName + " VALUES (@ClientID";
            PropertyInfo[] infos = (typeof(T)).GetProperties();
            int n = 0;
            foreach (PropertyInfo info in infos)
            {
                if (n < infos.Length - 1)
                {
                    SQL += ", @" + info.Name;
                    SqlParameter param = new SqlParameter("@" + info.Name, info.GetValue(obj, null));
                    parames.Add(param);
                }
                n++;
            }
            SQL += ")";
            int i = SqlHelper.ExecuteNonQuery(Config.SVConnectionString, CommandType.Text, SQL, parames.ToArray());

            //Add to log table
             string SQL2 = "INSERT INTO Syn" + tableName + " VALUES (@" + infos[0].Name + ")" ;
             SqlParameter[] parames2 = new SqlParameter[]{new SqlParameter("@" + infos[0].Name, infos[0].GetValue(obj, null))};
             int j = SqlHelper.ExecuteNonQuery(Config.ConnectionString, CommandType.Text, SQL2, parames2);

            if (i == -1 || j ==-1) return false;
            return true;
        }

        /// <summary>
        /// Get akk data
        /// </summary>
        /// <returns></returns>
        public static List<T> GetAll()
        {
            string tableName = GetTableName();
            string SQL = "SELECT * FROM " + tableName;
            List<T> result = null;
            DataSet dataset = SqlHelper.ExecuteDataset(Config.ConnectionString, CommandType.Text, SQL);
            if (dataset != null && dataset.Tables.Count > 0)
            {
                DataTable table = dataset.Tables[0];
                result = new List<T>();
                foreach (DataRow row in table.Rows)
                {
                    T obj = GetObject(row);
                    result.Add(obj);
                }
                table.Dispose();
            }
            dataset.Dispose();
            return result;
        }

        /// <summary>
        /// Get all object prepare to send to server
        /// </summary>
        /// <param name="KeyColumn"></param>
        /// <returns></returns>
        public static List<T> GetAllToSend(string KeyColumn)
        {
            string tableName = GetTableName();
            string SQL = "SELECT * FROM " + tableName + " WHERE " + KeyColumn + " NOT IN (SELECT " + KeyColumn + " FROM Syn" + tableName + ")";
            List<T> result = null;
            DataSet dataset = SqlHelper.ExecuteDataset(Config.ConnectionString, CommandType.Text, SQL);
            if (dataset != null && dataset.Tables.Count > 0)
            {
                DataTable table = dataset.Tables[0];
                result = new List<T>();
                foreach (DataRow row in table.Rows)
                {
                    T obj = GetObject(row);
                    result.Add(obj);
                }
                table.Dispose();
            }
            dataset.Dispose();
            return result;
        }

        /// <summary>
        /// Convert datarow to an object
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T GetObject(DataRow row)
        {
            T obj = Activator.CreateInstance<T>();
            PropertyInfo[] infos = (typeof(T)).GetProperties();

            if (infos.Length != row.ItemArray.Length + 1) return null;
            int i = 0;
            foreach (PropertyInfo info in infos)
            {
                if ( i < row.ItemArray.Length && row[i] != DBNull.Value) info.SetValue(obj, row[i], null);
                i++;
            }
            return obj;
        }

        /// <summary>
        /// Get table name with
        /// </summary>
        /// <returns></returns>
        private static string GetTableName()
        {
            if (bReadTableName) return TableName;
            TableName = string.Empty;

            if (typeof(T) == typeof(Figure))
                TableName = Constant_Table.FIGURE;
            else if (typeof(T) == typeof(FigureDetail))
                TableName = Constant_Table.FIGUREDE_TAIL;
            else if (typeof(T) == typeof(MedicineDelivery))
                TableName = Constant_Table.MEDICINE_DELIVERY;
            else if (typeof(T) == typeof(MedicineDeliveryDetail))
                TableName = Constant_Table.MEDICIN_EDELIVERY_DETAIL;
            else if (typeof(T) == typeof(MedicineDeliveryDetailAllocate))
                TableName = Constant_Table.MEDICIN_EDELIVERY_DETAIL_ALLOCATE;
            else if (typeof(T) == typeof(MedicinePlan))
                TableName = Constant_Table.MEDICINE_PLAN;
            else if (typeof(T) == typeof(MedicinePlanDetail))
                TableName = Constant_Table.MEDICINE_PLAN_DETAIL;
            else if (typeof(T) == typeof(MedicineUnitPrice))
                TableName = Constant_Table.MEDICINE_UNIT_PRICE;
            else if (typeof(T) == typeof(Patient))
                TableName = Constant_Table.PATIENT;
            else if (typeof(T) == typeof(PatientFigure))
                TableName = Constant_Table.PATIENT_FIGURE;
            else if (typeof(T) == typeof(Prescription))
                TableName = Constant_Table.PRESCRIPTION;
            else if (typeof(T) == typeof(PrescriptionDetail))
                TableName = Constant_Table.PRESCRIPTION_DETAIL;
            else if (typeof(T) == typeof(WareHouse))
                TableName = Constant_Table.WAREHOUSE;
            else if (typeof(T) == typeof(WareHouseDetail))
                TableName = Constant_Table.WAREHOUSE_DETAIL;
            else if (typeof(T) == typeof(WareHouseExportAllocate))
                TableName = Constant_Table.WAREHOUSE_EXPORT_ALLOCATE;
            else if (typeof(T) == typeof(WareHouseIO))
                TableName = Constant_Table.WAREHOUSE_IO;
            else if (typeof(T) == typeof(WareHouseIODetail))
                TableName = Constant_Table.WAREHOUSE_IO_DETAIL;
            else if (typeof(T) == typeof(WareHouseMinimumAllow))
                TableName = Constant_Table.WAREHOUSE_MINIMUM_ALLOW;
            return TableName;
        }
    }


    /// <summary>
    /// constant which contain table name
    /// </summary>
    public class Constant_Table
    {
        public const string FIGURE = "Figure";
        public const string FIGUREDE_TAIL = "FigureDetail";
        public const string MEDICINE_DELIVERY = "MedicineDelivery";
        public const string MEDICIN_EDELIVERY_DETAIL = "MedicineDeliveryDetail";
        public const string MEDICIN_EDELIVERY_DETAIL_ALLOCATE = "MedicineDeliveryDetailAllocate";
        public const string MEDICINE_PLAN = "MedicinePlan";
        public const string MEDICINE_PLAN_DETAIL = "MedicinePlanDetail";
        public const string MEDICINE_UNIT_PRICE = "MedicineUnitPrice";
        public const string PATIENT = "Patient";
        public const string PATIENT_FIGURE = "PatientFigure";
        public const string PRESCRIPTION = "Prescription";
        public const string PRESCRIPTION_DETAIL = "PrescriptionDetail";
        public const string WAREHOUSE = "WareHouse";
        public const string WAREHOUSE_DETAIL = "WareHouseDetail";
        public const string WAREHOUSE_EXPORT_ALLOCATE = "WareHouseExportAllocate";
        public const string WAREHOUSE_IO = "WareHouseIO";
        public const string WAREHOUSE_IO_DETAIL = "WareHouseIODetail";
        public const string WAREHOUSE_MINIMUM_ALLOW = "WareHouseMinimumAllow";
    }
}