<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="frmPMList.aspx.cs" Inherits="RHPDNew.Forms.frmPMList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="heading-bg">
        <div class="container">
            <h1>Packaging Material List</h1>
        </div>
    </div>
    <br />
    <br />
        <style>
            body{background:url(../assets/images/Siachen-3.jpg) no-repeat;background-size:cover;}
        </style>
    <div class="container" runat="server" id="div4">
        
        <asp:UpdateProgress ID="UpdateProgress7" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updPacking">
            <ProgressTemplate>
                
                <div class="full-pop-up">
              <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left:0%" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
                                   <asp:UpdatePanel runat="server" ID="updPacking">
                                      <ContentTemplate>

      
          
              <div class="row" style="margin-left:-85px;">
                  
                          
                   
        <telerik:RadGrid OnPreRender="rgdCRV_PreRender" ID="rgdCRV" runat="server"
        GridLines="None" AutoGenerateColumns="False"
        Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" AllowFilteringByColumn="true" OnNeedDataSource="rgdCRV_NeedDataSource"  > 
         
            <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="Top" > 
             
                <Columns> 
                   
                    
                   <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>                    
                            <FooterTemplate>
                                <asp:Label runat="server" ID="lblCountLabel"> Count:</asp:Label>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn Visible="false" HeaderText="SID" DataField="SID" DataType="System.Int32" UniqueName="SID">
                            <ItemTemplate>
                               
                                 <%#Eval("SID") %> 
                                <asp:Label ID="IsEmptyPM" runat="server" Text='<%#Eval("IsEmptyPM") %>'></asp:Label>                                            
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                      <telerik:GridTemplateColumn   HeaderText="Category" DataField="Cat" DataType="System.String" UniqueName="Cat">
                                    <ItemTemplate>                                      
                                               
                                        
                                                   <%#Eval("Cat").ToString() %>
                     
                                    </ItemTemplate>
                           <FooterTemplate>
                                <asp:Label runat="server" ID="lblCount"></asp:Label>
                            </FooterTemplate>
                          
                                </telerik:GridTemplateColumn>
             
                     
                         <telerik:GridTemplateColumn   HeaderText="PM Name" DataField="PackingMaterial" DataType="System.String" UniqueName="PackingMaterial">
                            <ItemTemplate>
                                         
                                  <%#(Eval("PackingMaterial").ToString()) %>
                          
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      
                     <telerik:GridTemplateColumn   HeaderText="Capacity" DataField="Capacity" DataType="System.String" UniqueName="Capacity">
                            <ItemTemplate>
                          <%#Eval("Capacity") %>                  
                         
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      
                        <telerik:GridTemplateColumn  HeaderText="Grade" DataField="Grade" DataType="System.String" UniqueName="Grade">
                            <ItemTemplate>
                                <%#Eval("Grade") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn  HeaderText="Condition" DataField="Condition" DataType="System.String" UniqueName="Condition">
                            <ItemTemplate>
                                <%#Eval("Condition") %>
                            </ItemTemplate>
                           <FooterTemplate>
                                <asp:Label runat="server" ID="lblQtyLabel" Text="&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp            Total:"></asp:Label>
                            </FooterTemplate>
                          <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="PM Quantity" DataField="PMQty" DataType="System.Double" UniqueName="PMQty">
                            <ItemTemplate>
                                <%#(Convert.ToDouble(Eval("PMQty"))==0?"N/A":(Convert.ToDouble(Eval("PMQty")).ToString("0"))) %>
                                               <asp:Label runat="server" ID="lblPMQty" Text='<%#Eval("PMQty") %>' Visible="false"></asp:Label>
                                        
                            </ItemTemplate>
                         
                            <FooterTemplate>
                                <asp:Label runat="server" ID="lblPMQtyF"></asp:Label>
                            </FooterTemplate>
                           
                        </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn   HeaderText="Item Inside" DataField="Product_Name" DataType="System.String" UniqueName="Product_Name"><%-- HeaderStyle-Width="300" ItemStyle-Width="300" FooterStyle-Width="300" FilterControlWidth="200" > --%>
                                    <ItemTemplate>                                 
                                               
                                         <%#(Convert.ToBoolean(Eval("IsEmptyPM"))==true?"Empty": Eval("Product_Name").ToString()) %>
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Product Quantity" DataField="Quantity" DataType="System.Double" UniqueName="Quantity">
                            <ItemTemplate>
                               
                                
                                                   <%#(Convert.ToBoolean(Eval("IsEmptyPM"))==true?"N/A":TruncateDecimalToString(Convert.ToDouble(Eval("Quantity")),3)) %>
                                              
                                       <asp:Label Visible="false" runat="server" ID="lblQuantity" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("Quantity")),3) %>'></asp:Label>         
                               
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
         

                </Columns> 

                   

    <CommandItemSettings ShowAddNewRecordButton="false" />


            </MasterTableView> 
        </telerik:RadGrid>
            
                   
            
              
                   </div>
                
</ContentTemplate></asp:UpdatePanel>

            </div>

</asp:Content>

