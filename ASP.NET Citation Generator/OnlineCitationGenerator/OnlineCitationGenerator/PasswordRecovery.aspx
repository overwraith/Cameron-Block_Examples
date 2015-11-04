<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="OnlineCitationGenerator.PasswordRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" 
    onsendingmail="PasswordRecovery1_SendingMail">
    <MailDefinition From="cnblock@cox.net" Subject="Password Recovery">
    </MailDefinition>
    </asp:PasswordRecovery>
<br />
<asp:Label ID="Label1" runat="server" ForeColor="Lime" 
    Text="An email has been sent to your inbox. " Visible="False"></asp:Label>
</asp:Content>
