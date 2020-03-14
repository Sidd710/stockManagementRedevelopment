<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="RHPDNew.Forms.AddRole" %>

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
            <h1>Add Role</h1>
            </div>
        </div>
    </div>
    <div class="container-fluid form-outer">
        <div class="container">
            <div class="fright depotCode">
                Code#
                <b><asp:Label ID="lblRoleCode" runat="server"></asp:Label></b>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="clear"></div>
        <div class="container forming_texting">
            <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Department:</label>
                    <asp:ObjectDataSource ID="odsDept" runat="server" TypeName="RHPDComponent.DeptComp" SelectMethod="SelectActive"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlDept" CssClass="form-control" runat="server" DataSourceID="odsDept" DataTextField="Dept" DataValueField="Id" OnDataBound="ddlDept_DataBound"></asp:DropDownList>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rfvtxtRoleType" runat="server" ErrorMessage="" InitialValue="-- Select --"  Text="*"  ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlDept"></asp:RequiredFieldValidator>
                </div>
                <div class="col-five">
                    <label class="form_text">Role :</label>
                    <asp:TextBox ID="txtRole" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rfvtxtRoleDesc" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtRole"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender runat="server" ID="fteType" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm-0123456789:_. " TargetControlID="txtRole"></asp:FilteredTextBoxExtender>
                </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Description:</label>
                    <asp:TextBox ID="txtDesc" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
                    <%-- <asp:FilteredTextBoxExtender runat="server" ID="fteDescription" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtDesc"></asp:FilteredTextBoxExtender>--%>
                </div>
                <div class="col-five checkboxDiv">
                    <label class="form_text">Is Active</label>
                    <asp:CheckBox ID="chkIsActive" CssClass="cssIsActive" Checked="true" runat="server" Text="" />
                </div>
            </div>
            <div class="row" style="display:none;">
                <div class="col-five">
                    <label class="form_text">Rank: </label>
                    <telerik:RadNumericTextBox CssClass="form-control"  MinValue="0"   
                    MaxValue="999999999"   BorderStyle="None" ID="txtRank" runat="server" Type="Number" Value="1" >
                         <NumberFormat GroupSeparator="" DecimalDigits="0" /> 
                    </telerik:RadNumericTextBox>
                  <%--  <asp:RequiredFieldValidator ID="rfvtxtAddQuantity" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtRank"></asp:RequiredFieldValidator>--%>
                     <%--<asp:FilteredTextBoxExtender runat="server" ID="fteRank" ValidChars="0123456798" TargetControlID="txtRank"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>
            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 text-align-center marginbottom20">
                    <asp:Button ID="btnSubmit" ValidationGroup="grp" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>
            <asp:ObjectDataSource ID="odsRole" runat="server" TypeName="RHPDComponent.AddroleComp" SelectMethod="GridDisplayComponent"></asp:ObjectDataSource>
            <telerik:RadGrid DataSourceID="odsRole" runat="server" ID="rgdRole" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="RadGrid_ItemCommand">
                <MasterTableView DataKeyNames="Role_Id" Caption="Role List" CommandItemDisplay="top" Font-Names="Arial" Font-Size="9">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                    <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                    </CommandItemTemplate>
                    <GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Dept" HeaderValueSeparator=":" SortOrder="Descending" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Dept" HeaderText="Department" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                    </GroupByExpressions>
                    <Columns>
                        <%-- <telerik:GridTemplateColumn HeaderText="Id" DataType="System.String" Groupable="false" HeaderStyle-CssClass="text-center GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lkesdfdit" runat="server" Text='<%# Eval("ImgId")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="false" HeaderText="Department" DataField="DeptId" DataType="System.String" UniqueName="DeptId" Groupable="false">
                            <ItemTemplate>

                                <%#Eval("Dept") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Role Code" DataField="Role_Code" DataType="System.String" UniqueName="Role_Code" Groupable="false">
                            <ItemTemplate>

                                <%#Eval("Role_Code") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Role" DataField="Role" DataType="System.String" UniqueName="Role" Groupable="false">
                            <ItemTemplate>

                                <%#Eval("Role") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Description" AllowFiltering="false">
                            <ItemTemplate>

                                <%#Eval("Role_Desc") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Rank" DataField="Rank" DataType="System.String" UniqueName="Rank" Groupable="false" Visible="false">
                            <ItemTemplate>

                                <%#Eval("Rank") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>


                        <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%#  Eval("Role_Id")+"< "+Eval("IsActive")%>'></asp:LinkButton>
                                    &nbsp&nbsp  
                                    <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" Text="Edit" CommandName="Editnew" CommandArgument='<%#  Eval("Role_Id")+"< "+Eval("Role_Code")+"< "+Eval("Role_desc")+"< "+ Eval("IsActive").ToString()+"< "+Eval("Role")+"< "+ Eval("DeptId")+"< "+ Eval("Rank")%>'></asp:LinkButton>
                                    <%--   <asp:Label ID="lblDelete" Visible="false" Text='<%# Bind("Id")%>' runat="server"></asp:Label> 
                                                                            <asp:LinkButton ID="lbldel" class="button thonerow pad-right-nonein red-gradient glossy tiny" runat="server" CommandName="Delete" CommandArgument='<%# Bind("Id")%>' OnClientClick="return confirm('Are you sure you want to delete this record?')"   Text="Delete"></asp:LinkButton>
                                    --%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Content>