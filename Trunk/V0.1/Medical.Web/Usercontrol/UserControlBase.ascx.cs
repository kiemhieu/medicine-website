using Medical.Synchronization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usercontrol_UserControlBase : System.Web.UI.UserControl
{
    public string TableName { get; set; }

    private List<SearchExpander> searchConditions;
    public List<SearchExpander> SearchConditions
    {
        get { return searchConditions; }
        set
        {
            searchConditions = value;
            if (searchConditions != null && searchConditions.Count > 0)
            {
                rptConditions.DataSource = searchConditions;
                rptConditions.DataBind();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (searchConditions != null && !string.IsNullOrEmpty(TableName) && TableName.Length > 0)
            {
                //Initial columns of grid
                BoundField tempField = new BoundField();
                tempField.HeaderText = "Phòng khám";
                tempField.DataField = "ClinicName";
                gvListData.Columns.Add(tempField);

                foreach (SearchExpander seardcondition in searchConditions)
                {
                    BoundField boundField = new BoundField();
                    boundField.DataField = seardcondition.ColumnName;
                    boundField.HeaderText = seardcondition.Display;
                    gvListData.Columns.Add(boundField);
                }

                //List Clinic in server
                string sSQL = "SELECT Id, Name from Clinic";
                DataSet dataset = SqlHelper.ExecuteDataset(Config.SVConnectionString, CommandType.Text, sSQL);

                ddlClinic.DataSource = dataset;
                ddlClinic.DataBind();
                //Initial data
            }

            LoadList();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
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
        string sSQL = "SELECT Clinic.Name AS ClinicName," + TableName + ".* FROM " + TableName + " INNER JOIN Clinic ON " + TableName + ".ClientID = Clinic.Id WHERE ";
        string sListFields = string.Empty;
        List<SqlParameter> parames = new List<SqlParameter>();
        int i = -1;

        if (searchConditions != null && !string.IsNullOrEmpty(TableName) && TableName.Length > 0)
        {
            foreach (SearchExpander seardcondition in searchConditions)
            {
                i++;
                object requesCondition = Request[seardcondition.ColumnName];
                //if (i == 0)
                //    sListFields += "[" + seardcondition.ColumnName + "]";
                //else sListFields = ", " + sListFields;
                SqlParameter param = null;
                if (i > 0) sSQL += " AND ";
                if (seardcondition.Type == typeof(string))
                {
                    sSQL += TableName + ".[" + seardcondition.ColumnName + "] LIKE '%' + @" + seardcondition.ColumnName + " + '%' ";
                    param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? string.Empty);
                }
                else
                {
                    sSQL += TableName + ".[" + seardcondition.ColumnName + "] = @" + seardcondition.ColumnName + " ";
                    param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? DBNull.Value);
                }
                parames.Add(param);
            }

            //Just show field
            //sSQL = sSQL.Replace("*", sListFields);
            DataSet dataset = SqlHelper.ExecuteDataset(Config.SVConnectionString, CommandType.Text, sSQL, parames.ToArray());
            gvListData.AutoGenerateColumns = false;
            gvListData.DataSource = dataset;
            gvListData.DataBind();
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
}