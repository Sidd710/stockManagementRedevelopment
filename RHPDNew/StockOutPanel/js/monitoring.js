$(document).ready(function () {
    
    $("#ctl00_ContentPlaceHolder1_tblMain__ctl01_ddlCountry").change(function () {
        
        var val = $('#ctl00_ContentPlaceHolder1_tblMain__ctl01_ddlCountry option:selected').text();
     
        if (val == "---Select Dipu----") {

            alert("Please select correct Dipu !!!!!")
            return false;
        }

        $('#ctl00_ContentPlaceHolder1_tblMain_ tr').append('<td ><input type=text style=align="center"><input id="name" type="hidden" value="' + val + '" name="name"></br></br><input type=button id="btnId"  value="' + 'Add IDT' + '" cssclass=test><span id="IDTqty" cssclass="qty" style="display:none"></td>');
        $('#ctl00_ContentPlaceHolder1_tblMain_ tr:first-child td:last-child').append(val)
        $('#ctl00_ContentPlaceHolder1_tblMain_ tr:first-child td:last-child').css("background-color", "Skyblue");
       
        $('#ctl00_ContentPlaceHolder1_tblMain_ tr:first-child td:last-child input[type="button"]').css("display", "none");
        $('#ctl00_ContentPlaceHolder1_tblMain_ tr:first-child td:last-child input[type="text"]').css("display", "none");

        
      
    });

    $(document).on('click', '#btnId', function () {
        var Dipuprd_IDTqty = $(this).closest('td').find("input").val();
        var Product_Name = $(this).closest('tr').find('.lblProductName').text();
        var Dipu = $('input[type=hidden]', $(this).closest("td")).val();

        if (Dipuprd_IDTqty == "")
        {
            alert("Please enter Idt quantity !!!!!!");
            return false;
        }


        $(this).closest('td').find("span").show()
        $(this).closest('td').find("span").text(Dipuprd_IDTqty);
        $(this).closest('td').find("input").remove()
        $(this).closest('td').find("#btnId").remove()

        $.ajax(
          {

              type: "POST",
              contentType: "application/json; charset=utf-8",
              url: "frmMonitoringStock.aspx/insertIDT",
              data: "{'Dipuprd_IDTqty':'" + Dipuprd_IDTqty + "','Product_Name':'" + Product_Name + "','Dipu':'" + Dipu + "'}",
              dataType: "json",
              success: function (data) {
                  if (data.d == 1) {



                      
                  }


              }
           
              
          });
        return false;
    });
             



    $("#ctl00_ContentPlaceHolder1_ddlProduct").change(function () {

       

        var StockQty = "";
        var productUnit = "";
            var Product_Name = $("#ctl00_ContentPlaceHolder1_ddlProduct option:selected").text();
          


            $.ajax({
                type: "POST",
                url: "frmMonitoringStock.aspx/BindBatchproductDetail",
                data: "{'Product_Name':'" + Product_Name + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    if (data.d.length > 0) {
                       
                        StockQty = data.d[0].StockQty;
                        productUnit = 'Nishaaaaaa';// data.d[0].productUnit;
                        GSreservre = data.d[0].GSreservre;
                       // ctl00_ContentPlaceHolder1_tblMain
                        var tr = $('#ctl00_ContentPlaceHolder1_tblMain_ tr:last');
                        var firstcolumnval = $(tr).find("td").html()
                        var p = $(tr).find("td").find('span.lbltotalQty').html(StockQty)
                        var p2 = $(tr).find("td").find('span.lblprdunit').html(productUnit)
                        var p3 = $(tr).find("td").find('span.lblGsreserve').html(GSreservre)
                        var totalRows = "";
                        var totalRows1 = $("#ctl00_ContentPlaceHolder1_tblMain_ tr").length;
                        
                        var h = parseInt(totalRows1) - 3

                        totalRows = parseInt(h) + 1;
                        var p1 = $(tr).find("td").find('span.lblsno').html(h)

                    }
                    else
                    {
                        alert("Error");
                    }

                },



            });


          //  $("[id*=ctl00_ContentPlaceHolder1_grdbachwithproductqty] tr:gt(1)").hide();

            
            var row = $("[id*=ctl00_ContentPlaceHolder1_tblMain_] tr:eq(1)").clone(true);

            $("[id$=ctl00_ContentPlaceHolder1_tblMain_]").append(row);
            $(row).find(".lblsno").text('');
            $(row).find(".lblProductName").text(Product_Name);
            $(row).find(".lbltotalQty").text();
            $(row).find(".lblprdunit").text(); 
            $(row).find(".lblappendrow").text('');
            $(row).find(".lblGsreserve").text();

            $("[id*=ctl00_ContentPlaceHolder1_tblMain_] tr").show();
            //$("[id*=ctl00_ContentPlaceHolder1_tblMain_] tr:eq(1)").hide();
           // $("[id*=ctl00_ContentPlaceHolder1_tblMain_] tr:eq(2)").hide();

            $("#ctl00_ContentPlaceHolder1_tblMain_").css("display", "block");

    });
    return false;




    


});