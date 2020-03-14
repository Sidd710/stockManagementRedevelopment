$(document).ready(function () {

    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    var depotid = getParameterValues('Did');
    var quarterid = getParameterValues('Qid');


    function getParameterValues(key) {
        var pageURL = window.location.search.substring(1);
        var urlQS = pageURL.split('&');
        for (var i = 0; i < urlQS.length; i++) {
            var paramName = urlQS[i].split('=');
            if (paramName[0] == key) {
                var value = paramName[1].replace('%20', ' ').replace('%26', '&').replace('+', ' ');
                return value;
            }
        }
    }

    $("#ctl00_ContentPlaceHolder1_btnsubmit").click(function () {
        var QuarterIdIs = quarterid;
       
        var IssueOrderNo = $('#ctl00_ContentPlaceHolder1_txtissueordno').val();
        var issueorder_date = $('#ctl00_ContentPlaceHolder1_txtdateofgenration').val();
        var Authority = $('#ctl00_ContentPlaceHolder1_txtAuthority').val();

        if (IssueOrderNo == "")
        {
            alert("Please enter issueorder Number !!!")
            return false;
        }
        if (issueorder_date == "") {
            alert("Please enter issueorder date  !!!")
            return false;
        }
        if (Authority == "") {
            alert("Please enter Authority Number !!!")
            return false;
        }

        $('#ctl00_ContentPlaceHolder1_grdIssueOrder tr').each(function () {
            var ProductName = $(this).find('td:eq(1)').text();
           
            var productID = $(this).find('td .hdclass input[type=hidden]').val();
            var issuequantity = $(this).find('td .lblissueqty').text();
            var DepotProductQuarterQty = depotid + "_" + productID + "_" + quarterid + "_" + issuequantity;
            

           // setTimeout(function () {
            if (ProductName != "" ) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "../stockoutpanel.asmx/insertIssueOrderNew",
                    data: "{'IssueOrderNo':'" + IssueOrderNo + "','issueorder_date':'" + issueorder_date + "','Authority':'" + Authority + "','DepotProductQuarterQty':'" + DepotProductQuarterQty + "' }",
                    //url: "../stockoutpanel.asmx/insertIssueOrder",
                    //data: "{'IssueOrderNo':'" + IssueOrderNo + "','issueorder_date':'" + issueorder_date + "','Authority':'" + Authority + "','depotid':'" + depotid + "','quarterid':'" + quarterid + "','productID':'" + productID + "','issuequantity':'" + issuequantity + "'}",
                    dataType: "json",
                    success: function (data) {
                        //alert("Helo");
                    },
                });
            }
        });
       // debugger;
       
        //("issuevoucherlist.aspx");//write main page url Name
       // }, 1000);
        //return false;
        window.location.href = "IssueOrderlist.aspx";//write main page url Name
        return false;
    });
    $("#ctl00_ContentPlaceHolder1_txtissueordno").change(function () {
        debugger;
        var issueorderno = $("#ctl00_ContentPlaceHolder1_txtissueordno").val();
        if (issueorderno == "")
        {
            alert("Please Enter Issue Order Number ");
            return false;
        }
        if (issueorderno != "") {
            $.ajax(
                           {
                               type: "POST",
                               contentType: "application/json; charset=utf-8",
                               url: "../stockoutpanel.asmx/checkissueorderNo",
                               data: "{'issueorderno':'" + issueorderno + "'}",
                               dataType: "json",
                               success: function (data) {

                                   if (parseInt(data.d) == parseInt(1)) {
                                       alert("Issue Order Number already Exsit , please enter another issue order Number");
                                       $("#ctl00_ContentPlaceHolder1_txtissueordno").val('');
                                       return false;
                                   }
                               },
                               error: function (result) {
                                   alert("Error");
                               }
                           });
        }
    });
    

});