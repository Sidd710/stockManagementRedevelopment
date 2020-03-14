<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="CategoryMaster.aspx.cs" Inherits="RHPDNew.Forms.CategoryMaster" %>
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
            alert('Name is also exists');
        }
    </script>
    
       <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Manage Categories</h1>
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
                            runat="server" />
                    </div>
                 </div>
                 <div class="row marginbottom10">
                    <div class="col-five">
                        <label class="form_text"> Type :</label>
                        <asp:ObjectDataSource ID="odsCategory" runat="server" TypeName="RHPDComponent.AddCategoryComp" SelectMethod="getrecord"></asp:ObjectDataSource>
                        <asp:DropDownList  ID="ddlselectCat" OnDataBound="ddlselectCat_DataBound" CssClass="form-control"  runat="server" DataSourceID="odsCategory" DataTextField="Type" DataValueField="ID" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddlselectCat" InitialValue="-- Select --" ErrorMessage="*" ValidationGroup="grp" runat="server"  ForeColor="Red" SetFocusOnError="true"  ControlToValidate="ddlselectCat"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-five">
                        <label class="form_text">Parent(If Any):</label>
                        <asp:ObjectDataSource ID="odsddlparentId" runat="server" TypeName="RHPDComponent.AddCategoryComp" SelectMethod="getparentid"></asp:ObjectDataSource>
                        <asp:DropDownList  ID="ddlparentId" DataSourceID="odsddlparentId"  OnDataBound="ddlparentId_DataBound"   DataTextField="Category_Name" DataValueField="ID" CssClass="form-control"  runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="row marginbottom10">
                    <div class="col-five">
                        <label class="form_text">Name:</label>
                        <asp:TextBox CssClass="form-control" ID="txtCategoryName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtCategoryName" ValidationGroup="grp" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtCategoryName"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-five">
                         <label class="form_text">Description:</label>
                         <asp:TextBox ID="txtCategoryDesc" CssClass="form-control" TextMode="MultiLine" runat="server" style="resize:none;"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvtxtCategoryDesc" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm." ValidationGroup="grp" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtCategoryDesc"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="clear"></div>
                <div class="row marginbottom10 checkboxDiv col-ten">
                    <div class="col-five">
                      <label class="form_text">Is Active</label>
                      <asp:CheckBox ID="chkIsActive" CssClass="cssIsActive" Checked="true" runat="server" Text="" />
                    </div>
                </div>
                <div class="clear"></div>
                <div class="row">
                    <div class="col-md-12 text-align-center marginbottom20">
                        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" ValidationGroup="grp" Text="Submit" OnClick="btnSubmit_Click"   />
                        <asp:Button ID="btnClear" CssClass="btn btn-warning"  OnClick="btnClear_Click" runat="server" Text="Clear"  />
                        <asp:HiddenField ID="hfid" runat="server" />
                        <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                    </div>
                </div>
                <asp:ObjectDataSource ID="objCat" runat="server" TypeName="RHPDComponent.AddCategoryComp" SelectMethod="GridDisplayMasterCategory" ></asp:ObjectDataSource>
                <telerik:RadGrid DataSourceID="objCat" runat="server" ID="RadGrid" Width="100%"  AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="RadGrid_ItemCommand">
                    <MasterTableView DataKeyNames="ID" Caption="Category List"  CommandItemDisplay="Top" Font-Names="Arial" Font-Size="9">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                         <CommandItemTemplate>
                          <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                    </CommandItemTemplate>
                        <GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Type" HeaderValueSeparator=":" SortOrder="Descending" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Type" HeaderText="Type" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                             <%--<telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Parent" HeaderValueSeparator=":" SortOrder="Descending" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Parent" HeaderText="Parent" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>--%>
                        
                        </GroupByExpressions>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                                <ItemTemplate>
                                    <div class="">
                                        <%#Container.DataSetIndex+1%>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="false" HeaderText=" Code" DataField="Type" DataType="System.String" UniqueName="Code" Groupable="false">
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("Category_Code").ToString()==""?"N/A":Eval("Category_Code") %>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Name" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <asp:Label ID="lblCategoryName" runat="server" Text='<%#Eval("Category_Name") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn HeaderText="Description" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <asp:Label ID="lblCategoryDesc" runat="server" Text='<%#Eval("Category_desc") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="ID" Visible="false" AllowFiltering="false" >
                                <ItemTemplate>
                                    <div class="">
                                        <asp:Label ID="lblID" runat="server"  Visible="false" Text='<%#Eval("ID") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false">
                                <ItemTemplate>
                                    <div class="">
                                        <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("ID")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>&nbsp;&nbsp;
                                        <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" Text="Edit" CommandName="Editnew" CommandArgument='<%#  Eval("ID")+"< "+Eval("Category_Name")+"< "+Eval("Category_desc")+"< "+ Eval("IsActive").ToString()+"<"+Eval("Category_TypeId")+"<"+Eval("ParentCategory_Id")+"<"+Eval("Category_Code")%>'></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
</asp:Content>
