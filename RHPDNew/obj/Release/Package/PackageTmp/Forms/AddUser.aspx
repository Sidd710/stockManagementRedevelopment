<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="RHPDNew.Forms.AddUser" %>


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
            <h1>Add User</h1>
            </div>
        </div>
    </div>
    <div class="container-fluid form-outer">
        <div class="container">
            <div class="fright depotCode">
            Code#
            <asp:Label ID="lblUserCode" runat="server"></asp:Label>
        </div>
        <div class="container">
            <div class="row">
                <div class="form-group-2">
                    <asp:ValidationSummary ID="valSum" ValidationGroup="grp"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server" />
                </div>
            </div>
            <asp:UpdatePanel ID="updRole" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="form-group-2">
                            <label class="col-lg-2">Department:</label>
                            <asp:DropDownList AutoPostBack="true" DataTextField="Dept" DataValueField="Id" DataSourceID="objDept" ID="ddlDept" CssClass="col-lg-4 form-control" runat="server" OnDataBound="ddlDept_DataBound">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objDept" runat="server" TypeName="RHPDComponent.DeptComp" SelectMethod="SelectActive"></asp:ObjectDataSource>
                            <asp:RequiredFieldValidator InitialValue="0" ValidationGroup="grp" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlDept"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group-2">

                            <label class="col-lg-2">Role:</label>
                            <asp:DropDownList AutoPostBack="true" DataTextField="RoleCode" DataValueField="Role_Id" DataSourceID="odsRole" ID="ddlRole" CssClass="col-lg-4 form-control" runat="server" OnDataBound="ddlRole_DataBound">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsRole" runat="server" SelectMethod="GetRoleByDeptID" TypeName="RHPDComponent.AddroleComp">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlDept" PropertyName="SelectedValue" Name="dID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>

                            <asp:RequiredFieldValidator InitialValue="0" ID="rfvtxtuserrole" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlRole"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>   --%>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Army Number:</label>

                    <asp:TextBox ID="txtArmyNumber" CssClass="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="RequiredFieldValidator7" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtArmyNumber"></asp:RequiredFieldValidator>
                    <%--<asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtFirstName"></asp:FilteredTextBoxExtender>--%>
                </div>
                <div class="form-group-2">
                    <script type="text/javascript">
                        function CompareDate() {
                            var date1Str = document.getElementById('ctl00_ContentPlaceHolder1_txtStartDate').value;
                            var date2Str = document.getElementById('ctl00_ContentPlaceHolder1_txtEndDate').value;;
                            var dateParts = date1Str.split(" ");
                            var newDateStr = dateParts[1] + " " + dateParts[0] + ", " + dateParts[2];
                            var date1 = new Date(newDateStr);
                            var dateParts = date2Str.split(" ");
                            var newDateStr = dateParts[1] + " " + dateParts[0] + ", " + dateParts[2];
                            var date2 = new Date(newDateStr);
                            if (date1 > date2) {
                                alert("Textbox2 is greater than Textbox1");
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                           
                        }
                    </script>
                    <label class="col-lg-2">Period:</label>
                    <asp:TextBox ID="txtStartDate" CssClass="col-lg-4 form-control" placeholder="Select Start Date" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                    <asp:CalendarExtender ID="cetxMfgDate" Format="dd MMM yyyy" TargetControlID="txtStartDate" runat="server"></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="rfvtxtunitDesc" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtStartDate"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtEndDate" CssClass="col-lg-4 form-control" placeholder="Select End Date" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" Format="dd MMM yyyy" TargetControlID="txtEndDate" runat="server"></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="*" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtEndDate"></asp:RequiredFieldValidator>
           <%--         <asp:CompareValidator ID="cmpVal1" ControlToCompare="txtStartDate"
                        ControlToValidate="txtEndDate" Type="Date" Operator="GreaterThan" ValidationGroup="grp"
                        ErrorMessage="*End Date Should be Greater" runat="server"></asp:CompareValidator>--%>
                </div>

                <div class="form-group-2">
                    <label class="col-lg-2">First Name:</label>

                    <asp:TextBox ID="txtFirstName" CssClass="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rfvddlselectdepu" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender runat="server" ID="ftetxtFirstName" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtFirstName"></asp:FilteredTextBoxExtender>
                </div>
                <div class="form-group-2 ">
                    <label class="col-lg-2">Last Name:</label>

                    <asp:TextBox ID="txtLastName" CssClass="col-lg-4 form-control" runat="server" OnTextChanged="txtLastName_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="RequiredFieldValidator1" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender runat="server" ID="ftetxtLastName" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtLastName"></asp:FilteredTextBoxExtender>
                </div>
            </div>


            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Username :</label>
                    <asp:TextBox CssClass="col-lg-4 form-control" ID="txtusername" runat="server" OnTextChanged="txtusername_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rfvtxtusername" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtusername"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">

                    <label class="col-lg-2">Password:</label>
                    <asp:TextBox ID="txtpassword" CssClass="col-lg-4 form-control" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rfvtxtpassword" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>

                </div>
            </div>

            <div class="row">
                <div class="form-group-2">

                    <label class="col-lg-2">Confirm Password:</label>
                    <asp:TextBox ID="txtcpassword" CssClass="col-lg-4 form-control" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rfvtxtcpassword" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtcpassword"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ValidationGroup="grp" ID="cvtxtcpassword" runat="server" ForeColor="Red" ErrorMessage="Password Does not Match " SetFocusOnError="true" ControlToValidate="txtcpassword" ControlToCompare="txtpassword"></asp:CompareValidator>
                </div>
            </div>

            <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>

            <div class="row">
                <div class="form-group-2">

                    <label class="col-lg-2">Address :</label>
                    <asp:TextBox ID="txtAddress" CssClass="col-lg-4 form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtuui" ValidationGroup="grp" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender runat="server" ID="ftetxtAddress" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm-0123456789:_. " TargetControlID="txtAddress"></asp:FilteredTextBoxExtender>
                </div>
            </div>


            <asp:UpdatePanel ID="updAdd" runat="server" Visible="false">
                <ContentTemplate>


                    <div class="row">
                        <div class="form-group-2">

                            <label class="col-lg-2">Country :</label>
                            <asp:DropDownList DataTextField="CountryName" AutoPostBack="true" DataValueField="ID" DataSourceID="odsCountry" ID="ddlCountry" CssClass="col-lg-4 form-control" runat="server" OnDataBound="ddlRole_DataBound">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsCountry" runat="server" SelectMethod="GetCountryList" TypeName="RHPDComponent.AddUserComp"></asp:ObjectDataSource>
                            <%--<asp:RequiredFieldValidator InitialValue="0" ValidationGroup="grp" ID="RequiredFieldValidator4" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group-2">

                            <label class="col-lg-2">State :</label>
                            <asp:DropDownList DataTextField="SUName" AutoPostBack="true" DataValueField="ID" DataSourceID="odsState" ID="ddlState" CssClass="col-lg-4 form-control" runat="server" OnDataBound="ddlRole_DataBound">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsState" runat="server" SelectMethod="GetStateByCountryID" TypeName="RHPDComponent.AddUserComp">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlCountry" PropertyName="SelectedValue" Name="cID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <%-- <asp:RequiredFieldValidator InitialValue="0" ValidationGroup="grp" ID="RequiredFieldValidator5" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlState"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group-2">

                            <label class="col-lg-2">City :</label>
                            <asp:DropDownList DataTextField="CityName" AutoPostBack="true" DataValueField="ID" DataSourceID="odsCity" ID="ddlCity" CssClass="col-lg-4 form-control" runat="server" OnDataBound="ddlRole_DataBound">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsCity" runat="server" SelectMethod="GetCityStateID" TypeName="RHPDComponent.AddUserComp">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlState" PropertyName="SelectedValue" Name="sID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <%--   <asp:RequiredFieldValidator InitialValue="0" ValidationGroup="grp" ID="RequiredFieldValidator6" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlCity"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="row">
                <div class="form-group-2">

                    <label class="col-lg-2">Contact No:</label>
                    <asp:TextBox ID="txtContactNo" CssClass="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="RequiredFieldValidator3" runat="server" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtContactNo"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender runat="server" ID="fteRank" ValidChars="0123456798" TargetControlID="txtContactNo"></asp:FilteredTextBoxExtender>
                    <asp:RegularExpressionValidator ID="revtbContacntNumber" runat="server" ValidationGroup="grp" ControlToValidate="txtContactNo" Text="Contact number is not valid !" ErrorMessage="" ValidationExpression="^[\s\S]{10,10}$"></asp:RegularExpressionValidator>
                </div>
            </div>


            <div class="row">
                <label class="col-lg-2">Is Active</label>
                <div class="form-group-2 col-lg-4 text-align-right padding-0">
                    <asp:CheckBox ID="chkIsActive" CssClass="cssIsActive pull-left" Checked="true" runat="server" Text="" />
                </div>
            </div>

            <div class="row">
                <div class="form-group-2 col-lg-4 text-align-right padding-0">
                    <asp:Button ID="btnSubmit" ValidationGroup="grp"  CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    <asp:HiddenField ID="hfid" runat="server" />
                </div>
            </div>
            <asp:ObjectDataSource ID="odsUSer" runat="server" TypeName="RHPDComponent.AddUserComp" SelectMethod="GridDisplayComponent"></asp:ObjectDataSource>
            <telerik:RadGrid DataSourceID="odsUSer" runat="server" ID="rgdUser" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="RadGrid_ItemCommand">
                <MasterTableView Caption="User List" DataKeyNames="User_id" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="9">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                    <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                    </CommandItemTemplate>
                    <GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Role" HeaderValueSeparator=":" SortOrder="Descending" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Role" HeaderText="Role" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                    </GroupByExpressions>
                    <Columns>

                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                            <ItemTemplate>

                                <%#Container.DataSetIndex+1%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Code" DataField="UserCode" DataType="System.String" UniqueName="UserCode">
                            <ItemTemplate>

                                <%#Eval("UserCode")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="ArmyNo" DataField="ArmyNo" DataType="System.String" UniqueName="ArmyNo">
                            <ItemTemplate>

                                <%#Eval("ArmyNo")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="StartDate" DataField="StartDate" DataType="System.DateTime" UniqueName="StartDate">
                            <ItemTemplate>

                                <%#Eval("StartDate").ToString()==""?"NA":Convert.ToDateTime(Eval("StartDate")).ToString("dd/MM/yyyy")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="EndDate" DataField="EndDate" DataType="System.String" UniqueName="EndDate">
                            <ItemTemplate>

                                <%#Eval("EndDate").ToString()==""?"NA":Convert.ToDateTime(Eval("EndDate")).ToString("dd/MM/yyyy")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>


                        <telerik:GridTemplateColumn HeaderText="Name" DataField="Name" DataType="System.String" UniqueName="Name">
                            <ItemTemplate>

                                <%#Eval("Name")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>


                        <telerik:GridTemplateColumn HeaderText="User Name" AllowFiltering="false">
                            <ItemTemplate>
                                <%#Eval("User_Name") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Password" AllowFiltering="false">
                            <ItemTemplate>
                                <%#Eval("Password") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Address" AllowFiltering="false">
                            <ItemTemplate>
                                <%#Eval("Address") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Password" AllowFiltering="false">
                            <ItemTemplate>
                                <%#Eval("ContactNo") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>



                        <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">

                                    <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("User_id")+"< "+Eval("FirstName")+"< "+Eval("LastName")+"< "+Eval("User_name")+"<"+Eval("UserCode")+"< "+ Eval("IsActive").ToString()+"<"+Eval("password")+"<"+Eval("RoleId")+"<"+Eval("Country")+"<"+Eval("State")+"<"+Eval("City")+"<"+Eval("Address")+"<"+Eval("ContactNo")%>'></asp:LinkButton>
                                    <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" Text="Edit" CommandName="Editnew"
                                        CommandArgument='<%# Eval("User_id")+"< "+Eval("FirstName")+"< "+Eval("LastName")+"< "+Eval("User_name")+"<"+Eval("UserCode")
+"< "+ Eval("IsActive").ToString()+"<"+Eval("password")+"<"+Eval("RoleId")+"<"+Eval("Country")+"<"+Eval("State")+"<"+Eval("City")+"<"+Eval("Address")
+"<"+Eval("ContactNo")+"<"+Eval("ArmyNo")+"<"+Eval("StartDate")+"<"+Eval("EndDate")%>'></asp:LinkButton>

                                </div>
                            </ItemTemplate>

                        </telerik:GridTemplateColumn>


                    </Columns>
                </MasterTableView>

            </telerik:RadGrid>


        </div>
    </div>
</asp:Content>
