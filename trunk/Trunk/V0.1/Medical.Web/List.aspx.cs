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
            else if (segment.ToUpper() == Constant_Table.FIGUREDE_TAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.FIGURE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Name", "Tên gọi", typeof(string)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICIN_EDELIVERY_DETAIL.ToUpper())
            {
                uctListBase.TableName = Constant_Table.FIGURE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Name", "Tên gọi", typeof(string)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICIN_EDELIVERY_DETAIL_ALLOCATE.ToUpper())
            {
                uctListBase.TableName = Constant_Table.FIGURE;
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Name", "Tên gọi", typeof(string)));
                uctListBase.SearchConditions = searchConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_DELIVERY.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_PLAN.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_PLAN_DETAIL.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_UNIT_PRICE.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.PATIENT.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.PATIENT_FIGURE.ToUpper())
            {
            }
            else if (segment.ToUpper() == Constant_Table.PRESCRIPTION.ToUpper())
            {
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