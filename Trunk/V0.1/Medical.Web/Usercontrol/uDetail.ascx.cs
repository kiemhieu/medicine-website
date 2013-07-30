using Medical.Synchronization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usercontrol_uDetail : System.Web.UI.UserControl
{
    public string TableName { get; set; }
    public string ClientId { get; set; }
    public string Id { get; set; }
    public List<SearchExpander> SearchConditionsId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadList();
        }
    }

    public void pager_Command(object sender, CommandEventArgs e)
    {
        int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
        pager.CurrentIndex = currnetPageIndx;
        this.gvListData.PageIndex = currnetPageIndx - 1;
        LoadList();
    }

    protected void gvListData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadList();
    }


    private void LoadList()
    {

        //SELECT    Clinic.Name AS ClinicName, Figure.ClientID, dbo.Figure.Id, dbo.Figure.Name, dbo.Figure.ClinicId, dbo.Figure.Description, dbo.Figure.LastUpdatedDate, 
        //          dbo.Figure.LastUpdatedUser, dbo.Figure.Version
        //FROM      dbo.Figure INNER JOIN
        //          dbo.Clinic ON dbo.Figure.ClientID = dbo.Clinic.Id

        //Add to log table
        string sSQL = "SELECT Clinic.Name AS ClinicName,[" + TableName + "].* FROM [" + TableName + "] INNER JOIN Clinic ON [" + TableName + "].ClientID =[Clinic].Id WHERE [" + TableName + "].ClientID=" + ClientId + " And [" + TableName + "].Id=" + Id;
        string sListFields = string.Empty;
        //List<SqlParameter> parames = new List<SqlParameter>();
        //int i = -1;

        //if (searchConditions != null && !string.IsNullOrEmpty(TableName) && TableName.Length > 0)
        //{
        //    foreach (SearchExpander seardcondition in searchConditions)
        //    {
        //        i++;
        //        object requesCondition = Request[seardcondition.ColumnName];
        //        SqlParameter param = null;
        //        if (requesCondition != null && requesCondition != string.Empty)
        //        {
        //            if (seardcondition.Type == typeof(string))
        //            {
        //                sSQL += " AND " + TableName + ".[" + seardcondition.ColumnName + "] LIKE '%' + @" + seardcondition.ColumnName + " + '%' ";
        //                param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? string.Empty);
        //            }
        //            else
        //            {
        //                sSQL += " AND " + TableName + ".[" + seardcondition.ColumnName + "] = @" + seardcondition.ColumnName + " ";
        //                param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? DBNull.Value);
        //            }
        //            parames.Add(param);
        //        }
        //    }

        DataSet dataset = SqlHelper.ExecuteDataset(Config.SVConnectionString, CommandType.Text, sSQL, new SqlParameter[]{});
        gvListData.AutoGenerateColumns = true;
        gvListData.DataSource = dataset;
        gvListData.DataBind();

        if (dataset != null && dataset.Tables.Count > 0) pager.ItemCount = dataset.Tables[0].Rows.Count;
        //}
    }
}