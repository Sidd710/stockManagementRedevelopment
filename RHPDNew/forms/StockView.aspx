<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockView.aspx.cs" Inherits="RHPDNew.Forms.StockView" %>
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
  
 
   <%-- <div class="container-fluid form-outer">
           <div class="container">--%>
                         <asp:Accordion ID="accData" runat="server" HeaderCssClass="Header" ContentCssClass="Contents" HeaderSelectedCssClass="SelectedHeader" Font-Names="Verdana" Font-Size="10" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1" FramesPerSecond="100"
        FadeTransitions="true" TransitionDuration="500">
               <Panes>
                <asp:AccordionPane ID="apStock" runat="server">
                <Header>Stock</Header>
                <Content>
                    <p>Stock <%=stcokCase %>:</p>
                   <div class="" runat="server" id="divStockGrid">
                       <telerik:RadGrid ClientSettings-EnablePostBackOnRowClick="true" ID="rgdStockList" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="false" OnSelectedIndexChanged="rgdStockList_SelectedIndexChanged" ClientSettings-Selecting-AllowRowSelect="true" > 
         
            <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" > 
             
                <Columns> 
                   
                    
                                <telerik:GridTemplateColumn  HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>                    
                            
                        </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn  HeaderText="AT/SO No" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                            <ItemTemplate>
                                <%-- <%# (Eval("ATNo").ToString()==""? "Supply Order NO:":"AT NO:")%>--%>
                                           
                                      
                                           <asp:Label runat="server" ID="nn" Text='<%#Eval("ATSONo") %>' Style="height:100%;width:55px;word-wrap:break-word;display:block"></asp:Label>
                            
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                   
                      
                        <telerik:GridTemplateColumn  HeaderText="Product" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                            <ItemTemplate>
                                <%#Eval("ITEMS") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn  HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                            <ItemTemplate>
                                <%#Eval("AU") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn  HeaderText="Recieved From" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                            <ItemTemplate>
                                                     <%#Eval("RecievedFrom") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn  HeaderText="Other Supplier " DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                            <ItemTemplate>
                                                     <%#Eval("OtherSupplier") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn  HeaderText="Other manufacture " DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                            <ItemTemplate>
                                                     <%#Eval("OriginalManf") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn  HeaderText="Generic Name " DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                            <ItemTemplate>
                                                     <%#Eval("GenericName") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                         <telerik:GridTemplateColumn  HeaderText="Packaging Material " DataField="AU" DataType="System.String" UniqueName="AU">
                                    <ItemTemplate>

                                        <%#Eval("PackingMaterial") %><%#(Eval("PackingMaterialFormat").ToString()==""?"": "["+Eval("PackingMaterialFormat")+"]")%>
                                        <br />
                                        
          <%#(Convert.ToBoolean(Eval("IsWithoutPacking").ToString())==true?"":  "Shape & size:"+Eval("PackagingMaterialShape")+ " & "+Eval("PackagingMaterialSize")+" "+Eval("ShapeUnit") +"<br />")%>
       
      Weight: <%#Eval("Weight") %>&nbsp <%#Eval("WeigthUnit") %> per  PM

                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>


                     <telerik:GridTemplateColumn  HeaderText="Sub Packaging Material " DataField="AU" DataType="System.String" UniqueName="AU">
                                    <ItemTemplate>


                     <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString())==false?"": "Name: "+ Eval("SubPackingMaterial") )%><br />
                                           
                                            <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString())==false?"":  Eval("SubPMShape").ToString()!=""?"Shape & Size: "+ Eval("SubPMShape") +" & "+Eval("SubPMSize")+" "+Eval("SubShapeUnit"):"" )%><br />
                                        
                                                
                                              <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString())==false?"":  (Eval("SubWeight").ToString()!=""?" Weight: "+TruncateDecimalToString(Convert.ToDouble(Eval("SubWeight") ),3)+"  "+Eval("SubWeightUnit"):"")+"<br />" )%>
                                      
                                         </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>





                        
                          
                    
                       <telerik:GridTemplateColumn Visible="false" HeaderText="Rate" DataField="CostOfParticular" DataType="System.Int32" UniqueName="CostOfParticular">
                                    <ItemTemplate>
                               
                                                            
                               <%#(Eval("CostOfParticular").ToString()=="0"?"-":TruncateDecimalToString(Convert.ToDouble(Eval("CostOfParticular").ToString()),2)) %> per  <%#Eval("AU") %>
                                    </ItemTemplate>
                               
                                </telerik:GridTemplateColumn> 
                                <telerik:GridTemplateColumn Visible="false" HeaderText="Amount" DataField="Amount" DataType="System.Int32" UniqueName="Amount">
                                    <ItemTemplate>
                             <%#((Convert.ToDouble(Eval("CostOfParticular").ToString()) *Convert.ToDouble(Eval("Quantity").ToString())).ToString()=="0"?"-":TruncateDecimalToString((Convert.ToDouble(Eval("CostOfParticular").ToString()) *Convert.ToDouble(Eval("Quantity").ToString())),2)) %>
                                  
                               
                                    </ItemTemplate>
                         
                                </telerik:GridTemplateColumn> 
                          
                   
                  
                          
                     
                  

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               <CommandItemStyle HorizontalAlign="Left" />
            </MasterTableView> 
        </telerik:RadGrid>
                       <div class="row">
                        <div class="col-md-12 text-align-center marginbottom20">
            </div></div>
                      <div class="row">
                             <telerik:RadGrid ID="rgdStockGrid" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true"  > 
         
                    <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" ShowHeader="false" > 
              
                    <Columns> 
                   
                    
                           <telerik:GridTemplateColumn HeaderText="" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                    <ItemTemplate>
                                        <div class="">
                                         
                                             <%-- <%# (Eval("ATNo").ToString()==""? "Supply Order NO:":"AT NO:")%>--%>
                                           
                                            <asp:Label runat="server" ID="nn" Text='<%#Eval("ATSONo") %>' Style="margin-bottom:-16px;width:65%;word-wrap:break-word;display:block;margin-left:17%"></asp:Label><br />
        Received From: <%#Eval("RecievedFrom") %> Supplier: <%#Eval("OtherSupplier") %><br />
        TRANSFER By: <%#Eval("TransferedBy") %><br />
      
        Product:   <%#Eval("ITEMS") %> A/U: <%#Eval("AU") %><br />
        Original manufacture : <%#Eval("OriginalManf") %><br />
        GENERIC NAME: <%#Eval("GenericName") %><br />
      <%--  Cost of particular: <%#TruncateDecimalToString( Convert.ToDouble(Eval("CostOfParticular") ),2)%> per  <%#Eval("AU") %><br />--%>
        RECEIVED DATE: <%#Convert.ToDateTime( Eval("RecievedOn")).ToString("dd MM yyyy") %><br />
                                             REMARKS : <%#Eval("Remarks") %><br />
         <%#(Eval("PackingMaterial").ToString()==""?"":"Packaging Material Name	: "+Eval("PackingMaterial")+"<br />" )%>
                                               Weight : <%#TruncateDecimalToString(Convert.ToDouble(Eval("Weight") ),3) %>&nbsp <%#Eval("WeigthUnit") %> &nbsp per PM<br />
        <%#(Convert.ToBoolean(Eval("IsWithoutPacking").ToString())==true?"":  "Shape & size:"+Eval("PackagingMaterialShape")+ " & "+Eval("PackagingMaterialSize")+" "+Eval("ShapeUnit") +"<br />")%>
                                          
                                            <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString())==false?"": "Sub Packaging Material Name: "+ Eval("SubPackingMaterial") +"<br />")%>
                                             
                                              <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString())==false?"":  (Eval("SubWeight").ToString()!=""?" Weight: "+TruncateDecimalToString(Convert.ToDouble(Eval("SubWeight") ),3)+"  "+Eval("SubWeightUnit")+"<br />":"") )%>
                                            <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString())==false?"":(Eval("SubPMShape").ToString()!=""? "Shape & Size: "+ Eval("SubPMShape") +" & "+Eval("SubPMSize")+" "+Eval("SubShapeUnit")+"<br />":"") )%>
                                         <%#(Convert.ToDouble(Eval("PackagingMaterialFormatLevel").ToString())==0?"": "Level: "+ Eval("PackagingMaterialFormatLevel") +"<br />")%>
                                                <%#(Convert.ToDouble(Eval("PackagingMaterialFormatLevel").ToString())==0?"":  (Eval("PackingMaterialFormat").ToString()==""?"": "Format: "+Eval("PackingMaterialFormat"))+"<br />" )%>
     
                                                    
 
                                            
       

                                                               </div>
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

                  <asp:AccordionPane ID="apBatch" runat="server">
                <Header>Batch(s)</Header>
                <Content>
                 <div class="container">
                      
                
                      <div class="row" runat="server" id="dvListBacth">
                   
                     <p> All Batch(s) :</p>
                         
                              <telerik:RadGrid ID="rgdBatchList" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true"> 
         
                    <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="Top" > 
                       <CommandItemTemplate>
                           <table>
                               <tr>
                                   <td style="width:12%;" ></td>
                                    
                                    <td style="width:7%;"> <label style="float:left;width:61px;">Expiry Date:</label> <asp:CheckBox Text="-Active" ID="cbxExpDate" runat="server" Checked="true" Enabled="false"  />  </td>
                                    <td style="width:26%;"> <label style="float:left;width:50px;">  ESL :</label> <asp:CheckBox Text="-Active" ID="cbxESLDate" runat="server" Checked="true" Enabled="false" />  
                </td>
                                   
                               </tr>
                           </table>
                            
                            </CommandItemTemplate>
                        <Columns> 
                   
                    
                           <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex+1%>
                                        </div>
                                    </ItemTemplate>
                     
                                </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="BID">
                                    <ItemTemplate>
                                        <%#Eval("BID") %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                    <ItemTemplate>
                                        <%#Eval("BatchNo") %>
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate">
                                    <ItemTemplate>
                                         <%#Eval("MFGDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("MFGDate")).ToString("dd-MM-yyyy") %>
                            
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                    <ItemTemplate>
                                          <%#Eval("EXPDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("EXPDate")).ToString("dd-MM-yyyy")%>
                               
                                    </ItemTemplate>
                             
                                </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="ESL " DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                    <ItemTemplate>
                                         <%#Eval("Esl").ToString()==""?"N/A":Convert.ToDateTime(Eval("Esl")).ToString("MMM-yyyy") %>
                               
                               
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Sample Sent" DataField="IsSentto" DataType="System.Boolean" UniqueName="IsSentto" >
                                    <ItemTemplate>
                                        <asp:CheckBox Enabled="false" Checked=' <%#Eval("IsSentto") %>' runat="server" /><br />

                                        <%#Convert.ToBoolean(Eval("IsSentto"))==true?Eval("ContactNo").ToString()!=""?Eval("ContactNo"):Eval("SampleSentQty").ToString()!=""?Convert.ToDouble(Eval("SampleSentQty")).ToString("0.000") :"":""%>
                               
                                    </ItemTemplate>
                     
                                </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn  HeaderText="Cost" DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                    <ItemTemplate>
                                       
                                             <%#(Eval("Cost").ToString()==""?"": Eval("Cost").ToString())%>

                     
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn> 
                             <telerik:GridTemplateColumn  HeaderText="Cost Of Particular" DataField="CostOfParticular" DataType="System.Double" UniqueName="CostOfParticular">
                                    <ItemTemplate>
                                       
                                         <%#(Eval("CostOfParticular").ToString()==""?"": Eval("CostOfParticular").ToString() +" per "+AU)%>

                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn> 
                             <telerik:GridTemplateColumn  HeaderText="Weight" DataField="Weight" DataType="System.Double" UniqueName="Weight">
                                    <ItemTemplate>
                                      
                                        <%#(Eval("Weight").ToString()==""?"": TruncateDecimalToString(Convert.ToDouble(Eval("Weight").ToString()),3).ToString()+" "+Eval("WeightUnit") )%>
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn> 
                             <telerik:GridTemplateColumn  HeaderText="Weight of Particular" DataField="WeightofParticular" DataType="System.Double" UniqueName="WeightofParticular">
                                    <ItemTemplate>
                                        <%#(Eval("WeightofParticular").ToString()==""?"": TruncateDecimalToString(Convert.ToDouble(Eval("WeightofParticular").ToString()),3)+" "+Eval("WeightUnit") )%>
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn> 
                              
                            <telerik:GridTemplateColumn  HeaderText="Warehouse No" DataField="WarehouseNo" DataType="System.String" UniqueName="WarehouseNo">
                                    <ItemTemplate>
                                        <%#Eval("WarehouseNo") %>
                                    </ItemTemplate>
                                  
                                </telerik:GridTemplateColumn>
                           
                            <telerik:GridTemplateColumn  HeaderText="Rows" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                                    <ItemTemplate>
                                        <%#Eval("SectionRows") %>
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn  HeaderText="Columns" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                                    <ItemTemplate>
                                        <%#Eval("SectionCol") %>
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn>
                     
                            
                             <telerik:GridTemplateColumn  HeaderText="Remarks" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                                    <ItemTemplate>
                                        <%#Eval("Remarks") %>
                                    </ItemTemplate>
                                  </telerik:GridTemplateColumn>
                        </Columns> 

                         <FooterStyle HorizontalAlign="Left" />
               
                    </MasterTableView> 
                </telerik:RadGrid>
            
            
                  
                           </div>

                    </div>
                </Content>
                </asp:AccordionPane>
                  <asp:AccordionPane ID="apVehicle" runat="server">
                <Header>Vehicle</Header>
                <Content>
                <div class="container" >
            
                      
                
                       <div class="row" runat="server" id="divVehicleAll">
                   
                     <p>Commodity Vehiclewise:</p>
                          
                  
                  
                          <telerik:RadGrid ID="rdsVehicleList" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" >
         
                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" > 
                      <GroupByExpressions>
                                 <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderValueSeparator=":" SortOrder="None" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderText="." />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                          <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="VehicleNo" HeaderValueSeparator=":" SortOrder="None" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="VehicleNo" HeaderText="Vehicle No" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression> <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="DriverName" HeaderValueSeparator=":" SortOrder="None" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="DriverName" HeaderText="Driver Name" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                        <Columns> 
                   
                    
                  
                             <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="Id">
                                    <ItemTemplate>
                                        <%#Eval("Id") %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn  HeaderText="" DataField="DriverName" DataType="System.String" UniqueName="DriverName">
                                    <ItemTemplate>
                                       <%-- <%#Eval("DriverName") %>--%>
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="" DataField="VehicleNo" DataType="System.String" UniqueName="VehicleNo">
                                    <ItemTemplate>
                                        <%-- <%#Eval("VehicleNo").ToString() %>   --%>                    
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex+1%>
                                        </div>
                                    </ItemTemplate>
                      
                                </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Challan No" DataField="ChallanNo" DataType="System.String" UniqueName="ChallanNo">
                                    <ItemTemplate>
                                      <%#Eval("ChallanNo").ToString() %>                      
                               
                                    </ItemTemplate>
                                   
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="Bacth No" DataField="StockBatchId" DataType="System.Int32" UniqueName="StockBatchId">
                                    <ItemTemplate>
                                         <%#Eval("BatchNo").ToString() %>                       
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                              
                           
                              <telerik:GridTemplateColumn HeaderText="Sent Qty" DataField="SentQty" DataType="System.Int32" UniqueName="SentQty">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("SentQty")),3) %>' ID="leeebl"></asp:Label>
                                                        
                               
                                    </ItemTemplate>
                          <FooterTemplate>
                             <asp:Label ID="lblQtySent" runat="server"></asp:Label>
                          </FooterTemplate>
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="Recieved Qty" DataField="RecievedQty" DataType="System.Int32" UniqueName="RecievedQty">
                                    <ItemTemplate>
                                      <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("RecievedQty")),3) %>' ID="lsssbl"></asp:Label>
                                      
                                    </ItemTemplate>
                             <FooterTemplate>
                             <asp:Label ID="lblQtyRec" runat="server"></asp:Label>
                          </FooterTemplate>
                                </telerik:GridTemplateColumn>
                     
                  

                        </Columns> 

                         <FooterStyle HorizontalAlign="Left" />
               
                    </MasterTableView> 
                </telerik:RadGrid>
            
                 
                           </div>
                



                    </div>
                </Content>
                </asp:AccordionPane>
               <asp:AccordionPane ID="apSppilage" runat="server">
                <Header>Spillage /Sample sent</Header>
                <Content>
                <div class="container" >
            
                      
                    <div class="row" runat="server" id="divSppilageList">
                   
                     <p>Spillage/Sample sent:</p>
                           <telerik:RadGrid ID="rgdIfSpillage" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="97%"  Skin="Office2010Black" ShowFooter="true"   > 
         
                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" > 
             
                        <Columns> 
                   
                    
                           <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex+1%>
                                        </div>
                                    </ItemTemplate>                    
                            
                                </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="StockId">
                                    <ItemTemplate>
                               <asp:HiddenField ID="hdnIsSent" runat="server" Value='<%#Eval("IsSentto").ToString() %>' />
                                          <asp:Label runat="server" Text='<%#Eval("StockId").ToString() %>' ID="lblStockId"></asp:Label>
                                       <asp:Label runat="server" Text='<%#Eval("StockBatchId").ToString() %>' ID="lblBatch"></asp:Label>
                             
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                    <ItemTemplate>
                                        <%#Eval("BatchNo") %>
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                        
                                             <telerik:GridTemplateColumn HeaderText="Sent Qty" DataField="tSentQty" DataType="System.Int32" UniqueName="tSentQty">
                                    <ItemTemplate>
                                              
                                         <asp:Label runat="server" Text='<%#TruncateDecimalToString( Convert.ToDouble(Eval("tSentQty")),3) %>' ID="lblSentQty"></asp:Label>
                                                      
                            
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="Recieved Qty" DataField="tRecQty" DataType="System.Int32" UniqueName="tRecQty">
                                    <ItemTemplate>
                               
                                         <asp:Label runat="server" Text='<%#TruncateDecimalToString( Convert.ToDouble(Eval("tRecQty")),3) %>' ID="lblRecQty"></asp:Label>
                                                      
                                               
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>            
                              <telerik:GridTemplateColumn HeaderText="Spilled Qty" DataField="SpilledQty" DataType="System.Int32" UniqueName="SpilledQty">
                                    <ItemTemplate>
                                              
                                         <asp:Label runat="server" Text='<%# TruncateDecimal(Convert.ToDouble(Eval("SpilledQty")),3).ToString() %>' ID="lblSpilledQty"></asp:Label>
                                                            
                            
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Sample Sent Qty" DataField="SampleSentQty" DataType="System.Int32" UniqueName="SampleSentQty">
                                    <ItemTemplate>
                               
                                         <asp:Label runat="server" Text='<%#Eval("SampleSentQty").ToString()!=""? TruncateDecimalToString(Convert.ToDouble(Eval("SampleSentQty")),3):"" %>' ID="lblSampleSentQty" Visible='<%#Convert.ToBoolean(Eval("IsSentto")) %>'></asp:Label>
                                                      
                                               
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="Spillage-affected full PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="tSpilqty">
                                    <ItemTemplate >
                                <asp:Label runat="server" Text='<%#Eval("SpillageAffected").ToString()!=""? Convert.ToDouble(Eval("SpillageAffected")).ToString("0"):"" %>' ID="lblSpillQty" ></asp:Label>
                                  
                                               </ItemTemplate>
                           
                     
                             
                                   
                                 </telerik:GridTemplateColumn>
                  
                              <telerik:GridTemplateColumn HeaderText="Sample-affected full PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="tSpilqty">
                                    <ItemTemplate >
                                          <asp:Label runat="server" Text='<%#Eval("SampleAffected").ToString()!=""? Convert.ToDouble(Eval("SampleAffected")).ToString("0"):"" %>' ID="lblSampleQty" Visible='<%#Convert.ToBoolean(Eval("IsSentto")) %>'></asp:Label>
                                  
                              
                                            </ItemTemplate>
                           
                     
                             
                                    
                                 </telerik:GridTemplateColumn>
                  
                              <telerik:GridTemplateColumn HeaderText="Both-affected full PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="tSpilqty">
                                    <ItemTemplate >
                                <asp:Label runat="server" Text='<%#Eval("BothAffected").ToString()!=""? Convert.ToDouble(Eval("BothAffected")).ToString("0"):"" %>' ID="lblBothQty" Visible='<%#Convert.ToBoolean(Eval("IsSentto")) %>'></asp:Label>
                                  
                                                </ItemTemplate>
                           
                     
                             
                                     
                                 </telerik:GridTemplateColumn>
                  
                             <telerik:GridTemplateColumn HeaderText="Total-affected full  PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="tSpilqty">
                                    <ItemTemplate >
                              
                                                 
                                       <asp:Label runat="server" Text='<%#Convert.ToDouble(Eval("DamagedBoxes")).ToString("0") %>' ID="lblDamagedBoxes"></asp:Label>
                                                      
                        
                                    </ItemTemplate>                       
                     
                             
                                
                                 </telerik:GridTemplateColumn>
                      
                    
                  

                        </Columns> 

                         <FooterStyle HorizontalAlign="Right" />
               
                    </MasterTableView> 
                </telerik:RadGrid>
            
              
                           </div>
                


                    </div>
                </Content>
                </asp:AccordionPane>
                   <asp:AccordionPane ID="apPackaging" runat="server">
                <Header>Packaging</Header>
                <Content>
                <div class="container" >
            
                      <div class="row" runat="server" id="divDispPack">  
                             <p>Packaging:</p>
                          <table style="width:97%">
                              <tr>
                                 
                                   <td><asp:Label runat="server" ID="lblTotalQtyPackaging" style="float:right"></asp:Label></td>
                              </tr>
                          </table>
                          <telerik:RadGrid ID="rgdPackagingListFull" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true"  > 
         
                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" > 
                       <GroupByExpressions>
                       
                          <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="PackagingType" HeaderValueSeparator=":" SortOrder="Ascending" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="PackagingType" HeaderText="Packaging Type" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                        <Columns> 
                   
                    
                           <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex+1%>
                                        </div>
                                    </ItemTemplate>                    
                            
                                </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Id") %>' runat="server" ID="lblBatchID"></asp:Label>
                               
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>
                    
                                <telerik:GridTemplateColumn  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <%#Eval("BatchNo") %>
                                    </ItemTemplate>
                                   <FooterTemplate>
                                     Total Packaging:                               
                                   </FooterTemplate>
                                </telerik:GridTemplateColumn>

                        
                                            <telerik:GridTemplateColumn HeaderText="Quantity" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                              
                                       
                                         <asp:Label runat="server" Text='<%#TruncateDecimalToString( Convert.ToDouble(Eval("RemainingQty")),3) %>' ID="lblQuantity"></asp:Label>
                                                      
                            
                                    </ItemTemplate>
                                                 <FooterTemplate>
                                                       <asp:Label runat="server"  ID="lblTotalQuatity"></asp:Label>
                            
                                                 </FooterTemplate>
                            
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="Packaging" DataField="Format" DataType="System.Int32" UniqueName="Format"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                               
                                         <asp:Label runat="server" Text='<%#Eval("Format").ToString() %>' ID="lblFormat"></asp:Label>
                                                      
                                               
                               
                                    </ItemTemplate>
                                  <FooterTemplate>
                                                       <asp:Label runat="server"  ID="lblTotalPackFormat"></asp:Label>
                            
                                                 </FooterTemplate>
                           
                                </telerik:GridTemplateColumn>            
                     
                  

                        </Columns> 

                         <FooterStyle HorizontalAlign="left" />
               
                    </MasterTableView> 
                </telerik:RadGrid> 
                            <telerik:RadGrid ID="rgdPackingListLoose" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" ShowHeader="false"  > 
         
                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" > 
                       <GroupByExpressions>
                       
                          <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="PackagingType" HeaderValueSeparator=":" SortOrder="Ascending" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="PackagingType" HeaderText="Packaging Type" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                        <Columns> 
                   
                    
                           <telerik:GridTemplateColumn HeaderText="" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex+1%>
                                        </div>
                                    </ItemTemplate>                    
                            
                                </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Id") %>' runat="server" ID="lblBatchID"></asp:Label>
                               
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>
                    
                                <telerik:GridTemplateColumn  HeaderText="" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <%#Eval("BatchNo") %>
                                    </ItemTemplate>
                                   <FooterTemplate>
                                     Total Packaging:                               
                                   </FooterTemplate>
                                </telerik:GridTemplateColumn>
                        
                                            <telerik:GridTemplateColumn  HeaderStyle-Width="250" ItemStyle-Width="250" HeaderText="" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                                    <ItemTemplate>
                                              
                                        <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("RemainingQty")),3) %>' ID="lblQuantity"></asp:Label>
                                                        
                            
                                    </ItemTemplate>
                                                 <FooterTemplate>
                                                       <asp:Label runat="server"  ID="lblTotalQuatity"></asp:Label>
                            
                                                 </FooterTemplate>
                            
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn  HeaderStyle-Width="250" ItemStyle-Width="250" HeaderText="" DataField="Format" DataType="System.Int32" UniqueName="Format">
                                    <ItemTemplate>
                               
                                         <asp:Label runat="server" Text='<%#Eval("Format").ToString() %>' ID="lblFormat"></asp:Label>
                                                      
                                               
                               
                                    </ItemTemplate>
                                  <FooterTemplate>
                                                       <asp:Label runat="server"  ID="lblTotalPackFormat"></asp:Label>
                            
                                                 </FooterTemplate>
                           
                                </telerik:GridTemplateColumn>            
                     
                  

                        </Columns> 

                         <FooterStyle HorizontalAlign="left" />
               
                    </MasterTableView> 
                </telerik:RadGrid> 
          
      
                          </div>
                      
                


                    </div>
                </Content>
                </asp:AccordionPane> 
                   <asp:AccordionPane ID="acDW" runat="server" Visible="false">
                <Header>DW Packaging</Header>
                <Content>
                <div class="container" >
            
                      <div class="row" runat="server" id="dvDWShow">  
                             <p>Packaging:</p>
                            <telerik:RadGrid ID="rgdDWShow" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="90%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true"  > 
         
                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" > 
                       <GroupByExpressions>
                       
                          <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="PackagingType" HeaderValueSeparator=":" SortOrder="Ascending" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="PackagingType" HeaderText="Packaging Type" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                        <Columns> 
                   
                    
                           <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex+1%>
                                        </div>
                                    </ItemTemplate>                    
                            
                                </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Id") %>' runat="server" ID="lblBatchID"></asp:Label>
                               
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>
                    
                                <telerik:GridTemplateColumn  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                        <%#Eval("BatchNo") %>
                                    </ItemTemplate>
                                   <FooterTemplate>
                                       Total:
                                   </FooterTemplate>
                                </telerik:GridTemplateColumn>
                        
                                            <telerik:GridTemplateColumn HeaderText="Quantity" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                                              
                                         <asp:Label runat="server" Text='<%#( Convert.ToDouble(Eval("RemainingQty")).ToString("0")) %>' ID="lblQuantity"></asp:Label>
                                                      
                            
                                    </ItemTemplate>
                                                 
                            <FooterTemplate>
                                    
                                <asp:Label runat="server"  ID="lblTotalQuatity"></asp:Label>
                                                        
                                   </FooterTemplate>
                                                
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="DW" DataField="Format" DataType="System.Int32" UniqueName="Format"  HeaderStyle-Width="250" ItemStyle-Width="250">
                                    <ItemTemplate>
                               
                                         <asp:Label runat="server" Text='<%#Eval("Format").ToString() %>' ID="lblFormat"></asp:Label>
                                                      
                                               
                               
                                    </ItemTemplate>
                                  <FooterTemplate>
                                                       
                                               
                                                       <asp:Label runat="server"  ID="lblTotalPackFormat"></asp:Label>
                            
                                                 </FooterTemplate>
                           
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
          
                     
                   
                          <p>CRV:<asp:TextBox ID="txtCRVNo" runat="server" Enabled="false" ></asp:TextBox>
                                </p>  
                     <asp:LinkButton style="float:right;margin-right:50px;margin-top:0px;" ForeColor="Blue" Font-Bold="true" Font-Size="Large" runat="server" ID="lbtnPRint" OnClick="lbtnPRint_Click" >Print</asp:LinkButton>           
           
                    <div class="clear"></div>

                   <telerik:RadGrid ID="rgdCRV" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" OnItemCreated="rgdCRV_ItemCreated"  > 
         
                    <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="none" > 
              
                        <Columns> 
                   
                    
                           <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex+1%>
                                                        <asp:HiddenField ID="hdnSID" runat="server" Value='<%#Eval("CatID") %>' />
                         <asp:HiddenField ID="hdnLevel" runat="server" Value='<%#Eval("SupplierId") %>' />
                        
                                        </div>
                                    </ItemTemplate>                    
                            
                                </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn   HeaderText="AT/SO No" DataField="ATNo" DataType="System.String" UniqueName="ATNo">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("ATNo") %>' runat="server" ID="lblBatchID" Visible="false"></asp:Label>
                              
                                           <%-- <%# (Eval("ATNo").ToString()==""? "Supply Order NO:":"AT NO:")%>--%>
                                           
                                        
                                           <asp:Label runat="server" ID="nn" Text='<%#Eval("ATSONo") %>' Style="height:100%;width:55px;word-wrap:break-word;display:block"></asp:Label>
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
                          <FooterTemplate>
                              
                          </FooterTemplate>
                                </telerik:GridTemplateColumn>
                          <telerik:GridTemplateColumn Visible="false"  HeaderText="Packaging Material " DataField="AU" DataType="System.String" UniqueName="AU">
                                    <ItemTemplate>
                                       <%#(Eval("PackingMaterial").ToString()==""?"":Eval("PackingMaterial") )%><%#(Eval("PackingMaterialFormat").ToString()==""?"":"["+ Eval("PackingMaterialFormat")+"]")%>
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Batch(s)" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                                    <ItemTemplate>
                                              
                                        <telerik:RadGrid  ID="rgdCRVBatch" runat="server"
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
                                          </ItemTemplate>
                                </telerik:GridTemplateColumn>
                             <%-- <telerik:GridTemplateColumn  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                    <ItemTemplate>
                              
                                         <asp:Label runat="server" ID="lblBatchNo" Text='<%#Eval("BatchNo").ToString()%>'></asp:Label>
                                
                            
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>--%>
                        
                             <telerik:GridTemplateColumn  HeaderText="Packaging" DataField="Format" DataType="System.String" UniqueName="Format">
                                    <ItemTemplate>
                                      
                                           <asp:Label Style="width:70px;word-wrap:break-word;display:block" runat="server" ID="lblFormat" Text='<%#Eval("PackagingType")+": "+Eval("Format").ToString()%>'></asp:Label>
                                
                                    </ItemTemplate>
                         <FooterTemplate>
                              Total Quantity:
                                                       <asp:Label runat="server"  ID="lblTotalQuatity"></asp:Label>
                                                              
                         </FooterTemplate>
                                </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn   HeaderText="Quantity" DataField="RemainingQty" DataType="System.String" UniqueName="BatchNo">
                                    <ItemTemplate>
                                       
                                         <asp:Label runat="server" ID="lblRemainingQty" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("RemainingQty")),3)%>'></asp:Label>
                                
                                    </ItemTemplate>
                         <FooterTemplate>
                               Full Packaging:
                                    <asp:Label runat="server"  ID="lblTotalFullFormat"></asp:Label>
                            
                         </FooterTemplate>
                                </telerik:GridTemplateColumn>


                      
                                <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate">
                                    <ItemTemplate>
                                    <asp:Label Style="width:63px;word-wrap:break-word;display:block" runat="server" ID="lblMFGDate" Text='<%#Eval("MFGDate").ToString()%>'></asp:Label>
                                
                               
                                    </ItemTemplate>
                           <FooterTemplate>
                               Loose Packaging:
                                    <asp:Label runat="server"  ID="lblTotalLooseFormat"></asp:Label>
                            
                           </FooterTemplate>
                                </telerik:GridTemplateColumn>
                        
                                 <telerik:GridTemplateColumn HeaderText="ESL" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                    <ItemTemplate>
                                          <asp:Label Style="width:63px;word-wrap:break-word;display:block" runat="server" ID="lblEsl" Text='<%#Eval("Esl").ToString()%>'></asp:Label>
                             
                            
                               
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                   
                             <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                    <ItemTemplate>
                                         <asp:Label Style="width:63px;word-wrap:break-word;display:block" runat="server" ID="lblEXPDate" Text='<%#Eval("EXPDate").ToString()%>'></asp:Label>
                             
                                         
                                    </ItemTemplate>
                             
                                </telerik:GridTemplateColumn>
                  

                     
                         <telerik:GridTemplateColumn  HeaderText="Cost " DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                    <ItemTemplate>
                                        
                                           <asp:Label Visible="false" runat="server" ID="lblCost" Text='<%#Eval("Cost") %>'></asp:Label>
                                         <asp:Label runat="server" ID="lblCostAU" Text='<%#(Eval("CostOfParticular").ToString()==""?"": Eval("CostOfParticular").ToString() +" per "+AU)%>'></asp:Label>

                             
                                  
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn> 
                            
                             <telerik:GridTemplateColumn  HeaderText="Weight" DataField="Weight" DataType="System.Double" UniqueName="Weight">
                                    <ItemTemplate>
                                      
                                      
                                           <asp:Label  runat="server" ID="lblWeight" Text='  <%#(Eval("Weight").ToString()==""?"": TruncateDecimalToString(Convert.ToDouble(Eval("Weight").ToString()),3)+" "+Eval("WeightUnit") )%>'></asp:Label>
                             
                                    <asp:Label Visible="false" runat="server" ID="lblWeightAU" Text='  <%#(Eval("WeightofParticular").ToString()==""?"": TruncateDecimalToString(Convert.ToDouble(Eval("WeightofParticular").ToString()),3)+" "+Eval("WeightUnit") +" per "+AU )%>'></asp:Label>
                             
                                        
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn> 

                     
                            <telerik:GridTemplateColumn HeaderText="Vehicle">

                                <ItemTemplate>
                                                            <telerik:RadGrid  ID="rdsVehicleList" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" >
         
                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" > 
              
                         <GroupByExpressions>
                                 <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderValueSeparator=":" SortOrder="None" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderText="." />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                          <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="VehicleNo" HeaderValueSeparator=":" SortOrder="None" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="VehicleNo" HeaderText="Vehicle No" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression> <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="DriverName" HeaderValueSeparator=":" SortOrder="None" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="DriverName" HeaderText="Driver Name" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                        <Columns> 
                   
                    
                  
                             <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="Id">
                                    <ItemTemplate>
                                        <%#Eval("Id") %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn  HeaderText="" DataField="DriverName" DataType="System.String" UniqueName="DriverName">
                                    <ItemTemplate>
                                       <%-- <%#Eval("DriverName") %>--%>
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="" DataField="VehicleNo" DataType="System.String" UniqueName="VehicleNo">
                                    <ItemTemplate>
                                        <%-- <%#Eval("VehicleNo").ToString() %>   --%>                    
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex+1%>
                                        </div>
                                    </ItemTemplate>
                      
                                </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Challan No" DataField="ChallanNo" DataType="System.String" UniqueName="ChallanNo">
                                    <ItemTemplate>
                                      <%#Eval("ChallanNo").ToString() %>                      
                               
                                    </ItemTemplate>
                                   
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="Bacth No" DataField="StockBatchId" DataType="System.Int32" UniqueName="StockBatchId">
                                    <ItemTemplate>
                                         <%#Eval("BatchNo").ToString() %>                       
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                              
                           
                              <telerik:GridTemplateColumn HeaderText="Sent Qty" DataField="SentQty" DataType="System.Int32" UniqueName="SentQty">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("SentQty")),3) %>' ID="leeebl"></asp:Label>
                                                        
                               
                                    </ItemTemplate>
                          <FooterTemplate>
                             <asp:Label ID="lblQtySent" runat="server"></asp:Label>
                          </FooterTemplate>
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="Recieved Qty" DataField="RecievedQty" DataType="System.Int32" UniqueName="RecievedQty">
                                    <ItemTemplate>
                                      <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("RecievedQty")),3) %>' ID="lsssbl"></asp:Label>
                                      
                                    </ItemTemplate>
                             <FooterTemplate>
                             <asp:Label ID="lblQtyRec" runat="server"></asp:Label>
                          </FooterTemplate>
                                </telerik:GridTemplateColumn>
                     
                  

                        </Columns> 

                    

                
                    </MasterTableView> 
                </telerik:RadGrid>
               <asp:Label runat="server" ID="lblthisFormatQty" Visible="false"></asp:Label>
             <br />
                                           <asp:Label runat="server" ID="lblthisFullQty" Visible="false"></asp:Label>
           
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        
                  

                        </Columns> 

                         <FooterStyle HorizontalAlign="Left" />
               
                    </MasterTableView> 
                </telerik:RadGrid>
                                                      
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
                            
                           


                      
                              <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Style="width:63px;word-wrap:break-word;display:block" Text='<%#Eval("MFGDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("MFGDate")).ToString("dd-MM-yyyy") %>'></asp:Label>
                            
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="ESL" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                    <ItemTemplate>
                                         <asp:Label Style="width:63px;word-wrap:break-word;display:block" runat="server" ID="lblEsl" Text='<%#Eval("Esl").ToString()==""?"N/A":Convert.ToDateTime(Eval("Esl")).ToString("MMM-yyyy")%>'></asp:Label>
                             
                            
                               
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                   
                             <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                    <ItemTemplate>
                                       <asp:Label Style="width:63px;word-wrap:break-word;display:block" runat="server" ID="lblEXPDate" Text='  <%#Eval("EXPDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("EXPDate")).ToString("dd-MM-yyyy")%>    '></asp:Label>
                             
                                         
                                    </ItemTemplate>
                             
                                </telerik:GridTemplateColumn>
                  

                     
                         <telerik:GridTemplateColumn  HeaderText="Cost " DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                    <ItemTemplate>
                                        
                                                 <asp:Label runat="server" ID="lblCostAU" Text='<%#(Eval("CostOfParticular").ToString()==""?"": Eval("CostOfParticular").ToString() +" per "+AU)%>'></asp:Label>

                             
                                  
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn> 
                            
                          
                                <telerik:GridTemplateColumn  HeaderText="Weight" DataField="Weight" DataType="System.Double" UniqueName="Weight">
                                    <ItemTemplate>
                                      
                                      
                                           <asp:Label  runat="server" ID="lblWeight" Text='  <%#(Eval("Weight").ToString()==""?"":TruncateDecimalToString(Convert.ToDouble(Eval("Weight").ToString()),3)+" "+Eval("WeightUnit") )%>'></asp:Label>
                             
                                    <asp:Label Visible="false" runat="server" ID="lblWeightAU" Text='  <%#(Eval("WeightofParticular").ToString()==""?"": TruncateDecimalToString(Convert.ToDouble(Eval("WeightofParticular").ToString()),3)+" "+Eval("WeightUnit") +" per "+AU )%>'></asp:Label>
                             
                                        
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn> 
                        
                     
                            <telerik:GridTemplateColumn HeaderText="Vehicle">

                                <ItemTemplate>
                                                            <telerik:RadGrid  ID="rdsVehicleList" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" >
         
                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" > 
              
                         <GroupByExpressions>
                                 <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderValueSeparator=":" SortOrder="None" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderText="." />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                          <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="VehicleNo" HeaderValueSeparator=":" SortOrder="None" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="VehicleNo" HeaderText="Vehicle No" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression> <telerik:GridGroupByExpression>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="DriverName" HeaderValueSeparator=":" SortOrder="None" />
                                    </GroupByFields>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldName="DriverName" HeaderText="Driver Name" />
                                    </SelectFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                        <Columns> 
                   
                    
                  
                             <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="Id">
                                    <ItemTemplate>
                                        <%#Eval("Id") %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn  HeaderText="" DataField="DriverName" DataType="System.String" UniqueName="DriverName">
                                    <ItemTemplate>
                                       <%-- <%#Eval("DriverName") %>--%>
                                    </ItemTemplate>
                            
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="" DataField="VehicleNo" DataType="System.String" UniqueName="VehicleNo">
                                    <ItemTemplate>
                                        <%-- <%#Eval("VehicleNo").ToString() %>   --%>                    
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex+1%>
                                        </div>
                                    </ItemTemplate>
                      
                                </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Challan No" DataField="ChallanNo" DataType="System.String" UniqueName="ChallanNo">
                                    <ItemTemplate>
                                      <%#Eval("ChallanNo").ToString() %>                      
                               
                                    </ItemTemplate>
                                   
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="Bacth No" DataField="StockBatchId" DataType="System.Int32" UniqueName="StockBatchId">
                                    <ItemTemplate>
                                         <%#Eval("BatchNo").ToString() %>                       
                               
                                    </ItemTemplate>
                           
                                </telerik:GridTemplateColumn>
                              
                           
                              <telerik:GridTemplateColumn HeaderText="Sent Qty" DataField="SentQty" DataType="System.Int32" UniqueName="SentQty">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("SentQty")),3) %>' ID="leeebl"></asp:Label>
                                                        
                               
                                    </ItemTemplate>
                          <FooterTemplate>
                             <asp:Label ID="lblQtySent" runat="server"></asp:Label>
                          </FooterTemplate>
                                </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="Recieved Qty" DataField="RecievedQty" DataType="System.Int32" UniqueName="RecievedQty">
                                    <ItemTemplate>
                                      <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("RecievedQty")),3) %>' ID="lsssbl"></asp:Label>
                                      
                                    </ItemTemplate>
                             <FooterTemplate>
                             <asp:Label ID="lblQtyRec" runat="server"></asp:Label>
                          </FooterTemplate>
                                </telerik:GridTemplateColumn>
                     
                  

                        </Columns> 

                    

                
                    </MasterTableView> 
                </telerik:RadGrid>
            
                                           <asp:Label runat="server" ID="lblthisFullQty" Visible="false"></asp:Label>
           
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        
                  

                        </Columns> 

                         <FooterStyle HorizontalAlign="Left" />
               
                    </MasterTableView> 
                </telerik:RadGrid>
                                   
                                        <asp:Label runat="server" ID="lblProductQty"></asp:Label>
                                         </ItemTemplate>
                                                 <FooterTemplate>
                                                  <asp:Label runat="server" ID="lblTotalQty" style="float:left" ></asp:Label>
                                                     <asp:Label runat="server" ID="lblTotalWeight" style="float:right" ></asp:Label>
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
                              <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.Int32" UniqueName="Remarks">
                                    <ItemTemplate>
                               
                                         <asp:Label runat="server" Text='<%#Eval("Remarks").ToString() %>' ID="lblFormat" Style="height:100%;width:55px;word-wrap:break-word;display:block"></asp:Label>
                                                      
                                               
                               
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
           <%-- </div>
    </div>--%>
    </form>
</body>
</html>
