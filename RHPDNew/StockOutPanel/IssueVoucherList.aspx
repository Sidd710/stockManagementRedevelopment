<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="IssueVoucherList.aspx.cs" Inherits="RHPDNew.StockOutPanel.IssueVoucherList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="" align="center">
        <div class="container">
            <h1>Issue Voucher List</h1>
        </div>
    </div>
    <br />
    <br />
    <style>
        body {
            background: url(../assets/images/Siachen-19.jpg) no-repeat;
            background-size: cover;
        }
    </style>
    <div class="container-fluid">

        <asp:UpdateProgress ID="UpdateProgress7" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updPacking">
            <ProgressTemplate>
                <div class="full-pop-up">
                    <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="updPacking">
            <ContentTemplate>

                <telerik:RadGrid ID="rgdVoucherList" runat="server" Skin="Vista"
                    GridLines="None" AutoGenerateColumns="false"
                    Width="100%" EnableAJAX="True" ShowFooter="true" AllowPaging="true" AllowFilteringByColumn="true" OnNeedDataSource="rgdVoucherList_NeedDataSource">

                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none">
                        <GroupByExpressions>

                            <telerik:GridGroupByExpression>
                                <GroupByFields>
                                    <telerik:GridGroupByField FieldName="IDTICTAWS" HeaderValueSeparator=":" SortOrder="None" />
                                </GroupByFields>
                                <SelectFields>
                                    <telerik:GridGroupByField FieldName="IDTICTAWS" HeaderText="Type" />
                                </SelectFields>
                            </telerik:GridGroupByExpression>
                            <telerik:GridGroupByExpression>
                                <GroupByFields>
                                    <telerik:GridGroupByField FieldName="Category_Name" HeaderValueSeparator=":" SortOrder="None" />
                                </GroupByFields>
                                <SelectFields>
                                    <telerik:GridGroupByField FieldName="Category_Name" HeaderText="Category" />
                                </SelectFields>
                            </telerik:GridGroupByExpression>

                        </GroupByExpressions>
                        <Columns>

                            <telerik:GridTemplateColumn HeaderText="SNo" DataField="Id" DataType="System.Int32" UniqueName="Id" AllowFiltering="false">
                                <ItemTemplate>

                                    <%#Container.DataSetIndex+1%>
                                </ItemTemplate>


                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Type" DataField="IDTICTAWS" DataType="System.String" UniqueName="IDTICTAWS">
                                <ItemTemplate>


                                    <%#Eval("IDTICTAWS") %>
                                </ItemTemplate>


                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Category" DataField="Category_Name" DataType="System.String" UniqueName="Category_Name">
                                <ItemTemplate>


                                    <%#Eval("Category_Name") %>
                                </ItemTemplate>


                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Issuse VoucherNo" DataField="IssusevoucherName" DataType="System.String" UniqueName="IssusevoucherName">
                                <ItemTemplate>


                                    <asp:Label ID="lblvechileName" CssClass="lblvechileNameclass" runat="server" Text='<% #Eval("IssusevoucherName")%>' Style="color: blue"></asp:Label>


                                </ItemTemplate>


                            </telerik:GridTemplateColumn>





                            <telerik:GridTemplateColumn HeaderText="Issue Quantity" DataField="Qty" DataType="System.Decimal" UniqueName="Qty">
                                <ItemTemplate>


                                    <%#Convert.ToDouble(Eval("Qty").ToString()).ToString("0.000") %>
                                </ItemTemplate>


                            </telerik:GridTemplateColumn>




                            <telerik:GridTemplateColumn HeaderText="Date of Genration" DataField="dateofgenration" DataType="System.DateTime" UniqueName="dateofgenration">
                                <ItemTemplate>


                                    <%#Convert.ToDateTime(Eval("dateofgenration").ToString()).ToString("dd-MMM-yyyy") %>
                                </ItemTemplate>


                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Created On" DataField="CreateDate" DataType="System.DateTime" UniqueName="CreateDate">
                                <ItemTemplate>


                                    <%#Convert.ToDateTime(Eval("CreateDate").ToString()).ToString("dd-MMM-yyyy hh:mm tt") %>
                                </ItemTemplate>


                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Status" DataField="Active" DataType="System.Boolean" UniqueName="Active">
                                <ItemTemplate>


                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%#Convert.ToBoolean(Eval("Active").ToString()) %>' Text=' <%#Eval("Status1") %>' TextAlign="Right" />

                                </ItemTemplate>


                            </telerik:GridTemplateColumn>



                            <telerik:GridHyperLinkColumn AllowFiltering="false" HeaderText="" UniqueName="IView" DataTextField="Id"
                                DataTextFormatString="View Detail" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="javascript:ViewCheck({0})">
                            </telerik:GridHyperLinkColumn>
                            <telerik:GridHyperLinkColumn AllowFiltering="false" HeaderText="" UniqueName="SIDPrint" DataTextField="Id"
                                DataTextFormatString="Print" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="../StockOutPanel/IssueVoucherPrintScreen.aspx?ivNo={0}" Target="Blank">
                            </telerik:GridHyperLinkColumn>


                        </Columns>

                        <FooterStyle HorizontalAlign="left" />

                    </MasterTableView>
                </telerik:RadGrid>

                <script type="text/javascript">
                    function ViewCheck(id) {


                        var url = "IssueVoucherView.aspx?ivNo=" + id;
                        var oWnd = radopen(url, "RadWindowDetails");
                    }
                </script>
                <telerik:RadWindowManager ID="RadWindowManager2" runat="server" Width="1300px" Height="600px">
                    <Windows>
                        <telerik:RadWindow ID="RadWindowDetails" runat="server" Width="1300px" Height="600px">
                        </telerik:RadWindow>
                    </Windows>
                </telerik:RadWindowManager>

                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="50000"></asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>



    </div>
</asp:Content>
