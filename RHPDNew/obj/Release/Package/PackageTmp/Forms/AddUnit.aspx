<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="AddUnit.aspx.cs" Inherits="RHPDNew.Forms.AddUnit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="heading-bg" align="center" >
            <div class="container">
                <h1  style="background-color:skyblue;color:white">Manage Units</h1>
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
                <div class="form-group-2">
                    <asp:ValidationSummary ID="valSum" ValidationGroup="grp"
                        DisplayMode="SingleParagraph"
                        EnableClientScript="true"
                        HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                        runat="server" />
                </div>
            </div>
            
            <div class="row marginbottom10">
               <div class="col-five">
                    <label class="form_text">Depot:</label>
                    <asp:ObjectDataSource ID="odsDepot" runat="server" TypeName="RHPDComponent.AddUnitComp" SelectMethod="getrecord"></asp:ObjectDataSource>
                    <asp:DropDownList OnDataBound="ddlselectdepu_DataBound" ID="ddlselectdepu" CssClass="form-control" runat="server" DataSourceID="odsDepot" DataTextField="Depu_Name" DataValueField="Depu_Id">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ValidationGroup="grp" InitialValue="-- Select --" ID="rfvddlselectdepu" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlselectdepu"></asp:RequiredFieldValidator>
                </div>
                <div class="col-five">
                    <label class="form_text">Unit Type:</label>
                    <asp:RadioButtonList DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" CssClass="unitType" runat="server" ID="rbtUnitType" DataTextField="Name"  DataValueField="Id"></asp:RadioButtonList>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                         ControlToValidate="rbtUnitType"></asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="SELECT * FROM [UnitType] WHERE ([IsActive] = @IsActive)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean"></asp:Parameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                   <%-- <asp:TextBox CssClass="col-lg-4 form-control" ID="txtUnitName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rfvtxtunitName" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtUnitName"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender runat="server" ID="fteName" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtUnitName"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>
              <div class="row marginbottom10">
                <div class="col-five">
                    <label class="form_text">Name:</label>
                     <asp:TextBox CssClass="form-control" ID="txtUnitName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rfvtxtunitName" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtUnitName"></asp:RequiredFieldValidator>
                   <%-- <asp:FilteredTextBoxExtender runat="server" ID="fteName" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm " TargetControlID="txtUnitName"></asp:FilteredTextBoxExtender>--%>
                </div>
                <div class="col-five">
                    <label class="form_text">Description:</label>
                    <asp:TextBox ID="txUnitDesc" CssClass="form-control" TextMode="MultiLine" runat="server" Style="resize: none;"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="grp" ID="rfvtxtunitDesc" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txUnitDesc"></asp:RequiredFieldValidator>
                 <%--   <asp:FilteredTextBoxExtender runat="server" ID="fteDescription" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm. " TargetControlID="txUnitDesc"></asp:FilteredTextBoxExtender>--%>
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
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" OnClick="btnClear_Click" runat="server" Text="Clear" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>

            <asp:ObjectDataSource ID="objUnit" runat="server" TypeName="RHPDComponent.AddUnitComp" SelectMethod="GridDisplayComponent"></asp:ObjectDataSource>
            <telerik:RadGrid runat="server" DataSourceID="objUnit" ID="RadGrid" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="RadGrid_ItemCommand">
                <MasterTableView DataKeyNames="Unit_ID" Caption="Unit List" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="9">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                    <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                    </CommandItemTemplate>

                    <GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Depu_Name" HeaderValueSeparator=":" SortOrder="Descending" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Depu_Name" HeaderText="Depot Name" />
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

                        <%--  <telerik:GridTemplateColumn HeaderText="Depot Name" DataField="CategoryName" DataType="System.String" UniqueName="Category_Name" Groupable="false">
                                <ItemTemplate>
                                    <div class="">
                                        <%#Eval("Depu_Name")%>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                           <telerik:GridTemplateColumn HeaderText="Command Name" DataField="CommandName" DataType="System.String" UniqueName="CommandName" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("CommandName").ToString()==""?"N/A":Eval("CommandName") %>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                         <telerik:GridTemplateColumn HeaderText="Formation Name" DataField="FormationName" DataType="System.String" UniqueName="FormationName" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("FormationName").ToString()==""?"N/A":Eval("FormationName") %>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Code" AllowFiltering="false" Visible="false">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblUnitCode" runat="server" Text='<%#Eval("Unit_Code") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Unit Name" DataField="CategoryName" DataType="System.String" UniqueName="Category_Name" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("Unit_Name").ToString()==""?"N/A":Eval("Unit_Name") %>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Description" AllowFiltering="false">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblunitDesc" runat="server" Text='<%#Eval("Unit_Desc") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false">
                            <ItemTemplate>
                                <div class="">
                                    <asp:LinkButton ID="lkactive" runat="server" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>' CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("Unit_Id")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" Text="Edit" CommandName="Editnew"
                                        CommandArgument='<%# Eval("Unit_id")+"< "+Eval("Unit_Name")+"<"+Eval("Unit_Desc")+
                                    "< "+ Eval("IsActive").ToString()+"<"+Eval("Depu_Name")+"<"+Eval("Unit_Code")+"<"+Eval("Depu_Id")+
                                    "<"+Eval("Command")+"<"+Eval("Formation")+"<"+Eval("UnitType")%>'></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
</asp:Content>
