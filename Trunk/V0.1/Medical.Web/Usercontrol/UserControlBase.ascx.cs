using Medical.Synchronization;
using Medical.Synchronization.Basic;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections;
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
    private string ClientID { get; set; }
    private string Id { get; set; }
    private List<SearchExpander> searchConditions;
    public List<SearchExpander> SearchConditions
    {
        get { return searchConditions; }
        set
        {
            searchConditions = value;
            if (searchConditions != null && searchConditions.Count > 0)
            {
                List<SearchExpander> searchcdt = new List<SearchExpander>();
                foreach (SearchExpander c in searchConditions)
                {
                    if (c.BeenSearch) searchcdt.Add(c);
                }
                rptConditions.DataSource = searchcdt;
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
                var segments = Request.GetFriendlyUrlSegments();

                //===========================================================================
                //Initial columns of grid
                if (segments.Count != 3)
                {
                    //BoundField tempField = new BoundField();
                    //tempField.HeaderText = "Phòng khám";
                    //tempField.DataField = "ClinicName";
                    //gvListData.Columns.Add(tempField);
                }
                else
                {
                    tdSearch.Visible = false;
                    TableName = segments[0];
                    ClientID = segments[1];
                    Id = segments[2];
                }

                gvListData.PageSize = 25;
                gvListData.PageSize = 25;
                gvListData.AllowPaging = true;
                foreach (SearchExpander seardcondition in SearchConditions)
                {
                    //===========================================================================
                    //Bound field when not have detail & not refference
                    if (!seardcondition.HasDetail && seardcondition.Refference == null)
                    {

                        BoundField boundField = new BoundField();
                        boundField.DataField = seardcondition.ColumnName;
                        boundField.HeaderText = seardcondition.Display;

                        if (seardcondition.Type == typeof(DateTime))
                        {
                            boundField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            boundField.DataFormatString = "{0:dd/MM/yyyy}";
                            if (!string.IsNullOrEmpty(seardcondition.DisplayFormat)) boundField.DataFormatString = seardcondition.DisplayFormat;
                        }
                        gvListData.Columns.Add(boundField);
                    }
                    //===========================================================================
                    //Link field when not have detail & have refference
                    else if (!seardcondition.HasDetail && seardcondition.Refference != null)
                    {
                        string RefTableName = WebCore.GetTableName(seardcondition.Refference);
                        HyperLinkField linkField = new HyperLinkField();
                        linkField.DataNavigateUrlFields = new string[] { "ClientId", seardcondition.ColumnName };
                        linkField.DataNavigateUrlFormatString = FriendlyUrl.Href("~/list").ToLower() + "/" + RefTableName.ToLower() + "/{0}/{1}";
                        linkField.HeaderText = seardcondition.Display;
                        linkField.DataTextField = RefTableName + seardcondition.DisplayRefferenceColumn;


                        if (seardcondition.DisplayRefferenceColumn.ToLower().Contains("date"))
                        {
                            linkField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            linkField.DataTextFormatString = "{0:dd/MM/yyyy}";
                        }
                        gvListData.Columns.Add(linkField);
                    }
                    //===========================================================================
                    //Link field when have detail
                    else
                    {
                        HyperLinkField linkField = new HyperLinkField();
                        linkField.DataNavigateUrlFields = new string[] { "ClientId", "Id" };
                        linkField.DataNavigateUrlFormatString = FriendlyUrl.Href("~/detail").ToLower() + "/" + TableName.ToLower().Replace("detail", "") + "/{0}/{1}";
                        linkField.HeaderText = seardcondition.Display;
                        linkField.DataTextField = seardcondition.ColumnName;
                        gvListData.Columns.Add(linkField);
                    }
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
        string sSelect = "SELECT Clinic.Name AS ClinicName, [" + TableName + "].ClientID";
        string sInnerjoin = "\n INNER JOIN Clinic ON [" + TableName + "].ClientID = Clinic.Id";
        string sWhere = "\n WHERE Clinic.Id =" + ddlClinic.SelectedValue + " ";
        string sSQL = string.Empty;
        string sListFields = string.Empty;
        List<SqlParameter> parames = new List<SqlParameter>();
        int i = -1;

        if (searchConditions != null && !string.IsNullOrEmpty(TableName) && TableName.Length > 0)
        {
            var conditionTables = new Hashtable();
            conditionTables.Add("Clinic", "Clinic");
            foreach (SearchExpander seardcondition in searchConditions)
            {
                i++;
                object requesCondition = Request[seardcondition.ColumnName];
                SqlParameter param = null;
                sSelect += ", [" + TableName + "]." + seardcondition.ColumnName;
                if (seardcondition.Refference != null)
                {
                    string RefTableName = WebCore.GetTableName(seardcondition.Refference);
                    //Add column to sellect
                    sSelect += ", [" + RefTableName + "]." + seardcondition.DisplayRefferenceColumn + " as " + RefTableName + seardcondition.DisplayRefferenceColumn;

                    //===========================================================================
                    //Join table has column refference
                    if (!conditionTables.ContainsKey(RefTableName))
                    {
                        sInnerjoin += "\n LEFT OUTER JOIN [" + RefTableName + "] ON [" + RefTableName + "]." + seardcondition.RefferenceColumn + " = [" + TableName + "]." + seardcondition.ColumnName;
                        conditionTables.Add(RefTableName, RefTableName);
                    }

                    //===========================================================================
                    // Where if search something in search textbox
                    if (requesCondition != null && requesCondition.ToString() != string.Empty)
                    {
                        //Where condition
                        sWhere += " AND  [" + RefTableName + "]." + seardcondition.DisplayRefferenceColumn + " LIKE '%' + @" + seardcondition.ColumnName + " + '%' ";
                        //Param
                        param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? string.Empty);
                        parames.Add(param);
                    }
                }
                //Check condition
                else if (requesCondition != null && requesCondition.ToString() != string.Empty)
                {
                    // Select like when search in string type
                    if (seardcondition.Type == typeof(string))
                    {
                        sWhere += " AND " + TableName + ".[" + seardcondition.ColumnName + "] LIKE '%' + @" + seardcondition.ColumnName + " + '%' ";
                        sSQL += " AND " + TableName + ".[" + seardcondition.ColumnName + "] LIKE '%' + @" + seardcondition.ColumnName + " + '%' ";
                        param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? string.Empty);
                    }
                    //Select validate value
                    else
                    {
                        sWhere += " AND " + TableName + ".[" + seardcondition.ColumnName + "] = @" + seardcondition.ColumnName + " ";
                        sSQL += " AND " + TableName + ".[" + seardcondition.ColumnName + "] = @" + seardcondition.ColumnName + " ";
                        param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? DBNull.Value);
                    }
                    parames.Add(param);
                }
            }
            // Check with client ID
            if (!string.IsNullOrEmpty(ClientID)) sWhere += " AND [" + TableName + "].ClientId=" + ClientID;
            if (!string.IsNullOrEmpty(Id)) sWhere += " AND [" + TableName + "].Id=" + Id;

            // Group all querry 
            sSelect += " FROM [" + TableName + "]";
            sSQL = sSelect + sInnerjoin + sWhere;
            DataSet dataset = SqlHelper.ExecuteDataset(Config.SVConnectionString, CommandType.Text, sSQL, parames.ToArray());
            gvListData.AutoGenerateColumns = false;
            gvListData.DataSource = dataset;
            gvListData.DataBind();

            if (dataset != null && dataset.Tables.Count > 0) pager.ItemCount = dataset.Tables[0].Rows.Count;
        }
    }

    /// <summary>
    /// Page command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void pager_Command(object sender, CommandEventArgs e)
    {
        int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
        pager.CurrentIndex = currnetPageIndx;
        this.gvListData.PageIndex = currnetPageIndx - 1;
        LoadList();
    }

    /// <summary>
    /// Change paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvListData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadList();
    }

    protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadList();
    }
}