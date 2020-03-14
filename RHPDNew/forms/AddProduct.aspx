<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="RHPDNew.Forms.AddProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script src="../js/jquery.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script>
        function name() {
            alert('Product Name is already exists');
        }
    </script>
    
    <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Manage Product</h1>
            </div>
        </div>
         <br />
         <br />
    <style>
            body{background:url(../assets/images/flag.jpg) no-repeat;background-size:cover;}
        </style>


    
    <div class="container-fluid form-outer">
        <div class="container">
            <div class="fright depotCode" style="display:none">
              Code# 
              <b><asp:Label ID="lblCode" runat="server"></asp:Label></b>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="clear"></div>
        <div class="container forming_texting">
              <div class="row">
                <div class="col-md-12">
                    <asp:ValidationSummary id="valSum" ValidationGroup="grp"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server"/>
                </div>
              </div>
              <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Category :</label>
                    <asp:ObjectDataSource ID="odsCategory" runat="server" TypeName="RHPDComponent.AddProductComp" SelectMethod="getrecord"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlselectCat"  OnDataBound="ddlselectCat_DataBound" CssClass="form-control" runat="server" DataSourceID="odsCategory" DataTextField="Category_Name" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlselectCat" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" InitialValue="-- Select --" SetFocusOnError="true" ControlToValidate="ddlselectCat"></asp:RequiredFieldValidator>
                </div>
                <div class="col-five">
                    <label class="form_text">Name :</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="NameTextBox" />
                    <asp:RequiredFieldValidator ID="rfvNameTextBox" runat="server" Text="*"
                        Display="Dynamic" ValidationGroup="grp" ControlToValidate="NameTextBox" ErrorMessage="*"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Full Description : </label>
                    <asp:TextBox runat="server" ID="FullDescriptionTextBox" CssClass="form-control" TextMode="MultiLine" style="resize:none;" Height="50" />
                    <asp:RequiredFieldValidator ID="rfvFullDescriptionTextBox" ForeColor="Red" runat="server" Text="*"
                        Display="Dynamic" ControlToValidate="FullDescriptionTextBox" ErrorMessage="*"
                        ValidationGroup="grp"></asp:RequiredFieldValidator>
                </div>
                <div class="col-five">
                    <label class="form_text">Generic Name :</label>
                    <asp:TextBox runat="server" ID="ShortDescriptionTextBox" CssClass="form-control" TextMode="MultiLine" style="resize:none;" Height="50" />
                    <asp:RequiredFieldValidator ID="rfvShortDescriptionTextBox" ForeColor="Red" runat="server" Text="*"
                        Display="Dynamic" ControlToValidate="ShortDescriptionTextBox" ErrorMessage="*"
                        ValidationGroup="grp"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Admin Comments</label>
           <%--     <div class="form-group-2 col-lg-4 text-align-right padding-0">--%>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtAdminComment" />
                </div>
              <%--  </div>--%>
                <div class="col-five">
                    <label class="form_text">Accounting Unit</label>
                    <asp:DropDownList ID="ddlproductUnit" runat="server" CssClass="form-control">
                       <%-- <asp:ListItem Text="----Select Unit-----" Value="0"></asp:ListItem>--%>
                        <asp:ListItem Text="KGS" Value="KGS"></asp:ListItem>
                        <asp:ListItem Text="LTRS" Value="LTRS"></asp:ListItem>
                        <asp:ListItem Text="NOS" Value="NOS"></asp:ListItem>
                       
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row" style="display:none;">
                <label class="form_text">Cost</label>
                <%--  <div class="form-group-2 col-lg-4 text-align-right padding-0">--%>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtVarientProductCost" MaxLength="15" Text="100" />
                <asp:FilteredTextBoxExtender ID="ftbetxtVarientProductCost" runat="server" FilterType="Custom,Numbers" FilterMode="ValidChars" ValidChars="." TargetControlID="txtVarientProductCost" />
                <asp:RequiredFieldValidator ID="rfvtxtVarientProductCost" ForeColor="Red" runat="server" ControlToValidate="txtVarientProductCost" ErrorMessage="*" ValidationGroup="grp" Text="*"></asp:RequiredFieldValidator>
            <%--     </div>--%>
            </div>

            <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Catpart no./Specification:</label>
                <%--  <div class="form-group-2 col-lg-4 text-align-right padding-0">--%>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtcat"   />
                    <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers" FilterMode="ValidChars" ValidChars="" TargetControlID="txtVarientProductCost" />--%>
                    <asp:RequiredFieldValidator Text="*" ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtcat" ErrorMessage="*" ValidationGroup="grp"></asp:RequiredFieldValidator>
            <%--     </div>--%>
                </div>

                <div class="col-five">
                     <label class="form_text">GS Reserve</label>
                          <telerik:RadNumericTextBox CssClass="form-control" MinValue="0" runat="server" ID="txtGSserve" Height="25"  NumberFormat-DecimalDigits="0" Width="290"></telerik:RadNumericTextBox>
                            
                   
                          </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-five">    <label class="form_text">Maint. Stock</label>
                    
                          <telerik:RadNumericTextBox CssClass="form-control" MinValue="0" runat="server" ID="txtStock" Height="25"  NumberFormat-DecimalDigits="0" Width="290"></telerik:RadNumericTextBox>
                 </div>
                <div class="col-five">   <label class="form_text">Is Active</label><asp:CheckBox ID="chkpublished" CssClass="cssIsActive" Checked="true" runat="server" Text="" />
       </div>
                </div>

            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 text-align-center marginbottom20">
                    <asp:Button ID="btnSubmit" ValidationGroup="grp" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" OnClick="btnClear_Click" ValidationGroup="validation" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="true" ForeColor="Green"></asp:Label>
                </div>
            </div>
            
            <asp:ObjectDataSource ID="objProduct" runat="server" TypeName="RHPDComponent.AddProductComp" SelectMethod="GridDisplayComponent" ></asp:ObjectDataSource>
            <telerik:RadGrid runat="server" DataSourceID="objProduct" ID="rgdProduct" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="RadGrid_ItemCommand">
                <MasterTableView DataKeyNames="Product_Id" Caption="Product List" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="9">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                        <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                        </CommandItemTemplate>
                        <GroupByExpressions>
                            <telerik:GridGroupByExpression>
                                <GroupByFields>
                                    <telerik:GridGroupByField FieldName="Category" HeaderValueSeparator=":" SortOrder="Descending" />
                                </GroupByFields>
                                <SelectFields>
                                    <telerik:GridGroupByField FieldName="Category" HeaderText="Category" />
                                </SelectFields>
                            </telerik:GridGroupByExpression>
                        </GroupByExpressions>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                         <telerik:GridTemplateColumn Visible="false" HeaderText="Code" DataField="Product_Code" DataType="System.String" UniqueName="Product_Code" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("Product_Code")%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Name" DataField="Product_Name" DataType="System.String" UniqueName="Product_Name" Groupable="false">
                            <ItemTemplate>
                                <div style="text-transform:capitalize;">
                                    <%#Eval("Product_Name")%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Description" DataField="Product_Desc" DataType="System.String" UniqueName="Product_Desc" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("Product_Desc")%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Generic Name" DataField="Short_Product_Desc" DataType="System.String" UniqueName="Short_Product_Desc" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("Short_Product_Desc")%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                         <telerik:GridTemplateColumn HeaderText="Unit" DataField="productUnit" DataType="System.String" UniqueName="productUnit" Groupable="false">
                            <ItemTemplate>
                                <div style="text-transform:capitalize;">
                                    <%#Eval("productUnit")%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                         <telerik:GridTemplateColumn HeaderText="Maint. Stock" DataField="Short_Product_Desc" DataType="System.String" UniqueName="Short_Product_Desc" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("StockQty")%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                         <telerik:GridTemplateColumn HeaderText="GS Serve" DataField="Short_Product_Desc" DataType="System.String" UniqueName="Short_Product_Desc" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("GSreservre")%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Admin Remarks" AllowFiltering="false" >
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblusrname" runat="server" Text='<%#Eval("Admin_Remarks") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                          <telerik:GridTemplateColumn HeaderText="Catpart no./Specification" AllowFiltering="false" >
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblcat" runat="server" Text='<%#Eval("Cat") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Cost" AllowFiltering="false" Visible="false" >
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblusrRank" runat="server" Text='<%#Eval("product_cost") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false">
                            <ItemTemplate>
                                <div class="">
                                    <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("Product_ID")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" Text="Edit" CommandName="pEdit" 
                                        CommandArgument='<%# Eval("Product_ID")+"< "+Eval("Product_Name")+"< "+Eval("Product_Desc")+"<"+Eval("Short_Product_Desc")
                                    +"< "+ Eval("IsActive").ToString()+"<"+Eval("Admin_Remarks")+"<"+Eval("product_cost")+"<"+Eval("Product_Code")
                                    +"<"+Eval("Category_Id") +"<"+Eval("Cat")+"<"+Eval("StockQty")+"<"+Eval("GSreservre")+"<"+Eval("productUnit")%>'></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Content>
