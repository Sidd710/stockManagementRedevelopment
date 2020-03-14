<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintIssueVoucher.aspx.cs" Inherits="RHPDNew.StockOutPanel.PrintIssueVoucher1" %>

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

                <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="return PrintPanel();" Style="float: right; margin-right: 5%;" />

                <%--<input type="button" id="btnprints" name="btnprints" value="Print" onclick="print_page();" />--%>
                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
            </div>
        </div>
        <asp:Panel ID="pnlContents" runat="server">


            <div class="heading-bg">
                <div class="container">
                    <label style="font-size: x-large; font: bold; color: #373739; display: inline-block; font-size: 30px; margin: -7px 0 0; padding: 15px 90px; text-decoration: underline">
                        Issue Voucher</label>

                </div>
            </div>
            <div>

                <div>

                    <div style="float: right; margin-right: 35px">
                        <br />
                    </div>
                    <div class="clearfix">
                        <label style="font-size: x-large; color: #373739; display: inline-block; font-size: 30px; margin-left: 20px; width: 450px; height: 30px;">
                            <asp:Label ID="lblVoucherNo" runat="server" Style="font-family: 'Times New Roman'; font-size: 15px;"></asp:Label><br />
                            <span style="font-family: 'Times New Roman'; font-size: 15px;">408 HQ Coy ASC (Pet)<br />
                                C/o 56 APO</span>
                        </label>
                    </div>
                    <br />
                    <div class="container" style="width: 100%; float: left">

                        <table style="background-color: none !important;">
                            <tr style="height:30px">
                                <td style="width: 170px;">
                                    <label style="float: left">To:</label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTo" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="height:30px">
                                <td>
                                    <label style="float: left">Vechicle No[Driver Name]:</label></td>
                                <td>
                                    <asp:Label ID="lblVechicleNo" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>

                                </td>
                            </tr>
                            <tr style="height:30px">
                                <td>
                                    <label style="float: left">Authority:</label></td>
                                <td>
                                    <asp:Label ID="lblAuthority" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height:30px">
                                <td>
                                    <label style="float: left">Through:</label></td>
                                <td>
                                    <asp:Label ID="lblThrough" runat="server" Style="width: 98%; word-wrap: break-word; display: block"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clearfix"></div>
                    <div class="container" style="margin-left: 0px; width: 100%">

                        <telerik:RadGrid ID="rgdSummary" runat="server" MasterTableView-AutoGenerateColumns="false" GridLines="None" AutoGenerateColumns="False"
                            Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" ShowHeader="true">
                            <MasterTableView DataKeyNames="ProductId" AutoGenerateColumns="false" GridLines="None" Width="100%" CommandItemDisplay="none">
                                <%--<GroupByExpressions>
                                    <telerik:GridGroupByExpression>
                                        <GroupByFields>
                                            <telerik:GridGroupByField FieldName="IDTICTAWS" HeaderValueSeparator=":" SortOrder="None" />
                                        </GroupByFields>
                                        <SelectFields>
                                            <telerik:GridGroupByField FieldName="IDTICTAWS" HeaderText="." />
                                        </SelectFields>
                                    </telerik:GridGroupByExpression>
                                    <telerik:GridGroupByExpression>
                                        <GroupByFields>
                                            <telerik:GridGroupByField FieldName="IssueVoucherId" HeaderValueSeparator=":" SortOrder="None" />
                                        </GroupByFields>
                                        <SelectFields>
                                            <telerik:GridGroupByField FieldName="IssueVoucherId" HeaderText="Issue VoucherId" />
                                        </SelectFields>
                                    </telerik:GridGroupByExpression>
                                    <telerik:GridGroupByExpression>
                                        <GroupByFields>
                                            <telerik:GridGroupByField FieldName="ATSONo" HeaderValueSeparator=":" SortOrder="None" />
                                        </GroupByFields>
                                        <SelectFields>
                                            <telerik:GridGroupByField FieldName="ATSONo" HeaderText="." />
                                        </SelectFields>
                                    </telerik:GridGroupByExpression>
                                </GroupByExpressions>--%>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="S No" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                        <ItemTemplate><%--<%# Container.DataItemIndex + 1 %>--%></ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Commodity" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                        <ItemTemplate></ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="tt" Style="float: none"> Total: </asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="A/U" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                        <ItemTemplate></ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="qty" Text="Quantity:" Style="float: right"></asp:Label>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Quantity" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%#Eval("productunit").ToString()=="NOS"?Convert.ToDouble(Eval("stockquantity")).ToString("0.00"):Convert.ToDouble(Eval("stockquantity")).ToString("0.000") %>' ID="lblVQty"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="lblTotalQty" Text="000"></asp:Label>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Batch Detail:" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                        <ItemTemplate>
                                            <asp:Table runat="server" ID="tblBatch">
                                                <asp:TableRow>
                                                    <asp:TableCell ColumnSpan="5"><b> Batch No: </b> <%#Eval("BatchNo") %></asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell>Cost: <%#Convert.ToDouble(Eval("VCost").ToString()).ToString("0.00") %></asp:TableCell>
                                                    <asp:TableCell>Full: <%#Eval("FormatFull").ToString()==""?"N/A":Eval("FormatFull") %></asp:TableCell>
                                                    <asp:TableCell>Loose/DW/Others: <%#Eval("FormatLoose").ToString()==""?"N/A":Eval("FormatLoose")%></asp:TableCell>
                                                    <asp:TableCell>Weight: <%#Convert.ToDouble(Eval("vWeight").ToString()).ToString("0.00") %></asp:TableCell>
                                                    <asp:TableCell>DOM: <%#Eval("DOM","{0:dd/MM/yyyy}") %></asp:TableCell>
                                                    <asp:TableCell>ESL: <%#Eval("ESL","{0:dd/MM/yyyy}") %></asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="lblCost" Text="000" Style="float: left"></asp:Label><asp:Label runat="server" ID="lblWeight" Text="000" Style="float: right"></asp:Label>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>



                        <asp:Label ID="lblAmount" runat="server" Text="" Style="float: right; margin-right: 95px"></asp:Label>
                        <br />
                        <div style="margin-top: 10px; height: 50px; text-align: center;">
                            <div class="container">
                                <asp:Label ID="lblCount" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblInWords" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblCatogory" runat="server" Text="Issued and charged off from"></asp:Label>


                            </div>
                        </div>
                    </div>
                    <div class="row" style="height: 500px;">
                    </div>
                </div>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
