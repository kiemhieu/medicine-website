using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using Medical.Synchronization;
using Medical.Synchronization.Basic;

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
                    //HeaderConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                    //HeaderConditions.Add(new SearchExpander("PrescriptionId", "PrescriptionId", typeof(int)));
                    //HeaderConditions.Add(new SearchExpander("FigureDetailId", "FigureDetailId", typeof(int)));
                    HeaderConditions.Add(new SearchExpander("MedicineId", "Tên biệt dược", typeof(int), "Id", typeof(Medicine)));
                    //HeaderConditions.Add(new SearchExpander("TradeName","TradeName",typeof(int)));
                    //HeaderConditions.Add(new SearchExpander("UnitName", "TradeName", typeof(int)));
                    HeaderConditions.Add(new SearchExpander("VolumnPerDay", "Liều lượng", typeof(int)));
                    HeaderConditions.Add(new SearchExpander("Day", "Số ngày", typeof(int)));
                    HeaderConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                    HeaderConditions.Add(new SearchExpander("Description", "Tình trạng", typeof(string)));
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
}