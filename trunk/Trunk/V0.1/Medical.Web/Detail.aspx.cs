using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using Medical.Synchronization;

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
        }
    }
}