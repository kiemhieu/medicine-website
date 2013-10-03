<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlBase.ascx.cs" Inherits="Usercontrol_UserControlBase" %>
<%@ Register Namespace="ASPnetControls" Assembly="ASPnetPagerV2_8" TagPrefix="cc" %>
<table width="100%">
    <tr>
        <td id="tdSearch" runat="server" style="width: 200px; vertical-align: top;">
            <fieldset>
                <table width="100%" class="tbl">
                    <asp:Repeater ID="rptConditions" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="left">
                                    <%# Eval("Display") %><br />
                                    <input type="text" id="<%# Eval("ColumnName") %>" name="<%# Eval("ColumnName") %>" style="width: 100%;" value="<%#Request[(string)Eval("ColumnName")] %>"></input>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="btnSearch" CssClass="btnFind" OnClick="btnSearch_Click" Text="Tìm kiếm"></asp:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
        <td style="vertical-align: top;">
            <fieldset style="margin-bottom: 10px;">
                <table width="100%" class="tbl">
                    <tr>
                        <td align="left" style="width: 80px">Phòng Khám</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlClinic" runat="server" Width="400px" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                </table>
            </fieldset>

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
        </td>
    </tr>
</table>
