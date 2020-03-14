
$(document).ready(function () {

    $('.agh').click(function () {

        var issuevouchernumber = $(this).closest('tr').find('.lblvechileNameclass').text();

    $.ajax({
        type: "POST",
        url: "IssueVoucherlist.aspx/getissuevoucher",
        data: "{'issuevouchernumber':'" + issuevouchernumber + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {



            var table = '<table id="grdvechile"  class="stm" width="100%><thead class="stm_head"> <tr> <th> Commodity</th> <th> A/U  </th> <th> Stock quantity</th><th> DOM </th><th> ESL </th> </thead></tr>';

            for (var i = 0; i < data.d.length; i++) {
                var row = '<tr">';
                row += '<td ><span class="vechileClass">' + data.d[i].product_name + '</span></td>';
                row += '<td ><span class="pmclass">' + data.d[i].productUnit + '</span></td>';
                row += '<td ><span class="stockclass">' + data.d[i].StockQuantity + '</span></td>';
                row += '<td ><span class="dom"></span></td>';
                row += '<td ><span class="esl"></span></td>';

                row += '</tr><br/>';

                table += row;
            }

            table += '</table>';
            var jk = data.d[0].Authority;
            var gh = data.d[0].through;

                var printWindow = window.open("");
                printWindow.document.write('<html><head><title>ISSUE VOUCHER</title></head><body>');
                var htmlToPrint = '' +
                        '<style type="text/css">' +
                        'table th, table td {' +
                        'border:1px solid #000;' +
                        'padding;0.5em;' +
                        '}' +
                        '</style>';
                printWindow.document.write('<body >');
                printWindow.document.write("Issue Voucher Number:"+''+"");
                printWindow.document.write(issuevouchernumber);
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write("Authority:"+''+"");
                printWindow.document.write(jk);
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write("Through:"+''+"");
                printWindow.document.write(gh);
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                htmlToPrint += table;
                printWindow.document.write(htmlToPrint);
               // popupWin.document.write($('#grdvechile').html());
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write('</br>');
                printWindow.document.write("Issued and charged off");
               
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