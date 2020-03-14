<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="GateRegister.aspx.cs" Inherits="RHPDNew.Forms.GateRegister" %>

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
        td, th {
    padding: 2.5px !important;
}
    </style>
    <script>
        function swap() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_Gatout").style.display == 'none')
            {
                document.getElementById("ctl00_ContentPlaceHolder1_Gatout").style.display = 'block'
                document.getElementById("ctl00_ContentPlaceHolder1_GateIn").style.display = 'none';
            }
            else
            {
                document.getElementById("ctl00_ContentPlaceHolder1_Gatout").style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_GateIn").style.display = 'block';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="heading-bg">
        <div class="container">
            <h1>Register Gate In/out</h1>
        </div>
    </div>
    <div id="selectgat" runat="server">
        <div class="clearfix"></div>
        <div class="container">
            <p>&nbsp;</p>
            <p>&nbsp;</p>
      
        <div class="row">
            <div class="form-group-2">
                <label class="col-lg-2">Select Gate : </label>
                <asp:RadioButtonList ID="rbtnSelectGate" runat="server"  ValidationGroup="assign" OnClick="swap();" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Gate Out" Value="0" Selected="True" ></asp:ListItem>
                    <asp:ListItem Text="Gate In" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>

         <div class="row" style="display:none;">
            <div class="form-group-2"></div>
            <div class="form-group-2 col-lg-4 text-align-right">
                <asp:Button ID="btnSelect" CssClass="btn btn-primary" ValidationGroup="assign" runat="server" Text="Select" OnClick="btnSelect_Click" />
                <asp:Button ID="btnCancelSelect" CssClass="btn btn-warning" runat="server" CausesValidation="false" OnClick="btnCancelSelect_Click" Text="Cancel" />
            </div>
        </div>

      </div>
    </div>

    <div id="Gatout" runat="server" >

        <div class="clearfix"></div>
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
                    <label class="col-lg-2">Vechicle No:</label>
                    <asp:TextBox ID="txtVechicleNo" class="col-lg-4 form-control" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtVechicleNo"></asp:RequiredFieldValidator>
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
                <asp:FilteredTextBoxExtender runat="server" ID="ftetxtName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtName"></asp:FilteredTextBoxExtender>
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
                    <asp:TextBox ID="txtTypeofVehicle" class="col-lg-4 form-control" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtTypeofVehicle"></asp:RequiredFieldValidator>
                </div>
              </div>
                
             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Quantity Unit:</label>

                     <asp:TextBox ID="txtQuantityUnit" class="col-lg-4 form-control" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtQuantityUnit"></asp:RequiredFieldValidator>

                    <%--<asp:ObjectDataSource ID="odsQuantitytype" runat="server" TypeName="RHPDComponent.ManagestockComp" SelectMethod="SelectQuantityType"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlQuantitytype" OnDataBound="ddlQuantitytype_DataBound" DataSourceID="odsQuantitytype" DataTextField="QuantityType" DataValueField="Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlDepoName" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Quantity type" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlQuantitytype"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">IR No:</label>
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

      <%--      <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Station:</label>
                </div>
            </div>--%>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Depo Name:</label>
<%--                    <asp:TextBox ID="txtDepoName" class="col-lg-4 form-control" runat="server"></asp:TextBox>--%>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="DdlDepoNameGateOut"></asp:RequiredFieldValidator>--%>

                      <asp:ObjectDataSource ID="OdsDeponameGateOut" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="getrecord">

                      </asp:ObjectDataSource>
                    <asp:DropDownList ID="DdlDepoNameGateOut"  DataSourceID="OdsDeponameGateOut" OnDataBound="DdlDepoNameGateOut_DataBound1" DataTextField="Depu_Name" DataValueField="Depu_Id" AutoPostBack="false"  runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Depo Name" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="DdlDepoNameGateOut"></asp:RequiredFieldValidator>
                  <%--<asp:ObjectDataSource ID="OdsDeponameGateOut" runat="server" TypeName="RHPDComponent.GatComponent" SelectMethod="getrecord"></asp:ObjectDataSource>
                    <asp:DropDownList ID="DdlDepoNameGateOut" DataSourceID="OdsDeponameGateOut" Enabled="true"
                        DataTextField="Depu_Name" DataValueField="Depu_Id" AutoPostBack="true" runat="server"
                         CssClass="col-lg-4 form-control" OnDataBound="DdlDepoNameGateOut_DataBound">
                    </asp:DropDownList>--%>
<%--                    --%>
                </div>
            </div>

            <div class="row" id="unit" runat="server" visible="false">
                <div class="form-group-2">
                    <label class="col-lg-2">Unit Master: </label>

                    <asp:TextBox ID="txtUnitMaster" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="grpunit" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtUnitMaster"></asp:RequiredFieldValidator>

                  <%--  <asp:DropDownList ID="ddlUnitMaster" DataSourceID="odsUnitMaster" Enabled="false" DataTextField="Unit_Name" DataValueField="Unit_Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="odsUnitMaster" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="GetUnitByDID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlDepoName" PropertyName="SelectedValue" Name="dID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="rfvddlUnitMaster" ValidationGroup="grpunit" runat="server" ErrorMessage="Please Select Unit Master" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlUnitMaster"></asp:RequiredFieldValidator>--%>

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

             <div class="row" >
                <div class="col-lg-2"></div>
                <div class="form-group-2 col-lg-4 text-align-right">
                    <asp:Button ID="btnSubmitGateOut" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmitGateOut_Click" />
                    <asp:Button ID="btnClearGateOut" CssClass="btn btn-warning" runat="server" CausesValidation="false" OnClick="btnClearGateOut_Click" Text="Clear" />
                       <asp:HiddenField ID="hdfGateOut" runat="server" />
                    <asp:Label ID="lblGateOut" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
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
        
          </div>
    </div>

    <div id="GateIn" runat="server" style="display:none;" >

        <div class="clearfix"></div>
        <div class="container">
            

            <div class="row">
                <div class="form-group-2">
                    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="GateIn"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server" />
                </div>
             </div>



            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Recieved From:</label>

                    <asp:DropDownList ID="ddlRecievedfrom" runat="server" CssClass="col-lg-4 form-control" OnDataBound="ddlRecievedfrom_DataBound">
                        <asp:ListItem Value="0" >-- Select --</asp:ListItem>
                        <asp:ListItem Value="Local Purchase">Local Purchase</asp:ListItem>
                        <asp:ListItem Value="Central Procruitment">Central Procruitment</asp:ListItem>
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" InitialValue="0" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlRecievedfrom"></asp:RequiredFieldValidator>
                </div>
            </div>

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Vechicle No:</label>
                    <asp:TextBox ID="txtVechicleNo1" class="col-lg-4 form-control" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtVechicleNo1"></asp:RequiredFieldValidator>
                </div>
              </div>

           <%-- <div class="row" visible="false" runat="server">
                <div class="form-group-2">
                    <label class="col-lg-2">Franchise No:</label>
                    <asp:TextBox ID="TextBox2" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ValidationGroup="GateIns" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtFranchiseNo"></asp:RequiredFieldValidator>
                </div>
            </div>--%>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">ArmyNo:</label>
                    <asp:TextBox ID="txtArmyNo1" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtArmyNo1"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Rank:</label>
                    <asp:TextBox ID="txtRank1" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtRank1"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Name:</label>

                    <asp:TextBox ID="txtName1" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtName1"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender runat="server" ID="fteTxtName1" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtName1"></asp:FilteredTextBoxExtender>

                     </div>
            </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Time In:</label>
                    <telerik:RadTimePicker id="radTimeIn1" Width="120px" TimeView-TimeFormat="t" runat="server" Culture="en-US">
                        <TimeView runat="server" StartTime="1:0:0" EndTime="23:30:00" Interval="0:30:0"></TimeView>
                    </telerik:RadTimePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" 
                        SetFocusOnError="true" ControlToValidate="radTimeIn1"></asp:RequiredFieldValidator>
                </div>
            </div>

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2"> Type of Vehicle:</label>
                    <asp:TextBox ID="txtTypeofVehicle1" class="col-lg-4 form-control" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtTypeofVehicle1"></asp:RequiredFieldValidator>
                </div>
              </div>
                
             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Quantity Unit:</label>

                     <asp:TextBox ID="txtQuantityUnit1" class="col-lg-4 form-control" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtQuantityUnit1"></asp:RequiredFieldValidator>

                    <%--<asp:ObjectDataSource ID="odsQuantitytype" runat="server" TypeName="RHPDComponent.ManagestockComp" SelectMethod="SelectQuantityType"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlQuantitytype" OnDataBound="ddlQuantitytype_DataBound" DataSourceID="odsQuantitytype" DataTextField="QuantityType" DataValueField="Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlDepoName" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Quantity type" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlQuantitytype"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Load In:</label>
                    <asp:TextBox ID="txtLoadIn1" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtLoadIn1"></asp:RequiredFieldValidator>
                </div>
              </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">IR No:</label>
                    <asp:TextBox ID="txtIRNo1" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtIRNo1"></asp:RequiredFieldValidator>
                </div>
              </div>

     

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Time Out:</label>
                    <telerik:RadTimePicker id="radTimeOut1" Width="120px" TimeView-TimeFormat="t" runat="server" Culture="en-US">
                        <TimeView runat="server" StartTime="1:0:0" EndTime="23:30:00" Interval="0:30:0"></TimeView>
                    </telerik:RadTimePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" 
                        ControlToValidate="radTimeOut1"></asp:RequiredFieldValidator>
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
<%--                    <asp:TextBox ID="txtDepoName1" class="col-lg-4 form-control" runat="server"></asp:TextBox>--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" InitialValue="0" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red"
                         SetFocusOnError="true" ControlToValidate="ddlDepoName"></asp:RequiredFieldValidator>

                  


                        <asp:ObjectDataSource ID="odsDepoName" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="getrecord"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlDepoName" OnDataBound="ddlDepoName_DataBound" DataSourceID="OdsDeponameGateOut" DataTextField="Depu_Name" DataValueField="Depu_Id" AutoPostBack="false"  runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                 
<%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Depo Name" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlDepoName"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="row" id="Div2" runat="server" visible="false">
                <div class="form-group-2">
                    <label class="col-lg-2">Unit Master: </label>

                    <asp:TextBox ID="txtUnitMaster1" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtUnitMaster1"></asp:RequiredFieldValidator>

                  <%--  <asp:DropDownList ID="ddlUnitMaster" DataSourceID="odsUnitMaster" Enabled="false" DataTextField="Unit_Name" DataValueField="Unit_Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="odsUnitMaster" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="GetUnitByDID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlDepoName" PropertyName="SelectedValue" Name="dID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="rfvddlUnitMaster" ValidationGroup="grpunit" runat="server" ErrorMessage="Please Select Unit Master" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlUnitMaster"></asp:RequiredFieldValidator>--%>

                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">fuel In:</label>
                    <asp:TextBox ID="txtfuelIn1" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtfuelIn1"></asp:RequiredFieldValidator>
                </div>
              </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">fuel Out:</label>
                    <asp:TextBox ID="txtfuelOut1" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ValidationGroup="GateIn" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtfuelOut1"></asp:RequiredFieldValidator>
                </div>
              </div>

             <div class="row">
                <div class="col-lg-2"></div>
                <div class="form-group-2 col-lg-4 text-align-right">
                    <asp:Button ID="btnSubmitGateIn" CssClass="btn btn-primary" ValidationGroup="GateIn" runat="server" Text="Submit" OnClick="btnSubmitGateIn_Click" />
                    <asp:Button ID="btnCancelGateIn" CssClass="btn btn-warning" runat="server" CausesValidation="false" OnClick="btnCancelGateIn_Click1" Text="Clear" />
                    <asp:HiddenField ID="hdnGateIn" runat="server" />
                    <asp:Label ID="lblGateIn" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
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
        
          </div>
    </div>

    <div id="grid">

            <telerik:RadGrid runat="server" ID="radGateout" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="radGateout_ItemCommand" OnPageIndexChanged="radGateout_PageIndexChanged" OnNeedDataSource="radGateout_NeedDataSource">
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

                         <telerik:GridTemplateColumn HeaderText="Recieved From" DataField="Recievedfrom" DataType="System.String" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:Label ID="lblRecvdFrom" runat="server" Text=' <%#Eval("Recievedfrom").ToString()==""?"N/A":Eval("Recievedfrom") %>'></asp:Label>
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
                                <asp:Label ID="lblstationDepuId" runat="server" Text=' <%#Eval("DEPUNAME").ToString() %>'></asp:Label>
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

                     <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">

                                    <asp:LinkButton ID="lkactive" runat="server" ForeColor="Red" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("Id")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>
                                    <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false"  ForeColor="Blue" Text="Edit" CommandName="Editnew" CommandArgument='<%#Eval("Recievedfrom")+"< "+Eval("vehbano")+"<"+Eval("ArmyNo")+"<"+Eval("Rank")+"<"+Eval("name")+"<"+Eval("timein")+"<"+Eval("typeofvehicle")+"<"+Eval("unitQuantityTypeId")+"<"+Eval("IdtId")+"<"+Eval("loadin")+"<"+Eval("timeout")+"<"+Eval("loadout")+"<"+Eval("stationDepuID")+"<"+Eval("fuelintankIn")+"<"+Eval("fuelintankOut")+"< "+ Eval("Id")%>'></asp:LinkButton>

                                </div>
                            </ItemTemplate>

                        </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>

        </telerik:RadGrid>
        </div>

</asp:Content>
