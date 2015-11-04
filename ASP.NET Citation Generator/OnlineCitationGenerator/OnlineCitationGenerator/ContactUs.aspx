<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="OnlineCitationGenerator.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="5000">
            </asp:Timer>
            <br />
            <asp:Label ID="lblShoutBox" runat="server" 
                Text="There is currently no comments... "></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:Label ID="lblVisitCustomize" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Comment: "></asp:Label>
    <asp:TextBox ID="txtComment" runat="server" Rows="1"></asp:TextBox>
    
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
    ControlToValidate="txtComment" CssClass="validator" Display="Dynamic" 
    ErrorMessage="The Comment Field is required. ">*</asp:RequiredFieldValidator>
<br />
<asp:Button ID="btnAddMsg" runat="server" onclick="btnAddMsg_Click" 
    Text="Add Message" />
<br />
<asp:Label ID="lblLogin" runat="server" CssClass="validator"></asp:Label>
    
</asp:Content>
