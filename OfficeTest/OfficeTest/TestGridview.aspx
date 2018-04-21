<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestGridview.aspx.cs" Inherits="OfficeTest.TestGridview" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
    <div class="row">

        <div class="box col-md-12" style="width: 900px">
            <asp:GridView ID="dgvProduct" runat="server"  DataKeyNames="Product_Id"  ShowHeader="true" BackColor="White" BorderColor="#E7E7FF"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Names="Calibri" Font-Size="Larger" OnRowDeleting="GridViewItem_RowDeleting"
                GridLines="Horizontal" AutoGenerateColumns="false" OnRowCommand="GritViewItem_RowCommand"
                OnRowDataBound="GirdviewItem_RowDataBound" OnRowUpdating="GridviewItem_RowUpdating" OnRowEditing="GridViewItem_RowEditing"
                OnPageIndexChanging="GridViewItem_PageIndexChanging" OnRowCancelingEdit="GridViewItem_RowCancelingEdit" AllowPaging="true">

                <Columns>

                    <asp:TemplateField HeaderText="Product Name" HeaderStyle-Width="20%" >
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" CssClass="form-control" Text='<%# Bind("Product_Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductName" runat="server" AutoPostBack="true" CssClass="form-control" Text='<%# Bind("Product_Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate >
                            <asp:TextBox ID="txtItemNameNew" runat="server" placeholder="Product Name" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                        </HeaderTemplate>                                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Group" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="lblGroup" runat="server" CssClass="form-control" Text='<%# Bind("Brand_Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlGroup"></asp:DropDownList>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <asp:DropDownList runat="server" Width="100%" ID="ddlgroupNew"></asp:DropDownList>
                        </HeaderTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Price" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" CssClass="form-control" Text='<%# Bind("Product_Price") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductPrice" runat="server" CssClass="form-control" Text='<%# Bind("Product_Price") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <asp:TextBox runat="server" placeholder="Product Price" ID="txtpriceNew"></asp:TextBox>
                        </HeaderTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Unit" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="lblunit" runat="server" CssClass="form-control"  Text='<%# Bind("Unit") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlUnit"></asp:DropDownList>
                        </EditItemTemplate>
                        <HeaderTemplate>
                             <asp:DropDownList runat="server" Width="100%" ID="ddlUnitNew"></asp:DropDownList>
                        </HeaderTemplate>
                     
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" CssClass="form-control" Text='<%# Bind("Product_Description") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductDescription" runat="server" CssClass="form-control" Text='<%# Bind("Product_Description") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <asp:TextBox runat="server" placeholder="Product Description" ID="txtDescriptionNew"></asp:TextBox>
                        </HeaderTemplate>                   
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Option">
                        <HeaderTemplate>
                            <asp:LinkButton ID="lnkInsert" runat="server" Text="Insert" CommandName="InsertItem" ToolTip="Insert" CommandArgument=""></asp:LinkButton>
                            <asp:LinkButton ID="lnkCancl" runat="server" Text="Cancel" CommandName="Cancel" ToolTip="Cancel" CommandArgument=""></asp:LinkButton>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" CommandName="Edit" ToolTip="Edit" CommandArgument=""></asp:LinkButton>
                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" ToolTip="Delete" CommandArgument=""></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" ToolTip="Update" CommandArgument=""></asp:LinkButton>
                            <asp:LinkButton ID="lnkCancl" runat="server" Text="Cancel" CommandName="Cancel" ToolTip="Cancel" CommandArgument=""></asp:LinkButton>
                        </EditItemTemplate>
                       
                    </asp:TemplateField>


                </Columns>

                <AlternatingRowStyle BackColor="#F7F7F7" />

                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />

                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />

                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />

                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />

                <SortedAscendingCellStyle BackColor="#F4F4FD" />

                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />

                <SortedDescendingCellStyle BackColor="#D8D8F0" />

                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
            <%--<asp:Button ID="btnPost" runat="server" Text="Post" OnClick="btnPost_Click" />--%>
            <asp:Button ID="btnprint" runat="server" Text="Print All Product" OnClick="btnprint_Click" />
        </div>
        <rsweb:ReportViewer ID="ReportViewerPr" runat="server" Width="937px"></rsweb:ReportViewer>
        
       
    </div>
      </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
