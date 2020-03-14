<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="frmSection.aspx.cs" Inherits="RHPDNew.Forms.frmSection" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>

    
    <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Manage Warehouse Section </h1>
            </div>
        </div>
         <br />
         <br />
    <style>
            body{background:url(../assets/images/flag.jpg) no-repeat;background-size:cover;}
        </style>
    <div class="container-fluid form-outer">
       
        <div class="clear"></div>
        <div class="container forming_texting">
            <div class="row">
                <div class="col-md-12">
                    <asp:ValidationSummary ID="valSum" ValidationGroup="grp"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server" />
                </div>
            </div>
            <div class="row marginbottom10">
                  <div class="col-five">
                    <label class="form_text">Warehouse No:</label>
                   <asp:DropDownList CssClass="form-control" OnDataBound="ddlWarehouse_DataBound" runat="server" ID="ddlWarehouse" DataSourceID="sqlWarehouse" DataTextField="WareHouseNo" DataValueField="ID"></asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="sqlWarehouse" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="select * from tblWarehouse where IsActive=1 order by WareHouseNo"></asp:SqlDataSource>  
                     <asp:RequiredFieldValidator InitialValue="&nbsp;" ID="RequiredFieldValidator3" ValidationGroup="grp" runat="server" ErrorMessage="**" Text="**" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="ddlWarehouse"></asp:RequiredFieldValidator>
               
                       </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Section:</label>
                    <asp:TextBox CssClass="form-control" ID="txtSupplierName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDepuName" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtSupplierName"></asp:RequiredFieldValidator>
                        </div>
                <div class="col-five">
                    <label class="form_text">Sub Section:</label>
                     <asp:TextBox CssClass="form-control" ID="txtSubSec" runat="server"></asp:TextBox>
                    
                              </div>
            </div>
             <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Rows:</label>
                   <telerik:RadNumericTextBox NumberFormat-DecimalDigits="0"  Width="290" Height="30" CssClass="form-control" runat="server" ID="txtRows"></telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtRows"></asp:RequiredFieldValidator>
                   </div>
                <div class="col-five">
                    <label class="form_text">Columns:</label>
                   <telerik:RadNumericTextBox NumberFormat-DecimalDigits="0" Width="290" Height="30" CssClass="form-control" runat="server" ID="txtColumns"></telerik:RadNumericTextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtColumns"></asp:RequiredFieldValidator>
                </div>
            </div>
           
            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 text-align-center marginbottom20">
                    <input type="hidden" id="visiblelblmsg" value="" runat="server" />
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit"  OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" CausesValidation="false" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="true" ForeColor="Green"></asp:Label>
                </div>
                <asp:Label ID="lblresult" runat="server" />
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />

            </div>
        </div>
        <script>
            function confirm() {
                var r = confirm("Press a button");
                if (r == true) {
                    return true;
                } else {
                    return false;
                }
            }
        </script>
        <div class="container">
            <div class="tableDiv">
                
            
            <telerik:RadGrid ID="rgdWareHouse" runat="server"
        GridLines="None" AutoGenerateColumns="False"
        Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" AllowFilteringByColumn="false" OnItemCommand="rgdWareHouse_ItemCommand"  > 
         
            <MasterTableView DataKeyNames="ID" GridLines="None"  CommandItemDisplay="none" > 
              <GroupByExpressions>
                   
                   <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="WareHouseNo" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="WareHouseNo" HeaderText="Warehouse No" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
               
                   
                    <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Section" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Section" HeaderText="Section" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                      <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="SubSection" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="SubSection" HeaderText="Sub Section" />
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
                      <telerik:GridTemplateColumn  HeaderText="Warehouse No" DataField="tblWarehouse.WareHouseN" DataType="System.String" UniqueName="tblWarehouse.WareHouseN">
                            <ItemTemplate>
                               
                                     <asp:Label ID="lblname" runat="server" Text='<%# Eval("WareHouseNo") %>'></asp:Label>
                                   
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                      
                    
                     <telerik:GridTemplateColumn   HeaderText="Section" DataField="Section" DataType="System.String" UniqueName="Section" ><%--HeaderStyle-Width="50" FilterControlWidth="50" ItemStyle-Width="50">--%>
                                    <ItemTemplate>
                                       
                                <asp:Label ID="lblcontact" runat="server" Text='<%# Eval("Section") %>'></asp:Label>
                                      
                                    </ItemTemplate>
                          
                          
                                </telerik:GridTemplateColumn>
                     
                    <telerik:GridTemplateColumn   HeaderText="Sub Section" DataField="IsParent" DataType="System.String" UniqueName="IsParent">
                            <ItemTemplate>
                               <asp:Label ID="lbldesc" runat="server" Text='<%#(Eval("SubSection"))%>'></asp:Label>
                               
                         
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                       <telerik:GridTemplateColumn   HeaderText="Rows" DataField="Row" DataType="System.Double" UniqueName="Row">
                                    <ItemTemplate>                                      
                                               
                                        
                                                   <%#Eval("Row").ToString()%>
                     
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>
                      
                        <telerik:GridTemplateColumn  HeaderText="Columns" DataField="Col" DataType="System.Double" UniqueName="Col">
                            <ItemTemplate>

                                        <%#(Eval("Col").ToString()) %>
                     
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn  HeaderText="Drawers" DataField="Drawers" DataType="System.Double" UniqueName="Drawers">
                            <ItemTemplate>
                                <%#Eval("Drawers") %>
                            </ItemTemplate>
                          
                        </telerik:GridTemplateColumn>
                        
                                    
                                    
                      
           
              

                
                      <telerik:GridTemplateColumn HeaderText="Action" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                            <ItemTemplate>
                               
                                 <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%#Eval("ID") %>' Text="Edit" CommandName="UpdateRecord" /> &nbsp;|&nbsp;
                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>' Text="Delete"  CommandName="DeleteRecord"  />
                        
                                               
                               
                            </ItemTemplate>
                         
                           
                        </telerik:GridTemplateColumn> 
                    
                    
                  

                </Columns> 

                 <FooterStyle HorizontalAlign="left" />
               

    <CommandItemSettings ShowAddNewRecordButton="false" />


            </MasterTableView> 
        </telerik:RadGrid>
            </div>
        </div>
    </div>
</asp:Content>
