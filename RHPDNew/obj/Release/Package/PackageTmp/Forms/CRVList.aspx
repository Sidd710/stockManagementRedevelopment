<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="CRVList.aspx.cs" Inherits="RHPDNew.Forms.CRVList" UICulture="hi-IN" Culture="hi-IN"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="heading-bg">
        <div class="container">
            <h1>CRV List</h1>
        </div>
    </div>
    <br />
    <br />
        <style>
            body{background:url(../assets/images/Siachen-3.jpg) no-repeat;background-size:cover;}
        </style>
    <div class="container" runat="server" id="div4">
          
              <div style="margin-left:-85px;" class="row">
                  
                  
                  <script type="text/javascript">
                      function ViewCheck(id) {

                         
                          var url = "StockView.aspx?sID=" + id ;
        var oWnd = radopen(url, "RadWindowDetails");
    }
</script>
                   <script type="text/javascript">
                       function ViewPrint(crv,pID) {

                          
                           var url = "PrintCRV.aspx?cNo=" + crv + "&pID=" + pID;
                           var oWnd = radopen(url, "RadWindowDetails");
                       }
</script>

                  <asp:UpdateProgress ID="UpdateProgress7" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updPacking">
            <ProgressTemplate>                
                <div class="full-pop-up">
              <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left:0%" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
                                   <asp:UpdatePanel runat="server" ID="updPacking">
                                      <ContentTemplate>


           <telerik:RadWindowManager ID="RadWindowManager2" runat="server" Width="1300px" Height="600px">
    <Windows>
        <telerik:RadWindow ID="RadWindowDetails" runat="server" Width="1300px" Height="600px">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
                   

                 
                   
        <telerik:RadGrid OnPreRender="rgdCRV_PreRender" ID="rgdCRV" runat="server"
        GridLines="None" AutoGenerateColumns="False"
        Width="60%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" AllowFilteringByColumn="true" OnNeedDataSource="rgdCRV_NeedDataSource"  > 
         
            <MasterTableView DataKeyNames="SID" GridLines="None"  CommandItemDisplay="Top" > 
              <GroupByExpressions>
                       <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Session" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Session" HeaderText="Session" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                   <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="CRVNo" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="CRVNo" HeaderText="CRV No" />
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
                   
                    
                   <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>                    
                             <FooterTemplate>
                                <asp:Label runat="server" ID="lblCountLabel">Count:</asp:Label>
                            </FooterTemplate>
                          
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn Visible="false" HeaderText="SID" DataField="SID" DataType="System.Int32" UniqueName="SID">
                            <ItemTemplate>                               
                                 <%#Eval("SID") %>
                            </ItemTemplate>                         
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn   HeaderText="AT/SO No" DataField="ATNo" DataType="System.String" UniqueName="ATNo" ><%--HeaderStyle-Width="50" FilterControlWidth="50" ItemStyle-Width="50">--%>
                                    <ItemTemplate>
                                           <asp:Label runat="server" ID="nn" Text='<%#Eval("ATSONo") %>' Style="height:100%;width:105px;word-wrap:break-word;display:block"></asp:Label>                                         
                                    </ItemTemplate>
                           <FooterTemplate>
                                <asp:Label runat="server" ID="lblCount"></asp:Label>
                            </FooterTemplate>                          
                                </telerik:GridTemplateColumn>                    
                     
                     <telerik:GridTemplateColumn   HeaderText="CRV No" DataField="CRVNo" DataType="System.String" UniqueName="CRVNo">
                            <ItemTemplate>
                          <%#Eval("CRVNo") %>
                                               
                         
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                       <telerik:GridTemplateColumn   HeaderText="Category" DataField="Cat" DataType="System.String" UniqueName="Cat">
                                    <ItemTemplate>                                      
                                               
                                        
                                                   <%#Eval("Cat").ToString()%>
                     
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>
                      
                        <telerik:GridTemplateColumn  HeaderText="Items" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                            <ItemTemplate>

                                    <%-- <%#(Convert.ToBoolean(Eval("IsEmptyPM"))==true?"Empty": Eval("ITEMS").ToString()) %>--%>
                                 <%#(Eval("ITEMS").ToString()) %>
                     
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn Visible="false"  HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                            <ItemTemplate>
                                <%#Eval("AU") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                        
                                    
                                      <telerik:GridTemplateColumn HeaderText="Quantity" DataField="Quantity" DataType="System.Double" UniqueName="Quantity">
                            <ItemTemplate>
                               
                                
                                                      
                                       <asp:Label runat="server" ID="lblQuantity" Text='<%#Convert.ToDouble(Eval("Quantity").ToString())<0?"0":Eval("AU").ToString()=="NOS"?Convert.ToDouble(Eval("Quantity").ToString()).ToString("0.00"):Convert.ToDouble(Eval("Quantity").ToString()).ToString("0.000")%>'></asp:Label>         
                               
                            </ItemTemplate>
                          <FooterTemplate>
                                <asp:Label runat="server" ID="lblPQty"></asp:Label>
                            </FooterTemplate>
                           
                        </telerik:GridTemplateColumn>  
                     <telerik:GridTemplateColumn HeaderText="Issued Quantity" DataField="IssueQty" DataType="System.Double" UniqueName="IssueQty">
                            <ItemTemplate>
                               
                                
                                                      
                                       <asp:Label runat="server" ID="lblIssueQuantity" Text='<%#Eval("IssueQty").ToString()==""?"0":Eval("AU").ToString()=="NOS"?Convert.ToDouble(Eval("IssueQty").ToString()).ToString("0.00"):Convert.ToDouble(Eval("IssueQty").ToString()).ToString("0.000")%>'></asp:Label>         
                               
                            </ItemTemplate>
                       
                           
                        </telerik:GridTemplateColumn>  
                      <telerik:GridTemplateColumn Visible="false" HeaderText="PM Quantity" DataField="PMQty" DataType="System.Double" UniqueName="PMQty">
                            <ItemTemplate>
                               
                               
                                                      
                                                  <%#(Convert.ToBoolean(Eval("IsEmptyPM"))==true?"N/A":(Convert.ToDouble(Eval("PMQty")).ToString("0"))) %>
                               
                               
                            </ItemTemplate>
                         
                           <FooterTemplate>
                                <asp:Label runat="server" ID="lblQtyLabel" Text="&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp           Total Amount:"></asp:Label>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>  
           
              

                     <telerik:GridTemplateColumn Visible="false" HeaderText="Rate" DataField="CostOfParticular" DataType="System.Double" UniqueName="CostOfParticular">
                            <ItemTemplate>
                               
                               
                                    <asp:Label runat="server" ID="lblRate"></asp:Label>
                                                      
                                per  <%#Eval("AU") %>
                                                      
                                                        
                                               
                               
                            </ItemTemplate>
                        
                          <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Amount" DataField="Amount" DataType="System.Double" UniqueName="Amount" >
                            <ItemTemplate>
                                
                                
                                    
                                                  
                              <asp:Label runat="server" Text='<%#(Convert.ToDouble(Eval("Amount")).ToString("0.00")) %>' ID="lblamt"></asp:Label>
                                                      
                               


                               
                            </ItemTemplate>
                          <FooterTemplate>
                                <asp:Label runat="server" ID="lblQty"></asp:Label>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn> 
                         <telerik:GridTemplateColumn HeaderText="Recieved Date" DataField="RecievedOn" DataType="System.DateTime" UniqueName="RecievedOn">
                            <ItemTemplate>
                               
                                 <%#Convert.ToDateTime(Eval("RecievedOn")).ToString("dd-MM-yyyy") %>
                                                      
                                               
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn HeaderText="Created Date" DataField="AddedOn" DataType="System.DateTime" UniqueName="AddedOn">
                            <ItemTemplate>
                               
                                 <%#Convert.ToDateTime(Eval("AddedOn")).ToString("dd-MM-yyyy") %>
                                                      
                                               
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
         
                      <telerik:GridTemplateColumn Visible="false" HeaderText="Remarks" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                            <ItemTemplate>
                               
                                 <asp:Label runat="server" Text='<%#Eval("Remarks").ToString() %>' ID="lblFormat"></asp:Label>
                                                      
                                               
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                    <telerik:GridHyperLinkColumn AllowFiltering="false" HeaderText="" UniqueName="SIDView" DataTextField="SID"
    DataTextFormatString="View Detail" DataNavigateUrlFields="SID" DataNavigateUrlFormatString="javascript:ViewCheck({0})">
</telerik:GridHyperLinkColumn>
                     <telerik:GridHyperLinkColumn AllowFiltering="false" HeaderText="" UniqueName="SIDPrint" DataTextField="CRVPrint"
    DataTextFormatString="Print" DataNavigateUrlFields="CRVNo,ProductId" DataNavigateUrlFormatString="../Forms/printcrv.aspx?cno={0}&pid={1}" Target="Blank">
</telerik:GridHyperLinkColumn>
                    
                  

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               

    <CommandItemSettings ShowAddNewRecordButton="false" />


            </MasterTableView> 
        </telerik:RadGrid>
            
                   
            </ContentTemplate></asp:UpdatePanel>
              
                   </div>
                


            </div>

</asp:Content>
