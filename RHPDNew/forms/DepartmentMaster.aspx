<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="DepartmentMaster.aspx.cs" Inherits="RHPDNew.Forms.DepartmentMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="container">
            <div class="row pageHeading">
                <h1>Manage Group/Section</h1>
            </div>
        </div>
    </div>
    <div class="container-fluid form-outer">
        <div class="container">
            <div class="fright depotCode">
            Code#
            <b><asp:Label ID="lblDeptCode" runat="server"></asp:Label></b>
            </div>
            <div class="clearfix"></div>
        </div>
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
                <div class="col-ten">
                    <label class="form_text">Name:</label>
                    <asp:TextBox CssClass="col-lg-4 form-control" ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtRoleType" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                 <%--   <asp:FilteredTextBoxExtender runat="server" ID="fteType" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtName"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>

            <div class="row">
                <div class="col-ten">
                    <label class="form_text">Description:</label>
                    <asp:TextBox ID="txtDesc" CssClass="col-lg-4 form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rfvtxtRoleDesc" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
           <%--         <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtDesc"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>
            <div class="clear"></div>
            <div class="row marginbottom10 checkboxDiv col-ten">
                <div class="col-ten">
                    <label class="form_text">Is Active</label>
                    <asp:CheckBox ID="cbxActive" CssClass="cssIsActive" Checked="true" runat="server" Text="" />
                </div>
            </div>
            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 marginbottom20">
                    <label class="form_text"></label>
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    <asp:HiddenField ID="hdnID" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>
            <asp:ObjectDataSource ID="objDept" runat="server" TypeName="RHPDComponent.DeptComp" SelectMethod="SelectAll"></asp:ObjectDataSource>
            <telerik:RadGrid runat="server" DataSourceID="objDept" ID="rgdDept" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="rgdDept_ItemCommand">
                <MasterTableView Caption="Department List" DataKeyNames="Id" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="9">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                    <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                    </CommandItemTemplate>
                    <Columns>

                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                            <ItemTemplate>
                                <%#Container.DataSetIndex+1%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Name" DataField="DeptName" DataType="System.String" UniqueName="DeptName" Groupable="false">
                            <ItemTemplate>
                                <div style="text-transform: capitalize;">
                                    <%#Eval("DeptName") %>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Description" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%#Eval("Description") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnActive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%#  Eval("Id")+"< "+Eval("DeptCode")+"< "+Eval("DeptName")+"< "+Eval("Description")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>
                                &nbsp&nbsp
                                <asp:LinkButton ID="lbtnEdit" runat="server" CausesValidation="false" Text="Edit" CommandName="Editnew" CommandArgument='<%#  Eval("Id")+"< "+Eval("DeptCode")+"< "+Eval("DeptName")+"< "+Eval("Description")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <NoRecordsTemplate>
                        No records found....!
                    </NoRecordsTemplate>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Content>
