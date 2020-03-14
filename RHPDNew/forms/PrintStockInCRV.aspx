<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="PrintStockInCRV.aspx.cs" Inherits="RHPDNew.Forms.PrintStockInCRV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script type="text/javascript">
        function print_page() {
            var btnprints = document.getElementById("btnprints");
            btnprints.style.visibility = "hidden";

            var btnIssueVoucher = document.getElementById("btnIssueVoucher");
            btnIssueVoucher.style.visibility = "hidden";

            window.print();

        }
    </script>
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
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
                <div class="form-group-2" style="float:right;">
                       <asp:Button ID="btnprints" runat="server" Text="print"/>
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>
    <div class="heading-bg">
        <div class="container">
            <h1>CRV</h1>
        </div>
    </div>
    <div>
        <div class="clearfix"></div>
         <asp:Panel id="pnlContents" runat = "server">
       
    </asp:Panel>
    <br />
    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick = "return PrintPanel();" />
   
        <div class="container">
            <p>&nbsp;</p>
              <div style="float:right;">
               <asp:Label ID="lblCRV" runat="server" style="font-family:'Times New Roman';font-size:large;"></asp:Label> <span style="font-family:'Times New Roman';font-size:large;">/CRV/ &nbsp&nbsp dt <%=DateTime.UtcNow.ToShortDateString() %></span><br />
                  <span style="font-family:'Times New Roman';font-size:large;"> 408HQ Coy ASC(Pet)<br />
              C/O 56 APO</span>
        
            </div>
            <p>&nbsp;</p>

           

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Received From:</label>
                    <asp:Label ID="lblRecivedFrom"  runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row" id="unit" runat="server" >
                <div class="form-group-2">
                    <label class="col-lg-2">AT No: </label>
                    <asp:Label ID="lblATNo" runat="server" Text=""></asp:Label>
                </div>
            </div>


            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Vechicle No:</label>
                     <asp:Label ID="lblVechicleNo" runat="server" Text=""></asp:Label>
                        
            
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Rate:</label>
                     <asp:Label ID="lblRate" runat="server" Text=""></asp:Label>
                        
            
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Amount:</label>
                     <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
                        
            
                </div>
            </div>

               <telerik:RadGrid ID="rgdCRV" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" OnItemCreated="rgdCRV_ItemCreated"  > 
         
            <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="none" > 
              
                <Columns> 
                   
                    
                   <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                      
                    
                        <telerik:GridTemplateColumn  HeaderText="Items" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                            <ItemTemplate>
                                <%#Eval("ITEMS") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn  HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                            <ItemTemplate>
                                <%#Eval("AU") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                        
                               <telerik:GridTemplateColumn HeaderText="" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                            <ItemTemplate>
                                   <asp:Label ID="lblB" runat="server" Text="Batch(s):" ></asp:Label>
                                <telerik:RadGrid  ID="rgdCRVBatch" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="97%" EnableAJAX="True" Skin="Office2010Black" OnItemCreated="rgdCRVBatch_ItemCreated" >
         
            <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="true" ShowHeader="true" > 
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
                     <telerik:GridTemplateColumn   HeaderText="" DataField="BatchNo" DataType="System.Int32" UniqueName="BID">
                            <ItemTemplate>
                              
                            </ItemTemplate>
                         <FooterTemplate>
                               Total:
                         </FooterTemplate>
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                            <ItemTemplate>
                              
                                 <asp:Label runat="server" ID="lblBatchNo" Text='<%#Eval("BatchNo").ToString()%>'></asp:Label>
                                
                            
                            </ItemTemplate>
                          <FooterTemplate>
                              <asp:Label runat="server"  ID="lblCount"></asp:Label>
                          </FooterTemplate>
                          
                        </telerik:GridTemplateColumn>
                        
                     <telerik:GridTemplateColumn  HeaderText="Packaging" DataField="Format" DataType="System.String" UniqueName="Format">
                            <ItemTemplate>
                                 <%#Eval("PackagingType") %>: <%#Eval("Format") %>
                            </ItemTemplate>
                          <FooterTemplate>
                                            
                                             
                                              Full Packaging:
                            <asp:Label runat="server"  ID="lblTotalFullFormat"></asp:Label><br />
                                              Loose Packaging:
                            <asp:Label runat="server"  ID="lblTotalLooseFormat"></asp:Label>
                            
                                         </FooterTemplate>
                        </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn   HeaderText="Quantity" DataField="RemainingQty" DataType="System.String" UniqueName="BatchNo">
                            <ItemTemplate>
                                <%#Eval("RemainingQty") %>
                            </ItemTemplate>
                         <FooterTemplate>

                               <asp:Label runat="server"  ID="lblTotalQuatity"></asp:Label>
                         </FooterTemplate>
                        </telerik:GridTemplateColumn>


                      
                        <telerik:GridTemplateColumn HeaderText="Manufacturing Date" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblMFGDate" Text='<%#Eval("MFGDate").ToString()%>'></asp:Label>
                                
                               
                            </ItemTemplate>
                           
                        </telerik:GridTemplateColumn>
                        
                         <telerik:GridTemplateColumn HeaderText="ESL Date" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                            <ItemTemplate>
                                  <asp:Label runat="server" ID="lblEsl" Text='<%#Eval("Esl").ToString()%>'></asp:Label>
                             
                            
                               
                            </ItemTemplate>
                            
                        </telerik:GridTemplateColumn>
                   
                     <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                            <ItemTemplate>
                                 <asp:Label runat="server" ID="lblEXPDate" Text='<%#Eval("EXPDate").ToString()%>'></asp:Label>
                             
                                           
                            </ItemTemplate>
                             
                        </telerik:GridTemplateColumn>
                  

                </Columns> 

                 <FooterStyle HorizontalAlign="Left" />
               
            </MasterTableView> 
        </telerik:RadGrid>
                                                      
                            
                            </ItemTemplate>
                                        
                            
                        </telerik:GridTemplateColumn>
                    

                            
                      <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.Int32" UniqueName="Remarks">
                            <ItemTemplate>
                               
                                 <asp:Label runat="server" Text='<%#Eval("Remarks").ToString() %>' ID="lblFormat"></asp:Label>
                                                      
                                               
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn>            
                     
                  

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               
            </MasterTableView> 
        </telerik:RadGrid>
             <asp:Label ID="Label1" runat="server">(Items Two Only)</asp:Label><br />
            <asp:Label ID="lblInWords" runat="server"></asp:Label>
            
              
                          
        </div>
    </div>
</asp:Content>
