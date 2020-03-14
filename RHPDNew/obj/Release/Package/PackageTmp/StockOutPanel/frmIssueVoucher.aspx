<%@ Page Title="" Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="frmIssueVoucher.aspx.cs" Inherits="RHPDNew.StockOutPanel.frmIssueVoucher" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnBID" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdnBatchNo" runat="server" />
            <asp:HiddenField ID="hdnIssueOrderID" runat="server" />
            <div class="heading-bg" align="center">
                <div class="container">
                    <h1 style="background-color: skyblue; color: white">Issue Voucher</h1>
                </div>
            </div>
            <div id="tablefirst" runat="server">
                <table style="width: 70%" align="center" class="customers">
                    <tr>
                        <td height="50">
                            <label class="thicker" style="font-size: large"><b>Category :</b> </label>
                            <asp:Label ID="lblcategory" runat="server" Style="top: 0px; left: 56px; width: 50px"></asp:Label>
                        </td>
                        <td height="50">
                            <label class="thicker" style="font-size: large"><b>Authority:</b> </label>
                            <asp:Label ID="lblAuthority" runat="server" Style="top: 0px; left: 56px; width: 50px"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td height="50">
                            <table>
                                <tr>
                                    <td>
                                        <label class="thicker" style="font-size: large"><b>Issue Voucher No :</b> </label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtissueVoucher" runat="server" CssClass="col-lg-10 form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtissueVoucher" ID="RequiredFieldValidator2" ValidationGroup="grp" runat="server" ErrorMessage="" Text="* Required" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td height="50">
                            <table>
                                <tr>
                                    <td>
                                        <label class="thicker" style="font-size: large"><b>Date of Genration :</b> </label>
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker TabIndex="8" Culture="en-US" RenderMode="Lightweight" ID="txtdateofgenration" Width="200px" Height="28px" runat="server" DateInput-DateFormat="dd-MM-yyyy">
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ControlToValidate="txtdateofgenration" ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server" ErrorMessage="" Text="* Required" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <br />
            <div id="productgrid" runat="server">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updSt">
                    <ProgressTemplate>
                        <div class="full-pop-up">
                            <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel runat="server" ID="updSt">
                    <ContentTemplate>
                        <telerik:RadGrid ID="rgdIssueVoucher" runat="server" AutoGenerateColumns="False"
                            Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowHeader="False" OnItemCreated="rgdIssueVoucher_ItemCreated">
                            <MasterTableView DataKeyNames="productID" GridLines="None" Width="100%" CommandItemDisplay="none">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="" AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                        <ItemTemplate>
                                            <div class="">
                                                <b>Product Detail:</b>
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td><b><%#Container.DataSetIndex+1%> </b></td>
                                                        <td><b>Name:  <%#Eval("product_name") %></b></td>
                                                        <td><%#(Eval("PackingMaterialFormat").ToString()==""?"":" Packing:"+ Eval("PackingMaterial")+"["+Eval("PackingMaterialFormat")+"]")%>
                                                            <br />
                                                            <%#(Convert.ToBoolean(Eval("IsWithoutPacking").ToString())==true?"":  "Shape & size:"+Eval("PackagingMaterialShape")+ " & "+Eval("PackagingMaterialSize")+" "+Eval("ShapeUnit") +"<br />")%>        
                                                            Weight: <%#Eval("Weight") %>&nbsp <%#Eval("WeigthUnit") %> per  PM<br />
                                                        </td>
                                                        <td>Quantity:   
                                                            <asp:Label runat="server" Text='<%#Eval("productunit").ToString()=="NOS"?Convert.ToDouble(Eval("issuequantity")).ToString("0.00"):Convert.ToDouble(Eval("issuequantity")).ToString("0.000") %>' ID="lblVQty"></asp:Label>
                                                            in   <%#Eval("productunit") %></td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </div>
                                            <br />
                                            <div>
                                                <b>Vehicle Detail:</b><br />
                                                <telerik:RadGrid Visible='<%#Status==1?false:true%>' ID="rgdIssueBatch" runat="server"
                                                    GridLines="None" AutoGenerateColumns="False" Width="97%" EnableAJAX="True" Skin="Office2010Black" ShowFooter="true">
                                                    <MasterTableView DataKeyNames="BatchName" GridLines="None" Width="100%" CommandItemDisplay="none">
                                                        <Columns>
                                                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                                <ItemTemplate>
                                                                    <div class="">
                                                                        <%#Container.DataSetIndex+1%>
                                                                    </div>
                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>


                                                            <telerik:GridTemplateColumn HeaderText="Batch No" DataField="BatchName" DataType="System.String" UniqueName="BatchName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBatchNo" runat="server" Text='<%#Eval("BatchName") %>'></asp:Label>

                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Esl" DataField="BatchName" DataType="System.String" UniqueName="Esl">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEsl" runat="server" Text=' <%#Eval("Esl").ToString()!=""?Convert.ToDateTime(Eval("Esl")).ToString("dd-MM-yyyy"):"" %>'></asp:Label>

                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>



                                                            <telerik:GridTemplateColumn HeaderText="Warehouse No" DataField="WarehouseNo" DataType="System.String" UniqueName="WarehouseNo">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblWarehouseNo" runat="server" Text='<%#Eval("WarehouseNo") %>'></asp:Label>

                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Issue Quantity" DataField="issuequantity" DataType="System.Int32" UniqueName="issuequantity">
                                                                <ItemTemplate>

                                                                    <asp:Label runat="server" Text='<%#Convert.ToDouble(Eval("issueqty")).ToString("0.000") %>' ID="lblissueqty"></asp:Label>



                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    Total Issued Qty:&nbsp;<asp:Label ID="lblTotalTranfered" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Batch Weight" DataField="issuequantity" DataType="System.Int32" UniqueName="issuequantity">
                                                                <ItemTemplate>

                                                                    <asp:Label runat="server" Text='<%# Convert.ToDouble(Eval("WeightOfBatch")).ToString("0.000") %>' ID="lblWeight"></asp:Label>

                                                                    &nbsp; <%#Eval("WeightUnit") %>
                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:Panel runat="server" ID="pnlVehicle" Visible="true">


                                                                        <table>
                                                                            <tr>
                                                                                <td>Full: </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblFormatFull"></asp:Label></td>
                                                                                <td>Loose/DW/Others:</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblFormatLoose"></asp:Label></td>
                                                                                <td>Total Qty:</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblTotalQty"></asp:Label></td>

                                                                            </tr>
                                                                        </table>
                                                                        <table>
                                                                            <tr>
                                                                                <th>Vehicle No</th>
                                                                                <th>Qty</th>
                                                                                <th>Include Loose</th>
                                                                                <th>Packaging</th>
                                                                            </tr>

                                                                            <tr>
                                                                                <th>
                                                                                    <asp:HiddenField runat="server" ID="hddVechileNumber" Visible="false" />
                                                                                    <asp:DropDownList DataTextField="VechileNumber" DataValueField="Id" ID="ddlVehicle" OnDataBound="ddlVehicle_DataBound" OnSelectedIndexChanged="ddlVehicle_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                                                </th>
                                                                                <th>
                                                                                    <telerik:RadNumericTextBox ID="txtQty" runat="server" AutoPostBack="true" ToolTip='<%#Eval("BatchName")+","+Eval("ProductID")%>' OnTextChanged="txtQty_TextChanged"></telerik:RadNumericTextBox>


                                                                                </th>
                                                                                <th>
                                                                                    <asp:CheckBox runat="server" ID="cbxLoose" OnCheckedChanged="cbxLoose_CheckedChanged" AutoPostBack="true" ToolTip='<%#Eval("BatchName")+","+Eval("ProductID")%>' />

                                                                                    <div id="divLoose">
                                                                                        <telerik:RadGrid Style="width: 300px" ID="rgdChildLoosePAck" runat="server"
                                                                                            GridLines="None" AutoGenerateColumns="False"
                                                                                            Width="97%" Skin="Office2010Black"
                                                                                            ShowFooter="false" Visible="false">

                                                                                            <MasterTableView DataKeyNames="childID" GridLines="None" Width="100%" CommandItemDisplay="none" TableLayout="Fixed" ShowFooter="false" ShowHeader="false">

                                                                                                <Columns>

                                                                                                    <telerik:GridTemplateColumn Visible="false" HeaderText="" DataField="LevelID" DataType="System.String" UniqueName="LevelID">
                                                                                                        <ItemTemplate>

                                                                                                            <%#Eval("LevelID") %>
                                                                                                        </ItemTemplate>


                                                                                                    </telerik:GridTemplateColumn>

                                                                                                    <telerik:GridTemplateColumn ItemStyle-Width="10" HeaderText="" DataField="Level" DataType="System.String" UniqueName="Level">
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("Level") %>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterTemplate>
                                                                                                        </FooterTemplate>

                                                                                                    </telerik:GridTemplateColumn>
                                                                                                    <telerik:GridTemplateColumn ItemStyle-Width="25" HeaderText="" DataField="LevelID" DataType="System.Int32" UniqueName="LevelID">
                                                                                                        <ItemTemplate>
                                                                                                         <%--   <telerik:RadNumericTextBox runat="server" ID="txtLevel"></telerik:RadNumericTextBox>--%>
                                                                                                             <telerik:RadNumericTextBox runat="server" ID="txtLevel1" Width="50px"></telerik:RadNumericTextBox>|
                                                                                                             <telerik:RadNumericTextBox runat="server" ID="txtLevel2" Width="50px"></telerik:RadNumericTextBox>
                                                                                                        </ItemTemplate>


                                                                                                    </telerik:GridTemplateColumn>






                                                                                                </Columns>


                                                                                                <FooterStyle HorizontalAlign="left" />

                                                                                            </MasterTableView>
                                                                                        </telerik:RadGrid>

                                                                                    </div>
                                                                                </th>
                                                                                <th>
                                                                                    <telerik:RadNumericTextBox ID="txtPack" runat="server" Width="50" AutoPostBack="true" ToolTip='<%#Eval("BatchName")+","+Eval("ProductID")%>' OnTextChanged="txtPack_TextChanged"></telerik:RadNumericTextBox><asp:Label ID="lblPack" runat="server"></asp:Label>

                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>
                                                                                    <asp:CheckBox runat="server" Text="Full Occupied" ID="cbxFullOccupied" />
                                                                                </th>
                                                                                <th>
                                                                                    <asp:Button ID="btnAddVehicle" runat="server" Text="Add" CommandArgument='<%#Eval("BatchName")+","+Eval("ProductID")%>' OnClick="btnAddVehicle_Click" />
                                                                                    &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></th>
                                                                                <th></th>
                                                                                <th></th>
                                                                            </tr>
                                                                        </table>
                                                                        <asp:HiddenField ID="hdnVehicleID" runat="server" />

                                                                    </asp:Panel>
                                                                    <br />

                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>




                                                        </Columns>


                                                        <FooterStyle HorizontalAlign="left" />

                                                    </MasterTableView>

                                                </telerik:RadGrid><br />
                                                <telerik:RadGrid ID="rgdVehicle" runat="server"
                                                    GridLines="None" AutoGenerateColumns="False"
                                                    Width="97%" Skin="Office2010Black" ShowFooter="false">

                                                    <MasterTableView DataKeyNames="Id" GridLines="None" Width="100%" CommandItemDisplay="none">
                                                        <GroupByExpressions>

                                                            <telerik:GridGroupByExpression>
                                                                <GroupByFields>
                                                                    <telerik:GridGroupByField FieldName="BatchNo" HeaderValueSeparator=":" SortOrder="None" />
                                                                </GroupByFields>
                                                                <SelectFields>
                                                                    <telerik:GridGroupByField FieldName="BatchNo" HeaderText="Batch No" />
                                                                </SelectFields>
                                                            </telerik:GridGroupByExpression>

                                                        </GroupByExpressions>
                                                        <Columns>


                                                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                                                <ItemTemplate>
                                                                    <div class="">
                                                                        <%#Container.DataSetIndex+1%>
                                                                    </div>
                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>


                                                            <telerik:GridTemplateColumn HeaderText="Vehicle No" DataField="VehicleNo" DataType="System.String" UniqueName="VehicleNo">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVehicleNo" runat="server" Text=' <%#Eval("VehicleNo") %>'></asp:Label>

                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Stock Quantity" DataField="StockQuantity" DataType="System.String" UniqueName="StockQuantity">
                                                                <ItemTemplate>

                                                                    <asp:Label ID="lblStockQuantity" runat="server" Text=' <%#Convert.ToDouble(Eval("StockQuantity")).ToString("0.000") %>'></asp:Label>

                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Cost" DataField="issuequantity" DataType="System.Int32" UniqueName="issuequantity">
                                                                <ItemTemplate>

                                                                    <asp:Label runat="server" Text='<%# Convert.ToDouble(Eval("VCost")).ToString("0.00") %>' ID="lblVCost"></asp:Label>



                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Weight" DataField="issuequantity" DataType="System.Int32" UniqueName="issuequantity">
                                                                <ItemTemplate>

                                                                    <asp:Label runat="server" Text='<%# Convert.ToDouble(Eval("VWeight")).ToString("0.000") %>' ID="lblVWeight"></asp:Label>



                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>


                                                            <telerik:GridTemplateColumn HeaderText="Full" DataField="StockQuantity" DataType="System.String" UniqueName="Full">
                                                                <ItemTemplate>

                                                                    <asp:Label ID="lblFormatFull" runat="server" Text=' <%#Eval("FormatFull") %>'></asp:Label>

                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Loose/DW/Others" DataField="StockQuantity" DataType="System.String" UniqueName="Loose">
                                                                <ItemTemplate>

                                                                    <asp:Label ID="lblFormatLoose" runat="server" Text=' <%#Eval("FormatLoose") %>'></asp:Label>

                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>


                                                            <telerik:GridTemplateColumn HeaderText="" DataType="System.Int32" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Button Visible='<%#Status==1?false:true%>' OnClick="btnDel_Click" CommandName="Delete" OnClientClick="return confirm('Are you sure want to delete?');" runat="server" ID="btnDel" Text="Delete" CommandArgument='<%#Eval("Id") %>' />

                                                                </ItemTemplate>

                                                            </telerik:GridTemplateColumn>


                                                        </Columns>

                                                        <FooterStyle HorizontalAlign="left" />

                                                    </MasterTableView>
                                                </telerik:RadGrid>

                                            </div>
                                        </ItemTemplate>

                                        <HeaderStyle CssClass="aligncenter GridHeader_Sunset" />

                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <FooterStyle HorizontalAlign="left" />
                            </MasterTableView>
                        </telerik:RadGrid>

                    </ContentTemplate>
                </asp:UpdatePanel>


            </div>


            <br />
            <div align="center">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btngeIssuvoucher_Click" ValidationGroup="grp" />

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
