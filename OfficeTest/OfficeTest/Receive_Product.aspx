<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receive_Product.aspx.cs" Inherits="OfficeTest.Receive_Product" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <br />
            <asp:Label runat="server" ID="lblMessage" Visible="false"></asp:Label>
            <br />
            <div class="row">
                <div class="col-md-6" style="margin-top: 20px">

                    <asp:Label runat="server">MRR No<span style="color: #f00;">*</span></asp:Label>
                    <asp:TextBox runat="server" ID="txtMRRNo" CssClass="form-control" Width="282px"></asp:TextBox><br />
                    <asp:HiddenField ID="hdnPRCvtID" runat="server" />
                    <asp:Label runat="server">Receive Date<span style="color: #f00;">*</span></asp:Label>
                    <asp:TextBox runat="server" ID="txtRcvDate" CssClass="form-control" TextMode="Date" Width="282px"></asp:TextBox><br />

                    <asp:Label runat="server">Grpoup Name<span style="color: #f00;">*</span></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlBrandName" CssClass="form-control" Width="282px" AutoPostBack="true" OnSelectedIndexChanged="ddlBrandName_SelectedIndexChanged"></asp:DropDownList>
                    <br />
                    <asp:HiddenField ID="hfdBrandId" runat="server" />

                    <asp:Label runat="server">Product Name<span style="color: #f00;">*</span></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlProductName" CssClass="form-control" Width="282px" AutoPostBack="true" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged"></asp:DropDownList>
                    <br />
                    <asp:HiddenField ID="hdfProductId" runat="server" />
                    <asp:HiddenField ID="hdfprId" runat="server" />
                    <asp:Label runat="server">Product Price<span style="color: #f00;">*</span></asp:Label>
                    <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" Width="282px"></asp:TextBox><br />
                    <asp:Label runat="server">Receive Qty ---  Unit:</asp:Label>
                    <asp:Label ID="lblUnit" runat="server" Text="" Visible="true" BackColor="LightSkyBlue" Font-Size="12pt"></asp:Label>
                    <asp:TextBox runat="server" ID="txtRcvQty" CssClass="form-control" Width="282px"></asp:TextBox><br />

                    <asp:Button ID="btnInsert" runat="server" BackColor="YellowGreen" Text="Add" Height="30" Width="70" OnClick="btnAdd_Click" />
                    <br />

                </div>
                <div>

                    <div class="col-md-6" style="margin-top: 15Px">
                        <asp:Label ID="lblgridmsg" runat="server" Visible="false" Text=""></asp:Label>
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

                                <asp:TemplateField ShowHeader="False" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%--  <asp:LinkButton ID="lnkView" runat="server" Text="View" OnClick="btnView_Click"></asp:LinkButton>--%>
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
                    </div>
                    <asp:Button runat="server" ID="btnPost" CssClass="btn btn-info" Text="Post" OnClick="btnPost_Click" />
                    <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-info" Text="Print" OnClick="btnPrint_Click" />

                </div>
                <div>
                    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="432px" Width="707px">
                        <LocalReport ReportPath="Report\Report1.rdlc">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
