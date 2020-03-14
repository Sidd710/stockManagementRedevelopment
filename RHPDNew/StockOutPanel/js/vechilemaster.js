$(document).ready(function () {
    var rdchecked = "DD";
    $("input[type='radio']").change(function () {
        if ($(this).val() == "rdDD") {
            rdchecked = "DD";
        }
        else {
            rdchecked = "CHT";
        }
    });
 
    $('#ctl00_ContentPlaceHolder1_btnaddvechile').click(function () {
        var Through_Check = $('#ctl00_ContentPlaceHolder1_txtthrough').val();
        
        if (rdchecked != "" && Through_Check!="") {

            $("#divvechileaddmaster").show(500);
            $("#grdvechile").fadeIn();


            if (rdchecked == "DD") {

                var table = '<table id="grdvechile" class="stm" width="100%><thead class="stm_head"> <tr> <th style="background-color:skyblue;font:600;font-family:cursive;"> Vehicle No</th> <th style="background-color:skyblue;font:600;font-family:cursive;"> Driver Name </th> <th style="background-color:skyblue;font:600;font-family:cursive;"> Rank  </th> <th style="background-color:skyblue;font:600;font-family:cursive;"> Army Number  </th><th style="background-color:skyblue;font:600;font-family:cursive;"> Unit Number  </th><th style="background-color:skyblue;font:600;font-family:cursive;"> Remarks  </th></thead></tr>';

                for (var i = 0; i < 1; i++) {
                    var row = '<tr">';

                    row += '<td ><input type="text" class="vechileClass"></td>';
                    row += '<td ><input type="text" class="driverclass"></td>';
                    row += '<td ><input type="text" class="rankclass"></td>';
                    row += '<td><input type="text" class="ArmyNo"></td>';
                    row += '<td><input type="text" class="UnitNo"></td>';
                    row += '<td><input type="text" class="remarks" ></td>';

                    row += '</tr><br/>';

                    table += row;
                }

                table += '</table>';

                $('#divvechileaddmaster').html(table);
                $('#divvechileaddmaster').append('<div style="margin-left:-1000px;margin-top:14px;"><input type="submit" value="Add Vehicle" class="btnvechilecss"></div> ');
                $('#divvechileaddmaster').append('<div style="margin-left:-820px;margin-top:-28px;"><input type="submit" value="Close" class="closebutton"></div> ');
                $('#divvechileaddmaster').append('<div style="margin-top:-26px;display:block" class="divbuttonsubmit"><input type="submit" value="Submit" class="submitButton"></div>');
                $('.divbuttonsubmit').css("display", "block");


            }
            else {

                var table = '<table id="grdvechile" class="stm" width="100%><thead class="stm_head"> <tr> <th style="background-color:skyblue;font:600;font-family:cursive;"> Vehicle No</th> <th style="background-color:skyblue;font:600;font-family:cursive;"> Driver Name </th> <th style="background-color:skyblue;font:600;font-family:cursive;"> License Number  </th><th style="background-color:skyblue;font:600;font-family:cursive;"> Remarks  </th></thead></tr>';

                for (var i = 0; i < 1; i++) {
                    var row = '<tr">';

                    row += '<td ><input type="text" class="vechileClass"></td>';
                    row += '<td ><input type="text" class="driverclass"></td>';
                    row += '<td><input type="text" class="LicenseNo"></td>';
                    row += '<td><input type="text" class="remarks"></td>';


                    row += '</tr><br/>';

                    table += row;
                }

                table += '</table>';

                $('#divvechileaddmaster').html(table);
                $('#divvechileaddmaster').append('<div style="margin-left:-1000px;margin-top:14px;"><input type="submit" value="Add Vehicle" class="btnvechilecss"></div> ');
                $('#divvechileaddmaster').append('<div style="margin-left:-820px;margin-top:-28px;"><input type="submit" value="Close" class="closebutton"></div> ');
                $('#divvechileaddmaster').append('<div style="margin-top:-26px;display:block" class="divbuttonsubmit"><input type="submit" value="Submit" class="submitButton"></div>');
                $('.divbuttonsubmit').css("display", "block");


            }


            return false;

        }
        else {

            if (rdchecked == "" && Through_Check == "")
            {
                alert(" OOPS, Please Enter Through And  Select Vechile Type!");
                return false;
            }

            if (rdchecked == "") {
                alert(" OOPS, Please Select Vechile Type !!!!");
                return false;

            }
            else {
                alert(" OOPS, Please Enter Through !!!!");
                return false;

            }
            
           

        }
       
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
            $('#grdvechile').append('<tr><td><input type="text" class="vechileClass"></td><td><input type="text" class="driverclass"></td><td><input type="text" class="rankclass"></td><td><input type="text" class="ArmyNo"></td><td><input type="text" class="UnitNo"></td><td><input type="text" class="remarks"></td></tr>');
        }
        else
        {
            $('#grdvechile').append('<tr><td><input type="text" class="vechileClass"></td><td><input type="text" class="driverclass"></td><td><input type="text" class="LicenseNo"></td><td><input type="text" class="remarks"></td></tr>');

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
      
        /**** Coded by Rohit Pundeer *****/
        var TableData = new Array();

        $('#grdvechile tr').each(function (row, tr) {
            if (rdchecked == "DD") {
                vechileType = "DD";
                var LicenseNo = "";
                TableData[row] = {
                    "vechileType": vechileType,
                    "VechileNumber": $(this).find('td .vechileClass').val(),
                    "DriverName": $(this).find('td .driverclass').val(),
                    "Rank": $(this).find('td .rankclass').val(),
                    "ArmyNo": $(this).find('td .ArmyNo').val(),
                    "unitNo": $(this).find('td .UnitNo').val(),
                    "Remarks": $(this).find('td .remarks').val(),
                    "Through": Through,
                    "LicenseNo" : ""
                }
            }
            else if (rdchecked == "CHT") {
                vechileType = "CHT";
                var ArmyNo = "";
                var unitNo = "";
                var Rank = "";
                TableData[row] = {
                    "vechileType": vechileType,
                    "VechileNumber": $(this).find('td .vechileClass').val(),
                    "DriverName": $(this).find('td .driverclass').val(),
                    "Remarks": $(this).find('td .remarks').val(),
                    "LicenseNo": $(this).find('td .LicenseNo').val(),
                    "Through": Through,
                    "ArmyNo": ArmyNo,
                    "unitNo": unitNo,
                    "Rank": Rank
                }
            }
        });
        TableData.shift();
        TableData = $.toJSON(TableData);

        if (TableData != null && TableData != undefined) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../stockoutpanel.asmx/InsertIntoVechileMaster",
                data: "{'pTableData':'" + TableData + "'}",
                dataType: "json",
                success: function (data) {
                    window.location.href = "vechilemaster.aspx";
                    return false;
                },
                error: function (data) {
                    return false;
                },
            });
        }


        /***** Commentted by Rohit Pundeer *******/
        //$('#grdvechile tr').each(function () {
        //    var vechileType = "";
        //    var VechileNumber = $(this).find('td .vechileClass').val();
        //    var DriverName = $(this).find('td .driverclass').val();
        //    var Rank = $(this).find('td .rankclass').val();
        //    var ArmyNo = $(this).find('td .ArmyNo').val();
        //    var unitNo = $(this).find('td .UnitNo').val();
        //    var Remarks = $(this).find('td .remarks').val();
        //    var LicenseNo = $(this).find('td .LicenseNo').val();

        //    if (rdchecked == "DD") {
        //        vechileType = "DD";
        //        LicenseNo = "";
               
        //    }
        //    else
        //    {
        //        vechileType = "CHT";
        //        ArmyNo = "";
        //        unitNo = "";
        //        Rank = "";
        //    }


        //    if (rdchecked == "DD") {

        //        if (VechileNumber != "" && DriverName != "" && Rank != 0 && Rank != "" && VechileNumber != undefined && DriverName != undefined && Rank != undefined && ArmyNo != undefined && ArmyNo != "" && unitNo != undefined && unitNo != "" && vechileType != undefined && vechileType != "") {
        //            $.ajax({
        //                type: "POST",
        //                contentType: "application/json; charset=utf-8",
        //                url: "../stockoutpanel.asmx/InsertVechileMaster",
        //                data: "{'VechileNumber':'" + VechileNumber + "','DriverName':'" + DriverName + "','Rank':'" + Rank + "','Through':'" + Through + "','ArmyNo':'" + ArmyNo + "','vechileType':'" + vechileType + "','unitNo':'" + unitNo + "','Remarks':'" + Remarks + "','LicenseNo':'" + LicenseNo + "'}",
        //                dataType: "json",
        //                success: function (data) {
        //                },
        //            });
        //        }

        //    }
        //    else {
        //        if (VechileNumber != "" && DriverName != "" && VechileNumber != undefined && DriverName != undefined && Rank != undefined && LicenseNo != undefined && LicenseNo != "" && vechileType != undefined && vechileType != "") {
        //            $.ajax({
        //                type: "POST",
        //                contentType: "application/json; charset=utf-8",
        //                url: "../stockoutpanel.asmx/InsertVechileMaster",
        //                data: "{'VechileNumber':'" + VechileNumber + "','DriverName':'" + DriverName + "','Rank':'" + Rank + "','Through':'" + Through + "','ArmyNo':'" + ArmyNo + "','vechileType':'" + vechileType + "','unitNo':'" + unitNo + "','Remarks':'" + Remarks + "','LicenseNo':'" + LicenseNo + "'}",
        //                dataType: "json",
        //                success: function (data) {
        //                },
        //            });
        //        }
        //    }
          
           
        //});
        //window.location.href = "vechilemaster.aspx";
        //return false;
    });
    

/********* toJSON Plugin Code ***********/
 /**
 * jQuery JSON plugin v2.5.1
 * https://github.com/Krinkle/jquery-json
 *
 * @author Brantley Harris, 2009-2011
 * @author Timo Tijhof, 2011-2014
 * @source This plugin is heavily influenced by MochiKit's serializeJSON, which is
 *         copyrighted 2005 by Bob Ippolito.
 * @source Brantley Harris wrote this plugin. It is based somewhat on the JSON.org
 *         website's http://www.json.org/json2.js, which proclaims:
 *         "NO WARRANTY EXPRESSED OR IMPLIED. USE AT YOUR OWN RISK.", a sentiment that
 *         I uphold.
 * @license MIT License <http://opensource.org/licenses/MIT>
 */
    (function ($) {
        'use strict';

        var escape = /["\\\x00-\x1f\x7f-\x9f]/g,
            meta = {
                '\b': '\\b',
                '\t': '\\t',
                '\n': '\\n',
                '\f': '\\f',
                '\r': '\\r',
                '"': '\\"',
                '\\': '\\\\'
            },
            hasOwn = Object.prototype.hasOwnProperty;

        /**
         * jQuery.toJSON
         * Converts the given argument into a JSON representation.
         *
         * @param o {Mixed} The json-serializable *thing* to be converted
         *
         * If an object has a toJSON prototype, that will be used to get the representation.
         * Non-integer/string keys are skipped in the object, as are keys that point to a
         * function.
         *
         */
        $.toJSON = typeof JSON === 'object' && JSON.stringify ? JSON.stringify : function (o) {
            if (o === null) {
                return 'null';
            }

            var pairs, k, name, val,
                type = $.type(o);

            if (type === 'undefined') {
                return undefined;
            }

            // Also covers instantiated Number and Boolean objects,
            // which are typeof 'object' but thanks to $.type, we
            // catch them here. I don't know whether it is right
            // or wrong that instantiated primitives are not
            // exported to JSON as an {"object":..}.
            // We choose this path because that's what the browsers did.
            if (type === 'number' || type === 'boolean') {
                return String(o);
            }
            if (type === 'string') {
                return $.quoteString(o);
            }
            if (typeof o.toJSON === 'function') {
                return $.toJSON(o.toJSON());
            }
            if (type === 'date') {
                var month = o.getUTCMonth() + 1,
                    day = o.getUTCDate(),
                    year = o.getUTCFullYear(),
                    hours = o.getUTCHours(),
                    minutes = o.getUTCMinutes(),
                    seconds = o.getUTCSeconds(),
                    milli = o.getUTCMilliseconds();

                if (month < 10) {
                    month = '0' + month;
                }
                if (day < 10) {
                    day = '0' + day;
                }
                if (hours < 10) {
                    hours = '0' + hours;
                }
                if (minutes < 10) {
                    minutes = '0' + minutes;
                }
                if (seconds < 10) {
                    seconds = '0' + seconds;
                }
                if (milli < 100) {
                    milli = '0' + milli;
                }
                if (milli < 10) {
                    milli = '0' + milli;
                }
                return '"' + year + '-' + month + '-' + day + 'T' +
                    hours + ':' + minutes + ':' + seconds +
                    '.' + milli + 'Z"';
            }

            pairs = [];

            if ($.isArray(o)) {
                for (k = 0; k < o.length; k++) {
                    pairs.push($.toJSON(o[k]) || 'null');
                }
                return '[' + pairs.join(',') + ']';
            }

            // Any other object (plain object, RegExp, ..)
            // Need to do typeof instead of $.type, because we also
            // want to catch non-plain objects.
            if (typeof o === 'object') {
                for (k in o) {
                    // Only include own properties,
                    // Filter out inherited prototypes
                    if (hasOwn.call(o, k)) {
                        // Keys must be numerical or string. Skip others
                        type = typeof k;
                        if (type === 'number') {
                            name = '"' + k + '"';
                        } else if (type === 'string') {
                            name = $.quoteString(k);
                        } else {
                            continue;
                        }
                        type = typeof o[k];

                        // Invalid values like these return undefined
                        // from toJSON, however those object members
                        // shouldn't be included in the JSON string at all.
                        if (type !== 'function' && type !== 'undefined') {
                            val = $.toJSON(o[k]);
                            pairs.push(name + ':' + val);
                        }
                    }
                }
                return '{' + pairs.join(',') + '}';
            }
        };

        /**
         * jQuery.evalJSON
         * Evaluates a given json string.
         *
         * @param str {String}
         */
        $.evalJSON = typeof JSON === 'object' && JSON.parse ? JSON.parse : function (str) {
            /*jshint evil: true */
            return eval('(' + str + ')');
        };

        /**
         * jQuery.secureEvalJSON
         * Evals JSON in a way that is *more* secure.
         *
         * @param str {String}
         */
        $.secureEvalJSON = typeof JSON === 'object' && JSON.parse ? JSON.parse : function (str) {
            var filtered =
                str
                .replace(/\\["\\\/bfnrtu]/g, '@')
                .replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']')
                .replace(/(?:^|:|,)(?:\s*\[)+/g, '');

            if (/^[\],:{}\s]*$/.test(filtered)) {
                /*jshint evil: true */
                return eval('(' + str + ')');
            }
            throw new SyntaxError('Error parsing JSON, source is not valid.');
        };

        /**
         * jQuery.quoteString
         * Returns a string-repr of a string, escaping quotes intelligently.
         * Mostly a support function for toJSON.
         * Examples:
         * >>> jQuery.quoteString('apple')
         * "apple"
         *
         * >>> jQuery.quoteString('"Where are we going?", she asked.')
         * "\"Where are we going?\", she asked."
         */
        $.quoteString = function (str) {
            if (str.match(escape)) {
                return '"' + str.replace(escape, function (a) {
                    var c = meta[a];
                    if (typeof c === 'string') {
                        return c;
                    }
                    c = a.charCodeAt();
                    return '\\u00' + Math.floor(c / 16).toString(16) + (c % 16).toString(16);
                }) + '"';
            }
            return '"' + str + '"';
        };

    }(jQuery));
/********* toJSON Plugin Code  **********/

});