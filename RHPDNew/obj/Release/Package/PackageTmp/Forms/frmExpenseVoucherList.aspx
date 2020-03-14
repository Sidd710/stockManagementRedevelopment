<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="frmExpenseVoucherList.aspx.cs" Inherits="RHPDNew.Forms.frmExpenseVoucherList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="heading-bg">
        <div class="container">
            <h1>Expense Voucher List</h1>
        </div>
    </div>
    <br />
    <br />
        <style>
            body{background:url(../assets/images/01-Cold.jpg) no-repeat;background-size:cover;}
        </style>
 <%--   <div class="container" >--%>
          
            <%--  <div style="margin-left:-95px;" class="row">--%>
                  
            
                  <asp:UpdateProgress ID="UpdateProgress7" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updPacking">
            <ProgressTemplate>                
                <div class="full-pop-up">
              <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left:0%" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
                                   <asp:UpdatePanel runat="server" ID="updPacking">
                                      <ContentTemplate>


           
                   
<b style="margin-left:15px;color:orangered">Pending List:</b>
                                          <hr />
                 
                   
        <telerik:RadGrid ID="rgdPendingList" runat="server"
        GridLines="None" AutoGenerateColumns="False"
        Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" OnItemCommand="rgdPendingList_ItemCommand"    > 
         
            <MasterTableView DataKeyNames="BID" GridLines="None"  CommandItemDisplay="none" > 
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
                                <telerik:GridGroupByField FieldName="Product_Name" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Product_Name" HeaderText="Product" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                   <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="BatchNo" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="BatchNo" HeaderText="Batch No" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                    
                    </GroupByExpressions>
                <Columns> 
                   
                    
                   <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>                    
                           
                          
                        </telerik:GridTemplateColumn>
                     
                     
                     
                     <telerik:GridTemplateColumn   HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                            <ItemTemplate>
                          <%#Eval("BatchNo") %>
                                          
                                <asp:HiddenField runat="server" Value='<%#Eval("CID") %>' ID="CID"   />
                                <asp:HiddenField runat="server" Value='<%#Eval("Product_ID") %>' ID="PID"   />
                                   <asp:HiddenField runat="server" Value='<%#Eval("RemainingQty") %>' ID="RemainingQty"   />
                         
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                       <telerik:GridTemplateColumn   HeaderText="Category" DataField="Cat" DataType="System.String" UniqueName="Cat">
                                    <ItemTemplate>                                      
                                               
                                        
                                                   <%#Eval("Category_Name").ToString()%>
                     
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>
                      
                        <telerik:GridTemplateColumn  HeaderText="Product" DataField="Product_Name" DataType="System.String" UniqueName="Product_Name">
                            <ItemTemplate>

                                    
                                 <%#(Eval("Product_Name").ToString()) %>
                     
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn  HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                            <ItemTemplate>
                                <%#Eval("productUnit") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                        
                                    
                                      <telerik:GridTemplateColumn HeaderText="Used Qty" DataField="Quantity" DataType="System.Double" UniqueName="Quantity">
                            <ItemTemplate>
                               
                                
                                                      
                                       <asp:Label runat="server" ID="lblSampleSentQty" Text='<%#Convert.ToDouble(Eval("SampleSentQty").ToString())<0?"0":Eval("productUnit").ToString()=="NOS"?Convert.ToDouble(Eval("SampleSentQty").ToString()).ToString("0.00"):Convert.ToDouble(Eval("SampleSentQty").ToString()).ToString("0.000")%>'></asp:Label>         
                               
                            </ItemTemplate>
                        
                        </telerik:GridTemplateColumn>  
                     <telerik:GridTemplateColumn HeaderText="Used from Full Packets" DataField="DamagedBox" DataType="System.Double" UniqueName="IssueQty">
                            <ItemTemplate>
                               
                                
                                                      
                                       <asp:Label runat="server" ID="lblDamagedBox" Text='<%#Eval("DamagedBox")%>'></asp:Label>         
                               
                            </ItemTemplate>
                       
                           
                        </telerik:GridTemplateColumn>  
                     
           
              

                        <telerik:GridTemplateColumn HeaderText="Total Full" DataField="Amount" DataType="System.Double" UniqueName="Amount" >
                            <ItemTemplate>
                                
                                
                                      <asp:Label runat="server" ID="lblFull" Text='<%#Eval("FormatFull")%>'></asp:Label>        
                                                         
                               


                               
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn> 
                         <telerik:GridTemplateColumn HeaderText="Total Loose/DW" DataField="RecievedOn" DataType="System.DateTime" UniqueName="RecievedOn">
                            <ItemTemplate>
                               
                                                            
                                           <asp:Label runat="server" ID="lblLoose" Text='<%#Eval("FormatLoose")%>'></asp:Label>   
                                  <asp:Label runat="server" ID="lblDW" Text='<%#Eval("FormatDW")%>'></asp:Label>              
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Dated" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                            <ItemTemplate>
                              <%#Convert.ToDateTime(Eval("AddedOn").ToString()).ToString("dd-MM-yyyy")%>
                                     
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
  
                   <telerik:GridTemplateColumn Visible="false" HeaderText="" DataField="add" DataType="System.String" UniqueName="aa">
                            <ItemTemplate>
                                  
                           
                      <%--   <asp:HyperLink ToolTip='<%#Eval("PMCount").ToString()=="0"?"No PM/Container added!":Eval("PMCount")+" PM/Container added!" %>' Font-Bold="true" Target="_blank" ForeColor="Blue" runat="server" ID="lbtnAddPM" Text="Add PM/Container" NavigateUrl='<%#"~/Forms/frmAddPMContainer.aspx?bId="+Eval("BID")+"&pID="+Eval("Product_ID")+"&cID="+Eval("CID")%>'></asp:HyperLink>
                                     <asp:Label ToolTip='<%#Eval("PMCount").ToString()=="0"?"No PM/Container added!":Eval("PMCount")+" PM/Container added!" %>' ForeColor="Red" runat="server" ID="count" Text='<%#Eval("PMCount").ToString()!="0"?"("+Eval("PMCount")+")":"" %>'></asp:Label>
           --%>                 </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
  
                  
                      <telerik:GridTemplateColumn HeaderText="" DataField="Remarks" DataType="System.String" UniqueName="Remarks" >
                            <ItemTemplate>
                                <asp:Panel runat="server" ID="pnl" Visible="false">

                             
                                  <asp:Label runat="server" ForeColor="Red" Text="" ID="lblErr"></asp:Label><br />
                                    <asp:TextBox runat="server" ID="txtEXVNo" placeholder="Expense Voucher No" ></asp:TextBox>
                                 <asp:RequiredFieldValidator  ID="req" ValidationGroup='<%#"grpP"+Eval("BID") %>' runat="server" Text="*Required" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtEXVNo"></asp:RequiredFieldValidator>

                                <br />
                                      <asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" placeholder="If any.." ></asp:TextBox><br />
                                 <asp:LinkButton   ValidationGroup='<%#"grpP"+Eval("BID") %>' Font-Bold="true" ForeColor="Green" runat="server" ID="btnGenerate" Text="Generate Expense Voucher"  CommandName="Gen" CommandArgument='<%#Eval("BID")%>'></asp:LinkButton>
                                    
                                         </asp:Panel>      
                                
                                <asp:LinkButton runat="server" ID="lbtnAddContainer"  Text="Add Container" OnClick="lbtnAddContainer_Click" Font-Bold="true" ForeColor="Blue" CommandArgument='<%#Eval("BID")%>'></asp:LinkButton>
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
  
                  

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               

    <CommandItemSettings ShowAddNewRecordButton="false" />


            </MasterTableView> 
        </telerik:RadGrid>
            
            <br />
                                                             
<b style="margin-left:15px;color:blue">Generated List:</b>
                                          <hr />  
                                          <telerik:RadGrid ID="rgdGeneratedList" runat="server"
        GridLines="None" AutoGenerateColumns="False"
        Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" AllowFilteringByColumn="true" OnNeedDataSource="rgdGeneratedList_NeedDataSource"> 
         
            <MasterTableView DataKeyNames="ID" GridLines="None"  CommandItemDisplay="none" > 
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
                                <telerik:GridGroupByField FieldName="Product_Name" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Product_Name" HeaderText="Product" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                    <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="BatchNo" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="BatchNo" HeaderText="Batch No" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>  <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="ExpenseVoucherNo" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="ExpenseVoucherNo" HeaderText="Expense Voucher No" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                    </GroupByExpressions>
                <Columns> 
                   
                    
                   <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>                    
                           
                          
                        </telerik:GridTemplateColumn>
                     
                     
                     
                     <telerik:GridTemplateColumn   HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                            <ItemTemplate>
                          <%#Eval("BatchNo") %>
                                           
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                       <telerik:GridTemplateColumn   HeaderText="Category" DataField="Cat" DataType="System.String" UniqueName="Category_Name">
                                    <ItemTemplate>                                      
                                               
                                        
                                                   <%#Eval("Category_Name").ToString()%>
                     
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>
                      
                        <telerik:GridTemplateColumn  HeaderText="Product" DataField="Product_Name" DataType="System.String" UniqueName="Product_Name">
                            <ItemTemplate>

                                    
                                 <%#(Eval("Product_Name").ToString()) %>
                     
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn   HeaderText="A/U" DataField="productUnit" DataType="System.String" UniqueName="productUnit">
                            <ItemTemplate>
                                <%#Eval("productUnit") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                        
                                    
                                   
                     <telerik:GridTemplateColumn Visible="false" HeaderText="Used from Full Packets" DataField="UsedFromFullPackets" DataType="System.Decimal" UniqueName="UsedFromFullPackets">
                            <ItemTemplate>
                               
                                
                                                      
                                       <asp:Label runat="server" ID="lblDamagedBox" Text='<%#Eval("UsedFromFullPackets")%>'></asp:Label>         
                               
                            </ItemTemplate>
                       
                           
                        </telerik:GridTemplateColumn>  
                     
           
              

                        <telerik:GridTemplateColumn  HeaderText="Full" DataField="FormatFull" DataType="System.String" UniqueName="FormatFull" >
                            <ItemTemplate>
                                
                                
                                      <asp:Label runat="server" ID="lblFull" Text='<%#Eval("FormatFull")%>'></asp:Label>        
                                                         
                               


                               
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn> 
                         <telerik:GridTemplateColumn  HeaderText="Loose/DW" DataField="FormatLoose" DataType="System.String" UniqueName="FormatLoose">
                            <ItemTemplate>
                               
                                                            
                                           <asp:Label runat="server" ID="lblLoose" Text='<%#Eval("FormatLoose")%>'></asp:Label>              
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                       <telerik:GridTemplateColumn  HeaderText="Quantity" DataField="UsedQty" DataType="System.Decimal" UniqueName="UsedQty">
                            <ItemTemplate>
                               
                                
                                                      
                                       <asp:Label runat="server" ID="lblSampleSentQty" Text='<%#Convert.ToDouble(Eval("UsedQty").ToString())<0?"0":Eval("productUnit").ToString()=="NOS"?Convert.ToDouble(Eval("UsedQty").ToString()).ToString("0.00"):Convert.ToDouble(Eval("UsedQty").ToString()).ToString("0.000")%>'></asp:Label>         
                               
                            </ItemTemplate>
                        
                        </telerik:GridTemplateColumn>  
                     <telerik:GridTemplateColumn Visible="false" HeaderText="Quantity" DataField="RemainingQty" DataType="System.Decimal" UniqueName="RemainingQty">
                            <ItemTemplate>
                              
                                  
                                                         
                                       <asp:Label runat="server" ID="lblRemainingQty" Text='<%#Eval("productUnit").ToString()=="NOS"?Convert.ToDouble(Eval("RemainingQty").ToString()).ToString("0.00"):Convert.ToDouble(Eval("RemainingQty").ToString()).ToString("0.000")%>'></asp:Label>         
                
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                   <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                            <ItemTemplate>
                              
                                     <%#Eval("Remarks") %>
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
  
                    <telerik:GridTemplateColumn HeaderText="Geneated On" DataField="AddedOn" DataType="System.DateTime" UniqueName="AddedOn">
                            <ItemTemplate>
                              
                                     <%#Eval("AddedOn") %>
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                     
  
                    <telerik:GridHyperLinkColumn AllowFiltering="false" HeaderText="" UniqueName="evView" DataTextField="ID"
    DataTextFormatString="View Detail" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="javascript:ViewCheck({0})">
</telerik:GridHyperLinkColumn>
                     <telerik:GridHyperLinkColumn AllowFiltering="false" HeaderText="" UniqueName="evPrint" DataTextField="Id"
    DataTextFormatString="Print" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="../Forms/ExpenseVoucherPrint.aspx?evID={0}" Target="Blank">
</telerik:GridHyperLinkColumn>

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               

    <CommandItemSettings ShowAddNewRecordButton="false" />


            </MasterTableView> 
        </telerik:RadGrid> 
                                          
                                          
                                            <script type="text/javascript">
                                                function ViewCheck(id) {


                                                    var url = "ExpenseVoucherView.aspx?evID=" + id;
                                                    var oWnd = radopen(url, "RadWindowDetails");
                                                }
</script>
             <telerik:RadWindowManager ID="RadWindowManager2" runat="server" Width="1300px" Height="600px">
    <Windows>
        <telerik:RadWindow ID="RadWindowDetails" runat="server" Width="1300px" Height="600px">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
                                           <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="50000"></asp:Timer>    
            </ContentTemplate></asp:UpdatePanel>
              
            <%--       </div>--%>
                


        <%--    </div>--%>
      
</asp:Content>
