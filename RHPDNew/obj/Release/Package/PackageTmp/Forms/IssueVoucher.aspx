<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="IssueVoucher.aspx.cs" Inherits="RHPDNew.StockOutPanel.IssueVoucher" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script src="js/issueVoucher.js"></script>

    <style>
        table, th, td {
            border: 1px solid black;
            padding: 9px;
        }

        .showpopupaddqty {
            opacity: 1;
            position: fixed;
            left: 30%;
            top: 5%;
            background: none repeat scroll 0 0 #fff;
            border: 35px solid green;
            border-radius: 37px;
            box-shadow: 0 0 30px rgba(0, 0, 0, 0.32);
            color: #000;
            font-family: sans-serif;
            min-height: 850px;
            height: auto !important;
            width: 45%;
            z-index: 99999999999;
            padding-bottom: 20px;
            position: fixed;
            overflow-y: scroll;
        }

        .showpopup {
            opacity: 1;
            position: fixed;
            left: 10%;
            top: 5%;
            background: none repeat scroll 0 0 #fff;
            border: 35px solid rosybrown;
            border-radius: 37px;
            box-shadow: 0 0 30px rgba(0, 0, 0, 0.32);
            color: #000;
            font-family: sans-serif;
            min-height: 850px;
            height: auto !important;
            width: 85%;
            z-index: 99999999999;
            padding-bottom: 20px;
            position: fixed;
            overflow-y: scroll;
        }
    </style>


    <%-- <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.0/themes/base/jquery-ui.css" />
 <script src="http://code.jquery.com/jquery-1.8.3.js"></script>
 <script src="http://code.jquery.com/ui/1.10.0/jquery-ui.js"></script>--%>
    <script src="JSpath/jquery-1.8.3.min.js"></script>
    <script src="JSpath/jquery-ui.js"></script>
    <link href="JSpath/jquery-ui.css" rel="stylesheet" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script>
        $(function () {
            $("#ctl00_ContentPlaceHolder1_txtdateofgenration").datepicker();
        });
    </script>
    <asp:HiddenField ID="hdnBatchNo" runat="server" />
    <asp:Button ID="Button2" runat="server" Text="" OnClick="Button2_Click" />

    <div class="heading-bg" align="center">
        <div class="container">
            <h1 style="background-color: skyblue; color: white">Issue Voucher</h1>
        </div>
    </div>
    <br />
    <br />
    <div id="ddlcategorydiv" class="wrapper-dropdown-2" align="center" style="display: none">
        <asp:DropDownList runat="server" ID="ddlcategory" CssClass="dropdown" Style="height: 35px; width: 160px;" AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
            <asp:ListItem Value="0">Select Category</asp:ListItem>
        </asp:DropDownList>
    </div>
    <br />
    <div id="tablefirst" runat="server">
        <table style="width: 65%" align="center" class="customers">

            <tr>
                <td height="50">
                    <label class="thicker" style="font-size: large">
                        <b>Issue Voucher No :</b>
                    </label>
                </td>
                <td height="50">
                    <asp:TextBox ID="txtissueVoucher" runat="server" CssClass="col-lg-4 form-control" Enabled="false" Style="top: 0px; left: 56px; width: 50px"></asp:TextBox>

                </td>
            </tr>


            <tr>
                <td height="50">
                    <label class="thicker" style="font-size: large">
                        <b>Date of Genration :</b>
                    </label>
                </td>
                <td height="50">

                    <asp:TextBox ID="txtdateofgenration" runat="server" CssClass="col-lg-4 form-control" Style="top: 0px; left: 56px; width: 50px"></asp:TextBox>
                </td>
            </tr>





        </table>
    </div>
    <br />
    <br />
    <div id="tableSecond" runat="server">
        <table style="width: 65%" align="center" class="customers">

            <tr>

                <td height="50">
                    <label class="thicker" style="font-size: large">
                        <b>Category :</b>
                    </label>

                    <asp:Label ID="lblcategory" runat="server" Style="top: 0px; left: 56px; width: 50px"></asp:Label>

                </td>

                <td height="50">
                    <label class="thicker" style="font-size: large">
                        <b>Through:</b>
                    </label>


                    <asp:TextBox ID="txtthrough" runat="server" CssClass="col-lg-4 form-control" Style="top: 0px; left: 357px; width: 50px"></asp:TextBox>

                </td>
                <td height="50">
                    <label class="thicker" style="font-size: large">
                        <b>Authority:</b>
                    </label>


                    <asp:Label ID="lblAuthority" runat="server" Style="top: 0px; left: 56px; width: 50px"></asp:Label>

                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="lblmessage" runat="server"></asp:Label>

    <br />
    <br />
    <div id="productgrid" runat="server">

        <asp:GridView ID="grdproductdata" runat="server" EmptyDataText="No data found !" CssClass="grdIssueOrderCss" BorderWidth="2" BorderColor="Black" HeaderStyle-Height="5px"
            AutoGenerateColumns="false" PagerSettings-Position="Bottom" HeaderStyle-CssClass="FixedHeader"
            PagerStyle-Font-Size="35px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="Large"
            Width="100%" OnRowDataBound="grdproductdata_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="S.No" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lblsno" CssClass="lblsno" runat="server" Text='<%#Container.DataItemIndex+1 %>' ItemStyle-HorizontalAlign="Center"> </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Product Name " ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lblPrdName" runat="server" Text='<%# Eval("product_name") %>' CssClass="lblPrdName">
                        </asp:Label>
                        <div class="hdclass">
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("productid")%>' />
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Packaging Material" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lblpm" runat="server" Text="Jar canes" CssClass="lblpm">
                        </asp:Label>

                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="A/U" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lblunit" runat="server" Text='<%# Eval("productUnit") %>' CssClass="lblunit">
                        </asp:Label>

                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Issue Quantity" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Label ID="lblissueqty" runat="server" Text='<%# Eval("issuequantity") %>' CssClass="lblissueqtyclass">
                        </asp:Label>

                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Add Vechile" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="burlywood" HeaderStyle-ForeColor="Black">
                    <ItemTemplate>
                        <asp:Button ID="btnvechile" runat="server" Text="Add Vechile" CssClass="btnaddvechile"></asp:Button>
                        <asp:LinkButton ID="lnvechiledetail" runat="server" Style="display: none" CssClass="lnkbtnaddvechile"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="12%" Height="50%" HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
            <HeaderStyle CssClass="stm_head" HorizontalAlign="Center" />
            <RowStyle CssClass="stm_dark" />
            <HeaderStyle CssClass="stm_head" />
        </asp:GridView>


    </div>

    <div id="divvechileadd" class="showpopup" style="text-align: center; display: none">
    </div>
    <div id="divvechileaddBatch" class="showpopupaddqty" style="text-align: center; display: none">
    </div>

    <br />
    <div id="bt" align="center">
        <%-- <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnsubmit_Click"  />--%>
        <asp:Button ID="btngeIssuvoucher" runat="server" Text="Genrate Issue Voucher" CssClass="btn btn-primary" />
    </div>
</asp:Content>
