<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueVoucherPrintScreen.aspx.cs" Inherits="RHPDNew.StockOutPanel.IssueVoucherPrintScreen" %>

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
    <form id="form2" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server"></asp:ToolkitScriptManager>
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
            <div class="form-group-2" style="float: right; margin-right: 0%" id="div1" runat="server">
                <asp:Button ID="btnprints" runat="server" Text="Compact View" Style="float: right; margin-right: 11%;" OnClick="btnprints_Click" />
                <asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="return PrintPanel();" Style="float: right; margin-right: -12%;" />


                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
            </div>
        </div>
        <asp:Panel ID="pnlContents" runat="server" BorderStyle="Dotted">
            <div class="row" style="margin-top: 0px; height: 48px">
                <div style="float: right; margin-right: 18px; margin-top: 0px;">
                    <asp:Label ID="Label5" runat="server" Style="font-family: 'Times New Roman'; font-size: 12px;"></asp:Label>
                    <br />
                    <span style="font-family: 'Times New Roman'; font-size: 12px; text-decoration: underline; margin-bottom: 2px; margin-right: 35px">ILO IAFZ-2096</span>

                </div>
            </div>


            <div class="heading-bg">
                <div class="container">
                    <label style="font-size: x-large; font: bold; color: #373739; display: inline-block; font-size: 30px; margin: -7px 0 0; padding: 15px 90px; text-decoration: underline">
                        ISSUE VOUCHER</label>

                </div>
            </div>


            <div>

                <div style="float: left; margin-left: 15px;">

                    <asp:Label ID="lblIssueVoucherNo" runat="server" Style="font-family: 'Times New Roman'; font-size: 12px;"></asp:Label>
                    <br />
                    <span style="font-family: 'Times New Roman'; font-size: 12px;">408 HQ Coy ASC (Pet)<br />
                        C/o 56 APO</span>

                </div>



                <div class="clearfix"></div>
                <div class="container" style="width: 100%; float: left">



                    <table style="background-color: none !important;">
                        <tr>
                            <td style="width: 150px;">
                                <label style="float: left">TO:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblTo" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label style="float: left" runat="server">VEH NO[Challan No]:</label></td>
                            <td>
                                <asp:Label ID="lblVehicleNo" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label style="float: left">Auth:</label></td>
                            <td>
                                <asp:Label ID="lblAuthority" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label style="float: left">THROUGH:</label></td>
                            <td>
                                <asp:Label ID="lblThrough" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>

                            </td>
                        </tr>
                    </table>



                </div>

                <div class="clearfix"></div>
                <div class="container" style="margin-left: 0px; width: 100%">


                    <telerik:RadGrid MasterTableView-ShowFooter="false" ID="rgdSummary" runat="server"
                        GridLines="None" AutoGenerateColumns="False"
                        Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">


                        <MasterTableView DataKeyNames="ProductId" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false">

                            <Columns>

                                <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex+1%>

                                            <asp:HiddenField ID="hdnPID" runat="server" Value='<%#Eval("PID") %>' />
                                            <asp:HiddenField ID="hdnSID" runat="server" Value='<%#Eval("SID") %>' />
                                        </div>
                                    </ItemTemplate>

                                </telerik:GridTemplateColumn>


                                <telerik:GridTemplateColumn HeaderText="Commodity" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS" ItemStyle-Width="135" HeaderStyle-Width="135">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="nn" Text='<%#Eval("product_name") %>' Style="width: 135px; word-wrap: break-word; display: block"></asp:Label>


                                    </ItemTemplate>

                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                                    <ItemTemplate>
                                        <%-- <%#int.Parse(Eval("SID").ToString())>0?Eval("IDTICTAWS"):"" %>--%>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label runat="server" ID="lblText" Style="float: right" Visible="false">Total Quantity:</asp:Label>
                                    </FooterTemplate>

                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderText="" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblB" runat="server" Text="Batch(s):"></asp:Label>
                                        <telerik:RadGrid OnItemCreated="rgdCRVBatch_ItemCreated" OnColumnCreated="rgdCRVBatch_ColumnCreated" ID="rgdCRVBatch" runat="server"
                                            GridLines="None" AutoGenerateColumns="False"
                                            Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowGroupPanel="false" ClientSettings-AllowExpandCollapse="false" MasterTableView-ExpandCollapseColumn-Groupable="false" GroupHeaderItemStyle-BorderStyle="None" GroupHeaderItemStyle-BorderWidth="0" GroupHeaderItemStyle-Font-Strikeout="false" GroupingSettings-CollapseTooltip="" GroupPanel-EnableTheming="false" GroupPanel-PanelItemsStyle-BackColor="WhiteSmoke" GroupPanel-PanelStyle-GridLines="None">


                                            <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="true" ShowHeader="true" ShowGroupFooter="false" EditFormSettings-FormMainTableStyle-GridLines="None" EditFormSettings-FormTableStyle-GridLines="None" EnableGroupsExpandAll="false" EnableHierarchyExpandAll="false" GroupsDefaultExpanded="true">
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
                                                    <telerik:GridTemplateColumn HeaderText="" UniqueName="BID" HeaderStyle-Width="5" ItemStyle-Width="5">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            Total:
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="" DataField="BatchNo" DataType="System.Int32" UniqueName="BID" HeaderStyle-Width="5" ItemStyle-Width="5">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            Total:
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>


                                                    <telerik:GridTemplateColumn HeaderText="Quantity" DataField="RemainingQty" DataType="System.String" UniqueName="BatchNo" HeaderStyle-Width="25" ItemStyle-Width="25">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%#TruncateDecimalToString( Convert.ToDouble(Eval("stockquantity")),3) %>' ID="lblQuantity"></asp:Label>

                                                        </ItemTemplate>
                                                        <FooterTemplate>

                                                            <asp:Label runat="server" ID="lblTotalQuatity" Style="display: -moz-inline-box; word-wrap: break-word; font: bold"></asp:Label>
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>


                                                    <telerik:GridTemplateColumn HeaderText="Pack" DataField="Format" DataType="System.String" UniqueName="Format" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                        <ItemTemplate>
                                                            <%#Eval("FormatFull").ToString()==""?"":"Full: "+Eval("FormatFull").ToString() %><br />
                                                            <%#Eval("FormatLoose").ToString()==""?"":"Loose: "+Eval("FormatLoose").ToString() %>
                                                        </ItemTemplate>
                                                        <FooterTemplate>



                                                            <asp:Label runat="server" ID="lblTotalFullFormat" Style="display: -moz-inline-box; word-wrap: break-word; font: bold"></asp:Label>


                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>



                                                    <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate" HeaderStyle-Width="25" ItemStyle-Width="25">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblMFGDate" Text='<%#Eval("DOM").ToString()%>' Style="width: 63px; word-wrap: break-word; display: block"></asp:Label>


                                                        </ItemTemplate>
                                                         <FooterTemplate>



                                                            <asp:Label runat="server" ID="lblTotalLooseFormat" Style="display: -moz-inline-box; word-wrap: break-word; font: bold"></asp:Label>


                                                        </FooterTemplate>

                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="ESL" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                                        <ItemTemplate>
                                                            <asp:Label Style="width: 63px; word-wrap: break-word; display: block" runat="server" ID="lblEsl" Text='  <%#Eval("ESL").ToString() %>'></asp:Label>



                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>



                                                    <telerik:GridTemplateColumn HeaderText="Cost " DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                                        <ItemTemplate>

                                                            <asp:Label runat="server" ID="lblCost" Text='<%#Eval("vCost") %>'></asp:Label>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label runat="server" ID="lblTotalCost" Style="display: -moz-inline-box; word-wrap: break-word; font: bold"></asp:Label>

                                                        </FooterTemplate>

                                                    </telerik:GridTemplateColumn>

                                                      <telerik:GridTemplateColumn HeaderText="Expiry Date" DataField="ExpiryDate" DataType="System.DateTime" UniqueName="ExpiryDate">
                                                        <ItemTemplate>

                                                            <%#Eval("ExpiryDate").ToString() %> 
                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Vehicle" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                                        <ItemTemplate>

                                                            <%#Eval("VechileNumber").ToString() %>  <%#Eval("LicenseNo").ToString()==""?"": "["+ Eval("LicenseNo").ToString() +" ]"%>
                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>


                                                </Columns>

                                                <FooterStyle HorizontalAlign="Left" />

                                            </MasterTableView>
                                        </telerik:RadGrid>

                                        <asp:Label runat="server" ID="lblTotalQty" Visible="false" Text='<%#TruncateDecimalToString( Convert.ToDouble(Eval("stockquantity")),3) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>


                                </telerik:GridTemplateColumn>



                                <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.Int32" UniqueName="Remarks" ItemStyle-Width="140" HeaderStyle-Width="140">
                                    <ItemTemplate>

                                        <%# Eval("Remarks") %>
                                    </ItemTemplate>


                                </telerik:GridTemplateColumn>


                            </Columns>

                            <FooterStyle HorizontalAlign="left" />

                        </MasterTableView>
                    </telerik:RadGrid>



                    <br />
                    <div style="margin-left: 570px; height: 20px; margin-top: 10px; width: 150px;">
                        <asp:Label ID="lblItemCount" runat="server"></asp:Label>
                    </div>
                    <br />
                    <div style="margin-left: 350px; width: 550px">
                        <p>
                            Issued and charged off from
                    <asp:Label runat="server" ID="lblCategory" />
                            Group Vide DS No - &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DT
                    <asp:Label runat="server" ID="lblDOGIV" />
                        </p>
                    </div>
                </div>

            </div>


            <div class="row" style="height: 500px;">
            </div>
        </asp:Panel>
    </form>
</body>
</html>


