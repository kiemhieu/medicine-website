using Medical.Synchronization;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Usercontrol_uMenu : System.Web.UI.UserControl
{
    Hashtable htCheckMenu = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {

        InsertParentItem();
    }

    public void InsertChildItem(RadMenuItem chucNangCha)
    {
        RadMenuItem chucNangCon1 = new RadMenuItem();
        chucNangCon1.Value = Constant_Table.FIGURE;
        chucNangCon1.Text = "Danh sách " + Constant_Table.FIGURE;
        chucNangCon1.NavigateUrl = FriendlyUrl.Href("~/list",Constant_Table.FIGURE);
        chucNangCha.Items.Add(chucNangCon1);

        RadMenuItem chucNangCon2 = new RadMenuItem();
        chucNangCon2.Value = Constant_Table.FIGUREDE_TAIL;
        chucNangCon2.Text = "Danh sách " + Constant_Table.FIGUREDE_TAIL;
        chucNangCon2.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.FIGUREDE_TAIL);
        chucNangCha.Items.Add(chucNangCon2);

        RadMenuItem chucNangCon3 = new RadMenuItem();
        chucNangCon3.Value = Constant_Table.MEDICIN_EDELIVERY_DETAIL;
        chucNangCon3.Text = "Danh sách " + Constant_Table.MEDICIN_EDELIVERY_DETAIL;
        chucNangCon3.NavigateUrl = FriendlyUrl.Href("~/list",Constant_Table.MEDICIN_EDELIVERY_DETAIL);
        chucNangCha.Items.Add(chucNangCon3);

        RadMenuItem chucNangCon4 = new RadMenuItem();
        chucNangCon4.Value = Constant_Table.MEDICIN_EDELIVERY_DETAIL_ALLOCATE;
        chucNangCon4.Text = "Danh sách " + Constant_Table.MEDICIN_EDELIVERY_DETAIL_ALLOCATE;
        chucNangCon4.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.MEDICIN_EDELIVERY_DETAIL_ALLOCATE);
        chucNangCha.Items.Add(chucNangCon4);

        RadMenuItem chucNangCon5 = new RadMenuItem();
        chucNangCon5.Value = Constant_Table.MEDICINE_DELIVERY;
        chucNangCon5.Text = "Danh sách " + Constant_Table.MEDICINE_DELIVERY;
        chucNangCon5.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.MEDICINE_DELIVERY);
        chucNangCha.Items.Add(chucNangCon5);

        RadMenuItem chucNangCon6 = new RadMenuItem();
        chucNangCon6.Value = Constant_Table.MEDICINE_PLAN;
        chucNangCon6.Text = "Danh sách " + Constant_Table.MEDICINE_PLAN;
        chucNangCon6.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.MEDICINE_PLAN);
        chucNangCha.Items.Add(chucNangCon6);

        RadMenuItem chucNangCon7 = new RadMenuItem();
        chucNangCon7.Value = Constant_Table.MEDICINE_PLAN_DETAIL;
        chucNangCon7.Text = "Danh sách " + Constant_Table.MEDICINE_PLAN_DETAIL;
        chucNangCon7.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.MEDICINE_PLAN_DETAIL);
        chucNangCha.Items.Add(chucNangCon7);

        RadMenuItem chucNangCon8 = new RadMenuItem();
        chucNangCon8.Value = Constant_Table.MEDICINE_UNIT_PRICE;
        chucNangCon8.Text = "Danh sách " + Constant_Table.MEDICINE_UNIT_PRICE;
        chucNangCon8.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.MEDICINE_UNIT_PRICE);
        chucNangCha.Items.Add(chucNangCon8);

        RadMenuItem chucNangCon9 = new RadMenuItem();
        chucNangCon9.Value = Constant_Table.PATIENT;
        chucNangCon9.Text = "Danh sách " + Constant_Table.PATIENT;
        chucNangCon9.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.PATIENT);
        chucNangCha.Items.Add(chucNangCon9);

        RadMenuItem chucNangCon10 = new RadMenuItem();
        chucNangCon10.Value = Constant_Table.PATIENT_FIGURE;
        chucNangCon10.Text = "Danh sách " + Constant_Table.PATIENT_FIGURE;
        chucNangCon10.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.PATIENT_FIGURE);
        chucNangCha.Items.Add(chucNangCon10);

        RadMenuItem chucNangCon11 = new RadMenuItem();
        chucNangCon11.Value = Constant_Table.PRESCRIPTION;
        chucNangCon11.Text = "Danh sách " + Constant_Table.PRESCRIPTION;
        chucNangCon11.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.PRESCRIPTION);
        chucNangCha.Items.Add(chucNangCon11);

        RadMenuItem chucNangCon12 = new RadMenuItem();
        chucNangCon12.Value = Constant_Table.PRESCRIPTION_DETAIL;
        chucNangCon12.Text = "Danh sách " + Constant_Table.PRESCRIPTION_DETAIL;
        chucNangCon12.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.PRESCRIPTION_DETAIL);
        chucNangCha.Items.Add(chucNangCon12);

        RadMenuItem chucNangCon13 = new RadMenuItem();
        chucNangCon13.Value = Constant_Table.WAREHOUSE;
        chucNangCon13.Text = "Danh sách " + Constant_Table.WAREHOUSE;
        chucNangCon13.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.WAREHOUSE);
        chucNangCha.Items.Add(chucNangCon13);

        RadMenuItem chucNangCon14 = new RadMenuItem();
        chucNangCon14.Value = Constant_Table.WAREHOUSE_DETAIL;
        chucNangCon14.Text = "Danh sách " + Constant_Table.WAREHOUSE_DETAIL;
        chucNangCon14.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.WAREHOUSE_DETAIL);
        chucNangCha.Items.Add(chucNangCon14);

        RadMenuItem chucNangCon15 = new RadMenuItem();
        chucNangCon15.Value = Constant_Table.WAREHOUSE_EXPORT_ALLOCATE;
        chucNangCon15.Text = "Danh sách " + Constant_Table.WAREHOUSE_EXPORT_ALLOCATE;
        chucNangCon15.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.WAREHOUSE_EXPORT_ALLOCATE);
        chucNangCha.Items.Add(chucNangCon15);

        RadMenuItem chucNangCon16 = new RadMenuItem();
        chucNangCon16.Value = Constant_Table.WAREHOUSE_IO;
        chucNangCon16.Text = "Danh sách " + Constant_Table.WAREHOUSE_IO;
        chucNangCon16.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.WAREHOUSE_IO);
        chucNangCha.Items.Add(chucNangCon16);

        RadMenuItem chucNangCon17 = new RadMenuItem();
        chucNangCon17.Value = Constant_Table.WAREHOUSE_IO_DETAIL;
        chucNangCon17.Text = "Danh sách " + Constant_Table.WAREHOUSE_IO_DETAIL;
        chucNangCon17.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.WAREHOUSE_IO_DETAIL);
        chucNangCha.Items.Add(chucNangCon17);

        RadMenuItem chucNangCon18 = new RadMenuItem();
        chucNangCon18.Value = Constant_Table.WAREHOUSE_MINIMUM_ALLOW;
        chucNangCon18.Text = "Danh sách " + Constant_Table.WAREHOUSE_MINIMUM_ALLOW;
        chucNangCon18.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.WAREHOUSE_MINIMUM_ALLOW);
        chucNangCha.Items.Add(chucNangCon18);

        //RadMenuItem chucNangCon = new RadMenuItem();
        //chucNangCon.Value = Constant_Table.FIGURE;
        //chucNangCon.Text = "Danh sách " + Constant_Table.FIGURE;
        //chucNangCon.NavigateUrl = FriendlyUrl.Href("~/list", Constant_Table.FIGURE);
        //chucNangCha.Items.Add(chucNangCon);
        //}
        htCheckMenu.Clear();
        htCheckMenu = null;
    }

    public void InsertParentItem()
    {
        this.menuTop.Items.Clear();
        //ChucNang cn = new ChucNang();
        //DataSet ds = cn.GetChucNangByUser(Page.User.Identity.Name);
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        RadMenuItem chucNang = new RadMenuItem();
        chucNang.Value = "1";
        chucNang.Text = "Các danh mục";
        chucNang.NavigateUrl = "";
        this.menuTop.Items.Add(chucNang);
        InsertChildItem(chucNang);

        //foreach (DataRow dr in ds.Tables[0].Rows)
        //{
        //    if (htCheckMenu.Contains(dr["ChucNangId"])) continue;
        //    else htCheckMenu.Add(dr["ChucNangId"], dr["ChucNangId"]);

        //    if (int.Parse(dr["ChucNangChaId"].ToString()) == -1)
        //    {
        //        RadMenuItem chucNang = new RadMenuItem();
        //        chucNang.Value = dr["ChucNangId"].ToString();
        //        chucNang.Text = dr["TenChucNang"].ToString();
        //        chucNang.NavigateUrl = dr["LienKet"].ToString();
        //        this.menuTop.Items.Add(chucNang);
        //        InsertChildItem(chucNang, ds.Tables[0]);
        //    }
        //}
        //}

        if (htCheckMenu != null)
        {
            htCheckMenu.Clear();
            htCheckMenu = null;
        }
    }
}
