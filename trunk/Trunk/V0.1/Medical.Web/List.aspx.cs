using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using Medical.Synchronization;

public partial class List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        foreach (var segment in Request.GetFriendlyUrlSegments())
        {
            if (segment.ToUpper() == Constant_Table.FIGURE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.FIGURE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Mã", typeof(string)));
                searchConditions.Add(new SearchExpander("Name", "Tên gọi", typeof(string)));
                searchConditions.Add(new SearchExpander("Description", "Ghi chú", typeof(string)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.FIGUREDE_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.FIGUREDE_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("FigureId", "FigureId", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICINE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("ID", "Mã thuốc", typeof(int)));
                searchConditions.Add(new SearchExpander("Name", "Tên thuốc", typeof(string)));
                searchConditions.Add(new SearchExpander("TradeName", "Tên thương mại", typeof(string)));
                searchConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "Cập nhật ngày", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("LastUpdatedBy", "Bởi", typeof(string)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_DELIVERY.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICINE_DELIVERY;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("ID", "ID", typeof(int)));
                searchConditions.Add(new SearchExpander("PatientId", "PatientId", typeof(int)));
                searchConditions.Add(new SearchExpander("PrescriptionId", "PrescriptionId", typeof(int)));
                searchConditions.Add(new SearchExpander("Date", "Date", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "LastUpdatedDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("LastUpdatedUser", "LastUpdatedUser", typeof(string)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICIN_DELIVERY_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICIN_DELIVERY_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineDeliveryId", "MedicineDeliveryId", typeof(int)));
                searchConditions.Add(new SearchExpander("PrescriptionDetailId", "PrescriptionDetailId", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Unit", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "LastUpdatedDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICIN_DELIVERY_DETAIL_ALLOCATE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICIN_DELIVERY_DETAIL_ALLOCATE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(string)));
                searchConditions.Add(new SearchExpander("MedicineDeliveryDetailId", "MedicineDeliveryDetailId", typeof(int)));
                searchConditions.Add(new SearchExpander("WareHouseDetailId", "WareHouseDetailId", typeof(int)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Unit", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "LastUpdatedDate", typeof(int)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_PLAN.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICINE_PLAN;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("Year", "Year", typeof(int)));
                searchConditions.Add(new SearchExpander("Month", "Month", typeof(int)));
                searchConditions.Add(new SearchExpander("Date", "Date", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Note", "Note", typeof(string)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "LastUpdatedDate", typeof(int)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_PLAN_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICINE_PLAN_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(string)));
                searchConditions.Add(new SearchExpander("PlanId", "PlanId", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int)));
                searchConditions.Add(new SearchExpander("InStock", "InStock", typeof(int)));
                searchConditions.Add(new SearchExpander("LastMonthUsage", "LastMonthUsage", typeof(int)));
                searchConditions.Add(new SearchExpander("CurrentMonthUsage", "CurrentMonthUsage", typeof(int)));
                searchConditions.Add(new SearchExpander("UnitPrice", "UnitPrice", typeof(int)));
                searchConditions.Add(new SearchExpander("Amount", "Amount", typeof(int)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_UNIT_PRICE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICINE_UNIT_PRICE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int)));
                searchConditions.Add(new SearchExpander("StartDate", "StartDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("EndDate", "EndDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("UnitPrice", "UnitPrice", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "LastUpdatedDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("LastUpdatedUser", "LastUpdatedUser", typeof(int)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.PATIENT.ToUpper())
            {
                uctListBase.TableName = Constant_Table.PATIENT;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("Code", "Code", typeof(string)));
                searchConditions.Add(new SearchExpander("Name", "Name", typeof(string)));
                searchConditions.Add(new SearchExpander("BirthYear", "BirthYear", typeof(int)));
                searchConditions.Add(new SearchExpander("Sexual", "Sexual", typeof(char)));
                searchConditions.Add(new SearchExpander("Phone", "Phone", typeof(string)));
                searchConditions.Add(new SearchExpander("Address", "Address", typeof(string)));
                searchConditions.Add(new SearchExpander("StartDate", "StartDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Description", "Description", typeof(string)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.PATIENT_FIGURE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.PATIENT_FIGURE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("PatientId", "PatientId", typeof(int)));
                searchConditions.Add(new SearchExpander("FigureId", "FigureId", typeof(int)));
                searchConditions.Add(new SearchExpander("StartDate", "StartDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("FromDate", "FromDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Description", "Description", typeof(string)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "LastUpdatedDate", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.PRESCRIPTION.ToUpper())
            {
                uctListBase.TableName = Constant_Table.PRESCRIPTION;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("PatientId", "PatientId", typeof(int)));
                searchConditions.Add(new SearchExpander("DoctorId", "DoctorId", typeof(int)));
                searchConditions.Add(new SearchExpander("Date", "Date", typeof(int)));
                searchConditions.Add(new SearchExpander("FigureId", "FigureId", typeof(int)));
                searchConditions.Add(new SearchExpander("Note", "Note", typeof(object)));
                searchConditions.Add(new SearchExpander("CreatedDate", "CreatedDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("LastUpdatedUser", "LastUpdatedUser", typeof(int)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;

            }
            else if (segment.ToUpper() == Constant_Table.PRESCRIPTION_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.PRESCRIPTION_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("PrescriptionId", "PrescriptionId", typeof(int)));
                searchConditions.Add(new SearchExpander("FigureDetailId", "FigureDetailId", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int)));
                searchConditions.Add(new SearchExpander("Day", "Day", typeof(int)));
                searchConditions.Add(new SearchExpander("VolumnPerDay", "VolumnPerDay", typeof(int)));
                searchConditions.Add(new SearchExpander("Amount", "Amount", typeof(int)));
                searchConditions.Add(new SearchExpander("Description", "Description", typeof(string)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                searchConditions.Add(new SearchExpander("MinAllowed", "MinAllowed", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdatedUser", "LastUpdatedUser", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "LastUpdatedDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("WareHouseId", "WareHouseId", typeof(int)));
                searchConditions.Add(new SearchExpander("WareHouseIODetailId", "WareHouseIODetailId", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int)));
                searchConditions.Add(new SearchExpander("LotNo", "LotNo", typeof(string)));
                searchConditions.Add(new SearchExpander("ExpiredDate", "ExpiredDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Unit", "Unit", typeof(int)));
                searchConditions.Add(new SearchExpander("UnitPrice", "UnitPrice", typeof(string)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "LastUpdatedDate", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_EXPORT_ALLOCATE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE_EXPORT_ALLOCATE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("WareHoudeIODetailId", "WareHoudeIODetailId", typeof(int)));
                searchConditions.Add(new SearchExpander("WareHouseDetailId", "WareHouseDetailId", typeof(int)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Unit", typeof(int)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_IO.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE_IO;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("Type", "Type", typeof(int)));
                searchConditions.Add(new SearchExpander("Date", "Date", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("No", "No", typeof(string)));
                searchConditions.Add(new SearchExpander("Person", "Person", typeof(string)));
                searchConditions.Add(new SearchExpander("Phone", "Phone", typeof(string)));
                searchConditions.Add(new SearchExpander("Address", "Address", typeof(string)));
                searchConditions.Add(new SearchExpander("Note", "Note", typeof(string)));
                searchConditions.Add(new SearchExpander("AttachmentNo", "AttachmentNo", typeof(string)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_IO_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE_IO_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("WareHouseIOId", "WareHouseIOId", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int)));
                searchConditions.Add(new SearchExpander("LotNo", "LotNo", typeof(string)));
                searchConditions.Add(new SearchExpander("ExpireDate", "ExpireDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Qty", "Qty", typeof(int)));
                searchConditions.Add(new SearchExpander("UnitPrice", "UnitPrice", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Unit", typeof(int)));
                searchConditions.Add(new SearchExpander("Amount", "Amount", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_MINIMUM_ALLOW.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE_MINIMUM_ALLOW;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int)));
                searchConditions.Add(new SearchExpander("Amount", "Amount", typeof(int)));
                searchConditions.Add(new SearchExpander("Note", "Note", typeof(string)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "LastUpdatedDate", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdateUser", "LastUpdateUser", typeof(int)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else //Do nothing
            {
            }
        }


    }
}