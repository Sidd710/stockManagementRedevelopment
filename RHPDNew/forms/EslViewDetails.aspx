<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EslViewDetails.aspx.cs" Inherits="RHPDNew.Forms.EslStatusViewDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
    <style type="text/css">
        .lblSampleUnfit {
            font-size: 16px;
            text-decoration-color:red;
            text-justify:auto;
        }
        .formationNoteLabels {
            float: left;
            width: 260px;
            position: relative;
            font-size: 16px;
            text-align: left;
            font-weight: normal;
            margin-right: 5px;

        }
        .leftMargin {
            margin-top:10px;
            margin-left:290px;
            width: 500px;
            height: 25px;
            padding:10px 2px 10px 2px;
            
        }
        .viewDetailsProductName {
            margin-left:350px;
        }
        .row {
            margin-bottom: 5px;
            padding: 3px 2px 3px 2px;
        }
    </style>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $("[id*=pnlEslNew]").hide();
            $("[id*=lblSampleUnfit]").hide();
            $("[id*=btnSubmit]").hide();
            $("#rbtFit").click(function () {
                if ($('#rbtFit').is(':checked')) {
                    $("[id*=lblSampleUnfit]").hide();
                    $("[id*=pnlEslNew]").show();
                    $("[id*=btnSubmit]").show();
                }
            });
            $("#rbtUnfit").click(function () {
                if ($('#rbtUnfit').is(':checked')) {                    
                    $("[id*=pnlEslNew]").hide();
                    $("[id*=lblSampleUnfit]").show();
                    $("[id*=btnSubmit]").show();
                }
            });
            $("#btnSubmit").click(function (event) {
                if ($('#rbtFit').is(':checked')) {
                    var rdpDate = $find("dpSampleNewEsl");
                    var date = rdpDate.get_selectedDate();
                    if (date == null)
                    { 
                        alert("Please enter the new Esl date!");
                        event.preventDefault();
                        event.stopPropagation();
                        return false;
                    }
                }
            });
        });
        function CloseModal() {
            var oWnd = GetRadWindow();
            if (oWnd)
                setTimeout(function () { oWnd.close(); }, 0);
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }
    </script>--%>
    <title>Esl Forward Note Details</title>    
</head>
<body>
    <form id="EslViewDetails" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager" runat="server"></telerik:RadAjaxManager>        
        <asp:Label ID="lblBatchId" runat="server" Visible="false"></asp:Label>
        <div class="container">
            <h4><asp:Label ID="lblViewDetailsProductName" runat="server" CssClass="viewDetailsProductName" Visible="true" ></asp:Label></h4>
        </div>
    <div>
        <table style="width:100%; border:hidden; background:none;">
                <tr class="tr">
                    <td class="tdFloatLeft">                        
                    <label class="formationNoteLabels">1. Forwarding Note No :- </label>
                        <asp:Label ID="lblForwardingNoteNo" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                    <label class="formationNoteLabels">2. Date :-</label> 
                        <asp:Label ID="lblFnDate" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
               <tr class="tr">
                    <td class="tdFloatLeft">
                    <label class="formationNoteLabels">3. Current Esl Date :-</label>  
                        <asp:Label ID="lblCurrentEsl" runat="server" CssClass="formationNoteLabels"></asp:Label> 
                    </td>                    
                    <td class="tdFloatRight">                        
                        <label class="formationNoteLabels">4. Batch Status :-</label>
                        <asp:Label ID="lblBatchStatus" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr >
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">5. Designation of officer sending samples, his postal and telegraphic address :-</label>
                        <asp:Label ID="lblDesignationAndPostalAddress" runat="server" CssClass="formationNoteLabels"></asp:Label>                    
                    </td>
                    <td class="tdFloatRight">
                    <label class="formationNoteLabels">6. Addressee :-</label>
                        <asp:Label ID="lblAddressee" runat="server" CssClass="formationNoteLabels"></asp:Label>                       
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                      <label class="formationNoteLabels">7. Nomenclature of store :-</label>
                        <asp:Label ID="lblNomenStore" runat="server" CssClass="formationNoteLabels"></asp:Label>   
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">8. Type of sample container(s) :-</label>
                        <asp:Label ID="lblContainerType" runat="server" CssClass="formationNoteLabels"></asp:Label>           
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                    <label class="formationNoteLabels">9. Sample references No(s) and/or identification marks(s) on samples label or containers :-</label>
                        <asp:Label ID="lblSampleReferenceAndIndentity" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                         <label class="formationNoteLabels">10. Acceptance of Tender No and Date or other references :-</label> 
                        <asp:Label ID="lblAtDetails" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">11. Quantity of sample(s) submitted :-</label> 
                        <asp:Label ID="lblSampleQuantity" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">12. Number of sample submitted :-</label>
                        <asp:Label ID="lblSampleNumbers" runat="server" CssClass="formationNoteLabels"></asp:Label>   
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">13. Type of sample(s) :- </label>
                        <asp:Label ID="lblSampleType" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">14. Date of sample(s) dispatched :-</label>
                        <asp:Label ID="lblDispatchDate" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                         <label class="formationNoteLabels">15. Method of dispatch :-</label>
                        <asp:Label ID="lblDispatchMethod" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">16. Date of sample(s) drawn :-</label>
                        <asp:Label ID="lblSampleDrawnDate" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                         <label class="formationNoteLabels">17. Name and Rank of individual who drew the sample :-</label>   
                        <asp:Label ID="lblDrawrNameAndRank" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">18. Quantity of the material which the sample(s) represent(s) :-</label>
                        <asp:Label ID="lblSampleQuantityRepresented" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels" style="width:250px">19. Details of represented material:</label><br/>                         
                    </td>
                    <td class="tdFloatRight"></td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(a) Source of supply :-</label>
                        <asp:Label ID="lblSupplySource" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(b) Date of receipt of consignment :-</label>
                        <asp:Label ID="lblReceiptDate" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(c) Intended destination of consignment :-</label>
                        <asp:Label ID="lblIntendedDestination" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(d) Date of filling/manufacture :-</label>
                        <asp:Label ID="lblFillingDate" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(e) Batch No. and date of manufacture :-</label>
                        <asp:Label ID="lblBatchNumberAndDOM" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(f) I note no. and date :-</label>
                        <asp:Label ID="lblINoteNoAndDate" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(g) Reference and date of any previous test report or correspondence on represented material :-</label>
                        <asp:Label ID="lblPrevTestReference" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(h) Size of container in which stock is held/supply made :-</label>
                        <asp:Label ID="lblContainerSize" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(i) Tank No.(s)/Tanker No.(s) :-</label>
                        <asp:Label ID="lblTankNo" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(j) Full details of marking for container stock/details of last operation before sampling for bulk store :-</label>
                        <asp:Label ID="lblContainerMarkingDetails" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels" style="width:250px;">20. Whether the material samples is :-</label><br/> 
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(a) Trade owned :-</label>
                        <asp:Label ID="lblTradeOwned" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">                    
                    <td class="tdFloatLeft">
                        <label class="formationNoteLabels">(b) Trade owned/offered for Govt. acceptance or :-</label>
                        <asp:Label ID="lblTradeGovtAccepted" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                    <td class="tdFloatRight">
                        <label class="formationNoteLabels">(c) Govt. stock :-</label>
                        <asp:Label ID="lblGovtStock" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>
                <tr class="tr">
                    <td class="tdFloatLeft">
                    <label class="formationNoteLabels">21. Reason test required :-</label>  
                        <asp:Label ID="lblTestReason" runat="server" CssClass="formationNoteLabels"></asp:Label> 
                    </td>                    
                    <td class="tdFloatRight">                        
                        <label class="formationNoteLabels">22. Particulars governing supply :-</label>
                        <asp:Label ID="lblGoverningSupply" runat="server" CssClass="formationNoteLabels"></asp:Label>
                    </td>
                </tr>   
            </table>
       </div>
    </form>
</body>
</html>
