<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintIssueVoucherNormalView.aspx.cs" Inherits="RHPDNew.StockOutPanel.PrintIssueVoucherNormalView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Club Infotech</title>
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
    <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
    <style type="text/css">
        .rgGroupCol {
            padding-left: 0 !important;
            padding-right: 0 !important;
            font-size: 1px !important;
        }

        .rgExpand,
        .rgCollapse {
            display: none !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <script type="text/javascript">
            function PrintPanel() {
                var panel = document.getElementById("<%=pnlContents.ClientID %>");
                var printWindow = window.open('', '', 'height=1000,width=1500');
                // printWindow.document.write('<html><head><title>DIV Contents</title>');
                printWindow.document.write('<html><head><title>Club Infotech</title><link href="../assets/css/bootstrap.css" rel="stylesheet" /><link href="../assets/css/style.css" rel="stylesheet" /><style type="text/css">.rgGroupCol{    padding-left: 0 !important;    padding-right: 0 !important;    font-size:1px !important;}.rgExpand,.rgCollapse{    display:none !important;}</style>');
                printWindow.document.write('</head><body >');

                printWindow.document.write(panel.innerHTML);
                printWindow.document.write('</body></html>');
                printWindow.document.close();
                setTimeout(function () {
                    printWindow.print();
                }, 500);
                return false;
            }
        </script>



        <div class="row">
            <div class="form-group-2" style="float: right; margin-right: 0%" id="divBTN" runat="server">
                <asp:Button ID="btnprints" runat="server" Text="Compact View" OnClick="btnprints_Click" Style="float: right; margin-right: 11%;" />
                <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="return PrintPanel();" Style="float: right; margin-right: -12%;" />

                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
            </div>
        </div>
        <asp:Panel ID="pnlContents" runat="server" BorderStyle="Solid">
            <div class="heading-bg">
                <div class="container">
                    <label style="font-size: x-large; font: bold; color: #373739; display: inline-block; font-size: 30px; margin: -7px 0 0; padding: 15px 90px; text-decoration: underline">
                        Issue Voucher</label>
                </div>
            </div>
            <div>
                <div>
                    <div style="float: left; margin-right: 35px">
                        <asp:Label ID="lblIssueVoucherNo" runat="server" Style="font-family: 'Times New Roman'; font-size: 12px;"></asp:Label>
                        <br />
                        <span style="font-family: 'Times New Roman'; font-size: 12px;">408 HQ Coy ASC (Pet)<br />
                            c/o 56 APO
                        </span>
                    </div>

                    <div class="clearfix"></div>
                    <div class="container" style="width: 100%; float: left">

                        <table style="background-color: none !important;">
                            <tr>
                                <td style="width: 150px;">
                                    <label style="float: left">TO - </label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTo" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label style="float: left">VEH NO - </label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVehicleNo" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label style="float: left">Auth - </label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAuthority" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label style="float: left">THROUGH  - </label>
                                </td>
                                <td>
                                    <asp:Label ID="lblThrough" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clearfix"></div>
                    <div class="container" style="margin-left: 0px; width: 100%">


                        <telerik:RadGrid MasterTableView-ShowFooter="false" ID="rgdIssueVoucher" runat="server" GridLines="None" AutoGenerateColumns="False"
                            Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">
                            <MasterTableView DataKeyNames="ProductId" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                        <ItemTemplate>
                                            <div class="">
                                                <%#Container.DataSetIndex+1%>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="Commodity" DataField="product_name" DataType="System.String" UniqueName="product_name" ItemStyle-Width="135" HeaderStyle-Width="135">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="nn" Text='<%#Eval("product_name") %>' Style="width: 135px; word-wrap: break-word; display: block"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                                        <ItemTemplate>
                                            <%#Eval("AU") %>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="lblText" Style="float: right" Visible="false">Total Quantity:</asp:Label>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBatches" runat="server" Text="Batch(s) Details:"></asp:Label>
                                            <telerik:RadGrid OnItemCreated="rgdIssueVoucherBatch_ItemCreated" OnColumnCreated="rgdIssueVoucherBatch_ColumnCreated" ID="rgdIssueVoucherBatch" runat="server"
                                                GridLines="None" AutoGenerateColumns="False"
                                                Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowGroupPanel="false" ClientSettings-AllowExpandCollapse="false" MasterTableView-ExpandCollapseColumn-Groupable="false" GroupHeaderItemStyle-BorderStyle="None" GroupHeaderItemStyle-BorderWidth="0" GroupHeaderItemStyle-Font-Strikeout="false" GroupingSettings-CollapseTooltip="" GroupPanel-EnableTheming="false" GroupPanel-PanelItemsStyle-BackColor="WhiteSmoke" GroupPanel-PanelStyle-GridLines="None">
                                                <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="true" ShowHeader="true" ShowGroupFooter="false" EditFormSettings-FormMainTableStyle-GridLines="None" EditFormSettings-FormTableStyle-GridLines="None" EnableGroupsExpandAll="false" EnableHierarchyExpandAll="false" GroupsDefaultExpanded="true">
                                                    <%--<GroupByExpressions>
                                                        <telerik:GridGroupByExpression>
                                                            <GroupByFields>
                                                                <telerik:GridGroupByField FieldName="BatchNo" HeaderValueSeparator=":" SortOrder="Ascending" />
                                                            </GroupByFields>
                                                            <SelectFields>
                                                                <telerik:GridGroupByField FieldName="BatchNo" HeaderText="Batch No" />
                                                            </SelectFields>
                                                        </telerik:GridGroupByExpression>
                                                    </GroupByExpressions>--%>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn HeaderText="" DataField="BatchNo" DataType="System.Int32" UniqueName="BID" HeaderStyle-Width="5" ItemStyle-Width="5">
                                                            <ItemTemplate>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                Total:
                                                            </FooterTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo" HeaderStyle-Width="25" ItemStyle-Width="25">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblBatchNo" Text='<%#Eval("BatchNo").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label runat="server" ID="lblCount" Style="display: -moz-inline-box; word-wrap: break-word; font: bold"></asp:Label>
                                                            </FooterTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridTemplateColumn HeaderText="Pack" DataField="FormatFull" DataType="System.String" UniqueName="FormatFull" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                            <ItemTemplate>
                                                                <%#Eval("PackagingType") %>: <%#Eval("FormatFull") %>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label runat="server" ID="lblTotalFullFormat" Style="display: -moz-inline-box; word-wrap: break-word; font: bold"></asp:Label>
                                                            </FooterTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridTemplateColumn HeaderText="Qty" DataField="stockquantity" DataType="System.String" UniqueName="stockquantity" HeaderStyle-Width="25" ItemStyle-Width="25">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" Text='<%#TruncateDecimalToString( Convert.ToDouble(Eval("stockquantity")),3) %>' ID="lblQuantity"></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label runat="server" ID="lblTotalQuatity" Style="display: -moz-inline-box; word-wrap: break-word; font: bold"></asp:Label>
                                                            </FooterTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridTemplateColumn HeaderText="Cost " DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                                            <ItemTemplate>
                                                                <asp:Label Visible="false" runat="server" ID="lblCost" Text='<%#Eval("Cost") %>'></asp:Label>
                                                                <asp:Label runat="server" ID="lblCostAU" Text='<%#(Eval("vCost").ToString()==""?"": Eval("vCost").ToString())%>'></asp:Label>
                                                                <asp:Label runat="server" ID="lblthisFormatQty" Visible="false" Style="display: -moz-inline-box; word-wrap: break-word; font: bold"></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label runat="server" ID="lblTotalLooseFormat" Style="display: -moz-inline-box; word-wrap: break-word; font: bold"></asp:Label>
                                                            </FooterTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate" HeaderStyle-Width="25" ItemStyle-Width="25">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblMFGDate" Text='<%#Eval("DOM","{0:dd/MM/yyyy}") %>' Style="width: 63px; word-wrap: break-word; display: block"></asp:Label>
                                                                <asp:Label runat="server" ID="lblthisFullQty" Visible="false" Style="display: -moz-inline-box; word-wrap: break-word; font: bold"></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridTemplateColumn HeaderText="ESL" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                                            <ItemTemplate>
                                                                <asp:Label Style="width: 63px; word-wrap: break-word; display: block" runat="server" ID="lblEsl" Text='<%#Eval("ESL","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                                            <ItemTemplate>
                                                                <asp:Label Style="width: 63px; word-wrap: break-word; display: block" runat="server" ID="lblEXPDate" Text='  <%#Eval("EXPDate").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridTemplateColumn Visible="false" HeaderText="Weight" DataField="Weight" DataType="System.Double" UniqueName="Weight">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblWeight" Text='  <%#(Eval("Weight").ToString()==""?"": Eval("Weight").ToString()+" "+Eval("WeightUnit") )%>'></asp:Label>
                                                                <asp:Label Visible="false" runat="server" ID="lblWeightAU" Text='  <%#(Eval("WeightofParticular").ToString()==""?"": Eval("WeightofParticular").ToString()+" "+Eval("WeightUnit") +" per "+AU )%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>

                                                    <FooterStyle HorizontalAlign="Left" />
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                            <asp:Label ID="lblSubPacking" runat="server" Text='<%#Eval("SupplierId") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="lblTotalQty" Visible="false"></asp:Label>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="Amount" DataField="Amount" DataType="System.Int32" UniqueName="Amount">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCost"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="lblAmount" Text="Total Amount: "></asp:Label>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <FooterStyle HorizontalAlign="left" />
                            </MasterTableView>
                        </telerik:RadGrid>

                        <telerik:RadGrid MasterTableView-ShowFooter="false" ID="rgdIssueVoucherWithouPacking" runat="server" GridLines="None" AutoGenerateColumns="False"
                            Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">
                            <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                        <ItemTemplate>
                                            <div class="">
                                                <%#Container.DataSetIndex+1%>
                                                <asp:HiddenField ID="hdnBID" runat="server" Value='<%#Eval("BID") %>' />
                                                <asp:HiddenField ID="hdnSID" runat="server" Value='<%#Eval("CatID") %>' />
                                            </div>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>


                                    <telerik:GridTemplateColumn HeaderText="Items" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS" ItemStyle-Width="135" HeaderStyle-Width="135">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Style="width: 135px; word-wrap: break-word; display: block" Text='<%#Eval("ITEMS") %>'></asp:Label>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                                        <ItemTemplate>
                                            <%#Eval("AU") %>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="lblTotaltext" Style="float: right" Visible="false">Total Quantity</asp:Label>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>
                                    <%--  <telerik:GridTemplateColumn  HeaderText="Packaging Material " DataField="AU" DataType="System.String" UniqueName="AU">
                                    <ItemTemplate>

                                        <%#Eval("PackingMaterial") %>[<%#Eval("PackingMaterialFormat") %>]
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>--%>

                                    <telerik:GridTemplateColumn HeaderText="" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblB" runat="server" Text="Batch(s):"></asp:Label>


                                            <telerik:RadGrid ID="rgdBatchWithoutPacking" runat="server"
                                                GridLines="None" AutoGenerateColumns="False"
                                                Width="97%" EnableAJAX="True" Skin="Office2010Black">
                                                <%--OnItemCreated="rgdCRVBatch_ItemCreated" > --%>

                                                <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" ShowHeader="true">
                                                    <GroupByExpressions>

                                                        <telerik:GridGroupByExpression>
                                                            <GroupByFields>
                                                                <telerik:GridGroupByField FieldName="BatchNo" HeaderValueSeparator=":" SortOrder="Ascending" />
                                                            </GroupByFields>
                                                            <SelectFields>
                                                                <telerik:GridGroupByField FieldName="BatchNo" HeaderText="Batch No" />
                                                            </SelectFields>
                                                        </telerik:GridGroupByExpression>
                                                    </GroupByExpressions>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="BID">
                                                            <ItemTemplate>
                                                                <%#Eval("BID") %>
                                                                <asp:HiddenField ID="hdnBID" runat="server" Value='<%#Eval("BID") %>' />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>


                                                        <telerik:GridTemplateColumn HeaderText="Cost " DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                                            <ItemTemplate>

                                                                <asp:Label runat="server" ID="lblCostAU" Text='<%#(Eval("CostOfParticular").ToString()==""?"": Eval("CostOfParticular").ToString() +"/"+AU)%>'></asp:Label>



                                                            </ItemTemplate>

                                                        </telerik:GridTemplateColumn>


                                                        <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate">
                                                            <ItemTemplate>
                                                                <asp:Label Style="width: 63px; word-wrap: break-word; display: block" runat="server" Text='<%#Eval("MFGDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("MFGDate")).ToString("dd-MM-yyyy") %>'></asp:Label>


                                                            </ItemTemplate>

                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="ESL" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                                            <ItemTemplate>
                                                                <asp:Label Style="width: 63px; word-wrap: break-word; display: block" runat="server" ID="lblEsl" Text='<%#Eval("Esl").ToString()==""?"N/A":Convert.ToDateTime(Eval("Esl")).ToString("dd-MM-yyyy")%>'></asp:Label>



                                                            </ItemTemplate>

                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                                            <ItemTemplate>
                                                                <asp:Label Style="width: 63px; word-wrap: break-word; display: block" runat="server" ID="lblEXPDate" Text='  <%#Eval("EXPDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("EXPDate")).ToString("dd-MM-yyyy")%>    '></asp:Label>


                                                            </ItemTemplate>

                                                        </telerik:GridTemplateColumn>













                                                        <telerik:GridTemplateColumn Visible="false" HeaderText="Weight" DataField="Weight" DataType="System.Double" UniqueName="Weight">
                                                            <ItemTemplate>


                                                                <asp:Label runat="server" ID="lblWeight" Text='  <%#(Eval("Weight").ToString()==""?"": Eval("Weight").ToString()+" "+Eval("WeightUnit") )%>'></asp:Label>

                                                                <asp:Label Visible="false" runat="server" ID="lblWeightAU" Text='  <%#(Eval("WeightofParticular").ToString()==""?"": Eval("WeightofParticular").ToString()+" "+Eval("WeightUnit") +" per "+AU )%>'></asp:Label>


                                                            </ItemTemplate>

                                                        </telerik:GridTemplateColumn>






                                                    </Columns>

                                                    <FooterStyle HorizontalAlign="Left" />

                                                </MasterTableView>
                                            </telerik:RadGrid>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label Visible="false" runat="server" ID="lblTotalQty" Style="float: left"></asp:Label>
                                        </FooterTemplate>

                                    </telerik:GridTemplateColumn>


                                    <telerik:GridTemplateColumn HeaderText="Amount" DataField="Amount" DataType="System.Int32" UniqueName="Amount">
                                        <ItemTemplate>

                                            <asp:Label runat="server" ID="lblCost"></asp:Label>

                                        </ItemTemplate>
                                        <FooterTemplate>

                                            <asp:Label ID="lblAmount" runat="server" Style="float: left" Text="" Visible="false"></asp:Label>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>


                                    <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.Int32" UniqueName="Remarks" ItemStyle-Width="140" HeaderStyle-Width="140">
                                        <ItemTemplate>



                                            <asp:Label runat="server" Text='<%#Eval("Remarks").ToString() %>' ID="lblFormat" Style="height: 100%; width: 139px; word-wrap: break-word; display: block"></asp:Label>



                                        </ItemTemplate>


                                    </telerik:GridTemplateColumn>



                                </Columns>

                                <FooterStyle HorizontalAlign="left" />

                            </MasterTableView>
                        </telerik:RadGrid>

                        <asp:Label ID="lblAmount" runat="server" Text="" Style="float: right; margin-right: 95px"></asp:Label>
                        <br />
                        <div style="margin-top: 0px; height: 50px; text-align: center;">
                            <div class="container">
                                <asp:Label ID="lblCountItems" runat="server"></asp:Label><br />
                                <asp:Label ID="lblInWords" runat="server"></asp:Label><br />
                                <br />
                                <div class="row" style="text-align: left; margin-left: 95px; margin-right: 95px;">
                                    <asp:Label ID="lblCatogory" runat="server" Text="Certified that above mentioned items has been recieved and credited in "></asp:Label>
                                    <%--<asp:Label Visible="false" ID="lblCRVdt"  runat="server" Text=" group vide DS No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt"></asp:Label>--%>
                                </div>
                                <br />
                                <asp:Label ID="Label3" runat="server" Style="text-decoration: underline">COUNTERSIGNED</asp:Label>
                            </div>

                        </div>
                    </div>

                </div>

            </div>
            <div class="row" style="height: 500px;">
            </div>
        </asp:Panel>
    </form>
</body>
</html>
