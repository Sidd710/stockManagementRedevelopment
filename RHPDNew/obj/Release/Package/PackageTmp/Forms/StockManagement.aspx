<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="StockManagement.aspx.cs" Inherits="RHPDNew.Forms.StockManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--   <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>--%>
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="heading-bg">
        <div class="container">
            <h1>Manage Stock</h1>
        </div>
    </div>
    <div>
        <div class="clearfix"></div>
        <div class="container">
            <p>&nbsp;</p>
            <div style="float: right;">
                Code#
                <asp:Label ID="lblCode" runat="server" Style="font-family: 'Times New Roman'; font-size: large;"></asp:Label><br />

            </div>
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

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Depot Name:</label>
                    <asp:Label ID="lblDepuId" runat="server" Text='<%#Eval("Depu_Id") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lblDepuName" runat="server" Text='<%#Eval("Depu_Name") %>'></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Recieved From:</label>

                    <asp:ObjectDataSource ID="odsRecievedfrom" runat="server" TypeName="RHPDComponent.ManagestockComp" SelectMethod="SelectRecievedFrom"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlRecievedfrom" OnDataBound="ddlRecievedfrom_DataBound" DataSourceID="odsRecievedfrom" DataTextField="RecievedFrom" DataValueField="Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlRecievedfrom"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Commodity (Batch Name):</label>
                    <asp:TextBox ID="txtBatchname" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtBatchname" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtBatchname"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Batch No:</label>
                    <asp:TextBox ID="txtBatchNo" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtBatchNo"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">AT No:</label>
                    <asp:TextBox ID="txtATNo" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtATNo"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Driver Name:</label>
                    <asp:TextBox ID="txtDriverName" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtDriverName"></asp:RequiredFieldValidator>
                    <asp:FilteredTextBoxExtender runat="server" ID="ftetxtFirstName" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm "
                        TargetControlID="txtDriverName">
                    </asp:FilteredTextBoxExtender>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Vechicle No:</label>

                    <asp:TextBox ID="txtVechicleNo" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtVechicleNo"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Batch Description:</label>

                    <asp:TextBox ID="txtBatchdesc" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtBatchdesc" runat="server" ValidationGroup="grp" ErrorMessage="" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtBatchdesc"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Select Supplier:</label>
                    <asp:DropDownList ID="ddlSupplier" DataSourceID="sdsSupplier" OnDataBound="ddlSupplier_DataBound" DataTextField="Name" DataValueField="Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="*" ForeColor="Red"
                        InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlSupplier"></asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="sdsSupplier" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="SELECT [Id], [Name] FROM [supplier] WHERE ([IsActivated] = @IsActivated)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="True" Name="IsActivated" Type="Boolean"></asp:Parameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Product:</label>
                    <telerik:RadComboBox ID="ddlselectpro" runat="server" Width="500" Height="150" EmptyMessage="Select Product" CssClass="col-lg-4 form-control"
                        EnableLoadOnDemand="true" ShowMoreResultsBox="true"
                        EnableVirtualScrolling="true" Label="Page Methods:">
                        <WebServiceSettings Method="GetCompanyNames" Path="StockManagement.aspx" />
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="fvddlselectpro" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="ddlselectpro"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Generic Name:</label>

                    <asp:TextBox ID="txtGenericName" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="grp" ErrorMessage="" Text="*" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtGenericName"></asp:RequiredFieldValidator>
                    <%--  <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm 1234567890"
                         TargetControlID="txtGenericName"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Original Manufacture:</label>

                    <asp:TextBox ID="txtOrignalManfucture" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="grp" ErrorMessage="" Text="*" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtOrignalManfucture"></asp:RequiredFieldValidator>
                    <%--           <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm 1234567890"
                         TargetControlID="txtOrignalManfucture"></asp:FilteredTextBoxExtender>--%>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Packaging Material:</label>
                    <asp:TextBox ID="txtPackingMaterial" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtPackingMaterial"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Packaging Material Quantity:</label>
                    <asp:TextBox ID="txtPackingQuantity" class="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtPackingQuantity" runat="server" ValidationGroup="grp" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtPackingQuantity"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Authorised Unit:</label>
                    <asp:ObjectDataSource ID="odsQuantitytype" runat="server" TypeName="RHPDComponent.ManagestockComp" SelectMethod="SelectQuantityType"></asp:ObjectDataSource>
                    <asp:DropDownList ID="ddlQuantitytype" OnDataBound="ddlQuantitytype_DataBound" DataSourceID="odsQuantitytype" DataTextField="QuantityType" OnSelectedIndexChanged="ddlQuantitytype_SelectedIndexChanged" AutoPostBack="true" DataValueField="Id" runat="server" CssClass="col-lg-4 form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlDepoName" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlQuantitytype"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Sent Quantity: </label>
                    <telerik:RadNumericTextBox CssClass="col-lg-4 form-control" Style="width: 100% !important;" BorderStyle="None" ID="rtxtSentQunatity" runat="server" Type="Number" MinValue="0.0"></telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="rtxtSentQunatity"></asp:RequiredFieldValidator>
                    <%--<asp:CustomValidator ID="CustomValidator1" runat="server" ValidationGroup="grp" Display="Dynamic" OnServerValidate="CustomValidator1_ServerValidate" Text="quantity not be 0" ForeColor="Red" ControlToValidate="rtxtSentQunatity"></asp:CustomValidator>--%>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Recived Quantity: </label>
                    <telerik:RadNumericTextBox CssClass="form-control" Style="width: 100% !important;" BrderStyle="None" ID="rntbAddQuantity" runat="server" Type="Number" MinValue="0.0">
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtAddQuantity" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="rntbAddQuantity"></asp:RequiredFieldValidator>
                    <%--<asp:CustomValidator ID="ctmvQtyIssued" runat="server" ValidationGroup="grp" Display="Dynamic" OnServerValidate="ctmvQtyIssued_ServerValidate" Text="quantity not be 0" ForeColor="Red" ControlToValidate="rntbAddQuantity"></asp:CustomValidator>--%>
                </div>
            </div>

            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Recived Date:</label>
                    <asp:TextBox ID="txtRecivedDate" CssClass="col-lg-4 form-control" placeholder="Click on textbox" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" Format="dd MMM yyyy" TargetControlID="txtRecivedDate" runat="server"></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtRecivedDate"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row">
                <div class="form-group-2">

                    <label class="col-lg-2">Manufacture Date:</label>
                    <asp:TextBox ID="txMfgDate" CssClass="col-lg-4 form-control" placeholder="Click on textbox" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                    <asp:CalendarExtender ID="cetxMfgDate" Format="dd MMM yyyy" TargetControlID="txMfgDate" runat="server"></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="rfvtxtunitDesc" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txMfgDate"></asp:RequiredFieldValidator>

                </div>
            </div>

            <div class="row">
                <div class="form-group-2">

                    <label class="col-lg-2">Expiry Date:</label>
                    <asp:TextBox ID="txtExpirydate" CssClass="col-lg-4 form-control" runat="server" placeholder="Click on textbox" onKeyDown="javascript: return false;"></asp:TextBox>
                    <asp:CalendarExtender ID="cetxtExpirydate" Format="dd MMM yyyy" TargetControlID="txtExpirydate" runat="server"></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="rfvtxtExpirydate" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtExpirydate"></asp:RequiredFieldValidator>

                </div>
            </div>


            <div class="row">
                <div class="form-group-2">

                    <label class="col-lg-2">Esl Date:</label>
                    <asp:TextBox ID="txtEsldate" CssClass="col-lg-4 form-control" runat="server" placeholder="Click on textbox" onKeyDown="javascript: return false;"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" Format="dd MMM yyyy" TargetControlID="txtEsldate" runat="server"></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtEsldate"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">If any inter transfer:</label>
                    <asp:RadioButtonList ID="rblInterTransferId" runat="server" RepeatDirection="Horizontal" Style="padding: 10px;">
                        <asp:ListItem Text="ICT" Value="1"></asp:ListItem>
                        <asp:ListItem Text="IDT" Value="2"></asp:ListItem>
                        <asp:ListItem Text="NONE" Value="3" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Select Challan No or IR No:</label>
                    <asp:RadioButtonList ID="rblChallanNo" runat="server" RepeatDirection="Horizontal" Style="padding: 10px;">
                        <asp:ListItem Text="Challan No" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="IR No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:TextBox ID="txtrblNo" CssClass="col-lg-4 form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="grp" runat="server" Text="*" ErrorMessage="" ForeColor="Red" SetFocusOnError="true"
                        ControlToValidate="txtrblNo"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row" style="display: none;">
                <label class="col-lg-2">Is Active</label>
                <div class="form-group-2 col-lg-4 text-align-right padding-0">
                    <asp:CheckBox ID="chkIsActive" CssClass="cssIsActive pull-left" Checked="true" runat="server" Text="" />
                </div>
            </div>
            <div class="row">
                <label class="col-lg-2">Is Sample Sent</label>
                <div class="form-group-2 col-lg-4 text-align-right padding-0">
                    <asp:CheckBox ID="chkIsSampleSent" CssClass="cssIsActive pull-left" onclick="dis();" runat="server" Text="" />
                </div>
            </div>
            <script type="text/javascript">
                function dis() {

                    if (document.getElementById("unit").style.display == 'block') {

                        document.getElementById("unit").style.display = 'none';
                    }
                    else {

                        document.getElementById("unit").style.display = 'block';
                    }
                }
            </script>
            <div class="row">
                <div class="form-group-2" id="unit" style="display: none;">
                    <label class="col-lg-2">Unit Info:</label>

                    <asp:TextBox ID="txtUnitInfo" class="col-lg-4 form-control" runat="server"></asp:TextBox>

                </div>
            </div>
            <div class="row">
                <div class="form-group-2">
                    <label class="col-lg-2">Remarks:</label>

                    <asp:TextBox ID="txtRemarks" class="col-lg-4 form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="grp" ErrorMessage="" Text="*" ForeColor="Red"
                        SetFocusOnError="true" ControlToValidate="txtRemarks"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-2"></div>
                <div class="form-group-2 col-lg-4 text-align-right">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="grp" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    <asp:HiddenField ID="hfid" runat="server" />
                    <asp:HiddenField ID="hdstockupd" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>

            <telerik:RadGrid runat="server" ID="RadGrid" Width="100%" AutoGenerateColumns="False" AllowPaging="true" AllowAutomaticUpdate="false" AllowFilteringByColumn="false" Skin="Web20" OnItemCommand="RadGrid_ItemCommand">
                <MasterTableView DataKeyNames="BID" Caption="Stock List" CommandItemDisplay="Top" Font-Names="Arial" Font-Size="8" AllowAutomaticUpdates="false">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                    <CommandItemTemplate>
                        <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" OnClick="btnExcel_Click" CssClass="myExcelbtn" />
                    </CommandItemTemplate>
                    <Columns>

                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Container.DataSetIndex+1%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Product_ID" Visible="false" DataField="CategoryName" DataType="System.String" UniqueName="Product_ID" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <%#Eval("Product_ID")%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Batch Name & Code" DataField="BatchName" DataType="System.String" UniqueName="BatchName" Groupable="false">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblBatchCodeDesc" runat="server" Text='<%#Eval("BatchName")+""+Eval("BatchCode") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Product Name& Code" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblProCodeDesc" runat="server" Text='<%#Eval("Product_Name")+ "" +Eval("Product_Code") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Manufauture Date" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblManufautureDate" runat="server" Text='<%# Convert.ToDateTime(Eval("MFGDate")).ToString("dd MMM yyyy") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Batch No" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblBatchNo" runat="server" Text='<%#Eval("BatchNo") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="AT No" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblATNo" runat="server" Text='<%#Eval("ATNo") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Vechicle No" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblVechicleNo" runat="server" Text='<%#Eval("VechicleNo") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Driver Name" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblDriverName" runat="server" Text='<%#Eval("DriverName").ToString()==""?"NA":Eval("DriverName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Supplier Name" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblSupplierName" runat="server" Text='<%#Eval("SupplierName").ToString()==""?"NA":Eval("SupplierName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Generic Name" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblGenericName" runat="server" Text='<%#Eval("GenericName").ToString()=="" ?"NA":Eval("GenericName") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Original Manfucturing" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblOriginalManf" runat="server" Text='<%#Eval("OriginalManf").ToString()==""?"NA":Eval("OriginalManf") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Expiry Date" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblExpiryDate" runat="server" Text='<%# Convert.ToDateTime(Eval("EXPDate")).ToString("dd MMM yyyy") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText=" Stock Quantity" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity")+" "+Eval("QuantityTypeNAME") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div class="">
                                    <asp:LinkButton ID="lkactive" runat="server" ForeColor="Red" Text='<%#Eval("IsActive").ToString()=="False"?"Activate":"InActivate" %>'
                                        CausesValidation="false" CommandName="Active" CommandArgument='<%# Eval("BID")+"< "+ Eval("IsActive").ToString()%>'></asp:LinkButton>
                                   <%-- <asp:LinkButton ID="lkedit" runat="server" CausesValidation="false" ForeColor="Blue" Text="Edit" CommandName="Editnew"
                                        CommandArgument='<%# Eval("BID")+"<"+Eval("BatchName")+"<"+Eval("BatchDesc")+"<"+Eval("MFGDate")+"<"+Eval("EXPDate")+"<"+ 
                                    Eval("IsActive").ToString()+"<"+Eval("QuantityType")+"<"+Eval("Product_ID")+"<"+Eval("RecievedFrom")+"<"
                                    +Eval("BatchNo")+"<"+Eval("ATNo")+"<"+Eval("VechicleNo")+"<"+Eval("SID")+"<"+Eval("Esl")+"<"+Eval("Quantity")
                                    +"<"+Eval("DriverName")+"<"+Eval("SupplierId")+"<"+Eval("GenericName")+"<"+Eval("OriginalManf")
                                    +"<"+Eval("SentQty")+"<"+Eval("RecievedOn")+"<"+Eval("InterTransferId")+"<"+Eval("IsIrNo")+"<"+Eval("IsChallanNo")+"<"+Eval("ChallanOrIrNo")
                                    +"<"+Eval("Remarks")  +"<"+Eval("PackingMaterial")+"<"+Eval("PackingQuantity")
                                    %>'></asp:LinkButton>--%>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>

    <!----- Content Ends ----->
</asp:Content>
