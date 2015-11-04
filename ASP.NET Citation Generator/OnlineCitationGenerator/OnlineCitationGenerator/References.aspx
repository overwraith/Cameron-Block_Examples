<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="References.aspx.cs" Inherits="OnlineCitationGenerator.References" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [Reference] WHERE ([username] = @username)" 
        ConflictDetection="CompareAllValues" 
        DeleteCommand="DELETE FROM [Reference] WHERE [PaperID] = @original_PaperID AND [username] = @original_username AND [paperTitle] = @original_paperTitle" 
        InsertCommand="INSERT INTO [Reference] ([username], [paperTitle]) VALUES (@username, @paperTitle)" 
        OldValuesParameterFormatString="original_{0}" 
        UpdateCommand="UPDATE [Reference] SET [username] = @username, [paperTitle] = @paperTitle WHERE [PaperID] = @original_PaperID AND [username] = @original_username AND [paperTitle] = @original_paperTitle">
        <DeleteParameters>
            <asp:Parameter Name="original_PaperID" Type="Int32" />
            <asp:Parameter Name="original_username" Type="String" />
            <asp:Parameter Name="original_paperTitle" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="paperTitle" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="username" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="paperTitle" Type="String" />
            <asp:Parameter Name="original_PaperID" Type="Int32" />
            <asp:Parameter Name="original_username" Type="String" />
            <asp:Parameter Name="original_paperTitle" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        DeleteCommand="DELETE FROM [Reference] WHERE [PaperID] = @original_PaperID AND [username] = @original_username AND [paperTitle] = @original_paperTitle" 
        InsertCommand="INSERT INTO [Reference] ([username], [paperTitle]) VALUES (@username, @paperTitle)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [Reference] WHERE ([PaperID] = @PaperID)" 
        UpdateCommand="UPDATE [Reference] SET [username] = @username, [paperTitle] = @paperTitle WHERE [PaperID] = @original_PaperID">
        <DeleteParameters>
            <asp:Parameter Name="original_PaperID" Type="Int32" />
            <asp:Parameter Name="original_username" Type="String" />
            <asp:Parameter Name="original_paperTitle" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="paperTitle" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="PaperID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="paperTitle" Type="String" />
            <asp:Parameter Name="original_PaperID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Choose a references page to edit: "></asp:Label>
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" 
        DataSourceID="SqlDataSource1" DataTextField="paperTitle" 
        DataValueField="PaperID" AutoPostBack="True">
    </asp:DropDownList>
    <br />
    <asp:Button ID="btnEditRef" runat="server" onclick="btnEditRef_Click" 
        Text="Edit Reference" />
    <br />
    <asp:Button ID="btnPrintPage" runat="server" onclick="btnPrintPage_Click" 
        Text="Print Reference" />
    <br />
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataKeyNames="PaperID" DataSourceID="SqlDataSource2" Height="50px" 
        Width="125px">
        <Fields>
            <asp:BoundField DataField="PaperID" HeaderText="PaperID" InsertVisible="False" 
                ReadOnly="True" SortExpression="PaperID" />
            <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" 
                SortExpression="username" />
            <asp:BoundField DataField="paperTitle" HeaderText="paperTitle" 
                SortExpression="paperTitle" />
        </Fields>
    </asp:DetailsView>
    <br />
    <br />
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="PaperID" 
        DataSourceID="SqlDataSource2">
        <EditItemTemplate>
            PaperID:
            <asp:Label ID="PaperIDLabel1" runat="server" Text='<%# Eval("PaperID") %>' />
            <br />
            username:
            <asp:TextBox ID="usernameTextBox" runat="server" 
                Text='<%# Bind("username") %>' />
            <br />
            paperTitle:
            <asp:TextBox ID="paperTitleTextBox" runat="server" 
                Text='<%# Bind("paperTitle") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            username:
            <asp:TextBox ID="usernameTextBox" runat="server" 
                Text='<%# Bind("username") %>' />
            <br />
            paperTitle:
            <asp:TextBox ID="paperTitleTextBox" runat="server" 
                Text='<%# Bind("paperTitle") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            PaperID:
            <asp:Label ID="PaperIDLabel" runat="server" Text='<%# Eval("PaperID") %>' />
            <br />
            username:
            <asp:Label ID="usernameLabel" runat="server" Text='<%# Bind("username") %>' />
            <br />
            paperTitle:
            <asp:Label ID="paperTitleLabel" runat="server" 
                Text='<%# Bind("paperTitle") %>' />
            <br />

        </ItemTemplate>
    </asp:FormView>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Make a new references page: "></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Paper Title: "></asp:Label>
    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="New Ref Page" />
</asp:Content>
