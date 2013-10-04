using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using Medical.Synchronization;
using Medical.Synchronization.Basic;

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
                searchConditions.Add(new SearchExpander("Name", "Tên gọi", typeof(string), true));
                searchConditions.Add(new SearchExpander("Description", "Ghi chú", typeof(string)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.FIGUREDE_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.FIGUREDE_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("FigureId", "Phác đồ", typeof(int), "Id", typeof(Figure)));
                searchConditions.Add(new SearchExpander("MedicineId", "Thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                //searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
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
                searchConditions.Add(new SearchExpander("LastUpdatedBy", "Bởi", typeof(string), "Id", typeof(User)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_DELIVERY.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICINE_DELIVERY;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("ID", "ID", typeof(int)));
                searchConditions.Add(new SearchExpander("PatientId", "Bệnh nhân", typeof(int), "Id", typeof(Patient)));
                searchConditions.Add(new SearchExpander("PrescriptionId", "Đơn thuốc", typeof(int), "Id", "Id", typeof(Prescription)));
                //searchConditions.Add(new SearchExpander("Date", "Date", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("LastUpdatedUser", "Người cập nhật", typeof(string), "Id", typeof(User)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICIN_DELIVERY_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICIN_DELIVERY_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineDeliveryId", "MedicineDeliveryId", typeof(int), "Id", "Id", typeof(MedicineDelivery)));
                searchConditions.Add(new SearchExpander("PrescriptionDetailId", "PrescriptionDetailId", typeof(int), "Id", "Id", typeof(PrescriptionDetail)));
                searchConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Unit", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(DateTime)));
                //searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICIN_DELIVERY_DETAIL_ALLOCATE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICIN_DELIVERY_DETAIL_ALLOCATE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(string)));
                searchConditions.Add(new SearchExpander("MedicineDeliveryDetailId", "MedicineDeliveryDetailId", typeof(int), "Id", "Id", typeof(MedicineDeliveryDetail)));
                searchConditions.Add(new SearchExpander("WareHouseDetailId", "WareHouseDetailId", typeof(int), "Id", "Id", typeof(WareHouseDetail)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Unit", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(DateTime)));
                //searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_PLAN.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICINE_PLAN;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int), true));
                searchConditions.Add(new SearchExpander("Year", "Năm", typeof(int)));
                searchConditions.Add(new SearchExpander("Month", "Tháng", typeof(int)));
                searchConditions.Add(new SearchExpander("Date", "Ngày", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Note", "Ghi chú", typeof(string)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(DateTime)));
                //searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_PLAN_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.MEDICINE_PLAN_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(string)));
                searchConditions.Add(new SearchExpander("PlanId", "PlanId", typeof(int), "Id", "Id", typeof(MedicinePlan)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("InStock", "InStock", typeof(int)));
                searchConditions.Add(new SearchExpander("LastMonthUsage", "LastMonthUsage", typeof(int)));
                searchConditions.Add(new SearchExpander("CurrentMonthUsage", "CurrentMonthUsage", typeof(int)));
                searchConditions.Add(new SearchExpander("UnitPrice", "UnitPrice", typeof(int)));
                searchConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                //searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
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
                searchConditions.Add(new SearchExpander("LastUpdatedUser", "LastUpdatedUser", typeof(int), "Id", typeof(User)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.PATIENT.ToUpper())
            {
                uctListBase.TableName = Constant_Table.PATIENT;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                //searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander(false, "Code", "Mã", null, typeof(string)));
                searchConditions.Add(new SearchExpander("Name", "Họ và tên", typeof(string)));
                searchConditions.Add(new SearchExpander("BirthYear", "Năm sinh", typeof(int)));
                searchConditions.Add(new SearchExpander(false, "Sexual", "Giới tính", null, typeof(char)));
                //searchConditions.Add(new SearchExpander("Phone", "Phone", typeof(string)));
                searchConditions.Add(new SearchExpander(false, "Address", "Địa chỉ", null, typeof(string)));
                //searchConditions.Add(new SearchExpander("StartDate", "StartDate", typeof(DateTime)));
                searchConditions.Add(new SearchExpander(false, "Description", "Ghi chú", null, typeof(string)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.PATIENT_FIGURE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.PATIENT_FIGURE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("PatientId", "Bệnh nhân", typeof(int), "Id", typeof(Patient)));
                searchConditions.Add(new SearchExpander("FigureId", "Phác đồ", typeof(int), "Id", typeof(Figure)));
                searchConditions.Add(new SearchExpander("StartDate", "Ngày bắt đầu", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("FromDate", "Từ ngày", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Description", "Mô tả", typeof(string)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.PRESCRIPTION.ToUpper())
            {
                uctListBase.TableName = Constant_Table.PRESCRIPTION;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                //searchConditions.Add(new SearchExpander("Id", "Id", typeof(int), true));
                searchConditions.Add(new SearchExpander("PatientId", "Bệnh nhân", typeof(int), "Id", typeof(Patient)));
                searchConditions.Add(new SearchExpander(false, "LastUpdatedDate", "Thời gian", "{0:HH:ss}", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("DoctorId", "Bác sĩ", typeof(int), "Id", typeof(User)));
                //searchConditions.Add(new SearchExpander("Date", "Date", typeof(int)));
                searchConditions.Add(new SearchExpander("RecheckDate", "Hẹn tái khám", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("FigureId", "Phác đồ", typeof(int), "Id", typeof(Figure)));
                searchConditions.Add(new SearchExpander("Note", "Tình trạng", typeof(object)));
                //searchConditions.Add(new SearchExpander("CreatedDate", "CreatedDate", typeof(DateTime)));
                //searchConditions.Add(new SearchExpander("LastUpdatedUser", "LastUpdatedUser", typeof(int), "Id", typeof(User)));
                //searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;

            }
            else if (segment.ToUpper() == Constant_Table.PRESCRIPTION_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.PRESCRIPTION_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("PrescriptionId", "PrescriptionId", typeof(int)));
                searchConditions.Add(new SearchExpander("FigureDetailId", "FigureDetailId", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "Thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("Day", "Số ngày", typeof(int)));
                searchConditions.Add(new SearchExpander("VolumnPerDay", "Số lần trong ngày", typeof(int)));
                searchConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                searchConditions.Add(new SearchExpander("Description", "Diễn giải", typeof(string)));
                //searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int), true));
                searchConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                searchConditions.Add(new SearchExpander("MinAllowed", "Lượng tối thiểu", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdatedUser", "Người cập nhật", typeof(int), "Id", typeof(User)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "LastUpdatedDate", typeof(DateTime)));
                //searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE_DETAIL;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("WareHouseId", "WareHouseId", typeof(int), "Id", "Id", typeof(WareHouse)));
                searchConditions.Add(new SearchExpander("WareHouseIODetailId", "WareHouseIODetailId", typeof(int), "Id", "Id", typeof(WareHouseIODetail)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("LotNo", "LotNo", typeof(string)));
                searchConditions.Add(new SearchExpander("ExpiredDate", "Ngày hết hạn", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int)));
                searchConditions.Add(new SearchExpander("UnitPrice", "Đơn giá", typeof(string)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_EXPORT_ALLOCATE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE_EXPORT_ALLOCATE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("WareHoudeIODetailId", "WareHoudeIODetailId", typeof(int), "id", "Id", typeof(WareHouseIODetail)));
                searchConditions.Add(new SearchExpander("WareHouseDetailId", "WareHouseDetailId", typeof(int), "Id", "Id", typeof(WareHouseDetail)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int)));
                searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_IO.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE_IO;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int), true));
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
                searchConditions.Add(new SearchExpander("WareHouseIOId", "Thủ kho", typeof(int), "Id", "Person", typeof(WareHouseIO)));
                searchConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("LotNo", "LotNo", typeof(string)));
                searchConditions.Add(new SearchExpander("ExpireDate", "Ngày hết hạn", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Qty", "Số lượng", typeof(int)));
                searchConditions.Add(new SearchExpander("UnitPrice", "Đơn giá", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int)));
                searchConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_MINIMUM_ALLOW.ToUpper())
            {
                uctListBase.TableName = Constant_Table.WAREHOUSE_MINIMUM_ALLOW;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                searchConditions.Add(new SearchExpander("Note", "Ghi chú", typeof(string)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdateUser", "Người cập nhật", typeof(int), "Id", typeof(User)));
                //searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.USER.ToUpper())
            {
                uctListBase.TableName = Constant_Table.USER;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("Name", "Tên", typeof(int)));
                searchConditions.Add(new SearchExpander("UserName", "Tên đăng nhập", typeof(int)));
                searchConditions.Add(new SearchExpander("Active", "Active", typeof(bool)));
                //searchConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctListBase.SearchConditions = searchConditions;
            }
            else //Do nothing
            {
            }
        }


    }
}