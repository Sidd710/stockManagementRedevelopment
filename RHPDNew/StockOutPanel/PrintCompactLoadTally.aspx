<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintCompactLoadTally.aspx.cs" Inherits="RHPDNew.StockOutPanel.PrintCompactLoadTally" %>
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
    <form id="form2" runat="server">
         <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server"></asp:ToolkitScriptManager>
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
                <div class="form-group-2" style="float:right;margin-right:0%" id="div1" runat="server">
                         <asp:Button ID="btnprints" runat="server" Text="Back to Full View" OnClick="btnprints_Click" style="float:right;margin-right:11%;" />
                    <asp:Button ID="Button1" runat="server" Text="Print" OnClientClick = "return PrintPanel();" style="float:right;margin-right:-16%;" />
   
                 
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>
         <asp:Panel id="pnlContents" runat = "server" BorderStyle="Dotted">
              <div class="row" style="margin-top:0px;height:48px">
               <div style="float:right;margin-right:18px;margin-top:0px;">
               <asp:Label ID="Label5" runat="server" style="font-family:'Times New Roman';font-size:12px;"></asp:Label> <br />
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
    text-decoration:underline">Load Tally</label> 
           
        </div>
    </div>
  
        
        <div >
            
              <div style="float:left;margin-left:15px;">                
              
               <asp:Label ID="lblIssueId" runat="server" style="font-family:'Times New Roman';font-size:12px;"></asp:Label> <br />
                  <span style="font-family:'Times New Roman';font-size:12px;"> 408 HQ Coy ASC (Pet)<br />
              C/o 56 APO</span>
        
            </div>
            

         
             <div class="clearfix"></div>
             <div class="container" style="width:100%;float:left"> 
                 

            
                    <table style="background-color:none !important;" >
                     <tr>
                         <td style="width:150px;"><label style="float:left">From:</label>       
                 </td><td><asp:Label   ID="lblFrom"  runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label>  </td>
                     </tr>
                      <tr>
                         <td> <label style="float:left" >To: </label></td>
                          <td>  <asp:Label  ID="lblTo" runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label>
                   </td>
                     </tr>
                      <tr>
                         <td><label style="float:left">Authority:</label></td>
                          <td> <asp:Label  ID="lblAuthority" runat="server"  Style="width:98%;word-wrap:break-word;display:block"></asp:Label>
                        
            </td>
                     </tr>
                      <tr>
                         <td><label style="float:left">Through:</label></td>
                          <td> <asp:Label  ID="lblThrough" runat="server"  Style="width:98%;word-wrap:break-word;display:block"></asp:Label>
                        
            </td>
                     </tr>
                 </table>

                    
               
               </div>
               
            <div class="clearfix"></div>
            <div class="container" style="margin-left:0px;width:100%">

              <asp:Literal runat="server" ID="ltrTable"></asp:Literal>
            
                    
       
                 
     
                 <br />
              <asp:Label ID="lblAmount" runat="server" Text="" style="float:right;margin-right:95px" ></asp:Label>
           <br />
                      <div style="margin-top:10px;height: 50px;text-align: center;">
        <div class="container">
             <asp:Label ID="lblCount" runat="server" ></asp:Label>
            <br />
             <asp:Label ID="lblInWords" runat="server" ></asp:Label>
            <br />  <asp:Label ID="Label2" runat="server" Text="This veh loaded in presence of stn bd of offrs, Unit rep, R&D, Dsc Rep and veh Dvr."></asp:Label><br />

           <table>
               <tr>
               <td><b>R & D NCO</b></td> <td><b>Dvr</b></td> <td><b>Gate Nco</b></td> <td><b>Security Nco</b></td> <td><b>R & D JCO</b></td>
                   </tr>  
               <tr>
                   <td></td> <td>Army No:<%=ArmyNo%><br />
                                 Rank:<%=Rank%><br />
                                 Name:<%=DriverName%><br />
                                 Sig:_________ 
                             </td> <td></td> <td></td> <td></td>
               </tr>  
           </table>
           
              </div></div></div>
              <div class="row" style="height:500px;">
                  
              </div></div>
    </asp:Panel></form>
</body>
</html>
