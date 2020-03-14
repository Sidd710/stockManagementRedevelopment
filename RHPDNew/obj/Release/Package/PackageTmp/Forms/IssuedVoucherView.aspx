<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="IssuedVoucherView.aspx.cs" Inherits="RHPDNew.Forms.IssuedVoucherView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>

    <script type="text/javascript">
        function print_page() {
            var btnprints = document.getElementById("btnprints");
            btnprints.style.visibility = "hidden";

            var btnIssueVoucher = document.getElementById("btnIssueVoucher");
            btnIssueVoucher.style.visibility = "hidden";

            window.print();

        }
    </script>
    <div class="heading-bg">
        <div class="container">
            <h1>Genrate Issue Voucher </h1>
        </div>
    </div>
    <div>
        <div class="clearfix"></div>
        <div class="container">
            <p>&nbsp;</p>
            <%--  <div style="float:right;">
              Code# <asp:Label ID="lblCode" runat="server" style="font-family:'Times New Roman';font-size:large;"></asp:Label><br />
        
            </div>--%>
            <p>&nbsp;</p>

            <div class="row">
                <div class="form-group-2" style="float:right;">
                   <%--<input type="button" value="Print this page" onclick=""/>--%>
                    <%-- <input type="button" id="btnprint" value="Print this Page" onclick="print_page()" />--%>
                    <asp:Button ID="btnprints" runat="server" Text="print"/>
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Depo Name:</label>
                    <asp:Label ID="lbldeponame"  runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row" id="unit" runat="server" visible="false">
                <div class="form-group-2">
                    <label class="col-lg-2">Unit Master: </label>
                    <asp:Label ID="lblunitname" runat="server" Text=""></asp:Label>
                </div>
            </div>


            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Vechicle No:</label>
                     <asp:Label ID="lblVechicleNo" runat="server" Text=""></asp:Label>
                </div>
            </div>


            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Authority :</label>
                    <asp:Label ID="lblAuthority" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Through:</label>
                    <asp:Label ID="lblThrough" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <telerik:RadGrid runat="server" ID="radStockTransferByIndent" Width="100%" AutoGenerateColumns="False" AllowPaging="true"
                AllowAutomaticUpdate="false" AllowFilteringByColumn="false" Skin="Web20">
                <MasterTableView DataKeyNames="indentid" Caption="Pending Voucher Products" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="8" AllowAutomaticUpdates="false">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                    <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" CssClass="myExcelbtn" />
                    </CommandItemTemplate>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Commodity" DataField="productname" DataType="System.String" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("productname")%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="A/U" DataField="AUnitName" DataType="System.String"  Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblAUnitName" runat="server" Text='<%#Convert.ToString(Eval("AuUnitName"))==""?"N/A":Eval("AuUnitName")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Qty" DataField="qty" DataType="System.Decimal" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("qty")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="DOM" DataField="domdate" DataType="System.DateTime" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">

                                    <asp:Label ID="lblManufautureDate" runat="server" Text='<%# Convert.ToDateTime(Eval("MFGDate")).ToString("dd MMM yyyy") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="ESL" DataField="esldate" DataType="System.DateTime" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblesldate" runat="server" Text='<%# Convert.ToDateTime(Eval("esldate")).ToString("dd MMM yyyy") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>

            </telerik:RadGrid>
        </div>
    </div>
</asp:Content>
