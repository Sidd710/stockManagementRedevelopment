<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="GateIssuedVoucherList.aspx.cs" Inherits="RHPDNew.Forms.GateIssuedVoucherList" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
    <style type="text/css">
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }



        Table {
            border: solid 1px #df5015;
        }

        .th {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }

        .td {
            border-bottom-color: #f0f2da;
            border-right-color: #f0f2da;
            padding: 0.5em 0.5em 0.5em 0.5em;
        }

        .tr {
            color: Black;
            background-color: White;
            text-align: left;
        }

        :link, :visited {
            color: #DF4F13;
            text-decoration: none;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="heading-bg">
        <div class="container">
            <h1>Gate Issued Voucher</h1>
        </div>
    </div>
    <div>

        <div class="clearfix"></div>
        <div class="clearfix"></div>
        <br />
        <br />
        <%--               <div class="row">
                    <div class="form-group-2">
                        <div class="form-group-2 col-lg-6 text-align-right">   
                             Click on Submit to See ESL Last 6 Month Wise
                        </div>
                    </div>
               </div>--%>


        <asp:ObjectDataSource ID="objIssue" runat="server" TypeName="RHPDComponent.IndentComponent" SelectMethod="SelectGateInoutList"></asp:ObjectDataSource>
        <telerik:RadGrid runat="server" DataSourceID="objIssue" ID="radIssueVoucher" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnPageIndexChanged="radIssueVoucher_PageIndexChanged">
            <MasterTableView DataKeyNames="Id" PageSize="10" Caption="Gate In/out List" AllowAutomaticUpdates="false" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="8">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                <CommandItemTemplate>
                    <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                </CommandItemTemplate>
                <Columns>

                    <telerik:GridTemplateColumn HeaderText="S No." AllowFiltering="false">
                        <ItemTemplate>
                            <div class="" style="float: left;">
                                <%#Container.DataSetIndex+1%>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn HeaderText="Indent Name" DataField="IndentName" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("IndentName").ToString()==""?"N/A":Eval("IndentName") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn HeaderText="Gate Out" DataType="System.String" Groupable="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:LinkButton ID="lkgenrate" runat="server" Text="register" PostBackUrl='<%# String.Format("~/Forms/GateInOutRegister.aspx?id={0}", Eval("Id"))%>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>

        </telerik:RadGrid>
    </div>

</asp:Content>
