<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ESLIssueForwardingNote.aspx.cs" Inherits="RHPDNew.Forms.ESLIssueForwardingNote" MasterPageFile="~/RHPD.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ContentPlaceHolderID="head" ID="Content1" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
    <style type="text/css">
        tbody tr:nth-of-type(even) {background: none}
        tbody tr:nth-of-type(odd) {background: none}        
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../js/jquery.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
  
      <div class="heading-bg">
        <div class="container">
            <h1>ESL Issue</h1>
        </div>
         <div class="container">
            <h3><asp:Label ID="lblForwardNoteProductName" runat="server"  Visible="true" ></asp:Label></h3>
        </div>
    </div>
    <div>

        <div class="clearfix"></div>
                

        <div class="container">

            <p>&nbsp;</p>
            <p>&nbsp;</p>
       
            <asp:Label ID="lblBatchId" runat="server"  Visible="false" ></asp:Label>
            <asp:Label ID="lblQuantity" runat="server"  Visible="false"></asp:Label>
            <br/>
            

            <table style="width:100%; border:hidden; background:none;">
                <tr class="tr">
                    <td class="tdFloatLeft">                        
                    </td>
                    <td class="tdFloatRight">
                    <label class="formationNoteLabels">Forwarding Note No:</label>                    
                    <asp:TextBox ID="txtForwardingNoteNumber" runat="server" CssClass="formationNoteControls"></asp:TextBox>                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter Forwading Note Number!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtForwardingNoteNumber"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">                        
                    </td>
                    <td class="tdFloatRight">
                    <label class="formationNoteLabels">Date:</label> 
                    <telerik:RadDatePicker CssClass="form-control" Culture="en-US" RenderMode="Lightweight" ID="txtForwardNoteDate" Width="280px" runat="server" DateInput-DateFormat="dd-MMM-yyyy">
                        </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter Date!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtForwardNoteDate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr >
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">1. Designation of officer sending samples, his postal and telegraphic address:</label>
                    <asp:TextBox ID="txtDesignation" runat="server" CssClass="formationNoteControls"></asp:TextBox>
                    <asp:TextBox ID="txtPostalTeleAddress" runat="server" CssClass="formationNoteControls" TextMode="MultiLine" Height="50px"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter Officers' Desigantion!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtDesignation"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter Officers' Postal Address!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtPostalTeleAddress"></asp:RequiredFieldValidator>
                    </td>
                    <td class="tdFloatRight">
                    <label class="formationNoteLabels">2. Addressee:</label>   
                    <asp:TextBox ID="txtAddressee" runat="server"  CssClass="formationNoteControls"  TextMode="MultiLine" Height="75px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the Adressee details!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtAddressee"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                      <label class="formationNoteLabels"> 3. Nomenclature of store:</label>   
                    <asp:TextBox ID="txtNomenStore" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter Nomenclature of store!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtNomenStore"></asp:RequiredFieldValidator>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels"> 4. Type of sample container(s):</label>   
                    <asp:TextBox ID="txtContainerType" runat="server"  CssClass="formationNoteControls"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter type of sample container!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtContainerType"></asp:RequiredFieldValidator>                    
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                    <label class="formationNoteLabels"> 5. Sample references Nos (s) and/or identification marks (s) on samples label or containers:</label>   
                    <asp:TextBox ID="txtSampleRefNumber" runat="server"  CssClass="formationNoteControls" ></asp:TextBox>                   
                    <asp:TextBox ID="txtSampleRefIdentityMarks" runat="server"  CssClass="formationNoteControls" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter Sample reference number!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtSampleRefNumber"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter Identification Marks on samples label!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtSampleRefIdentityMarks"></asp:RequiredFieldValidator>
                    </td>
                    <td class="tdFloatRight">
                         <label class="formationNoteLabels"> 6. Acceptance of Tender No and Date or other references:</label> 
                    <%--<asp:Label ID="lblAtNumber" runat="server"  Visible="true" ></asp:Label>  --%>
                    <asp:TextBox ID="txtAtNumber" runat="server"  CssClass="formationNoteControls" ReadOnly="true" BackColor="#ccffcc"></asp:TextBox><br />
                    <%--<asp:TextBox ID="txtAtNoDate" runat="server"  CssClass="formationNoteControls" Width="150px"></asp:TextBox>--%>                                        
                    <asp:TextBox ID="txtAtNoReferences" runat="server"  CssClass="formationNoteControls" TextMode="MultiLine" Height="50px"></asp:TextBox>    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter quanity of samples submitted!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtAtNoReferences"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels"> 7. Quantity of sample (s) submitted:</label>   
                    <asp:TextBox ID="txtSampleQuantity" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter quanity of samples submitted!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtSampleQuantity"></asp:RequiredFieldValidator>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels"> 8. Number of sample submitted:</label>   
                    <asp:TextBox ID="txtNumberofSamples" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter the number of samples submitted!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtNumberofSamples"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels"> 9. Type of sample(s) (eg: average composite or so on):</label>   
                    <asp:TextBox ID="txtSampleType" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter the type of samples!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtSampleType"></asp:RequiredFieldValidator>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">10. Date of sample(s) dispatched:</label>   
                    <%--<asp:TextBox ID="txtDispatchDate" runat="server"  CssClass="formationNoteControls" Width="150px" ></asp:TextBox>--%>
                        <telerik:RadDatePicker CssClass="form-control" Culture="en-US" RenderMode="Lightweight" ID="txtDispatchDate" Width="280px" runat="server" DateInput-DateFormat="dd-MMM-yyyy">
                        </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="txtDispatchDateValidator" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the date of sample dispatched!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtDispatchDate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                         <label class="formationNoteLabels">11. Method of dispatch (including aircraft number, trains, time and so on if possible):</label>   
                    <asp:TextBox ID="txtDispatchMethod" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter the method of dispatch!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtDispatchMethod"></asp:RequiredFieldValidator>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">12. Date of sample(s) drawn:</label>   
                    <%--<asp:TextBox ID="txtSampleDrawnDate" runat="server"  CssClass="formationNoteControls" Width="150px" ></asp:TextBox>--%>
                     <telerik:RadDatePicker CssClass="form-control" Culture="en-US" RenderMode="Lightweight" ID="txtSampleDrawnDate" Width="280px" runat="server" DateInput-DateFormat="dd-MMM-yyyy">
                        </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="txtSampleDrawnDateValidator" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the date of sample drawn!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtSampleDrawnDate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                         <label class="formationNoteLabels">13. Name and Rank of individual who drew the sample:</label>   
                    <asp:TextBox ID="txtDrawerNameRank" runat="server"  CssClass="formationNoteControls" ></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please Enter the name and Rank!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtDrawerNameRank"></asp:RequiredFieldValidator>  
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">14. Quantity of the material which the sample(s) represent(s):</label>   
                    <asp:TextBox ID="txtQuantityRepresentBySample" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the quantity of the matetrial sample represents!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtQuantityRepresentBySample"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels" style="width:250px">15. Details of represented material:</label><br/> 
                    </td>
                    <td class="tdFloatRight"></td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(a) Source of supply:</label>   
                        <%--<asp:Label ID="lblSupplySource" runat="server"  Visible="true" ></asp:Label>--%>
                    <asp:TextBox ID="txtSupplySource" runat="server"  CssClass="formationNoteControls" ReadOnly="true" BackColor="#ccffcc"></asp:TextBox>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(b) Date of receipt of consignment:</label>   
                        <%--<asp:Label ID="lblReceiptDate" runat="server"  Visible="true" ></asp:Label>--%>
                    <asp:TextBox ID="txtReceiptDate" runat="server"  CssClass="formationNoteControls" ReadOnly="true" BackColor="#ccffcc"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(c) Intended destination of consignment:</label>   
                    <asp:TextBox ID="txtIntendedDestination" runat="server"  CssClass="formationNoteControls" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the inteneded destination of consignment!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtIntendedDestination"></asp:RequiredFieldValidator>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(d) Date of filling/manufacture:</label>   
                        <%--<asp:Label ID="lblFillingDate" runat="server"  Visible="true" ></asp:Label>--%>
                    <%--<asp:TextBox ID="txtFillingDate" runat="server"  CssClass="formationNoteControls" ></asp:TextBox>--%>
                        <telerik:RadDatePicker CssClass="form-control" Culture="en-US" RenderMode="Lightweight" ID="txtFillingDate" Width="280px" runat="server" DateInput-DateFormat="dd-MMM-yyyy">
                        </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="txtFillingDateValidator" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtFillingDate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(e) Batch No. and date of manufacture: </label>   
                        <%--<asp:Label ID="lblBatchNumber" runat="server"  Visible="true" ></asp:Label>--%>
                    <asp:TextBox ID="txtBatchNumber" runat="server"  CssClass="formationNoteControls" ReadOnly="true" BackColor="#ccffcc" ></asp:TextBox>
                        <%--<label class="formationNoteLabels" style="margin-left:20px;"></label>--%>
                        <%--<asp:Label ID="lblManufactureDate" runat="server"  Visible="true"></asp:Label>--%>
                    <asp:TextBox ID="txtManufactureDate" runat="server"  CssClass="formationNoteControls" ReadOnly="true" BackColor="#ccffcc"></asp:TextBox>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(f) I note no. and date:</label>   
                        <asp:TextBox ID="txtINoteNumber" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                        <telerik:RadDatePicker CssClass="form-control" Culture="en-US" RenderMode="Lightweight" ID="txtINoteDate" Width="280px" runat="server" DateInput-DateFormat="dd-MMM-yyyy">
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the I note number!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtINoteNumber"></asp:RequiredFieldValidator>
                    <%--<asp:TextBox ID="txtINoteDate" runat="server"  CssClass="formationNoteControls" Width="150px" ></asp:TextBox>--%>
                        
                    <asp:RequiredFieldValidator ID="txtINoteDateValidator" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtINoteDate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(g) Reference and date of any previous test report or correspondence on represented material:</label>   
                    <asp:TextBox ID="txtPreviousTestReference" runat="server"  CssClass="formationNoteControls" TextMode="MultiLine" Height="50px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the Reference and date of any previous test report!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtPreviousTestReference"></asp:RequiredFieldValidator>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(h) Size of container in which stock is held/supply made:</label>   
                        <%--<asp:Label ID="lblContainerSize" runat="server"  Visible="true"></asp:Label>--%>
                    <asp:TextBox ID="txtContainerSize" runat="server"  CssClass="formationNoteControls" ReadOnly="true" BackColor="#ccffcc"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the Size of container in which stock is held/supply made!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtContainerSize"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(i) Tank No.(s)/Tanker No.(s):</label>   
                    <asp:TextBox ID="txtTankNumber" runat="server"  CssClass="formationNoteControls" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the Tank/Tanker Numbers!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtTankNumber"></asp:RequiredFieldValidator>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(j) Full details of marking for container stock/details of last operation before sampling for bulk store:</label>   
                    <asp:TextBox ID="txtContainerMarkingDetails" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the marking details!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtContainerMarkingDetails"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels" style="width:250px;">16. Whether the material samples is:</label><br/> 
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(a) Trade owned:</label>   
                    <asp:TextBox ID="txtTradeOwned" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tr">
                    
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(b) Trade owned/offered for Govt. acceptance or:</label>   
                    <asp:TextBox ID="txtTradeOfferedGovt" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(c) Govt. stock:</label>   
                    <asp:TextBox ID="txtGovtStock" runat="server"  CssClass="formationNoteControls"></asp:TextBox>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                    <label class="formationNoteLabels">17. Reason test required (fullest possible details should be given particularly in the case of complaint samples):</label>   
                    <asp:TextBox ID="txtTestReason" runat="server"  CssClass="formationNoteControls" TextMode="MultiLine" Height="75px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the reason test required!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtTestReason"></asp:RequiredFieldValidator>
                    </td>                    
                    <td class="tdFloatRight">                        
                        <label class="formationNoteLabels">18. Particulars governing supply (particulars to which samples are required to be tested):</label>   
                    <asp:TextBox ID="txtGoverningSupply" runat="server"  CssClass="formationNoteControls" TextMode="MultiLine" Height="75px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ValidationGroup="FormationNoteGrp" runat="server" ErrorMessage="Please enter the particulars governing supply!" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtGoverningSupply"></asp:RequiredFieldValidator>
                    </td>
                </tr>                
            </table>
            
                                    
            <div class="row">
                <div class="formationNoteLabels"></div><br/>
                <div class="form-group-2 col-lg-4 text-align-right" style="margin-left:20%">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="FormationNoteGrp" runat="server" Text="Submit"  OnClick="btnSubmit_Click" />
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

