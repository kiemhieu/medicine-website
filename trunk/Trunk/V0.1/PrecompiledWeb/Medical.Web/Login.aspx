<%@ page language="C#" autoeventwireup="true" inherits="user_Login, App_Web_k4vwhjc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login </title>
    <link href="Styles/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-wrap">
            <div class="wrap-login">
                <div class="banner">
                </div>
                <div class="login">
                    <div class="login-content">
                        <div class="login-head">
                        </div>
                        <div class="login-body">
                            <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false" OnAuthenticate="LoginUser_Authenticate">
                                <LayoutTemplate>
                                    <span class="failureNotification">
                                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                    </span>
                                    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                                        ValidationGroup="LoginUserValidationGroup" />
                                    <table width="340px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Tên đăng nhập</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox Width="340px" ID="UserName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    CssClass="failureNotification" ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Mật khẩu</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox Width="340px" ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    CssClass="failureNotification" ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox CssClass="chkRemember" ID="RememberMe" runat="server" />
                                                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Giữ đăng nhập</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Đăng nhập"
                                                    CssClass="btnLogin" ValidationGroup="LoginUserValidationGroup" />
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                            </asp:Login>
                        </div>
                        <div class="login-bottom">
                            <div class="login-contact">
                                <div class="contact-icon">
                                </div>
                                <div class="contact-info">
                                    Liên hệ: [Địa chỉ liên hệ]<br />
                                    Điện thoại: [Số điện thoại]<br />
                                    Email: [Email]<br />
                                    YM!: [yahoo/skype]
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer">
                <div class="footer-body">
                    <p>
                        Bản quyền.<br />
                        Dịch vọng, Cầu Giấy, Hà Nội;<br />
                        (84-4)1111110 - Fax: (84-4)22222222 - Email : medicil@medicil.com.vn<br />
                    </p>
                </div>
            </div>
        </div>
        <%--<div class="logoVDC">
    </div>
    <div class="thongtinVDC">
        Bản quyền thuộc về: Công ty điện toán và truyền số liệu - VDC. Lô IIA, làng Quốc
        tế Thăng Long, Dịch vọng, Cầu Giấy, Hà Nội; (84-4) 37930530 - Fax: (84-4) 37930501
        - Email: vdc@vdc.com.vn Sản phẩm được phát triển bởi nhóm Giải pháp phần mềm số
        2 - VSS2
    </div>--%>
    </form>
</body>
</html>
