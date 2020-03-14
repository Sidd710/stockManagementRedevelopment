<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintCompactCRV.aspx.cs" Inherits="RHPDNew.Forms.PrintCompactCRV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Club Infotech</title>
    <script src="../assets/js/jquery.min.js"></script>
<script src="../assets/js/bootstrap.js"></script>
      <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
    <style type="text/css">
 
.rgGroupCol
{
    padding-left: 0 !important;
    padding-right: 0 !important;
    font-size:1px !important;
}
 
.rgExpand,
.rgCollapse
{
    display:none !important;
}
 
</style>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
  <script type = "text/javascript">
      function PrintPanel() {
          var panel = document.getElementById("<%=pnlContents.ClientID %>");
             var printWindow = window.open('', '', 'height=1000,width=1500');
            // printWindow.document.write('<html><head><title>DIV Contents</title>');
             printWindow.document.write('<html><head><title>Club Infotech</title><link href="../assets/css/bootstrap.css" rel="stylesheet" /><link href="../assets/css/style.css" rel="stylesheet" /><style type="text/css">.rgGroupCol{    padding-left: 0 !important;    padding-right: 0 !important;    font-size:1px !important;}.rgExpand,.rgCollapse{    display:none !important;}</style>');
             printWindow.document.write('</head><body >');

             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
         }
    </script>
 
    

     <div class="row">
                <div class="form-group-2" style="float:right;margin-right:0%" id="divBTN" runat="server">
                     <asp:Button ID="Button1" runat="server" Text="Back to Full View" OnClick="btnprints_Click" style="float:right;margin-right:12%;" />
                   &nbsp;&nbsp; <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick = "return PrintPanel();" style="float:right;margin-right:-14%;" />
   
           
                      <asp:Button ID="btnprints" runat="server" Text="Print old" OnClick="btnprints_Click" Visible="false"/>
                    <%--<input type="button" id="btnprints" name="btnprints" value="Print" onclick="print_page();" />--%>
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>
         <asp:Panel id="pnlContents" runat = "server" BorderStyle="Dotted">
              <div class="row" style="margin-top:0px;height:48px">
               <div style="float:right;margin-right:18px;margin-top:0px;">
               <asp:Label ID="Label1" runat="server" style="font-family:'Times New Roman';font-size:large;"></asp:Label> <br />
                  <span style="font-family:'Times New Roman';font-size:12px;text-decoration:underline;margin-bottom:2px;margin-right:35px"> ILO IAFZ-2096</span>
        
            </div></div>
            
           
         
    <div class="heading-bg">
        <div class="container">
           <label style="font-size:x-large;font:bold;   
    color: #373739;
    display: inline-block;
    font-size: 30px;
    margin: -7px 0 0;
    padding: 15px 90px;
    text-decoration:underline">CRV</label> 
           
        </div>
    </div>
    <div>
        
        <div >
            
              <div style="float:right;margin-right:35px">
               <asp:Label ID="lblCRV" runat="server" style="font-family:'Times New Roman';font-size:12px;"></asp:Label> <br />
                  <span style="font-family:'Times New Roman';font-size:12px;"> 408 HQ Coy ASC (Pet)<br />
              C/o 56 APO</span>
        
            </div>
            

        
             <div class="clearfix"></div>
             <div class="container" style="width:100%;float:left"> 
                 

            
                 <table style="background-color:none !important;" >
                     <tr>
                         <td style="width:150px;"><label style="float:left">Received From:</label>       
                 </td><td><asp:Label   ID="lblRecivedFrom"  runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label>  </td>
                     </tr>
                      <tr>
                         <td> <label style="float:left" runat="server" id="lblATSO"> </label></td>
                          <td>  <asp:Label  ID="lblATNo" runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label>
                   </td>
                     </tr>
                      <tr>
                         <td><label style="float:left">Vechicle No[Challan No]:</label></td>
                          <td> <asp:Label  ID="lblVechicleNo" runat="server"  Style="width:98%;word-wrap:break-word;display:block"></asp:Label>
                        
            </td>
                     </tr>
                 </table>
                 
                 </div>
            <div class="clearfix"></div>
            <div class="container" style="margin-left:0px;width:100%">
                                  
              
                 <asp:Literal runat="server" ID="ltrTable"></asp:Literal>
          
                 
      <asp:Label ID="lblAmount" runat="server" Text="" style="float:right;margin-right:95px" ></asp:Label>
                 <br />
                 <div style="margin-top:0px;height: 50px;text-align: center;">
        <div class="container">
        <asp:Label ID="lblCountItems" runat="server" ></asp:Label><br />
            <asp:Label ID="lblInWords" runat="server" ></asp:Label><br /><br />
                     <div class="row" style="text-align:left;margin-left:95px;margin-right:95px;">
             <asp:Label  ID="lblCatogory"  runat="server"  Text="Certified that above mentioned items has been recieved and credited in "></asp:Label>
           <%-- <asp:Label Visible="false" ID="lblCRVdt"  runat="server" Text=" group vide DS No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt"></asp:Label>--%>
               </div>
            <br />
            <asp:Label ID="Label3" runat="server" Style="text-decoration:underline" >COUNTERSIGNED</asp:Label>
               </div>
            
         </div> 
                </div> 
                          
        </div>
         
    </div>
              <div class="row" style="height:500px;">
                  
              </div>
    </asp:Panel></form>
</body>
</html>

