<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewAuthor.aspx.cs" Inherits="OnlineCitationGenerator.NewAuthor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>New Author</h1>
        <asp:Label ID="Label1" runat="server" Text="First Name (initial): "></asp:Label>
        <asp:TextBox ID="txtFname" runat="server" MaxLength="1"></asp:TextBox>
        </br>
        <asp:Label ID="Label2" runat="server" Text="Middle Name (initial): "></asp:Label>
        <asp:TextBox ID="txtMname" runat="server" MaxLength="1"></asp:TextBox>
        </br>
        <asp:Label ID="Label3" runat="server" Text="Last Name: "></asp:Label>
        <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtLname" CssClass="validator" 
        ErrorMessage="Last name is a required field. ">*</asp:RequiredFieldValidator>
        </br>
        <asp:Label ID="Label4" runat="server" Text="Suffix: "></asp:Label>
        <asp:TextBox ID="txtSuffix" runat="server"></asp:TextBox>
        <br />
    <asp:Button ID="btnEnter" runat="server" onclick="btnEnter_Click" 
        Text="Enter" />
        </br>
</asp:Content>
