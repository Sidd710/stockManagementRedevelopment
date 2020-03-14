<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="loadtallyNumberlist.aspx.cs" Inherits="RHPDNew.StockOutPanel.loadtallyNumberlist" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                           
         <style>
            body{background:url(../assets/images/armysitting.jpg) no-repeat;background-size:cover;}
        </style>


       <script src="JSpath/jquery-1.8.3.min.js"></script>
   <script src="JSpath/jquery-ui.js"></script>
       <link href="JSpath/jquery-ui.css" rel="stylesheet" />
     <link href="/css/style.css" rel="stylesheet" media="screen" type="text/css" />
<link href="/css/style_1.css" rel="stylesheet" media="print" type="text/css" />
     


             <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Load Tally List</h1>
            </div>
        </div>
         <br />
         <br />
           <asp:UpdateProgress ID="UpdateProgress7" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updPacking">
            <ProgressTemplate>                
                <div class="full-pop-up">
              <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left:0%" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
                                   <asp:UpdatePanel runat="server" ID="updPacking">
                                      <ContentTemplate>
     
     <telerik:RadGrid ID="rgdTelly" runat="server" Skin="Telerik"
         GridLines="None" AutoGenerateColumns="false"
         Width="97%" EnableAJAX="True" ShowFooter="true" AllowPaging="true" AllowFilteringByColumn="true" OnNeedDataSource="rgdTelly_NeedDataSource"> 
         
            <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" > 
              <GroupByExpressions>
                       <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Type" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Type" HeaderText="Type" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                 
                    </GroupByExpressions>
                <Columns> 
                                                         
 <telerik:GridTemplateColumn HeaderText="SNo" DataField="Id" DataType="System.Int32" UniqueName="Id" AllowFiltering="false">
                            <ItemTemplate>
                               
                                          <%#Container.DataSetIndex+1%>
                                             
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn HeaderText="Load Tally No" DataField="LoadTallyNo" DataType="System.String" UniqueName="LoadTallyNo">
                            <ItemTemplate>
                               
                                               
                                               <%#Eval("LoadTallyNo") %>    
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Type" DataField="Type" DataType="System.String" UniqueName="Type">
                            <ItemTemplate>
                               
                                               
                                    <%#Eval("Type") %>  
                                
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn>  
                     <telerik:GridTemplateColumn HeaderText="Vehicle Detail" DataField="Type" DataType="System.String" >
                            <ItemTemplate>
                               
                                               
                                       
                                Army No: <%#Eval("ArmyNo") %>       <br />
                                Driver Name:  <%#Eval("DriverName") %>     <br />
                                 Vehicle No:  <%#Eval("VechileNo") %>         
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn>  
                     <telerik:GridTemplateColumn  Visible="false" HeaderText="Army No" DataField="ArmyNo" DataType="System.String" UniqueName="ArmyNo">
                            <ItemTemplate>
                               
                                               
                                           <%#Eval("ArmyNo") %>        
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn  Visible="false" HeaderText="Driver Name" DataField="DriverName" DataType="System.String" UniqueName="DriverName">
                            <ItemTemplate>
                               
                                               
                                           <%#Eval("DriverName") %>        
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn Visible="false" HeaderText="Vechile No" DataField="VechileNo" DataType="System.String" UniqueName="VechileNo">
                            <ItemTemplate>
                               
                                               
                                           <%#Eval("VechileNo") %>        
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                 
                   
                                         <telerik:GridTemplateColumn HeaderText="Issue Quantity" DataField="IssueQuantity" DataType="System.Decimal" UniqueName="IssueQuantity">
                            <ItemTemplate>
                               
                                               
                                           <%#Convert.ToDouble(Eval("IssueQuantity").ToString()).ToString("0.000") %>        
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                  

                     <telerik:GridTemplateColumn HeaderText="Dispatch To" DataField="DispatchTo" DataType="System.String" UniqueName="DispatchTo">
                            <ItemTemplate>
                               
                                               
                                           <%#Eval("DispatchTo") %>        
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn HeaderText="Through" DataField="Through" DataType="System.String" UniqueName="Through">
                            <ItemTemplate>
                               
                                               
                                           <%#Eval("Through") %>        
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                          <telerik:GridTemplateColumn HeaderText="Date of Genration" DataField="DateofGenration" DataType="System.DateTime" UniqueName="DateofGenration">
                            <ItemTemplate>
                               
                                               
                                           <%#Convert.ToDateTime(Eval("DateofGenration").ToString()).ToString("dd-MMM-yyyy") %>        
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn>
                       <telerik:GridTemplateColumn HeaderText="Created On" DataField="Createddate" DataType="System.DateTime" UniqueName="Createddate">
                            <ItemTemplate>
                               
                                               
                                           <%#Convert.ToDateTime(Eval("Createddate").ToString()).ToString("dd-MMM-yyyy hh:mm tt") %>        
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                        <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                            <ItemTemplate>
                               
                                               
                                           <%#Eval("Remarks") %>        
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
 <telerik:GridTemplateColumn Visible="false" HeaderText=""   AllowFiltering="false">
                            <ItemTemplate>
                               
                                  <asp:LinkButton ID="lbnPRint" runat="server"  Text="Print" PostBackUrl='<% #"~/StockOutPanel/PrintLoadTally.aspx?no="+Eval("LoadTallyNo")%>' ></asp:LinkButton>
                                      
                                             
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn>     
 
                    <telerik:GridHyperLinkColumn AllowFiltering="false" HeaderText="" UniqueName="LTView" DataTextField="Id"
    DataTextFormatString="View Detail" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="javascript:ViewCheck({0})">
</telerik:GridHyperLinkColumn>
                     <telerik:GridHyperLinkColumn AllowFiltering="false" HeaderText="" UniqueName="SIDPrint" DataTextField="Id"
    DataTextFormatString="Print" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="../StockOutPanel/PrintLoadTally.aspx?ltNo={0}" Target="Blank">
</telerik:GridHyperLinkColumn>
                    
                           
                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               
            </MasterTableView> 
        </telerik:RadGrid>

                                                          <script type="text/javascript">
                                                              function ViewCheck(id) {


                                                                  var url = "LoadTallyView.aspx?ltNo=" + id;
                                                                  var oWnd = radopen(url, "RadWindowDetails");
                                                              }
</script>
             <telerik:RadWindowManager ID="RadWindowManager2" runat="server" Width="1300px" Height="600px">
    <Windows>
        <telerik:RadWindow ID="RadWindowDetails" runat="server" Width="1300px" Height="600px">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
                   
     <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="50000"></asp:Timer></ContentTemplate></asp:UpdatePanel>

     </asp:Content>
