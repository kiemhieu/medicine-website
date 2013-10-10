using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using Medical.Synchronization;
using Medical.Synchronization.Basic;
using System.Data;

public partial class Detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();
            if (segments.Count != 3) return;
            var TableName = segments[0].ToUpper();
            var ClientId = segments[1];
            var Id = segments[2];
            if (TableName == Constant_Table.FIGURE.ToUpper())
            {
                uctDetail.TableName = TableName;
                uctDetail.ClientId = ClientId;
                uctDetail.Id = Id;
            }
            else if (TableName == Constant_Table.MEDICINE_DELIVERY.ToUpper())
            {
                uctDetail.TableName = TableName;
                uctDetail.ClientId = ClientId;
                uctDetail.Id = Id;
            }

            InitializeHeaderDetail();

            InitializeHeaderValues();
        }
    }

    private void InitializeHeaderValues()
    {
        IList<string> segments = Request.GetFriendlyUrlSegments();
        var TableName = segments[0].ToUpper();
        var ClientId = segments[1];
        var Id = segments[2];


        string sSQL = "SELECT * FROM [" + TableName + "] WHERE ID=" + Id.ToString();
        DataSet dataset = SqlHelper.ExecuteDataset(Config.SVConnectionString, CommandType.Text, sSQL, null);

        foreach (SearchExpander searchCondition in uctDetail.HeaderConditions)
        {
            searchCondition.Value = dataset.Tables[0].Rows[0][searchCondition.ColumnName];
            // searchCondition.ColumnName
        }

        uctDetail.DataBind();
    }

    /// <summary>
    /// Initial header of detail usercontrol
    /// </summary>
    private void InitializeHeaderDetail()
    {
        foreach (var segment in Request.GetFriendlyUrlSegments())
        {
            if (segment.ToUpper() == Constant_Table.FIGUREDE_DETAIL.ToUpper())
            {
                uctDetail.TableName = Constant_Table.FIGUREDE_DETAIL;
                List<SearchExpander> headerConditions = new List<SearchExpander>();
                headerConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                headerConditions.Add(new SearchExpander("FigureId", "Phác đồ", typeof(int), "Id", typeof(Figure)));
                headerConditions.Add(new SearchExpander("MedicineId", "Thuốc", typeof(int), "Id", typeof(Medicine)));
                headerConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                //HeaderConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctDetail.HeaderConditions = headerConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_DELIVERY.ToUpper())
            {
                List<SearchExpander> HeaderConditions = new List<SearchExpander>();
                HeaderConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                HeaderConditions.Add(new SearchExpander("MedicineDeliveryId", "MedicineDeliveryId", typeof(int), "Id", "Id", typeof(MedicineDelivery)));
                HeaderConditions.Add(new SearchExpander("PrescriptionDetailId", "PrescriptionDetailId", typeof(int), "Id", "Id", typeof(PrescriptionDetail)));
                HeaderConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                HeaderConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                HeaderConditions.Add(new SearchExpander("Unit", "Unit", typeof(int)));
                HeaderConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(DateTime)));
                //HeaderConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctDetail.HeaderConditions = HeaderConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_PLAN.ToUpper())
            {
                List<SearchExpander> HeaderConditions = new List<SearchExpander>();
                HeaderConditions.Add(new SearchExpander("Id", "Id", typeof(string)));
                HeaderConditions.Add(new SearchExpander("PlanId", "PlanId", typeof(int), "Id", "Id", typeof(MedicinePlan)));
                HeaderConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int), "Id", typeof(Medicine)));
                HeaderConditions.Add(new SearchExpander("InStock", "InStock", typeof(int)));
                HeaderConditions.Add(new SearchExpander("LastMonthUsage", "LastMonthUsage", typeof(int)));
                HeaderConditions.Add(new SearchExpander("CurrentMonthUsage", "CurrentMonthUsage", typeof(int)));
                HeaderConditions.Add(new SearchExpander("UnitPrice", "UnitPrice", typeof(int)));
                HeaderConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                //HeaderConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctDetail.HeaderConditions = HeaderConditions;
            }
            else if (segment.ToUpper() == Constant_Table.PRESCRIPTION.ToUpper())
            {
                List<SearchExpander> HeaderConditions = new List<SearchExpander>();
                HeaderConditions.Add(new SearchExpander("PatientId", "Bệnh nhân", typeof(int), "Id", typeof(Patient)));
                HeaderConditions.Add(new SearchExpander(false, "LastUpdatedDate", "Thời gian", "{0:HH:ss}", typeof(DateTime)));
                HeaderConditions.Add(new SearchExpander("DoctorId", "Bác sĩ", typeof(int), "Id", typeof(User)));
                //HeaderConditions.Add(new SearchExpander("Date", "Date", typeof(int)));
                HeaderConditions.Add(new SearchExpander(false, "RecheckDate", "Hẹn tái khám", null, typeof(DateTime)));
                HeaderConditions.Add(new SearchExpander("FigureId", "Phác đồ", typeof(int), "Id", typeof(Figure)));
                HeaderConditions.Add(new SearchExpander(false, "Note", "Tình trạng", null, typeof(object)));
                //HeaderConditions.Add(new SearchExpander("CreatedDate", "CreatedDate", typeof(DateTime)));
                //HeaderConditions.Add(new SearchExpander("LastUpdatedUser", "LastUpdatedUser", typeof(int), "Id", typeof(User)));
                //HeaderConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                uctDetail.HeaderConditions = HeaderConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE.ToUpper())
            {
                List<SearchExpander> HeaderConditions = new List<SearchExpander>();
                HeaderConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                HeaderConditions.Add(new SearchExpander("WareHouseId", "WareHouseId", typeof(int), "Id", "Id", typeof(WareHouse)));
                HeaderConditions.Add(new SearchExpander("WareHouseIODetailId", "WareHouseIODetailId", typeof(int), "Id", "Id", typeof(WareHouseIODetail)));
                HeaderConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int), "Id", typeof(Medicine)));
                HeaderConditions.Add(new SearchExpander("LotNo", "LotNo", typeof(string)));
                HeaderConditions.Add(new SearchExpander("ExpiredDate", "Ngày hết hạn", typeof(DateTime)));
                HeaderConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int)));
                HeaderConditions.Add(new SearchExpander("UnitPrice", "Đơn giá", typeof(string)));
                HeaderConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(int)));
                uctDetail.HeaderConditions = HeaderConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_IO.ToUpper())
            {
                List<SearchExpander> HeaderConditions = new List<SearchExpander>();
                HeaderConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                HeaderConditions.Add(new SearchExpander("WareHouseIOId", "Thủ kho", typeof(int), "Id", "Person", typeof(WareHouseIO)));
                HeaderConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                HeaderConditions.Add(new SearchExpander("LotNo", "LotNo", typeof(string)));
                HeaderConditions.Add(new SearchExpander("ExpireDate", "Ngày hết hạn", typeof(DateTime)));
                HeaderConditions.Add(new SearchExpander("Qty", "Số lượng", typeof(int)));
                HeaderConditions.Add(new SearchExpander("UnitPrice", "Đơn giá", typeof(int)));
                HeaderConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int)));
                HeaderConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                uctDetail.HeaderConditions = HeaderConditions;
            }
            else //Do nothing
            {
            }
        }
    }
}