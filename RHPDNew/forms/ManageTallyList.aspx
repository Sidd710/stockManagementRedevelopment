<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="ManageTallyList.aspx.cs" Inherits="RHPDNew.Forms.ManageTallyList" %>

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
            <h1>Managed Tally List</h1>
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

        <div class="container">

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
                <div class="form-group-2">

                    <label class="col-lg-2">Date from:</label>
                    <asp:TextBox ID="txtDatefrom" CssClass="col-lg-4 form-control" placeholder="Click on textbox" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                    <asp:CalendarExtender ID="cetxMfgDate" Format="dd MMM yyyy" TargetControlID="txtDatefrom" runat="server"></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="rfvtxtunitDesc" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDatefrom"></asp:RequiredFieldValidator>

                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Date to:</label>
                    <asp:TextBox ID="txtDateto" CssClass="col-lg-4 form-control" placeholder="Click on textbox" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" Format="dd MMM yyyy" TargetControlID="txtDateto" runat="server"></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDateto"></asp:RequiredFieldValidator>

                </div>
            </div>

            <div class="row">
                <div class="col-lg-2"></div>
                <div class="form-group-2 col-lg-4 text-align-right">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false" /><br />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>
            </div>

        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="sp_ManageTallySheet" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="selecttallyall" Name="Action" Type="String"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <telerik:RadGrid runat="server" DataSourceID="SqlDataSource1" ID="radTallyList" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnPageIndexChanged="radTallyList_PageIndexChanged" OnNeedDataSource="radTallyList_NeedDataSource">
            <MasterTableView DataKeyNames="Id" PageSize="10" Caption="Managed Tally List" AllowAutomaticUpdates="false" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="8">
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
                     <telerik:GridTemplateColumn HeaderText="Depu Name" DataField="DepuName" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblLoadIn" runat="server" Text=' <%#Eval("DepuName").ToString()==""?"N/A":Eval("DepuName") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Unit Name" DataField="UnitName" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblIdtId" runat="server" Text=' <%#Eval("UnitName").ToString()==""?"N/A":Eval("UnitName") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Vehicle No" DataField="VehBaNo" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblVeh" runat="server" Text=' <%#Eval("VehBaNo").ToString()==""?"N/A":Eval("VehBaNo") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                
                    <telerik:GridTemplateColumn HeaderText="Authority" DataField="Authority" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblTypeOfVeh" runat="server" Text=' <%#Eval("Authority").ToString()==""?"N/A":Eval("Authority") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Through" DataField="unit" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblUnitQuant" runat="server" Text=' <%#Eval("Through").ToString()==""?"N/A":Eval("Through") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <%--  <telerik:GridTemplateColumn HeaderText="Unit Station Name" DataField="unitname" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("unitname").ToString()==""?"Not Alloted":Eval("unitname") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>--%>
                    <telerik:GridTemplateColumn HeaderText="Generated On" DataField="AddedOn" DataType="System.String" AllowFiltering="true">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblFuelOut" runat="server" Text=' <%#Convert.ToDateTime(Eval("AddedOn")).ToString("dd/MMM/yyyy") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Issued Voucher" DataType="System.String" Groupable="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:LinkButton ID="lkgenrate" runat="server" Text="View" PostBackUrl='<%# String.Format("~/Forms/ManageTallyView.aspx?id={0}", Eval("Id"))%>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>

        </telerik:RadGrid>

    </div>

</asp:Content>
