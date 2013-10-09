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
using System.Collections;

public partial class Usercontrol_uDetail : System.Web.UI.UserControl
{
    public string TableName { get; set; }
    public string ClientId { get; set; }
    public string Id { get; set; }
    public List<SearchExpander> DetailConditions { get; set; }

    private List<SearchExpander> headerConditions;
    public List<SearchExpander> HeaderConditions
    {
        get { return headerConditions; }
        set
        {
            headerConditions = value;
            if (headerConditions != null && headerConditions.Count > 0)
            {
                List<SearchExpander> searchcdt = new List<SearchExpander>();
                foreach (SearchExpander c in headerConditions)
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
            //Initial properties with segments
            var segments = Request.GetFriendlyUrlSegments();
            if (segments.Count == 3)
            {
                TableName = segments[0].ToLower().Replace("detail", "") + "detail";
                ClientId = segments[1];
                Id = segments[2];
            }

            //Init column with name
            Initializate();

            // Initial columns with earch table name
            InitializateGrid();

            LoadList();
        }
    }

    private void InitializateGrid()
    {
        if (DetailConditions != null && !string.IsNullOrEmpty(TableName) && TableName.Length > 0)
        {
            gvListData.PageSize = 25;
            gvListData.AllowPaging = true;
            foreach (SearchExpander seardcondition in DetailConditions)
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
        
        string sSelect = "SELECT Clinic.Name AS ClinicName, [" + TableName + "].ClientID";
        string sInnerjoin = "\n INNER JOIN Clinic ON [" + TableName + "].ClientID = Clinic.Id";
        string sWhere = "\n WHERE 1=1 ";
        string sSQL = string.Empty;
        string sListFields = string.Empty;
        List<SqlParameter> parames = new List<SqlParameter>();
        int i = -1;

        if (DetailConditions != null && !string.IsNullOrEmpty(TableName) && TableName.Length > 0)
        {
            var conditionTables = new Hashtable();
            conditionTables.Add("Clinic", "Clinic");
            foreach (SearchExpander seardcondition in DetailConditions)
            {
                i++;
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
                }
                //Check condition
                else
                {

                }
            }
            // Check with client ID
            if (!string.IsNullOrEmpty(ClientID)) sWhere += " AND [" + TableName + "].ClientId=" + ClientId;
            if (!string.IsNullOrEmpty(Id)) sWhere += " AND [" + TableName + "]." + TableName.Replace("detail", "") + "Id=" + Id;

            if (TableName == "medicineplandetail") sWhere = sWhere.Replace("medicineplanId", "PlanId");
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

    private void Initializate()
    {
        List<SearchExpander> searchConditions = new List<SearchExpander>();
        switch (TableName)
        {
            case "figuredetail":
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("FigureId", "Phác đồ", typeof(int), "Id", typeof(Figure)));
                searchConditions.Add(new SearchExpander("MedicineId", "Thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                DetailConditions = searchConditions;
                break;
            case "medicinedeliverydetail":
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("PrescriptionDetailId", "PrescriptionDetailId", typeof(int), "Id", "Id", typeof(PrescriptionDetail)));
                searchConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Unit", typeof(int)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(DateTime)));
                DetailConditions = searchConditions;
                break;
            case "medicineplandetail":
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(string)));
                searchConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("InStock", "InStock", typeof(int)));
                searchConditions.Add(new SearchExpander("LastMonthUsage", "LastMonthUsage", typeof(int)));
                searchConditions.Add(new SearchExpander("CurrentMonthUsage", "CurrentMonthUsage", typeof(int)));
                searchConditions.Add(new SearchExpander("UnitPrice", "Đơn giá", typeof(int)));
                searchConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                DetailConditions = searchConditions;
                break;
            case "prescriptiondetail":
                searchConditions.Add(new SearchExpander("PrescriptionId", "PrescriptionId", typeof(int)));
                searchConditions.Add(new SearchExpander("FigureDetailId", "FigureDetailId", typeof(int), "Id", "Id", typeof(FigureDetail)));
                searchConditions.Add(new SearchExpander("MedicineId", "Thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("Day", "Số ngày", typeof(int)));
                searchConditions.Add(new SearchExpander("VolumnPerDay", "Số lần trong ngày", typeof(int)));
                searchConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                searchConditions.Add(new SearchExpander("Description", "Diễn giải", typeof(string)));
                DetailConditions = searchConditions;
                break;
            case "warehousedetail":
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                //searchConditions.Add(new SearchExpander("WareHouseId", "WareHouseId", typeof(int), "Id", "Id", typeof(WareHouse)));
                searchConditions.Add(new SearchExpander("WareHouseIODetailId", "WareHouseIODetailId", typeof(int), "Id", "Id", typeof(WareHouseIODetail)));
                searchConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("LotNo", "LotNo", typeof(string)));
                searchConditions.Add(new SearchExpander("ExpiredDate", "Ngày hết hạn", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int)));
                searchConditions.Add(new SearchExpander("UnitPrice", "Đơn giá", typeof(string)));
                searchConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(int)));
                DetailConditions = searchConditions;
                break;
            case "warehouseiodetail":
                searchConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                searchConditions.Add(new SearchExpander("WareHouseIOId", "Thủ kho", typeof(int), "Id", "Person", typeof(WareHouseIO)));
                searchConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                searchConditions.Add(new SearchExpander("LotNo", "LotNo", typeof(string)));
                searchConditions.Add(new SearchExpander("ExpireDate", "Ngày hết hạn", typeof(DateTime)));
                searchConditions.Add(new SearchExpander("Qty", "Số lượng", typeof(int)));
                searchConditions.Add(new SearchExpander("UnitPrice", "Đơn giá", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int)));
                searchConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                DetailConditions = searchConditions;
                break;
        }
    }
}