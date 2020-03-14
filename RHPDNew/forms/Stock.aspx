<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="RHPDNew.Forms.Stock" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="heading-bg" align="center">

        <div class="container">
            <h1 style="background-color: skyblue; color: white">Manage Stock-IN</h1>
        </div>
    </div>
    <br />
    <br />
    <style>
        body {
            background: url(../assets/images/flag.jpg) no-repeat;
            background-size: cover;
        }
    </style>
    <div class="container-fluid form-outer">


        <asp:HiddenField ID="hdnEditStock" runat="server" Value="0" />
        <asp:HiddenField ID="hdnStockID" runat="server" Value="0" />
        <asp:HiddenField ID="hdnBatchId" runat="server" Value="0" />
        <asp:HiddenField ID="hdnVehicle" runat="server" Value="0" />
        <asp:HiddenField ID="hdnSpillageDone" runat="server" Value="0" />
        <asp:HiddenField ID="hdnLevel" runat="server" Value="0" />

        <asp:Accordion ID="accData" runat="server" HeaderCssClass="Header" ContentCssClass="Contents" HeaderSelectedCssClass="SelectedHeader" Font-Names="Verdana" Font-Size="10" BorderColor="#000000" BorderStyle="Solid" BorderWidth="1" FramesPerSecond="100"
            FadeTransitions="true" TransitionDuration="500">
            <Panes>
                <asp:AccordionPane ID="apStock" runat="server">
                    <Header>Stock </Header>
                    <Content>
                        <p>Stock <%=stcokCase%>:</p>

                        <telerik:RadGrid Visible="false" ClientSettings-EnablePostBackOnRowClick="true" ID="rgdStockList" runat="server"
                            GridLines="None" AutoGenerateColumns="False"
                            Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="false" OnSelectedIndexChanged="rgdStockList_SelectedIndexChanged" ClientSettings-Selecting-AllowRowSelect="true">

                            <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="top" ShowFooter="false">
                                <CommandItemTemplate>
                                    <asp:Button ID="btnNEwStock" runat="server" OnClick="btnNewProduct_Click" Text="Add New Product" />
                                </CommandItemTemplate>
                                <Columns>


                                    <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                        <ItemTemplate>
                                            <div class="">
                                                <%#Container.DataSetIndex + 1%>
                                            </div>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="AT/SO No" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                                        <ItemTemplate>
                                            <%-- <%# (Eval("ATNo").ToString()==""? "Supply Order NO:":"AT NO:")%>--%>


                                            <asp:Label runat="server" ID="nn" Text='<%#Eval("ATSONo")%>' Style="height: 100%; width: 55px; word-wrap: break-word; display: block"></asp:Label>

                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>


                                    <telerik:GridTemplateColumn HeaderText="Product" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                                        <ItemTemplate>
                                            <%#Eval("ITEMS")%>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                                        <ItemTemplate>
                                            <%#Eval("AU")%>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Recieved From" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                                        <ItemTemplate>
                                            <%#Eval("RecievedFrom")%>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Other Supplier " DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                                        <ItemTemplate>
                                            <%#Eval("OtherSupplier")%>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Other manufacture " DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                                        <ItemTemplate>
                                            <%#Eval("OriginalManf")%>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Generic Name " DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                                        <ItemTemplate>
                                            <%#Eval("GenericName")%>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Packaging Material " DataField="AU" DataType="System.String" UniqueName="AU">
                                        <ItemTemplate>

                                            <%#Eval("PackingMaterial")%><%#(Eval("PackingMaterialFormat").ToString() == "" ? "" : "[" + Eval("PackingMaterialFormat") + "]")%>
                                            <br />

                                            <%#(Convert.ToBoolean(Eval("IsWithoutPacking").ToString()) == true ? "" : "Shape & size:" + Eval("PackagingMaterialShape") + " & " + Eval("PackagingMaterialSize") + " " + Eval("ShapeUnit") + "<br />")%>
       
      Weight: <%#Eval("Weight")%>&nbsp <%#Eval("WeigthUnit")%> per  PM

                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>


                                    <telerik:GridTemplateColumn HeaderText="Sub Packaging Material " DataField="AU" DataType="System.String" UniqueName="AU">
                                        <ItemTemplate>


                                            <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString()) == false ? "" : "Name: " + Eval("SubPackingMaterial"))%><br />

                                            <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString()) == false ? "" : Eval("SubPMShape").ToString() != "" ? "Shape & Size: " + Eval("SubPMShape") + " & " + Eval("SubPMSize") + " " + Eval("SubShapeUnit") : "")%><br />


                                            <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString()) == false ? "" : (Eval("SubWeight").ToString() != "" ? " Weight: " + TruncateDecimalToString(Convert.ToDouble(Eval("SubWeight")), 3) + "  " + Eval("SubWeightUnit") : "") + "<br />")%>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>








                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Rate" DataField="CostOfParticular" DataType="System.Int32" UniqueName="CostOfParticular">
                                        <ItemTemplate>


                                            <%#(Eval("CostOfParticular").ToString() == "0" ? "-" : TruncateDecimalToString(Convert.ToDouble(Eval("CostOfParticular").ToString()), 2))%> per  <%#Eval("AU")%>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Amount" DataField="Amount" DataType="System.Int32" UniqueName="Amount">
                                        <ItemTemplate>
                                            <%#((Convert.ToDouble(Eval("CostOfParticular").ToString()) * Convert.ToDouble(Eval("Quantity").ToString())).ToString() == "0" ? "-" : TruncateDecimalToString((Convert.ToDouble(Eval("CostOfParticular").ToString()) * Convert.ToDouble(Eval("Quantity").ToString())), 2))%>
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>


                                    <telerik:GridTemplateColumn HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button OnClientClick="return confirm('Are you sure you want to Delete?');" runat="server" ID="btnSubmitCRV" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("SID")%>' OnClick="btnSubmitCRV_Click1" />
                                        </ItemTemplate>

                                    </telerik:GridTemplateColumn>





                                </Columns>

                                <FooterStyle HorizontalAlign="left" />
                                <CommandItemStyle HorizontalAlign="Left" />
                            </MasterTableView>
                        </telerik:RadGrid>

                        <div class="forming_texting" runat="server" id="divStock">
                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updSt">
                                <ProgressTemplate>

                                    <div class="full-pop-up">
                                        <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>

                            <asp:UpdatePanel runat="server" ID="updSt">
                                <ContentTemplate>


                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:ValidationSummary ID="valSum" ValidationGroup="grp"
                                                DisplayMode="SingleParagraph"
                                                EnableClientScript="true"
                                                HeaderText="(*) indicates fields are required, you must enter a value in the following fields:"
                                                runat="server" />
                                        </div>
                                    </div>
                                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                                        <AjaxSettings>
                                            <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                                <UpdatedControls>
                                                    <telerik:AjaxUpdatedControl ControlID="rdxAtNo" LoadingPanelID="RadAjaxLoadingPanel1" />
                                                </UpdatedControls>
                                            </telerik:AjaxSetting>
                                        </AjaxSettings>
                                    </telerik:RadAjaxManager>
                                    <telerik:RadAjaxManager ID="rdProduct" runat="server">
                                        <AjaxSettings>
                                            <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                                <UpdatedControls>
                                                    <telerik:AjaxUpdatedControl ControlID="adProduct" LoadingPanelID="RadAjaxLoadingPanel1" />
                                                </UpdatedControls>
                                            </telerik:AjaxSetting>
                                        </AjaxSettings>
                                    </telerik:RadAjaxManager>

                                    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" />
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1"
                                        ConnectionString="<%$ ConnectionStrings:con %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="select distinct ATNo from stockmaster where ATNo <> ''"></asp:SqlDataSource>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2"
                                        ConnectionString="<%$ ConnectionStrings:con %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="select distinct SupplierNo from stockmaster where SupplierNo <> ''"></asp:SqlDataSource>
                                    <div class="col-md-12 main-feild">
                                        <div class="row marginbottom10">

                                            <div class="col-five">
                                                <label class="form_text">If any Transfer:</label>
                                                <asp:RadioButtonList TabIndex="1" ID="rbtnListTransferedBy" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="None" Value="None" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="IDT" Value="IDT"></asp:ListItem>
                                                    <asp:ListItem Text="ICT" Value="ICT"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="col-five">
                                                <label class="form_text">Session:</label>
                                                <asp:DropDownList runat="server" ID="ddlSession" Width="70" AutoPostBack="true" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                </asp:DropDownList><asp:Label runat="server" ID="lblSession"></asp:Label>
                                            </div>

                                        </div>
                                        <div class="row marginbottom10">

                                            <table style="width: 91%; float: right">

                                                <tr>
                                                    <td style="width: 47%">
                                                        <label class="form_text">AT No or Supply Order No:</label>
                                                        <asp:Label CssClass="form_text" ID="lblATNo" runat="server" Style="height: 100%; width: 400px; word-wrap: break-word; display: block"></asp:Label><br />
                                                        <asp:Label ID="lblSupNo" runat="server" Style="height: 100%; width: 400px; word-wrap: break-word; display: block"></asp:Label><br />
                                                    </td>

                                                    <td>
                                                        <asp:UpdatePanel ID="ATSO" runat="server">
                                                            <ContentTemplate>


                                                                <asp:RadioButtonList TabIndex="2" ID="rbATNoSupNo" runat="server" RepeatDirection="Horizontal" Style="background: rgba(0, 0, 0, 0) none repeat scroll 0 0 !important; border: 0 none  !important; width: 325px  !important; font-size: 12px !important;"
                                                                    OnSelectedIndexChanged="rbATNoSupNo_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Text="AT No" Value="1" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Supply Order No" Value="2"></asp:ListItem>

                                                                </asp:RadioButtonList>
                                                                <br />


                                                                <telerik:RadAutoCompleteBox TabIndex="3" Style="margin-top: -17px; width: 325px;" RenderMode="Lightweight" runat="server" ID="rdxAtNo" EmptyMessage="Please type AT No. here"
                                                                    DataSourceID="SqlDataSource1" DataTextField="ATNo" InputType="Text" Width="283" Delimiter="," DropDownWidth="150px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                                </telerik:RadAutoCompleteBox>
                                                                <asp:RequiredFieldValidator ID="reqATNo" ValidationGroup="grp" runat="server" ErrorMessage="AT No," Text="***" ForeColor="Red" SetFocusOnError="true" ControlToValidate="rdxAtNo"></asp:RequiredFieldValidator>
                                                                <telerik:RadAutoCompleteBox TabIndex="3" Style="margin-top: -17px; width: 325px;" Visible="false" Delimiter="," RenderMode="Lightweight" runat="server" ID="rdxSupplierNo" EmptyMessage="Please type Supply Order No. here"
                                                                    DataSourceID="SqlDataSource2" DataTextField="ATNo" InputType="Text" Width="283" DropDownWidth="150px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                                </telerik:RadAutoCompleteBox>
                                                                <asp:RequiredFieldValidator Enabled="false" ID="reqSup" ValidationGroup="grp" runat="server" ErrorMessage="Supply Order No," Text="***" ForeColor="Red" SetFocusOnError="true" ControlToValidate="rdxSupplierNo"></asp:RequiredFieldValidator>

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>



                                                    </td>
                                                </tr>

                                            </table>

                                        </div>

                                        <div class="row marginbottom10">
                                            <script type="text/javascript">
                                                function _CheckEntry(sender, eventArgs) {
                                                    alert("dc");

                                                    if (sender.get_entries().get_count() > 0) {
                                                        eventArgs.set_cancel(true);
                                                        alert("You can select only one Product");

                                                    }
                                                }
                                            </script>
                                            <div class="col-five">
                                                <label class="form_text">Product<asp:Label ID="lblProduct" runat="server"></asp:Label>:</label>
                                                <asp:HiddenField ID="hdnCatID" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnPID" runat="server" Value="0" />

                                                <telerik:RadAutoCompleteBox Delimiter="," TabIndex="4" Style="width: 500px;" RenderMode="Lightweight" runat="server" ID="adProduct" EmptyMessage="Please type Product Name here"
                                                    DataSourceID="sqlProduct" DataTextField="Product_Name" DataValueField="Product_ID" InputType="Text" TokensSettings-AllowTokenEditing="false" Width="500" DropDownWidth="300px" TextSettings-SelectionMode="Single" AllowCustomEntry="false">
                                                </telerik:RadAutoCompleteBox>
                                                <asp:RequiredFieldValidator InitialValue="" ID="prprprr" ValidationGroup="grp" runat="server" ErrorMessage="Product," Text="***" ForeColor="Red" SetFocusOnError="true"
                                                    ControlToValidate="adProduct"></asp:RequiredFieldValidator>

                                                <%--     <asp:DropDownList OnDataBound="ddlProduct_DataBound" ID="ddlProduct" runat="server" DataSourceID="sqlProduct" DataTextField="Product_Name" CssClass="form-control" DataValueField="Product_ID"></asp:DropDownList>--%>
                                                <asp:SqlDataSource ID="sqlProduct" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="SELECT * FROM [ProductMaster] WHERE ([IsActive] = @IsActive) order by Product_Name">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean"></asp:Parameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:SqlDataSource ID="sqlProductCat" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="SELECT * FROM [ProductMaster] WHERE ([IsActive] = @IsActive and Category_Id=@CatID) order by Product_Name">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean"></asp:Parameter>
                                                        <asp:ControlParameter ControlID="hdnCatID" Name="CatID" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>


                                            <div class="col-five">
                                                <label class="form_text">
                                                    Supplier Name:<asp:Label runat="server" ID="lblSupplier"></asp:Label>
                                                    <asp:HiddenField runat="server" ID="hdnSupplier" />
                                                </label>
                                                <telerik:RadAutoCompleteBox TabIndex="5" Style="width: 500px;" RenderMode="Lightweight" runat="server" ID="rdaSupplier" EmptyMessage="Please type Supplier Name here"
                                                    DataSourceID="sqlSupplier" DataTextField="Name" DataValueField="Name" InputType="Text" Width="500" DropDownWidth="300px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                </telerik:RadAutoCompleteBox>
                                                <asp:SqlDataSource ID="sqlSupplier" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="select * from supplier where IsActivated= @IsActive order by Name">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean"></asp:Parameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <%-- <asp:TextBox CssClass="form-control" ID="txtSupplierName" runat="server"></asp:TextBox>--%>
                                                <asp:RequiredFieldValidator ControlToValidate="rdaSupplier" ID="reqSupplier" ValidationGroup="grp" runat="server" ErrorMessage="Supplier Name," Text="***" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-five">
                                                <label class="form_text">
                                                    Original manufacture:<asp:Label runat="server" ID="lblOM"></asp:Label>
                                                    <asp:HiddenField runat="server" ID="hdnOM" />
                                                </label>

                                                <telerik:RadAutoCompleteBox DropDownPosition="Static" TabIndex="6" Style="width: 500px;" RenderMode="Lightweight" runat="server" ID="txtOriginalManufacture" EmptyMessage="Please type Original manufacture here" DataSourceID="sqlOM" DataTextField="Name" DataValueField="Name" InputType="Text" Width="500" DropDownWidth="300px" TextSettings-SelectionMode="Single" AllowCustomEntry="true"></telerik:RadAutoCompleteBox>
                                                <asp:SqlDataSource ID="sqlOM" runat="server" ConnectionString='<%$ ConnectionStrings:con %>' SelectCommand="select Name from OriginalManufacture  where Isactivated=1 order by name "></asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ControlToValidate="txtOriginalManufacture" ID="rqOM" ValidationGroup="grp" runat="server" ErrorMessage="Original manufacture," Text="***" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                            </div>


                                            <div class="col-five">
                                                <label class="form_text">Received Date:</label>
                                                <telerik:RadDatePicker TabIndex="8" Culture="en-US" RenderMode="Lightweight" ID="txtReceivedDate" Width="250px" Height="28px" runat="server" DateInput-DateFormat="dd-MM-yyyy">
                                                </telerik:RadDatePicker>
                                                <%-- <asp:TextBox ID="txtReceivedDate" CssClass="form-control" placeholder="Click on textbox" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" Format="dd MM yyyy" TargetControlID="txtReceivedDate" runat="server"></asp:CalendarExtender>
                                                --%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="grp" runat="server" Text="***" ErrorMessage="Received Date," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtReceivedDate"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                        <div class="row marginbottom10">
                                            <div class="col-five">
                                                <label class="form_text">Remarks:</label>
                                                <asp:TextBox Width="250px" TabIndex="9" TextMode="MultiLine" ID="txtRemarks" runat="server"></asp:TextBox>

                                            </div>
                                        </div>




                                        <div style="align-content: center; margin-left: 6%">

                                            <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
                                                <AjaxSettings>
                                                    <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                                        <UpdatedControls>
                                                            <telerik:AjaxUpdatedControl ControlID="txtPackingMaterial" LoadingPanelID="RadAjaxLoadingPanel1" />
                                                        </UpdatedControls>
                                                    </telerik:AjaxSetting>
                                                </AjaxSettings>
                                            </telerik:RadAjaxManager>
                                            <telerik:RadAjaxManager ID="RadAjaxManager3" runat="server">
                                                <AjaxSettings>
                                                    <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                                        <UpdatedControls>
                                                            <telerik:AjaxUpdatedControl ControlID="txtCapacity" LoadingPanelID="RadAjaxLoadingPanel1" />
                                                        </UpdatedControls>
                                                    </telerik:AjaxSetting>
                                                </AjaxSettings>
                                            </telerik:RadAjaxManager>
                                            <telerik:RadAjaxManager ID="RadAjaxManager4" runat="server">
                                                <AjaxSettings>
                                                    <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                                        <UpdatedControls>
                                                            <telerik:AjaxUpdatedControl ControlID="txtGrade" LoadingPanelID="RadAjaxLoadingPanel1" />
                                                        </UpdatedControls>
                                                    </telerik:AjaxSetting>
                                                </AjaxSettings>
                                            </telerik:RadAjaxManager>
                                            <telerik:RadAjaxManager ID="RadAjaxManager5" runat="server">
                                                <AjaxSettings>
                                                    <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                                        <UpdatedControls>
                                                            <telerik:AjaxUpdatedControl ControlID="txtCondition" LoadingPanelID="RadAjaxLoadingPanel1" />
                                                        </UpdatedControls>
                                                    </telerik:AjaxSetting>
                                                </AjaxSettings>
                                            </telerik:RadAjaxManager>


                                            <asp:SqlDataSource runat="server" ID="sqlName"
                                                ConnectionString="<%$ ConnectionStrings:con %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select Name from PMNames order by Name"></asp:SqlDataSource>
                                            <asp:SqlDataSource runat="server" ID="sqlCapacity"
                                                ConnectionString="<%$ ConnectionStrings:con %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select Unit as Data from pmcapacity order by Capacity "></asp:SqlDataSource>
                                            <asp:SqlDataSource runat="server" ID="sqlGrade"
                                                ConnectionString="<%$ ConnectionStrings:con %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select Grade from PMGrade order by Grade"></asp:SqlDataSource>
                                            <asp:SqlDataSource runat="server" ID="sqlCondition"
                                                ConnectionString="<%$ ConnectionStrings:con %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select condition from pmcondition order by condition"></asp:SqlDataSource>

                                            <asp:Panel runat="server" GroupingText="" BorderStyle="none" Width="80%">
                                                <asp:UpdateProgress ID="UpdateProgress7" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updPacking">
                                                    <ProgressTemplate>

                                                        <div class="full-pop-up">
                                                            <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                                        </div>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                                <asp:UpdatePanel runat="server" ID="updPacking">
                                                    <ContentTemplate>
                                                        <asp:RadioButtonList TabIndex="10" Style="margin-bottom: 10px; width: 1006px;" RepeatDirection="Horizontal" runat="server" ID="rbtnPacking" OnSelectedIndexChanged="rbtnPacking_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="Product with Packaging" Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Packaging without Product" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Product without Packaging" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:Panel runat="server" ID="pnlPMName">
                                                            <table style="width: 100%">

                                                                <tr>
                                                                    <td>
                                                                        <label>Material Name<br />
                                                                            <asp:Label ID="lblPMName" runat="server"></asp:Label></label></td>
                                                                    <td>
                                                                        <label>Capacity<br />
                                                                            <asp:Label ID="lblPMCapacity" runat="server"></asp:Label></label></td>
                                                                    <td>
                                                                        <label>Grade<br />
                                                                            <asp:Label ID="lblPMGrade" runat="server"></asp:Label></label></td>
                                                                    <td>
                                                                        <label>Condition<br />
                                                                            <asp:Label ID="lblPMCondition" runat="server"></asp:Label></label></td>

                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:HiddenField Value="" ID="hdnPMName" runat="server" />
                                                                        <telerik:RadAutoCompleteBox TabIndex="11" Style="width: 88%;" RenderMode="Lightweight" runat="server" ID="txtPackingMaterial" DataSourceID="sqlName" DataTextField="Name" InputType="Text" Width="283" DropDownWidth="150px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                                        </telerik:RadAutoCompleteBox>

                                                                        <asp:RequiredFieldValidator ID="rqPMName" runat="server" ValidationGroup="grp" Text="***" ErrorMessage="Material Name," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtPackingMaterial"></asp:RequiredFieldValidator>

                                                                    </td>
                                                                    <td>
                                                                        <asp:HiddenField Value="" ID="hdnPMCapacity" runat="server" />
                                                                        <telerik:RadAutoCompleteBox TabIndex="12" Style="width: 88%;" RenderMode="Lightweight" runat="server" ID="txtCapacity"
                                                                            DataSourceID="sqlCapacity" DataTextField="Data" InputType="Text" Width="283" DropDownWidth="150px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                                        </telerik:RadAutoCompleteBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:HiddenField Value="" ID="hdnPMGrade" runat="server" />
                                                                        <telerik:RadAutoCompleteBox TabIndex="13" Style="width: 88%;" RenderMode="Lightweight" runat="server" ID="txtGrade"
                                                                            DataSourceID="sqlGrade" DataTextField="Grade" InputType="Text" Width="283" DropDownWidth="150px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                                        </telerik:RadAutoCompleteBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:HiddenField Value="" ID="hdnPMCondition" runat="server" />
                                                                        <telerik:RadAutoCompleteBox TabIndex="14" Style="width: 88%;" RenderMode="Lightweight" runat="server" ID="txtCondition"
                                                                            DataSourceID="sqlCondition" DataTextField="condition" InputType="Text" Width="283" DropDownWidth="150px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                                        </telerik:RadAutoCompleteBox>
                                                                    </td>

                                                                </tr>
                                                            </table>



                                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updShape">
                                                                <ProgressTemplate>

                                                                    <div class="full-pop-up">
                                                                        <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                                                    </div>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>

                                                            <asp:UpdatePanel runat="server" ID="updShape">
                                                                <ContentTemplate>
                                                                    <div class="row marginbottom10">
                                                                        <label class="form_text">Shape & Size:</label>
                                                                        <table style="width: 50%; grid-columns: none">
                                                                            <tr>
                                                                                <td style="width: 100px;">
                                                                                    <asp:DropDownList TabIndex="15" Style="width: 100px;" AutoPostBack="true" CssClass="form-control" ID="ddlShape" runat="server" OnSelectedIndexChanged="ddlShape_SelectedIndexChanged"></asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 50%;">




                                                                                    <div id="dvShpere" runat="server" visible="false">

                                                                                        <telerik:RadNumericTextBox TabIndex="16" NumberFormat-DecimalDigits="3" runat="server" ID="txtSpRadius" placeholder="Enter radius" Height="35" Width="75"></telerik:RadNumericTextBox>
                                                                                    </div>
                                                                                    <div id="dvCuboid" visible="false" runat="server">
                                                                                        <table style="width: 12%;">
                                                                                            <tr>
                                                                                                <td style="width: 30%;">
                                                                                                    <telerik:RadNumericTextBox TabIndex="17" NumberFormat-DecimalDigits="3" runat="server" ID="txtCblength" placeholder="Enter length" Height="35" Width="75"></telerik:RadNumericTextBox>
                                                                                                </td>
                                                                                                <td style="width: 30%;">
                                                                                                    <telerik:RadNumericTextBox TabIndex="18" NumberFormat-DecimalDigits="3" runat="server" ID="txtCbbreadth" placeholder="Enter breadth " Height="35" Width="85"></telerik:RadNumericTextBox>
                                                                                                </td>
                                                                                                <td style="width: 30%;">
                                                                                                    <telerik:RadNumericTextBox TabIndex="19" NumberFormat-DecimalDigits="3" runat="server" ID="txtCbheight" placeholder="Enter height " Height="35" Width="75"></telerik:RadNumericTextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                    <div id="dvCylinder" visible="false" runat="server">

                                                                                        <telerik:RadNumericTextBox TabIndex="17" NumberFormat-DecimalDigits="3" runat="server" ID="txtCyRadius" placeholder="Enter radius" Height="35" Width="75"></telerik:RadNumericTextBox>
                                                                                        <telerik:RadNumericTextBox TabIndex="18" NumberFormat-DecimalDigits="3" runat="server" ID="txtCyHeight" placeholder="Enter height" Height="35" Width="75"></telerik:RadNumericTextBox>
                                                                                    </div>
                                                                                    <div id="dvCube" visible="false" runat="server">

                                                                                        <telerik:RadNumericTextBox TabIndex="17" NumberFormat-DecimalDigits="3" runat="server" ID="txtCubeEdge" placeholder="Enter edge " Height="35" Width="75"></telerik:RadNumericTextBox>
                                                                                    </div>
                                                                                    <div id="dvOther" visible="false" runat="server">
                                                                                        <asp:TextBox runat="server" TabIndex="17" ID="txtOtherArea" placeholder="Enter other info"></asp:TextBox>
                                                                                    </div>

                                                                                </td>
                                                                                <td style="width: 30%;">
                                                                                    <asp:DropDownList TabIndex="20" Style="width: 70px;" ID="ddlUnit" runat="server" CssClass="form-control" Visible="false">

                                                                                        <asp:ListItem Text="cm" Value="cm" Selected="True"></asp:ListItem>
                                                                                        <asp:ListItem Text="ft" Value="ft"></asp:ListItem>
                                                                                        <asp:ListItem Text="sq ft" Value="sq ft"></asp:ListItem>
                                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                        </table>


                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </asp:Panel>
                                                        <div class="row marginbottom10">
                                                            <label class="form_text"></label>
                                                            <asp:CheckBox runat="server" TabIndex="21" ID="cbxDW" Text=" DW" OnCheckedChanged="cbxDW_CheckedChanged" AutoPostBack="true" />
                                                        </div>
                                                        <div class="row marginbottom10" runat="server" id="divFormat">
                                                            <label class="form_text">Format:</label>
                                                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="upFormat">
                                                                <ProgressTemplate>

                                                                    <div class="full-pop-up">
                                                                        <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                                                    </div>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                            <asp:UpdatePanel runat="server" ID="upFormat">
                                                                <ContentTemplate>
                                                                    <table style="width: 50%; grid-columns: none">
                                                                        <tr>
                                                                            <td style="width: 90%;">
                                                                                <asp:PlaceHolder runat="server" ID="phFormat">
                                                                                    <telerik:RadNumericTextBox TabIndex="22" NumberFormat-DecimalDigits="3" MinValue="1" Enabled="false" runat="server" ID="txtPMFormat1" Height="25" Width="30" DisplayText="1" Value="1"></telerik:RadNumericTextBox>X
                                      <telerik:RadNumericTextBox TabIndex="23" NumberFormat-DecimalDigits="3" MinValue="1" runat="server" ID="txtPMFormat2" Height="25" Width="30"></telerik:RadNumericTextBox>X
                                   
                                         <telerik:RadNumericTextBox TabIndex="24" AutoPostBack="true" OnTextChanged="txtPMFormat3_TextChanged" NumberFormat-DecimalDigits="3" MinValue="1" runat="server" ID="txtPMFormat3" Height="25" Width="30"></telerik:RadNumericTextBox>X
                                      <telerik:RadNumericTextBox TabIndex="25" NumberFormat-DecimalDigits="3" MinValue="1" runat="server" ID="txtPMFormat4" Height="25" Width="30"></telerik:RadNumericTextBox>

                                                                                </asp:PlaceHolder>
                                                                            </td>
                                                                            <td style="width: 90%;">
                                                                                <asp:ImageButton TabIndex="26" ToolTip="Add New" ID="btnAddTextbox" runat="server" OnClick="btnAddTextbox_Click" ImageUrl="~/assets/Images/plus-gray.png" Height="30" Width="30" />
                                                                            </td>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>


                                                        </div>

                                                        <div style="margin-left: 38%; width: 90px;" class="row marginbottom10" runat="server" id="dvWeight">

                                                            <asp:Label Style="margin-left: -185px;" runat="server" ID="lblWeigth" Text="Weight of single Full PM:" CssClass="form_text"></asp:Label><br />
                                                            <table style="background-color: none; width: 50%">
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <telerik:RadNumericTextBox TabIndex="27" NumberFormat-DecimalDigits="3" Width="282" Height="35" ID="rtxtWeight" runat="server" Type="Number" MinValue="0">
                                                                        </telerik:RadNumericTextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlWeightUnit" TabIndex="28" runat="server" CssClass="form-control" Style="width: 96px;">

                                                                            <asp:ListItem Text="GRAMS" Value="GRAMS" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Text="KGS" Value="KGS"></asp:ListItem>
                                                                            <asp:ListItem Text="TONNES" Value="TONNES"></asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                            </table>


                                                            <asp:RequiredFieldValidator ID="RequiredFieldVasssssslidator3" ValidationGroup="grp" runat="server" Text="***" ErrorMessage="Weight," ForeColor="Red" SetFocusOnError="true" ControlToValidate="rtxtWeight"></asp:RequiredFieldValidator>

                                                        </div>

                                                        <div class="row marginbottom10">
                                                            <label class="form_text"></label>
                                                            <asp:CheckBox runat="server" ID="cbxSubPack" TabIndex="29" Text="  Charge in Sub Packaging" OnCheckedChanged="cbxDW_CheckedChanged" AutoPostBack="true" Visible="false" />
                                                        </div>

                                                        <asp:Panel Visible="false" runat="server" GroupingText="Sub Packaging:" BorderStyle="none" Width="80%" ID="pnlSupPack">
                                                            <asp:UpdateProgress ID="UpdateProgress8" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
                                                                <ProgressTemplate>

                                                                    <div class="full-pop-up">
                                                                        <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                                                    </div>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                                <ContentTemplate>
                                                                    <telerik:RadAjaxManager ID="RadAjaxManager6" runat="server">
                                                                        <AjaxSettings>
                                                                            <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                                                                <UpdatedControls>
                                                                                    <telerik:AjaxUpdatedControl ControlID="rdaSubPMName" LoadingPanelID="RadAjaxLoadingPanel1" />
                                                                                </UpdatedControls>
                                                                            </telerik:AjaxSetting>
                                                                        </AjaxSettings>
                                                                    </telerik:RadAjaxManager>
                                                                    <telerik:RadAjaxManager ID="RadAjaxManager7" runat="server">
                                                                        <AjaxSettings>
                                                                            <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                                                                <UpdatedControls>
                                                                                    <telerik:AjaxUpdatedControl ControlID="rdaSubCapacity" LoadingPanelID="RadAjaxLoadingPanel1" />
                                                                                </UpdatedControls>
                                                                            </telerik:AjaxSetting>
                                                                        </AjaxSettings>
                                                                    </telerik:RadAjaxManager>
                                                                    <telerik:RadAjaxManager ID="RadAjaxManager8" runat="server">
                                                                        <AjaxSettings>
                                                                            <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                                                                <UpdatedControls>
                                                                                    <telerik:AjaxUpdatedControl ControlID="rdaSubGrade" LoadingPanelID="RadAjaxLoadingPanel1" />
                                                                                </UpdatedControls>
                                                                            </telerik:AjaxSetting>
                                                                        </AjaxSettings>
                                                                    </telerik:RadAjaxManager>
                                                                    <telerik:RadAjaxManager ID="RadAjaxManager9" runat="server">
                                                                        <AjaxSettings>
                                                                            <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                                                                                <UpdatedControls>
                                                                                    <telerik:AjaxUpdatedControl ControlID="rdaSubCondition" LoadingPanelID="RadAjaxLoadingPanel1" />
                                                                                </UpdatedControls>
                                                                            </telerik:AjaxSetting>
                                                                        </AjaxSettings>
                                                                    </telerik:RadAjaxManager>



                                                                    <asp:Panel runat="server" ID="Panel1">
                                                                        <table style="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <label>Material Name<br />
                                                                                        <asp:Label ID="lblSubPMName" runat="server"></asp:Label></label></td>
                                                                                <td>
                                                                                    <label>Capacity
                                                                                        <br />
                                                                                        <asp:Label ID="lblSubCapacity" runat="server"></asp:Label></label></td>
                                                                                <td>
                                                                                    <label>Grade<br />
                                                                                        <asp:Label ID="lblSubGrade" runat="server"></asp:Label></label></td>
                                                                                <td>
                                                                                    <label>Condition<br />
                                                                                        <asp:Label ID="lblSubCondition" runat="server"></asp:Label></label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:HiddenField Value="" ID="hdnSubPMName" runat="server" />
                                                                                    <telerik:RadAutoCompleteBox TabIndex="30" Style="width: 88%;" RenderMode="Lightweight" runat="server" ID="rdaSubPMName"
                                                                                        DataSourceID="sqlName" DataTextField="Name" InputType="Text" Width="283" DropDownWidth="150px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                                                    </telerik:RadAutoCompleteBox>

                                                                                    <asp:RequiredFieldValidator Enabled="false" ID="rqSubPMName" runat="server" ValidationGroup="grp" Text="***" ErrorMessage="Sub Material Name," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtPackingMaterial"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HiddenField Value="" ID="hdnSubCapacity" runat="server" />
                                                                                    <telerik:RadAutoCompleteBox TabIndex="31" Style="width: 88%;" RenderMode="Lightweight" runat="server" ID="rdaSubCapacity" DataSourceID="sqlCapacity" DataTextField="Data" InputType="Text" Width="283" DropDownWidth="150px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                                                    </telerik:RadAutoCompleteBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HiddenField Value="" ID="hdnSubGrade" runat="server" />
                                                                                    <telerik:RadAutoCompleteBox TabIndex="32" Style="width: 88%;" RenderMode="Lightweight" runat="server" ID="rdaSubGrade"
                                                                                        DataSourceID="sqlGrade" DataTextField="Grade" InputType="Text" Width="283" DropDownWidth="150px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                                                    </telerik:RadAutoCompleteBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HiddenField Value="" ID="hdnSubCondition" runat="server" />
                                                                                    <telerik:RadAutoCompleteBox TabIndex="33" Style="width: 88%;" RenderMode="Lightweight" runat="server" ID="rdaSubCondition"
                                                                                        DataSourceID="sqlCondition" DataTextField="condition" InputType="Text" Width="283" DropDownWidth="150px" TextSettings-SelectionMode="Single" AllowCustomEntry="true">
                                                                                    </telerik:RadAutoCompleteBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>


                                                                    </asp:Panel>
                                                                    <asp:UpdateProgress ID="UpdateProgress9" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel2">
                                                                        <ProgressTemplate>

                                                                            <div class="full-pop-up">
                                                                                <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                                                            </div>
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>

                                                                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                                        <ContentTemplate>
                                                                            <div class="row marginbottom10">
                                                                                <label class="form_text">Shape & Size:</label>
                                                                                <table style="width: 50%; grid-columns: none">
                                                                                    <tr>
                                                                                        <td style="width: 100px;">
                                                                                            <asp:DropDownList TabIndex="34" Style="width: 100px;" AutoPostBack="true" CssClass="form-control" ID="ddlSubShape" runat="server" OnSelectedIndexChanged="ddlSubShape_SelectedIndexChanged"></asp:DropDownList>
                                                                                        </td>
                                                                                        <td style="width: 50%;">


                                                                                            <div id="dvSubSphere" runat="server" visible="false">

                                                                                                <telerik:RadNumericTextBox TabIndex="34" NumberFormat-DecimalDigits="3" runat="server" ID="rnSphereR" placeholder="radius" Height="35" Width="75"></telerik:RadNumericTextBox>
                                                                                            </div>
                                                                                            <div id="dvSubCuboid" visible="false" runat="server">
                                                                                                <table style="width: 12%;">
                                                                                                    <tr>
                                                                                                        <td style="width: 30%;">
                                                                                                            <telerik:RadNumericTextBox TabIndex="34" NumberFormat-DecimalDigits="3" runat="server" ID="rnSubCuboidLngth" placeholder="length" Height="35" Width="50"></telerik:RadNumericTextBox>
                                                                                                        </td>
                                                                                                        <td style="width: 30%;">
                                                                                                            <telerik:RadNumericTextBox TabIndex="35" NumberFormat-DecimalDigits="3" runat="server" ID="rnSubCuboidBrth" placeholder="breadth " Height="35" Width="50"></telerik:RadNumericTextBox>
                                                                                                        </td>
                                                                                                        <td style="width: 30%;">
                                                                                                            <telerik:RadNumericTextBox TabIndex="36" NumberFormat-DecimalDigits="3" runat="server" ID="rnSubCuboidHeight" placeholder="height " Height="35" Width="50"></telerik:RadNumericTextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </div>
                                                                                            <div id="dvSubCylinder" visible="false" runat="server">

                                                                                                <telerik:RadNumericTextBox TabIndex="34" NumberFormat-DecimalDigits="3" runat="server" ID="rnSubCylinderRadius" placeholder="radius" Height="35" Width="55"></telerik:RadNumericTextBox>
                                                                                                <telerik:RadNumericTextBox TabIndex="35" NumberFormat-DecimalDigits="3" runat="server" ID="rnSubCylinderHeight" placeholder="height" Height="35" Width="55"></telerik:RadNumericTextBox>
                                                                                            </div>
                                                                                            <div id="dvSubCube" visible="false" runat="server">

                                                                                                <telerik:RadNumericTextBox TabIndex="34" NumberFormat-DecimalDigits="3" runat="server" ID="rnSubCubeRadius" placeholder="edge " Height="35" Width="75"></telerik:RadNumericTextBox>
                                                                                            </div>
                                                                                            <div id="dvSubOther" visible="false" runat="server">
                                                                                                <asp:TextBox runat="server" TabIndex="34" ID="txtSubOtherInfo" placeholder="Enter other info"></asp:TextBox>
                                                                                            </div>

                                                                                        </td>
                                                                                        <td style="width: 30%;">
                                                                                            <asp:DropDownList TabIndex="35" Style="width: 70px;" ID="ddlSubShapeUnit" runat="server" CssClass="form-control" Visible="false">

                                                                                                <asp:ListItem Text="cm" Value="cm" Selected="True"></asp:ListItem>
                                                                                                <asp:ListItem Text="ft" Value="ft"></asp:ListItem>
                                                                                                <asp:ListItem Text="sq ft" Value="sq ft"></asp:ListItem>
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                </table>


                                                                            </div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>



                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <div class="row marginbottom10">
                                                                <label class="form_text">Weight of single Full PM: </label>
                                                                <table style="background-color: none; width: 50%">
                                                                    <tr>
                                                                        <td style="width: 50%">
                                                                            <telerik:RadNumericTextBox TabIndex="36" NumberFormat-DecimalDigits="3" Width="265" Height="35" ID="rnSubPMWeight" runat="server" Type="Number" MinValue="0">
                                                                            </telerik:RadNumericTextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList TabIndex="37" ID="ddlSubWeight" runat="server" CssClass="form-control" Style="width: 96px;">

                                                                                <asp:ListItem Text="GRAMS" Value="GRAMS" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Text="KGS" Value="KGS"></asp:ListItem>
                                                                                <asp:ListItem Text="TONNES" Value="TONNES"></asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                </table>


                                                            </div>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                        </div>





                                        <div class="clear"></div>
                                        <div class="row">
                                            <div class="col-md-12 text-align-center marginbottom20">
                                                <asp:Button ValidationGroup="grp" TabIndex="38" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                                                <asp:Button runat="server" TabIndex="39" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click1" />
                                            </div>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="" runat="server" id="divStockGrid">
                            <div class="row">

                                <telerik:RadGrid ID="rgdStockGrid" runat="server"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">

                                    <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" ShowHeader="false">

                                        <Columns>


                                            <telerik:GridTemplateColumn HeaderText="" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                <ItemTemplate>
                                                    <div class="">

                                                        <%-- <%# (Eval("ATNo").ToString()==""? "Supply Order NO:":"AT NO:")%>--%>

                                                        <asp:Label runat="server" ID="nn" Text='<%#Eval("ATSONo")%>' Style="margin-bottom: -16px; width: 65%; word-wrap: break-word; display: block; margin-left: 17%"></asp:Label><br />
                                                        Received From: <%#Eval("RecievedFrom")%> Supplier: <%#Eval("OtherSupplier")%><br />
                                                        TRANSFER By: <%#Eval("TransferedBy")%><br />

                                                        Product:   <%#Eval("ITEMS")%> A/U: <%#Eval("AU")%><br />
                                                        Original manufacture : <%#Eval("OriginalManf")%><br />
                                                        GENERIC NAME: <%#Eval("GenericName")%><br />
                                                        <%--  Cost of particular: <%#TruncateDecimalToString( Convert.ToDouble(Eval("CostOfParticular") ),2)%> per  <%#Eval("AU") %><br />--%>
        RECEIVED DATE: <%#Convert.ToDateTime(Eval("RecievedOn")).ToString("dd MM yyyy")%><br />
                                                        REMARKS : <%#Eval("Remarks")%><br />
                                                        <%#(Eval("PackingMaterial").ToString() == "" ? "" : "Packaging Material Name	: " + Eval("PackingMaterial") + "<br />")%>
                                               Weight : <%#TruncateDecimalToString(Convert.ToDouble(Eval("Weight")), 3)%>&nbsp <%#Eval("WeigthUnit")%> &nbsp per PM<br />
                                                        <%#(Convert.ToBoolean(Eval("IsWithoutPacking").ToString()) == true ? "" : "Shape & size:" + Eval("PackagingMaterialShape") + " & " + Eval("PackagingMaterialSize") + " " + Eval("ShapeUnit") + "<br />")%>

                                                        <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString()) == false ? "" : "Sub Packaging Material Name: " + Eval("SubPackingMaterial") + "<br />")%>

                                                        <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString()) == false ? "" : (Eval("SubWeight").ToString() != "" ? " Weight: " + TruncateDecimalToString(Convert.ToDouble(Eval("SubWeight")), 3) + "  " + Eval("SubWeightUnit") + "<br />" : ""))%>
                                                        <%#(Convert.ToBoolean(Eval("IsSubPacking").ToString()) == false ? "" : (Eval("SubPMShape").ToString() != "" ? "Shape & Size: " + Eval("SubPMShape") + " & " + Eval("SubPMSize") + " " + Eval("SubShapeUnit") + "<br />" : ""))%>
                                                        <%#(Convert.ToDouble(Eval("PackagingMaterialFormatLevel").ToString()) == 0 ? "" : "Level: " + Eval("PackagingMaterialFormatLevel") + "<br />")%>
                                                        <%#(Convert.ToDouble(Eval("PackagingMaterialFormatLevel").ToString()) == 0 ? "" : (Eval("PackingMaterialFormat").ToString() == "" ? "" : "Format: " + Eval("PackingMaterialFormat")) + "<br />")%>
                                                    </div>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>

                                        </Columns>

                                        <FooterStyle HorizontalAlign="left" />

                                    </MasterTableView>
                                </telerik:RadGrid>

                                <div class="row">
                                    <div class="col-md-12 text-align-center" style="margin-top: 5px;">


                                        <asp:Button ID="btnEditStock" runat="server" Text="Edit" OnClick="btnEditStock_Click" />
                                    </div>
                                </div>
                            </div>



                        </div>
                    </Content>
                </asp:AccordionPane>

                <asp:AccordionPane ID="apBatch" runat="server">
                    <Header>Batch(s)</Header>
                    <Content>
                        <div class="container">
                            <div class="row" runat="server" id="dvEditBatch">
                                <script type="text/javascript">
                                    function activeExp() {
                                        if (document.getElementById("divExpiryDate").style.display == 'block') {

                                            document.getElementById("divExpiryDate").style.display = 'none';
                                        }
                                        else {

                                            document.getElementById("divExpiryDate").style.display = 'block';
                                        }
                                    }
                                    function activeESL() {

                                        if (document.getElementById("divESLDate").style.display == 'block') {

                                            document.getElementById("divESLDate").style.display = 'none';
                                        }
                                        else {

                                            document.getElementById("divESLDate").style.display = 'block';
                                        }
                                    }


                                </script>
                                <p>Introduce Batch(s) :</p>
                                <div class="col-md-12 text-align-center" style="margin-top: 5px;">


                                    <asp:Button ID="btnSubmitAllBatch" runat="server" Text="Submit" OnClick="btnSubmitAllBatch_Click" /><br />
                                    <br />
                                </div>
                                <div class="clearfix">
                                </div>
                                <asp:UpdateProgress ID="UpdateProgress4" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updBatchDate">
                                    <ProgressTemplate>

                                        <div class="full-pop-up">
                                            <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updBatchDate">
                                    <ContentTemplate>


                                        <telerik:RadGrid ID="rgdBatch" runat="server"
                                            GridLines="None" AutoGenerateColumns="False"
                                            Width="100%" Skin="Office2010Black" ShowFooter="true" OnItemCommand="rgdBatch_ItemCommand">

                                            <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="Top">
                                                <CommandItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="width: 18%;"></td>

                                                            <td style="width: 13%;">
                                                                <label style="float: left; width: 61px;">Expiry Date:</label>
                                                                <asp:CheckBox Text="-Active" ID="cbxExpDate" runat="server" Checked="true" OnCheckedChanged="cbxExpDate_CheckedChanged" AutoPostBack="true" />
                                                            </td>
                                                            <td style="width: 42%;">
                                                                <label style="float: left; width: 50px;">ESL:</label><asp:CheckBox ID="cbxESLDate" Text="-Active" runat="server" Checked="true" OnCheckedChanged="cbxESLDate_CheckedChanged" AutoPostBack="true" />
                                                            </td>

                                                        </tr>
                                                    </table>


                                                </CommandItemTemplate>
                                                <Columns>


                                                    <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                        <ItemTemplate>
                                                            <div class="">
                                                                <%#Container.DataSetIndex + 1%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <FooterTemplate>

                                                            <asp:ValidationSummary ID="vsBatch" ValidationGroup="bgrp"
                                                                DisplayMode="SingleParagraph"
                                                                EnableClientScript="true"
                                                                HeaderText="(*) indicates fields are required!"
                                                                runat="server" />
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="BID">
                                                        <ItemTemplate>
                                                            <%#Eval("BID")%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                                        <ItemTemplate>
                                                            <%#Eval("BatchNo")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox Style="width: 140px" ID="txtBatchNo" placeholder="Batch No" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="bgrp" runat="server" Text="*" ErrorMessage="Batch No," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtBatchNo"></asp:RequiredFieldValidator>

                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate">
                                                        <ItemTemplate>
                                                            <%#Eval("MFGDate").ToString() == "" ? "N/A" : Convert.ToDateTime(Eval("MFGDate")).ToString("dd-MM-yyyy")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <telerik:RadDatePicker Culture="en-US" RenderMode="Lightweight" ID="txtMfgDate" Width="100px" runat="server" DateInput-DateFormat="dd-MM-yyyy">
                                                            </telerik:RadDatePicker>
                                                            <%-- <asp:TextBox style="width:100%" ID="txtMfgDate"  placeholder="Manufacturing Date" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" Format="dd MM yyyy" TargetControlID="txtMfgDate" runat="server"></asp:CalendarExtender>
                                                            --%>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldVassssslidator4" ValidationGroup="bgrp" runat="server" Text="*" ErrorMessage="DOM," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtMfgDate"></asp:RequiredFieldValidator>

                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Expiry Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                                        <ItemTemplate>


                                                            <%#Eval("EXPDate").ToString() == "" ? "N/A" : Convert.ToDateTime(Eval("EXPDate")).ToString("dd-MM-yyyy")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <div style="display: block" id="divExpiryDate">
                                                                <telerik:RadDatePicker Culture="en-US" RenderMode="Lightweight" ID="txtExpiryDate" Width="100px" runat="server" DateInput-DateFormat="dd-MM-yyyy">
                                                                </telerik:RadDatePicker>
                                                                <%-- <asp:TextBox style="width:100%"  ID="txtExpiryDate" placeholder="Expiry  Date" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" Format="dd MM yyyy" TargetControlID="txtExpiryDate" runat="server"></asp:CalendarExtender>
                                                                --%>
                                                            </div>
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="ESL" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                                        <ItemTemplate>
                                                            <%#Eval("Esl").ToString() == "" ? "N/A" : Convert.ToDateTime(Eval("Esl")).ToString("MMM-yyyy")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <div style="display: block" id="divESLDate">
                                                                <telerik:RadMonthYearPicker ID="txtESLDate" Width="100px" Culture="en-US" runat="server" DateInput-DateFormat="MMM-yyyy"></telerik:RadMonthYearPicker>
                                                                <%-- <telerik:RadDatePicker  Culture="en-US" RenderMode="Lightweight" ID="txtESLDate" Width="100px" runat="server" DateInput-DateFormat="MMM-yyyy" Calendar-EnableMonthYearFastNavigation="true">
        </telerik:RadDatePicker>--%>
                                                                <%--                                             <asp:TextBox ID="txtESLDate" style="width:100%"  placeholder="ESL  Date" runat="server" onKeyDown="javascript: return false;"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender4" Format="dd MM yyyy" TargetControlID="txtESLDate" runat="server"></asp:CalendarExtender>
                                                                --%>
                                                            </div>
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Sample Sent" DataField="IsSentto" DataType="System.Boolean" UniqueName="IsSentto">
                                                        <ItemTemplate>
                                                            <asp:CheckBox Enabled="false" Checked=' <%#Eval("IsSentto")%>' runat="server" /><br />

                                                            <%#Convert.ToBoolean(Eval("IsSentto")) == true ? Eval("ContactNo").ToString() != "" ? Eval("ContactNo") : Eval("SampleSentQty").ToString() != "" ?  Convert.ToDouble(Eval("SampleSentQty")).ToString("0.000") : "" : ""%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>

                                                            <asp:CheckBox ID="cbxSampleSentB" Checked="false" runat="server" Text="" OnCheckedChanged="cbxSampleSentB_CheckedChanged" AutoPostBack="true" />
                                                            <br />
                                                            <telerik:RadNumericTextBox Visible="false" EmptyMessage="Sent Qty" Width="70" runat="server" ID="txtSampleSentQty" NumberFormat-DecimalDigits="3"></telerik:RadNumericTextBox>
                                                            <asp:TextBox Visible="false" TextMode="MultiLine" Style="width: 80px" ID="txtContactNo" runat="server" placeholder="Information"></asp:TextBox>




                                                            <script type="text/javascript">
                                                                function display() {

                                                                    if (document.getElementById("divContactNo").style.display == 'block') {

                                                                        document.getElementById("divContactNo").style.display = 'none';
                                                                    }
                                                                    else {

                                                                        document.getElementById("divContactNo").style.display = 'block';
                                                                    }
                                                                }
                                                            </script>



                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Cost Of Particular" DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                                        <ItemTemplate>
                                                            <%#Eval("CostOfParticular") + " per " + AU%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <telerik:RadNumericTextBox Width="140" PlaceHolder="Cost" runat="server" ID="txtCost" NumberFormat-DecimalDigits="2"></telerik:RadNumericTextBox>
                                                            <asp:RequiredFieldValidator ID="Requircost" ValidationGroup="bgrp" runat="server" Text="*" ErrorMessage="Cost," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtCost"></asp:RequiredFieldValidator>

                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Warehouse No" DataField="WarehouseNo" DataType="System.String" UniqueName="WarehouseNo">
                                                        <ItemTemplate>
                                                            <%#Eval("WarehouseNo")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>

                                                            <asp:DropDownList OnDataBound="ddlWarehouse_DataBound" runat="server" ID="ddlWarehouse" DataTextField="Name" DataValueField="Name" Width="100"></asp:DropDownList>

                                                            <asp:RequiredFieldValidator InitialValue="&nbsp;" ID="RequiredFieldValidator3" ValidationGroup="bgrp" runat="server" ErrorMessage="**" Text="**" ForeColor="Red" SetFocusOnError="true"
                                                                ControlToValidate="ddlWarehouse"></asp:RequiredFieldValidator>

                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Rows" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                                                        <ItemTemplate>
                                                            <%#Eval("SectionRows")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <telerik:RadNumericTextBox MinValue="0" EmptyMessage="Rows" NumberFormat-DecimalDigits="0" Width="50" CssClass="form-control" runat="server" ID="txtRows"></telerik:RadNumericTextBox>
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Columns" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                                                        <ItemTemplate>
                                                            <%#Eval("SectionCol")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <telerik:RadNumericTextBox MinValue="0" EmptyMessage="Columns" NumberFormat-DecimalDigits="0" Width="50" CssClass="form-control" runat="server" ID="txtColumns"></telerik:RadNumericTextBox>
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>


                                                    <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                                                        <ItemTemplate>
                                                            <%#Eval("Remarks")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox Style="width: 150px" ID="txtRemarks" placeholder="Remarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEditBatch" runat="server" CausesValidation="false" Text="Edit" CommandName="EditBatch" CommandArgument='<%#Eval("BID")%>'></asp:LinkButton>
                                                            |<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" Text="Delete" CommandName="DeleteBatch" CommandArgument='<%#Eval("BID")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Button runat="server" ID="btnSubmitBatch" Text="Add" ValidationGroup="bgrp" OnClick="btnSubmitBatch_Click" />
                                                            <asp:Button runat="server" ID="btnCancel" Text="Clear" OnClick="btnCancel_Click" />
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>


                                                </Columns>

                                                <FooterStyle HorizontalAlign="Left" />

                                            </MasterTableView>
                                        </telerik:RadGrid>
                                        <asp:Label Text="" ID="lblErrorBatch" runat="server" ForeColor="Red"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="row">
                                </div>
                            </div>

                            <div class="row" runat="server" id="dvListBacth">

                                <p>All Batch(s) :</p>
                                <telerik:RadGrid ID="rgdBatchList" runat="server"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Width="100%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">

                                    <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="Top">
                                        <CommandItemTemplate>
                                            <table>
                                                <tr>
                                                    <td style="width: 12%;"></td>

                                                    <td style="width: 7%;">
                                                        <label style="float: left; width: 61px;">Expiry Date:</label>
                                                        <asp:CheckBox Text="-Active" ID="cbxExpDate" runat="server" Checked="true" Enabled="false" />
                                                    </td>
                                                    <td style="width: 26%;">
                                                        <label style="float: left; width: 50px;">ESL :</label>
                                                        <asp:CheckBox Text="-Active" ID="cbxESLDate" runat="server" Checked="true" Enabled="false" />
                                                    </td>

                                                </tr>
                                            </table>

                                        </CommandItemTemplate>
                                        <Columns>


                                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                <ItemTemplate>
                                                    <div class="">
                                                        <%#Container.DataSetIndex + 1%>
                                                    </div>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="BID">
                                                <ItemTemplate>
                                                    <%#Eval("BID")%>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                                <ItemTemplate>
                                                    <%#Eval("BatchNo")%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate">
                                                <ItemTemplate>
                                                    <%#Eval("MFGDate").ToString() == "" ? "N/A" : Convert.ToDateTime(Eval("MFGDate")).ToString("dd-MM-yyyy")%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                                <ItemTemplate>
                                                    <%#Eval("EXPDate").ToString() == "" ? "N/A" : Convert.ToDateTime(Eval("EXPDate")).ToString("dd-MM-yyyy")%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="ESL " DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                                <ItemTemplate>
                                                    <%#Eval("Esl").ToString() == "" ? "N/A" : Convert.ToDateTime(Eval("Esl")).ToString("MMM-yyyy")%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Sample Sent" DataField="IsSentto" DataType="System.Boolean" UniqueName="IsSentto">
                                                <ItemTemplate>
                                                    <asp:CheckBox Enabled="false" Checked=' <%#Eval("IsSentto")%>' runat="server" /><br />

                                                    <%#Convert.ToBoolean(Eval("IsSentto")) == true ? Eval("ContactNo").ToString() != "" ? Eval("ContactNo") : Eval("SampleSentQty").ToString() != "" ? Convert.ToDouble(Eval("SampleSentQty")).ToString("0.000") : "" : ""%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Cost" DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                                <ItemTemplate>

                                                    <%#(Eval("Cost").ToString() == "" ? "" : Eval("Cost").ToString())%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Cost Of Particular" DataField="CostOfParticular" DataType="System.Double" UniqueName="CostOfParticular">
                                                <ItemTemplate>

                                                    <%#(Eval("CostOfParticular").ToString() == "" ? "" : Eval("CostOfParticular").ToString() + " per " + AU)%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Weight" DataField="Weight" DataType="System.Double" UniqueName="Weight">
                                                <ItemTemplate>

                                                    <%#(Eval("Weight").ToString() == "" ? "" : TruncateDecimalToString(Convert.ToDouble(Eval("Weight").ToString()), 3).ToString() + " " + Eval("WeightUnit"))%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Weight of Particular" DataField="WeightofParticular" DataType="System.Double" UniqueName="WeightofParticular">
                                                <ItemTemplate>
                                                    <%#(Eval("WeightofParticular").ToString() == "" ? "" : TruncateDecimalToString(Convert.ToDouble(Eval("WeightofParticular").ToString()), 3) + " " + Eval("WeightUnit"))%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Warehouse No" DataField="WarehouseNo" DataType="System.String" UniqueName="WarehouseNo">
                                                <ItemTemplate>
                                                    <%#Eval("WarehouseNo")%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Rows" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                                                <ItemTemplate>
                                                    <%#Eval("SectionRows")%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Columns" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                                                <ItemTemplate>
                                                    <%#Eval("SectionCol")%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>


                                            <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                                                <ItemTemplate>
                                                    <%#Eval("Remarks")%>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>

                                        <FooterStyle HorizontalAlign="Left" />

                                    </MasterTableView>
                                </telerik:RadGrid>

                                <div class="row">
                                    <div class="col-md-12 text-align-center" style="margin-top: 5px;">



                                        <asp:Button ID="btnAddBatch" runat="server" Text="Manage" OnClick="btnAddBatch_Click" />

                                    </div>
                                </div>
                            </div>

                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="apVehicle" runat="server">
                    <Header>Vehicle</Header>
                    <Content>
                        <%--<style>
                        .RadGrid_Office2010Black .rgFooter td, .RadGrid_Office2010Black .rgFooterWrapper {
    
    color: black;
}
                    </style>--%>
                        <div class="container">

                            <div class="row" runat="server" id="divEditVehicle">

                                <p>Introduce Commodity Vehiclewise:</p>
                                <div class="col-md-12 text-align-center" style="margin-top: 5px;">


                                    <asp:Button ID="btnVEhicleSubmitAll" runat="server" Text="Submit" OnClick="btnVEhicleSubmitAll_Click" />
                                    <br />
                                    <br />
                                </div>
                                <div class="clearfix">
                                </div>

                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="uptVehicle">
                                    <ProgressTemplate>

                                        <div class="full-pop-up">
                                            <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="uptVehicle">
                                    <ContentTemplate>

                                        <%--<style>
    .RadGrid_Office2010Black .rgFooter td, .RadGrid_Office2010Black .rgFooterWrapper {
        background-color:WindowFrame  !important;
    /*color: black !important;*/
}
</style>--%>

                                        <telerik:RadGrid ID="rgdVehicle" runat="server"
                                            GridLines="None" AutoGenerateColumns="False"
                                            Width="90%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" OnItemCommand="rgdVehicle_ItemCommand">

                                            <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none">
                                                <GroupByExpressions>

                                                    <telerik:GridGroupByExpression>
                                                        <GroupByFields>
                                                            <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderValueSeparator=":" SortOrder="None" />
                                                        </GroupByFields>
                                                        <SelectFields>
                                                            <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderText="." />
                                                        </SelectFields>
                                                    </telerik:GridGroupByExpression>

                                                    <telerik:GridGroupByExpression>
                                                        <GroupByFields>
                                                            <telerik:GridGroupByField FieldName="VehicleNo" HeaderValueSeparator=":" SortOrder="None" />
                                                        </GroupByFields>
                                                        <SelectFields>
                                                            <telerik:GridGroupByField FieldName="VehicleNo" HeaderText="Vehicle No" />
                                                        </SelectFields>
                                                    </telerik:GridGroupByExpression>
                                                    <telerik:GridGroupByExpression>
                                                        <GroupByFields>
                                                            <telerik:GridGroupByField FieldName="DriverName" HeaderValueSeparator=":" SortOrder="None" />
                                                        </GroupByFields>
                                                        <SelectFields>
                                                            <telerik:GridGroupByField FieldName="DriverName" HeaderText="Driver Name" />
                                                        </SelectFields>
                                                    </telerik:GridGroupByExpression>
                                                </GroupByExpressions>
                                                <Columns>



                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="Id">
                                                        <ItemTemplate>
                                                            <%#Eval("Id")%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="" DataField="IsDDOrCHT" DataType="System.String" UniqueName="IsDDOrCHT">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                        <FooterTemplate>

                                                            <asp:RadioButtonList BorderStyle="None" ForeColor="White" BackColor="#333333" runat="server" ID="rbtnDDCHT" RepeatDirection="Horizontal" TextAlign="Left">
                                                                <asp:ListItem Text="CHT" Value="CHT" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="DD" Value="DD"></asp:ListItem>

                                                            </asp:RadioButtonList>
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="" DataField="DriverName" DataType="System.String" UniqueName="DriverName">
                                                        <ItemTemplate>
                                                            <%-- <%#Eval("DriverName") %>--%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtDriverName" placeholder="Driver Name" runat="server" Style="width: 125px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="vgrp" runat="server" Text="*" ErrorMessage="Driver Name," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDriverName"></asp:RequiredFieldValidator>

                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="" DataField="VehicleNo" DataType="System.String" UniqueName="VehicleNo">
                                                        <ItemTemplate>
                                                            <%-- <%#Eval("VehicleNo").ToString() %>   --%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtVehicleNo" placeholder="Vehicle No" runat="server" Style="width: 125px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldVssssssalidator4" ValidationGroup="vgrp" runat="server" Text="*" ErrorMessage="Vehicle No," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtVehicleNo"></asp:RequiredFieldValidator>

                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                        <ItemTemplate>
                                                            <div class="">
                                                                <%#Container.DataSetIndex + 1%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="vgrp"
                                                                DisplayMode="SingleParagraph"
                                                                EnableClientScript="true"
                                                                HeaderText="(*) indicates fields are required!"
                                                                runat="server" />
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Challan No" DataField="ChallanNo" DataType="System.String" UniqueName="ChallanNo">
                                                        <ItemTemplate>
                                                            <%#Eval("ChallanNo").ToString()%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtChallanNo" placeholder="Challan No" runat="server" Style="width: 125px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequsdsdsdsdiredFieldVssssssalidator4" ValidationGroup="vgrp" runat="server" Text="*" ErrorMessage=" Challan No," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtChallanNo"></asp:RequiredFieldValidator>

                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Bacth No" DataField="StockBatchId" DataType="System.Int32" UniqueName="StockBatchId">
                                                        <ItemTemplate>
                                                            <%#Eval("BatchNo").ToString()%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <%--  OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged"--%>
                                                            <asp:DropDownList OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged" AutoPostBack="true" OnDataBound="ddlBatch_DataBound" ID="ddlBatch" runat="server" DataTextField="BatchNo" DataValueField="BID" Style="width: 100px"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFissssseldValidator9" ValidationGroup="vgrp" runat="server" ErrorMessage="Batch," ForeColor="Red" SetFocusOnError="true"
                                                                ControlToValidate="ddlBatch" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:Label ID="lblBatchdll" runat="server" Text="" Visible="false" Style="width: 100px"></asp:Label>
                                                            <asp:Label ID="lblBID" runat="server" Text="" Visible="false" Style="width: 100px"></asp:Label>
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>



                                                    <telerik:GridTemplateColumn HeaderText="Sent Qty" DataField="SentQty" DataType="System.Int32" UniqueName="SentQty">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("SentQty")), 3)%>' ID="leeebl"></asp:Label>



                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <telerik:RadNumericTextBox NumberFormat-DecimalDigits="3" Style="width: 135px" ID="txtSentQty" runat="server" placeholder="Sent Qty"></telerik:RadNumericTextBox>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldVassssslidator4" ValidationGroup="vgrp" runat="server" Text="*" ErrorMessage="Sent Qty," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtSentQty"></asp:RequiredFieldValidator>
                                                            <br />
                                                            <asp:Label ID="lblQtySent" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Recieved Qty" DataField="RecievedQty" DataType="System.Int32" UniqueName="RecievedQty">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("RecievedQty")), 3)%>' ID="lsssbl"></asp:Label>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValddddidator4" ValidationGroup="vgrp" runat="server" Text="*" ErrorMessage="Recieved Qty," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtRecievedQty"></asp:RequiredFieldValidator>

                                                            <telerik:RadNumericTextBox NumberFormat-DecimalDigits="3" Style="width: 135px" ID="txtRecievedQty" runat="server" placeholder="Recieved Qty"></telerik:RadNumericTextBox>

                                                            <br />
                                                            <asp:Label ID="lblQtyRec" runat="server"></asp:Label>
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn>
                                                        <ItemTemplate>
                                                            <asp:LinkButton Style="width: 100%" ID="btnEditVehicle" runat="server" CausesValidation="false" Text="Edit" CommandName="EditVehicle" CommandArgument='<%#Eval("Id")%>'></asp:LinkButton>
                                                            |
                                 
                                         <asp:LinkButton Style="width: 100%" ID="btnDelete" runat="server" CausesValidation="false" Text="Delete" CommandName="DeleteVehicle" CommandArgument='<%#Eval("Id")%>'></asp:LinkButton>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Button Style="width: 60px" runat="server" ID="btnSubmitVehicle" Text="Add" ValidationGroup="vgrp" OnClick="btnSubmitVehicle_Click" />
                                                            <asp:Button Style="width: 60px" runat="server" ID="btnCancel" Text="Clear" OnClick="btnCancel_Click" />

                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>


                                                </Columns>

                                                <FooterStyle HorizontalAlign="Left" />

                                            </MasterTableView>
                                        </telerik:RadGrid>
                                        <asp:Label Text="" ID="lblVehilceError" runat="server" ForeColor="Red"></asp:Label>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="row" runat="server" id="divVehicleAll">

                                <p>Commodity Vehiclewise:</p>


                                <telerik:RadGrid ID="rdsVehicleList" runat="server"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">

                                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none">
                                        <GroupByExpressions>
                                            <telerik:GridGroupByExpression>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderValueSeparator=":" SortOrder="None" />
                                                </GroupByFields>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderText="." />
                                                </SelectFields>
                                            </telerik:GridGroupByExpression>
                                            <telerik:GridGroupByExpression>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="VehicleNo" HeaderValueSeparator=":" SortOrder="None" />
                                                </GroupByFields>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldName="VehicleNo" HeaderText="Vehicle No" />
                                                </SelectFields>
                                            </telerik:GridGroupByExpression>
                                            <telerik:GridGroupByExpression>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="DriverName" HeaderValueSeparator=":" SortOrder="None" />
                                                </GroupByFields>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldName="DriverName" HeaderText="Driver Name" />
                                                </SelectFields>
                                            </telerik:GridGroupByExpression>
                                        </GroupByExpressions>
                                        <Columns>



                                            <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="Id">
                                                <ItemTemplate>
                                                    <%#Eval("Id")%>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="" DataField="DriverName" DataType="System.String" UniqueName="DriverName">
                                                <ItemTemplate>
                                                    <%-- <%#Eval("DriverName") %>--%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="" DataField="VehicleNo" DataType="System.String" UniqueName="VehicleNo">
                                                <ItemTemplate>
                                                    <%-- <%#Eval("VehicleNo").ToString() %>   --%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                <ItemTemplate>
                                                    <div class="">
                                                        <%#Container.DataSetIndex + 1%>
                                                    </div>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Challan No" DataField="ChallanNo" DataType="System.String" UniqueName="ChallanNo">
                                                <ItemTemplate>
                                                    <%#Eval("ChallanNo").ToString()%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Bacth No" DataField="StockBatchId" DataType="System.Int32" UniqueName="StockBatchId">
                                                <ItemTemplate>
                                                    <%#Eval("BatchNo").ToString()%>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>


                                            <telerik:GridTemplateColumn HeaderText="Sent Qty" DataField="SentQty" DataType="System.Int32" UniqueName="SentQty">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("SentQty")), 3)%>' ID="leeebl"></asp:Label>


                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblQtySent" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Recieved Qty" DataField="RecievedQty" DataType="System.Int32" UniqueName="RecievedQty">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("RecievedQty")), 3)%>' ID="lsssbl"></asp:Label>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblQtyRec" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>



                                        </Columns>

                                        <FooterStyle HorizontalAlign="Left" />

                                    </MasterTableView>
                                </telerik:RadGrid>
                                <div class="row">
                                    <div class="col-md-12 text-align-center" style="margin-top: 5px;">



                                        <asp:Button ID="btnAddNEwVehicle" runat="server" Text="Manage" OnClick="btnAddNEwVehicle_Click" />

                                    </div>
                                </div>
                            </div>




                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="apSppilage" runat="server">
                    <Header>Spillage </Header>
                    <Content>
                        <div class="container">
                            <asp:UpdateProgress ID="UpdateProgress11" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updSpill">
                                <ProgressTemplate>

                                    <div class="full-pop-up">
                                        <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>

                            <asp:UpdatePanel ID="updSpill" runat="server">
                                <ContentTemplate>

                                    <div class="row" runat="server" id="divIfSppilage">

                                        <p>If Spillage/Sample sent:</p>

                                        <telerik:RadGrid ID="rgdSppilage" runat="server"
                                            GridLines="None" AutoGenerateColumns="False"
                                            Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" OnItemCreated="rgdSppilage_ItemCreated">

                                            <MasterTableView DataKeyNames="tBatchId" GridLines="None" Width="100%" CommandItemDisplay="none">

                                                <Columns>


                                                    <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                        <ItemTemplate>
                                                            <div class="">
                                                                <%#Container.DataSetIndex + 1%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="sgrp"
                                                                DisplayMode="SingleParagraph"
                                                                EnableClientScript="true"
                                                                HeaderText="(*) indicates fields are required!"
                                                                runat="server" />
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="tBatchId">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnIsSent" runat="server" Value='<%#Eval("IsSentto").ToString()%>' />
                                                            <asp:Label runat="server" Text='<%#Eval("tStockId").ToString()%>' ID="lblStockId"></asp:Label>

                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                                        <ItemTemplate>
                                                            <%#Eval("BatchNo")%>
                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>


                                                    <telerik:GridTemplateColumn HeaderText="Sent Qty" DataField="tSentQty" DataType="System.Int32" UniqueName="tSentQty">
                                                        <ItemTemplate>

                                                            <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("tSentQty")), 3)%>' ID="lblSentQty"></asp:Label>


                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Recieved Qty" DataField="tRecQty" DataType="System.Int32" UniqueName="tRecQty">
                                                        <ItemTemplate>

                                                            <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("tRecQty")), 3)%>' ID="lblRecQty"></asp:Label>



                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Spilled Qty" DataField="tSpilqty" DataType="System.Int32" UniqueName="tSpilqty">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("tSpilqty")), 3)%>' ID="lblSpilqty"></asp:Label>

                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Sample Sent Qty" DataField="SampleSentQty" DataType="System.Int32" UniqueName="SampleSentQty">
                                                        <ItemTemplate>

                                                            <asp:Label runat="server" Text='<%#Eval("SampleSentQty").ToString() != "" ? TruncateDecimalToString(Convert.ToDouble(Eval("SampleSentQty")), 3) : ""%>' ID="lblSampleSentQty" Visible='<%#Convert.ToBoolean(Eval("IsSentto"))%>'></asp:Label>



                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Spillage-affected full PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="SpilAffectedQty">
                                                        <ItemTemplate>

                                                            <telerik:RadNumericTextBox ToolTip='<%#Eval("tBatchId")%>' AutoPostBack="true" OnTextChanged="txtSppilDamagedBox_TextChanged" NumberFormat-DecimalDigits="0" ID='txtSppilDamagedBox' runat="server" Value="0" Visible='<%#Convert.ToDouble(Eval("tSpilqty")) > 0 ? true : false%>'></telerik:RadNumericTextBox>
                                                            <br />
                                                            <asp:Label Text="Minimum Damaged boxes: " ID="lblSpillSentBox" runat="server" ForeColor="Blue"></asp:Label>

                                                        </ItemTemplate>




                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Sample-affected full PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="SampleAffectedQty">
                                                        <ItemTemplate>

                                                            <telerik:RadNumericTextBox OnTextChanged="txtSppilDamagedBox_TextChanged" AutoPostBack="true" ToolTip='<%#Eval("tBatchId")%>' NumberFormat-DecimalDigits="0" ID='txtSampleDamagedBox' runat="server" Value="0" Visible='<%#Convert.ToBoolean(Eval("IsSentto"))%>'></telerik:RadNumericTextBox>
                                                            <br />
                                                            <asp:Label Text="Minimum Damaged boxes: " ID="lblSampleSentBox" runat="server" ForeColor="Blue" Visible='<%#Convert.ToBoolean(Eval("IsSentto"))%>'></asp:Label>


                                                        </ItemTemplate>




                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Both-affected full PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="BothAffectd">
                                                        <ItemTemplate>

                                                            <telerik:RadNumericTextBox AutoPostBack="true" OnTextChanged="txtSppilDamagedBox_TextChanged" ToolTip='<%#Eval("tBatchId")%>' NumberFormat-DecimalDigits="0" ID='txtBothDamagedBox' runat="server" Value="0" Visible='<%#Convert.ToBoolean(Eval("IsSentto"))%>'></telerik:RadNumericTextBox>
                                                        </ItemTemplate>




                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Total-affected full  PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="tSpilqty">
                                                        <ItemTemplate>

                                                            <telerik:RadNumericTextBox Enabled="false" NumberFormat-DecimalDigits="0" ID='txtDamagedBox' runat="server" Value="0" Visible='<%#Convert.ToDouble(Eval("tSpilqty")) > 0 ? true : false%>'></telerik:RadNumericTextBox>
                                                            <br />
                                                            <asp:Label Text="Minimum Total Damaged boxes: " ID="lblSpilErr" runat="server" ForeColor="Blue"></asp:Label>
                                                        </ItemTemplate>



                                                        <FooterTemplate>
                                                            <asp:Button runat="server" ID="btnSubmitSpillage" Text="Submit" ValidationGroup="sgrp" OnClick="btnSubmitSpillage_Click" />

                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>


                                                </Columns>

                                                <FooterStyle HorizontalAlign="Right" />

                                            </MasterTableView>
                                        </telerik:RadGrid>

                                    </div>
                                    <asp:Label Text="" ID="lblSpilErr" runat="server" ForeColor="Red" Visible="false"></asp:Label>

                                    <div class="row" runat="server" id="divSppilageList">

                                        <p>Spillage/Sample sent:</p>
                                        <asp:Label Text="" ID="lblNosppil" runat="server" ForeColor="Blue"></asp:Label>

                                        <telerik:RadGrid ID="rgdIfSpillage" runat="server"
                                            GridLines="None" AutoGenerateColumns="False"
                                            Width="97%" Skin="Office2010Black" ShowFooter="true" OnItemCommand="rgdIfSpillage_ItemCommand">

                                            <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none">

                                                <Columns>


                                                    <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                        <ItemTemplate>
                                                            <div class="">
                                                                <%#Container.DataSetIndex + 1%>
                                                            </div>
                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="StockId">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnIsSent" runat="server" Value='<%#Eval("IsSentto").ToString()%>' />
                                                            <asp:Label runat="server" Text='<%#Eval("StockId").ToString()%>' ID="lblStockId"></asp:Label>
                                                            <asp:Label runat="server" Text='<%#Eval("StockBatchId").ToString()%>' ID="lblBatch"></asp:Label>

                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                                        <ItemTemplate>
                                                            <%#Eval("BatchNo")%>
                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Sent Qty" DataField="tSentQty" DataType="System.Int32" UniqueName="tSentQty">
                                                        <ItemTemplate>

                                                            <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("tSentQty")), 3)%>' ID="lblSentQty"></asp:Label>


                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Recieved Qty" DataField="tRecQty" DataType="System.Int32" UniqueName="tRecQty">
                                                        <ItemTemplate>

                                                            <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("tRecQty")), 3)%>' ID="lblRecQty"></asp:Label>



                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Spilled Qty" DataField="SpilledQty" DataType="System.Int32" UniqueName="SpilledQty">
                                                        <ItemTemplate>

                                                            <asp:Label runat="server" Text='<%# TruncateDecimal(Convert.ToDouble(Eval("SpilledQty")), 3).ToString()%>' ID="lblSpilledQty"></asp:Label>


                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Sample Sent Qty" DataField="SampleSentQty" DataType="System.Int32" UniqueName="SampleSentQty">
                                                        <ItemTemplate>

                                                            <asp:Label runat="server" Text='<%#Eval("SampleSentQty").ToString() != "" ? TruncateDecimalToString(Convert.ToDouble(Eval("SampleSentQty")), 3) : ""%>' ID="lblSampleSentQty" Visible='<%#Convert.ToBoolean(Eval("IsSentto"))%>'></asp:Label>



                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Spillage-affected full PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="SpilAffectedQty">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%#Eval("SpillageAffected").ToString() != "" ? Convert.ToDouble(Eval("SpillageAffected")).ToString("0") : ""%>' ID="lblSpillQty"></asp:Label>

                                                            <telerik:RadNumericTextBox Text='<%#Eval("SpillageAffected").ToString() != "" ? Convert.ToDouble(Eval("SpillageAffected")).ToString("0") : ""%>' OnTextChanged="txtSppilDamagedBox_TextChanged1" ToolTip='<%#Eval("StockBatchId")%>' AutoPostBack="true" NumberFormat-DecimalDigits="0" ID='txtSppilDamagedBox' runat="server" Value="0" Visible="false"></telerik:RadNumericTextBox>
                                                        </ItemTemplate>




                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Sample-affected full PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="SampleAffectedQty">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%#Eval("SampleAffected").ToString() != "" ? Convert.ToDouble(Eval("SampleAffected")).ToString("0") : ""%>' ID="lblSampleQty" Visible='<%#Convert.ToBoolean(Eval("IsSentto"))%>'></asp:Label>


                                                            <telerik:RadNumericTextBox Text='<%#Eval("SampleAffected").ToString() != "" ? Convert.ToDouble(Eval("SampleAffected")).ToString("0") : ""%>' OnTextChanged="txtSppilDamagedBox_TextChanged1" AutoPostBack="true" ToolTip='<%#Eval("StockBatchId")%>' NumberFormat-DecimalDigits="0" ID='txtSampleDamagedBox' runat="server" Value="0" Visible="false"></telerik:RadNumericTextBox>
                                                        </ItemTemplate>




                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Both-affected full PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="BothAffectd">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%#Eval("BothAffected").ToString() != "" ? Convert.ToDouble(Eval("BothAffected")).ToString("0") : ""%>' ID="lblBothQty" Visible='<%#Convert.ToBoolean(Eval("IsSentto"))%>'></asp:Label>

                                                            <telerik:RadNumericTextBox Text='<%#Eval("BothAffected").ToString() != "" ? Convert.ToDouble(Eval("BothAffected")).ToString("0") : ""%>' OnTextChanged="txtSppilDamagedBox_TextChanged1" Visible="false" AutoPostBack="true" ToolTip='<%#Eval("StockBatchId")%>' NumberFormat-DecimalDigits="0" ID='txtBothDamagedBox' runat="server" Value="0"></telerik:RadNumericTextBox>
                                                        </ItemTemplate>




                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Total-affected full  PM" DataField="tSpilqty" DataType="System.Int32" UniqueName="tSpilqty">
                                                        <ItemTemplate>


                                                            <asp:Label runat="server" Text='<%#Convert.ToDouble(Eval("DamagedBoxes")).ToString("0")%>' ID="lblDamagedBoxes"></asp:Label>

                                                            <telerik:RadNumericTextBox Enabled="false" NumberFormat-DecimalDigits="0" Visible="false" ID='txtDamagedBox' runat="server" Text='<%#Eval("DamagedBoxes").ToString()%>'></telerik:RadNumericTextBox>

                                                        </ItemTemplate>


                                                        <FooterTemplate>
                                                            <asp:Button ID="btnSpilEdit" runat="server" CausesValidation="false" Text="Edit" CommandName="EditSpill" CommandArgument='<%#Eval("Id")%>'></asp:Button>
                                                            <asp:Button Visible="false" runat="server" ID="btnSubmitSpillage" Text="Submit" ValidationGroup="sgrp" OnClick="btnSubmitSpillage_Click1" />

                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>




                                                </Columns>

                                                <FooterStyle HorizontalAlign="Right" />

                                            </MasterTableView>
                                        </telerik:RadGrid>


                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="apPackaging" runat="server">
                    <Header>Packaging</Header>
                    <Content>
                        <div class="container">

                            <div class="row" runat="server" id="divDispPack">
                                <p>Packaging:</p>
                                <table style="width: 97%">
                                    <tr>

                                        <td>
                                            <asp:Label runat="server" ID="lblTotalQtyPackaging" Style="float: right"></asp:Label></td>
                                    </tr>
                                </table>
                                <telerik:RadGrid ID="rgdPackagingListFull" runat="server"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">

                                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none">
                                        <GroupByExpressions>

                                            <telerik:GridGroupByExpression>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="PackagingType" HeaderValueSeparator=":" SortOrder="Ascending" />
                                                </GroupByFields>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldName="PackagingType" HeaderText="Packaging Type" />
                                                </SelectFields>
                                            </telerik:GridGroupByExpression>
                                        </GroupByExpressions>
                                        <Columns>


                                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                <ItemTemplate>
                                                    <div class="">
                                                        <%#Container.DataSetIndex + 1%>
                                                    </div>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%#Eval("Id")%>' runat="server" ID="lblBatchID"></asp:Label>

                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                <ItemTemplate>
                                                    <%#Eval("BatchNo")%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    Total Packaging:                               
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Quantity" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                <ItemTemplate>

                                                    <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("RemainingQty")), 3)%>' ID="lblQuantity"></asp:Label>


                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="server" ID="lblTotalQuatity"></asp:Label>

                                                </FooterTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Packaging" DataField="Format" DataType="System.Int32" UniqueName="Format" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                <ItemTemplate>

                                                    <asp:Label runat="server" Text='<%#Eval("Format").ToString()%>' ID="lblFormat"></asp:Label>



                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="server" ID="lblTotalPackFormat"></asp:Label>

                                                </FooterTemplate>

                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="">
                                                <ItemTemplate>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>

                                        </Columns>

                                        <FooterStyle HorizontalAlign="left" />

                                    </MasterTableView>
                                </telerik:RadGrid>

                                <asp:UpdateProgress ID="UpdateProgress6" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updloose">
                                    <ProgressTemplate>

                                        <div class="full-pop-up">
                                            <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>

                                <asp:UpdatePanel ID="updloose" runat="server">
                                    <ContentTemplate>
                                        <asp:HiddenField ID="LooseID" runat="server" Value="0" />

                                        <telerik:RadGrid AllowAutomaticUpdates="false" ID="rgdPackingListLoose" runat="server"
                                            GridLines="None" AutoGenerateColumns="False"
                                            Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" ShowHeader="false" OnItemCommand="rgdPackingListLoose_ItemCommand">

                                            <MasterTableView AllowAutomaticUpdates="false" DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none">
                                                <GroupByExpressions>

                                                    <telerik:GridGroupByExpression>
                                                        <GroupByFields>
                                                            <telerik:GridGroupByField FieldName="PackagingType" HeaderValueSeparator=":" SortOrder="Ascending" />
                                                        </GroupByFields>
                                                        <SelectFields>
                                                            <telerik:GridGroupByField FieldName="PackagingType" HeaderText="Packaging Type" />
                                                        </SelectFields>
                                                    </telerik:GridGroupByExpression>
                                                </GroupByExpressions>
                                                <Columns>


                                                    <telerik:GridTemplateColumn HeaderText="" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                        <ItemTemplate>
                                                            <div class="">
                                                                <%#Container.DataSetIndex + 1%>
                                                            </div>
                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                        <ItemTemplate>
                                                            <asp:Label Text='<%#Eval("Id")%>' runat="server" ID="lblBatchID"></asp:Label>
                                                            <asp:Label Text='<%#Eval("StockBatchId")%>' runat="server" ID="lblStockBatchId"></asp:Label>

                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                        <ItemTemplate>
                                                            <%#Eval("BatchNo")%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            Total Packaging:                               
                                                        </FooterTemplate>
                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderStyle-Width="250" ItemStyle-Width="250" HeaderText="" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                                                        <ItemTemplate>

                                                            <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("RemainingQty")), 3)%>' ID="lblQuantity"></asp:Label>


                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label runat="server" ID="lblTotalQuatity"></asp:Label>

                                                        </FooterTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="" DataField="Format" DataType="System.Int32" UniqueName="Format" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                        <ItemTemplate>

                                                            <asp:Label runat="server" Text='<%#Eval("Format").ToString()%>' ID="lblFormat"></asp:Label>





                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label runat="server" ID="lblTotalPackFormat"></asp:Label>

                                                        </FooterTemplate>

                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEditLoose" runat="server" CausesValidation="false" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("Id")%>'></asp:LinkButton>

                                                        </ItemTemplate>

                                                    </telerik:GridTemplateColumn>

                                                </Columns>

                                                <FooterStyle HorizontalAlign="left" />

                                            </MasterTableView>
                                        </telerik:RadGrid>




                                        <telerik:RadGrid ID="rgdEditLoosePAck" runat="server"
                                            GridLines="None" AutoGenerateColumns="False"
                                            Skin="Office2010Black"
                                            ShowFooter="true" Visible="false" Style="width: 50%">

                                            <MasterTableView DataKeyNames="childID" GridLines="None" Width="100%" CommandItemDisplay="none" TableLayout="Fixed" ShowFooter="true" ShowHeader="true">

                                                <Columns>

                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="" DataField="LevelID" DataType="System.String" UniqueName="LevelID">
                                                        <ItemTemplate>

                                                            <%#Eval("LevelID")%>
                                                            <asp:Label Text='<%#Eval("LooseID")%>' runat="server" ID="lblLooseID"></asp:Label>

                                                        </ItemTemplate>


                                                    </telerik:GridTemplateColumn>

                                                    <telerik:GridTemplateColumn HeaderText="Edit Loose Packaging" DataField="Level" DataType="System.String" UniqueName="Level">
                                                        <ItemTemplate>

                                                            <asp:Literal ID="ltr" runat="server" Text=' <%#Eval("Level")%>'></asp:Literal>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>

                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="" DataField="LevelID" DataType="System.Int32" UniqueName="LevelID">
                                                        <ItemTemplate>
                                                            <telerik:RadNumericTextBox NumberFormat-DecimalDigits="0" ValidationGroup="pgrp" runat="server" ID="txtLevel" Width="100"></telerik:RadNumericTextBox>
                                                            <asp:RequiredFieldValidator ID="kjsdldsjls" ValidationGroup="pgrp" runat="server" Text="*" ErrorMessage="Level," ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtLevel"></asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Button ID="btnUpdateLoose" runat="server" Text="Update" OnClick="btnUpdateLoose_Click" />
                                                            <asp:Button ID="btnCancelLooseEdit" runat="server" Text="Cancel" OnClick="btnCancelLooseEdit_Click" />
                                                        </FooterTemplate>

                                                    </telerik:GridTemplateColumn>






                                                </Columns>


                                                <FooterStyle HorizontalAlign="left" />

                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="row" runat="server" id="divIntroPack">
                                <p>Full Packaging:</p>
                                <table style="width: 97%">
                                    <tr>

                                        <td>
                                            <asp:Label runat="server" ID="lblQtyFullPack" Style="float: right"></asp:Label></td>
                                    </tr>
                                </table>
                                <telerik:RadGrid ID="rgdFullPack" runat="server"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">

                                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none">

                                        <Columns>


                                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                <ItemTemplate>
                                                    <div class="">
                                                        <%#Container.DataSetIndex + 1%>
                                                    </div>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%#Eval("Id")%>' runat="server" ID="lblBatchID"></asp:Label>

                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                                <ItemTemplate>
                                                    <%#Eval("BatchNo")%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    Total Full Packaging:                               
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Quantity" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                                                <ItemTemplate>

                                                    <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("Quantity")), 3)%>' ID="lblQuantity"></asp:Label>


                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="server" ID="lblTotalQuatity"></asp:Label>

                                                </FooterTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Full Packaging" DataField="Packaging" DataType="System.Int32" UniqueName="Packaging">
                                                <ItemTemplate>

                                                    <asp:Label runat="server" Text='<%#Eval("Packaging").ToString()%>' ID="lblFormat"></asp:Label>



                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="server" ID="lblTotalPackFormat"></asp:Label>

                                                </FooterTemplate>

                                            </telerik:GridTemplateColumn>



                                        </Columns>

                                        <FooterStyle HorizontalAlign="left" />

                                    </MasterTableView>
                                </telerik:RadGrid>
                                <p>Loose Packaging:</p>
                                <telerik:RadGrid ID="rgdLoosePAck" runat="server"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" OnItemCreated="rgdLoosePAck_ItemCreated">

                                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none">

                                        <Columns>


                                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                <ItemTemplate>
                                                    <div class="">
                                                        <%#Container.DataSetIndex + 1%>
                                                    </div>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%#Eval("Id")%>' runat="server" ID="lblBatchID"></asp:Label>

                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                                <ItemTemplate>
                                                    <%#Eval("BatchNo")%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    Total Loose Packaging:                  
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Quantity" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("Quantity")), 3)%>' ID="lblQuantity"></asp:Label>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="server" ID="lblTotalQuatity"></asp:Label>

                                                </FooterTemplate>

                                            </telerik:GridTemplateColumn>


                                            <telerik:GridTemplateColumn HeaderText="Introduce loose packaging" DataField="Packaging" DataType="System.String" UniqueName="Packaging">
                                                <ItemTemplate>



                                                    <telerik:RadGrid ID="rgdChildLoosePAck" runat="server"
                                                        GridLines="None" AutoGenerateColumns="False"
                                                        Width="97%" Skin="Office2010Black"
                                                        ShowFooter="false">

                                                        <MasterTableView DataKeyNames="childID" GridLines="None" Width="100%" CommandItemDisplay="none" TableLayout="Fixed" ShowFooter="false" ShowHeader="false">

                                                            <Columns>

                                                                <telerik:GridTemplateColumn Visible="false" HeaderText="" DataField="LevelID" DataType="System.String" UniqueName="LevelID">
                                                                    <ItemTemplate>

                                                                        <%#Eval("LevelID")%>
                                                                    </ItemTemplate>


                                                                </telerik:GridTemplateColumn>

                                                                <telerik:GridTemplateColumn HeaderText="" DataField="Level" DataType="System.String" UniqueName="Level">
                                                                    <ItemTemplate>
                                                                        <%#Eval("Level")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                    </FooterTemplate>

                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn HeaderText="" DataField="LevelID" DataType="System.Int32" UniqueName="LevelID">
                                                                    <ItemTemplate>
                                                                        <telerik:RadNumericTextBox NumberFormat-DecimalDigits="0" ValidationGroup="pgrp" runat="server" ID="txtLevel" Width="100"></telerik:RadNumericTextBox>
                                                                        <asp:RequiredFieldValidator ID="RequsddsdiredFidsssseldValddddidator4" ValidationGroup="pgrp" runat="server" Text="*" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtLevel"></asp:RequiredFieldValidator>
                                                                    </ItemTemplate>


                                                                </telerik:GridTemplateColumn>






                                                            </Columns>


                                                            <FooterStyle HorizontalAlign="left" />

                                                        </MasterTableView>
                                                    </telerik:RadGrid>


                                                    <asp:Label Style="margin-left: 42%" runat="server" ID="lblTotalQuatity" Text='<%# "Pieces/QTY: " + TruncateDecimalToString(Convert.ToDouble(Eval("Quantity")), 3)%>'></asp:Label>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>


                                            </telerik:GridTemplateColumn>




                                        </Columns>


                                        <FooterStyle HorizontalAlign="left" />

                                    </MasterTableView>
                                </telerik:RadGrid>

                                <div class="row">
                                    <div class="col-md-12 text-align-center" style="margin-top: 5px;">


                                        <asp:Button ValidationGroup="pgrp" runat="server" ID="btnPackSubmit" Text="Submit" OnClick="btnPackSubmit_Click" />
                                        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="pgrp"
                                            DisplayMode="SingleParagraph"
                                            EnableClientScript="true"
                                            HeaderText="(*) indicates fields are required!"
                                            runat="server" />
                                    </div>
                                </div>

                            </div>



                        </div>
                    </Content>
                </asp:AccordionPane>

                <asp:AccordionPane ID="acDW" runat="server" Visible="false">
                    <Header>DW Packaging</Header>
                    <Content>
                        <div class="container">

                            <div class="row" runat="server" id="dvDWShow">
                                <p>Packaging:</p>
                                <telerik:RadGrid ID="rgdDWShow" runat="server"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Width="90%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">

                                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none">
                                        <GroupByExpressions>

                                            <telerik:GridGroupByExpression>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="PackagingType" HeaderValueSeparator=":" SortOrder="Ascending" />
                                                </GroupByFields>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldName="PackagingType" HeaderText="Packaging Type" />
                                                </SelectFields>
                                            </telerik:GridGroupByExpression>
                                        </GroupByExpressions>
                                        <Columns>


                                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                <ItemTemplate>
                                                    <div class="">
                                                        <%#Container.DataSetIndex + 1%>
                                                    </div>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%#Eval("Id")%>' runat="server" ID="lblBatchID"></asp:Label>

                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                <ItemTemplate>
                                                    <%#Eval("BatchNo")%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    Total:
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Quantity" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                <ItemTemplate>

                                                    <asp:Label runat="server" Text='<%#(Convert.ToDouble(Eval("RemainingQty")).ToString("0"))%>' ID="lblQuantity"></asp:Label>


                                                </ItemTemplate>

                                                <FooterTemplate>

                                                    <asp:Label runat="server" ID="lblTotalQuatity"></asp:Label>

                                                </FooterTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="DW PM" DataField="Format" DataType="System.Int32" UniqueName="Format" HeaderStyle-Width="250" ItemStyle-Width="250">
                                                <ItemTemplate>

                                                    <asp:Label runat="server" Text='<%#Eval("Format").ToString()%>' ID="lblFormat"></asp:Label>



                                                </ItemTemplate>
                                                <FooterTemplate>


                                                    <asp:Label runat="server" ID="lblTotalPackFormat"></asp:Label>

                                                </FooterTemplate>

                                            </telerik:GridTemplateColumn>



                                        </Columns>

                                        <FooterStyle HorizontalAlign="left" />

                                    </MasterTableView>
                                </telerik:RadGrid>

                            </div>
                            <div class="row" runat="server" id="dvDWSave">


                                <p>Introduce  Packaging:</p>
                                <telerik:RadGrid ID="rhdDWDefine" runat="server"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Width="90%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">

                                    <MasterTableView DataKeyNames="tBatchId" GridLines="None" Width="100%" CommandItemDisplay="none">

                                        <Columns>


                                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                <ItemTemplate>
                                                    <div class="">
                                                        <%#Container.DataSetIndex + 1%>
                                                    </div>
                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%#Eval("tRecQty")%>' runat="server" ID="lblBatchID"></asp:Label>

                                                </ItemTemplate>

                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                                <ItemTemplate>
                                                    <%#Eval("BatchNo")%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Quantity" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%# (Convert.ToDouble(Eval("tRecQty")).ToString("0"))%>' ID="lblQuantity"></asp:Label>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="server" ID="lblTotalQuatity"></asp:Label>

                                                </FooterTemplate>

                                            </telerik:GridTemplateColumn>


                                            <telerik:GridTemplateColumn HeaderText="Define DW PM" DataField="Packaging" DataType="System.String" UniqueName="Packaging">
                                                <ItemTemplate>

                                                    <telerik:RadNumericTextBox NumberFormat-DecimalDigits="0" ValidationGroup="dw" runat="server" ID="txtPack"></telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="kjsdldsjls" ValidationGroup="dw" runat="server" Text="*" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtPack"></asp:RequiredFieldValidator>





                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>


                                            </telerik:GridTemplateColumn>




                                        </Columns>


                                        <FooterStyle HorizontalAlign="left" />

                                    </MasterTableView>
                                </telerik:RadGrid>

                                <div class="row">
                                    <div class="col-md-12 text-align-center" style="margin-top: 5px;">


                                        <asp:Button ValidationGroup="dw" runat="server" ID="btnSubmitDW" Text="Submit" OnClick="btnSubmitDW_Click" />
                                        <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="dw"
                                            DisplayMode="SingleParagraph"
                                            EnableClientScript="true"
                                            HeaderText="(*) indicates fields are required!"
                                            runat="server" />
                                    </div>
                                </div>

                            </div>



                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="apCRV" runat="server">
                    <Header>Summary </Header>
                    <Content>
                        <div runat="server" id="div4">


                            <p>Summary:</p>
                            <asp:UpdateProgress ID="UpdateProgress10" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel3">
                                <ProgressTemplate>

                                    <div class="full-pop-up">
                                        <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>

                            <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                <ContentTemplate>

                                    <table style="width: 95%">

                                        <tr>


                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCRVNo" runat="server" ValidationGroup="gCRV" placeholder="Enter CRV No"></asp:TextBox>
                                                <asp:RequiredFieldValidator ControlToValidate="txtCRVNo" ID="rq" runat="server" ValidationGroup="gCRV" ErrorMessage="* CRV No required !" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                                                <asp:Button Visible="false" OnClientClick="return confirm('Are you sure you want to Generate CRV?');" runat="server" Text="Generate CRV" OnClick="Unnamed_Click" ID="btnGenCRV" ValidationGroup="gCRV" />
                                                <asp:Button OnClientClick="return confirm('Are you sure you want to Generate CRV?');" runat="server" Text="Generate CRV" OnClick="btnSubmitCRV_Click" ID="btnSubmitCRV" ValidationGroup="gCRV" />


                                                <asp:Button runat="server" Text="Add New Product" OnClick="btnNewProduct_Click" ID="btnNewProduct" />
                                            </td>
                                        </tr>
                                    </table>

                                    <telerik:RadGrid ID="rgdCRV" runat="server"
                                        GridLines="None" AutoGenerateColumns="False"
                                        Width="95%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true" OnItemCreated="rgdCRV_ItemCreated">

                                        <MasterTableView DataKeyNames="SID" GridLines="None" Width="100%" CommandItemDisplay="none">

                                            <Columns>


                                                <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                    <ItemTemplate>
                                                        <div class="">
                                                            <%#Container.DataSetIndex + 1%>
                                                            <asp:HiddenField ID="hdnSID" runat="server" Value='<%#Eval("CatID")%>' />
                                                            <asp:HiddenField ID="hdnLevel" runat="server" Value='<%#Eval("SupplierId")%>' />

                                                        </div>
                                                    </ItemTemplate>

                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="AT/SO No" DataField="ATNo" DataType="System.String" UniqueName="ATNo">
                                                    <ItemTemplate>
                                                        <asp:Label Text='<%#Eval("ATNo")%>' runat="server" ID="lblBatchID" Visible="false"></asp:Label>

                                                        <%-- <%# (Eval("ATNo").ToString()==""? "Supply Order NO:":"AT NO:")%>--%>


                                                        <asp:Label runat="server" ID="nn" Text='<%#Eval("ATSONo")%>' Style="height: 100%; width: 55px; word-wrap: break-word; display: block"></asp:Label>
                                                    </ItemTemplate>

                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn HeaderText="Items" DataField="ITEMS" DataType="System.String" UniqueName="ITEMS">
                                                    <ItemTemplate>
                                                        <%#Eval("ITEMS")%>
                                                    </ItemTemplate>

                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="A/U" DataField="AU" DataType="System.String" UniqueName="AU">
                                                    <ItemTemplate>
                                                        <%#Eval("AU")%>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn Visible="false" HeaderText="Packaging Material " DataField="AU" DataType="System.String" UniqueName="AU">
                                                    <ItemTemplate>
                                                        <%#(Eval("PackingMaterial").ToString() == "" ? "" : Eval("PackingMaterial"))%><%#(Eval("PackingMaterialFormat").ToString() == "" ? "" : "[" + Eval("PackingMaterialFormat") + "]")%>
                                                    </ItemTemplate>

                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Batch(s)" DataField="Quantity" DataType="System.Int32" UniqueName="Quantity">
                                                    <ItemTemplate>

                                                        <telerik:RadGrid ID="rgdCRVBatch" runat="server"
                                                            GridLines="None" AutoGenerateColumns="False"
                                                            Width="97%" EnableAJAX="True" Skin="Office2010Black">
                                                            <%--OnItemCreated="rgdCRVBatch_ItemCreated" > --%>

                                                            <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" ShowHeader="true">
                                                                <GroupByExpressions>

                                                                    <telerik:GridGroupByExpression>
                                                                        <GroupByFields>
                                                                            <telerik:GridGroupByField FieldName="BatchNo" HeaderValueSeparator=":" SortOrder="Ascending" />
                                                                        </GroupByFields>
                                                                        <SelectFields>
                                                                            <telerik:GridGroupByField FieldName="BatchNo" HeaderText="Batch No" />
                                                                        </SelectFields>
                                                                    </telerik:GridGroupByExpression>
                                                                </GroupByExpressions>
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="BID">
                                                                        <ItemTemplate>
                                                                            <%#Eval("BID")%>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <%-- <telerik:GridTemplateColumn  HeaderText="Batch No" DataField="BatchNo" DataType="System.String" UniqueName="BatchNo">
                                    <ItemTemplate>
                              
                                         <asp:Label runat="server" ID="lblBatchNo" Text='<%#Eval("BatchNo").ToString()%>'></asp:Label>
                                
                            
                                    </ItemTemplate>
                          
                                </telerik:GridTemplateColumn>--%>

                                                                    <telerik:GridTemplateColumn HeaderText="Packaging" DataField="Format" DataType="System.String" UniqueName="Format">
                                                                        <ItemTemplate>
                                                                            <%#Eval("PackagingType")%>:
                                          <asp:Label runat="server" ID="lblFormat" Text='<%#Eval("Format").ToString()%>'></asp:Label>

                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            Total Quantity:
                                                       <asp:Label runat="server" ID="lblTotalQuatity"></asp:Label>

                                                                        </FooterTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn HeaderText="Quantity" DataField="RemainingQty" DataType="System.String" UniqueName="BatchNo">
                                                                        <ItemTemplate>

                                                                            <asp:Label runat="server" ID="lblRemainingQty" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("RemainingQty")), 3)%>'></asp:Label>

                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            Full Packaging:
                                    <asp:Label runat="server" ID="lblTotalFullFormat"></asp:Label>

                                                                        </FooterTemplate>
                                                                    </telerik:GridTemplateColumn>



                                                                    <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lblMFGDate" Text='<%#Eval("MFGDate").ToString()%>'></asp:Label>


                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            Loose Packaging:
                                    <asp:Label runat="server" ID="lblTotalLooseFormat"></asp:Label>

                                                                        </FooterTemplate>
                                                                    </telerik:GridTemplateColumn>

                                                                    <telerik:GridTemplateColumn HeaderText="ESL" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lblEsl" Text='<%#Eval("Esl").ToString()%>'></asp:Label>



                                                                        </ItemTemplate>

                                                                    </telerik:GridTemplateColumn>

                                                                    <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lblEXPDate" Text='<%#Eval("EXPDate").ToString()%>'></asp:Label>


                                                                        </ItemTemplate>

                                                                    </telerik:GridTemplateColumn>



                                                                    <telerik:GridTemplateColumn HeaderText="Cost " DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                                                        <ItemTemplate>

                                                                            <asp:Label Visible="false" runat="server" ID="lblCost" Text='<%#Eval("Cost")%>'></asp:Label>
                                                                            <asp:Label runat="server" ID="lblCostAU" Text='<%#(Eval("CostOfParticular").ToString() == "" ? "" : Eval("CostOfParticular").ToString() + " per " + AU)%>'></asp:Label>



                                                                        </ItemTemplate>

                                                                    </telerik:GridTemplateColumn>

                                                                    <telerik:GridTemplateColumn HeaderText="Weight" DataField="Weight" DataType="System.Double" UniqueName="Weight">
                                                                        <ItemTemplate>


                                                                            <asp:Label runat="server" ID="lblWeight" Text='  <%#(Eval("Weight").ToString() == "" ? "" : TruncateDecimalToString(Convert.ToDouble(Eval("Weight").ToString()), 3) + " " + Eval("WeightUnit"))%>'></asp:Label>

                                                                            <asp:Label Visible="false" runat="server" ID="lblWeightAU" Text='  <%#(Eval("WeightofParticular").ToString() == "" ? "" : TruncateDecimalToString(Convert.ToDouble(Eval("WeightofParticular").ToString()), 3) + " " + Eval("WeightUnit") + " per " + AU)%>'></asp:Label>


                                                                        </ItemTemplate>

                                                                    </telerik:GridTemplateColumn>


                                                                    <telerik:GridTemplateColumn HeaderText="Vehicle">

                                                                        <ItemTemplate>
                                                                            <telerik:RadGrid ID="rdsVehicleList" runat="server"
                                                                                GridLines="None" AutoGenerateColumns="False"
                                                                                Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">

                                                                                <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false">

                                                                                    <GroupByExpressions>
                                                                                        <telerik:GridGroupByExpression>
                                                                                            <GroupByFields>
                                                                                                <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderValueSeparator=":" SortOrder="None" />
                                                                                            </GroupByFields>
                                                                                            <SelectFields>
                                                                                                <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderText="." />
                                                                                            </SelectFields>
                                                                                        </telerik:GridGroupByExpression>
                                                                                        <telerik:GridGroupByExpression>
                                                                                            <GroupByFields>
                                                                                                <telerik:GridGroupByField FieldName="VehicleNo" HeaderValueSeparator=":" SortOrder="None" />
                                                                                            </GroupByFields>
                                                                                            <SelectFields>
                                                                                                <telerik:GridGroupByField FieldName="VehicleNo" HeaderText="Vehicle No" />
                                                                                            </SelectFields>
                                                                                        </telerik:GridGroupByExpression>
                                                                                        <telerik:GridGroupByExpression>
                                                                                            <GroupByFields>
                                                                                                <telerik:GridGroupByField FieldName="DriverName" HeaderValueSeparator=":" SortOrder="None" />
                                                                                            </GroupByFields>
                                                                                            <SelectFields>
                                                                                                <telerik:GridGroupByField FieldName="DriverName" HeaderText="Driver Name" />
                                                                                            </SelectFields>
                                                                                        </telerik:GridGroupByExpression>
                                                                                    </GroupByExpressions>
                                                                                    <Columns>



                                                                                        <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="Id">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Id")%>
                                                                                            </ItemTemplate>
                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="" DataField="DriverName" DataType="System.String" UniqueName="DriverName">
                                                                                            <ItemTemplate>
                                                                                                <%-- <%#Eval("DriverName") %>--%>
                                                                                            </ItemTemplate>

                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="" DataField="VehicleNo" DataType="System.String" UniqueName="VehicleNo">
                                                                                            <ItemTemplate>
                                                                                                <%-- <%#Eval("VehicleNo").ToString() %>   --%>
                                                                                            </ItemTemplate>

                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                                                            <ItemTemplate>
                                                                                                <div class="">
                                                                                                    <%#Container.DataSetIndex + 1%>
                                                                                                </div>
                                                                                            </ItemTemplate>

                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="Challan No" DataField="ChallanNo" DataType="System.String" UniqueName="ChallanNo">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("ChallanNo").ToString()%>
                                                                                            </ItemTemplate>

                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="Bacth No" DataField="StockBatchId" DataType="System.Int32" UniqueName="StockBatchId">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("BatchNo").ToString()%>
                                                                                            </ItemTemplate>

                                                                                        </telerik:GridTemplateColumn>


                                                                                        <telerik:GridTemplateColumn HeaderText="Sent Qty" DataField="SentQty" DataType="System.Int32" UniqueName="SentQty">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("SentQty")), 3)%>' ID="leeebl"></asp:Label>


                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:Label ID="lblQtySent" runat="server"></asp:Label>
                                                                                            </FooterTemplate>
                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="Recieved Qty" DataField="RecievedQty" DataType="System.Int32" UniqueName="RecievedQty">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("RecievedQty")), 3)%>' ID="lsssbl"></asp:Label>

                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:Label ID="lblQtyRec" runat="server"></asp:Label>
                                                                                            </FooterTemplate>
                                                                                        </telerik:GridTemplateColumn>



                                                                                    </Columns>




                                                                                </MasterTableView>
                                                                            </telerik:RadGrid>
                                                                            <asp:Label runat="server" ID="lblthisFormatQty" Visible="false"></asp:Label>
                                                                            <br />
                                                                            <asp:Label runat="server" ID="lblthisFullQty" Visible="false"></asp:Label>

                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>



                                                                </Columns>

                                                                <FooterStyle HorizontalAlign="Left" />

                                                            </MasterTableView>
                                                        </telerik:RadGrid>

                                                        <telerik:RadGrid ID="rgdBatchWithoutPacking" runat="server"
                                                            GridLines="None" AutoGenerateColumns="False"
                                                            Width="97%" EnableAJAX="True" Skin="Office2010Black">
                                                            <%--OnItemCreated="rgdCRVBatch_ItemCreated" > --%>

                                                            <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false" ShowHeader="true">
                                                                <GroupByExpressions>

                                                                    <telerik:GridGroupByExpression>
                                                                        <GroupByFields>
                                                                            <telerik:GridGroupByField FieldName="BatchNo" HeaderValueSeparator=":" SortOrder="Ascending" />
                                                                        </GroupByFields>
                                                                        <SelectFields>
                                                                            <telerik:GridGroupByField FieldName="BatchNo" HeaderText="Batch No" />
                                                                        </SelectFields>
                                                                    </telerik:GridGroupByExpression>
                                                                </GroupByExpressions>
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="BID">
                                                                        <ItemTemplate>
                                                                            <%#Eval("BID")%>
                                                                            <asp:HiddenField ID="hdnBID" runat="server" Value='<%#Eval("BID")%>' />
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>





                                                                    <telerik:GridTemplateColumn HeaderText="DOM" DataField="MFGDate" DataType="System.DateTime" UniqueName="MFGDate">
                                                                        <ItemTemplate>
                                                                            <%#Eval("MFGDate").ToString() == "" ? "N/A" : Convert.ToDateTime(Eval("MFGDate")).ToString("dd-MM-yyyy")%>
                                                                        </ItemTemplate>

                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn HeaderText="ESL" DataField="Esl" DataType="System.DateTime" UniqueName="Esl">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lblEsl" Text='<%#Eval("Esl").ToString() == "" ? "N/A" : Convert.ToDateTime(Eval("Esl")).ToString("MMM-yyyy")%>'></asp:Label>



                                                                        </ItemTemplate>

                                                                    </telerik:GridTemplateColumn>

                                                                    <telerik:GridTemplateColumn HeaderText="Expiry  Date" DataField="EXPDate" DataType="System.DateTime" UniqueName="EXPDate">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lblEXPDate" Text='  <%#Eval("EXPDate").ToString() == "" ? "N/A" : Convert.ToDateTime(Eval("EXPDate")).ToString("dd-MM-yyyy")%>    '></asp:Label>


                                                                        </ItemTemplate>

                                                                    </telerik:GridTemplateColumn>



                                                                    <telerik:GridTemplateColumn HeaderText="Cost " DataField="Cost" DataType="System.Double" UniqueName="Cost">
                                                                        <ItemTemplate>

                                                                            <asp:Label runat="server" ID="lblCostAU" Text='<%#(Eval("CostOfParticular").ToString() == "" ? "" : Eval("CostOfParticular").ToString() + " per " + AU)%>'></asp:Label>



                                                                        </ItemTemplate>

                                                                    </telerik:GridTemplateColumn>


                                                                    <telerik:GridTemplateColumn HeaderText="Weight" DataField="Weight" DataType="System.Double" UniqueName="Weight">
                                                                        <ItemTemplate>


                                                                            <asp:Label runat="server" ID="lblWeight" Text='  <%#(Eval("Weight").ToString() == "" ? "" : TruncateDecimalToString(Convert.ToDouble(Eval("Weight").ToString()), 3) + " " + Eval("WeightUnit"))%>'></asp:Label>

                                                                            <asp:Label Visible="false" runat="server" ID="lblWeightAU" Text='  <%#(Eval("WeightofParticular").ToString() == "" ? "" : TruncateDecimalToString(Convert.ToDouble(Eval("WeightofParticular").ToString()), 3) + " " + Eval("WeightUnit") + " per " + AU)%>'></asp:Label>


                                                                        </ItemTemplate>

                                                                    </telerik:GridTemplateColumn>


                                                                    <telerik:GridTemplateColumn HeaderText="Vehicle">

                                                                        <ItemTemplate>
                                                                            <telerik:RadGrid ID="rdsVehicleList" runat="server"
                                                                                GridLines="None" AutoGenerateColumns="False"
                                                                                Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">

                                                                                <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none" ShowFooter="false">

                                                                                    <GroupByExpressions>
                                                                                        <telerik:GridGroupByExpression>
                                                                                            <GroupByFields>
                                                                                                <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderValueSeparator=":" SortOrder="None" />
                                                                                            </GroupByFields>
                                                                                            <SelectFields>
                                                                                                <telerik:GridGroupByField FieldName="IsDDOrCHT" HeaderText="." />
                                                                                            </SelectFields>
                                                                                        </telerik:GridGroupByExpression>
                                                                                        <telerik:GridGroupByExpression>
                                                                                            <GroupByFields>
                                                                                                <telerik:GridGroupByField FieldName="VehicleNo" HeaderValueSeparator=":" SortOrder="None" />
                                                                                            </GroupByFields>
                                                                                            <SelectFields>
                                                                                                <telerik:GridGroupByField FieldName="VehicleNo" HeaderText="Vehicle No" />
                                                                                            </SelectFields>
                                                                                        </telerik:GridGroupByExpression>
                                                                                        <telerik:GridGroupByExpression>
                                                                                            <GroupByFields>
                                                                                                <telerik:GridGroupByField FieldName="DriverName" HeaderValueSeparator=":" SortOrder="None" />
                                                                                            </GroupByFields>
                                                                                            <SelectFields>
                                                                                                <telerik:GridGroupByField FieldName="DriverName" HeaderText="Driver Name" />
                                                                                            </SelectFields>
                                                                                        </telerik:GridGroupByExpression>
                                                                                    </GroupByExpressions>
                                                                                    <Columns>



                                                                                        <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="BatchNo" DataType="System.Int32" UniqueName="Id">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Id")%>
                                                                                            </ItemTemplate>
                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="" DataField="DriverName" DataType="System.String" UniqueName="DriverName">
                                                                                            <ItemTemplate>
                                                                                                <%-- <%#Eval("DriverName") %>--%>
                                                                                            </ItemTemplate>

                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="" DataField="VehicleNo" DataType="System.String" UniqueName="VehicleNo">
                                                                                            <ItemTemplate>
                                                                                                <%-- <%#Eval("VehicleNo").ToString() %>   --%>
                                                                                            </ItemTemplate>

                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                                                            <ItemTemplate>
                                                                                                <div class="">
                                                                                                    <%#Container.DataSetIndex + 1%>
                                                                                                </div>
                                                                                            </ItemTemplate>

                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="Challan No" DataField="ChallanNo" DataType="System.String" UniqueName="ChallanNo">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("ChallanNo").ToString()%>
                                                                                            </ItemTemplate>

                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="Bacth No" DataField="StockBatchId" DataType="System.Int32" UniqueName="StockBatchId">
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("BatchNo").ToString()%>
                                                                                            </ItemTemplate>

                                                                                        </telerik:GridTemplateColumn>


                                                                                        <telerik:GridTemplateColumn HeaderText="Sent Qty" DataField="SentQty" DataType="System.Int32" UniqueName="SentQty">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label runat="server" Text='<%# TruncateDecimalToString(Convert.ToDouble(Eval("SentQty")), 3)%>' ID="leeebl"></asp:Label>


                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:Label ID="lblQtySent" runat="server"></asp:Label>
                                                                                            </FooterTemplate>
                                                                                        </telerik:GridTemplateColumn>
                                                                                        <telerik:GridTemplateColumn HeaderText="Recieved Qty" DataField="RecievedQty" DataType="System.Int32" UniqueName="RecievedQty">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label runat="server" Text='<%#TruncateDecimalToString(Convert.ToDouble(Eval("RecievedQty")), 3)%>' ID="lsssbl"></asp:Label>

                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:Label ID="lblQtyRec" runat="server"></asp:Label>
                                                                                            </FooterTemplate>
                                                                                        </telerik:GridTemplateColumn>



                                                                                    </Columns>




                                                                                </MasterTableView>
                                                                            </telerik:RadGrid>

                                                                            <asp:Label runat="server" ID="lblthisFullQty" Visible="false"></asp:Label>

                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>



                                                                </Columns>

                                                                <FooterStyle HorizontalAlign="Left" />

                                                            </MasterTableView>
                                                        </telerik:RadGrid>

                                                        <asp:Label runat="server" ID="lblProductQty"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label runat="server" ID="lblTotalQty" Style="float: left"></asp:Label>
                                                        <asp:Label runat="server" ID="lblTotalWeight" Style="float: right"></asp:Label>
                                                    </FooterTemplate>

                                                </telerik:GridTemplateColumn>



                                                <telerik:GridTemplateColumn HeaderText="Amount" DataField="Amount" DataType="System.Int32" UniqueName="Amount">
                                                    <ItemTemplate>


                                                        <asp:Label runat="server" ID="lblCost"></asp:Label>

                                                    </ItemTemplate>
                                                    <FooterTemplate>

                                                        <asp:Label runat="server" ID="lblAmount" Text="Total Amount: "></asp:Label>

                                                    </FooterTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.Int32" UniqueName="Remarks">
                                                    <ItemTemplate>

                                                        <asp:Label runat="server" Text='<%#Eval("Remarks").ToString()%>' ID="lblFormat" Style="height: 100%; width: 55px; word-wrap: break-word; display: block"></asp:Label>



                                                    </ItemTemplate>


                                                </telerik:GridTemplateColumn>



                                            </Columns>

                                            <FooterStyle HorizontalAlign="left" />

                                        </MasterTableView>
                                    </telerik:RadGrid>

                                </ContentTemplate>
                            </asp:UpdatePanel>






                        </div>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>



    </div>

</asp:Content>
