$(document).ready(function () {

    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');

    var Cat_Id = getParameterValues('Category_Id');
    var issueorderID = getParameterValues('IssueOrderId');

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







    var IssueQuantity = "";
    var remainingQuantity = "";
    var ProductId = "";
    var ActualIssueQuantity = "";
    var ActualBatchquantity = "";
    var batchno = "";
    var Authority = $('#ctl00_ContentPlaceHolder1_lblAuthority').text();


    $('.btnaddvechile').click(function () {
        ProductId = $(this).closest('tr').find('.hdclass input[type=hidden]').val();
        ActualIssueQuantity = $(this).closest('tr').find('.lblissueqtyclass').text();
        $("#divvechileadd").show(500);
        $("#grdvechile").fadeIn();




        $.ajax({
            type: "POST",
            url: "IssueVoucher.aspx/GetBatchDetail",
            data: "{'ProductId':'" + ProductId + "','issueorderID':'" + issueorderID + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {



                var table = '<table id="grdvechile" class="stm" width="100%><thead class="stm_head"> <tr> <th> Batch No</th> <th> Issued quantity  </th><th>Add Vechile</th></thead></tr>';

                for (var i = 0; i < data.d.length; i++) {
                    var row = '<tr">';
                    row += '<td ><input type="text" class="batchclass" value="' + data.d[i].BatchName + '"></td>';
                    row += '<td ><input type="text" class="Issuuquantity" value="' + data.d[i].issueqty + '"></td>';
                    row += '<td ><input type="button" class="addvechilebatch" value="Add Vechile"></td>';

                    row += '</tr><br/>';

                    table += row;
                }

                table += '</table>';

                $('#divvechileadd').html(table);

                $('#divvechileadd').append('<div style="margin-left:-1527px;margin-top:19px;"><input type="submit" value="Close" class="closebutton"></div> ');

            }
        });


        return false;
    });



    $('.addvechilebatch').live('click', function () {
        ActualBatchquantity = $(this).closest('tr').find('.Issuuquantity').val();
        batchno = $(this).closest('tr').find('.batchclass').val();

        $("#divvechileaddBatch").show(500);
        $("#grdvechilebatch").fadeIn();


        $.ajax({
            type: "POST",
            url: "IssueVoucher.aspx/getVechiledetail",
            data: "{'ProductId':'" + ProductId + "','issueorderID':'" + issueorderID + "','batchno':'" + batchno + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                if (data.d.length > 0) {
                    var table = '<table id="grdvechilebatch" class="stm" width="100%><thead class="stm_head"> <tr> <th> Vehicle No</th><th> Stock quantity   </th> </thead></tr>';

                    for (var i = 0; i < data.d.length; i++) {
                        var row = '<tr">';

                        row += '<td ><span  class="vechileClass">' + data.d[i].VehicleNo + '</span></td>';
                        row += '<td ><span  class="stockclass">' + data.d[i].StockQuantity + '</span></td>';

                        row += '</tr><br/>';

                        table += row;
                    }

                    table += '</table>';

                    $('#divvechileaddBatch').html(table);
                    $('#divvechileaddBatch').append('<div style="margin-left:728px;margin-top:-150px;"><input type="submit" value="Close" class="closebuttonbatch"></div> ');
                    $('#divvechileaddBatch').css("display", "block");
                    return false;



                }
                else {
                    var table = '<table id="grdvechilebatch" class="stm" width="100%><thead class="stm_head"> <tr> <th> Vehicle No</th><th> Stock quantity   </th> </thead></tr>';

                    for (var i = 0; i < 1; i++) {
                        var row = '<tr">';

                        row += '<td ><input type="text" class="vechileClass"></td>';
                        row += '<td ><input type="text" class="stockclass"></td>';

                        row += '</tr><br/>';

                        table += row;
                    }

                    table += '</table>';

                    $('#divvechileaddBatch').html(table);


                    $(function () {
                        $('.vechileClass').autocomplete({
                            source: function (request, response) {
                                $.ajax({
                                    url: "IssueVoucher.aspx/GetVechileAutocompete",
                                    data: "{ 'mail': '" + request.term + "' }",
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    dataFilter: function (data) { return data; },
                                    success: function (data) {
                                        response($.map(data.d, function (item) {
                                            return {
                                                value: item.VechileNumber
                                            }
                                        }))
                                    },
                                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                                        alert("Error");
                                    }
                                });
                            },
                            minLength: 2
                        });
                    });



                    $('#divvechileaddBatch').append('<div style="margin-left:-637px;margin-top:14px;"><input type="submit" value="Add Vechile" class="btnvechilecss"></div> ');
                    $('#divvechileaddBatch').append('<div style="margin-left:-473px;margin-top:-26px;"><input type="submit" value="Close" class="closebuttonbatch"></div> ');
                    $('#divvechileaddBatch').append('<div style="margin-top:-26px;display:block" class="divbuttonsubmit"><input type="submit" value="Submit" class="submitButton"></div>');
                    $('#divvechileaddBatch').css("display", "block");
                    $('#divvechileaddBatch').append('<div id="divRemainingIDT" style="padding:30px;margin-right: 1500px;"><table><tr><td><label style="color:green"><b>Remaining  Quantity:</b></label><span ID="lblRemainingquantity" style="font:bold;font-size: large"></span> </td> </tr></table></div>');
                    $('.divbuttonsubmit').css("display", "block");
                    return false;
                }

            }
        });






    });



    $('.closebutton').live('click', function () {

        $("#divvechileadd").hide(500);
        $("#grdvechile").fadeOut();
        window.location.href = "IssueVoucher.aspx?Category_Id=" + Cat_Id + "&IssueOrderId=" + issueorderID + ""; ///please give URL to redirect
        return false;
    });
    $('.closebuttonbatch').live('click', function () {

        $("#divvechileaddBatch").hide(500);
        $("#grdvechilebatch").fadeOut();

        return false;
    });
    $('.btnvechilecss').live('click', function () {






        var checkfields = true;

        var ac = $('#lblRemainingquantity').text();
        if (ac == 0 && ac != "") {
            alert("Remianing quantity is Zero !!!!!");
            checkfields = false
            return false;
        }
        $('#grdvechilebatch tr:not(:first-child)').each(function () {

            var EnteredVehicleName = $(this).find('td .vechileClass').val();
            // var Enteredpm = $(this).find('td .pmclass').val();
            var EnteredStock = $(this).find('td .stockclass').val();

            if (EnteredVehicleName == "") {
                alert("Vechile Name can't be blank!!!!")
                checkfields = false
                return false;
            }
                //else if (Enteredpm == "") {
                //    alert("Pm Quantity can't be blank!!!!")
                //    checkfields = false
                //    return false;
                //}
            else if (EnteredStock == "") {
                alert("Stock Quantity can't be blank!!!!")
                checkfields = false
                return false;
            }

        });

        if (checkfields == true) {
            $('#grdvechilebatch').append('<tr><td><input type="text" class="vechileClass"></td><td><input type="text" class="stockclass"></td></tr>');

            $(function () {
                $('.vechileClass').autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "IssueVoucher.aspx/GetVechileAutocompete",
                            data: "{ 'mail': '" + request.term + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.VechileNumber
                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert("Error");
                            }
                        });
                    },
                    minLength: 2
                });
            });
            return false;
        }
        return false;

    });

    $('.stockclass').live('change', function () {

        var issueQuantityvalue = 0;
        issueQuantityvalue = $(this).val();

        if (parseInt(issueQuantityvalue) > parseInt(ActualBatchquantity)) {
            alert("Quantity Should not be greater than Issue Quantity!!!!");
            $(this).val('');
            return false;

        }

        var sum = 0;
        $(".stockclass").each(function () {
            if (this.value == "") {
                this.value = 0;
            }

            if (!isNaN(this.value) && this.value.length != 0) {
                sum += parseFloat(this.value);
                if (parseInt(sum) > parseInt(ActualBatchquantity)) {

                    alert("Sum of Issuing Quantity is greater that Issue Quantity !!!!")
                    $(this).val('');
                    return false;

                }
                remainingQuantity = parseInt(ActualBatchquantity) - parseInt(sum);

                $("#lblRemainingquantity").text(remainingQuantity);
                if (remainingQuantity == "0") {
                    $('.divbuttonsubmit').css("display", "block");
                }
                else {
                    $('.divbuttonsubmit').css("display", "none");
                }

            }

        });
    });


    $('.submitButton').live('click', function () {

        var IssueVoucherId = $('#ctl00_ContentPlaceHolder1_txtissueVoucher').val();
        var dateofgenration = $('#ctl00_ContentPlaceHolder1_txtdateofgenration').val();
        var Through = $('#ctl00_ContentPlaceHolder1_txtthrough').val();

        if (IssueVoucherId == "") {
            alert("Please enter Issue Voucher Number !!!")
            return false;
        }
        if (dateofgenration == "") {
            alert("Please enter Date of genration!!!")
            return false;
        }
        if (Through == "") {
            alert("Please enter Through !!!")
            return false;
        }

        $('#grdvechilebatch tr').each(function () {
            var VehicleNo = $(this).find('td .vechileClass').val();
            var PMQuantity = 10;
            var StockQuantity = $(this).find('td .stockclass').val();
            if (VehicleNo != "" && PMQuantity != "" && StockQuantity != 0 && StockQuantity != "" && VehicleNo != undefined && PMQuantity != undefined && StockQuantity != undefined && batchno != undefined && batchno != "") {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "../stockoutpanel.asmx/insertIssueVoucher",
                    data: "{'VehicleNo':'" + VehicleNo + "','PMQuantity':'" + PMQuantity + "','StockQuantity':'" + StockQuantity + "','IssueVoucherId':'" + IssueVoucherId + "','dateofgenration':'" + dateofgenration + "','Through':'" + Through + "','ProductId':'" + ProductId + "','Authority':'" + Authority + "','Cat_Id':'" + Cat_Id + "','issueorderID':'" + issueorderID + "','batchno':'" + batchno + "'}",
                    dataType: "json",
                    success: function (data) {
                    },
                });
            }
        });
        $('#divvechileaddBatch').css("display", "none");
        alert("Vechile detail added to '" + batchno + "'");
        return false;
    });




    $('.vechileClass ui-autocomplete-input').live('change', function () {
        var VehicleName = $(this).val();

        if (VehicleName != undefined) {

            $('#grdvechilebatch tr:not(:last-child)').each(function () {

                var EnteredVehicleName = $(this).find('td .vechileClass').val();

                if (EnteredVehicleName == VehicleName) {
                    alert("Vechile Name already Exsit!!!!")
                    //$(this).find('td .vechileClass').val('');
                    return false;
                }
            });
        }
        // alert("s");

    });




    $('.lnkbtnaddvechile').click(function () {
        ProductId = $(this).closest('tr').find('.hdclass input[type=hidden]').val();
        ActualIssueQuantity = $(this).closest('tr').find('.lblissueqtyclass').text();
        $("#divvechileadd").show(500);
        $("#grdvechile").fadeIn();




        $.ajax({
            type: "POST",
            url: "IssueVoucher.aspx/GetBatchDetail",
            data: "{'ProductId':'" + ProductId + "','issueorderID':'" + issueorderID + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {



                var table = '<table id="grdvechile" class="stm" width="100%><thead class="stm_head"> <tr> <th> Batch No</th> <th> Issued quantity  </th><th>Add Vechile</th></thead></tr>';

                for (var i = 0; i < data.d.length; i++) {
                    var row = '<tr">';
                    row += '<td ><input type="text" class="batchclass" value="' + data.d[i].BatchName + '"></td>';
                    row += '<td ><input type="text" class="Issuuquantity" value="' + data.d[i].issueqty + '"></td>';
                    row += '<td ><input type="button" class="addvechilebatch" value="Add Vechile"></td>';

                    row += '</tr><br/>';

                    table += row;
                }

                table += '</table>';

                $('#divvechileadd').html(table);

                $('#divvechileadd').append('<div style="margin-left:-1527px;margin-top:19px;"><input type="submit" value="Close" class="closebutton"></div> ');

            }
        });


        return false;
    });



});