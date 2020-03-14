<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ESLIssue.aspx.cs" Inherits="RHPDNew.Forms.ESLIssue" MasterPageFile="~/RHPD.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ContentPlaceHolderID="head" ID="Content1" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../js/jquery.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
  
      <div class="heading-bg">
        <div class="container">
            <h1>ESL Issue</h1>
        </div>
    </div>
    <div>

        <div class="clearfix"></div>

        <div class="container">

            <p>&nbsp;</p>
            <p>&nbsp;</p>
       
            <asp:Label ID="lblBatchId" runat="server"  Visible="false" ></asp:Label>
            <asp:Label ID="lblQuantity" runat="server"  Visible="false"></asp:Label>

             <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Batch Id :  </label>   
                    <asp:Label ID="lblBatchName" runat="server" Style="font-family: 'Times New Roman'; font-size: large;"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Product Name :  </label>   
                    <asp:Label ID="lblProductName" runat="server" Style="font-family: 'Times New Roman'; font-size: large;"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Issue To : </label>
                    <asp:DropDownList ID="ddlIssueTo" runat="server" CssClass="col-lg-4 form-control">
                        <asp:ListItem Value="-- Select --" Text="-- Select --">-- Select --</asp:ListItem>
                        <asp:ListItem Value="Lab" Text="Lab"> Lab </asp:ListItem>
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="-- Select --" runat="server" ValidationGroup="issue" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlIssueTo"></asp:RequiredFieldValidator>
                    <%--<asp:TextBox ID="txtIssueTo" runat="server"  CssClass="col-lg-4 form-control" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv" ErrorMessage="*" ValidationGroup="issue" runat="server" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtIssueTo"></asp:RequiredFieldValidator>--%>

                </div>
            </div>


               <div class="row" id="">
                <div class="form-group-2">
                    <label id="lbltotlquantity" runat="server" class="col-lg-2"> Total Quantity :  </label>
                    <asp:Label ID="lbltotalQuantity"  CssClass="col-lg-4 form-control" runat="server" ></asp:Label>
                </div>
              </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Quantity Type :  </label>

                       <asp:ObjectDataSource ID="odsQuantitytype" runat="server" TypeName="RHPDComponent.ManagestockComp" SelectMethod="SelectQuantityType"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlQuantitytype" Enabled="false" OnDataBound="ddlQuantitytype_DataBound" DataSourceID="odsQuantitytype" DataTextField="QuantityType" DataValueField="Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" runat="server" ValidationGroup="issue" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlQuantitytype"></asp:RequiredFieldValidator>
                   <%-- <asp:RequiredFieldValidator ID="rfvddlDepoName" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Quantity type" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlQuantitytype"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtQuantitytype" runat="server" CssClass="col-lg-4 form-control" placeholder="Eg. in kg or in ltr"></asp:TextBox>
                    <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txtQuantitytype" ID="txtQuantitytype_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters"></asp:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" ValidationGroup="issue" runat="server" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtQuantitytype"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

                 <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Quantity Issue :  </label>

                    <asp:TextBox ID="txtQuantity" runat="server"  CssClass="col-lg-4 form-control" ></asp:TextBox>
                    <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txtQuantity" ID="txtQuantity_FilteredTextBoxExtender" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="*" ValidationGroup="issue" runat="server" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtQuantity"></asp:RequiredFieldValidator>
                      <asp:CustomValidator ID="ctmvQtyIssued" runat="server" EnableClientScript="true"  ValidationGroup="issue" 
                        OnServerValidate="ctmvQtyIssued_ServerValidate" ErrorMessage="*"  ForeColor="Red" ControlToValidate="txtQuantity"></asp:CustomValidator>

                </div>
            </div>
             
             <div class="row" id="currentstatus" runat="server" visible="false">
                <div class="form-group-2">
                    <label id="Label1" runat="server" class="col-lg-2"> Current Status :  </label>
                    <asp:Label ID="lblCurrentStatus" Text="" runat="server" ></asp:Label>
                </div>
              </div>


            <div class="row" id="Status" runat="server" visible="false">
                <div class="form-group-2">
                    <label class="col-lg-2">Set Status :   </label>
                    <asp:DropDownList ID="ddlStatus"  OnDataBound="ddlStatus_DataBound1"  runat="server" CssClass="col-lg-4 form-control" >
                       <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlddlStatus" ErrorMessage="*" InitialValue="0" ValidationGroup="issued" runat="server" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="ddlStatus"></asp:RequiredFieldValidator>

                </div>
            </div>

             <div class="row" id="RecieveDate" runat="server">
                <div class="form-group-2">
                    <label class="col-lg-2">Recieve Date: </label>
                    <asp:TextBox ID="txtRecieve" runat="server" CssClass="col-lg-4 form-control"  onKeyDown="javascript: return false;" ></asp:TextBox>
                    <asp:CalendarExtender runat="server" Enabled="True" TargetControlID="txtRecieve" ID="txtRecieve_CalendarExtender"  Format="dd MMM yyyy"  ></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="rfvRecieveDate" ErrorMessage="*" ValidationGroup="issued" runat="server" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtRecieve"></asp:RequiredFieldValidator>
                </div>
            </div>
       
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Remarks By NUR/E GP :   </label>

                    <asp:TextBox ID="txtRemarkbyNureGP" runat="server" TextMode="MultiLine"  CssClass="col-lg-4 form-control" ></asp:TextBox>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="*" ValidationGroup="issue" runat="server" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtRemarkbyNureGP"></asp:RequiredFieldValidator>--%>

                </div>
            </div>

              <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Remarks By JCO-I/E-GP :   </label>

                    <asp:TextBox ID="txtRemarkbyJCO" runat="server" TextMode="MultiLine"  CssClass="col-lg-4 form-control" ></asp:TextBox>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="*" ValidationGroup="issue" runat="server" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtRemarkbyJCO"></asp:RequiredFieldValidator>--%>

                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Remarks By DSO :  </label>

                    <asp:TextBox ID="txtRemarkbyDSO" runat="server" TextMode="MultiLine"  CssClass="col-lg-4 form-control" ></asp:TextBox>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="*" ValidationGroup="issue" runat="server" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtRemarkbyDSO"></asp:RequiredFieldValidator>--%>


                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Overall  Remarks : </label>
                    <asp:TextBox ID="txtOverallRemark" runat="server" TextMode="MultiLine"  CssClass="col-lg-4 form-control" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="*" ValidationGroup="issue" runat="server" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtOverallRemark"></asp:RequiredFieldValidator>
                </div>
            </div>

              <div class="row">
                      <label class="col-lg-2">Is Active</label>
                    <div class="form-group-2 col-lg-4 text-align-right padding-0">   
                <asp:CheckBox ID="chkIsActive" CssClass="cssIsActive pull-left" Checked="true" runat="server" Text=""  Enabled="false"   />   
              </div>
                    </div>
            <div class="row">
                <div class="col-lg-2"></div>
                <div class="form-group-2 col-lg-4 text-align-right">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="issue" runat="server" Text="Submit"  OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" CausesValidation="false" /><br />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>
            </div>
               <div class="clearfix"></div>   
              <div class="clearfix"></div>

           <br />


        </div>
          
    </div>
</asp:Content>
