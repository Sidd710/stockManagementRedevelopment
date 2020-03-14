<%@ Page Language="C#" MasterPageFile="~/RHPD.Master" AutoEventWireup="true" CodeBehind="MonitoringToolSunny.aspx.cs" Inherits="RHPDNew.StockOutPanel.MonitoringToolSunny" %>
<%@ Register Src="~/StockOutPanel/rhpd.ascx" TagName="rhpdusercontro" TagPrefix="my" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/bootstrap.js"></script>
    <script src="js/jquery.min.js"></script>
    <script src="js/jquery-1.10.2.js"></script>
    <script src="js/jquery-1.7.1.intellisense.js"></script>
    <script src="js/issueIDT.js"></script>
     
    <div class="container-fluid">
         <asp:UpdatePanel ID="upd1" runat="server">
         <ContentTemplate>
           <div id="divusercontrol" runat="server">
          <my:rhpdusercontro runat="server" ID="MyUserInfoBoxControl" />
    </div>
             </ContentTemplate>
    </asp:UpdatePanel>
        <br />
        <br />
        <br />
       
        <div class="container">
            <div class="">
                <table width="100%" runat="server" id="Table1" class="idtTable">
                    <tr>
                        <td colspan="4">
                            <asp:RadioButtonList ID="rdoBtnLstQuarters" Width="100%" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="4" OnSelectedIndexChanged="rdoBtnLstQuarters_SelectedIndexChanged" AutoPostBack="true" runat="server">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">Select Product : 
                                <asp:DropDownList ID="ddlProduct" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" Width="200px" runat="server">
                                </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="rowlnkBtnAutoAdd" runat="server">
                        <td colspan="4">
                            <asp:LinkButton ID="lnkBtnAutoAdd" OnClick="lnkBtnAutoAdd_Click" Text="Click here to auto add previous quarter data in to this Quarter." runat="server"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
            <style>
            body{background:url(../assets/images/armymanwithgun.jpg) no-repeat;background-size:cover;}
        </style>
            <div id="monitoringtoolGrid" runat="server" class="idtTable">
                <div style="margin: 10px 0;">
                    <table runat="server" id="tblSuper" border="0">
                        <tr id="trlblMsg" runat="server">
                            <td colspan="2" style="text-align: center">
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id="tdMainData" runat="server" style="vertical-align: top;">
                                <table runat="server" id="tblMain" border="1" class="style1">
                                </table>
                            </td>
                            <td id="tdNewDepotSection" runat="server" style="vertical-align: top;">
                                <table runat="server" id="tblAddNew" border="1" class="style1">
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="dDepotNew" OnSelectedIndexChanged="dDepotNew_SelectedIndexChanged" AutoPostBack="true" Width="200px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function UpdateDepotForProduct(ddDepot) {
            if (String(ddDepot.value) == "0" || String(ddDepot.value) == "") {
                return false;
            }
            else {
                var QuarterId = $('#<%=rdoBtnLstQuarters.ClientID %> input:checked').val();
                var UserId = $(ddDepot).attr('UserId');
                var DepotId = ddDepot.value;
                $.ajax(
                {
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "../stockoutpanel.asmx/StockOutMain_Depot_Update",
                    data: "{'QuarterId':'" + QuarterId + "','DepotId':'" + DepotId + "','UserId':'" + UserId + "'}",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 1) {
                            window.location = "../StockOutPanel/frmMonitoringStock.aspx";
                        }
                        else {
                            window.location = "../StockOutPanel/frmMonitoringStock.aspx";
                        }
                    }
                });
                return false;
            }
        }
        $('.clsbtnOrderIDT').click(function () {
            var ddlvalue = document.getElementById('<%=MyUserInfoBoxControl.FindControl("ddlordertype").ClientID %>');
            var TypeId = ddlvalue.value;

            var DepotId = $(this).attr('DepotId');
            var QuarterId = $('#<%=rdoBtnLstQuarters.ClientID %> input:checked').val();

            if (QuarterId == undefined) {
                QuarterId = 0;
            }
            window.location = "../StockOutPanel/issueOrder.aspx?Did=" + DepotId + "&Qid=" + QuarterId + "&TypeId=" + TypeId;
            return false;
        });

        $('.clsbtnIssueIDTUpdate').click(function () {
            var ddlvalue = document.getElementById('<%=MyUserInfoBoxControl.FindControl("ddlordertype").ClientID %>');
            var TypeId = ddlvalue.value;
            var ProductId = $(this).attr('ProductId');
            var DepotId = $(this).attr('DepotId');
            var QuarterId = $('#<%=rdoBtnLstQuarters.ClientID %> input:checked').val();
            if (QuarterId == undefined) {
                QuarterId = 0;
            }
            window.location = "../StockOutPanel/issueIdtQuantity.aspx?prdId=" + ProductId + "&Did=" + DepotId + "&qid=" + QuarterId + "&TypeId=" + TypeId;
            return false;
        });

        $('.clsBtnAddMore').click(function () {
            var ddlvalue = document.getElementById('<%=MyUserInfoBoxControl.FindControl("ddlordertype").ClientID %>');
            var TypeId = ddlvalue.value;
            var ProductId = $(this).attr('ProductId');
            var DepotId = $(this).attr('DepotId');
            var QuarterId = $('#<%=rdoBtnLstQuarters.ClientID %> input:checked').val();
            if (QuarterId == undefined) {
                QuarterId = 0;
            }
            window.location = "../StockOutPanel/addingIdtQuantity.aspx?prdId=" + ProductId + "&Did=" + DepotId + "&qid=" + QuarterId + "&TypeId=" + TypeId;
            return false;
        });


        $('.clsbtnIssueIDTNew').click(function () {
            var QuarterId = $('#<%=rdoBtnLstQuarters.ClientID %> input:checked').val();

            //var QuarterId = $(this).attr('QuarterId');
            var ProductId = $(this).attr('ProductId');
            var DepotId = $(this).attr('DepotId');
            var UserId = $(this).attr('UserId');
            var IDT = $("#ctl00_ContentPlaceHolder1_txtIssueIDTNew_" + ProductId + "_" + DepotId).val();
            var IDTUpdate = $(this).attr('IDTUpdate');
            $.ajax(
            {
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../stockoutpanel.asmx/StockOutMain_AddUpdateIDT",
                data: "{'QuarterId':'" + QuarterId + "','ProductId':'" + ProductId + "','DepotId':'" + DepotId + "','UserId':'" + UserId + "','IDT':'" + IDT + "','IDTUpdate':'" + IDTUpdate + "'}",
                dataType: "json",
                success: function (data) {
                    if (data.d == 1) {
                        window.location = "../StockOutPanel/frmMonitoringStock.aspx";
                    }
                    else {
                        window.location = "../StockOutPanel/frmMonitoringStock.aspx";
                    }
                }
            });
            return false;
        });

        $('.clsbtnIssueStatus').click(function () {
            var QuarterId = $('#<%=rdoBtnLstQuarters.ClientID %> input:checked').val();
            var ProductId = $(this).attr('ProductId');
            var DepotId = $(this).attr('DepotId');
            var UserId = $(this).attr('UserId');
            var IDT = $("#ctl00_ContentPlaceHolder1_txtIssueIDTNew_" + ProductId + "_" + DepotId).val();
            var IDTUpdate = $(this).attr('IDTUpdate');
            $.ajax(
            {
                type: "POST",
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "../stockoutpanel.asmx/StockOutMain_GetIssueIdtQtybyProduct",
                data: "{'QuarterId':'" + QuarterId + "','ProductId':'" + ProductId + "','DepotId':'" + DepotId + "'}",
                dataType: "json",
                success: function (data) {
                    if (data.d.length == 1) {
                        var IssueOrderNo = data.d[0].IssueOrderNo;
                        var issuequantity = data.d[0].issuequantity;
                        var table = '<table>';
                        var row = '<tr>';
                        row += '<td>Issue Order No : "' + IssueOrderNo + '"</td>';
                        row += '<td>Issue Quantity : "' + issuequantity + '"</td>';
                        row += '</tr><br/>';
                        table += row;
                        table += '</table>';
                    }
                }, error: function (result) {
                    alert("Error");
                    return false;
                }
            });
            return false;
        });
    </script>
</asp:Content>
