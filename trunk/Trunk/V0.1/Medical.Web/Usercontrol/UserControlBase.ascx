<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlBase.ascx.cs" Inherits="Usercontrol_UserControlBase" %>
<table width="100%">
    <tr>
        <td style="width: 200px; vertical-align: top;">
            <fieldset id="frmSeach" runat="server">
                <table width="100%" class="tbl">
                    <tr>
                        <td align="left">Tên NSD:
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:TextBox runat="server" ID="tbxTenNguoiSuDung" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">Đơn vị:
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 200px;">
                            <asp:DropDownList runat="server" ID="ddlDonVi" Width="182px">
                                <asp:ListItem Text="Chưa xác định" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">Email:
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:TextBox runat="server" ID="tbxEmail" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60px;">Khóa:
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddlKhoa">
                                <asp:ListItem Value="-1" Text="--Tất cả--"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Khóa"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Không khóa"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="btnTimKiem" OnClick="btnTimKiem_Click" Text="Tìm kiếm"></asp:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
        <td style="vertical-align: top;">
            <fieldset>
                <div style="padding: 5px 0px 5px 0px">
                    <asp:Label runat="server" ID="lblThongBaoSoLuongBanGhi"></asp:Label>
                </div>
                <asp:GridView GridLines="None" CssClass="mGrid" runat="server" Width="100%" AllowPaging="true"
                    PageSize="30" AutoGenerateColumns="false" ID="gvNguoiSuDung" PagerSettings-Visible="false"
                    OnPageIndexChanging="gvUser_PageIndexChanging" EmptyDataText="Không có dữ liệu trong danh sách"
                    OnRowCommand="gvNguoiSuDung_RowCommand" OnRowDataBound="gvNguoiSuDung_RowDataBound">
                    <EmptyDataRowStyle BorderColor="#eeeeee" BorderStyle="Solid" BorderWidth="1px" />
                    <EmptyDataTemplate>
                        Không có dữ liệu trong danh sách
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="STT" HeaderStyle-Width="30px" ItemStyle-CssClass="gridviewItemCenter">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NSD" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:TextBox runat="server" Width="99%" ID="tbxUsername" CssClass="TextBoxNoBorder"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:TextBox runat="server" Width="99%" ID="tbxEmail" CssClass="TextBoxNoBorder"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Đơn vị" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <%#GetTenDonViByNguoiSuDung(Eval("UserName").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="60px" HeaderText="Khóa" ItemStyle-CssClass="gridviewItemCenter">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lbtnLock" CommandArgument='<%#Eval("UserName")%>'
                                    CommandName="GetLock">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Họ tên">
                            <ItemTemplate>
                                <%#GetTenDayDuByUsername(Eval("Username").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ghi chú">
                            <ItemTemplate>
                                <%#GetGhiChuByUsername(Eval("Username").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Sửa" ItemStyle-CssClass="gridviewItemCenter">
                            <ItemTemplate>
                                <a onclick='javascript:HieuChinhNguoiSuDung("<%#Eval("Username")%>");'>Sửa</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="gridviewHeader"></HeaderStyle>
                    <AlternatingRowStyle CssClass="gridviewAtlItem" />
                    <RowStyle CssClass="gridviewItem" />
                </asp:GridView>
                <div style="padding-top: 5px;">
                    <asp:Button runat="server" OnClientClick='javascript:HieuChinhNguoiSuDung("");' ID="lbtnThemMoi"
                        Text="Thêm mới"></asp:Button>
                    <div style="float: right">
                        <cc:pagerv2_8 id="pager" runat="server" pagesize="30" pageclause="Trang" oncommand="pager_Command"
                            backtofirstclause="Trang đầu" backtopageclause="Quay lại trang" fromclause="Từ"
                            goclause="tới" gotolastclause="Trang cuối" ofclause="trên" />
                    </div>
                </div>
            </fieldset>
        </td>
    </tr>
</table>
