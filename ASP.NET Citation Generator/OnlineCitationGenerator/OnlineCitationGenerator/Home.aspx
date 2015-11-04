<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TermProjectCS.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Here is some information
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/About.aspx">About</asp:HyperLink>
&nbsp;us.
    <br />
    Here is our
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CreateUser.aspx">create user</asp:HyperLink>
&nbsp;page.
    <br />
    Here is the
    <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="~/Login.aspx">Login</asp:HyperLink>
&nbsp;page.
    <br />
Here is the
<asp:HyperLink ID="HyperLink3" runat="server" 
    NavigateUrl="~/ChangePassword.aspx">Change Password</asp:HyperLink>
&nbsp;page.
    <br />
    Here is our
    <asp:HyperLink ID="HyperLink4" runat="server" 
        NavigateUrl="~/PasswordRecovery.aspx">Password Recovery</asp:HyperLink>
&nbsp;page.
    <br />
    Here is our
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/PrivacyPage.aspx">Privacy</asp:HyperLink>
&nbsp;page.
    <br />
    <br />
    After you log in you will be able to use the citation generator. 
<br />
<br />
</asp:Content>
