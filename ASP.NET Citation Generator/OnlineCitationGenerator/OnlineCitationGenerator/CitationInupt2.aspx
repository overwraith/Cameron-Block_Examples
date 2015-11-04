<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CitationInupt2.aspx.cs" Inherits="OnlineCitationGenerator.CitationInupt2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
            &nbsp;</h1>
        <h1>
            APA Citation generator</h1>
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        DeleteCommand="DELETE FROM [Book] WHERE [refID] = @original_refID AND [anonymous] = @original_anonymous AND [corporateAuthor] = @original_corporateAuthor AND (([publicationDate] = @original_publicationDate) OR ([publicationDate] IS NULL AND @original_publicationDate IS NULL)) AND [title] = @original_title AND (([subtitle] = @original_subtitle) OR ([subtitle] IS NULL AND @original_subtitle IS NULL)) AND [City] = @original_City AND (([State] = @original_State) OR ([State] IS NULL AND @original_State IS NULL)) AND [publisher] = @original_publisher AND (([translation] = @original_translation) OR ([translation] IS NULL AND @original_translation IS NULL)) AND (([edition] = @original_edition) OR ([edition] IS NULL AND @original_edition IS NULL)) AND (([volume] = @original_volume) OR ([volume] IS NULL AND @original_volume IS NULL)) AND (([URL] = @original_URL) OR ([URL] IS NULL AND @original_URL IS NULL)) AND (([DOI] = @original_DOI) OR ([DOI] IS NULL AND @original_DOI IS NULL))" 
        InsertCommand="INSERT INTO [Book] ([anonymous], [corporateAuthor], [publicationDate], [title], [subtitle], [City], [State], [publisher], [translation], [edition], [volume], [URL], [DOI]) VALUES (@anonymous, @corporateAuthor, @publicationDate, @title, @subtitle, @City, @State, @publisher, @translation, @edition, @volume, @URL, @DOI)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [Book]" 
        UpdateCommand="UPDATE [Book] SET [anonymous] = @anonymous, [corporateAuthor] = @corporateAuthor, [publicationDate] = @publicationDate, [title] = @title, [subtitle] = @subtitle, [City] = @City, [State] = @State, [publisher] = @publisher, [translation] = @translation, [edition] = @edition, [volume] = @volume, [URL] = @URL, [DOI] = @DOI WHERE [refID] = @original_refID AND [anonymous] = @original_anonymous AND [corporateAuthor] = @original_corporateAuthor AND (([publicationDate] = @original_publicationDate) OR ([publicationDate] IS NULL AND @original_publicationDate IS NULL)) AND [title] = @original_title AND (([subtitle] = @original_subtitle) OR ([subtitle] IS NULL AND @original_subtitle IS NULL)) AND [City] = @original_City AND (([State] = @original_State) OR ([State] IS NULL AND @original_State IS NULL)) AND [publisher] = @original_publisher AND (([translation] = @original_translation) OR ([translation] IS NULL AND @original_translation IS NULL)) AND (([edition] = @original_edition) OR ([edition] IS NULL AND @original_edition IS NULL)) AND (([volume] = @original_volume) OR ([volume] IS NULL AND @original_volume IS NULL)) AND (([URL] = @original_URL) OR ([URL] IS NULL AND @original_URL IS NULL)) AND (([DOI] = @original_DOI) OR ([DOI] IS NULL AND @original_DOI IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_refID" Type="Int32" />
            <asp:Parameter Name="original_anonymous" Type="Boolean" />
            <asp:Parameter Name="original_corporateAuthor" Type="Boolean" />
            <asp:Parameter DbType="Date" Name="original_publicationDate" />
            <asp:Parameter Name="original_title" Type="String" />
            <asp:Parameter Name="original_subtitle" Type="String" />
            <asp:Parameter Name="original_City" Type="String" />
            <asp:Parameter Name="original_State" Type="String" />
            <asp:Parameter Name="original_publisher" Type="String" />
            <asp:Parameter Name="original_translation" Type="Boolean" />
            <asp:Parameter Name="original_edition" Type="Int32" />
            <asp:Parameter Name="original_volume" Type="Int32" />
            <asp:Parameter Name="original_URL" Type="String" />
            <asp:Parameter Name="original_DOI" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="anonymous" />
            <asp:Parameter Name="corporateAuthor" />
            <asp:Parameter Name="publicationDate" />
            <asp:Parameter Name="title" />
            <asp:Parameter Name="subtitle" />
            <asp:Parameter Name="City" />
            <asp:Parameter Name="State" />
            <asp:Parameter Name="publisher" />
            <asp:Parameter Name="translation" />
            <asp:Parameter Name="edition" />
            <asp:Parameter Name="volume" />
            <asp:Parameter Name="URL" />
            <asp:Parameter Name="DOI" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="anonymous" Type="Boolean" />
            <asp:Parameter Name="corporateAuthor" Type="Boolean" />
            <asp:Parameter DbType="Date" Name="publicationDate" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="subtitle" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="State" Type="String" />
            <asp:Parameter Name="publisher" Type="String" />
            <asp:Parameter Name="translation" Type="Boolean" />
            <asp:Parameter Name="edition" Type="Int32" />
            <asp:Parameter Name="volume" Type="Int32" />
            <asp:Parameter Name="URL" Type="String" />
            <asp:Parameter Name="DOI" Type="String" />
            <asp:Parameter Name="original_refID" Type="Int32" />
            <asp:Parameter Name="original_anonymous" Type="Boolean" />
            <asp:Parameter Name="original_corporateAuthor" Type="Boolean" />
            <asp:Parameter DbType="Date" Name="original_publicationDate" />
            <asp:Parameter Name="original_title" Type="String" />
            <asp:Parameter Name="original_subtitle" Type="String" />
            <asp:Parameter Name="original_City" Type="String" />
            <asp:Parameter Name="original_State" Type="String" />
            <asp:Parameter Name="original_publisher" Type="String" />
            <asp:Parameter Name="original_translation" Type="Boolean" />
            <asp:Parameter Name="original_edition" Type="Int32" />
            <asp:Parameter Name="original_volume" Type="Int32" />
            <asp:Parameter Name="original_URL" Type="String" />
            <asp:Parameter Name="original_DOI" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="refID" DataSourceID="SqlDataSource1" 
        onprerender="GridView1_PreRender" 
        onselectedindexchanging="GridView1_SelectedIndexChanging">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                ShowSelectButton="True" />
            <asp:TemplateField><ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="GridViewInsert">New</asp:LinkButton></ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="refID" HeaderText="refID" InsertVisible="False" 
                ReadOnly="True" SortExpression="refID" Visible="false" />
            <asp:BoundField DataField="publicationDate" HeaderText="publicationDate" 
                SortExpression="publicationDate" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="subtitle" HeaderText="subtitle" 
                SortExpression="subtitle" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
            <asp:BoundField DataField="publisher" HeaderText="publisher" 
                SortExpression="publisher" />
            <asp:CheckBoxField DataField="translation" HeaderText="translation" 
                SortExpression="translation" />
            <asp:BoundField DataField="edition" HeaderText="edition" 
                SortExpression="edition" />
            <asp:BoundField DataField="volume" HeaderText="volume" 
                SortExpression="volume" />
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
            <asp:BoundField DataField="DOI" HeaderText="DOI" SortExpression="DOI" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        DeleteCommand="DELETE FROM [Author] WHERE [authorID] = @original_authorID AND [refID] = @original_refID AND (([fname] = @original_fname) OR ([fname] IS NULL AND @original_fname IS NULL)) AND (([mname] = @original_mname) OR ([mname] IS NULL AND @original_mname IS NULL)) AND (([lname] = @original_lname) OR ([lname] IS NULL AND @original_lname IS NULL)) AND (([suffix] = @original_suffix) OR ([suffix] IS NULL AND @original_suffix IS NULL))" 
        InsertCommand="INSERT INTO [Author] ([refID], [fname], [mname], [lname], [suffix]) VALUES (@refID, @fname, @mname, @lname, @suffix)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [Author] WHERE ([refID] = @refID)" 
        UpdateCommand="UPDATE [Author] SET [refID] = @refID, [fname] = @fname, [mname] = @mname, [lname] = @lname, [suffix] = @suffix WHERE [authorID] = @original_authorID AND [refID] = @original_refID AND (([fname] = @original_fname) OR ([fname] IS NULL AND @original_fname IS NULL)) AND (([mname] = @original_mname) OR ([mname] IS NULL AND @original_mname IS NULL)) AND (([lname] = @original_lname) OR ([lname] IS NULL AND @original_lname IS NULL)) AND (([suffix] = @original_suffix) OR ([suffix] IS NULL AND @original_suffix IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_authorID" Type="Int32" />
            <asp:Parameter Name="original_refID" Type="Int32" />
            <asp:Parameter Name="original_fname" Type="String" />
            <asp:Parameter Name="original_mname" Type="String" />
            <asp:Parameter Name="original_lname" Type="String" />
            <asp:Parameter Name="original_suffix" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="refID" Type="Int32" />
            <asp:Parameter Name="fname" Type="String" />
            <asp:Parameter Name="mname" Type="String" />
            <asp:Parameter Name="lname" Type="String" />
            <asp:Parameter Name="suffix" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="refID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="refID" Type="Int32" />
            <asp:Parameter Name="fname" Type="String" />
            <asp:Parameter Name="mname" Type="String" />
            <asp:Parameter Name="lname" Type="String" />
            <asp:Parameter Name="suffix" Type="String" />
            <asp:Parameter Name="original_authorID" Type="Int32" />
            <asp:Parameter Name="original_refID" Type="Int32" />
            <asp:Parameter Name="original_fname" Type="String" />
            <asp:Parameter Name="original_mname" Type="String" />
            <asp:Parameter Name="original_lname" Type="String" />
            <asp:Parameter Name="original_suffix" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        DeleteCommand="DELETE FROM [Editor] WHERE [editorID] = @original_editorID AND [refID] = @original_refID AND (([fname] = @original_fname) OR ([fname] IS NULL AND @original_fname IS NULL)) AND (([mname] = @original_mname) OR ([mname] IS NULL AND @original_mname IS NULL)) AND (([lname] = @original_lname) OR ([lname] IS NULL AND @original_lname IS NULL)) AND (([suffix] = @original_suffix) OR ([suffix] IS NULL AND @original_suffix IS NULL))" 
        InsertCommand="INSERT INTO [Editor] ([refID], [fname], [mname], [lname], [suffix]) VALUES (@refID, @fname, @mname, @lname, @suffix)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [Editor] WHERE ([refID] = @refID)" 
        UpdateCommand="UPDATE [Editor] SET [refID] = @refID, [fname] = @fname, [mname] = @mname, [lname] = @lname, [suffix] = @suffix WHERE [editorID] = @original_editorID AND [refID] = @original_refID AND (([fname] = @original_fname) OR ([fname] IS NULL AND @original_fname IS NULL)) AND (([mname] = @original_mname) OR ([mname] IS NULL AND @original_mname IS NULL)) AND (([lname] = @original_lname) OR ([lname] IS NULL AND @original_lname IS NULL)) AND (([suffix] = @original_suffix) OR ([suffix] IS NULL AND @original_suffix IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_editorID" Type="Int32" />
            <asp:Parameter Name="original_refID" Type="Int32" />
            <asp:Parameter Name="original_fname" Type="String" />
            <asp:Parameter Name="original_mname" Type="String" />
            <asp:Parameter Name="original_lname" Type="String" />
            <asp:Parameter Name="original_suffix" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="refID" Type="Int32" />
            <asp:Parameter Name="fname" Type="String" />
            <asp:Parameter Name="mname" Type="String" />
            <asp:Parameter Name="lname" Type="String" />
            <asp:Parameter Name="suffix" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="refID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="refID" Type="Int32" />
            <asp:Parameter Name="fname" Type="String" />
            <asp:Parameter Name="mname" Type="String" />
            <asp:Parameter Name="lname" Type="String" />
            <asp:Parameter Name="suffix" Type="String" />
            <asp:Parameter Name="original_editorID" Type="Int32" />
            <asp:Parameter Name="original_refID" Type="Int32" />
            <asp:Parameter Name="original_fname" Type="String" />
            <asp:Parameter Name="original_mname" Type="String" />
            <asp:Parameter Name="original_lname" Type="String" />
            <asp:Parameter Name="original_suffix" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <h2>Authors</h2>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="authorID" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server">New</asp:LinkButton></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="authorID" HeaderText="authorID" 
                InsertVisible="False" ReadOnly="True" SortExpression="authorID" Visible="false" />
            <asp:BoundField DataField="refID" HeaderText="refID" SortExpression="refID" Visible="false"/>
            <asp:BoundField DataField="fname" HeaderText="fname" SortExpression="fname" />
            <asp:BoundField DataField="mname" HeaderText="mname" SortExpression="mname" />
            <asp:BoundField DataField="lname" HeaderText="lname" SortExpression="lname" />
            <asp:BoundField DataField="suffix" HeaderText="suffix" 
                SortExpression="suffix" />
        </Columns>
    </asp:GridView>
    <h2>Editors</h2>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="editorID" DataSourceID="SqlDataSource3">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server">New</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="editorID" HeaderText="editorID" 
                InsertVisible="False" ReadOnly="True" SortExpression="editorID" Visible="false"/>
            <asp:BoundField DataField="refID" HeaderText="refID" SortExpression="refID" Visible="false"/>
            <asp:BoundField DataField="fname" HeaderText="fname" SortExpression="fname" />
            <asp:BoundField DataField="mname" HeaderText="mname" SortExpression="mname" />
            <asp:BoundField DataField="lname" HeaderText="lname" SortExpression="lname" />
            <asp:BoundField DataField="suffix" HeaderText="suffix" 
                SortExpression="suffix" />
        </Columns>
    </asp:GridView>
    <br />
    </form>
</body>
</html>
