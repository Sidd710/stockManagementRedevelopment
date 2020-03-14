
$(document).ready(function () {

    $('.lnlp').click(function () {

        var LoadTallyNumber = $(this).closest('tr').find('.lbltallynumber').text();

        $.ajax({
            type: "POST",
            url: "loadtallyNumberlist.aspx/getloadtally",
            data: "{'LoadTallyNumber':'" + LoadTallyNumber + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {



                var table = '<table id="grdvechile"  class="stm" width="100%><thead class="stm_head"> <tr> <th> Commodity</th> <th> A/U  </th>  <th> PM Quantity</th> <th> Stock quantity</th><th> DM</th> <th> ESL</th> <th> Remarks</th>  </thead></tr>';

                for (var i = 0; i < data.d.length; i++) {
                    var row = '<tr">';
                    row += '<td ><span class="vechileClass">' + data.d[i].product_name + '</span></td>';
                    row += '<td ><span class="pmunit">' + data.d[i].productUnit + '</span></td>';
                    row += '<td ><span class="pmclass">' + data.d[i].PMQuantity + '</span></td>';
                    row += '<td ><span class="stockclass">' + data.d[i].StockQuantity + '</span></td>';
                    row += '<td ><span class="dm"></span></td>';
                    row += '<td ><span class="esl"></span></td>';
                    row += '<td ><span class="remark"></span></td>';
                

                    row += '</tr><br/>';

                    table += row;
                }

                table += '</table>';
                var jk = data.d[0].Authority;
                var gh = data.d[0].through;
                var vechile = data.d[0].vechileNo;

                var printWindow = window.open("");
                printWindow.document.write('<html><head><title>LOAD TALLY SHEET</title></head><body>');
                var htmlToPrint = '' +
                        '<style type="text/css">' +
                        'table th, table td {' +
                        'border:1px solid #000;' +
                        'padding;0.5em;' +
                        '}' +
                        '</style>';
                printWindow.document.write('<body >');
                printWindow.document.write("LoadTally No:" + '' + "");
                printWindow.document.write(LoadTallyNumber);
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write("Authority:" + '' + "");
                printWindow.document.write(jk);
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write("Through:" + '' + "");
                printWindow.document.write(gh);
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write("Vechile No:" + '' + "");
                printWindow.document.write(vechile);
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                htmlToPrint += table;

                printWindow.document.write(htmlToPrint);
                // popupWin.document.write($('#grdvechile').html());
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write("The Vehicle loaded in presence of stn bd of offrs,Unit rep, R&D Rep,Dsc Rep,and veh Dvr");
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
              
              
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write("Army No:" + '' + "");
                printWindow.document.write('</br>');
               
                printWindow.document.write("Rank:" + '' + "");
                printWindow.document.write('</br>');
                
                printWindow.document.write("Name:" + '' + "");
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');

                printWindow.document.write("Signature:" + '' + "");
                printWindow.document.write('</body></html>');
                printWindow.document.close();
                setTimeout(function () {
                    printWindow.print();
                }, 500);
                return false;



            }

        });


        return false;
    });

});