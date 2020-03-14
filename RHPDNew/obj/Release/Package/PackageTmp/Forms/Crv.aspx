<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="Crv.aspx.cs" Inherits="RHPDNew.Forms.Crvpx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
    <style type="text/css">
    .modalBackground
{
background-color: Gray;
filter: alpha(opacity=80);
opacity: 0.8;
z-index: 10000;
}  

Table{border:solid 1px #df5015;}
.th{color:#FFFFFF;border-right-color:#abb079;border-bottom-color:#abb079;padding:0.5em 0.5em 0.5em 0.5em;text-align:center}
.td{border-bottom-color:#f0f2da;border-right-color:#f0f2da;padding:0.5em 0.5em 0.5em 0.5em;}
.tr{color: Black; background-color: White; text-align:left}
:link,:visited { color: #DF4F13; text-decoration:none }

        </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="heading-bg">
        <div class="container">
            <h1>CRV</h1>
        </div>
    </div>
    <div>
             <p>&nbsp;</p>
           <div style="float:right;margin-right:20%;">
              <asp:Label ID="lblCode" runat="server" style="font-family:'Times New Roman';font-size:large;"></asp:Label>
           </div>   <p>&nbsp;</p>
        
            <div class="clearfix"></div>

            <div class="container">

                 <div class="row">
                    <div class="form-group-2">
                            <asp:ValidationSummary id="valSum" ValidationGroup="grp"
                             DisplayMode="SingleParagraph"
                             EnableClientScript="true"
                             HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                             runat="server"/>
                        </div>
                      </div>

                <div class="row">
                    <div class="form-group-2">
                    
                         <label class="col-lg-2">Date from:</label>
                         <asp:TextBox ID="txtDatefrom" CssClass="col-lg-4 form-control" placeholder="Click on textbox"  runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                        <asp:CalendarExtender ID="cetxMfgDate" Format="dd MMM yyyy" TargetControlID="txtDatefrom" runat="server"></asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="rfvtxtunitDesc" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDatefrom"></asp:RequiredFieldValidator>
  
                        </div>
                      </div>

                <div class="row">
                    <div class="form-group-2">
                       <label class="col-lg-2">Date to:</label>
                       <asp:TextBox ID="txtDateto" CssClass="col-lg-4 form-control" placeholder="Click on textbox"  runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtender1" Format="dd MMM yyyy" TargetControlID="txtDateto" runat="server"></asp:CalendarExtender>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDateto"></asp:RequiredFieldValidator>
  
                    </div>
                  </div>

                    <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="form-group-2 col-lg-4 text-align-right">   
              <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit"  OnClick="btnSubmit_Click"  />
                         <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false"  /><br /> 
                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                      </div>
                    </div>

                    </div>

                <telerik:RadGrid runat="server" ID="radCrvp" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20">
                    <MasterTableView DataKeyNames="BID" Caption="Crv List"   AllowAutomaticUpdates="false"   CommandItemDisplay="Top" Font-Names="Arial" Font-Size="8">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                         <CommandItemTemplate>
                          <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                        </CommandItemTemplate>
                        <Columns>
                        
                            <telerik:GridTemplateColumn HeaderText="S No." AllowFiltering="false">
                                <ItemTemplate>
                                    <div class="" style="float:left;">
                                        <%#Container.DataSetIndex+1%>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                             <telerik:GridTemplateColumn HeaderText="Received From" DataField="RecievedFromname" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("RecievedFromname").ToString()==""?"N/A":Eval("RecievedFromname")%>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                              <telerik:GridTemplateColumn HeaderText="Vehicle No" DataField="VechicleNo" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("VechicleNo").ToString()==""?"N/A":Eval("VechicleNo")%>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                              <telerik:GridTemplateColumn HeaderText="Batch NO" DataField="BatchNo" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                     <div class="">
                                        <%#Eval("BatchNo").ToString()==""?"N/A":Eval("BatchNo") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                               <telerik:GridTemplateColumn HeaderText="At No" DataField="atnodate" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("atnodate").ToString()==""?"N/A":Eval("atnodate") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                             <telerik:GridTemplateColumn HeaderText="Product Name" DataField="ProductName" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("ProductName").ToString()==""?"N/A":Eval("ProductName") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                              <telerik:GridTemplateColumn HeaderText="A/U" DataField="QuantityTypeNAME" DataType="System.String" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("QuantityTypeNAME").ToString()==""?"N/A":Eval("QuantityTypeNAME") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                              <telerik:GridTemplateColumn HeaderText="Qty" DataField="Quantity" DataType="System.Decimal" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("Quantity").ToString()==""?"N/A":Eval("Quantity") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            
                             <telerik:GridTemplateColumn HeaderText="DOM" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("MFGDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("MFGDate")).ToString("dd MMM yyyy") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                             <telerik:GridTemplateColumn HeaderText="ESL Date" AllowFiltering="false" >
                                <ItemTemplate>
                                   <div class="">
                                        <%#Eval("ESLDATE").ToString()==""?"N/A":Convert.ToDateTime(Eval("ESLDATE")).ToString("dd MMM yyyy") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <%-- <telerik:GridTemplateColumn HeaderText="ProductStatus" AllowFiltering="false" >
                                <ItemTemplate>
                                   <div class="">
                                       <asp:Label id="test" runat="server" Text=' <%#Eval("ProductStatus").ToString()==""?"N/A":Eval("ProductStatus") %>'></asp:Label>
                                     
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>


                          <%--   <telerik:GridTemplateColumn HeaderText="Date Of Reciept" DataField="AddedOn" DataType="System.String" UniqueName="AddedOn" Groupable="false">
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("dateofreceipt").ToString()==""?"N/A":Convert.ToDateTime(Eval("dateofreceipt")).ToString("dd MMM yyyy") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="CRV" DataField="BatchCode" DataType="System.String" UniqueName="BatchCode" Groupable="false">
                                <ItemTemplate>
                                    <div style="text-transform:capitalize;">
                                        <%#Eval("crvno").ToString()==""?"N/A":Eval("crvno") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn HeaderText="EXP Date" AllowFiltering="false" >
                                <ItemTemplate>
                                   <div class="">
                                        <%#Eval("EXPDate").ToString()==""?"N/A":Convert.ToDateTime(Eval("EXPDate")).ToString("dd MMM yyyy") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                             <telerik:GridTemplateColumn HeaderText="ProductStatus" AllowFiltering="false" >
                                <ItemTemplate>
                                   <div class="">
                                       <asp:Label id="test" runat="server" Text=' <%#Eval("ProductStatus").ToString()==""?"N/A":Eval("ProductStatus") %>'></asp:Label>
                                     
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>

                        </Columns>
                    </MasterTableView>

                </telerik:RadGrid>
         </div>

         <%--     <div class="row">
                    <div class="form-group-2">
                       <label class="col-lg-6">Received and Credited in Lub 'B' Gp vide DS No:</label>
                    </div>
                  </div>--%>

</asp:Content>
