<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseVoucherView.aspx.cs" Inherits="RHPDNew.Forms.ExpenseVoucherView" %>



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
                                   <b>Expense Voucher No:<%=LTNo %></b></div><br />
                             </div>
      </div>
                         <asp:Accordion ID="accData" runat="server" HeaderCssClass="Header" ContentCssClass="Contents" HeaderSelectedCssClass="SelectedHeader" Font-Names="Verdana" Font-Size="10" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1" FramesPerSecond="100"
        FadeTransitions="true" TransitionDuration="500">
               <Panes>
                <asp:AccordionPane ID="apStock" runat="server">
                <Header>Basic Detail</Header>
                <Content>
                 
                      
  <div class="col-md-12 main-feild">
                         <div class="row marginbottom10" >
                          
                              
                                  <p>  <b>  Expense Voucher Detail:</b> :</p>
                         
                      
                              <table>
                                        <tr>
                                             <td>Category:  <%=Category_Name%></td>
                                             <td>Bathc No :<%=BathcNo %></td>
                                            <td>Product: <%=Product_Name %></td>                                            
                                            <td>  Used Qty :<%=UsedQty %>  </td>
                                            
                                            
                                        </tr>
                                       
                                        <tr>
                                            
                                            
                                            <td colspan="2">Remarks:<%=Remarks %></td>
                                             <td>Used From Full Packets:<%=UsedFromFullPackets %></td>
                                            <td><b>Remaining Qty:<%=RemainingQty %></b></td>
                                           
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
         
            <MasterTableView DataKeyNames="Product_ID" GridLines="None" Width="100%" CommandItemDisplay="none" > 
                 <GroupByExpressions>
                   
              
                       <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Category_Name" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Category_Name" HeaderText="Category" />
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
                              <asp:Label runat="server" Text='<%#Eval("productunit").ToString()=="NOS"?Convert.ToDouble(Eval("UsedQty")).ToString("0.00"):Convert.ToDouble(Eval("UsedQty")).ToString("0.000") %>' ID="lblVQty"></asp:Label>
                                                      
                             <%#Eval("productunit") %>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Batch Detail:" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                               <asp:Table runat="server" ID="tblBatch1">
                                    <asp:TableRow>
                                        <asp:TableCell ColumnSpan="5"><b> Batch No: </b> <%#Eval("BatchNo") %></asp:TableCell>
                                    </asp:TableRow>
                                     <asp:TableRow>
                                        
                                         <asp:TableCell>DOM: <%#Convert.ToDateTime(Eval("MFGDate").ToString()).ToString("dd-MM-yyyy") %></asp:TableCell>
                                 
                                         <asp:TableCell> ESL: <%#Eval("Esl").ToString()==""?"N/A":Convert.ToDateTime(Eval("Esl").ToString()).ToString("dd-MM-yyyy") %></asp:TableCell>
                              <asp:TableCell>   EXPIRY: <%#Eval("MFGDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("EXPDate").ToString()).ToString("dd-MM-yyyy")%></asp:TableCell>
                                     </asp:TableRow>

                                </asp:Table>
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
                  
               <asp:AccordionPane ID="AccordionPane1" runat="server">
                <Header> <b>  PM/Conatainer(s)</b> </Header>
                <Content>
                 <div class="container">
                      
                
                      <div class="row" runat="server" id="Div1">
                   
                     <p>  <b>  PM/Conatainer(s) Detail:</b> :</p>
                         
                          <telerik:RadGrid ID="rgdPMConatainer" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="false" ShowHeader="true" > 
         
            <MasterTableView DataKeyNames="ID" GridLines="None" Width="100%" CommandItemDisplay="none" > 
                 <GroupByExpressions>
                   
              
                       <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Category_Name" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Category_Name" HeaderText="Category" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                 
                    
                 
                    </GroupByExpressions>
                             <Columns> 
               
                   
                                     
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
                                  
                                  <telerik:GridTemplateColumn HeaderText="MaterialName" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <%#Eval("MaterialName") %>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Capacity" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <%#Eval("Capacity") %>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Grade" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <%#Eval("Grade") %>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Condition" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <%#Eval("Condition") %>
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                    
                                  <telerik:GridTemplateColumn HeaderText="Quantity" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <asp:Label ForeColor='<%# Convert.ToBoolean(Eval("IsSentfromCP").ToString())==true?System.Drawing.Color.Blue:System.Drawing.Color.Black %>' ID="Quantity" runat="server" Text='<%# Convert.ToBoolean(Eval("IsSentfromCP").ToString()) == true ? "Sent from Source" : Eval("Quantity")  +" "+ Eval("productunit")%>'></asp:Label>
                                              
                            
                                 </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                                  
                   <telerik:GridTemplateColumn HeaderText="Date Of Receival" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                   <asp:Label ID="DateOfReceival" runat="server" Text='<%#Convert.ToDateTime( Eval("DateOfReceival").ToString()).ToString("dd-MMM-yyyy") %>'></asp:Label>
            
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
          
                     
                   
                          <p>Expense Voucher No:<%=LTNo %></p>
                  
                     <asp:LinkButton style="float:right;margin-right:50px;margin-top:0px;" ForeColor="Blue" Font-Bold="true" Font-Size="Large" runat="server" ID="lbtnPRint" OnClick="lbtnPRint_Click"  >Print</asp:LinkButton>           
           
                    <div class="clear"></div>

                    <telerik:RadGrid ID="rgdSummary" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" ShowHeader="true" > 
         
            <MasterTableView DataKeyNames="Product_ID" GridLines="None" Width="100%" CommandItemDisplay="none" > 
                 <GroupByExpressions>
                      <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Category_Name" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Category_Name" HeaderText="Category" />
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
                             <FooterTemplate>
                                        <asp:Label runat="server" ID="tt"  style="float:none"> Total: </asp:Label>
                                      </FooterTemplate>  
                                             <FooterStyle HorizontalAlign="Center" />         
                        </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="A/U" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <%#Eval("productunit") %>
                                 </ItemTemplate> 
                                      <FooterTemplate>
                                         <asp:Label runat="server" ID="qty" Text="Quantity:" style="float:right"></asp:Label>
                                      </FooterTemplate>
                                            
                            
                        </telerik:GridTemplateColumn>
                    
                                  <telerik:GridTemplateColumn HeaderText="Quantity" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                              <asp:Label runat="server" Text='<%#Eval("productunit").ToString()=="NOS"?Convert.ToDouble(Eval("UsedQty")).ToString("0.00"):Convert.ToDouble(Eval("UsedQty")).ToString("0.000") %>' ID="lblVQty"></asp:Label>
                                                      
                            
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
                                        
                                         <asp:TableCell>DOM: <%#Convert.ToDateTime(Eval("MFGDate").ToString()).ToString("dd-MM-yyyy") %></asp:TableCell>
                                 
                                         <asp:TableCell> ESL: <%#Eval("Esl").ToString()==""?"N/A":Convert.ToDateTime(Eval("Esl").ToString()).ToString("dd-MM-yyyy") %></asp:TableCell>
                              <asp:TableCell>   EXPIRY: <%#Eval("MFGDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("EXPDate").ToString()).ToString("dd-MM-yyyy")%></asp:TableCell>
                                     </asp:TableRow>

                                </asp:Table>

                             
                                 </ItemTemplate>  
                                                        
                             
                        </telerik:GridTemplateColumn>
                  
                  

                </Columns> 

               
               
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

