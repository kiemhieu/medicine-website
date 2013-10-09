<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uDetail.ascx.cs" Inherits="Usercontrol_uDetail" %>
<%@ Register Namespace="ASPnetControls" Assembly="ASPnetPagerV2_8" TagPrefix="cc" %>
<fieldset>
    <table width="100%" class="tbl">
        <asp:Repeater ID="rptConditions" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="left" style="width:200px;">
                        <%# Eval("Display") %>
                    </td>
                    <td align="left">
                        <input type="text" id='<%# Eval("ColumnName") %>' name="<%# Eval("ColumnName") %>" style="width: 100%;" value="<%#Request[(string)Eval("ColumnName")] %>"></input>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</fieldset>
<div style="padding: 5px 0px 5px 0px"></div>
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
            <cc:PagerV2_8 ID="pager" runat="server" PageSize="30" PageClause="Trang" OnCommand="pager_Command"
                BackToFirstClause="Trang đầu" BackToPageClause="Quay lại trang" FromClause="Từ"
                GoClause="tới" GoToLastClause="Trang cuối" OfClause="trên" />
        </div>
    </div>
</fieldset>
