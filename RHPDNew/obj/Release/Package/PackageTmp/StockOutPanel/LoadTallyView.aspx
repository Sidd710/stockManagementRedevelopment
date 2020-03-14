<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadTallyView.aspx.cs" Inherits="RHPDNew.StockOutPanel.LoadTallyView" %>


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
  
 
  <div class="col-md-12 main-feild">
                         <div class="row marginbottom10" >
                             <div class="" style="margin-left:10px;">
                                   <b>Load Tally No:<%=LTNo %></b></div><br />
                             </div>
      </div>
                         <asp:Accordion ID="accData" runat="server" HeaderCssClass="Header" ContentCssClass="Contents" HeaderSelectedCssClass="SelectedHeader" Font-Names="Verdana" Font-Size="10" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1" FramesPerSecond="100"
        FadeTransitions="true" TransitionDuration="500">
               <Panes>
                <asp:AccordionPane ID="apStock" runat="server">
                <Header>Vehicle</Header>
                <Content>
                 
                      
  <div class="col-md-12 main-feild">
                         <div class="row marginbottom10" >
                          
                                <p>Vehicle Detail:</p>
                              <table>
                                        <tr><td><b>  Vechile Number:  <%=VechileNumber%></b></td>
                                             <td>Vehicle Type:<%=VehicleType %></td>
                                            <td>Authority: <%=Authority %></td>                                            
                                            <td>  Unit No:<%=UnitNio %>  </td>
                                            <td>Army No:<%=ArmyNo %></td>
                                        </tr>
                                       
                                        <tr><td> Rank:<%=Rank %></td>
                                            
                                            <td>Through:<%=Through %></td>
                                             <td>Driver Name:<%=DriverName %></td>
                                            <td>No. of Products:<%=ProductCount %></td>
                                            <td><b>Stock Quantity:<%=StockQty %></b></td>
                                        </tr>
                                    </table>
                         
                             </div>
                                       
                 
                      
            </div>
                </Content>
                </asp:AccordionPane>

                  <asp:AccordionPane ID="apBatch" runat="server">
                <Header> <b>  Product(s)</b> </Header>
                <Content>
                 <div class="container">
                      
                
                      <div class="row" runat="server" id="dvListBacth">
                   
                     <p>  <b>  Product(s) Detail:</b> :</p>
                         
                          <telerik:RadGrid ID="rgdProduct" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="false" ShowHeader="true" > 
         
            <MasterTableView DataKeyNames="ProductId" GridLines="None" Width="100%" CommandItemDisplay="none" > 
                 <GroupByExpressions>
                     <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="IDTICTAWS" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="IDTICTAWS" HeaderText="." />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                 <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="IssueVoucherId" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="IssueVoucherId" HeaderText="Issue VoucherId" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                 
                       <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="ATSONo" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="ATSONo" HeaderText="." />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                 
                    </GroupByExpressions>
                             <Columns> 
               
                   <telerik:GridTemplateColumn Visible="false" HeaderText="" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                              
                                    
                                    <table>
                                        <tr><td><b><%#Container.DataSetIndex+1%>.&nbsp;   Name:  <%#Eval("product_name") %></b></td>
                                            <td><%#Eval("ATSONo") %></td>
                                             <td>Issue Voucher: <%#Eval("IssueVoucherId") %> </td>
                                            <td>Type:<%#Eval("IDTICTAWS") %></td>
                                            <td>  Quantity:    <asp:Label runat="server" Text='<%#Eval("productunit").ToString()=="NOS"?Convert.ToDouble(Eval("stockquantity")).ToString("0.00"):Convert.ToDouble(Eval("stockquantity")).ToString("0.000") %>' ID="lblVQty"></asp:Label>
                                                      
                             in   <%#Eval("productunit") %></td>
                                            
                                        </tr>
                                        <tr>
                                            <td colspan="6"><b>Batch Detail:</b></td>
                                        </tr>
                                        <tr>
                                            <td><b>  Batch No:  <%#Eval("BatchNo") %></b></td>
                                            <td>Cost: <%#Convert.ToDouble(Eval("VCost").ToString()).ToString("0.00") %></td>
                                             <td>Weight: <%#Convert.ToDouble(Eval("vWeight").ToString()).ToString("0.00") %></td>
                                            <td>  Full: <%#Eval("FormatFull").ToString()==""?"N/A":Eval("FormatFull") %></td>
                                       <td>Loose/DW/Others: <%#Eval("FormatLoose").ToString()==""?"N/A":Eval("FormatLoose")%></td>


                                        </tr>
                                    </table>
                                    
                                
                        
                                </div>
                                <hr />
                            </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                     
                     <telerik:GridTemplateColumn HeaderText="SNo" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <%#Container.DataSetIndex+1%>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                       <telerik:GridTemplateColumn HeaderText="Product" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <%#Eval("product_name") %>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="A/U" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <%#Eval("productunit") %>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                    
                                  <telerik:GridTemplateColumn HeaderText="Quantity" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <asp:Label runat="server" Text='<%#Eval("productunit").ToString()=="NOS"?Convert.ToDouble(Eval("stockquantity")).ToString("0.00"):Convert.ToDouble(Eval("stockquantity")).ToString("0.000") %>' ID="lblVQty"></asp:Label>
                                                      
                             <%#Eval("productunit") %>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Batch Detail:" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <table>
                                        
                                        <tr>
                                            <td colspan="5"><b> Batch No: </b> <%#Eval("BatchNo") %></td>
                                        </tr>
                                        <tr>
                                           
                                            <td>Cost: <%#Eval("VCost") %></td>
                                             <td>Weight: <%#Eval("vWeight") %> </td>
                                            <td>  Full: <%#Eval("FormatFull").ToString()==""?"N/A":Eval("FormatFull") %></td>
                                       <td>Loose/DW/Others: <%#Eval("FormatLoose").ToString()==""?"N/A":Eval("FormatLoose")%></td>


                                        </tr>
                                    </table>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                  
                              
                  
                              
                  

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               
            </MasterTableView> 
        </telerik:RadGrid>



                              
            
            
                  
                           </div>

                    </div>
                </Content>
                </asp:AccordionPane>
                  
               
                    
                   
               <asp:AccordionPane ID="apCRV" runat="server">
                <Header>Summary </Header>
                <Content>
                <div  runat="server" id="div4">
          
                     
                   
                          <p>Load Tally No:<%=LTNo %></p>
                  
                     <asp:LinkButton style="float:right;margin-right:50px;margin-top:0px;" ForeColor="Blue" Font-Bold="true" Font-Size="Large" runat="server" ID="lbtnPRint" OnClick="lbtnPRint_Click"  >Print</asp:LinkButton>           
           
                    <div class="clear"></div>

                   <telerik:RadGrid ID="rgdSummary" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" ShowHeader="true" > 
         
            <MasterTableView DataKeyNames="ProductId" GridLines="None" Width="100%" CommandItemDisplay="none" > 
                 <GroupByExpressions>
                     <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="IDTICTAWS" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="IDTICTAWS" HeaderText="." />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                 <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="IssueVoucherId" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="IssueVoucherId" HeaderText="Issue VoucherId" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                 
                       <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="ATSONo" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="ATSONo" HeaderText="." />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                 
                    </GroupByExpressions>
                             <Columns> 
               
                   
                                     
                     <telerik:GridTemplateColumn HeaderText="SNo" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <%#Container.DataSetIndex+1%>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                       <telerik:GridTemplateColumn HeaderText="Items" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <%#Eval("product_name") %>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="A/U" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <%#Eval("productunit") %>
                                 </ItemTemplate> 
                                      <FooterTemplate>
                                         Total:
                                      </FooterTemplate>                   
                            
                        </telerik:GridTemplateColumn>
                    
                                  <telerik:GridTemplateColumn HeaderText="Quantity" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <asp:Label runat="server" Text='<%#Eval("productunit").ToString()=="NOS"?Convert.ToDouble(Eval("stockquantity")).ToString("0.00"):Convert.ToDouble(Eval("stockquantity")).ToString("0.000") %>' ID="lblVQty"></asp:Label>
                                                      
                             <%#Eval("productunit") %>
                                 </ItemTemplate>                    
                             <FooterTemplate>
                                          <asp:Label runat="server" ID="lblTotalQty" Text="000"></asp:Label>
                                      </FooterTemplate>         
                        </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Batch Detail:" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                             <asp:Table runat="server" ID="tblBatch">
                                    <asp:TableRow>
                                        <asp:TableCell ColumnSpan="5"><b> Batch No: </b> <%#Eval("BatchNo") %></asp:TableCell>
                                    </asp:TableRow>
                                     <asp:TableRow>
                                         <asp:TableCell>Cost: <%#Convert.ToDouble(Eval("VCost").ToString()).ToString("0.00") %></asp:TableCell>
                                 
                                         <asp:TableCell> Full: <%#Eval("FormatFull").ToString()==""?"N/A":Eval("FormatFull") %></asp:TableCell>
                              <asp:TableCell>   Loose/DW/Others: <%#Eval("FormatLoose").ToString()==""?"N/A":Eval("FormatLoose")%></asp:TableCell>
                                    
                                         <asp:TableCell>
                                             Weight: <%#Convert.ToDouble(Eval("vWeight").ToString()).ToString("0.00") %>
                                         </asp:TableCell> </asp:TableRow>

                                </asp:Table>
                                 </ItemTemplate>  
                                                        
                             <FooterTemplate>

                                  <asp:Label runat="server" ID="lblCost" Text="000" style="float:left"></asp:Label>
                                          <asp:Label runat="server" ID="lblWeight" Text="000" style="float:right"></asp:Label>
                                  
                                      </FooterTemplate>   
                        </telerik:GridTemplateColumn>
                  
                              <telerik:GridTemplateColumn HeaderText="Remarks" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <%#Eval("Remarks") %>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                  
                              
                  

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               
            </MasterTableView> 
        </telerik:RadGrid>
            
              
                         


                    </div>
                </Content>
                </asp:AccordionPane>
               </Panes>
        </asp:Accordion>
           
    </form>
</body>
</html>
