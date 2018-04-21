<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StoreProduct.aspx.cs" Inherits="OfficeTest.StoreProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:Label runat="server" ID="lblMessage" Visible="false"></asp:Label>
    <br />
    <div class="row">
        <div class="col-md-6" style="margin-top: 20px">
             <div class="row" style="padding-bottom: 8px">
                                    <div class="col-md-4">
                                        Company Name<span style="color: #f00;">*</span>
                                        <asp:HiddenField ID="hidNewProject" runat="server" />
                                    </div>

                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtProject" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtProject"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Company Name"
                                            Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>


            <asp:Label runat="server">MRR No</asp:Label>
            <asp:TextBox runat="server" ID="txtMRRNo" CssClass="form-control" Width="400"></asp:TextBox><br />
            <asp:HiddenField ID="hdnPRCvtID" runat="server" />

            <asp:Label runat="server">Receive Date</asp:Label>
            <asp:TextBox runat="server" ID="txtRcvDate" CssClass="form-control" TextMode="Date" Width="300"></asp:TextBox><br />

            <asp:Label runat="server">Grpoup Name</asp:Label>
            <asp:DropDownList runat="server" ID="ddlBrandName" CssClass="form-control" Width="300" AutoPostBack="true" OnSelectedIndexChanged="ddlBrandName_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:HiddenField ID="hfdBrandId" runat="server" />

            <asp:Label runat="server">Product Name</asp:Label>
            <asp:DropDownList runat="server" ID="ddlProductName" CssClass="form-control" Width="300" AutoPostBack="true" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:HiddenField ID="hdfProductId" runat="server" />
            <asp:HiddenField ID="hdfprId" runat="server" />
             <asp:Label runat="server">Product Price</asp:Label>
            <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" Width="300"></asp:TextBox><br />

            <asp:Label runat="server">Receive Qty</asp:Label>
            <asp:TextBox runat="server" ID="txtRcvQty" CssClass="form-control" Width="400"></asp:TextBox><br />
            <asp:Label ID="lblUnit" runat="server" Text="" Visible="true"></asp:Label>

            <asp:Button ID="btnInsert" runat="server" Text="Add" Height="30" Width="70" OnClick="btnAdd_Click" />
            <br />

        </div>

        <div class="col-md-6" style="margin-top: 15Px">
           <asp:GridView ID="dgvProductRcv" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" runat="server" CellPadding="6" AutoGenerateColumns="false" OnRowEditing="dgvProductRcv_RowEditing">

                <Columns>
                    <asp:TemplateField HeaderText="Sl." HeaderStyle-Width="10%">
                        <ItemTemplate><%# Container.DataItemIndex +1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product_Id" Visible="false" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ProId") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="" HorizontalAlign="Center" />
                        <ItemStyle CssClass="" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" Product Name " ItemStyle-Width="150" ControlStyle-CssClass="table table-bordered">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" CssClass="form-control" Text='<%# Eval("ProductName") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="table table-stripped"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RcvQty" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblRcvQtye" runat="server" CssClass="form-control" Text='<%# Eval("RcvQty") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblUnit" runat="server" CssClass="form-control" Text='<%# Eval("UnitId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>  
                      <asp:TemplateField HeaderText=" Product Price " ItemStyle-Width="150" ControlStyle-CssClass="table table-bordered">
                        <ItemTemplate>
                            <asp:Label ID="lblOrice" runat="server" CssClass="form-control" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle CssClass="table table-stripped"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                          <asp:LinkButton Text="Edit" runat="server" CommandName="Edit" />
                          <asp:LinkButton Text="Delete" runat="server" OnClick="OnDelete" />
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:LinkButton Text="Update" runat="server" OnClick="OnUpdate" />
                          <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel" />
                      </EditItemTemplate>
                  </asp:TemplateField>      
                  <%--  <asp:TemplateField ShowHeader="False" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" Text="View" OnClick="btnView_Click"></asp:LinkButton>
                            <%--  <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return isDelete();btnDelete_Click" Text="Delete"></asp:LinkButton>--%>
                        <%--</ItemTemplate>
                    </asp:TemplateField>--%>

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
            <%-- <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-info" Text="Print" OnClick="btnPrint_Click" />--%>
        </div>
        <asp:Button runat="server" ID="btnPost" CssClass="btn btn-info" Text="Post" OnClick="btnPost_Click" />
       <%-- <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-info" Text="Print" OnClick="btnPrint_Click" />--%>


        <div>
         
        </div>
    </div>

</asp:Content>
