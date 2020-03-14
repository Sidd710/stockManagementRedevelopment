<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="frmLPCP.aspx.cs" Inherits="RHPDNew.Forms.frmLPCP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/chosen.jquery.min.js"></script>
  <style>
            body{background:url(../assets/images/flag.jpg) no-repeat;background-size:cover;}

            .RadGrid_Metro .rgHeader {
    color: #e3e3e3 !Important;
}
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <asp:UpdateProgress ID="UpdateProgress7" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updPacking">
            <ProgressTemplate>                
                <div class="full-pop-up">
              <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left:0%" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
                                   <asp:UpdatePanel runat="server" ID="updPacking">
                                      <ContentTemplate>

     
    
    <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Introduce Local Procrument or Centarl Purchase</h1>
            </div>
        </div>
         <br />
         <br />
   
    <div class="container-fluid form-outer">
        <div class="row">      
        <div class="clear"></div>
          <table style="width:100%;">                      
                                        <tr>
                                           
                                            <td style="width:291px">               
<asp:RadioButtonList TabIndex="2" ID="rbATNoSupNo" runat="server" RepeatDirection="Horizontal"
 style="width:296px" >
                                        <asp:ListItem Text="AT No" Value="1" Selected="True"></asp:ListItem>
                                         <asp:ListItem Text="Supply Order No" Value="2"></asp:ListItem>

  </asp:RadioButtonList>  </td>
                                            <td colspan="3">
                                                
                                    
                                                       <asp:TextBox style="width:100%"  CssClass="form-control"  runat="server" ID="txtATSONo" ></asp:TextBox>
                                        
                                                <asp:RequiredFieldValidator ID="dafafasd" ValidationGroup="bgrp" runat="server" Text="*" ErrorMessage="AT/SO No," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtTenderDate"></asp:RequiredFieldValidator>

                                                
                                                  </td>
                                            </tr>
              
              <tr>
                  <td style="width:291px">
                      <label class="form_text">* Supplier:</label><asp:DropDownList  CssClass="form-control"   OnDataBound="ddlSupplier_DataBound" ID="ddlSupplier" runat="server"  DataTextField="Name" DataValueField="Id" ></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="sdsd" ValidationGroup="bgrp" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" SetFocusOnError="true"
                                 ControlToValidate="ddlSupplier" InitialValue="0"></asp:RequiredFieldValidator>
                      
                  </td>
                   <td style="width:291px"> <label class="form_text"> Supplier Contact:</label><asp:TextBox  CssClass="form-control"  runat="server" ID="txtContact" ></asp:TextBox>
                                
                  </td>
                   <td style="width:291px"> <label class="form_text"> * Tender Date:</label>
                       <telerik:RadDatePicker  CssClass="form-control"  Culture="en-US" RenderMode="Lightweight" ID="txtTenderDate" runat="server" DateInput-DateFormat="dd-MM-yyyy" >
        </telerik:RadDatePicker>
                                         <asp:RequiredFieldValidator ID="ered" ValidationGroup="bgrp" runat="server" Text="*" ErrorMessage="Tender Date," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtTenderDate"></asp:RequiredFieldValidator>

                                  

                  </td>
                   <td style="width:291px">
                       <label class="form_text"> * LD%:</label><telerik:RadNumericTextBox  CssClass="form-control"  MinValue="0"  NumberFormat-DecimalDigits="2"  Width="50"   runat="server" ID="txtLD"></telerik:RadNumericTextBox>
                              <asp:RequiredFieldValidator ID="dfds" ValidationGroup="bgrp" runat="server" Text="*"  ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtLD"></asp:RequiredFieldValidator>

                  </td>
              </tr>
                                        
                                    </table> 
                               
                      <asp:HiddenField runat="server" ID="hdnID" />
                     
                          <telerik:RadGrid ID="rgdBatch" runat="server"
                              GridLines="None" AutoGenerateColumns="False"
                              Width="100%"  Skin="Metro" ShowFooter="true" OnItemCommand="rgdBatch_ItemCommand" AllowAutomaticUpdates="false" AllowAutomaticDeletes="false" AllowAutomaticInserts="false" > 
         
                    <MasterTableView DataKeyNames="ID" GridLines="None" Width="100%" CommandItemDisplay="none" AllowAutomaticUpdates="false" AllowAutomaticInserts="false" AllowAutomaticDeletes="false"> 
                     
                        <Columns> 
                   
                    
                           <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                    <ItemTemplate>
                                        <div class="">
                                            <%#Container.DataSetIndex + 1%>
                                        </div>
                                    </ItemTemplate>
                               <FooterTemplate>
                           
                                     <asp:ValidationSummary ID="vsBatch" ValidationGroup="bgrp"
                                DisplayMode="SingleParagraph"
                                EnableClientScript="true"
                                HeaderText="(*) indicates fields are required!"
                                runat="server" />
                               </FooterTemplate>
                                </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn Visible="false"  HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="BID">
                                    <ItemTemplate>
                                        <%#Eval("ID")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn  HeaderText="Product" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                    <ItemTemplate>
                                        <%#Eval("ProductMaster.Product_Name")%>
                                    </ItemTemplate>
                                    <FooterTemplate>    <br />

                                       <asp:DropDownList  CssClass="form-control"   OnDataBound="ddlBatch_DataBound" ID="ddlProduct" runat="server"  DataTextField="Product_Name" DataValueField="Product_ID" style="width:100px"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFissssseldValidator9" ValidationGroup="bgrp" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                 ControlToValidate="ddlProduct" InitialValue="0"></asp:RequiredFieldValidator>
                                       
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn  HeaderText="Quantity" DataField="Cost" DataType="System.Double" UniqueName="Quantity">
                                    <ItemTemplate>
                                        <%#Convert.ToDecimal(Eval("Quantity").ToString()).ToString("0.000")%>
                                    </ItemTemplate>
                                    <FooterTemplate>    <br />

                                        <telerik:RadNumericTextBox AutoPostBack="true" OnTextChanged="txtRate_TextChanged"  CssClass="form-control"  Width="140" EmptyMessage="Quantity"  runat="server" ID="txtQuantity" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                        <asp:RequiredFieldValidator ID="Requircost" ValidationGroup="bgrp" runat="server" Text="*" ErrorMessage="Quantity," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtQuantity"></asp:RequiredFieldValidator>

                                                  </FooterTemplate>
                                </telerik:GridTemplateColumn> 
                              <telerik:GridTemplateColumn  HeaderText="Original Manufacture" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                    <ItemTemplate>
                                        <%#Eval("OriginalManufacture_.Name")%>
                                    </ItemTemplate>
                                    <FooterTemplate>    <br />

                                       <asp:DropDownList  CssClass="form-control"   OnDataBound="ddlWarehouse_DataBound" ID="ddlOM" runat="server"  DataTextField="Name" DataValueField="Id" style="width:100px"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="llulj" ValidationGroup="bgrp" runat="server" ErrorMessage="Original Manufacture," ForeColor="Red" SetFocusOnError="true"
                                 ControlToValidate="ddlOM" InitialValue="0"></asp:RequiredFieldValidator>
                                       
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Delivery DateTime" DataField="DeliveryDate" DataType="System.DateTime" UniqueName="DeliveryDate">
                                    <ItemTemplate>
                                         <%#Convert.ToDateTime(Eval("DeliveryDate").ToString()).ToString("dd-MM-yyyy hh:mm tt")%>                            
                               
                                    </ItemTemplate>
                                    <FooterTemplate>
                                          <br />

                                         <telerik:RadDateTimePicker  CssClass="form-control"  Culture="en-US" RenderMode="Lightweight" ID="txtDeliveryDate" runat="server" DateInput-DateFormat="dd-MM-yyyy hh:mm tt" >
        </telerik:RadDateTimePicker>
                                         <asp:RequiredFieldValidator ID="ered" ValidationGroup="bgrp" runat="server" Text="*" ErrorMessage="Delivery Date," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDeliveryDate"></asp:RequiredFieldValidator>

                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn  HeaderText="Rate" DataField="Rate" DataType="System.String" UniqueName="Rate">
                                    <ItemTemplate>
                                       
                                          <%#Convert.ToDecimal(Eval("Rate").ToString()).ToString("0.000")%>
                                    </ItemTemplate>
                                    <FooterTemplate>    <br />

                                        <telerik:RadNumericTextBox AutoPostBack="true" OnTextChanged="txtRate_TextChanged" MinValue="0" EmptyMessage="Rate" NumberFormat-DecimalDigits="2"    CssClass="form-control" runat="server" ID="txtRate"></telerik:RadNumericTextBox>
                              <asp:RequiredFieldValidator ID="dfds" ValidationGroup="bgrp" runat="server" Text="*" ErrorMessage="Rate," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtRate"></asp:RequiredFieldValidator>
 </FooterTemplate>
                                </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn  HeaderText="Value" DataField="Value" DataType="System.Double" UniqueName="Value">
                                    <ItemTemplate>
                                        
                                          <%#Convert.ToDecimal(Eval("Value").ToString()).ToString("0.000")%>
                                    </ItemTemplate>
                                    <FooterTemplate>                                        <asp:Label ForeColor="Blue" runat="server" ID="lblTotalValue" ></asp:Label><br />
                                        <telerik:RadNumericTextBox Enabled="false"  CssClass="form-control"  Width="140" EmptyMessage="Value"  runat="server" ID="txtValue" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                        <asp:RequiredFieldValidator ID="txtsxValue" ValidationGroup="bgrp" runat="server" Text="*" ErrorMessage="Value," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtValue"></asp:RequiredFieldValidator>
                                    
                                                  </FooterTemplate>
                                </telerik:GridTemplateColumn> 
                                 
                           
                                
                             <telerik:GridTemplateColumn HeaderText="Action">
                                     <ItemTemplate>
                                          <asp:LinkButton ID="btnEditBatch" runat="server" CausesValidation="false" Text="Edit" CommandName="EditA" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                           |<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" Text="Delete" CommandName="DeleteA" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                     </ItemTemplate>
                                     <FooterTemplate>
                                         <asp:Button runat="server" ID="btnSubmitBatch" Text="Add" ValidationGroup="bgrp" OnClick="btnSubmitBatch_Click" />
                                    <asp:Button runat="server" ID="btnCancel" Text="Clear"  OnClick="btnCancel_Click" />
                                  </FooterTemplate>
                                 </telerik:GridTemplateColumn>
                  

                        </Columns> 

                         <FooterStyle HorizontalAlign="Left" />
               
                    </MasterTableView> 
                </telerik:RadGrid>


                   
                <div class="col-md-12 text-align-center marginbottom20">
                     <asp:Label Text="" ID="lblErrorBatch" runat="server" ForeColor="Red" ></asp:Label>
            <br />
            
               <asp:Button Style="background-color:#6584bc ;" Width="250" Height="30" runat="server" ID="btnSubmitall" Text="Submit"  OnClick="btnSubmitall_Click" />
                      </div>       

                    
                    
       </div>
      
    </div>

</ContentTemplate></asp:UpdatePanel>
       
</asp:Content>
