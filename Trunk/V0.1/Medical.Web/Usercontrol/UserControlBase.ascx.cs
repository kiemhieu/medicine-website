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
                var segments = Request.GetFriendlyUrlSegments(); 

                //Initial columns of grid
                if (segments.Count != 3)
                {
                    BoundField tempField = new BoundField();
                    tempField.HeaderText = "Phòng khám";
                    tempField.DataField = "ClinicName";
                    gvListData.Columns.Add(tempField);
                }
                else
                {
                    tdSearch.Visible = false;

                    TableName = segments[0];
                    ClientID = segments[1];
                    Id = segments[2];
                }

                gvListData.PageSize = 25;
                gvListData.AllowPaging = true;
                foreach (SearchExpander seardcondition in searchConditions)
                {
                    if (!seardcondition.HasDetail)
                    {
                        if (seardcondition.Refference == null)
                        {
                            BoundField boundField = new BoundField();
                            boundField.DataField = seardcondition.ColumnName;
                            boundField.HeaderText = seardcondition.Display;
                            gvListData.Columns.Add(boundField);
                        }
                        else
                        {
                            string RefTableName = GetTableName(seardcondition.Refference);
                            HyperLinkField linkField = new HyperLinkField();
                            linkField.DataNavigateUrlFields = new string[] { "ClientId", seardcondition.ColumnName };
                            linkField.DataNavigateUrlFormatString = FriendlyUrl.Href("~/list").ToLower() + "/" + RefTableName.ToLower() + "/{0}/{1}";
                            linkField.HeaderText = seardcondition.Display;
                            linkField.DataTextField = RefTableName + seardcondition.DisplayRefferenceColumn;
                            gvListData.Columns.Add(linkField);
                        }
                    }
                    else
                    {
                        HyperLinkField linkField = new HyperLinkField();
                        linkField.DataNavigateUrlFields = new string[] { "ClientId", "Id" };
                        linkField.DataNavigateUrlFormatString = FriendlyUrl.Href("~/detail").ToLower() + "/" + TableName.ToLower() + "/{0}/{1}";
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

        //SELECT    Clinic.Name AS ClinicName, Figure.ClientID, dbo.Figure.Id, dbo.Figure.Name, dbo.Figure.ClinicId, dbo.Figure.Description, dbo.Figure.LastUpdatedDate, 
        //          dbo.Figure.LastUpdatedUser, dbo.Figure.Version
        //FROM      dbo.Figure INNER JOIN
        //          dbo.Clinic ON dbo.Figure.ClientID = dbo.Clinic.Id

        //Add to log table
        string sSelect = "SELECT Clinic.Name AS ClinicName, [" + TableName + "].ClientID";
        string sInnerjoin = "\n INNER JOIN Clinic ON " + TableName + ".ClientID = Clinic.Id";
        string sWhere = "\n WHERE 1=1 ";
        string sSQL = "SELECT Clinic.Name AS ClinicName," + TableName + ".* FROM " + TableName + " INNER JOIN Clinic ON " + TableName + ".ClientID = Clinic.Id WHERE 1=1 ";
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
                    string RefTableName = GetTableName(seardcondition.Refference);
                    //Add column to sellect
                    sSelect += ", [" + RefTableName + "]." + seardcondition.DisplayRefferenceColumn + " as " + RefTableName + seardcondition.DisplayRefferenceColumn;
                    //Join table has column refference
                    if (!conditionTables.ContainsKey(RefTableName))
                    {
                        sInnerjoin += "\n INNER JOIN [" + RefTableName + "] ON [" + RefTableName + "]." + seardcondition.RefferenceColumn + " = [" + TableName + "]." + seardcondition.ColumnName;
                        conditionTables.Add(RefTableName, RefTableName);
                    }
                    if (requesCondition != null && requesCondition.ToString() != string.Empty)
                    {
                        //Where condition
                        sWhere += " AND  [" + RefTableName + "]." + seardcondition.DisplayRefferenceColumn + " LIKE '%' + @" + seardcondition.ColumnName + " + '%' ";
                        //Param
                        param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? string.Empty);
                        parames.Add(param);
                    }
                }
                else if (requesCondition != null && requesCondition.ToString() != string.Empty)
                {
                    if (seardcondition.Type == typeof(string))
                    {
                        sWhere += " AND " + TableName + ".[" + seardcondition.ColumnName + "] LIKE '%' + @" + seardcondition.ColumnName + " + '%' ";
                        sSQL += " AND " + TableName + ".[" + seardcondition.ColumnName + "] LIKE '%' + @" + seardcondition.ColumnName + " + '%' ";
                        param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? string.Empty);
                    }
                    else
                    {
                        sWhere += " AND " + TableName + ".[" + seardcondition.ColumnName + "] = @" + seardcondition.ColumnName + " ";
                        sSQL += " AND " + TableName + ".[" + seardcondition.ColumnName + "] = @" + seardcondition.ColumnName + " ";
                        param = new SqlParameter("@" + seardcondition.ColumnName, requesCondition ?? DBNull.Value);
                    }
                    parames.Add(param);
                }
            }
            if (!string.IsNullOrEmpty(ClientID)) sWhere += " AND [" + TableName + "].ClientId=" + ClientID;
            if (!string.IsNullOrEmpty(Id)) sWhere += " AND [" + TableName + "].Id=" + Id;

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

    /// <summary>
    /// Get table when know refference type that base on
    /// </summary>
    /// <param name="type">Type mapping</param>
    /// <returns>Table name</returns>
    private string GetTableName(Type type)
    {
        string TableName = string.Empty;

        if (type.Name == typeof(Figure).Name)
            TableName = Constant_Table.FIGURE;
        else if (type.Name == typeof(FigureDetail).Name)
            TableName = Constant_Table.FIGUREDE_DETAIL;
        else if (type.Name == typeof(Medicine).Name)
            TableName = Constant_Table.MEDICINE;
        else if (type.Name == typeof(MedicineDelivery).Name)
            TableName = Constant_Table.MEDICINE_DELIVERY;
        else if (type.Name == typeof(MedicineDeliveryDetail).Name)
            TableName = Constant_Table.MEDICIN_DELIVERY_DETAIL;
        else if (type.Name == typeof(MedicineDeliveryDetailAllocate).Name)
            TableName = Constant_Table.MEDICIN_DELIVERY_DETAIL_ALLOCATE;
        else if (type.Name == typeof(MedicinePlan).Name)
            TableName = Constant_Table.MEDICINE_PLAN;
        else if (type.Name == typeof(MedicinePlanDetail).Name)
            TableName = Constant_Table.MEDICINE_PLAN_DETAIL;
        else if (type.Name == typeof(MedicineUnitPrice).Name)
            TableName = Constant_Table.MEDICINE_UNIT_PRICE;
        else if (type.Name == typeof(Patient).Name)
            TableName = Constant_Table.PATIENT;
        else if (type.Name == typeof(PatientFigure).Name)
            TableName = Constant_Table.PATIENT_FIGURE;
        else if (type.Name == typeof(Prescription).Name)
            TableName = Constant_Table.PRESCRIPTION;
        else if (type.Name == typeof(PrescriptionDetail).Name)
            TableName = Constant_Table.PRESCRIPTION_DETAIL;
        else if (type.Name == typeof(WareHouse).Name)
            TableName = Constant_Table.WAREHOUSE;
        else if (type.Name == typeof(WareHouseDetail).Name)
            TableName = Constant_Table.WAREHOUSE_DETAIL;
        else if (type.Name == typeof(WareHouseExportAllocate).Name)
            TableName = Constant_Table.WAREHOUSE_EXPORT_ALLOCATE;
        else if (type.Name == typeof(WareHouseIO).Name)
            TableName = Constant_Table.WAREHOUSE_IO;
        else if (type.Name == typeof(WareHouseIODetail).Name)
            TableName = Constant_Table.WAREHOUSE_IO_DETAIL;
        else if (type.Name == typeof(WareHouseMinimumAllow).Name)
            TableName = Constant_Table.WAREHOUSE_MINIMUM_ALLOW;
        else if (type.Name == typeof(User).Name)
            TableName = Constant_Table.USER;
        return TableName;
    }
}