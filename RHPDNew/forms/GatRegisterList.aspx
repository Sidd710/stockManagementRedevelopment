<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="GatRegisterList.aspx.cs" Inherits="RHPDNew.Forms.GatRegisterList" %>


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

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="sp_Gat" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="Selectallfromto" Name="Action" Type="String"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <telerik:RadGrid runat="server" DataSourceID="SqlDataSource1" ID="radGateout" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnPageIndexChanged="radGateout_PageIndexChanged1" OnNeedDataSource="radGateout_NeedDataSource1">
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

                    <telerik:GridTemplateColumn HeaderText="Vehicle No" DataField="vehbano" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblVeh" runat="server" Text=' <%#Eval("vehbano").ToString()==""?"N/A":Eval("vehbano") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn HeaderText="Army No" DataField="ArmyNo" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblArmyNo" runat="server" Text=' <%#Eval("ArmyNo").ToString()==""?"N/A":Eval("ArmyNo") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Rank" DataField="Rank" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblRank" runat="server" Text=' <%#Eval("Rank").ToString()==""?"N/A":Eval("Rank") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Name" DataField="name" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblname" runat="server" Text=' <%#Eval("name").ToString()==""?"N/A":Eval("name") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Time In" DataField="timein" DataType="System.DateTime" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblTimein" runat="server" Text=' <%#Eval("timein").ToString()==""?"N/A":Convert.ToDateTime(Eval("timein")).ToShortTimeString() %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Type of Vehicle" DataField="typeofvehicle" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblTypeOfVeh" runat="server" Text=' <%#Eval("typeofvehicle").ToString()==""?"N/A":Eval("typeofvehicle") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Quantity Unit" DataField="unit" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblUnitQuant" runat="server" Text=' <%#Eval("unitQuantityTypeId").ToString()==""?"N/A":Eval("unitQuantityTypeId") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Load In" DataField="Indname" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblLoadIn" runat="server" Text=' <%#Eval("loadin").ToString()==""?"N/A":Eval("loadin") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="IR No" DataField="irno" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblIdtId" runat="server" Text=' <%#Eval("IdtId").ToString()==""?"N/A":Eval("IdtId") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Time Out" DataField="timeout" DataType="System.DateTime" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblTimeOut" runat="server" Text=' <%#Eval("timeout").ToString()==""?"N/A":Convert.ToDateTime(Eval("timeout")).ToShortTimeString() %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn HeaderText="Load Out" DataField="loadout" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblLoadOut" runat="server" Text=' <%#Eval("loadout").ToString()==""?"N/A":Eval("loadout") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Depu Station Name" DataField="stationDepuID" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblstationDepuId" runat="server" Text=' <%#Eval("stationDepuID").ToString()==""?"N/A":Eval("stationDepuID") %>'></asp:Label>
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
                    <telerik:GridTemplateColumn HeaderText="Fuel In" DataField="fuelintankIn" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblFuelIn" runat="server" Text=' <%#Eval("fuelintankIn").ToString()==""?"N/A":Eval("fuelintankIn") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Fuel Out" DataField="fuelintankOut" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblFuelOut" runat="server" Text=' <%#Eval("fuelintankOut").ToString()==""?"N/A":Eval("fuelintankOut") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Generated On" DataField="AddedOn" DataType="System.DateTime" AllowFiltering="true">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblFuelOut" runat="server" Text=' <%#Eval("AddedOn").ToString()==""?"N/A": Convert.ToDateTime(Eval("AddedOn")).ToString("dd/MMM/yyyy") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Gate In/out" DataType="System.String" Groupable="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:LinkButton ID="lkgenrate" runat="server" Text="View" PostBackUrl='<%# String.Format("~/Forms/GatInOutView.aspx?id={0}", Eval("Id"))%>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>

        </telerik:RadGrid>

    </div>

</asp:Content>
