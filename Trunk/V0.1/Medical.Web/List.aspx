<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List" %>

<%@ Register src="Usercontrol/UserControlBase.ascx" tagname="UserControlBase" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:UserControlBase ID="uctListBase" runat="server" />
</asp:Content>

