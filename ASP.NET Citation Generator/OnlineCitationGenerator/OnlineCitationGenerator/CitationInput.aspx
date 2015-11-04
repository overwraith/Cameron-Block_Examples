<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CitationInput.aspx.cs" Inherits="OnlineCitationGenerator.CitationInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Citation Inupt</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>APA Citation generator</h1>
    <div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Citation Type: "></asp:Label>
    &nbsp;<asp:DropDownList ID="ddl1" runat="server" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Book</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="GetBookReferences" TypeName="OnlineCitationGenerator.BookDB" 
                OldValuesParameterFormatString="original_{0}" 
                UpdateMethod="UpdateBookReferences">
                <UpdateParameters>
                    <asp:Parameter Name="original_Book" Type="Object" />
                    <asp:Parameter Name="book" Type="Object" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </p>
        <p>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAuthors" 
                TypeName="OnlineCitationGenerator.AuthorDB" UpdateMethod="UpdateAuthors">
                <UpdateParameters>
                    <asp:Parameter Name="original_Author" Type="Object" />
                    <asp:Parameter Name="author" Type="Object" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </p>
        <p>
            <asp:ListView ID="ListView1" runat="server" 
            DataSourceID="ObjectDataSource1" DataKeyNames="refID">
            <AlternatingItemTemplate>
                <span style="background-color: #FFF8DC;">refID:
                <asp:Label ID="refIDLabel" runat="server" Text='<%# Eval("refID") %>' />
                <br />
                edition:
                <asp:Label ID="editionLabel" runat="server" Text='<%# Eval("edition") %>' />
                <br />
                volume:
                <asp:Label ID="volumeLabel" runat="server" Text='<%# Eval("volume") %>' />
                <br />
                <asp:CheckBox ID="anonymousCheckBox" runat="server" 
                    Checked='<%# Eval("anonymous") %>' Enabled="false" Text="anonymous" />
                <br />
                <asp:CheckBox ID="corporateAuthorCheckBox" runat="server" 
                    Checked='<%# Eval("corporateAuthor") %>' Enabled="false" 
                    Text="corporateAuthor" />
                <br />
                <asp:CheckBox ID="translationCheckBox" runat="server" 
                    Checked='<%# Eval("translation") %>' Enabled="false" Text="translation" />
                <br />
                publicationDate:
                <asp:Label ID="publicationDateLabel" runat="server" 
                    Text='<%# Eval("publicationDate") %>' />
                <br />
                title:
                <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                <br />
                subtitle:
                <asp:Label ID="subtitleLabel" runat="server" Text='<%# Eval("subtitle") %>' />
                <br />
                city:
                <asp:Label ID="cityLabel" runat="server" Text='<%# Eval("city") %>' />
                <br />
                state:
                <asp:Label ID="stateLabel" runat="server" Text='<%# Eval("state") %>' />
                <br />
                publisher:
                <asp:Label ID="publisherLabel" runat="server" Text='<%# Eval("publisher") %>' />
                <br />
                URL:
                <asp:Label ID="URLLabel" runat="server" Text='<%# Eval("URL") %>' />
                <br />
                DOI:
                <asp:Label ID="DOILabel" runat="server" Text='<%# Eval("DOI") %>' />
                <br />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                <br />
                <br />
                </span>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <span style="background-color: #008A8C;color: #FFFFFF;">refID:
                <asp:TextBox ID="refIDTextBox" runat="server" Text='<%# Bind("refID") %>' />
                <br />
                edition:
                <asp:TextBox ID="editionTextBox" runat="server" Text='<%# Bind("edition") %>' />
                <br />
                volume:
                <asp:TextBox ID="volumeTextBox" runat="server" Text='<%# Bind("volume") %>' />
                <br />
                <asp:CheckBox ID="anonymousCheckBox" runat="server" 
                    Checked='<%# Bind("anonymous") %>' Text="anonymous" />
                <br />
                <asp:CheckBox ID="corporateAuthorCheckBox" runat="server" 
                    Checked='<%# Bind("corporateAuthor") %>' Text="corporateAuthor" />
                <br />
                <asp:CheckBox ID="translationCheckBox" runat="server" 
                    Checked='<%# Bind("translation") %>' Text="translation" />
                <br />
                publicationDate:
                <asp:TextBox ID="publicationDateTextBox" runat="server" 
                    Text='<%# Bind("publicationDate") %>' />
                <br />
                title:
                <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                <br />
                subtitle:
                <asp:TextBox ID="subtitleTextBox" runat="server" 
                    Text='<%# Bind("subtitle") %>' />
                <br />
                city:
                <asp:TextBox ID="cityTextBox" runat="server" Text='<%# Bind("city") %>' />
                <br />
                state:
                <asp:TextBox ID="stateTextBox" runat="server" Text='<%# Bind("state") %>' />
                <br />
                publisher:
                <asp:TextBox ID="publisherTextBox" runat="server" 
                    Text='<%# Bind("publisher") %>' />
                <br />
                URL:
                <asp:TextBox ID="URLTextBox" runat="server" Text='<%# Bind("URL") %>' />
                <br />
                DOI:
                <asp:TextBox ID="DOITextBox" runat="server" Text='<%# Bind("DOI") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                    Text="Update" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Cancel" />
                <br />
                <br />
                </span>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <span>No data was returned.</span>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <span style="">refID:
                <asp:TextBox ID="refIDTextBox" runat="server" Text='<%# Bind("refID") %>' />
                <br />
                edition:
                <asp:TextBox ID="editionTextBox" runat="server" Text='<%# Bind("edition") %>' />
                <br />
                volume:
                <asp:TextBox ID="volumeTextBox" runat="server" Text='<%# Bind("volume") %>' />
                <br />
                <asp:CheckBox ID="anonymousCheckBox" runat="server" 
                    Checked='<%# Bind("anonymous") %>' Text="anonymous" />
                <br />
                <asp:CheckBox ID="corporateAuthorCheckBox" runat="server" 
                    Checked='<%# Bind("corporateAuthor") %>' Text="corporateAuthor" />
                <br />
                <asp:CheckBox ID="translationCheckBox" runat="server" 
                    Checked='<%# Bind("translation") %>' Text="translation" />
                <br />
                publicationDate:
                <asp:TextBox ID="publicationDateTextBox" runat="server" 
                    Text='<%# Bind("publicationDate") %>' />
                <br />
                title:
                <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                <br />
                subtitle:
                <asp:TextBox ID="subtitleTextBox" runat="server" 
                    Text='<%# Bind("subtitle") %>' />
                <br />
                city:
                <asp:TextBox ID="cityTextBox" runat="server" Text='<%# Bind("city") %>' />
                <br />
                state:
                <asp:TextBox ID="stateTextBox" runat="server" Text='<%# Bind("state") %>' />
                <br />
                publisher:
                <asp:TextBox ID="publisherTextBox" runat="server" 
                    Text='<%# Bind("publisher") %>' />
                <br />
                URL:
                <asp:TextBox ID="URLTextBox" runat="server" Text='<%# Bind("URL") %>' />
                <br />
                DOI:
                <asp:TextBox ID="DOITextBox" runat="server" Text='<%# Bind("DOI") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                    Text="Insert" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Clear" />
                <br />
                <br />
                </span>
            </InsertItemTemplate>
            <ItemTemplate>
                <span style="background-color: #DCDCDC;color: #000000;">refID:
                <asp:Label ID="refIDLabel" runat="server" Text='<%# Eval("refID") %>' />
                <br />
                edition:
                <asp:Label ID="editionLabel" runat="server" Text='<%# Eval("edition") %>' />
                <br />
                volume:
                <asp:Label ID="volumeLabel" runat="server" Text='<%# Eval("volume") %>' />
                <br />
                <asp:CheckBox ID="anonymousCheckBox" runat="server" 
                    Checked='<%# Eval("anonymous") %>' Enabled="false" Text="anonymous" />
                <br />
                <asp:CheckBox ID="corporateAuthorCheckBox" runat="server" 
                    Checked='<%# Eval("corporateAuthor") %>' Enabled="false" 
                    Text="corporateAuthor" />
                <br />
                <asp:CheckBox ID="translationCheckBox" runat="server" 
                    Checked='<%# Eval("translation") %>' Enabled="false" Text="translation" />
                <br />
                publicationDate:
                <asp:Label ID="publicationDateLabel" runat="server" 
                    Text='<%# Eval("publicationDate") %>' />
                <br />
                title:
                <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                <br />
                subtitle:
                <asp:Label ID="subtitleLabel" runat="server" Text='<%# Eval("subtitle") %>' />
                <br />
                city:
                <asp:Label ID="cityLabel" runat="server" Text='<%# Eval("city") %>' />
                <br />
                state:
                <asp:Label ID="stateLabel" runat="server" Text='<%# Eval("state") %>' />
                <br />
                publisher:
                <asp:Label ID="publisherLabel" runat="server" Text='<%# Eval("publisher") %>' />
                <br />
                URL:
                <asp:Label ID="URLLabel" runat="server" Text='<%# Eval("URL") %>' />
                <br />
                DOI:
                <asp:Label ID="DOILabel" runat="server" Text='<%# Eval("DOI") %>' />
                <br />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                <br />
                <br />

                </span>
            </ItemTemplate>
            <LayoutTemplate>
                <div ID="itemPlaceholderContainer" runat="server" 
                    style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <span runat="server" id="itemPlaceholder" />
                </div>
                <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <span style="background-color: #008A8C;font-weight: bold;color: #FFFFFF;">refID:
                <asp:Label ID="refIDLabel" runat="server" Text='<%# Eval("refID") %>' />
                <br />
                edition:
                <asp:Label ID="editionLabel" runat="server" Text='<%# Eval("edition") %>' />
                <br />
                volume:
                <asp:Label ID="volumeLabel" runat="server" Text='<%# Eval("volume") %>' />
                <br />
                <asp:CheckBox ID="anonymousCheckBox" runat="server" 
                    Checked='<%# Eval("anonymous") %>' Enabled="false" Text="anonymous" />
                <br />
                <asp:CheckBox ID="corporateAuthorCheckBox" runat="server" 
                    Checked='<%# Eval("corporateAuthor") %>' Enabled="false" 
                    Text="corporateAuthor" />
                <br />
                <asp:CheckBox ID="translationCheckBox" runat="server" 
                    Checked='<%# Eval("translation") %>' Enabled="false" Text="translation" />
                <br />
                publicationDate:
                <asp:Label ID="publicationDateLabel" runat="server" 
                    Text='<%# Eval("publicationDate") %>' />
                <br />
                title:
                <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                <br />
                subtitle:
                <asp:Label ID="subtitleLabel" runat="server" Text='<%# Eval("subtitle") %>' />
                <br />
                city:
                <asp:Label ID="cityLabel" runat="server" Text='<%# Eval("city") %>' />
                <br />
                state:
                <asp:Label ID="stateLabel" runat="server" Text='<%# Eval("state") %>' />
                <br />
                publisher:
                <asp:Label ID="publisherLabel" runat="server" Text='<%# Eval("publisher") %>' />
                <br />
                URL:
                <asp:Label ID="URLLabel" runat="server" Text='<%# Eval("URL") %>' />
                <br />
                DOI:
                <asp:Label ID="DOILabel" runat="server" Text='<%# Eval("DOI") %>' />
                <br />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                <br />
                <br />
                </span>
            </SelectedItemTemplate>
            </asp:ListView>
        &nbsp;</p>
        <asp:ListView ID="ListView2" runat="server" DataSourceID="ObjectDataSource2">
            <AlternatingItemTemplate>
                <li style="background-color: #FFF8DC;">suffix:
                    <asp:Label ID="suffixLabel" runat="server" Text='<%# Eval("suffix") %>' />
                    <br />
                    fname:
                    <asp:Label ID="fnameLabel" runat="server" Text='<%# Eval("fname") %>' />
                    <br />
                    mname:
                    <asp:Label ID="mnameLabel" runat="server" Text='<%# Eval("mname") %>' />
                    <br />
                    lname:
                    <asp:Label ID="lnameLabel" runat="server" Text='<%# Eval("lname") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </li>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <li style="background-color: #008A8C;color: #FFFFFF;">suffix:
                    <asp:TextBox ID="suffixTextBox" runat="server" Text='<%# Bind("suffix") %>' />
                    <br />
                    fname:
                    <asp:TextBox ID="fnameTextBox" runat="server" Text='<%# Bind("fname") %>' />
                    <br />
                    mname:
                    <asp:TextBox ID="mnameTextBox" runat="server" Text='<%# Bind("mname") %>' />
                    <br />
                    lname:
                    <asp:TextBox ID="lnameTextBox" runat="server" Text='<%# Bind("lname") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                        Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Cancel" />
                </li>
            </EditItemTemplate>
            <EmptyDataTemplate>
                No data was returned.
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <li style="">suffix:
                    <asp:TextBox ID="suffixTextBox" runat="server" Text='<%# Bind("suffix") %>' />
                    <br />fname:
                    <asp:TextBox ID="fnameTextBox" runat="server" Text='<%# Bind("fname") %>' />
                    <br />mname:
                    <asp:TextBox ID="mnameTextBox" runat="server" Text='<%# Bind("mname") %>' />
                    <br />lname:
                    <asp:TextBox ID="lnameTextBox" runat="server" Text='<%# Bind("lname") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                        Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Clear" />
                </li>
            </InsertItemTemplate>
            <ItemSeparatorTemplate>
<br />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <li style="background-color: #DCDCDC;color: #000000;">suffix:
                    <asp:Label ID="suffixLabel" runat="server" Text='<%# Eval("suffix") %>' />
                    <br />
                    fname:
                    <asp:Label ID="fnameLabel" runat="server" Text='<%# Eval("fname") %>' />
                    <br />
                    mname:
                    <asp:Label ID="mnameLabel" runat="server" Text='<%# Eval("mname") %>' />
                    <br />
                    lname:
                    <asp:Label ID="lnameLabel" runat="server" Text='<%# Eval("lname") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </li>
            </ItemTemplate>
            <LayoutTemplate>
                <ul ID="itemPlaceholderContainer" runat="server" 
                    style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <li style="background-color: #008A8C;font-weight: bold;color: #FFFFFF;">suffix:
                    <asp:Label ID="suffixLabel" runat="server" Text='<%# Eval("suffix") %>' />
                    <br />
                    fname:
                    <asp:Label ID="fnameLabel" runat="server" Text='<%# Eval("fname") %>' />
                    <br />
                    mname:
                    <asp:Label ID="mnameLabel" runat="server" Text='<%# Eval("mname") %>' />
                    <br />
                    lname:
                    <asp:Label ID="lnameLabel" runat="server" Text='<%# Eval("lname") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </li>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Please select a citation type. "></asp:Label>
        </asp:Panel>
    </div>
    <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
        Text="Submit" />
    </form>
</body>
</html>
