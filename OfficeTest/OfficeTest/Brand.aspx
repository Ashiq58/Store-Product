<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Brand.aspx.cs" Inherits="OfficeTest.Brand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
    <asp:Label runat="server" ID="lblMessage" Visible="false"></asp:Label>
    <br />
    <div class="col-md-6" style="margin-top:20px">

        <asp:Label runat="server">Brand Name</asp:Label>
        <asp:TextBox runat="server" ID="txtBrandName" CssClass="form-control"></asp:TextBox><br />

        <asp:HiddenField ID="hdnBrantID" runat="server" />

        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info" Text="Save" OnClick="btnSave_Click" />
        <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-default" Text="Cancel" Visible="false" OnClick="btnCancel_Click" />


    </div>

    <div class="col-md-6" style="margin-top: 8px">
        <asp:GridView ID="dgvBrand" runat="server" BackColor="White" BorderColor="#E7E7FF"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Names="Calibri" Font-Size="Larger"
            GridLines="Horizontal" AutoGenerateColumns="false">

            <Columns>
                <asp:TemplateField HeaderText="Brand_Id" Visible="false" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblBrand_Id" runat="server" Text='<%# Eval("Brand_Id") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="" HorizontalAlign="Center" />
                    <ItemStyle CssClass="" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" Brand Name" ItemStyle-Width="150" ControlStyle-CssClass="table table-bordered">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" CssClass="form-control" Text='<%# Eval("Brand_Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBrandName" runat="server" CssClass="form-control" Text='<%# Eval("Brand_Name") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <ControlStyle CssClass="table table-stripped"></ControlStyle>

                    <ItemStyle Width="150px"></ItemStyle>
              </asp:TemplateField>
              <asp:TemplateField ShowHeader="False" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" Text="View" OnClick="btnView_Click"></asp:LinkButton>
                        <%--<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return isDelete();" Text="Delete"></asp:LinkButton>--%>
                    </ItemTemplate>
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
    </div>
</asp:Content>
