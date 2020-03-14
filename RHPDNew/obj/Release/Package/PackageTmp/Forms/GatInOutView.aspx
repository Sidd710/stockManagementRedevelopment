<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="GatInOutView.aspx.cs" Inherits="RHPDNew.Forms.GatInOutView" %>


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
            <h1>Register Gate In/out</h1>
        </div>
    </div>
    <div id="selectgat" runat="server">
        <div class="clearfix"></div>
        <div class="container">
            <p>&nbsp;</p>
            <p>&nbsp;</p>
         <div class="row">
                <div class="form-group-2" style="float:right;">
                   <%--<input type="button" value="Print this page" onclick=""/>--%>
                    <%-- <input type="button" id="btnprint" value="Print this Page" onclick="print_page()" />--%>
                    <asp:Button ID="btnprints" runat="server" Text="print"/>
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>

        <div class="row">
            <div class="form-group-2">
                <label class="col-lg-2">Select Gate : </label>
                 <asp:Label ID="lblSelectGate" runat="server" Text=""></asp:Label>
            </div>
        </div>
            

      </div>
    </div>

    <div id="Gatout" runat="server" visible="false">

        <div class="container">

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Vechicle No:</label>
                     <asp:Label ID="lblVechicleNo" runat="server" Text=""></asp:Label>
                </div>
              </div>

           <%-- <div class="row" visible="false" runat="server">
                <div class="form-group-2">
                    <label class="col-lg-2">Franchise No:</label>
                    <asp:TextBox ID="txtFranchiseNo" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtFranchiseNo" runat="server" ValidationGroup="grps" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtFranchiseNo"></asp:RequiredFieldValidator>
                </div>
            </div>--%>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">ArmyNo:</label>
                    <asp:Label ID="lblArmyNo" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Rank:</label>
                    <asp:Label ID="lblRank" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Name:</label>
                     <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                </div>
            </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Time In:</label>
                    <asp:Label ID="lblTimeIn" runat="server" Text=""></asp:Label>
                </div>
            </div>

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2"> Type of Vehicle:</label>
                      <asp:Label ID="lblTypeofVehicle" runat="server" Text=""></asp:Label>
                </div>
              </div>
                
             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Quantity Unit:</label>
                     <asp:Label ID="lblQuantityUnit" runat="server" Text=""></asp:Label>
                </div>
            </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">IR No:</label>
                    <asp:Label ID="lblIRNo" runat="server" Text=""></asp:Label>
                </div>
              </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Load Out:</label>
                     <asp:Label ID="lblLoadOut" runat="server" Text=""></asp:Label>
                </div>
              </div>

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Time Out:</label>
                    <asp:Label ID="lblTimeOut" runat="server" Text=""></asp:Label>
                </div>
            </div>


             <div class="row">
                <div class="form-group-2">
                     <label class="col-lg-2">Station Depo Name:</label>
                     <asp:Label ID="lblDepoName" runat="server" Text=""></asp:Label>
                </div>
            </div>

          <%--  <div class="row" id="unit" runat="server" visible="false">
                <div class="form-group-2">
                    <label class="col-lg-2">Unit Master: </label>
                    <asp:Label ID="lblUnitMaster" runat="server" Text=""></asp:Label>
                </div>
            </div>--%>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">fuel In:</label>
                     <asp:Label ID="lblfuelIn" runat="server" Text=""></asp:Label>
                </div>
              </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">fuel Out:</label>
                    <asp:Label ID="lblfuelOut" runat="server" Text=""></asp:Label>
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

    <div id="GateIn" runat="server" visible="false">

        <div class="container">

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Recieved From:</label>
                    <asp:Label ID="lblRecievedFromGateIn" runat="server" Text=""></asp:Label>
                </div>
            </div>

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Vechicle No:</label>
                    <asp:Label ID="lblVechicleNoGateIn" runat="server" Text=""></asp:Label>
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
                     <asp:Label ID="lblArmyNoGateIn" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Rank:</label>
                    <asp:Label ID="lblRankGateIn" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Name:</label>
                    <asp:Label ID="lblNameGateIn" runat="server" Text=""></asp:Label>
                </div>
            </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Time In:</label>
                    <asp:Label ID="lblTimeInGateIn" runat="server" Text=""></asp:Label>
                </div>
            </div>

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2"> Type of Vehicle:</label>
                    <asp:Label ID="lblTypeofVehicleGateIn" runat="server" Text=""></asp:Label>
                </div>
              </div>
                
             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Quantity Unit:</label>
                    <asp:Label ID="lblQuantityUnitGateIn" runat="server" Text=""></asp:Label>

                    <%--<asp:ObjectDataSource ID="odsQuantitytype" runat="server" TypeName="RHPDComponent.ManagestockComp" SelectMethod="SelectQuantityType"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlQuantitytype" OnDataBound="ddlQuantitytype_DataBound" DataSourceID="odsQuantitytype" DataTextField="QuantityType" DataValueField="Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlDepoName" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Quantity type" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlQuantitytype"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Load In:</label>
                    <asp:Label ID="lblLoadInGateIn" runat="server" Text=""></asp:Label>
                </div>
              </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">IR No:</label>
                    <asp:Label ID="lblIRNoGateIn" runat="server" Text=""></asp:Label>
                </div>
              </div>

     

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Time Out:</label>
                    <asp:Label ID="lblTimeOutGateIn" runat="server" Text=""></asp:Label>
                </div>
            </div>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Station Depo Name:</label>
                    <asp:Label ID="lblDepoNameGateIn" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <%--<div class="row" id="Div2" runat="server" visible="false">
                <div class="form-group-2">
                    <label class="col-lg-2">Unit Master: </label>
                    <asp:Label ID="lblUnitMasterGateIn" runat="server" Text=""></asp:Label>
                </div>
            </div>--%>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">fuel In:</label>
                    <asp:Label ID="lblfuelInGateIn" runat="server" Text=""></asp:Label>
                </div>
              </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">fuel Out:</label>
                    <asp:Label ID="lblfuelOutGateIn" runat="server" Text=""></asp:Label>
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

</asp:Content>