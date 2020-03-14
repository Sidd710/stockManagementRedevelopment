
$(document).ready(function () {
    var IssueQuantity = "";
    var remainingQuantity = "";
    var quantityIssued = "";
    var toatalQuantity_Issued = 0;
    var abc = 0;
    var kl = "";
    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    var Did = getParameterValues('Did');
    var prdId = getParameterValues('prdId');
    var qid = getParameterValues('qid');
    var TypeId = getParameterValues('TypeId');


    $("#ctl00_ContentPlaceHolder1_btn").click(function () {
      
        $('#ctl00_ContentPlaceHolder1_grdbachwithproductqty tr').each(function () {
            var BatchName = $(this).find('td:eq(1)').text();

            var issueqty = $(this).find('td .txtIssueQty').val();

            if (BatchName != "" && issueqty != "" && issueqty != 0) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "../stockoutpanel.asmx/insertdata",
                    data: "{'BatchName':'" + BatchName + "','issueqty':'" + issueqty + "','Did':'" + Did + "','prdId':'" + prdId + "','qid':'" + qid + "','TypeId':'" + TypeId + "'}",
                    dataType: "json",
                    success: function (data) {

                    },
                });
            }
        });
        window.location.href = "frmMonitoringStock.aspx";//write main page url Name
        return false;
    });

    $("#ctl00_ContentPlaceHolder1_txtIssuequantity").change(function () {
     
       
        var stockQty = $('#ctl00_ContentPlaceHolder1_lblstockbalnace').text();
        IssueQuantity = $('#ctl00_ContentPlaceHolder1_txtIssuequantity').val();

        var remainingIDTquantity = $('#ctl00_ContentPlaceHolder1_lblRemainingIDTQTY').text();
      
        $("#ctl00_ContentPlaceHolder1_lblremainingIDT").text(IssueQuantity);
       
        if(parseInt(IssueQuantity)>parseInt(stockQty))
        {
            alert("Issue Quantity is greater than Stock Quantity !!!!")
            $('#ctl00_ContentPlaceHolder1_txtIssuequantity').val('');
            $("#ctl00_ContentPlaceHolder1_lblremainingIDT").text('');
            return false;
        }
       
        else if (parseInt(IssueQuantity) > parseInt(remainingIDTquantity)) {
            
            alert("Issue Quantity is greater than Total remaining IDT !!!!")
            $('#ctl00_ContentPlaceHolder1_txtIssuequantity').val('');
            $("#ctl00_ContentPlaceHolder1_lblremainingIDT").text('');
            return false;
        }
        else {
            $('#divRemaining').css("display", "block");
        }

    });

    $('#ctl00_ContentPlaceHolder1_grdbachwithproductqty_ctl02_txtIssueQty').change(function () {

        var i = 0;
        i = $(this).val();
        var otherInput = $(this).closest('tr').find('.lbltotalQty').text();

        if (parseInt(i) > parseInt(otherInput)) {

            alert("Issue quantity should not be greater that Total quantity of batch !!!!!!")
            $(this).val('');
            return false;
        }


        if (IssueQuantity == "") {
            alert("Please Enter Issue Quantity Above !!!!!!")
            $(this).val('');
            return false;
        }

        var sum = 0;
        $(".txtIssueQty").each(function () {
            if (this.value == "")
            {
                this.value = 0;
            }

            if (!isNaN(this.value) && this.value.length != 0) {
                sum += parseFloat(this.value);
                if (parseInt(sum) > parseInt(IssueQuantity)) {

                    alert("Sum of Issuing Quantity is greater that Issue Quantity !!!!")
                    $(this).val('');
                    return false;

                }
                remainingQuantity = parseInt(IssueQuantity) - parseInt(sum);

                $("#ctl00_ContentPlaceHolder1_lblremainingIDT").text(remainingQuantity);
                if (remainingQuantity == "0") {
                    $('#ctl00_ContentPlaceHolder1_btn').css("display", "block");
                }
                else
                {
                    $('#ctl00_ContentPlaceHolder1_btn').css("display", "none");
                }

            }

        });

    });

    $("#ctl00_ContentPlaceHolder1_ddlBatch").change(function () {
        var btchprdqnty = "";
        var BatchcodeNumber = "";
        var BatchNo = $("#ctl00_ContentPlaceHolder1_ddlBatch option:selected").val();
        var BatchNoText = $("#ctl00_ContentPlaceHolder1_ddlBatch option:selected").text();

        if (BatchNoText == "--Select Batch--") {
            alert("Please select a correct batch !!!!");
            return false;
        }
       // clientId.val($.trim(clientId.val()));
        //var Batchtrim=$.tr
        
        //$.ajax({
        //    type: "POST",
        //    url: "issueIdtQuantity.aspx/BindBatchproductDetail",
        //    data: "{'BatchNo':'" + BatchNo + "'}",
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    success: function (data) {

        //        if (data.d.length > 0) {
                    
        //            kl = data.d[0].BatchName;

        //        }

        //    },



        //});


        //$('#ctl00_ContentPlaceHolder1_grdbachwithproductqty tr').each(function () {
        //   debugger;
        //   var Batchcode = $(this).find('td:eq(1)').text().trim();
        //    //var tu = Batchcode.slice("", "");
        //    alert(Batchcode);
        //    if (Batchcode != "")
        //    {
        //        if(kl==Batchcode)
        //        {

        //            alert("Batch already exsit!!!!!");
        //            return false;
        //        }
        //}
            
        //});

        //return false;
        $.ajax({
            type: "POST",
            url: "issueIdtQuantity.aspx/BindBatchproductDetail",
            data: "{'BatchNo':'" + BatchNo + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                if (data.d.length > 0) {
                    btchprdqnty = data.d[0].batchTotalQuantity;
                    BatchcodeNumber = data.d[0].BatchName;
                 
                    var tr = $('#ctl00_ContentPlaceHolder1_grdbachwithproductqty tr:last');
                    var firstcolumnval = $(tr).find("td").html()
                    var p = $(tr).find("td").find('span.lbltotalQty').html(btchprdqnty)
                    var q = $(tr).find("td").find('span.lblBatchNo').html(BatchcodeNumber)

                    var totalRows = ""; 
                    var totalRows1 = $("#ctl00_ContentPlaceHolder1_grdbachwithproductqty tr").length;

                    var h = parseInt(totalRows1) - 2

                    totalRows = parseInt(h) + 1;
                    var p1 = $(tr).find("td").find('span.lblsno').html(h)

                }

            },

        });

        $("[id*=ctl00_ContentPlaceHolder1_grdbachwithproductqty] tr:gt(1)").hide();
        var row = $("[id*=ctl00_ContentPlaceHolder1_grdbachwithproductqty] tr:eq(1)").clone(true);

        $("[id$=ctl00_ContentPlaceHolder1_grdbachwithproductqty]").append(row);
        $(row).find(".lblsno").text('');
        $(row).find(".lblBatchNo").text(); 
        $(row).find(".lbltotalQty").text();
        $(row).find(".txtIssueQty").val();


        $("[id*=ctl00_ContentPlaceHolder1_grdbachwithproductqty] tr").show();
        $("[id*=ctl00_ContentPlaceHolder1_grdbachwithproductqty] tr:eq(1)").hide();

        $("#ctl00_ContentPlaceHolder1_grdbachwithproductqty").css("display", "block");

    });
    return false;

});

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

