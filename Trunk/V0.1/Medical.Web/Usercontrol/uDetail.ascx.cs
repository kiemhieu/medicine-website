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
using System.Web.UI.HtmlControls;

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
            InitializateHeaderData();
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

            InitializateHeader();

            //Init column with name
            InitializateGridHeader();

            // Initial columns with earch table name
            InitializateGrid();

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

    private void InitializateHeader()
    {
        foreach (var segment in Request.GetFriendlyUrlSegments())
        {
            if (segment.ToUpper() == Constant_Table.FIGUREDE_DETAIL.ToUpper())
            {
                List<SearchExpander> headerConditions = new List<SearchExpander>();
                headerConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                headerConditions.Add(new SearchExpander("FigureId", "Phác đồ", typeof(int), "Id", typeof(Figure)));
                headerConditions.Add(new SearchExpander("MedicineId", "Thuốc", typeof(int), "Id", typeof(Medicine)));
                headerConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                //HeaderConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                this.HeaderConditions = headerConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_DELIVERY.ToUpper())
            {
                List<SearchExpander> HeaderConditions = new List<SearchExpander>();
                HeaderConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                HeaderConditions.Add(new SearchExpander("MedicineDeliveryId", "MedicineDeliveryId", typeof(int), "Id", "Id", typeof(MedicineDelivery)));
                HeaderConditions.Add(new SearchExpander("PrescriptionDetailId", "PrescriptionDetailId", typeof(int), "Id", "Id", typeof(PrescriptionDetail)));
                HeaderConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                HeaderConditions.Add(new SearchExpander("Volumn", "Volumn", typeof(int)));
                HeaderConditions.Add(new SearchExpander("Unit", "Unit", typeof(int)));
                HeaderConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(DateTime)));
                //HeaderConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                this.HeaderConditions = HeaderConditions;
            }
            else if (segment.ToUpper() == Constant_Table.MEDICINE_PLAN.ToUpper())
            {
                List<SearchExpander> HeaderConditions = new List<SearchExpander>();
                HeaderConditions.Add(new SearchExpander("Id", "Id", typeof(string)));
                HeaderConditions.Add(new SearchExpander("PlanId", "PlanId", typeof(int), "Id", "Id", typeof(MedicinePlan)));
                HeaderConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int), "Id", typeof(Medicine)));
                HeaderConditions.Add(new SearchExpander("InStock", "InStock", typeof(int)));
                HeaderConditions.Add(new SearchExpander("LastMonthUsage", "LastMonthUsage", typeof(int)));
                HeaderConditions.Add(new SearchExpander("CurrentMonthUsage", "CurrentMonthUsage", typeof(int)));
                HeaderConditions.Add(new SearchExpander("UnitPrice", "UnitPrice", typeof(int)));
                HeaderConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                //HeaderConditions.Add(new SearchExpander("Version", "Version", typeof(int)));
                this.HeaderConditions = HeaderConditions;
            }
            else if (segment.ToUpper() == Constant_Table.PRESCRIPTION.ToUpper())
            {
                List<SearchExpander> HeaderConditions = new List<SearchExpander>();
                HeaderConditions.Add(new SearchExpander("PatientId", "Bệnh nhân", typeof(int), "Id", typeof(Patient)));
                HeaderConditions.Add(new SearchExpander(true, "LastUpdatedDate", "Thời gian", "{0:HH:ss}", typeof(DateTime)));
                HeaderConditions.Add(new SearchExpander("DoctorId", "Bác sĩ", typeof(int), "Id", typeof(User)));
                HeaderConditions.Add(new SearchExpander("RecheckDate", "Hẹn tái khám", typeof(DateTime)));
                HeaderConditions.Add(new SearchExpander("FigureId", "Phác đồ", typeof(int), "Id", typeof(Figure)));
                this.HeaderConditions = HeaderConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE.ToUpper())
            {
                List<SearchExpander> HeaderConditions = new List<SearchExpander>();
                HeaderConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                HeaderConditions.Add(new SearchExpander("WareHouseId", "WareHouseId", typeof(int), "Id", "Id", typeof(WareHouse)));
                HeaderConditions.Add(new SearchExpander("WareHouseIODetailId", "WareHouseIODetailId", typeof(int), "Id", "Id", typeof(WareHouseIODetail)));
                HeaderConditions.Add(new SearchExpander("MedicineId", "MedicineId", typeof(int), "Id", typeof(Medicine)));
                HeaderConditions.Add(new SearchExpander("LotNo", "LotNo", typeof(string)));
                HeaderConditions.Add(new SearchExpander("ExpiredDate", "Ngày hết hạn", typeof(DateTime)));
                HeaderConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int)));
                HeaderConditions.Add(new SearchExpander("UnitPrice", "Đơn giá", typeof(string)));
                HeaderConditions.Add(new SearchExpander("LastUpdatedDate", "Ngày cập nhật", typeof(int)));
                this.HeaderConditions = HeaderConditions;
            }
            else if (segment.ToUpper() == Constant_Table.WAREHOUSE_IO.ToUpper())
            {
                List<SearchExpander> HeaderConditions = new List<SearchExpander>();
                HeaderConditions.Add(new SearchExpander("Id", "Id", typeof(int)));
                HeaderConditions.Add(new SearchExpander("WareHouseIOId", "Thủ kho", typeof(int), "Id", "Person", typeof(WareHouseIO)));
                HeaderConditions.Add(new SearchExpander("MedicineId", "Tên thuốc", typeof(int), "Id", typeof(Medicine)));
                HeaderConditions.Add(new SearchExpander("LotNo", "LotNo", typeof(string)));
                HeaderConditions.Add(new SearchExpander("ExpireDate", "Ngày hết hạn", typeof(DateTime)));
                HeaderConditions.Add(new SearchExpander("Qty", "Số lượng", typeof(int)));
                HeaderConditions.Add(new SearchExpander("UnitPrice", "Đơn giá", typeof(int)));
                HeaderConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int)));
                HeaderConditions.Add(new SearchExpander("Amount", "Số lượng", typeof(int)));
                this.HeaderConditions = HeaderConditions;
            }
            else //Do nothing
            {
            }
        }
    }

    private void InitializateGridHeader()
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
                ////searchConditions.Add(new SearchExpander("PrescriptionId", "PrescriptionId", typeof(int)));
                ////searchConditions.Add(new SearchExpander("FigureDetailId", "FigureDetailId", typeof(int), "Id", "Id", typeof(FigureDetail)));
                searchConditions.Add(new SearchExpander("MedicineId", "Tên biệt dược", typeof(int), "Id", typeof(Medicine)));
                //searchConditions.Add(new SearchExpander("", "Hoạt chất", typeof(int)));
                searchConditions.Add(new SearchExpander("Unit", "Đơn vị", typeof(int), typeof(Medicine), "Id", "Name", typeof(Define), false));
                searchConditions.Add(new SearchExpander("VolumnPerDay", "Liều lượng", typeof(int)));
                searchConditions.Add(new SearchExpander("Day", "Số ngày", typeof(int)));
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

                    if (seardcondition.PKType == typeof(DateTime))
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
                    if (seardcondition.HasLinkRef)
                    {
                        string BeetwenTableName = WebCore.GetTableName(seardcondition.Type);
                        HyperLinkField linkField = new HyperLinkField();
                        if (seardcondition.Type == null) linkField.DataNavigateUrlFields = new string[] { "ClientId", seardcondition.ColumnName };
                        else linkField.DataNavigateUrlFields = new string[] { "ClientId", BeetwenTableName + seardcondition.RefferenceColumn };
                        linkField.DataNavigateUrlFormatString = FriendlyUrl.Href("~/list").ToLower() + "/" + RefTableName.ToLower() + "/{0}/{1}";
                        linkField.HeaderText = seardcondition.Display;
                        if (seardcondition.Type == null) linkField.DataTextField = RefTableName + seardcondition.DisplayRefferenceColumn;
                        else linkField.DataTextField = RefTableName + seardcondition.DisplayRefferenceColumn;

                        if (seardcondition.DisplayRefferenceColumn.ToLower().Contains("date"))
                        {
                            linkField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            linkField.DataTextFormatString = "{0:dd/MM/yyyy}";
                        }
                        gvListData.Columns.Add(linkField);
                    }
                    else
                    {
                        BoundField linkField = new BoundField();
                        if (seardcondition.Type == null) linkField.DataField = RefTableName + seardcondition.DisplayRefferenceColumn;
                        else linkField.DataField = RefTableName + seardcondition.DisplayRefferenceColumn;
                        linkField.HeaderText = seardcondition.Display;
                        gvListData.Columns.Add(linkField);
                    }
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

    private void InitializateHeaderData()
    {
        if (string.IsNullOrEmpty(TableName)) return;

        string tableName = TableName.Replace("detail", "");

        string sSelect = "SELECT Clinic.Name AS ClinicName, [" + tableName + "].ClientID";
        string sInnerjoin = "\n INNER JOIN Clinic ON [" + tableName + "].ClientID = Clinic.Id";
        string sWhere = "\n WHERE 1=1 ";
        string sSQL = string.Empty;
        string sListFields = string.Empty;
        List<SqlParameter> parames = new List<SqlParameter>();
        int i = -1;

        if (HeaderConditions != null && !string.IsNullOrEmpty(tableName) && tableName.Length > 0)
        {
            var conditionTables = new Hashtable();
            conditionTables.Add("Clinic", "Clinic");
            foreach (SearchExpander seardcondition in HeaderConditions)
            {
                i++;
                SqlParameter param = null;
                if (seardcondition.Type == null) sSelect += ", [" + tableName + "]." + seardcondition.ColumnName;

                if (seardcondition.Refference != null)
                {
                    string BeetwenRefTableName = WebCore.GetTableName(seardcondition.Type);
                    string RefTableName = WebCore.GetTableName(seardcondition.Refference);

                    //Add column to sellect
                    if (seardcondition.Type == null) sSelect += ", [" + RefTableName + "]." + seardcondition.DisplayRefferenceColumn + " as " + RefTableName + seardcondition.DisplayRefferenceColumn;
                    else sSelect += ", [" + RefTableName + "]." + seardcondition.DisplayRefferenceColumn + " as " + RefTableName + seardcondition.DisplayRefferenceColumn;

                    //===========================================================================
                    //Join table has column refference
                    if (!conditionTables.ContainsKey(RefTableName))
                    {
                        if (seardcondition.Type == null)
                        {
                            sInnerjoin += "\n LEFT OUTER JOIN [" + RefTableName + "] ON [" + RefTableName + "]." + seardcondition.RefferenceColumn + " = [" + tableName + "]." + seardcondition.ColumnName;
                            conditionTables.Add(RefTableName, RefTableName);
                        }
                        else
                        {
                            sInnerjoin += "\n LEFT OUTER JOIN [" + RefTableName + "] ON [" + RefTableName + "]." + seardcondition.RefferenceColumn + " = [" + BeetwenRefTableName + "]." + seardcondition.ColumnName;
                            conditionTables.Add(RefTableName, RefTableName);
                        }
                    }

                }
                //Check condition
                else
                {

                }
            }
            // Check with client ID
            if (!string.IsNullOrEmpty(ClientID)) sWhere += " AND [" + tableName + "].ClientId=" + ClientId;
            if (!string.IsNullOrEmpty(Id)) sWhere += " AND [" + tableName + "].Id=" + Id;

            if (tableName == "medicineplandetail") sWhere = sWhere.Replace("medicineplanId", "PlanId");
            // Group all querry 
            sSelect += " FROM [" + tableName + "]";
            sSQL = sSelect + sInnerjoin + sWhere;

            DataSet dataset = SqlHelper.ExecuteDataset(Config.SVConnectionString, CommandType.Text, sSQL, null);
            if (this.HeaderConditions != null)
                foreach (SearchExpander searchCondition in this.HeaderConditions)
                {
                    string RefTableName = WebCore.GetTableName(searchCondition.Refference);
                    if (searchCondition.Refference != null)
                        searchCondition.Value = string.IsNullOrEmpty(searchCondition.DisplayFormat) ? dataset.Tables[0].Rows[0][RefTableName + searchCondition.DisplayRefferenceColumn] : string.Format(searchCondition.DisplayFormat, dataset.Tables[0].Rows[0][RefTableName + searchCondition.DisplayRefferenceColumn]);
                    else
                        searchCondition.Value = string.IsNullOrEmpty(searchCondition.DisplayFormat) ? dataset.Tables[0].Rows[0][searchCondition.ColumnName] : string.Format(searchCondition.DisplayFormat, dataset.Tables[0].Rows[0][searchCondition.ColumnName]);

                    if (string.IsNullOrEmpty(searchCondition.DisplayFormat) && dataset.Tables[0].Rows[0][searchCondition.ColumnName].GetType() == typeof(DateTime)) searchCondition.Value = ((DateTime)dataset.Tables[0].Rows[0][searchCondition.ColumnName]).ToString("dd/MM/yyyy") ;
                }
            this.DataBind();

            if (this.HeaderConditions != null && this.HeaderConditions.Count > 0)
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
                if (seardcondition.Type == null) sSelect += ", [" + TableName + "]." + seardcondition.ColumnName;


                if (seardcondition.Refference != null)
                {
                    string RefTableName = WebCore.GetTableName(seardcondition.Refference);
                    string BeetwenRefTableName = WebCore.GetTableName(seardcondition.Type);


                    //Add column to sellect
                    if (seardcondition.Type == null) sSelect += ", [" + RefTableName + "]." + seardcondition.DisplayRefferenceColumn + " as " + RefTableName + seardcondition.DisplayRefferenceColumn;
                    else sSelect += ", [" + RefTableName + "]." + seardcondition.DisplayRefferenceColumn + " as " + RefTableName + seardcondition.DisplayRefferenceColumn;

                    //===========================================================================
                    //Join table has column refference
                    if (!conditionTables.ContainsKey(RefTableName))
                    {
                        if (seardcondition.Type == null)
                        {
                            sInnerjoin += "\n LEFT OUTER JOIN [" + RefTableName + "] ON [" + RefTableName + "]." + seardcondition.RefferenceColumn + " = [" + TableName + "]." + seardcondition.ColumnName;
                            conditionTables.Add(RefTableName, RefTableName);
                        }
                        else
                        {
                            sInnerjoin += "\n LEFT OUTER JOIN [" + RefTableName + "] ON [" + RefTableName + "]." + seardcondition.RefferenceColumn + " = [" + BeetwenRefTableName + "]." + seardcondition.ColumnName;
                            conditionTables.Add(RefTableName, RefTableName);
                        }
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
}