<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="OnlineCitationGenerator.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ChangePassword ID="ChangePassword1" runat="server" 
    onchangedpassword="ChangePassword1_ChangedPassword" 
        oncontinuebuttonclick="ChangePassword1_ContinueButtonClick" 
        oncancelbuttonclick="ChangePassword1_CancelButtonClick">
</asp:ChangePassword>
<br />
<asp:Label ID="lblChangePass" runat="server" 
    Text="Your password has been changed. " Visible="False" ForeColor="Lime"></asp:Label>
</asp:Content>
