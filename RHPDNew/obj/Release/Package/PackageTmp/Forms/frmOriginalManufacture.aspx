<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="frmOriginalManufacture.aspx.cs" Inherits="RHPDNew.Forms.frmOriginalManufacture" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>

    
    <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Manage Original Manufacture</h1>
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
                    <label class="form_text">Name:</label>
                    <asp:TextBox CssClass="form-control" ID="txtSupplierName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDepuName" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtSupplierName"></asp:RequiredFieldValidator>
                  <%--  <asp:FilteredTextBoxExtender runat="server" ID="fteName" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm 1234567890 " TargetControlID="txtSupplierName"></asp:FilteredTextBoxExtender>--%>
                </div>
                <div class="col-five">
                    <label class="form_text">Contact No:</label>
                    <asp:TextBox CssClass="form-control" ID="txtContactNo" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtContactNo"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" ValidChars="1234567890" 
                        TargetControlID="txtContactNo"></asp:FilteredTextBoxExtender>
                </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-five checkboxDiv">
                    <label class="form_text">Is Active</label>
                    <asp:CheckBox ID="chkIsActive" CssClass="cssIsActive" Checked="true" runat="server" Text="" />
                </div>
                <div class="col-five">
                    <label class="form_text">Descripition:</label>
                    <asp:TextBox ID="txtDesc" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDepuDesc" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
                <%--    <asp:FilteredTextBoxExtender runat="server" ID="fteLocation" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm 1234567890" TargetControlID="txtDesc"></asp:FilteredTextBoxExtender>--%>
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
                <asp:GridView ID="grdFormation" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Id" AutoGenerateColumns="false
                " OnRowCommand="grdFormation_RowCommand">
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
                      <asp:TemplateField AccessibleHeaderText="ContactNo">
                        <HeaderTemplate>
                            Contact No
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblcontact" runat="server" Text='<%# Eval("ContactNo") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="Address">
                        <HeaderTemplate>
                            Address
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="Active/In-Active">
                        <HeaderTemplate>
                            Active/In-Active
                        </HeaderTemplate>
                        <ItemTemplate>

                            <asp:CheckBox ID="chk" Checked=' <%# Eval("IsActivated")%>' runat="server" Enabled="false"/>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="Active/In-Active">
                        <HeaderTemplate>
                            Action
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%#Eval("Id") %>' Text="Edit" CommandName="UpdateRecord" /> &nbsp;|&nbsp;
                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>' Text="Delete"  CommandName="DeleteRecord"  />

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
</asp:Content>
