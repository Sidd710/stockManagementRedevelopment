<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LPCPView.aspx.cs" Inherits="RHPDNew.Forms.LPCPView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script src="../assets/js/jquery.min.js"></script>
<script src="../assets/js/bootstrap.js"></script>
     <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div>
      <div class="container" style="width:100%;float:left"> 
                 
          <table>
              <tr>
                  <td>
                     <b> AT/SO No.</b>

                  </td>
                   <td colspan="5">
                       <asp:Label   ID="lblATSoNo"  runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label> 
                  </td>
              </tr>
               <tr>
                  <td>
  <b> Product</b>

                  </td>
                   <td>
                      <b>    Rate</b>

                  </td>
                    <td>
                        <b>   Supplier</b>

                  </td>
                   <td>
                        <b>  Original Manufacture</b>

                  </td>
                    <td>
                        <b>   Date of Tender</b>

                  </td>
                   <td>
                       <b>   Receiving Date</b>

                  </td>
              </tr>
               <tr>
                  <td>
                     <asp:Label   ID="lblProduct"  runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label> 
                  </td>
                   <td>
                       <asp:Label   ID="lblRate"  runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label> 
                  </td>
                   <td>
                       <asp:Label   ID="lblSupplier"  runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label> 
                  </td>
                   <td>
                       <asp:Label   ID="lblOM"  runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label> 
                  </td>
                   <td>
                       <asp:Label   ID="lblDOT"  runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label> 
                  </td>
                   <td>
                       <asp:Label   ID="lblRecDt"  runat="server" Style="width:98%;word-wrap:break-word;display:block"></asp:Label> 
                  </td>
              </tr>
          </table><br />
            
                  <table>
             
               <tr>
                  <td>
  <b> Date
</b>

                  </td>
                   <td>
                      <b>    CRV No.
</b>

                  </td>
                    <td>
                        <b>   Batch
</b>

                  </td>
                   <td>
                        <b> Vehicle No.
</b>

                  </td>
                    <td>
                        <b>   Qty
</b>

                  </td>
                   <td>
                       <b>   Spillage
</b>

                  </td>

                    <td>
                       <b>   Full Loose/DW- Batch wise 

</b>

                  </td>
                    <td>
                       <b>   Quantity- Batch wise

</b>

                  </td>
                    <td>
                       <b>   Sample sent - Batch wise

</b>

                  </td>


              </tr>

                          <tr>
                  <td>
  

                  </td>
                   <td>
                      

                  </td>
                    <td>
                        

                  </td>
                   <td>
                      

                  </td>
                    <td>
                       
                  </td>
                   <td>
                      
                  </td>

                    <td>
                      

                  </td>
                    <td>
                      

                  </td>
                    <td>
                      


                  </td>


              </tr>
                      <tr>
                  <td>
  

                  </td>
                   <td>
                      

                  </td>
                    <td>
                        

                  </td>
                   <td>
                      

                  </td>
                    <td>
                       
                  </td>
                   <td>
                      
                  </td>

                    <td>
                      

                  </td>
                    <td>
                      

                  </td>
                    <td>
                      


                  </td>


              </tr>
                     <tr>
                         <td colspan="9"> <b>TOTAL</b>

                         </td>
                     </tr>
                      <tr>
                  <td>
  Days

                  </td>
                           <td>
                      Nos.

                  </td>
                   <td>
                      Nos.

                  </td>
                    <td>
                        Nos

                  </td>
                   <td>
                      Qty

                  </td>
                    <td>
                       Qty
                  </td>
                   <td>
                      Nos
                  </td>

                    <td>
                      
Qty
                  </td>
                    <td>
                      
                        Qty
                  </td>
                   


              </tr>
                      <tr>
                  <td colspan="2">
  TOTAL AMOUNT :

                  </td>
                   <td>
                      
                       IN numbers
                  </td>
                    <td colspan="6">
                        in words

                  </td>
                  
                      


               


              </tr>
                      </table>
                      
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

           
            <telerik:RadGrid MasterTableView-ShowFooter="false" ID="rgdCRV" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">
                <%-- OnItemCreated="rgdCRV_ItemCreated"  > --%>
         
            <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" > 
              
                <Columns> 
                   
                     <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                    <asp:HiddenField ID="hdnBID" runat="server" Value='<%#Eval("BID") %>' />
                                      <asp:HiddenField ID="hdnSID" runat="server" Value='<%#Eval("CatID") %>' />
                                     <asp:HiddenField ID="hdnLevel" runat="server" Value='<%#Eval("SupplierId") %>' />
                        
                    
                                </div>
                            </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                
                      
                        <telerik:GridTemplateColumn  HeaderText="Items" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS" ItemStyle-Width="135" HeaderStyle-Width="135">
                            <ItemTemplate>
                                   <asp:Label runat="server" ID="nn" Text='<%#Eval("ITEMS") %>' Style="width:135px;word-wrap:break-word;display:block"></asp:Label>
                               
                             
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn  HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                            <ItemTemplate>
                                <%#Eval("AU") %>
                            </ItemTemplate>
                          <FooterTemplate>
                                                    <asp:Label runat="server" ID="lblText" Style="float:right" Visible="false" >Total Quantity:</asp:Label>
                                                 </FooterTemplate>
                            
                        </telerik:GridTemplateColumn>
                       <%--  <telerik:GridTemplateColumn  HeaderText="Packaging Material " DataField="AU" DataType="System.String" UniqueName="AU">
                                    <ItemTemplate>

                                        <%#Eval("PackingMaterial") %>[<%#Eval("PackingMaterialFormat") %>]
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>--%>
                        
                               <telerik:GridTemplateColumn HeaderText="" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                            <ItemTemplate>
                                   <asp:Label ID="lblB" runat="server" Text="Batch(s):" ></asp:Label>
                                <telerik:RadGrid OnItemCreated="rgdCRVBatch_ItemCreated" OnColumnCreated="rgdCRVBatch_ColumnCreated"  ID="rgdCRVBatch" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowGroupPanel="false" ClientSettings-AllowExpandCollapse="false" MasterTableView-ExpandCollapseColumn-Groupable="false" GroupHeaderItemStyle-BorderStyle="None" GroupHeaderItemStyle-BorderWidth="0" GroupHeaderItemStyle-Font-Strikeout="false" GroupingSettings-CollapseTooltip="" GroupPanel-EnableTheming="false" GroupPanel-PanelItemsStyle-BackColor="WhiteSmoke" GroupPanel-PanelStyle-GridLines="None">
                                    <%-- OnItemCreated="rgdCRVBatch_ItemCreated" >--%>
         
            <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="true" ShowHeader="true" ShowGroupFooter="false" EditFormSettings-FormMainTableStyle-GridLines="None" EditFormSettings-FormTableStyle-GridLines="None" EnableGroupsExpandAll="false" EnableHierarchyExpandAll="false" GroupsDefaultExpanded="true" > 
               <GroupByExpressions>
                       
                          <telerik:GridGroupByExpression>
                                    <GroupByFields >
                                        <telerik:GridGroupByField FieldName="BatchNo" HeaderValueSeparator=":" SortOrder="Ascending" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="BatchNo" HeaderText="Batch No" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                <Columns>                  
                     <telerik:GridTemplateColumn   HeaderText="" DataField="BatchNo" DataType="System.Int32" UniqueName="BID" HeaderStyle-Width="5" ItemStyle-Width="5">
                            <ItemTemplate>
                              
                            </ItemTemplate>
                         <FooterTemplate>
                               Total:
                         </FooterTemplate>
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo" HeaderStyle-Width="25" ItemStyle-Width="25">
                            <ItemTemplate>
                              
                                 <asp:Label runat="server" ID="lblBatchNo" Text='<%#Eval("BatchNo").ToString()%>'></asp:Label>
                                
                            
                            </ItemTemplate>
                          <FooterTemplate>
                              <asp:Label runat="server"  ID="lblCount" style="display:-moz-inline-box;word-wrap:break-word;font:bold"></asp:Label>
                          </FooterTemplate>
                          
                        </telerik:GridTemplateColumn>

                       <telerik:GridTemplateColumn   HeaderText="Quantity" DataField="RemainingQty" DataType="System.String" UniqueName="BatchNo" HeaderStyle-Width="25" ItemStyle-Width="25">
                            <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#TruncateDecimalToString( Convert.ToDouble(Eval("RemainingQty")),3) %>' ID="lblQuantity"></asp:Label>
                            
                            </ItemTemplate>
                         <FooterTemplate>

                               <asp:Label runat="server"  ID="lblTotalQuatity" style="display:-moz-inline-box;word-wrap:break-word;font:bold"></asp:Label>
                         </FooterTemplate>
                        </telerik:GridTemplateColumn>

                        
                     <telerik:GridTemplateColumn  HeaderText="Pack" DataField="Format" DataType="System.String" UniqueName="Format" HeaderStyle-Width="250" ItemStyle-Width="250">
                            <ItemTemplate>
                                 <%#Eval("PackagingType") %>: <%#Eval("Format") %>
                            </ItemTemplate>
                          <FooterTemplate>
                                            
                                             
                                            
                            <asp:Label runat="server"  ID="lblTotalFullFormat" style="display:-moz-inline-box;word-wrap:break-word;font:bold"></asp:Label>
                                             
                                 
                                         </FooterTemplate>
                        </telerik:GridTemplateColumn>
                 
                    <telerik:GridTemplateColumn  HeaderText="Cost " DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                    <ItemTemplate>
                                        
                                           <asp:Label Visible="false" runat="server" ID="lblCost" Text='<%#Eval("Cost") %>'></asp:Label>
                                         <asp:Label runat="server" ID="lblCostAU" Text='<%#(Eval("CostOfParticular").ToString()==""?"": Eval("CostOfParticular").ToString() +"/"+AU)%>'></asp:Label>

                              <asp:Label runat="server" ID="lblthisFormatQty" Visible="false" style="display:-moz-inline-box;word-wrap:break-word;font:bold"></asp:Label>
                                       
          
                                  
                                    </ItemTemplate>
                        <FooterTemplate>
                              <asp:Label runat="server"  ID="lblTotalLooseFormat" style="display:-moz-inline-box;word-wrap:break-word;font:bold"></asp:Label>
                     
                        </FooterTemplate>
                                    
                                </telerik:GridTemplateColumn>
                      
                        <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate" HeaderStyle-Width="25" ItemStyle-Width="25">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblMFGDate" Text='<%#Eval("MFGDate").ToString()%>' Style="width:63px;word-wrap:break-word;display:block"></asp:Label>
                                    
                                 <asp:Label runat="server" ID="lblthisFullQty" Visible="false" style="display:-moz-inline-box;word-wrap:break-word;font:bold"></asp:Label>
                            </ItemTemplate>
                            
                           
                        </telerik:GridTemplateColumn>
                        
                            <telerik:GridTemplateColumn HeaderText="ESL" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                    <ItemTemplate>
                                          <asp:Label Style="width:63px;word-wrap:break-word;display:block" runat="server" ID="lblEsl" Text='  <%#Eval("Esl").ToString() %>
                            
                               '></asp:Label>
                             
                            
                               
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                   
                             <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                    <ItemTemplate>
                                         <asp:Label Style="width:63px;word-wrap:break-word;display:block" runat="server" ID="lblEXPDate" Text='  <%#Eval("EXPDate").ToString()%>
                            
                               '></asp:Label>
                             
                                         
                                    </ItemTemplate>
                             
                                </telerik:GridTemplateColumn>
                  
                        
                            
                             <telerik:GridTemplateColumn Visible="false"  HeaderText="Weight" DataField="Weight" DataType="System.Double" UniqueName="Weight">
                                    <ItemTemplate>
                                      
                                      
                                           <asp:Label  runat="server" ID="lblWeight" Text='  <%#(Eval("Weight").ToString()==""?"": Eval("Weight").ToString()+" "+Eval("WeightUnit") )%>'></asp:Label>
                             
                                    <asp:Label Visible="false" runat="server" ID="lblWeightAU" Text='  <%#(Eval("WeightofParticular").ToString()==""?"": Eval("WeightofParticular").ToString()+" "+Eval("WeightUnit") +" per "+AU )%>'></asp:Label>
                             
                                        
            
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn> 
                

                </Columns> 

                 <FooterStyle HorizontalAlign="Left" />
               
            </MasterTableView> 
        </telerik:RadGrid>
                                                      
                              <asp:Label ID="lblSubPacking" runat="server" Text='<%#Eval("SupplierId") %>' Visible="false" ></asp:Label>
                            </ItemTemplate>
                                  <FooterTemplate>
                                                    <asp:Label runat="server" ID="lblTotalQty" Visible="false" ></asp:Label>
                                                 </FooterTemplate>
                                  
                          
                        </telerik:GridTemplateColumn>
                    
                     <telerik:GridTemplateColumn HeaderText="Amount" DataField="Amount" DataType="System.Int32" UniqueName="Amount">
                                    <ItemTemplate>                              
                                      
                                                  
                               <asp:Label runat="server" ID="lblCost"></asp:Label>
                        
                                    </ItemTemplate>
                           <FooterTemplate>
                                                    
                                                        <asp:Label runat="server"  ID="lblAmount" Text="Total Amount: "></asp:Label>
                            
                                                 </FooterTemplate>
                                </telerik:GridTemplateColumn>         
                            
                      <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.Int32" UniqueName="Remarks"  ItemStyle-Width="140" HeaderStyle-Width="140">
                            <ItemTemplate>
                               
                                           
                                     
                                 <asp:Label runat="server" Text='<%#Eval("Remarks").ToString() %>' ID="lblFormat" Style="height:100%;width:139px;word-wrap:break-word;display:block"></asp:Label>
                                                      
                                               
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn>            
                     
                  

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               
            </MasterTableView> 
        </telerik:RadGrid>
                 <telerik:RadGrid MasterTableView-ShowFooter="false" ID="rgdCRVWithouPAcking" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">
                <%-- OnItemCreated="rgdCRV_ItemCreated"  > --%>
         
            <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" > 
              
                <Columns> 
                   
                     <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                    <asp:HiddenField ID="hdnBID" runat="server" Value='<%#Eval("BID") %>' />
                                      <asp:HiddenField ID="hdnSID" runat="server" Value='<%#Eval("CatID") %>' />
                                </div>
                            </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                
                      
                        <telerik:GridTemplateColumn  HeaderText="Items" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS" ItemStyle-Width="135" HeaderStyle-Width="135">
                            <ItemTemplate>
                           <asp:Label runat="server" Style="width:135px;word-wrap:break-word;display:block" Text='<%#Eval("ITEMS") %>'></asp:Label>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn  HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                            <ItemTemplate>
                                <%#Eval("AU") %>
                            </ItemTemplate>
                           <FooterTemplate>
                                                    <asp:Label runat="server" ID="lblTotaltext" Style="float:right" Visible="false" >Total Quantity</asp:Label>
                                                 </FooterTemplate>
                        </telerik:GridTemplateColumn>
                       <%--  <telerik:GridTemplateColumn  HeaderText="Packaging Material " DataField="AU" DataType="System.String" UniqueName="AU">
                                    <ItemTemplate>

                                        <%#Eval("PackingMaterial") %>[<%#Eval("PackingMaterialFormat") %>]
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>--%>
                        
                               <telerik:GridTemplateColumn HeaderText="" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                            <ItemTemplate>
                                   <asp:Label ID="lblB" runat="server" Text="Batch(s):" ></asp:Label>
                                
                                                      
                                   <telerik:RadGrid  ID="rgdBatchWithoutPacking" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="97%" EnableAJAX="True" Skin="Office2010Black" >
                                             <%--OnItemCreated="rgdCRVBatch_ItemCreated" > --%>
         
                    <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" ShowHeader="true" > 
                        <GroupByExpressions>
                       
                          <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="BatchNo" HeaderValueSeparator=":" SortOrder="Ascending" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="BatchNo" HeaderText="Batch No" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                        <Columns>                  
                               <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="BID">
                                    <ItemTemplate>
                                        <%#Eval("BID") %>
                                          <asp:HiddenField ID="hdnBID" runat="server" Value='<%#Eval("BID") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>        
                            
                           
                            <telerik:GridTemplateColumn  HeaderText="Cost " DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                    <ItemTemplate>
                                        
                                                 <asp:Label runat="server" ID="lblCostAU" Text='<%#(Eval("CostOfParticular").ToString()==""?"": Eval("CostOfParticular").ToString() +"/"+AU)%>'></asp:Label>

                             
                                  
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn>

                      
                              <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate">
                                    <ItemTemplate>
                                            <asp:Label Style="width:63px;word-wrap:break-word;display:block" runat="server" Text='<%#Eval("MFGDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("MFGDate")).ToString("dd-MM-yyyy") %>'></asp:Label>
                            
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                                                      <telerik:GridTemplateColumn HeaderText="ESL" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                    <ItemTemplate>
                                          <asp:Label Style="width:63px;word-wrap:break-word;display:block" runat="server" ID="lblEsl" Text='<%#Eval("Esl").ToString()==""?"N/A":Convert.ToDateTime(Eval("Esl")).ToString("dd-MM-yyyy")%>'></asp:Label>
                             
                            
                               
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                   
                             <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                    <ItemTemplate>
                                         <asp:Label Style="width:63px;word-wrap:break-word;display:block" runat="server" ID="lblEXPDate" Text='  <%#Eval("EXPDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("EXPDate")).ToString("dd-MM-yyyy")%>    '></asp:Label>
                             
                                         
                                    </ItemTemplate>
                             
                                </telerik:GridTemplateColumn>
                  

                  
                      
                  
                             
                              
                  

                     
                          
                            
                          
                                <telerik:GridTemplateColumn Visible="false"  HeaderText="Weight" DataField="Weight" DataType="System.Double" UniqueName="Weight">
                                    <ItemTemplate>
                                      
                                      
                                           <asp:Label  runat="server" ID="lblWeight" Text='  <%#(Eval("Weight").ToString()==""?"": Eval("Weight").ToString()+" "+Eval("WeightUnit") )%>'></asp:Label>
                             
                                    <asp:Label Visible="false" runat="server" ID="lblWeightAU" Text='  <%#(Eval("WeightofParticular").ToString()==""?"": Eval("WeightofParticular").ToString()+" "+Eval("WeightUnit") +" per "+AU )%>'></asp:Label>
                             
                                        
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn> 
                        
                     
                            
                        
                  

                        </Columns> 

                         <FooterStyle HorizontalAlign="Left" />
               
                    </MasterTableView> 
                </telerik:RadGrid>
                   
                            </ItemTemplate>
                                  <FooterTemplate>
                                                    <asp:Label Visible="false" runat="server" ID="lblTotalQty" Style="float:left" ></asp:Label>
                                                 </FooterTemplate>       
                          
                        </telerik:GridTemplateColumn>
                    
                        
                                <telerik:GridTemplateColumn HeaderText="Amount" DataField="Amount" DataType="System.Int32" UniqueName="Amount">
                                    <ItemTemplate>
                           
                                        <asp:Label runat="server" ID="lblCost"></asp:Label>                     
                                      
                                    </ItemTemplate>
                          <FooterTemplate>
                              
                               <asp:Label ID="lblAmount" runat="server" Style="float:left" Text="" Visible="false"></asp:Label>
                           </FooterTemplate>
                                </telerik:GridTemplateColumn> 
                          
                            
                      <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.Int32" UniqueName="Remarks" ItemStyle-Width="140" HeaderStyle-Width="140">
                            <ItemTemplate>
                               
                                           
                                     
                                 <asp:Label runat="server" Text='<%#Eval("Remarks").ToString() %>' ID="lblFormat" Style="height:100%;width:139px;word-wrap:break-word;display:block"></asp:Label>
                                                      
                                               
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn>            
                     
                  

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               
            </MasterTableView> 
        </telerik:RadGrid>
                 
     
                </div> 
    </div>
    </form>
</body>
</html>
