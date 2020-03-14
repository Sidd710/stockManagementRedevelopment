$(document).ready(function () {
    var rdchecked = "";
    $("input[type='radio']").change(function () {
        if ($(this).val() == "rdDD") {
            rdchecked = "DD";
        }
        else {
            rdchecked = "CHT";
        }
    });
 
    $('#ctl00_ContentPlaceHolder1_btnaddvechile').click(function () {
        $("#divvechileaddmaster").show(500);
        $("#grdvechile").fadeIn();

        var table = '<table id="grdvechile" class="stm" width="100%><thead class="stm_head"> <tr> <th style="background-color:skyblue;font:600;font-family:cursive;"> Vehicle No</th> <th style="background-color:skyblue;font:600;font-family:cursive;"> Driver Name </th> <th style="background-color:skyblue;font:600;font-family:cursive;"> Rank  </th> <th style="background-color:skyblue;font:600;font-family:cursive;"> Army Number  </th></thead></tr>';

        for (var i = 0; i < 1; i++) {
            var row = '<tr">';

            row += '<td ><input type="text" class="vechileClass"></td>';
            row += '<td ><input type="text" class="driverclass"></td>';
            row += '<td ><input type="text" class="rankclass"></td>';
            if (rdchecked == "DD")
            {
                row += '<td><input type="text" class="ArmyNo" disabled></td>';
            }
            else
            {
                row += '<td><input type="text" class="ArmyNo"></td>';
            }

           

            row += '</tr><br/>';

            table += row;
        }

        table += '</table>';

        $('#divvechileaddmaster').html(table);
        $('#divvechileaddmaster').append('<div style="margin-left:-1200px;margin-top:14px;"><input type="submit" value="Add Vechile" class="btnvechilecss"></div> ');
        $('#divvechileaddmaster').append('<div style="margin-left:-1021px;margin-top:-26px;"><input type="submit" value="Close" class="closebutton"></div> ');
        $('#divvechileaddmaster').append('<div style="margin-top:-26px;display:block" class="divbuttonsubmit"><input type="submit" value="Submit" class="submitButton"></div>');
        $('.divbuttonsubmit').css("display", "block");
        return false;
    });

    $('.closebutton').live('click', function () {

        $("#divvechileaddmaster").hide(500);
        $("#grdvechile").fadeOut();

        return false;
    });

    $('.btnvechilecss').live('click', function () {
        //var checkfields = true;

        //var ac = $('#lblRemainingquantity').text();
        //if (ac == 0 && ac != "") {
        //    alert("Remianing quantity is Zero !!!!!");
        //    checkfields = false
        //    return false;
        //}
        //$('#grdvechile tr:not(:first-child)').each(function () {

        //    var EnteredVehicleName = $(this).find('td .vechileClass').val();
        //    var Enteredpm = $(this).find('td .pmclass').val();
        //    var EnteredStock = $(this).find('td .stockclass').val();

        //    if (EnteredVehicleName == "") {
        //        alert("Vechile Name can't be blank!!!!")
        //        checkfields = false
        //        return false;
        //    }
        //    else if (Enteredpm == "") {
        //        alert("Pm Quantity can't be blank!!!!")
        //        checkfields = false
        //        return false;
        //    }
        //    else if (EnteredStock == "") {
        //        alert("Stock Quantity can't be blank!!!!")
        //        checkfields = false
        //        return false;
        //    }

        //});

        //if (checkfields == true) {

        if (rdchecked == "DD") {
            $('#grdvechile').append('<tr><td><input type="text" class="vechileClass"></td><td><input type="text" class="driverclass"></td><td><input type="text" class="rankclass"></td><td><input type="text" class="ArmyNo" disabled></td></tr>');
        }
        else
        {
            $('#grdvechile').append('<tr><td><input type="text" class="vechileClass"></td><td><input type="text" class="driverclass"></td><td><input type="text" class="rankclass"></td><td><input type="text" class="ArmyNo"></td></tr>');

        }


      
        //    return false;
        //}
        return false;

    });

    $('.submitButton').live('click', function () {

        var Through = $('#ctl00_ContentPlaceHolder1_txtthrough').val();
     

        if (Through == "") {
            alert("Please enter Through !!!")
            return false;
        }
      

        $('#grdvechile tr').each(function () {
            var vechileType = "";
            var VechileNumber = $(this).find('td .vechileClass').val();
            var DriverName = $(this).find('td .driverclass').val();
            var Rank = $(this).find('td .rankclass').val();
            var ArmyNo = $(this).find('td .ArmyNo').val();
            if (rdchecked == "DD") {
                ArmyNo = "";
                vechileType = "DD";
               
            }
            else
            {
                vechileType = "CHT";
            }
          
            if (VechileNumber != "" && DriverName != "" && Rank != 0 && Rank != "" && VechileNumber != undefined && DriverName != undefined && Rank != undefined && ArmyNo != undefined && vechileType != undefined && vechileType != "") {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "../stockoutpanel.asmx/InsertVechileMaster",
                    data: "{'VechileNumber':'" + VechileNumber + "','DriverName':'" + DriverName + "','Rank':'" + Rank + "','Through':'" + Through + "','ArmyNo':'" + ArmyNo + "','vechileType':'" + vechileType + "'}",
                    dataType: "json",
                    success: function (data) {
                    },
                });
            }
        });
        window.location.href = "vechilemaster.aspx";
        return false;
    });
    

});