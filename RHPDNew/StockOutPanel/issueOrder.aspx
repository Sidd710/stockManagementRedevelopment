<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="issueOrder.aspx.cs" Inherits="Demo1.issueOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/StockOutPanel/rhpd.ascx" TagName="rhpdusercontro" TagPrefix="my" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
   <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <style>
table, th, td {
    border: 1px solid black;
    padding: 9px
}


.button-success {
            background: blue; /* this is a green */
             border-radius: 8px;
            text-shadow: 0 2px 2px rgba(0, 0, 0, 0.2);
        }
          </style>
     

      
        
        <div class="heading-bg" align="center" >
        <div class="container">
            <h1  style="background-color:skyblue;color:white">Issue Order</h1>
        </div>
    </div>
        <br />
       <br />

       <table style="width:90%" align="center" class="customers" >

        <tr>
            <td height="50" >
<label class="thicker" style="font-size:large">
   <b> Issue Order No :</b>
</label>
            </td>
             <td height="50">
                 <asp:TextBox ID="txtissueordno" runat="server"  CssClass="col-lg-4 form-control" style="top: 0px;left: 56px; width:50px"   ></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="grp" runat="server" Text="*Required" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtissueordno"></asp:RequiredFieldValidator>
                                      
            </td>
        </tr>
       
      
         <tr>
             <td height="50">
<label class="thicker" style="font-size:large">
  <b> Date of Genration :</b>
</label>
             </td>
              <td height="50">
                     <telerik:RadDatePicker  TabIndex="8" Culture="en-US" RenderMode="Lightweight" ID="txtdateofgenration" Width="250px" Height="28px" runat="server" DateInput-DateFormat="dd-MM-yyyy">
        </telerik:RadDatePicker> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server" Text="*Required" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtdateofgenration"></asp:RequiredFieldValidator>
                                      
       <%-- <asp:TextBox ID="txtdateofgenration" runat="server"  CssClass="col-lg-4 form-control" style="top: 0px;left: 56px; width:50px"   ></asp:TextBox>
              <asp:CalendarExtender ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="txtdateofgenration" runat="server"></asp:CalendarExtender>
                      
    --%>               </td>
         </tr>
       
        <tr>
            <td height="50">

         <label class="thicker" style="font-size:large">
 <b>Authority :</b> 
</label>
            </td>

             <td height="50">
                <asp:TextBox ID="txtAuthority"  runat="server"  CssClass="col-lg-4 form-control" style="top: 0px;left: 56px; width:50px"   ></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="grp" runat="server" Text="*Required" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtAuthority"></asp:RequiredFieldValidator>
                                      
            </td>
        </tr>
      
   
       
        
       
        </table>



   
        <br />
        <br />
        <div>
           
            
                  <asp:GridView ID="grdIssueOrder" runat="server" EmptyDataText="No data found !" CssClass="grdIssueOrderCss"  BorderWidth="2" BorderColor="Black" HeaderStyle-Height="5px"
                        AutoGenerateColumns="false" PagerSettings-Position="Bottom" HeaderStyle-CssClass="FixedHeader" 
                        PagerStyle-Font-Size="35px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="Large"
                        Width="100%"
                       >
            <Columns> 
                <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black" >
                    <ItemTemplate>
                        <asp:Label ID="lblsno" CssClass="lblsno" runat="server" Text='<%#Container.DataItemIndex+1 %>' ItemStyle-HorizontalAlign="Center" > </asp:Label>
                    </ItemTemplate>
                     <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Product Name " ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black" >
                    <ItemTemplate>
                        <asp:Label ID="lblPrdName" runat="server" Text='<%# Eval("product_name") %>' CssClass="lblPrdName">
                        </asp:Label>
                        <div class="hdclass">
                            <asp:HiddenField ID="HiddenField1" runat="server"  Value='<%#Eval("productid")%>' />
                            </div>
                        <%--<asp:Label id="spnhidden" runat="server" style="display:none" CssClass="lblHidden"/>--%>
                    </ItemTemplate>
                     <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="A/U" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lblunit"   runat="server" Text='<%# Eval("productUnit") %>' CssClass="lblunit">
                        </asp:Label>
                     
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Issued Quantity" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black" >
                    <ItemTemplate>
                        <asp:Label ID="lblissueqty"  runat="server" Text='<%#Eval("productUnit").ToString()=="NOS"?Convert.ToDouble(Eval("issueqty")).ToString("0.00"):Convert.ToDouble(Eval("issueqty")).ToString("0.000") %>' CssClass="lblissueqty">
                        </asp:Label>
                        
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>
                 <%--<asp:TemplateField HeaderText="Weight" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black" >
                    <ItemTemplate>
                        <asp:Label ID="lblWeight"  runat="server" Text='<%#Convert.ToDouble(Eval("Weight")).ToString("0.000") %>' CssClass="lblissueqty">
                        </asp:Label>
                        
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Cost" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black" >
                    <ItemTemplate>
                        <asp:Label ID="lblCost"  runat="server" Text='<%#Convert.ToDouble(Eval("Cost")).ToString("0.00") %>' CssClass="lblissueqty">
                        </asp:Label>
                        
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>--%>
            
            </Columns>
            <HeaderStyle CssClass="stm_head" HorizontalAlign="Center" />
            <RowStyle CssClass="stm_dark" />
            <HeaderStyle CssClass="stm_head" />
        </asp:GridView>

            <telerik:RadGrid ID="rgdIssuedList" runat="server"
                      GridLines="None" AutoGenerateColumns="False"
                      Width="97%"  Skin="Office2010Black" ShowFooter="true" OnItemCreated="rgdIssuedList_ItemCreated"> 
         
            <MasterTableView DataKeyNames="id" GridLines="None" Width="100%" CommandItemDisplay="none" > 
                 <GroupByExpressions>
                       <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Quarter" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Quarter" HeaderText="Quarter" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                   <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Depot" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Depot" HeaderText="Depot" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                   <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="ProductName" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="ProductName" HeaderText="Product" />
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

                            
                     <telerik:GridTemplateColumn   HeaderText="Batch No" DataField="ATNo" DataType="System.String" UniqueName="BatchNo">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblBatchName" Text='<%#Eval("BatchName") %>'> </asp:Label>
                                     <asp:Label runat="server" ID="lblAU" Text='<%#Eval("AU") %>' Visible="false"> </asp:Label>
                                                  
                                      
                          
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      
                     <telerik:GridTemplateColumn HeaderText="Full Packing" DataField="FullPack" DataType="System.Int32" UniqueName="FullPack">
                            <ItemTemplate>
                             
                                 <asp:Label runat="server"  ID="lblFullPack"></asp:Label>
                                                      
                                     <asp:Label runat="server"  ID="lblFullPackQty"></asp:Label>
                                                      
                                      
                                
                            </ItemTemplate>
                        
                        </telerik:GridTemplateColumn> 
                           
                        <telerik:GridTemplateColumn HeaderText="Loose/DW/Others Packing" DataField="LoosePack" DataType="System.Int32" UniqueName="LoosePack">
                            <ItemTemplate>
                                   <asp:Label runat="server"  ID="lblLoosePack"></asp:Label>
                           
                                  <asp:Label runat="server"  ID="lblLoosePackQty"></asp:Label>
                                                 
                            </ItemTemplate>
                         
                        </telerik:GridTemplateColumn> 
                           
                          
             
                      
                            <telerik:GridTemplateColumn   HeaderText="Quantity" DataField="Esl" DataType="System.String" UniqueName="Esl">
                            <ItemTemplate>
                                <%#Eval("AU").ToString()=="NOS"?Convert.ToDouble(Eval("issueqty")).ToString("0.00") :Convert.ToDouble(Eval("issueqty")).ToString("0.000")%>
                   
                                     </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn   HeaderText="Cost" DataField="Esl" DataType="System.String" UniqueName="Esl">
                            <ItemTemplate>
                                             <%#(Convert.ToDouble(Eval("CostOfParticular"))*Convert.ToDouble(Eval("issueqty"))).ToString("0.00") %>
                           
                               
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                     
                        
                                      <telerik:GridTemplateColumn   HeaderText="Batch Weight" DataField="Esl" DataType="System.String" UniqueName="Esl">
                            <ItemTemplate>
                                <%#(Convert.ToDouble(Eval("WeightofParticular"))*Convert.ToDouble(Eval("issueqty"))).ToString("0.000") %>
                   
                                     </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                    
              
                       
                            <telerik:GridTemplateColumn  HeaderText="Remarks" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                            <ItemTemplate>
                                 <asp:Label  runat="server" ID="lblRemarks" Text='<%#Eval("Remarks").ToString() %>'> </asp:Label>
                                           
                          
                           
                               
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                    
                </Columns> 
                
                 <FooterStyle HorizontalAlign="left" />
               
            </MasterTableView> 
        </telerik:RadGrid>
                       
   <br />
            <br />
          
             <br />
            <br />
            <div id="bt" align="center">
           
                 <asp:Button  ValidationGroup="grp" ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnsubmit_Click"  />
                </div>
        </div>
</asp:Content>
