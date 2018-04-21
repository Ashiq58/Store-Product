<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="OfficeTest.Product" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <h1>Product Insert</h1>
            <asp:Label runat="server" ID="lblMessage" Visible="false"></asp:Label>
            <asp:Label ID="lblMsg" runat="server" CssClass="text-danger"></asp:Label><br />
            <asp:Label ID="lblSucessMsg" runat="server" CssClass="text-success"></asp:Label><br />
            <div class="col-md-12" style="margin-top: 20px">
                
                <asp:Label runat="server">Product Name</asp:Label>
                <asp:TextBox runat="server" ID="txtProductName" Width="280" CssClass="form-control"></asp:TextBox><br />
                  
                <asp:Label runat="server">Product Price</asp:Label>
                <asp:TextBox runat="server" ID="txtProductPrice" Width="280" CssClass="form-control"></asp:TextBox><br />
                    
                <asp:Label runat="server">Product Description</asp:Label>
                <asp:TextBox runat="server" ID="txtProductDescription" Width="280" CssClass="form-control"></asp:TextBox><br />
                   
                  
                <asp:HiddenField ID="hfdBrandId" runat="server" />
                <asp:CheckBox ID="chbBrand" Text="Want a new brand?" AutoPostBack="true" OnCheckedChanged="chbBrand_CheckedChanged" runat="server" /><br />
                <asp:Label runat="server">Brand</asp:Label>
                <asp:DropDownList ID="ddlBrandName" Width="280" Class="form-control" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                <asp:TextBox ID="txtBrandNameNew" Width="280" runat="server" Visible="false" class="form-control"></asp:TextBox><br />
                   
                  
                 <asp:CheckBox ID="chbUnit" Text="Want a new Unit?" AutoPostBack="true" OnCheckedChanged="chbUnit_CheckedChanged" runat="server" /><br />
                <asp:Label runat="server">Product Unit</asp:Label>
                <asp:DropDownList runat="server" ID="ddlUnit" CssClass="form-control" Width="280" AutoPostBack="true"></asp:DropDownList>
                <asp:HiddenField ID="hdnptID" runat="server" />
                <asp:HiddenField  ID="hfdUnitId" runat="server"/>
                
                 <asp:TextBox ID="txtUnitNew" Width="280" runat="server" Visible="false" class="form-control"></asp:TextBox><br />
                      
                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info" Text="Save" OnClick="btnSave_Click" />
                <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-default" Text="Cancel" Visible="false" OnClick="btnCancel_Click" />
            </div>
            <br />
            <br />
            <div class="row" style="padding-bottom: 5px; margin: 0 auto">
                <div class="col-md-12">
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0; margin-bottom: 0;"><span style="background: #fff">Product List</span></legend>
                            <br />
                            <asp:GridView ID="dgvProduct" runat="server" BorderColor="#EEE" AllowPaging="True" OnPageIndexChanging="GridViewItem_PageIndexChanging"
                                BorderStyle="None" BorderWidth="2px" CellPadding="6" Font-Names="Calibri" Font-Size="Larger"
                                GridLines="Horizontal" AutoGenerateColumns="false" Width="100%" PageSize="10">

                                <Columns>
                                    <asp:TemplateField HeaderText="Sl." HeaderStyle-Width="5%">
                                        <ItemTemplate><%# Container.DataItemIndex +1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product_Id" Visible="false" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProduct_Id" runat="server" Text='<%# Eval("Product_Id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Product Name " HeaderStyle-Width="20%" ControlStyle-CssClass="table table-bordered">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" CssClass="form-control" Text='<%# Eval("Product_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" Text='<%# Eval("Product_Name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle CssClass="table table-stripped"></ControlStyle>

                                        <%-- <ItemStyle Width="350px"></ItemStyle>--%>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Price" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" CssClass="form-control" Text='<%# Eval("Product_Price") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtProductPrice" runat="server" CssClass="form-control" Text='<%# Eval("Product_Price") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" runat="server" CssClass="form-control" Text='<%# Eval("Product_Description") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtProductDescription" runat="server" CssClass="form-control" Text='<%# Eval("Product_Description") %>'></asp:TextBox>
                                        </EditItemTemplate>

                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Brand_Name" HeaderText="Brand" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="Unit" HeaderText="Product Unit" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Left" />

                                    <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" Text="View" OnClick="btnView_Click"></asp:LinkButton>
                                            <%--  <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return isDelete();btnDelete_Click" Text="Delete"></asp:LinkButton>--%>
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
                            <%-- <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-info" Text="Print" OnClick="btnPrint_Click" />--%>
                        </fieldset>
                    </div>
                </div>
            </div>

            <div>
                <%--    <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
