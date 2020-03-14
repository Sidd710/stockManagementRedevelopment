<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="GateInOutRegister.aspx.cs" Inherits="RHPDNew.Forms.GateInOutRegister" %>


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
            <h1>Register Gate In/out</h1>
        </div>
    </div>
    <div>

        <div class="clearfix"></div>
        <div class="container">
              <p>&nbsp;</p>
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
                <div class="form-group-2">
                    <label class="col-lg-2">Vechicle No:</label>
                    <asp:TextBox ID="txtVechicleNo" class="col-lg-4 form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtVechicleNo"></asp:RequiredFieldValidator>
                </div>
              </div>

            <div class="row" visible="false" runat="server">
                <div class="form-group-2">
                    <label class="col-lg-2">Franchise No:</label>
                    <asp:TextBox ID="txtFranchiseNo" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtFranchiseNo" runat="server" ValidationGroup="grps" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtFranchiseNo"></asp:RequiredFieldValidator>
                </div>
            </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">ArmyNo:</label>
                    <asp:TextBox ID="txtArmyNo" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtArmyNo"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Rank:</label>
                    <asp:TextBox ID="txtRank" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtRank"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Name:</label>

                    <asp:TextBox ID="txtName" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                </div>
            </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Time In:</label>
                    <telerik:RadTimePicker id="radtimein" Width="120px" TimeView-TimeFormat="t" runat="server" Culture="en-US">
                        <TimeView runat="server" StartTime="1:0:0" EndTime="23:30:00" Interval="0:30:0"></TimeView>
                    </telerik:RadTimePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="radtimein"></asp:RequiredFieldValidator>
                </div>
            </div>

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2"> Type of Vehicle:</label>
                    <asp:TextBox ID="txtTypeofVehicle" class="col-lg-4 form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtTypeofVehicle"></asp:RequiredFieldValidator>
                </div>
              </div>
                
             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Quantity Unit:</label>
                    <asp:ObjectDataSource ID="odsQuantitytype" runat="server" TypeName="RHPDComponent.ManagestockComp" SelectMethod="SelectQuantityType"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlQuantitytype" OnDataBound="ddlQuantitytype_DataBound" DataSourceID="odsQuantitytype" DataTextField="QuantityType" DataValueField="Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlDepoName" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Quantity type" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlQuantitytype"></asp:RequiredFieldValidator>
                </div>
            </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">IR No:</label>
                    <asp:Label ID="lblidentid" runat="server" Visible="false" ReadOnly="true"></asp:Label>
                    <asp:TextBox ID="txtIRNo" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtIRNo"></asp:RequiredFieldValidator>
                </div>
              </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Load Out:</label>
                    <asp:TextBox ID="txtLoadOut" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtLoadOut"></asp:RequiredFieldValidator>
                </div>
              </div>

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Time Out:</label>
                    <telerik:RadTimePicker id="radTimeOut" Width="120px" TimeView-TimeFormat="t" runat="server" Culture="en-US">
                        <TimeView runat="server" StartTime="1:0:0" EndTime="23:30:00" Interval="0:30:0"></TimeView>
                    </telerik:RadTimePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="radTimeOut"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Station:</label>
                </div>
            </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Depo Name:</label>
                    <asp:ObjectDataSource ID="odsDepoName" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="getrecord"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlDepoName" DataSourceID="odsDepoName" Enabled="false"
                        DataTextField="Depu_Name" DataValueField="Depu_Id" AutoPostBack="true" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Depo Name" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlDepoName"></asp:RequiredFieldValidator>
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
                    <label class="col-lg-2">fuel In:</label>
                    <asp:TextBox ID="txtfuelIn" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtfuelIn"></asp:RequiredFieldValidator>
                </div>
              </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">fuel Out:</label>
                    <asp:TextBox ID="txtfuelOut" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtfuelOut"></asp:RequiredFieldValidator>
                </div>
              </div>

             <div class="row">
                <div class="col-lg-2"></div>
                <div class="form-group-2 col-lg-4 text-align-right">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" CausesValidation="false" OnClick="btnClear_Click" Text="Clear" />
                       <asp:HiddenField ID="hdf" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>

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


        
        <telerik:RadGrid runat="server" ID="radGateout" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnPageIndexChanged="radGateout_PageIndexChanged" OnNeedDataSource="radGateout_NeedDataSource">
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
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("vehbano").ToString()==""?"N/A":Eval("vehbano") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                     <telerik:GridTemplateColumn HeaderText="Army No" DataField="ArmyNo" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("ArmyNo").ToString()==""?"N/A":Eval("ArmyNo") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="Rank" DataField="Rank" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("Rank").ToString()==""?"N/A":Eval("Rank") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="Name" DataField="name" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("name").ToString()==""?"N/A":Eval("name") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="Time In" DataField="timein" DataType="System.DateTime" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("timein").ToString()==""?"N/A":Convert.ToDateTime(Eval("timein")).ToShortTimeString() %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="Type of Vehicle" DataField="typeofvehicle" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("typeofvehicle").ToString()==""?"N/A":Eval("typeofvehicle") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Quantity Unit" DataField="unit" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("unit").ToString()==""?"N/A":Eval("unit") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <%--<telerik:GridTemplateColumn HeaderText="Load In" DataField="Indname" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("Indname").ToString()==""?"N/A":Eval("Indname") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>--%>
                    <telerik:GridTemplateColumn HeaderText="IR No" DataField="irno" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("irno").ToString()==""?"N/A":Eval("irno") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Time Out" DataField="timeout" DataType="System.DateTime" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("timeout").ToString()==""?"N/A":Convert.ToDateTime(Eval("timeout")).ToShortTimeString() %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    
                    <telerik:GridTemplateColumn HeaderText="Load Out" DataField="loadout" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("loadout").ToString()==""?"N/A":Eval("loadout") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Depu Station Name" DataField="depuname" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("depuname").ToString()==""?"N/A":Eval("depuname") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Unit Station Name" DataField="unitname" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("unitname").ToString()==""?"Not Alloted":Eval("unitname") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Fuel In" DataField="fuelintankIn" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("fuelintankIn").ToString()==""?"N/A":Eval("fuelintankIn") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Fuel Out" DataField="fuelintankOut" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblPname" runat="server" Text=' <%#Eval("fuelintankOut").ToString()==""?"N/A":Eval("fuelintankOut") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>

        </telerik:RadGrid>
          </div>
    </div>

</asp:Content>
