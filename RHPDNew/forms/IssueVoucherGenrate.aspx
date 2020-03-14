<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="IssueVoucherGenrate.aspx.cs" Inherits="RHPDNew.Forms.IssueVoucherGenrate" %>

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
                <div class="form-group-2">
                    <asp:ValidationSummary ID="valSum" ValidationGroup="grp"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="form-group-2" style="float:right;">
                   <%--<input type="button" value="Print this page" onclick=""/>--%>
                    <%-- <input type="button" id="btnprint" value="Print this Page" onclick="print_page()" />--%>
                    <asp:Button ID="btnprints" runat="server" Text="print" OnClick="btnprints_Click"/>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Depo Name:</label>
                    <asp:ObjectDataSource ID="odsDepoName" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="getrecord"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlDepoName" DataSourceID="odsDepoName" Enabled="false"
                        DataTextField="Depu_Name" DataValueField="Depu_Id" AutoPostBack="true" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlDepoName" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Depo Name" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlDepoName"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row" id="unit" runat="server" visible="false">
                <div class="form-group-2">
                    <label class="col-lg-2">Unit Master: </label>
                    <asp:DropDownList ID="ddlUnitMaster" DataSourceID="odsUnitMaster" Enabled="false" DataTextField="Unit_Name" DataValueField="Unit_Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="odsUnitMaster" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="GetUnitByDID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlDepoName" PropertyName="SelectedValue" Name="dID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="rfvddlUnitMaster" ValidationGroup="grpunit" runat="server" ErrorMessage="Please Select Unit Master" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlUnitMaster"></asp:RequiredFieldValidator>

                    <%-- <asp:CustomValidator ID="cvddlUnitMaster" runat="server" ValidationGroup="grp" OnServerValidate="cvddlUnitMaster_ServerValidate" Text="Please select Unit Master" ForeColor="Red" ControlToValidate="ddlUnitMaster"></asp:CustomValidator>--%>
                </div>
            </div>


            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Vechicle No:</label>

                    <asp:TextBox ID="txtVechicleNo" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtVechicleNo"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Authority :</label>
                    <asp:TextBox ID="txtAuthority" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtAuthority" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtAuthority"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Through:</label>
                    <asp:TextBox ID="txtThrough" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtThrough" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtThrough"></asp:RequiredFieldValidator>
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
                                    <%-- <%#Eval("BatchName").ToString()==""?"N/A":Eval("BatchName") %>--%>
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


            <div class="row" style="margin-top: 10px;">
                <div class="col-lg-2"></div>
                <div class="form-group-2 col-lg-4 text-align-right">
                    <asp:Button ID="btnIssueVoucher" CssClass="btn btn-primary" Visible="false" OnClientClick="if(!confirm('Are you sure')) return false;" ValidationGroup="grp" runat="server" Text="Genrate Voucher" OnClick="btnIssueVoucher_Click" />
                    <asp:HiddenField ID="hdf" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
