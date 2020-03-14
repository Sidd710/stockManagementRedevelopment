<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="ManageTallySheets.aspx.cs" Inherits="RHPDNew.Forms.ManageTallySheets" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../js/jquery.js"></script>
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <%--<script>
        function name() {
            alert('Name is also exists');

        }
          </script>--%>

    <div class="heading-bg">
        <div class="container">
            <h1>Manage Tally Sheet</h1>
        </div>
    </div>
    <div>
        <div class="clearfix"></div>
        <div style="float: left; margin-left: 20%;">
          <%--  Code#--%>
            <%--<asp:Label ID="lblCode" runat="server" Text="LT NO:03 DT-30/10/14" Style="font-family: 'Times New Roman'; font-size: large;"></asp:Label><br />--%>

        </div>

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
            
                
            <div class="row" style="">
                <div class="form-group-2">
                    <label class="col-lg-2">From :</label>
                    <asp:ObjectDataSource ID="odsFrom" runat="server" TypeName="RHPDComponent.TallySheetComponent" SelectMethod="getrecord"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlFrom"  Enabled="false" CssClass="col-lg-4 form-control" OnDataBound="ddlFrom_DataBound" runat="server" DataSourceID="odsFrom" DataTextField="Depu_Name" DataValueField="Depu_Id" AutoPostBack="true">
                    </asp:DropDownList>

                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="RHPDComponent.TallySheetComponent" SelectMethod="GetUnitByDID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlFrom" PropertyName="SelectedValue" Name="dID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>


                </div>
            </div>


            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">To:</label>
                    <asp:ObjectDataSource ID="odsddlTo" runat="server" TypeName="RHPDComponent.TallySheetComponent" SelectMethod="getrecord"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlTo" CssClass="col-lg-4 form-control"  Enabled="false" OnDataBound="ddlTo_DataBound1" runat="server" DataSourceID="odsddlTo" DataTextField="Depu_Name" DataValueField="Depu_Id" AutoPostBack="true">
                    </asp:DropDownList>

                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Unit To(If Any):</label>
                    <asp:DropDownList ID="DropDownList2" Enabled="false" CssClass="col-lg-4 form-control" OnDataBound="DropDownList2_DataBound" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Unit_Name" DataValueField="Unit_Id" AutoPostBack="true">
                    </asp:DropDownList>
                   <%-- <asp:RequiredFieldValidator ID="rfvddlTo" ErrorMessage="*" InitialValue="-- Select --" ValidationGroup="grp" runat="server" ForeColor="Red" SetFocusOnError="true" ControlToValidate="DropDownList2"></asp:RequiredFieldValidator>--%>
                      <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="RHPDComponent.TallySheetComponent" SelectMethod="GetUnitByDID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlTo" PropertyName="SelectedValue" Name="dID" Type="Int32" DefaultValue="0"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Authority No:</label>
                    <asp:TextBox CssClass="col-lg-4 form-control" ID="txtAuth" runat="server"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtAuth" ValidationGroup="grp" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtAuth"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">

                    <label class="col-lg-2">Through:</label>
                    <asp:TextBox ID="txtThrough" CssClass="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtThrough" ValidationGroup="grp" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtThrough"></asp:RequiredFieldValidator>

                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Vehicle No:</label>
                    <%-- <div class="form-group-2 col-lg-4 text-align-right padding-0">  --%>
                    <asp:TextBox ID="txtVehicleNo" CssClass="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvVehicle" ValidationGroup="grp" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtVehicleNo"></asp:RequiredFieldValidator>

                </div>
            </div>




            <div class="row">
                <div class="col-lg-2"></div>
                <div class="form-group-2 col-lg-4 text-align-right">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" ValidationGroup="grp" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>

            <telerik:RadGrid runat="server" ID="RadGrid" Width="100%" AutoGenerateColumns="False" AllowPaging="true"
                AllowAutomaticUpdate="false" AllowFilteringByColumn="false" Skin="Web20">
                <MasterTableView DataKeyNames="indentid" Caption="Manage Tally Sheet" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="8" AllowAutomaticUpdates="false">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                    <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" CssClass="myExcelbtn" />
                    </CommandItemTemplate>
                    <Columns>

                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Commodity" DataField="productname" DataType="System.String" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("productname")%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="A/U" DataField="AUnitName" DataType="System.String" UniqueName="BatchName" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%-- <%#Eval("BatchName").ToString()==""?"N/A":Eval("BatchName") %>--%>
                                    <asp:Label ID="lblAUnitName" runat="server" Text='<%#Convert.ToString(Eval("AuUnitName"))==""?"N/A":Eval("AuUnitName")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Qty" DataField="qty" DataType="System.Decimal" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("qty")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="DOM" DataField="domdate" DataType="System.DateTime" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">

                                    <asp:Label ID="lblManufautureDate" runat="server" Text='<%# Convert.ToDateTime(Eval("MFGDate")).ToString("dd MMM yyyy") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="ESL" DataField="esldate" DataType="System.DateTime" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">

                                    <asp:Label ID="lblesldate" runat="server" Text='<%# Convert.ToDateTime(Eval("esldate")).ToString("dd MMM yyyy") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>


                    </Columns>
                </MasterTableView>

            </telerik:RadGrid>



        </div>
    </div>
</asp:Content>
