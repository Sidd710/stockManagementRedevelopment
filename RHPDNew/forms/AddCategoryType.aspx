<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="AddCategoryType.aspx.cs" Inherits="RHPDNew.Forms.AddCategory" %>

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
            alert('Name is also exists');
        }
    </script>
   <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Category Type</h1>
            </div>
        </div>
         <br />
         <br />
    <style>
            body{background:url(../assets/images/flag.jpg) no-repeat;background-size:cover;}
        </style>
    <div class="container-fluid form-outer forming_texting">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <asp:ValidationSummary ID="valSum" ValidationGroup="grp"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server" />
                </div>
            </div>
            <div class="clear"></div>
            <div class="row marginbottom10">
                <div class="col-md-12 text-align-center">
                    <label class="form_text">Type:</label>
                    <asp:TextBox CssClass="col-lg-4 form-control" ID="txtCategoryName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtCategoryName" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtCategoryName"></asp:RequiredFieldValidator>
                    <%--<asp:FilteredTextBoxExtender runat="server" ID="fteType" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtCategoryName"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-md-12 text-align-center">
                    <label class="form_text">Description:</label>
                    <asp:TextBox ID="txtCategoryDesc" CssClass="col-lg-4 form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtCategoryDesc" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtCategoryDesc"></asp:RequiredFieldValidator>
                    <%--  <asp:FilteredTextBoxExtender runat="server" ID="fteDescription" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm. " TargetControlID="txtCategoryDesc"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>
            <div class="clear"></div>
            <div class="row marginbottom10 checkboxDiv col-ten">
                <div class="col-md-12 text-align-center">
                    <label class="form_text">Is Active</label>
                    <asp:CheckBox ID="chkIsActive" CssClass="cssIsActive" Checked="true" runat="server" Text="" />
                </div>
            </div>
            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 marginbottom20">
                    <label class="form_text"></label>
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" CausesValidation="false" OnClick="btnClear_Click" Text="Clear" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>
            <asp:ObjectDataSource ID="objCattype" runat="server" TypeName="RHPDComponent.AddCategoryComp" SelectMethod="GridDisplayComponent"></asp:ObjectDataSource>
            <telerik:RadGrid runat="server" DataSourceID="objCattype" ID="RadGrid" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="RadGrid_ItemCommand" OnItemDataBound="RadGrid_ItemDataBound">
                <MasterTableView DataKeyNames="ID" Caption="Category List" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="9">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                    <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" CausesValidation="false" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                    </CommandItemTemplate>
                    <Columns>
                        <%-- <telerik:GridTemplateColumn HeaderText="Id" DataType="System.String" Groupable="false" HeaderStyle-CssClass="text-center GridHeader_Sunset">
                                                                            <ItemTemplate>
                                                                                <div class="">
                                                                                    <asp:Label ID="lkesdfdit" runat="server" Text='<%# Eval("ImgId")%>'></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Type" DataField="Type" DataType="System.String" UniqueName="Type" Groupable="false">
                            <ItemTemplate>
                                <div style="text-transform: capitalize;">
                                    <%#Eval("Type").ToString()==""?"N/A":Eval("Type") %>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Description" AllowFiltering="false">
                            <ItemTemplate>
                                <div style="text-transform: capitalize;">
                                    <%-- <asp:Image ID="img" runat="server" class="table-img" ImageUrl='<%#"~/Upload/Banner/"+ Eval("ImageUrl")%>' />--%>
                                    <asp:Label ID="lblCategoryDesc" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <%--   <telerik:GridTemplateColumn HeaderText="Image Description" DataField="ImgDescription" DataType="System.String" UniqueName="ImgDescription" Groupable="false" HeaderStyle-CssClass="text-center GridHeader_Sunset">
                                                                            <ItemTemplate>
                                                                                <div class="">
                                                                                    <%#Eval("ImgDescription").ToString()==""?"N/A":Eval("ImgDescription") %>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>

                        <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false">
                            <ItemTemplate>
                                <div class="">
                                    <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("Id")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>&nbsp;&nbsp;
                                                 <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" Text="Edit" CommandName="Editnew" CommandArgument='<%#  Eval("ID")+"< "+Eval("Type")+"< "+Eval("Description")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>
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
    <%-- <div>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="FirstName" runat="server"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    --%>
</asp:Content>
