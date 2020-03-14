<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/RHPD.Master" CodeBehind="addingIdtQuantity.aspx.cs" Inherits="Demo1.addingIdtQuantity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table, td, th {
            border: 3px solid black;
            background-color: seashell;
            padding: 12px;
        }

        p.thicker {
            font-weight: bold;
        }

        .button-success {
            background: rgb(28, 184, 65); /* this is a green */
            border-radius: 8px;
            text-shadow: 0 2px 2px rgba(0, 0, 0, 0.2);
        }
    </style>

 <%--<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.0/themes/base/jquery-ui.css" />
 <script src="http://code.jquery.com/jquery-1.8.3.js"></script>
 <script src="http://code.jquery.com/ui/1.10.0/jquery-ui.js"></script>--%>
    <script src="JSpath/jquery-1.8.3.min.js"></script>
    <script src="JSpath/jquery-ui.js"></script>
    <link href="JSpath/jquery-ui.css" rel="stylesheet" />
    <link rel="stylesheet" href="/resources/demos/style.css" />

    <script type="text/javascript">
        function SetName(crtQnty) {
            //var label = document.getElementById("<%=lblcurrentquantity.ClientID %>");
            document.getElementById("<%=hfName.ClientID %>").value = crtQnty;//label.innerHTML;
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            // Added by Rohit Pundeer
            $("#ctl00_ContentPlaceHolder1_btnsubmit").hide();

            var rdchecked = "";
            $("input[type='radio']").change(function () {
                if ($(this).val() == "rdAddition") {
                    rdchecked = "Add";
                }
                else {
                    rdchecked = "Sub";
                }
            });
            var addingQTY = 0;
            var currentQTY = 0;
            var sum = 0;
            var actualQTY = 0;
            actualQTY = parseInt($("#ctl00_ContentPlaceHolder1_lblactualquantity").text());
            /***** Added by Rohit Pundeer *****/
            $('.optypeChecked').change(function () {
                $("#ctl00_ContentPlaceHolder1_btnsubmit").hide();
                addingQTY = parseInt($("#ctl00_ContentPlaceHolder1_lblAddingquantity").val());
                //alert("actualQTY: " + actualQTY + "\n" + "addingQTY: " + addingQTY);   // Commented by RP
                if (rdchecked == "Add" || rdchecked == "") {
                    sum = parseInt(actualQTY) + parseInt(addingQTY);
                    crtQnty = "+" + parseInt(addingQTY);
                    $("#ctl00_ContentPlaceHolder1_btnsubmit").show();
                }
                else if (actualQTY >= 0 && actualQTY >= addingQTY) {
                    sum = parseInt(actualQTY) - parseInt(addingQTY);
                    crtQnty = "-" + parseInt(addingQTY);
                    $("#ctl00_ContentPlaceHolder1_btnsubmit").show();
                }
                else if (actualQTY == 0 || actualQTY < addingQTY) {
                    $("#ctl00_ContentPlaceHolder1_btnsubmit").hide();
                    crtQnty = parseInt(actualQTY);
                    addingQTY = 0;
                    $("#ctl00_ContentPlaceHolder1_lblAddingquantity").focus();
                    alert("Either you are subtracting from '0' or your desired subtraction quantity is greater than actual quantity!");
                    return false;
                }
                currentQTY = $("#ctl00_ContentPlaceHolder1_lblcurrentquantity").text(sum);
                SetName(crtQnty);
            });
            /**** Modified and Commentted by Rohit Pundeer ****/
            //$("#ctl00_ContentPlaceHolder1_lblAddingquantity").change(function () { 
            //    $("#ctl00_ContentPlaceHolder1_btnsubmit").hide();
            //    addingQTY = parseInt($("#ctl00_ContentPlaceHolder1_lblAddingquantity").val());
            //    //alert("actualQTY: " + actualQTY + "\n" + "addingQTY: " + addingQTY);   // Commented by RP
            //    if (rdchecked == "Add" || rdchecked == "") {
            //        sum = parseInt(actualQTY) + parseInt(addingQTY);
            //        crtQnty = "+" + parseInt(addingQTY);
            //        $("#ctl00_ContentPlaceHolder1_btnsubmit").show();
            //    }
            //    else if (actualQTY >= 0 && actualQTY >= addingQTY) {
            //        sum = parseInt(actualQTY) - parseInt(addingQTY);
            //        crtQnty = "-" + parseInt(addingQTY);
            //        $("#ctl00_ContentPlaceHolder1_btnsubmit").show();
            //    }
            //    else if (actualQTY == 0 || actualQTY < addingQTY) {
            //        $("#ctl00_ContentPlaceHolder1_btnsubmit").hide();
            //        crtQnty = parseInt(actualQTY);
            //        addingQTY = 0;                    
            //        $("#ctl00_ContentPlaceHolder1_lblAddingquantity").focus();
            //        alert("Either you are subtracting from '0' or your desired subtraction quantity is greater than actual quantity!");
            //        return false;
            //    }


            //    currentQTY = $("#ctl00_ContentPlaceHolder1_lblcurrentquantity").text(sum);
            //    SetName(crtQnty);

            //});
        })
    </script>
    <div class="heading-bg" align="center">
        <div class="container">
            <h1 style="background-color: skyblue; color: white">Adding IDT form</h1>
        </div>
    </div>
    <br />
    <br />
   <%-- <table class="table table-bordered">
        <thead>
            <tr>
                <td>
                    <label><b>Select Operation Type</b></label>
                </td>
                <td></td>
            </tr>
        </thead>
    </table>--%>

    <table style="width: 65%" align="center" class="customers">




        <tr>
            <td height="50">
                <label class="thicker" style="font-size: large">
                    <b>Product Name:</b>
                </label>
            </td>
            <td height="50">
                <asp:Label ID="prdname" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="50">
                <label class="thicker" style="font-size: large">
                    <b>Remaining quantity:</b>
                </label>
            </td>
            <td height="50">
                <asp:Label ID="lblactualquantity" runat="server"></asp:Label></td>

        </tr>
        <tr>
            <td height="50">
                <label class="thicker" style="font-size: large">
                    <b>Adding/Subtracting quantity:
        <asp:RadioButton ID="rdAddition" Text="Addition" runat="server" GroupName="optype" Checked="true" CssClass="optypeChecked" />
                        <asp:RadioButton ID="rdSubstraction" Text="Substraction" runat="server" GroupName="optype"  CssClass="optypeChecked" />
                    </b>
                </label>
            </td>
            <td height="50">
                <asp:TextBox ID="lblAddingquantity" runat="server" CssClass="col-lg-4 form-control optypeChecked" Style="top: 0px; left: 56px; width: 50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="***" ForeColor="Red" SetFocusOnError="true"
                    ControlToValidate="lblAddingquantity"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td height="50">

                <label class="thicker" style="font-size: large">
                    <b>Current quantity :</b>
                </label>
            </td>
            <td height="50">
                <asp:Label ID="lblcurrentquantity" runat="server"></asp:Label>
                <asp:HiddenField ID="hfName" runat="server" />
            </td>
        </tr>

        <tr>
            <td height="50">
                <label class="thicker" style="font-size: large">
                    <b>Reference letter number :</b>
                </label>
            </td>
            <td height="50">
                <asp:TextBox ID="txtRefrenceletter" runat="server" CssClass="col-lg-4 form-control" Style="top: 0px; left: 56px; width: 50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="***" ForeColor="Red" SetFocusOnError="true"
                    ControlToValidate="txtRefrenceletter"></asp:RequiredFieldValidator>
            </td>
        </tr>


        <tr>
            <td height="50">
                <label class="thicker" style="font-size: large">
                    <b>Reference letter date :</b>
                </label>
            </td>
            <td height="50">
                <telerik:RadDatePicker Culture="en-US" RenderMode="Lightweight" ID="txtrefrencedate" Width="100px" runat="server" DateInput-DateFormat="dd-MM-yyyy">
                </telerik:RadDatePicker>
                <%-- <asp:TextBox ID="" runat="server"  CssClass="col-lg-4 form-control" style="top: 0px;left: 56px; width:50px"   ></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtrefrencedate" runat="server"></asp:CalendarExtender>
                --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="***" ForeColor="Red" SetFocusOnError="true"
                    ControlToValidate="txtrefrencedate"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td height="50">

                <label class="thicker" style="font-size: large">
                    <b>Remarks :</b>
                </label>
            </td>

            <td height="50">
                <asp:TextBox ID="txtremarks" runat="server" CssClass="col-lg-4 form-control" Style="top: 0px; left: 56px; width: 50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="prprprr" ValidationGroup="grp" runat="server" ErrorMessage="*" Text="***" ForeColor="Red" SetFocusOnError="true"
                    ControlToValidate="txtremarks"></asp:RequiredFieldValidator>

            </td>
        </tr>





    </table>
    <br />
    <div align="center">
        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnsubmit_Click" ValidationGroup="grp" />
    </div>


</asp:Content>
