<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uDetail.ascx.cs" Inherits="Usercontrol_uDetail" %>
<%@ Register Namespace="ASPnetControls" Assembly="ASPnetPagerV2_8" TagPrefix="cc" %>
<fieldset>
    <div style="padding: 5px 0px 5px 0px">
        <asp:Label runat="server" ID="lblThongBaoSoLuongBanGhi"></asp:Label>
    </div>
    <asp:GridView GridLines="None" CssClass="mGrid" runat="server" Width="100%" AllowPaging="true"
        PageSize="30" AutoGenerateColumns="false" ID="gvListData" PagerSettings-Visible="false"
        OnPageIndexChanging="gvListData_PageIndexChanging" EmptyDataText="Không có dữ liệu trong danh sách">
        <EmptyDataRowStyle BorderColor="#eeeeee" BorderStyle="Solid" BorderWidth="1px" />
        <EmptyDataTemplate>
            Không có dữ liệu trong danh sách
        </EmptyDataTemplate>
        <HeaderStyle CssClass="gridviewHeader"></HeaderStyle>
        <AlternatingRowStyle CssClass="gridviewAtlItem" />
        <RowStyle CssClass="gridviewItem" />
    </asp:GridView>
    <div style="padding-top: 5px;">
        <div style="float: right">
            <cc:pagerv2_8 id="pager" runat="server" pagesize="30" pageclause="Trang" oncommand="pager_Command"
                backtofirstclause="Trang đầu" backtopageclause="Quay lại trang" fromclause="Từ"
                goclause="tới" gotolastclause="Trang cuối" ofclause="trên" />
        </div>
    </div>
</fieldset>
