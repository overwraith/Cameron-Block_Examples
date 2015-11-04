<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewBook.aspx.cs" Inherits="OnlineCitationGenerator.NewBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    </style>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>New Book</h1>
    <asp:Label ID="Label1" runat="server" Text="Publication Date: "></asp:Label>
<asp:TextBox ID="txtPubDate" runat="server"></asp:TextBox>
<asp:CompareValidator ID="CompareValidator1" runat="server" 
    ControlToValidate="txtPubDate" CssClass="validator" Display="Dynamic" 
    ErrorMessage="Cannot convert publication date to a date type. " 
    Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
<br />
<asp:Label ID="Label2" runat="server" Text="Title: "></asp:Label>
<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
    ControlToValidate="txtTitle" CssClass="validator" 
    ErrorMessage="The title field is required. ">*</asp:RequiredFieldValidator>
<br />
<asp:Label ID="Label3" runat="server" Text="Subtitle: "></asp:Label>
<asp:TextBox ID="txtSubTitle" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label4" runat="server" Text="City: "></asp:Label>
<asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
    ControlToValidate="txtCity" CssClass="validator" 
    ErrorMessage="The city field is required. ">*</asp:RequiredFieldValidator>
<br />
<asp:Label ID="Label5" runat="server" Text="State: "></asp:Label>
<asp:TextBox ID="txtState" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label6" runat="server" Text="Publisher: "></asp:Label>
<asp:TextBox ID="txtPub" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
    ControlToValidate="txtPub" CssClass="validator" 
    ErrorMessage="The publisher field is required. ">*</asp:RequiredFieldValidator>
<br />
<asp:CheckBox ID="chkTrans" runat="server" Text="Translation" />
<br />
<asp:Label ID="Label8" runat="server" Text="Edition: "></asp:Label>
<asp:TextBox ID="txtEdition" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label9" runat="server" Text="Volume: "></asp:Label>
<asp:TextBox ID="txtVolume" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label10" runat="server" Text="URL: "></asp:Label>
<asp:TextBox ID="txtURL" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label11" runat="server" Text="DOI: "></asp:Label>
<asp:TextBox ID="txtDOI" runat="server"></asp:TextBox>
<br />
<asp:Button ID="btnEnterBook" runat="server" onclick="btnEnterBook_Click" 
    Text="Enter" />
<br />
<asp:ValidationSummary ID="ValidationSummary1" runat="server" 
    CssClass="validator" />
<br />
</asp:Content>
