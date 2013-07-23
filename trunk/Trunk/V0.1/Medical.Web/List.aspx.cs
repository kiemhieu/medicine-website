﻿using System;
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
            else if (segment.ToUpper() == Constant_Table.MEDICIN_EDELIVERY_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICIN_EDELIVERY_DETAIL;
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
            else if (segment.ToUpper() == Constant_Table.MEDICIN_EDELIVERY_DETAIL_ALLOCATE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICIN_EDELIVERY_DETAIL_ALLOCATE;
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
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_DETAIL.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_EXPORT_ALLOCATE.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_IO.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_IO_DETAIL.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_MINIMUM_ALLOW.ToUpper())
            {
            }
            else //Do nothing
            {
            }
        }


    }
}