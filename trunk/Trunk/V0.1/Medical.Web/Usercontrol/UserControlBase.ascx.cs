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
            //Initial columns
            foreach (SearchExpander seardcondition in searchConditions)
            {
                BoundField boundField = new BoundField();
                boundField.DataField = seardcondition.ColumnName;
                boundField.HeaderText = seardcondition.Display;
                gvListData.Columns.Add(boundField);
            }

            //Initial data
            LoadList();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadList();
    }

    private void LoadList()
    {
        //Add to log table
        string sSQL = "SELECT * FROM " + TableName + " WHERE ";
        string sListFields = string.Empty;
        List<SqlParameter> parames = new List<SqlParameter>();
        int i = -1;
        foreach (SearchExpander seardcondition in searchConditions)
        {
            i++;
            object requesCondition = Request[seardcondition.ColumnName];
            //if (i == 0)
            //    sListFields += "[" + seardcondition.ColumnName + "]";
            //else sListFields = ", " + sListFields;
            SqlParameter param = null;
            if (seardcondition.Type == typeof(string))
            {
                sSQL += seardcondition.ColumnName + " LIKE '%' + @" + seardcondition.ColumnName + " + '%' ";
                param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? string.Empty);
            }
            else
            {
                sSQL += seardcondition.ColumnName + " = @" + seardcondition.ColumnName + " ";
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

        i = -1;
        foreach (SearchExpander seardcondition in searchConditions)
        {
            i++;
            gvListData.Columns[i].HeaderText = seardcondition.Display;
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