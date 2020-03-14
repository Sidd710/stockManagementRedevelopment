<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="AddDepu.aspx.cs" Inherits="RHPDNew.Forms.AddDepu" %>

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
        function example() {
            if (!confirm('Parent is Exists. Are you want to make this parent ?')) {
                var xPro = document.getElementById('<%= visiblelblmsg.ClientID %>');
                xPro.value = "";
                return false;
            }
            else {
                var xPro = document.getElementById('<%= visiblelblmsg.ClientID %>');
                xPro.value = "done";
                document.getElementById("<%= btnSubmit.ClientID %>").click();
                //onclick()
                return true;
            }
        }
        function name() {
            alert('Name is also exists');
        }
        function parent() {
            alert('This is Parent so,Please set it Parent')
        }
    </script>
    
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
                 <div class="col-five"></div>
                <div class="col-five"> <label class="form_text"> Type:</label>
                    <table style="width:286px;margin-left:223px;">
                        <tr>
                            <td>  <asp:CheckBox runat="server" ID="cbxIDT" Text="IDT" /></td>
                            <td> <asp:CheckBox runat="server" ID="cbxICT" Text="ICT" /></td>
                            <td> <asp:CheckBox runat="server" ID="cbxAWS" Text="AWS" /></td>
                        </tr>
                    </table>
                  
                      
  

                
                </div>
           
                
                <div class="col-five">
                    <label class="form_text"> Formation:</label>
                    <asp:DropDownList ID="ddlformation" runat="server" DataSourceID="sqlformation"  CssClass="form-control" OnDataBound="ddlformation_DataBound" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                         ControlToValidate="ddlformation" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="sqlformation" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="SELECT * FROM [Formation] WHERE ([IsActive] = @IsActive)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean"></asp:Parameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Corp.:</label>
                    <asp:TextBox CssClass="form-control" ID="txtCorp" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                         ControlToValidate="txtCorp"></asp:RequiredFieldValidator>
                  <%--  <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender3" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm 1234567890" TargetControlID="txtDepuName"></asp:FilteredTextBoxExtender>--%>
                </div>
                <div class="col-five">
                    <label class="form_text">Unit Name:</label>
                    <asp:TextBox CssClass="form-control" ID="txtdepotNo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" 
                        SetFocusOnError="true" ControlToValidate="txtdepotNo"></asp:RequiredFieldValidator>
                  <%--  <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender4" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm 1234567890" TargetControlID="txtDepuName"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>

            <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Depot Name:</label>
                    <asp:TextBox CssClass="form-control" ID="txtDepuName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDepuName" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDepuName"></asp:RequiredFieldValidator>
                   <%-- <asp:FilteredTextBoxExtender runat="server" ID="fteName" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtDepuName"></asp:FilteredTextBoxExtender>--%>
                </div>
                <div class="col-five">
                    <label class="form_text">Location:</label>
                    <asp:TextBox ID="txtDepuDesc" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDepuDesc" ValidationGroup="grp" runat="server" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDepuDesc"></asp:RequiredFieldValidator>
                  <%--  <asp:FilteredTextBoxExtender runat="server" ID="fteLocation" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtDepuDesc"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>
            <div class="clear"></div>
            <div class="row marginbottom10 checkboxDiv col-ten">
                <div class="col-five">
                    <label class="form_text">Is Active</label>
                    <asp:CheckBox ID="chkIsActive" CssClass="cssIsActive" Checked="true" runat="server" Text="" />
                </div>
                <div class="col-five">
                    <label class="form_text">Is Parent</label>
                    <asp:UpdatePanel runat="server" ID="updP">
                        <ContentTemplate>

                        
                    <asp:CheckBox AutoPostBack="true" ID="chkIsPArent" CssClass="cssIsActive"  runat="server" Text="" />
                <asp:TextBox Visible="false" placeholder="Unit Name" CssClass="form-control" ID="txtUnitName" runat="server"></asp:TextBox>
                              </ContentTemplate>
                    </asp:UpdatePanel> </div>
                
            </div>
            <div class="clear"></div>
            <div class="row">
                <div class="col-md-12 text-align-center marginbottom20">
                    <input type="hidden" id="visiblelblmsg" value="" runat="server" />
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" OnClick="btnClear_Click1" CausesValidation="false" runat="server" Text="Clear" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>

                <asp:Label ID="lblresult" runat="server" />
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <%--   <asp:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
                    CancelControlID="Imgclose" BackgroundCssClass="modalBackground" runat="server">
                </asp:ModalPopupExtender>

                <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="100px" Width="400px" Style="display: none">
                    <table width="100%" style="border: Solid 1px #51aeda; width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                        <tr style="background-color: #51aeda;">
                            <td style="height: 10%; color: White; font-weight: bold; padding: 3px; font-size: larger; font-family: Calibri" align="Left">Confirm Box</td>
                            <td style="color: White; font-weight: bold; padding: 3px; font-size: larger" align="Right">
                                <asp:ImageButton ID="Imgclose" runat="server" ImageUrl="~/Images/Close.gif" OnClick="Imgclose_Click" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" align="left" style="padding: 5px; font-family: Calibri">
                                <asp:Label ID="lblUser" Text="Are you sure want to update the parent" runat="server" />
                            </td>
                        </tr>
                        <tr>


                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right" style="padding-right: 15px">
                                <asp:ImageButton ID="btnYes" OnClick="btnYes_Click" runat="server" ImageUrl="~/Images/btnyes.jpg" />
                                <asp:ImageButton ID="ImageButton3" OnClick="Button1_Click" runat="server" ImageUrl="~/Images/btnNo.jpg" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>--%>
            </div>
        </div>
        <asp:ObjectDataSource ID="objDepu" runat="server" TypeName="RHPDComponent.AdddepuComp" SelectMethod="GridDisplayComponent"></asp:ObjectDataSource>

        <div class="container">
            <telerik:RadGrid runat="server" DataSourceID="objDepu" ID="RadGrid" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="RadGrid_ItemCommand">
            <MasterTableView DataKeyNames="Depu_Id" Caption="Depot List" AllowAutomaticUpdates="false" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="9">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                <CommandItemTemplate>
                    <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                </CommandItemTemplate>
                 <GroupByExpressions>
                    
                   <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="IDTICTAWS" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="IDTICTAWS" HeaderText="." />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                    
                    </GroupByExpressions>
                <Columns>

                    <telerik:GridTemplateColumn HeaderText="S No." AllowFiltering="false">
                        <ItemTemplate>
                            <div class="" style="float: left;">
                                <%#Container.DataSetIndex+1%>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="Command Name" DataField="cmname" DataType="System.String" UniqueName="cmname" Groupable="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <%#Eval("cmname").ToString()==""?"N/A":Eval("cmname") %>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn HeaderText="Formation Name" DataField="fmname" DataType="System.String" UniqueName="fmname" Groupable="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <%#Eval("fmname").ToString()==""?"N/A":Eval("fmname") %>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Corp" DataField="corp" DataType="System.String" UniqueName="corp" Groupable="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <%#Eval("corp").ToString()==""?"N/A":Eval("corp") %>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Unit Name" DataField="DepotNo" DataType="System.String" UniqueName="DepotNo" Groupable="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <%#Eval("DepotNo").ToString()==""?"N/A":Eval("DepotNo") %>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn Visible="false" HeaderText="Code" DataField="Depot_Code" DataType="System.String" UniqueName="Depot_Code" Groupable="false">
                        <ItemTemplate>
                            <div class="">
                                <%#Eval("Depot_Code").ToString()==""?"N/A":Eval("Depot_Code") %>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Depot Name" DataField="DepuName" DataType="System.String" UniqueName="Depu_Name" Groupable="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <%#Eval("Depu_Name").ToString()==""?"N/A":Eval("Depu_Name") %>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn HeaderText="Location" AllowFiltering="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <asp:Label ID="lblDepuDesc" runat="server" Text='<%#Eval("Depu_Location") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn Visible="false" HeaderText="Unit Name" DataField="UnitName" DataType="System.String" UniqueName="UnitName" Groupable="false">
                        <ItemTemplate>
                            <div style="text-transform: capitalize;">
                                <%#Eval("UnitName").ToString()==""?"N/A":Eval("UnitName") %>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                

                    <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false">
                        <ItemTemplate>
                            <div class="">
                                <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("Depu_Id")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>
                                <%-- <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()%>' CausesValidation="false" CommandName="Active" CommandArgument='<%#Eval("IsActive").ToString()%>'></asp:LinkButton>--%>
                                <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" Text="Edit" CommandName="Editnew"
                                     CommandArgument='<%#  Eval("Depu_Id")+"< "+Eval("Depu_Name")+"< "+Eval("Depu_Location")+"< "+ Eval("IsActive").ToString()
                                +"<"+Eval("Depot_Code")+"<"+Eval("IsParent")
                                +"<"+Eval("CommandId")+"<"+Eval("FormationId")+"<"+Eval("Corp")+"<"+Eval("DepotNo")+"<"+Eval("UnitName")+"<"+Eval("IDT")+"<"+Eval("ICT") +"<"+Eval("AWS")     %>'></asp:LinkButton>

                            </div>
                        </ItemTemplate>

                    </telerik:GridTemplateColumn>


                </Columns>
            </MasterTableView>

        </telerik:RadGrid>
        </div>
    </div>
</asp:Content>
