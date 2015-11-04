<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProjectCS.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Login ID="Login1" runat="server" onloggedin="Login1_LoggedIn">
    </asp:Login>
    <br />
    If you haven&#39;t created an account, please go to our create user page:
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CreateUser.aspx">Create User</asp:HyperLink>
    . 
    <br />
    <br />
    If you can no longer access your account please go to our
    <asp:HyperLink ID="HyperLink2" runat="server" 
        NavigateUrl="~/PasswordRecovery.aspx">Password Recovery</asp:HyperLink>
&nbsp;page.  
</asp:Content>
