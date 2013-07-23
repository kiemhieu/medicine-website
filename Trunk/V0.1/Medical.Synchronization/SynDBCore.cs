﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using Medical.Synchronization.Basic;
using System.Collections;

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
        public static List<T> SendAllToSV(string ClientID, string KeyColumn)
        {
            List<T> list = GetAllToSend(KeyColumn);
            return SendToSV(ClientID, list);
        }

        /// <summary>
        /// Send a list object (of T) to Server
        /// </summary>
        /// <param name="ClientID"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> SendToSV(string ClientID, List<T> list)
        {
            List<T> result = new List<T>();
            if (list == null) return null;
            foreach (T obj in list)
            {
                SendToSV(ClientID, obj);
                if (Exist(obj, ClientID)) result.Add(obj);
            }
            return result;
        }

        /// <summary>
        /// Check if exist in server
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool Exist(T obj, string ClientID)
        {
            string tableName = GetTableName();
            PropertyInfo[] infos = (typeof(T)).GetProperties();
            string KeyColumn = string.Empty;
            int KeyIndex = -1;
            foreach (PropertyInfo info in infos)
            {
                KeyIndex++;
                if (info.PropertyType.Name == "ExtensionDataObject" || info.Name.ToUpper() == "CLIENTID") continue;
                KeyColumn = info.Name;
                break;
            }

            //Add to log table
            string SQL2 = "SELECT * FROM " + tableName + " WHERE ClientID ='" + ClientID + "' AND " + KeyColumn + "=@" + KeyColumn;
            SqlParameter[] parames2 = new SqlParameter[] { new SqlParameter("@" + KeyColumn, infos[KeyIndex].GetValue(obj, null)) };
            DataSet dataset = SqlHelper.ExecuteDataset(Config.SVConnectionString, CommandType.Text, SQL2, parames2);

            bool result = false;
            if (dataset != null && dataset.Tables.Count > 0)
            {
                result = true;
                dataset.Dispose();
            }
            return result;
        }

        /// <summary>
        /// Send an object to server
        /// </summary>
        /// <param name="ClientID"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool SendToSV(string ClientID, T obj)
        {

            //Another parameter in table which is referenced
            string tableName = GetTableName();
            PropertyInfo[] infos = (typeof(T)).GetProperties();

            //-----------------------------------------------------------------------------------------------------
            //--------------------------------SAVE TO SERVER TABLE------------------------------------------------
            try
            {
                //Parameter root - ClientID
                List<SqlParameter> parames = new List<SqlParameter>();
                SqlParameter param0 = new SqlParameter("@ClientID", ClientID);
                parames.Add(param0);

                string SQL = "INSERT INTO " + tableName + " VALUES (@ClientID";
                int n = 0;
                foreach (PropertyInfo info in infos)
                {
                    if (n < infos.Length)
                    {
                        if (info.PropertyType != typeof(string)
                            && info.PropertyType.GetInterface(typeof(IEnumerable).Name) != null
                            && info.PropertyType.GetInterface(typeof(IEnumerable<>).Name) != null) continue;
                        SQL += ", @" + info.Name;
                        object valueP = info.GetValue(obj, null);
                        if (valueP is DateTime && (DateTime)valueP == DateTime.MinValue) valueP = DBNull.Value;
                        SqlParameter param = new SqlParameter("@" + info.Name, valueP ?? DBNull.Value);
                        parames.Add(param);
                    }
                    n++;
                }
                SQL += ")";
                int i = SqlHelper.ExecuteNonQuery(Config.SVConnectionString, CommandType.Text, SQL, parames.ToArray());
                if (i == -1) return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SaveLog(List<T> list)
        {
            string tableName = GetTableName();
            PropertyInfo[] infos = (typeof(T)).GetProperties();
            string KeyColumn = string.Empty;
            int KeyIndex = -1;
            foreach (PropertyInfo info in infos)
            {
                KeyIndex++;
                if (info.PropertyType.Name == "ExtensionDataObject") continue;
                KeyColumn = info.Name;
                break;
            }
            //-----------------------------------------------------------------------------------------------------
            //--------------------------------SAVE TO MAPPING TABLE------------------------------------------------
            try
            {
                foreach (T obj in list)
                {
                    //Add to log table
                    string SQL2 = "INSERT INTO Syn" + tableName + " VALUES (@" + KeyColumn + ")";
                    SqlParameter[] parames2 = new SqlParameter[] { new SqlParameter("@" + KeyColumn, infos[KeyIndex].GetValue(obj, null)) };
                    int j = SqlHelper.ExecuteNonQuery(Config.ConnectionString, CommandType.Text, SQL2, parames2);
                }
                //if (j == -1) return false;
                return true;
            }
            catch
            {
                return false;
            }
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

            int i = 0;
            foreach (PropertyInfo info in infos)
            {
                if (info.PropertyType.Name == "ExtensionDataObject") continue;
                string name = info.Name;
                if (i < row.ItemArray.Length && row[i] != DBNull.Value) info.SetValue(obj, row[i], null);
                name = name + ":";
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

            if (typeof(T).Name == typeof(Figure).Name)
                TableName = Constant_Table.FIGURE;
            else if (typeof(T).Name == typeof(FigureDetail).Name)
                TableName = Constant_Table.FIGUREDE_DETAIL;
            else if (typeof(T).Name == typeof(MedicineDelivery).Name)
                TableName = Constant_Table.MEDICINE_DELIVERY;
            else if (typeof(T).Name == typeof(MedicineDeliveryDetail).Name)
                TableName = Constant_Table.MEDICIN_EDELIVERY_DETAIL;
            else if (typeof(T).Name == typeof(MedicineDeliveryDetailAllocate).Name)
                TableName = Constant_Table.MEDICIN_EDELIVERY_DETAIL_ALLOCATE;
            else if (typeof(T).Name == typeof(MedicinePlan).Name)
                TableName = Constant_Table.MEDICINE_PLAN;
            else if (typeof(T).Name == typeof(MedicinePlanDetail).Name)
                TableName = Constant_Table.MEDICINE_PLAN_DETAIL;
            else if (typeof(T).Name == typeof(MedicineUnitPrice).Name)
                TableName = Constant_Table.MEDICINE_UNIT_PRICE;
            else if (typeof(T).Name == typeof(Patient).Name)
                TableName = Constant_Table.PATIENT;
            else if (typeof(T).Name == typeof(PatientFigure).Name)
                TableName = Constant_Table.PATIENT_FIGURE;
            else if (typeof(T).Name == typeof(Prescription).Name)
                TableName = Constant_Table.PRESCRIPTION;
            else if (typeof(T).Name == typeof(PrescriptionDetail).Name)
                TableName = Constant_Table.PRESCRIPTION_DETAIL;
            else if (typeof(T).Name == typeof(WareHouse).Name)
                TableName = Constant_Table.WAREHOUSE;
            else if (typeof(T).Name == typeof(WareHouseDetail).Name)
                TableName = Constant_Table.WAREHOUSE_DETAIL;
            else if (typeof(T).Name == typeof(WareHouseExportAllocate).Name)
                TableName = Constant_Table.WAREHOUSE_EXPORT_ALLOCATE;
            else if (typeof(T).Name == typeof(WareHouseIO).Name)
                TableName = Constant_Table.WAREHOUSE_IO;
            else if (typeof(T).Name == typeof(WareHouseIODetail).Name)
                TableName = Constant_Table.WAREHOUSE_IO_DETAIL;
            else if (typeof(T).Name == typeof(WareHouseMinimumAllow).Name)
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
        public const string FIGUREDE_DETAIL = "FigureDetail";
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