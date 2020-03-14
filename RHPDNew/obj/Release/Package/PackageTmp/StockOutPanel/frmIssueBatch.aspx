<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmIssueBatch.aspx.cs" Inherits="RHPDNew.StockOutPanel.frmIssueBatch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
  
    <div>
              <asp:HiddenField ID="hdnBID" runat="server"  ClientIDMode="Static" />           

      
      
	
                      
                   
        
    <telerik:RadGrid ID="rgdIssueBatch" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" OnItemCommand="rgdIssueBatch_ItemCommand" >
         
            <MasterTableView DataKeyNames="id" GridLines="None" Width="100%" CommandItemDisplay="none" > 
              
                <Columns> 
                   
                  
                   <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                    
                      
                        <telerik:GridTemplateColumn  HeaderText="Batch Name" DataField="BatchName" DataType="System.String" UniqueName="BatchName">
                            <ItemTemplate>
                                <asp:Label ID="lblBatchNo" runat="server" Text='<%#Eval("BatchName") %>'></asp:Label>
                                
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn  HeaderText="Product Name" DataField="AU" DataType="System.String" UniqueName="ProductName">
                            <ItemTemplate>
                               <%#Eval("ProductName") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>                            
                    

                     <telerik:GridTemplateColumn HeaderText="Issue Quantity" DataField="issuequantity" DataType="System.Int32" UniqueName="issuequantity">
                            <ItemTemplate>
                               
                                 <asp:Label runat="server" Text='<%#Eval("issueqty").ToString() %>' ID="lblissueqty"></asp:Label>
                                                      
                                               
                               
                            </ItemTemplate>
                        
                        </telerik:GridTemplateColumn> 
                      <telerik:GridTemplateColumn HeaderText="Issue Quantity" DataField="issuequantity" DataType="System.Int32" UniqueName="issuequantity">
                            <ItemTemplate>
                               
                              <asp:ImageButton ID="btnAdd" ToolTip="Calculate"  runat="server" ImageUrl="../Images/plus-gray.png" Height="30" Width="30" CommandName="get" CommandArgument='<%#Eval("id") %>'  />            
                                     
                                <asp:Panel runat="server" ID="pnlVehicle" Visible="false">
                                        <table>
                                        <tr>
                                            <td>Full Packaging:</td><td><asp:Label runat="server" ID="lblFormatFull"></asp:Label></td>
                                              <td>Loose Packaging:</td><td><asp:Label runat="server" ID="lblFormatLoose"></asp:Label></td>
                                            <td>Total Qty:</td><td><asp:Label runat="server" ID="lblTotalQty"></asp:Label></td>

                                        </tr></table>
                                    <table>
                                        <tr>
                                            <th>Vehicle No</th>
                                            <th>Qty</th>
                                            <th>Include Loose</th>
                                            <th>Packaging</th>
                                        </tr>
                                       
                                         <tr>
                                            <th>
                                                <asp:TextBox ID="txtVehicleNo" runat="server"></asp:TextBox></th>
                                            <th><telerik:RadNumericTextBox ID="txtQty" runat="server" OnTextChanged="txtQty_TextChanged" AutoPostBack="true" ToolTip='<%#Eval("id") %>'></telerik:RadNumericTextBox></th>
                                            <th><asp:CheckBox runat="server" ID="cbxLoose" onclick="display();"/>
                                                 <script type="text/javascript">
                                                     function display() {

                                                         if (document.getElementById("divLoose").style.display == 'block') {

                                                             document.getElementById("divLoose").style.display = 'none';
                                                         }
                                                         else {

                                                             document.getElementById("divLoose").style.display = 'block';
                                                         }
                                                     }
                    </script>
                                                <div id="divLoose" style="display:none">
                                                             <telerik:RadGrid ID="rgdChildLoosePAck" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="97%" Skin="Office2010Black" 
                                            ShowFooter="false"  > 
         
                    <MasterTableView  DataKeyNames="childID" GridLines="None" Width="100%" CommandItemDisplay="none" TableLayout="Fixed" ShowFooter="false" ShowHeader="false" > 
             
                        <Columns> 
                   
                              <telerik:GridTemplateColumn Visible="false"  HeaderText="" DataField="LevelID" DataType="System.String" UniqueName="LevelID">
                                    <ItemTemplate>
                             
                                        <%#Eval("LevelID") %>
                                    </ItemTemplate>
                        
                          
                                </telerik:GridTemplateColumn>
                 
                              <telerik:GridTemplateColumn  HeaderText="" DataField="Level" DataType="System.String" UniqueName="Level">
                                    <ItemTemplate>
                                        <%#Eval("Level") %>
                               
                                    </ItemTemplate>
                                  <FooterTemplate>
                             
                                  </FooterTemplate>
                          
                                </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn HeaderText="" DataField="LevelID" DataType="System.Int32" UniqueName="LevelID">
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ValidationGroup="pgrp" runat="server" ID="txtLevel" Width="35" ></telerik:RadNumericTextBox>
                                                                      </ItemTemplate>
                         
                                     
                                </telerik:GridTemplateColumn>
                        
                                     
                 
                      
                  

                        </Columns> 
                

                         <FooterStyle HorizontalAlign="left" />
               
                    </MasterTableView> 
                </telerik:RadGrid>

                                                </div>
                                            </th>
                                            <th><telerik:RadNumericTextBox ID="txtPack" runat="server" Width="50" OnTextChanged="txtPack_TextChanged" AutoPostBack="true" ToolTip='<%#Eval("id") %>'></telerik:RadNumericTextBox><asp:Label ID="lblPack" runat="server"></asp:Label></th>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th><asp:Button ID="btnAddVehicle" runat="server" OnClick="btnAddVehicle_Click" Text="Add"  CommandArgument='<%#Eval("id") %>'/></th>
                                            <th><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" /></th>
                                            <th></th>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hdnVehicleID" runat="server" />
                                    <telerik:RadGrid ID="rgdVehicle" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="97%"  Skin="Office2010Black" ShowFooter="false" OnItemCommand="rgdVehicle_ItemCommand"  > 
         
            <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" > 
              
                <Columns> 
                   
                  
                   <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                    
                      
                        <telerik:GridTemplateColumn  HeaderText="Vehicle No" DataField="VehicleNo" DataType="System.String" UniqueName="VehicleNo">
                            <ItemTemplate>
                                <asp:Label ID="lblVehicleNo" runat="server" Text=' <%#Eval("VehicleNo") %>'></asp:Label>
                               
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn  HeaderText="Stock Quantity" DataField="StockQuantity" DataType="System.String" UniqueName="StockQuantity">
                            <ItemTemplate>
                              
                                 <asp:Label ID="lblStockQuantity" runat="server" Text=' <%#Eval("StockQuantity") %>'></asp:Label>
                           
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn> 
                    
                      <telerik:GridTemplateColumn  HeaderText="Full Packing" DataField="StockQuantity" DataType="System.String" UniqueName="StockQuantity">
                            <ItemTemplate>
                              
                                 <asp:Label ID="lblFormatFull" runat="server" Text=' <%#Eval("FormatFull") %>'></asp:Label>
                           
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>     
                      <telerik:GridTemplateColumn  HeaderText="Loose Packing" DataField="StockQuantity" DataType="System.String" UniqueName="StockQuantity">
                            <ItemTemplate>
                              
                                 <asp:Label ID="lblFormatLoose" runat="server" Text=' <%#Eval("FormatLoose") %>'></asp:Label>
                           
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>                       
                    

                     <telerik:GridTemplateColumn HeaderText=""  DataType="System.Int32" Visible="false">
                            <ItemTemplate>
                               
                            <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandArgument='<%#Eval("batchno") %>' CommandName="Edit" ></asp:LinkButton>
                               
                            </ItemTemplate>
                        
                        </telerik:GridTemplateColumn>                              
                   

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               
            </MasterTableView> 
        </telerik:RadGrid>

                                </asp:Panel>
                               
                            </ItemTemplate>
                        
                        </telerik:GridTemplateColumn> 
                              
                              
                    		
	
                </Columns> 
                

                 <FooterStyle HorizontalAlign="left" />
               
            </MasterTableView> 
       
        </telerik:RadGrid>
  
        
          </div>
    </form>
</body>
</html>
