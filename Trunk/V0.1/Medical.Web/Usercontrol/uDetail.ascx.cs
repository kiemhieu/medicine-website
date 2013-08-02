using Medical.Synchronization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using Medical.Synchronization.Basic;

public partial class Usercontrol_uDetail : System.Web.UI.UserControl
{
    public string TableName { get; set; }
    public string ClientId { get; set; }
    public string Id { get; set; }
    public List<SearchExpander> SearchConditions { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Initial properties with segments
            var segments = Request.GetFriendlyUrlSegments();
            if (segments.Count == 3)
            {
                TableName = segments[0].ToLower().Replace("detail", "");
                ClientId = segments[1];
                Id = segments[2];
            }

            // Initial columns with earch table name
            if (SearchConditions != null && !string.IsNullOrEmpty(TableName) && TableName.Length > 0)
            {
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
            }

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
        if (string.IsNullOrEmpty(TableName)) return;

        Initializate();

        //Add to log table
        string sSQL = "SELECT Clinic.Name AS ClinicName,[" + TableName + "Detail].* FROM [" + TableName + "Detail] INNER JOIN Clinic ON [" + TableName + "Detail].ClientID =[Clinic].Id WHERE [" + TableName + "Detail].ClientID=" + ClientId + " And [" + TableName + "Detail]." + TableName + "Id=" + Id;
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

        DataSet dataset = SqlHelper.ExecuteDataset(Config.SVConnectionString, CommandType.Text, sSQL, new SqlParameter[] { });
        gvListData.AutoGenerateColumns = false;
        gvListData.DataSource = dataset;
        gvListData.DataBind();

        if (dataset != null && dataset.Tables.Count > 0) pager.ItemCount = dataset.Tables[0].Rows.Count;
        //}
    }

    private void Initializate()
    {
        switch (TableName)
        {
            case "figure":
                List<SearchExpander> searchConditions = new List<SearchExpander>();
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("FigureId", "Phác đồ", typeof(int), "Id", typeof(Figure)));
                searchConditions.Add(new SearchExpander("MedicineId", "Thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                break;
        }
    }
}