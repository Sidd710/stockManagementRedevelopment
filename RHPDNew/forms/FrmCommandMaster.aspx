<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="FrmCommandMaster.aspx.cs" Inherits="RHPDNew.Forms.FrmCommandMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
       <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Manage Command</h1>
            </div>
        </div>
         <br />
         <br />
    <style>
            body{background:url(../assets/images/flag.jpg) no-repeat;background-size:cover;}
        </style>
    <div "page-wrapper">
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
                    <asp:TextBox CssClass="col-lg-4 form-control" ID="txtCommandName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDepuName" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtCommandName"></asp:RequiredFieldValidator>
<%--                    <asp:FilteredTextBoxExtender runat="server" ID="fteName" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm 1234567890" TargetControlID="txtCommandName"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-ten">
                    <label class="form_text">Descripition:</label>
                    <asp:TextBox ID="txDesc" CssClass="col-lg-4 form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDepuDesc" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txDesc"></asp:RequiredFieldValidator>
                    <%--<asp:FilteredTextBoxExtender runat="server" ID="fteLocation" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm 1234567890" TargetControlID="txDesc"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>
            
            <div class="clear"></div>
            <div class="row marginbottom10 checkboxDiv col-ten">
                <div class="col-ten">
                    <label class="form_text">Is Active</label>
                    <asp:CheckBox ID="chkIsActive" CssClass="cssIsActive" Checked="true" runat="server" Text="" />
                </div>
            </div>
            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 marginbottom20">
                    <label class="form_text"></label>
                    <input type="hidden" id="visiblelblmsg" value="" runat="server" />
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" CausesValidation="false" runat="server" Text="Clear" />
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
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Id" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField AccessibleHeaderText="Name">
                        <HeaderTemplate>
                            Sr.No
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="" style="float: left;">
                                <%#Container.DisplayIndex+1%>
                            </div>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField AccessibleHeaderText="Name">
                        <HeaderTemplate>
                            Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="Name">
                        <HeaderTemplate>
                            Descripition
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("Descripition") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="Active/In-Active">
                        <HeaderTemplate>
                            Active/In-Active
                        </HeaderTemplate>
                        <ItemTemplate>

                            <asp:CheckBox ID="chk" Checked=' <%# Eval("IsActive")%>' runat="server" />
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="Active/In-Active">
                        <HeaderTemplate>
                            Action
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%#Eval("Id") %>' Text="Update" CommandName="UpdateRecord" />
                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>' Text="Delete" Visible="false" CommandName="DeleteRecord" OnClientClick="return confirm();" />

                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#EFF3FB"></RowStyle>

                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
            </asp:GridView>
            </div>
        </div>
    </div>
        </div>
</asp:Content>