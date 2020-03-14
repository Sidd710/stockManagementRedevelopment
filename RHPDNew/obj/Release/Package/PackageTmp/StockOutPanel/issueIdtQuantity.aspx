<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="issueIdtQuantity.aspx.cs" Inherits="Demo1.issueIdtQuantity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="heading-bg" align="center">
        <div class="container">
            <h1 style="background-color: skyblue; color: white">Issue IDT Quantity</h1>
            <asp:Button ID="btnback" runat="server" Text="Back" Style="float: right" CssClass="btn btn-primary" OnClick="btnback_Click" />
        </div>
    </div>
    <br />
    <br />


    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DynamicLayout="true" DisplayAfter="0" AssociatedUpdatePanelID="updSt">
        <ProgressTemplate>

            <div class="full-pop-up">
                <img runat="server" src="~/assets/Images/loading@2x.gif" alt="Processing......" width="70" height="70" style="margin-left: 0%" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel runat="server" ID="updSt">
        <ContentTemplate>


            <div>



                <table style="width: 100%; text-align: center;" class="customers">



                    <tr>
                        <td style="height: 50px">
                            <label class="thicker" style="font-size: large; text-align: center;">
                                <b>Unit/Depot Name:</b>
                            </label>

                            <asp:Label ID="lbldepoName" runat="server"></asp:Label>
                        </td>

                        <td style="height: 50px">
                            <label class="thicker" style="font-size: large">
                                <b>Product Name:</b>
                            </label>
                            <asp:Label ID="lblprdName" runat="server"></asp:Label></td>
                        <td style="height: 50px">

                            <label class="thicker" style="font-size: large">
                                <b>Stock Balance:</b>
                            </label>

                            <asp:Label ID="lblstockbalnace" runat="server"></asp:Label>

                        </td>

                        <td style="height: 50px">
                            <table>
                                <tr>
                                    <td>
                                        <label style="color: green"><b>Remaining IDT Quantity:</b></label>
                                        <asp:Label ID="lblRemainingIDTQTY" runat="server" Style="font: bold; font-size: large" Text="0"></asp:Label>
                                    </td>

                                </tr>
                            </table>





                        </td>
                        <td>
                            <label class="thicker" style="font-size: large">
                                <b>Add Issue Quantity: </b>
                                <asp:TextBox AutoPostBack="true" ID="txtIssuequantity" runat="server" CssClass="form-control" Style="top: 0px; left: 56px; width: 250px" OnTextChanged="txtIssuequantity_TextChanged"></asp:TextBox>
                                <asp:Label ID="lblApproxWeight" runat="server" Style="display: -moz-inline-box; color: blue"></asp:Label>

                            </label>
                        </td>

                    </tr>
                    <tr>
                        <td style="height: 50px">
                            <label class="thicker" style="font-size: large">
                                <b>A/U:</b>
                            </label>

                            <asp:Label ID="lblunit" runat="server"></asp:Label>
                        </td>

                        <td style="height: 50px">
                            <label class="thicker" style="font-size: large">
                                <b>Weight:</b>
                            </label>
                            <asp:Label ID="lblWeight" runat="server"></asp:Label></td>
                        <td style="height: 50px">

                            <label class="thicker" style="font-size: large">
                                <b>Amount:</b>
                            </label>

                            <asp:Label ID="lblAmount" runat="server"></asp:Label>

                        </td>
                        <td style="height: 50px">
                            <table>
                                <tr>
                                    <td>
                                        <label style="color: red"><b>Remaining Quantity:</b></label>
                                        <asp:Label ID="lblremainingIDT" runat="server" Style="font: bold; font-size: large"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>



                        <td style="height: 50px">
                            <asp:DropDownList runat="server" ID="ddlBatch" CssClass="dropdown" Style="height: 35px; width: 300px;" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">--No Batch found--</asp:ListItem>
                            </asp:DropDownList></td>


                    </tr>


                </table>

                <br />


            </div>


            <div id="grdbachwithproduct" style="align-content: center">


                <telerik:RadGrid ID="rgdQty" runat="server"
                    GridLines="None" AutoGenerateColumns="False"
                    Width="97%" Skin="Office2010Black" ShowFooter="true" OnItemCommand="rgdQty_ItemCommand">

                    <MasterTableView DataKeyNames="BID" GridLines="None" Width="100%" CommandItemDisplay="none">
                        <Columns>


                            <telerik:GridTemplateColumn HeaderText="SNo." AllowFiltering="false" HeaderStyle-CssClass="aligncenter GridHeader_Sunset">
                                <ItemTemplate>
                                    <div class="">
                                        <%#Container.DataSetIndex+1%>
                                    </div>
                                </ItemTemplate>

                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn Visible="false" HeaderText="Batch No" DataField="ATNo" DataType="System.String" UniqueName="BatchNo">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblSID" Text='<%#Eval("SID") %>'> </asp:Label>

                                    <asp:Label runat="server" ID="lblBID" Text='<%#Eval("BID") %>'> </asp:Label>

                                </ItemTemplate>

                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Batch No" DataField="ATNo" DataType="System.String" UniqueName="BatchNo">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBatchName" Text='<%#Eval("BatchName") %>'> </asp:Label>


                                </ItemTemplate>

                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="Esl" DataField="Esl" DataType="System.String" UniqueName="Esl">
                                <ItemTemplate>
                                    <%#Eval("Esl") %>
                                </ItemTemplate>

                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Batch Weight" DataField="Esl" DataType="System.String" UniqueName="Esl">
                                <ItemTemplate>
                                    <%#(Convert.ToDouble(Eval("WeightofParticular"))*Convert.ToDouble(Eval("batchTotalQuantity"))).ToString("0.000") %>
                                </ItemTemplate>

                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Batch Cost" DataField="Esl" DataType="System.String" UniqueName="Esl">
                                <ItemTemplate>
                                    <asp:Label Visible="false" runat="server" ID="lblCost" Text=' <%#(Convert.ToDouble(Eval("CostOfParticular")))%>'> </asp:Label>

                                    <%#(Convert.ToDouble(Eval("CostOfParticular"))*Convert.ToDouble(Eval("batchTotalQuantity"))).ToString("0.00") %>
                                </ItemTemplate>

                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Quantity" DataField="AU" DataType="System.String" UniqueName="Quantity">
                                <ItemTemplate>
                                    <%#Eval("batchTotalQuantity") %>
                                </ItemTemplate>

                            </telerik:GridTemplateColumn>

                            <%-- Rohit Pundeer - 17/06/2016, Added to show packing type in list.--%>
                            <telerik:GridTemplateColumn HeaderText="Packaging Type" DataField="PackagingType" DataType="System.String" UniqueName="PackagingType">
                                <ItemTemplate>
                                    <%#Eval("PackagingType").ToString() %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>


                            <telerik:GridTemplateColumn HeaderText="Full Packing" DataField="FullPack" DataType="System.Int32" UniqueName="FullPack">
                                <ItemTemplate>

                                    <asp:Label runat="server" Text='<%#Eval("FullPack").ToString() %>' ID="lblFullPack"></asp:Label>

                                    <asp:Label runat="server" Text='<%#"[Qty: "+Eval("FullPackQty").ToString()+"]" %>' ID="lblFullPackQty"></asp:Label>



                                </ItemTemplate>

                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Issue Qty from Full" DataField="Remarks" DataType="System.Int32" UniqueName="IssuQtyFromFull">
                                <ItemTemplate>

                                    <telerik:RadNumericTextBox Value='<%#Eval("txtFullQtyVal") %>' ToolTip='<%#Eval("BID").ToString() %>' AutoPostBack="true" OnTextChanged="txtFullQty_TextChanged" ID="txtFullQty" runat="server" ValidationGroup="sgrp"></telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="reqswdsd" runat="server" ControlToValidate="txtFullQty" ValidationGroup="sgrp"></asp:RequiredFieldValidator>
                                    <asp:Label runat="server" ID="lblFullQty" Text='<%#Eval("lblFullQtyText") %>'></asp:Label>
                                    <br />
                                    <asp:Label runat="server" ID="lblFullRemQty" Text='<%#Eval("lblFullRemQtyText") %>'></asp:Label>

                                </ItemTemplate>


                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Loose/DW/Others Packing" DataField="LoosePack" DataType="System.Int32" UniqueName="LoosePack">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("LoosePack").ToString() %>' ID="lblLoosePack"></asp:Label>

                                    <asp:Label runat="server" Text='<%#"[Qty: "+Eval("LoosePackQty").ToString()+" ]" %>' ID="lblLoosePackQty"></asp:Label>

                                </ItemTemplate>

                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Shuffle Packs" DataField="Remarks" DataType="System.Int32" UniqueName="ShufflePAcks">
                                <ItemTemplate>
                                    <asp:ImageButton AlternateText="Remove 1" ToolTip="Remove 1 Pack from Loose" ID="btnPrev" runat="server" ImageUrl="~/assets/Images/prev.png" Height="30" Width="30" CommandName="Prev" Enabled="false" CommandArgument='<%#Eval("CountPrev") %>' />
                                    <asp:ImageButton AlternateText="Add 1" ToolTip="Add 1 Pack to Loose" ID="btnNext" runat="server" ImageUrl="~/assets/Images/next.png" Height="30" Width="30" CommandName="Next" CommandArgument='<%#Eval("CountNext") %>' />

                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Issue Qty from Loose/DW/Others" DataField="Remarks" DataType="System.Int32" UniqueName="Remarks">
                                <ItemTemplate>


                                    <telerik:RadNumericTextBox Visible='<%#Convert.ToDouble(Eval("LoosePackQty").ToString())==0?false:true%>' Value='<%#Eval("txtLooseQtyVal") %>' ToolTip='<%#Eval("BID").ToString() %>' AutoPostBack="true" OnTextChanged="txtLooseQty_TextChanged" ID="txtLooseQty" runat="server" ValidationGroup="sgrp"></telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator Enabled='<%#Convert.ToDouble(Eval("LoosePackQty").ToString())==0?false:true%>' ID="resdsq" runat="server" ControlToValidate="txtLooseQty" ValidationGroup="sgrp"></asp:RequiredFieldValidator>

                                    <asp:Label runat="server" ID="lblLooseQty" Text='<%#Eval("lblLooseQtyText") %>'></asp:Label>
                                    <br />
                                    <asp:Label runat="server" ID="lblLooseRemQty" Text='<%#Eval("lblLooseRemQtyText") %>'></asp:Label>


                                </ItemTemplate>


                            </telerik:GridTemplateColumn>


                            <telerik:GridTemplateColumn HeaderText="Total Issue Qty" DataField="Remarks" DataType="System.Int32" UniqueName="Remarks">
                                <ItemTemplate>

                                    <asp:TextBox ID="txtIssueQty" runat="server" CssClass="txtIssueQty" ReadOnly="true" Value='<%#Eval("txtIssueQtyText") %>'>
                                    </asp:TextBox>
                                    <asp:ImageButton Visible="false" AlternateText="Calculate" ID="btnAdd" ToolTip="Calculate" runat="server" ImageUrl="~/assets/Images/plus-gray.png" Height="30" Width="30" CommandName="Calc" />


                                </ItemTemplate>


                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Weight" DataField="Esl" DataType="System.String" UniqueName="Esl">
                                <ItemTemplate>
                                    <asp:Label Visible="false" runat="server" ID="lblWeight" Text='<%#Convert.ToDouble(Eval("WeightofParticular"))%>'></asp:Label>
                                    <asp:Label runat="server" ID="lblQtyWeight" Text='<%#(Convert.ToDouble(Eval("WeightofParticular"))*Convert.ToDouble(Eval("txtIssueQtyText"))).ToString("0.000")%>'></asp:Label>

                                </ItemTemplate>

                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Cost" DataField="Esl" DataType="System.String" UniqueName="Esl">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblQtyCost" Text='<%#(Convert.ToDouble(Eval("CostOfParticular"))*Convert.ToDouble(Eval("txtIssueQtyText"))).ToString("0.00") %>'> </asp:Label>




                                </ItemTemplate>

                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblRemarks" Text='<%#Eval("Remarks").ToString() %>'> </asp:Label>




                                </ItemTemplate>

                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="" DataField="" DataType="System.String" UniqueName="Remarks">
                                <ItemTemplate>



                                    <asp:LinkButton runat="server" ID="lbtnRemove" Text="Remove" CommandArgument='<%#Eval("BID") %>' OnClick="lbtnRemove_Click"></asp:LinkButton>



                                </ItemTemplate>

                            </telerik:GridTemplateColumn>
                        </Columns>

                        <FooterStyle HorizontalAlign="left" />

                    </MasterTableView>
                </telerik:RadGrid>


                <table style="width: 65%" align="center" class="customers" runat="server" id="tblTotal" visible="false">

                    <tr>
                        <td colspan="3">
                            <label class="thicker" style="font-size: large">
                                <b>Total </b>
                            </label>
                        </td>
                    </tr>

                    <tr>
                        <td height="50">
                            <label class="thicker" align="center" style="font-size: large">
                                <b>Weight:</b>
                            </label>

                            <asp:Label ID="lblTotalWeight" runat="server"></asp:Label>
                        </td>

                        <td height="50">
                            <label class="thicker" style="font-size: large">
                                <b>Quantity:</b>
                            </label>
                            <asp:Label ID="lblTotalQty" runat="server"></asp:Label></td>
                        <td height="50">

                            <label class="thicker" style="font-size: large">
                                <b>Amount:</b>
                            </label>

                            <asp:Label ID="lblTotalAmt" runat="server"></asp:Label>

                        </td>



                    </tr>
                </table>



                <br />


                <div align="center">
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtRemarks" placeholder="Remarks..." Width="400" Height="50"></asp:TextBox><br />
                    <asp:Button ID="btnSubmit" ValidationGroup="sgrp" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
                </div>
            </div>


            <b style="margin-left: 5%; font-size: large">Issued IDT List</b>
            <hr />
            <br />
            <telerik:RadGrid ID="rgdIssuedList" runat="server"
                GridLines="None" AutoGenerateColumns="False"
                Width="97%" Skin="Office2010Black" ShowFooter="true" OnItemCreated="rgdIssuedList_ItemCreated">

                <MasterTableView DataKeyNames="id" GridLines="None" Width="100%" CommandItemDisplay="none">
                    <GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Quarter" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Quarter" HeaderText="Quarter" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                        <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="Depot" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="Depot" HeaderText="Depot" />
                            </SelectFields>
                        </telerik:GridGroupByExpression>
                        <telerik:GridGroupByExpression>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="ProductName" HeaderValueSeparator=":" SortOrder="None" />
                            </GroupByFields>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="ProductName" HeaderText="Product" />
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


                        <telerik:GridTemplateColumn HeaderText="Batch No" DataField="ATNo" DataType="System.String" UniqueName="BatchNo">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblBatchName" Text='<%#Eval("BatchName") %>'> </asp:Label>


                            </ItemTemplate>

                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Full Packing" DataField="FullPack" DataType="System.Int32" UniqueName="FullPack">
                            <ItemTemplate>

                                <asp:Label runat="server" ID="lblFullPack"></asp:Label>

                                <asp:Label runat="server" ID="lblFullPackQty"></asp:Label>



                            </ItemTemplate>

                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Loose/DW/Others Packing" DataField="LoosePack" DataType="System.Int32" UniqueName="LoosePack">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblLoosePack"></asp:Label>

                                <asp:Label runat="server" ID="lblLoosePackQty"></asp:Label>

                            </ItemTemplate>

                        </telerik:GridTemplateColumn>




                        <telerik:GridTemplateColumn HeaderText="Quantity" DataField="Esl" DataType="System.String" UniqueName="Esl">
                            <ItemTemplate>
                                <%#Eval("AU").ToString()=="NOS"?Convert.ToDouble(Eval("issueqty")).ToString("0.00") :Convert.ToDouble(Eval("issueqty")).ToString("0.000")%>
                            </ItemTemplate>

                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Cost" DataField="Esl" DataType="System.String" UniqueName="Esl">
                            <ItemTemplate>
                                <%#(Convert.ToDouble(Eval("CostOfParticular"))*Convert.ToDouble(Eval("issueqty"))).ToString("0.00") %>
                            </ItemTemplate>

                        </telerik:GridTemplateColumn>


                        <telerik:GridTemplateColumn HeaderText="Batch Weight" DataField="Esl" DataType="System.String" UniqueName="Esl">
                            <ItemTemplate>
                                <%#(Convert.ToDouble(Eval("WeightofParticular"))*Convert.ToDouble(Eval("issueqty"))).ToString("0.000") %>
                            </ItemTemplate>

                        </telerik:GridTemplateColumn>



                        <telerik:GridTemplateColumn HeaderText="Remarks" DataField="Remarks" DataType="System.String" UniqueName="Remarks">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblRemarks" Text='<%#Eval("Remarks").ToString() %>'> </asp:Label>




                            </ItemTemplate>

                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="" DataField="" DataType="System.String" UniqueName="Remarks">
                            <ItemTemplate>



                                <%--    <asp:LinkButton runat="server" ID="lbtnEdit" Text="Edit" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton>|--%>
                                <asp:LinkButton Visible='<%#Convert.ToInt32(Eval("issueorder_Status").ToString())==0?true:false %>' runat="server" ID="lbtnDel" Text="Delete" CommandArgument='<%#Eval("id") %>' OnClick="lbtnDel_Click"></asp:LinkButton>



                            </ItemTemplate>

                        </telerik:GridTemplateColumn>
                    </Columns>

                    <FooterStyle HorizontalAlign="left" />

                </MasterTableView>
            </telerik:RadGrid>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
