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
        if (uctDetail.HeaderConditions != null)
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
        
    }
}