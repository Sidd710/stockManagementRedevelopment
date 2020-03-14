<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="frmLPCPList.aspx.cs" Inherits="RHPDNew.Forms.frmLPCPList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="heading-bg">
        <div class="container">
            <h1>LP & CP List</h1>
        </div>
    </div>
    <br />
    <br />
        <style>
            body{background:url(../assets/images/Siachen-3.jpg) no-repeat;background-size:cover;} .RadGrid_Metro .rgHeader {
    color: #e3e3e3 !Important;
}
        </style>
  <%--  <div class="container">
          --%>
   <div class="col-md-12 text-align-center marginbottom20">
                  
                  
                  <script type="text/javascript">
                      function ViewCheck(id) {


                          var url = "LPCPView.aspx?ID=" + id;
                         
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
                                          <table>
                                              <tr>
                                                  <td style="width:40%">
                                                      <table >
                                                          <tr>
                                                              <td> <asp:RadioButtonList   runat="server" ID="rbtnTenderRec" RepeatDirection="Horizontal"  >
                                          
                                               <asp:ListItem Text="Tender" Value="Tender" Selected="True"></asp:ListItem>
                                               <asp:ListItem Text="Receiving" Value="Receiving"></asp:ListItem>
                                         </asp:RadioButtonList></td>
                                                          </tr>
                                                           <tr>
                                                              <td> From:    <telerik:RadDatePicker Width="120"    Culture="en-US" RenderMode="Lightweight" ID="txtFrom" runat="server" DateInput-DateFormat="dd-MM-yyyy" >
        </telerik:RadDatePicker>
                                                                   <asp:RequiredFieldValidator ID="wewerwr" ValidationGroup="grpGO" runat="server" Text="*Required" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtFrom"></asp:RequiredFieldValidator>

                                
                                                 To:     <telerik:RadDatePicker Width="120"    Culture="en-US" RenderMode="Lightweight" ID="txtTo" runat="server" DateInput-DateFormat="dd-MM-yyyy" >
        </telerik:RadDatePicker>
                                                                   <asp:RequiredFieldValidator ID="wrwref" ValidationGroup="grpGO" runat="server" Text="*Required" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtTo"></asp:RequiredFieldValidator>

                                                                  <asp:Button runat="server" ID="btnGo" Text="Go" OnClick="btnGo_Click" ValidationGroup="grpGO"/>
                                                                     <asp:Button runat="server" ID="Button1" Text="Clear" OnClick="Button1_Click" />
                                                              </td>
                                                          </tr>
                                                      </table>
                                                  
                                                 
                                
                                                  </td>
                                                  <td style="width:60%">
                                                      <table >
                                                          <tr>
                                                              <td>
                                                                      <asp:RadioButtonList runat="server" ID="rbtnCPLP" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnCPLP_SelectedIndexChanged">
                                             <asp:ListItem Text="Both" Value="Both" Selected="True"></asp:ListItem>
                                               <asp:ListItem Text="CP" Value="CP"></asp:ListItem>
                                               <asp:ListItem Text="LP" Value="LP"></asp:ListItem>
                                         </asp:RadioButtonList>
                                                              </td>
                                                          </tr>
                                                          <tr>
                                                              <td>
                                                                   <asp:RadioButtonList runat="server" ID="rbtnStatus" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnStatus_SelectedIndexChanged">
                                            <%-- <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
                                               <asp:ListItem Text="Processing" Value="Processing"></asp:ListItem>
                                               <asp:ListItem Text="Late" Value="Late"></asp:ListItem>
                                                   <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                               <asp:ListItem Text="Dispute" Value="Dispute"></asp:ListItem>
                                     --%>    </asp:RadioButtonList>
                                                              </td>
                                                          </tr>
                                                      </table>
                                                  </td>
                                              </tr>
                                          </table>
                                     
                                         
                                           

           <telerik:RadWindowManager ID="RadWindowManager2" runat="server" Width="1300px" Height="600px">
    <Windows>
        <telerik:RadWindow ID="RadWindowDetails" runat="server" Width="1300px" Height="600px">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
                   

                 
                   
        <telerik:RadGrid ID="rgdList" runat="server"
        GridLines="None" AutoGenerateColumns="False"
        Width="100%" EnableAJAX="True" Skin="Metro" ShowFooter="true" AllowFilteringByColumn="true" OnNeedDataSource="rgdCRV_NeedDataSource"  > 
         
            <MasterTableView DataKeyNames="ID" GridLines="None"  CommandItemDisplay="none" > 
              <GroupByExpressions>
                       <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="StatusFinal" HeaderValueSeparator=":" SortOrder="Descending" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="StatusFinal" HeaderText="." />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                   <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="LPCP" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="LPCP" HeaderText="." />
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
                    
                     <telerik:GridTemplateColumn   HeaderText="Product" DataField="Product" DataType="System.String" UniqueName="Product" >
                                    <ItemTemplate>
                                       
                           
                                           <asp:Label runat="server" ID="lblProduct" Text='<%#Eval("Product") %>'></asp:Label>
                                         
                                    </ItemTemplate>
                          
                          
                                </telerik:GridTemplateColumn>
                     
                     <telerik:GridTemplateColumn HeaderText="Quantity" DataField="Quantity" DataType="System.Decimal" UniqueName="Quantity">
                            <ItemTemplate>                              
                                
                                                      
                                       <asp:Label runat="server" ID="lblQuantity" Text='<%#Convert.ToDecimal(Eval("Quantity").ToString())<0?"0":Eval("AU").ToString()=="NOS"?Convert.ToDecimal(Eval("Quantity").ToString()).ToString("0.00"):Convert.ToDecimal(Eval("Quantity").ToString()).ToString("0.000")%>'></asp:Label>         
                               
                            </ItemTemplate>
                        
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn HeaderText="BalanceQty" DataField="BalanceQty" DataType="System.Decimal" UniqueName="BalanceQty">
                            <ItemTemplate>                              
                                
                                                      
                                       <asp:Label runat="server" ID="lblBalanceQty" Text='<%#Convert.ToDecimal(Eval("BalanceQty").ToString())<0?"0":Eval("AU").ToString()=="NOS"?Convert.ToDecimal(Eval("BalanceQty").ToString()).ToString("0.00"):Convert.ToDecimal(Eval("BalanceQty").ToString()).ToString("0.000")%>'></asp:Label>         
                               
                            </ItemTemplate>
                        
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn HeaderText="SppiledQty" DataField="SppiledQty" DataType="System.Decimal" UniqueName="SppiledQty">
                            <ItemTemplate>                              
                                
                                                      
                                       <asp:Label runat="server" ID="lblSppiledQty" Text='<%#Convert.ToDecimal(Eval("SppiledQty").ToString())<0?"0":Eval("AU").ToString()=="NOS"?Convert.ToDecimal(Eval("SppiledQty").ToString()).ToString("0.00"):Convert.ToDecimal(Eval("SppiledQty").ToString()).ToString("0.000")%>'></asp:Label>         
                               
                            </ItemTemplate>
                        
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn HeaderText="Value" DataField="Value" DataType="System.Decimal" UniqueName="Value">
                            <ItemTemplate>                              
                                
                                                      
                                       <asp:Label runat="server" ID="lblValue" Text='<%#Convert.ToDecimal(Eval("Value").ToString()).ToString("0.000")%>'></asp:Label>         
                               
                            </ItemTemplate>
                        
                           
                        </telerik:GridTemplateColumn> 
                       <telerik:GridTemplateColumn HeaderText="LDAmount" DataField="LDAmount" DataType="System.Decimal" UniqueName="LDAmount">
                            <ItemTemplate>                              
                                
                                                      
                                       <asp:Label runat="server" ID="lblLDAmount" Text='<%#Convert.ToDecimal(Eval("LDAmount").ToString())<0?"0":Eval("AU").ToString()=="NOS"?Convert.ToDecimal(Eval("LDAmount").ToString()).ToString("0.00"):Convert.ToDecimal(Eval("LDAmount").ToString()).ToString("0.000")%>'></asp:Label>         
                               
                            </ItemTemplate>
                        
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn HeaderText="StandingAmt" DataField="StandingAmt" DataType="System.Decimal" UniqueName="StandingAmt">
                            <ItemTemplate>                              
                                
                                                      
                                       <asp:Label runat="server" ID="lblStandingAmt" Text='<%#Convert.ToDecimal(Eval("StandingAmt").ToString())<0?"0":Eval("AU").ToString()=="NOS"?Convert.ToDecimal(Eval("StandingAmt").ToString()).ToString("0.00"):Convert.ToDecimal(Eval("StandingAmt").ToString()).ToString("0.000")%>'></asp:Label>         
                               
                            </ItemTemplate>
                        
                           
                        </telerik:GridTemplateColumn> 
                     <telerik:GridTemplateColumn   HeaderText="Action" DataField="Status" DataType="System.String" UniqueName="Status">
                            <ItemTemplate>
                         
                                <asp:Panel Visible='<%#Eval("StatusFinal").ToString()=="Processing"?true:false%>' runat="server" ID="pnlActionP">
                                   
                                    <asp:DropDownList ToolTip='<%#Eval("ID")+"/"+Eval("StatusFinal")%>' OnSelectedIndexChanged="ddlStatusP_SelectedIndexChanged" AutoPostBack="true" runat="server" ID="ddlStatusP">
                                         <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                         <asp:ListItem Text="Late" Value="Spillage"></asp:ListItem>
                                          <asp:ListItem Text="Dispute" Value="Dispute"></asp:ListItem>
                                          <asp:ListItem Text="Others | Complete" Value="Other"></asp:ListItem>                                         
                                         
                                    </asp:DropDownList><br />
                                     <asp:TextBox runat="server" Visible="false" ID="txtRemarksP" placeholder="Remarks..." TextMode="MultiLine"></asp:TextBox>
                                       <asp:RequiredFieldValidator Enabled="false" ID="rqRemarksP" ValidationGroup="grpP" runat="server" Text="*Required" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtRemarksP"></asp:RequiredFieldValidator>

                                    <br /><asp:Button ValidationGroup="grpP" runat="server" ID="btnSubmitP" Text="Submit" CommandName='<%#Eval("StatusFinal")%>' CommandArgument='<%#Eval("ID")%>' OnClick="btnSubmitP_Click"  />
                                </asp:Panel>
                                   <asp:Panel Visible='<%#Eval("StatusFinal").ToString()=="Late"?true:false%>' runat="server" ID="pnlActionL">
                                                                                   <asp:DropDownList ToolTip='<%#Eval("ID")+"/"+Eval("StatusFinal")%>' OnSelectedIndexChanged="ddlStatusP_SelectedIndexChanged" AutoPostBack="true" runat="server" ID="ddlStatusL">  
                                         <asp:ListItem Text="--Select--" Value=""></asp:ListItem>                                      
                                           <asp:ListItem Text="Spillage | Complete" Value="Spillage"></asp:ListItem>
                                                        <asp:ListItem Text="Dispute" Value="Dispute"></asp:ListItem>
                                          <asp:ListItem Text="Others | Complete" Value="Other"></asp:ListItem>
                                    </asp:DropDownList><br />
                                             <asp:TextBox Visible="false" runat="server" ID="txtRemarksL" placeholder="Remarks..." TextMode="MultiLine"></asp:TextBox>
                                          <asp:RequiredFieldValidator Enabled="false" ID="rqRemarksL" ValidationGroup="grpL" runat="server" Text="*Required" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtRemarksL"></asp:RequiredFieldValidator>

                        <br /><asp:Button ValidationGroup="grpL" runat="server" ID="btnSubmitL" Text="Submit" CommandName='<%#Eval("StatusFinal")%>' CommandArgument='<%#Eval("ID")%>' OnClick="btnSubmitP_Click"  />
                                </asp:Panel>


                                <%#Eval("StatusFinal").ToString()=="Completed"?"Completed":""%>
                                        <asp:Label Visible='<%#Eval("StatusFinal").ToString()=="Dispute"?true:false%>' runat="server" Text='<%#Eval("Remarks").ToString() %>' ID="lblFormat"></asp:Label>
                                                      
                                  
                         
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      
                      
                       
                        
                                    
                    
                       
                                    
                     
                     <telerik:GridTemplateColumn HeaderText="Date" DataField="AddedOn" DataType="System.DateTime" UniqueName="AddedOn">
                            <ItemTemplate>
                               
                                 <%#Convert.ToDateTime(Eval("AddedOn")).ToString("dd-MM-yyyy") %>
                                                      
                                               
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
         
                     
                    <telerik:GridHyperLinkColumn ItemStyle-Width="170" AllowFiltering="false" HeaderText="" UniqueName="IDView" DataTextField="ID"
    DataTextFormatString="Show Detail" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="javascript:ViewCheck({0})">
</telerik:GridHyperLinkColumn>
                     
                    
                  

                </Columns> 

                
               



            </MasterTableView> 
        </telerik:RadGrid>
            
                   
            </ContentTemplate></asp:UpdatePanel>
              
             
            </div>

</asp:Content>
