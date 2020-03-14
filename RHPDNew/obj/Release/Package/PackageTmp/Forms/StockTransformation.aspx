<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="StockTransformation.aspx.cs" Inherits="RHPDNew.Forms.StockTransformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="heading-bg">
        <div class="container">
            <h1>Stock Transformation</h1>
        </div>
    </div>

    <div id="SelectAssign" runat="server">
        <div class="clearfix"></div>
        <div class="container">
            <p>&nbsp;</p>
            <p>&nbsp;</p>
      
        <div class="row">
            <div class="form-group-2">
                <label class="col-lg-2">Assign Stock to : </label>
                <asp:RadioButtonList ID="rbtnSelect" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtnSelect_SelectedIndexChanged" ValidationGroup="assign">
                    <asp:ListItem Text="Depo Wise" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Unit Wise" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>

        <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Depo Name:</label>
                    <asp:ObjectDataSource ID="odsDepoName" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="getrecord"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlDepoName" OnDataBound="ddlDepoName_DataBound" DataSourceID="odsDepoName" DataTextField="Depu_Name" DataValueField="Depu_Id" AutoPostBack="true"  runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlDepoName" ValidationGroup="assign" runat="server" ErrorMessage="Please Select Depo Name" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlDepoName"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row" id="unit" runat="server" visible="false">
                <div class="form-group-2">
                    <label class="col-lg-2">Unit Master: </label>
                    <asp:DropDownList ID="ddlUnitMaster" DataSourceID="odsUnitMaster" OnDataBound="ddlUnitMaster_DataBound" DataTextField="Unit_Name" DataValueField="Unit_Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="odsUnitMaster" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="GetUnitByDID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlDepoName" PropertyName="SelectedValue" Name="dID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="rfvddlUnitMaster" ValidationGroup="assign" runat="server" ErrorMessage="Please Select Unit Master" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlUnitMaster"></asp:RequiredFieldValidator>

                   <%-- <asp:CustomValidator ID="cvddlUnitMaster" runat="server" ValidationGroup="grp" OnServerValidate="cvddlUnitMaster_ServerValidate" Text="Please select Unit Master" ForeColor="Red" ControlToValidate="ddlUnitMaster"></asp:CustomValidator>--%>

                </div>
            </div>
        <div class="row">
            <div class="form-group-2"></div>
            <div class="form-group-2 col-lg-4 text-align-right">
                <asp:Button ID="btnAssign" CssClass="btn btn-primary" ValidationGroup="assign" runat="server" Text="Select Assign" OnClick="btnAssign_Click" />
                  <asp:Button ID="btnCancelAssign" CssClass="btn btn-warning" runat="server" CausesValidation="false" OnClick="btnCancelAssign_Click" Text="Cancel" />
            </div>
        </div>

    </div>
       </div>


    <div id="Selectdepwise" runat="server" visible="false">
        <div class="clearfix"></div>
        <div class="container">
            <p>&nbsp;</p>
            <p>&nbsp;</p>

            <div class="row">
                <div class="form-group-2">
                    <asp:ValidationSummary ID="valSum" ValidationGroup="grp"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server" />
                </div>
            </div>

            <%--<div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Assign Stock to : </label>
                    <asp:RadioButtonList ID="rbtAssign" Enabled="false" runat="server" ValidationGroup="assign">
                        <asp:ListItem Text="Depo Wise" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Unit Wise" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>--%>

            <%-- <div class="row">
                <div class="form-group-2">
                   <label class="col-lg-2">Type of Order:</label>
                    <asp:ObjectDataSource ID="odsTypeofOrder" runat="server" TypeName="RHPDComponent.AddCategoryComp" SelectMethod="getrecord"></asp:ObjectDataSource>
                   <asp:DropDownList ID="ddlTypeofOrder" DataSourceID="odsDepoName" OnDataBound="ddlTypeofOrder_DataBound" runat="server" CssClass="col-lg-4 form-control" DataTextField="Name" DataValueField="ID">
                   </asp:DropDownList> 
                   <asp:RequiredFieldValidator ID="rfvddlTypeofOrder" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Type of Order" Text="Please Select Type of Order" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlDepoName"></asp:RequiredFieldValidator>
                </div>
            </div>--%>

                       <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Category Type:</label>
                        <asp:DropDownList ID="ddlCategoryType" OnDataBound="ddlCategoryType_DataBound" AutoPostBack="true" DataSourceID="odsCategoryType" DataTextField="Type" DataValueField="ID"
                        runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="odsCategoryType" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="getrecordCategorytype">
                     </asp:ObjectDataSource>
             
                <%--    <asp:RequiredFieldValidator ID="rfvCategoryType" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Category Type" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlCategoryType"></asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Category Name:</label>
                   
                    <asp:DropDownList ID="ddlCategoryName" AutoPostBack="true" DataSourceID="odsCategoryName" DataTextField="Category_Name" DataValueField="ID" OnDataBound="ddlCategoryName_DataBound" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                     <asp:ObjectDataSource ID="odsCategoryName" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="getrecordCategory">
                         <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCategoryType"  Name="did" Type="Int32" PropertyName="SelectedValue" DefaultValue="0"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="rfvddlCategoryName" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Category Name" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlCategoryName"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Product Name:</label>
                  
                    <asp:DropDownList ID="ddlProduct" DataSourceID="odsProductName" AutoPostBack="true" DataTextField="Product_Name" DataValueField="Product_ID" OnDataBound="ddlProduct_DataBound"   runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                      <asp:ObjectDataSource ID="odsProductName" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="GetProductByDID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCategoryName" PropertyName="SelectedValue"  Name="DID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="rfddlProduct" ValidationGroup="grp" runat="server" ErrorMessage="Please Select Product Name" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlProduct"></asp:RequiredFieldValidator>
                </div>
            </div>
               <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Select Batch:</label>
                  
                    <asp:DropDownList ID="ddlProductBatch" DataSourceID="sqlBatch" AutoPostBack="true" OnSelectedIndexChanged="ddlProductBatch_SelectedIndexChanged" OnDataBound="ddlProductBatch_DataBound" DataTextField="Batch" DataValueField="BID"    runat="server" CssClass="col-lg-4 form-control">
                   <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                         </asp:DropDownList>
                    <%--  <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="RHPDComponent.StockTransferComponent" SelectMethod="GetProductByDID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCategoryName" PropertyName="SelectedValue"  Name="DID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>--%>
                    <asp:SqlDataSource ID="sqlBatch" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="spGetBatchByProduct" SelectCommandType="StoredProcedure">

                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlProduct" PropertyName="SelectedValue" DefaultValue="1" Name="PID" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server"
                         ErrorMessage="Please Select Product Name" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlProductBatch"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Total Quantity:</label>
                    <asp:TextBox ID="txtTotalQuantity" CssClass="col-lg-4 form-control" runat="server" ReadOnly="true" Text=""></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvtxtTotalQuantity" ValidationGroup="grp" runat="server" ErrorMessage="quantity not available" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtTotalQuantity"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Issued Quantity:</label>

                    <asp:TextBox ID="txtIssuedQuantity" CssClass="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rftxtIssuedQuantity" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtIssuedQuantity"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender runat="server" ID="ftetxtIssuedQuantity" ValidChars="0123456798." TargetControlID="txtIssuedQuantity"></asp:FilteredTextBoxExtender>

                    <asp:CustomValidator ID="ctmvQtyIssued" runat="server" ValidationGroup="grp" OnServerValidate="ctmvQtyIssued_ServerValidate"  Display="Dynamic" Text="quantity not be greater than total quantity" ForeColor="Red"  ControlToValidate="txtIssuedQuantity"></asp:CustomValidator>
                    
                </div>
            </div>

            <div class="row">
                <div class="col-lg-2"></div>
                <div class="form-group-2 col-lg-4 text-align-right">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" CausesValidation="false" OnClick="btnClear_Click" Text="Clear" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>

            <asp:GridView ID="grdstockissue" runat="server" DataKeyNames="Sr.No" AutoGenerateColumns="false" EnableModelValidation="True"
                ShowFooter="true" AllowPaging="true"
                OnPageIndexChanging="grdstockissue_PageIndexChanging"
                OnRowDeleting="grdstockissue_RowDeleting"
                OnRowEditing="grdstockissue_RowEditing"
                OnRowDataBound="grdstockissue_RowDataBound"
                PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>
                    <asp:BoundField DataField="Sr.No" HeaderText="Sr.No" />
                    <asp:BoundField DataField="CategoryType" HeaderText="CategoryType" />
                    <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                    <asp:BoundField DataField="BatchName" HeaderText="BatchName" />
                    <asp:BoundField DataField="CategoryTypeId" HeaderText="CategoryTypeId" />
                    <asp:BoundField DataField="CategoryMasterId" HeaderText="CategoryMasterId" />
                    <asp:BoundField DataField="ProductMasterId" HeaderText="ProductMasterId" />
                    <asp:BoundField DataField="BatchMasterId" HeaderText="BatchMasterId" />
                    <asp:BoundField DataField="TotalQty" HeaderText="TotalQty" />
                    <asp:BoundField DataField="QtyIssued" HeaderText="QtyIssued" />
                    <asp:BoundField DataField="RemainingQty" HeaderText="RemainingQty" />
                    <asp:CommandField DeleteText="Edit" ShowEditButton="true" />
                    <asp:CommandField DeleteText="Delete" ShowDeleteButton="true" ButtonType="Link" />

                    <%-- <asp:TemplateField AccessibleHeaderText="Edit">
                         <ItemTemplate> 
                             <asp:LinkButton ID="lkbtnedit" Text="Edit" runat="server" CommandName="editfield" CommandArgument='<%# Container.DataItemIndex+1%>'></asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>
                      <asp:TemplateField AccessibleHeaderText="Delete">
                         <ItemTemplate> 
                             <asp:LinkButton ID="lkbtndelete" Text="Delete" runat="server" CommandName="deletefield" CommandArgument='<%# Container.DataItemIndex+1%>'></asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>--%>
                    <%--<asp:BoundField DataField="IsUnit" HeaderText="Is Unit" />
                    <asp:BoundField DataField="TypeOfOrderId" HeaderText="Type of Order" />
                    <asp:BoundField DataField="DepuName" HeaderText="DepuName"/>
                    <asp:BoundField DataField="UnitMaster" HeaderText="UnitMaster" />
                    <asp:BoundField DataField="DepuId" HeaderText="DepuId" />
                    <asp:BoundField DataField="UnitId" HeaderText="UnitId" />--%>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

                <RowStyle ForeColor="#000066"></RowStyle>

                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
            </asp:GridView>

              <div class="row" style="margin-top:10px;">
                <div class="col-lg-2"></div>
                <div class="form-group-2 col-lg-4 text-align-right">
                    <asp:Button ID="btnSubmitAll" CssClass="btn btn-primary" Visible="false"  OnClientClick="if(!confirm('Are you sure')) return false;" ValidationGroup="grps" runat="server" Text="Issue Product" OnClick="btnSubmitAll_Click" />
                   
                </div>
            </div>

        </div>
    </div>

</asp:Content>
