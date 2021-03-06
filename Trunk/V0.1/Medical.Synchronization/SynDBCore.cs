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
            foreach (T obj in list) { if (SendToSV(ClientID, obj)) result.Add(obj); }
            return result;
        }

        /// <summary>
        /// Clear log when data changed
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool SaveChange(object KeyValue)
        {
            string tableName = WebCore.GetTableName(typeof(T));
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
            string SQL2 = "DELETE FROM Syn" + tableName + " WHERE " + KeyColumn + "=@" + KeyColumn;
            SqlParameter[] parames2 = new SqlParameter[] { new SqlParameter("@" + KeyColumn, KeyValue) };
            int i = SqlHelper.ExecuteNonQuery(Config.ConnectionString, CommandType.Text, SQL2, parames2);
             
            if (i == -1) return false;
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
            string KeyColumn = string.Empty;
            object KeyValue = null;

            //Another parameter in table which is referenced
            string tableName = WebCore.GetTableName(typeof(T));
            PropertyInfo[] infos = (typeof(T)).GetProperties();
            try
            {
                //Parameter root - ClientID
                List<SqlParameter> parames = new List<SqlParameter>();
                SqlParameter param0 = new SqlParameter("@ClientID", ClientID);
                parames.Add(param0);

                string SQL = "INSERT INTO [" + tableName + "] VALUES (@ClientID";
                int KeyIndex = -1;
                foreach (PropertyInfo info in infos)
                {
                    KeyIndex++;
                    //remove uneccessary column
                    if (info.PropertyType.Name == "ExtensionDataObject") continue;
                    if (info.PropertyType != typeof(string)
                        && info.PropertyType.GetInterface(typeof(IEnumerable).Name) != null
                        && info.PropertyType.GetInterface(typeof(IEnumerable<>).Name) != null) continue;


                    object valueP = info.GetValue(obj, null);
                    if (KeyColumn == string.Empty) KeyColumn = info.Name;
                    if (KeyValue == null) KeyValue = valueP;
                    if (valueP is DateTime && (DateTime)valueP == DateTime.MinValue) valueP = DBNull.Value;
                    SqlParameter param = new SqlParameter("@" + info.Name, valueP ?? DBNull.Value);
                    parames.Add(param);

                    SQL += ", @" + info.Name;
                }
                SQL += ")";

                //--------------------------------DELETE IF EXIST FROM SERVER TABLE-----------------------------------
                string sqlDelete = "DELETE FROM [" + tableName + "] WHERE ClientID=@ClientID AND " + KeyColumn + "=@" + KeyColumn;
                SqlParameter paramClientID = new SqlParameter("@ClientID", ClientID);
                SqlParameter paramKeyColumn = new SqlParameter("@" + KeyColumn, KeyValue ?? DBNull.Value);
                SqlHelper.ExecuteNonQuery(Config.SVConnectionString, CommandType.Text, sqlDelete, new SqlParameter[] { paramClientID, paramKeyColumn });

                //--------------------------------SAVE TO SERVER TABLE------------------------------------------------
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
            string tableName = WebCore.GetTableName(typeof(T));
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
                    string SQL2 = "INSERT INTO [Syn" + tableName + "] VALUES (@" + KeyColumn + ")";
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
            string tableName = WebCore.GetTableName(typeof(T));
            string SQL = "SELECT * FROM [" + tableName + "]";
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
            string tableName = WebCore.GetTableName(typeof(T));
            string SQL = "SELECT * FROM [" + tableName + "] WHERE " + KeyColumn + " NOT IN (SELECT " + KeyColumn + " FROM [Syn" + tableName + "])";
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
    }


    /// <summary>
    /// constant which contain table name
    /// </summary>
    public class Constant_Table
    {
        public const string DEFINE = "Define";
        public const string FIGURE = "Figure";
        public const string FIGUREDE_DETAIL = "FigureDetail";
        public const string MEDICINE = "Medicine";
        public const string USER = "User";
        public const string MEDICINE_DELIVERY = "MedicineDelivery";
        public const string MEDICIN_DELIVERY_DETAIL = "MedicineDeliveryDetail";
        public const string MEDICIN_DELIVERY_DETAIL_ALLOCATE = "MedicineDeliveryDetailAllocate";
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