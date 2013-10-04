using Medical.Synchronization;
using Medical.Synchronization.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical.Synchronization
{
    /// <summary>
    /// Summary description for WebCore
    /// </summary>
    public class WebCore
    {
        /// <summary>
        /// Get table when know refference type that base on
        /// </summary>
        /// <param name="type">Type mapping</param>
        /// <returns>Table name</returns>
        public static string GetTableName(Type type)
        {
            string TableName = string.Empty;

            if (type.Name == typeof(Figure).Name)
                TableName = Constant_Table.FIGURE;
            else if (type.Name == typeof(FigureDetail).Name)
                TableName = Constant_Table.FIGUREDE_DETAIL;
            else if (type.Name == typeof(Medicine).Name)
                TableName = Constant_Table.MEDICINE;
            else if (type.Name == typeof(MedicineDelivery).Name)
                TableName = Constant_Table.MEDICINE_DELIVERY;
            else if (type.Name == typeof(MedicineDeliveryDetail).Name)
                TableName = Constant_Table.MEDICIN_DELIVERY_DETAIL;
            else if (type.Name == typeof(MedicineDeliveryDetailAllocate).Name)
                TableName = Constant_Table.MEDICIN_DELIVERY_DETAIL_ALLOCATE;
            else if (type.Name == typeof(MedicinePlan).Name)
                TableName = Constant_Table.MEDICINE_PLAN;
            else if (type.Name == typeof(MedicinePlanDetail).Name)
                TableName = Constant_Table.MEDICINE_PLAN_DETAIL;
            else if (type.Name == typeof(MedicineUnitPrice).Name)
                TableName = Constant_Table.MEDICINE_UNIT_PRICE;
            else if (type.Name == typeof(Patient).Name)
                TableName = Constant_Table.PATIENT;
            else if (type.Name == typeof(PatientFigure).Name)
                TableName = Constant_Table.PATIENT_FIGURE;
            else if (type.Name == typeof(Prescription).Name)
                TableName = Constant_Table.PRESCRIPTION;
            else if (type.Name == typeof(PrescriptionDetail).Name)
                TableName = Constant_Table.PRESCRIPTION_DETAIL;
            else if (type.Name == typeof(WareHouse).Name)
                TableName = Constant_Table.WAREHOUSE;
            else if (type.Name == typeof(WareHouseDetail).Name)
                TableName = Constant_Table.WAREHOUSE_DETAIL;
            else if (type.Name == typeof(WareHouseExportAllocate).Name)
                TableName = Constant_Table.WAREHOUSE_EXPORT_ALLOCATE;
            else if (type.Name == typeof(WareHouseIO).Name)
                TableName = Constant_Table.WAREHOUSE_IO;
            else if (type.Name == typeof(WareHouseIODetail).Name)
                TableName = Constant_Table.WAREHOUSE_IO_DETAIL;
            else if (type.Name == typeof(WareHouseMinimumAllow).Name)
                TableName = Constant_Table.WAREHOUSE_MINIMUM_ALLOW;
            else if (type.Name == typeof(User).Name)
                TableName = Constant_Table.USER;
            else if (type.Name == typeof(Define).Name)
                TableName = Constant_Table.DEFINE;
            return TableName;
        }
    }
}