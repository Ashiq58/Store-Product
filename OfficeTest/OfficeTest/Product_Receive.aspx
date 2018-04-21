<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Receive.aspx.cs" Inherits="OfficeTest.Product_Receive" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <br />
    <asp:Label runat="server" ID="lblMessage" Visible="false"></asp:Label>
    <br />
    <div class="col-md-6" style="margin-top:20px">

        <asp:Label runat="server">MRR No</asp:Label>
        <asp:TextBox runat="server" ID="txtMRRNo" CssClass="form-control"></asp:TextBox><br />
        <asp:Label runat="server">Receive Date</asp:Label>
        <asp:TextBox runat="server" ID="txtRcvDate" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox><br />
        <asp:Label runat="server">Product Name</asp:Label>
        <asp:DropDownList runat="server" ID="ddlProductName" placeholder="Product Name" CssClass="form-control" Width="280" AutoPostBack="true"></asp:DropDownList>
        <asp:Label runat="server">Receive QTY</asp:Label>
        <asp:TextBox runat="server" ID="txtRcnQTy" CssClass="form-control" placeholder="Receive Quantity " ></asp:TextBox><br />
        <br />
        <asp:HiddenField ID="hdnRcvID" runat="server" />
         
       <%-- <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info" Text="Save" OnClick="btnSave_Click" />--%>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-info" Text="Add" OnClick="btnAdd_Click" />
         <%-- <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-default" Text="Cancel" Visible="false" OnClick="btnCancel_Click" />--%>

    </div>

    <div class="col-md-6" style="margin-top: 15Px" >
        <asp:GridView ID="dgvProductRcv" runat="server" BackColor="White" BorderColor="#E7E7FF"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Names="Calibri" Font-Size="Larger"
            GridLines="Horizontal" AutoGenerateColumns="true">

            <Columns>

             <%--  <asp:TemplateField HeaderText="Product_Id" Visible="false" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblProduct_Id" runat="server" Text='<%# Eval("Product_Id") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="" HorizontalAlign="Center" />
                    <ItemStyle CssClass="" HorizontalAlign="Center" />
                </asp:TemplateField>--%>
            <%-- <asp:BoundField DataField="Product_Id"  HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Left"/>--%>
               <%-- <asp:TemplateField HeaderText="QTY" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblRcvQTy" runat="server" CssClass="form-control" Text='<%# Eval("Receive_Qty") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtRcnQTy" runat="server" CssClass="form-control" Text='<%# Eval("Receive_Qty") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>--%>
              
               <%-- <asp:TemplateField ShowHeader="False" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                     <%--   <asp:LinkButton ID="lnkView" runat="server" Text="View" OnClick="btnView_Click"></asp:LinkButton>--%>
                      <%--  <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return isDelete();btnDelete_Click" Text="Delete"></asp:LinkButton>--%>
                         
                   <%-- </ItemTemplate>
                </asp:TemplateField>--%>
                 <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"  ItemStyle-Width="150">
                    <ItemStyle Width="150px" CssClass="btn btn-default"></ItemStyle>
                </asp:CommandField>
                
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

        <asp:Button runat="server" ID="btnPost" CssClass="btn btn-info" Text="Post" OnClick="btnPost_Click"  />
    </div>




</asp:Content>
