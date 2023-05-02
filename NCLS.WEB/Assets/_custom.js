$(document).ready(function () {

    $.fn.datepicker.defaults.format = "dd/mm/yyyy";

    var menu, submenu;
    $('.page-breadcrumb > li').each(function (index) {
        if (index == 0)
            menu = $(this).text();
        else if (index == 1)
            submenu = $(this).text();
    });
    $('.head-menu').each(function () {
        $(this).removeClass('active');
        $(this).removeClass('start');
        if ($(this).find('a > span.root-menu').text().trim() == menu.trim()) {
            $(this).addClass('active');
            $(this).addClass('start');
        }
    });

    function merge_options(obj1, obj2) {
        var obj3 = {};
        obj3 = obj1;
        for (var attrname in obj2) { obj3[attrname] = obj2[attrname]; }
        return obj3;
    }
    $.fn.serializeObjectTable = function () {
        var o = {};

        var table = this.DataTable();
        var a = table.$('input, select').serialize();
        var parms = {};
        var items = a.split("&");
        for (var i = 0; i < items.length; i++) {
            var values = items[i].split("=");
            var key = decodeURIComponent(values.shift());
            var value = values.join("=")
            parms[key] = decodeURIComponent(value);
        }
        return (parms);
        return o;
    };
    $.fn.serializeObjectTest = function () {

        var disabled = this.find(':input:disabled').removeAttr('disabled');
        var a = this.find('input, select').serialize();
        disabled.attr('disabled', 'disabled');
        return data;
    };
    $.fn.serializeObject = function () {
        var o = {};
        var disabledInput = this.find(':input:disabled').removeAttr('disabled')
        var a = this.find('input[name],select[name],textarea[name]').not('input[type=hidden]').serializeArray();
        //var a = this.find('input[name],select[name],textarea[name],input[type=hidden]').serializeArray();

        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        disabledInput.attr('disabled', 'disabled');
        return o;
    };
    $(".datatable").DataTable({
        responsive: false,
        "language": {
            "emptyTable": 'Data not found',
            "zeroRecords": 'Data not found'
        },
        "oLanguage": {
            "sSearch": "Search"
        },
        "aLengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
        "aaSorting": []
    }).columns.adjust().draw();

    $('.date-picker').datepicker({
        rtl: App.isRTL(),
        orientation: "right",
        autoclose: true       
    });

    //Loadding
    $(document).ajaxStart(function () {
        $('#loading').show();
    }).ajaxStop(function () {
        $('#loading').hide();
    }).ajaxError(function (e, xhr, settings, exception) {
        if (exception.toString() != '' && exception.toString() != 'abort' ) { // && exception.toString() != 'abort'
            //  alertMessage('Error ' + exception.toString());
            bootbox.confirm("System error - Do you want error message?", function (result) {
                if (result)
                    window.location.href = "../Error/Error";          
            });    
    }
    });

    $(document).ajaxStart(function () {
        $('#loading').show();
    }).ajaxStop(function () {
        $('#loading').hide();
    });
    //Loadding

});

function modalGET(caption, controller, action, isFull) {
    var url = root + controller + '/' + action;
    $.get(url, function (result) {

        $('#modalDialog > .modal-dialog > .modal-content > .modal-body').html(result);
        showModal(caption, isFull);
    });
}

function modalGET_Id(caption, controller, action, id, isFull) {
    var url = root + controller + '/' + action + '/' + id;
    $.get(url, function (result) {
        $('#modalDialog > .modal-dialog > .modal-content > .modal-body').html(result);
        showModal(caption, isFull);
    });
}

function modalGET_Args(caption, controller, action, args, isFull) {
    var url = root + controller + '/' + action + '?' + args;
    $.get(url, function (result) {
        $('#modalDialog > .modal-dialog > .modal-content > .modal-body').html(result);
        showModal(caption, isFull);
    });
}

function modalPOST(caption, controller, action, data, isFull, med) {
    var url = root + controller + '/' + action;
    $.post(url, data, function (result) {
        $('#modalDialog > .modal-dialog > .modal-content > .modal-body').html(result);
        showModal(caption, isFull);
    });
}
function modalPOSTLv2(caption, controller, action, data, isFull) {
    var url = root + controller + '/' + action;
    $.post(url, data, function (result) {
        $('#modalDialogLv2 > .modal-dialog > .modal-content > .modal-body').html(result);
        showModalLv2(caption, isFull);
    });
}

function showModal(caption, isFull, med) {

    $('#modalDialog > .modal-dialog').removeClass('modal-full');
    $('#modalDialog > .modal-dialog').removeClass('modal-20');
    $('#modalDialog > .modal-dialog').removeClass('modal-30');
    $('#modalDialog > .modal-dialog').removeClass('modal-40');
    $('#modalDialog > .modal-dialog').removeClass('modal-50');
    $('#modalDialog > .modal-dialog').removeClass('modal-55');
    $('#modalDialog > .modal-dialog').removeClass('modal-60');
    $('#modalDialog > .modal-dialog').removeClass('modal-60');
    $('#modalDialog > .modal-dialog').removeClass('modal-70');
    $('#modalDialog > .modal-dialog').removeClass('modal-75');
    $('#modalDialog > .modal-dialog').removeClass('modal-80');
    $('#modalDialog > .modal-dialog').removeClass('modal-90');
    $('#modalDialog > .modal-dialog').removeClass('modal-99');

    if (typeof (isFull) === "boolean") {
        if (isFull)
            $('#modalDialog > .modal-dialog').addClass('modal-full');
        else
            $('#modalDialog > .modal-dialog').removeClass('modal-full');
    } else {
        if (typeof (isFull) === "number") {
            var x = isFull;
            switch (true) {
                case (x >= 20 && x < 30):
                    $('#modalDialog > .modal-dialog').addClass('modal-20');
                    break;
                case (x >= 30 && x < 38):
                    $('#modalDialog > .modal-dialog').addClass('modal-36');
                    break;
                case (x >= 30 && x < 40):
                    $('#modalDialog > .modal-dialog').addClass('modal-30');
                    break;
                case (x >= 40 && x < 50):
                    $('#modalDialog > .modal-dialog').addClass('modal-40');
                    break;
                case (x >= 50 && x < 60):
                    $('#modalDialog > .modal-dialog').addClass('modal-50');
                    break;
                case (x >= 55 && x < 60):
                    $('#modalDialog > .modal-dialog').addClass('modal-55');
                    break;
                case (x >= 60 && x < 70):
                    $('#modalDialog > .modal-dialog').addClass('modal-60');
                    break;
                case (x >= 70 && x < 80):
                    $('#modalDialog > .modal-dialog').addClass('modal-70');
                    break;
                case (x >= 70 && x < 76):
                    $('#modalDialog > .modal-dialog').addClass('modal-75');
                    break;
                case (x >= 80 && x < 90):
                    $('#modalDialog > .modal-dialog').addClass('modal-80');
                    break;
                case (x >= 90 && x < 95):
                    $('#modalDialog > .modal-dialog').addClass('modal-90');
                    break;
                case (x >= 95):
                    $('#modalDialog > .modal-dialog').addClass('modal-99');
                    break;
                default:
                    $('#modalDialog > .modal-dialog').addClass('modal-full');
                    break;
            }
        }
    }
    
    $('#modalDialog > .modal-dialog > .modal-content > .modal-header > .modal-title').text(caption);
    $('#modalDialog').modal('show');
}
function showModalLv2(caption, isFull) {
    if (typeof (isFull) === "boolean") {
        if (isFull)
            $('#modalDialogLv2 > .modal-dialog').addClass('modal-full');
        else
            $('#modalDialogLv2 > .modal-dialog').removeClass('modal-full');
    } else {
        if (typeof (isFull) === "number") {
            var x = isFull;
            switch (true) {
                case (x >= 20 && x < 30):
                    $('#modalDialog > .modal-dialog').addClass('modal-20');
                    break;
                case (x >= 30 && x < 40):
                    $('#modalDialog > .modal-dialog').addClass('modal-30');
                    break;
                case (x >= 40 && x < 50):
                    $('#modalDialog > .modal-dialog').addClass('modal-40');
                    break;
                case (x >= 50 && x < 60):
                    $('#modalDialog > .modal-dialog').addClass('modal-50');
                    break;
                case (x >= 60 && x < 70):
                    $('#modalDialog > .modal-dialog').addClass('modal-60');
                    break;
                case (x >= 70 && x < 80):
                    $('#modalDialog > .modal-dialog').addClass('modal-70');
                    break;
                case (x >= 80 && x < 90):
                    $('#modalDialog > .modal-dialog').addClass('modal-80');
                    break;
                case (x >= 90):
                    $('#modalDialog > .modal-dialog').addClass('modal-90');
                    break;
            default:
                $('#modalDialog > .modal-dialog').addClass('modal-full');
                break;
            }
        }
    }
    $('#modalDialogLv2 > .modal-dialog > .modal-content > .modal-header > .modal-title').text(caption);
    $('#modalDialogLv2').modal('show');
}

function clearModal() {
    $('#modalDialog > .modal-dialog > .modal-content > .modal-body').html('');
    $('#modalDialog > .modal-dialog > .modal-content > .modal-header > .modal-title').text('');
    $('#modalDialog').modal('hide');
}

function clearModalLv2() {
    $('#modalDialogLv2 > .modal-dialog > .modal-content > .modal-body').html('');
    $('#modalDialogLv2 > .modal-dialog > .modal-content > .modal-header > .modal-title').text('');
    $('#modalDialogLv2').modal('hide');
}
function alertMessage(message) {
    if (!message)
        message = '';
    bootbox.alert(message, function () { });
}

function confirmMessage(message) {
    if (!message)
        message = "Confirm";
    bootbox.confirm(message, function (result) { return result; });
}

function GenerateJsonPostData(Jquery) {
    var $ = Jquery;
    var paramControlArray = new Array();
    var paramNameArray = new Array();
    var paramControlTypeArray = new Array();
    var paramOptionArray = new Array();
    this.add = function (ControlId, ParamName, ControlType, option) {
        paramControlArray.push(ControlId);
        paramNameArray.push(ParamName);
        paramControlTypeArray.push(ControlType);
        paramOptionArray.push(option);
    }
    this.GetPostDataString = function () {
        var paramArray = new Array();
        for (var i = 0; i < paramControlArray.length; i++) {
            var condRadio = '';
            var value = '';
            switch (paramControlTypeArray[i]) {

                case "radio":
                    value = $("#" + paramControlArray[i] + " Input[type=radio]:checked").val(); break;
                case "checkbox":
                    value = $("#" + paramControlArray[i])[0].checked.toString(); break;
                case "custom":
                    value = "";
                    if (paramOptionArray[i] != null) {
                        if (paramOptionArray[i].customValue != null) {
                            value = paramOptionArray[i].customValue;
                        }
                    }
                    break;
                case "option":
                    value = $("#" + paramControlTypeArray[i]).val();
                    
                default:
                    value = $("#" + paramControlArray[i]).val(); break;
            }

            if (value == null) { value = ""; }
            if (paramOptionArray[i] != null) {
                if (paramOptionArray[i].isNumberString == true) {
                    value = us_MoneyToNumber(value);
                }
            }
            value = value.replace(/\\/, '\\\\');
            value = value.replace("'", "\\'");
            var str = "'" + paramNameArray[i] + "':'" + value + "'";
            paramArray.push(str);
        }
        return "{" + paramArray.join(",") + "}";
    }
}

var ComponentsDateTimePickers = function () {

    var handleDatePickers = function () {

        if (jQuery().datepicker) {
            $('.date-picker').datepicker({
                rtl: App.isRTL(),
                orientation: "left",
                autoclose: true
            });
            //$('body').removeClass("modal-open"); // fix bug when inline picker is used in modal
        }

        /* Workaround to restrict daterange past date select: http://stackoverflow.com/questions/11933173/how-to-restrict-the-selectable-date-ranges-in-bootstrap-datepicker */

        // Workaround to fix datepicker position on window scroll
        $(document).scroll(function () {
            $('#form_modal2 .date-picker').datepicker('place'); //#modal is the id of the modal
        });
    }

    var handleTimePickers = function () {

        if (jQuery().timepicker) {
            $('.timepicker-default').timepicker({
                autoclose: true,
                showSeconds: true,
                minuteStep: 1
            });

            $('.timepicker-no-seconds').timepicker({
                autoclose: true,
                minuteStep: 5,
                defaultTime: false
            });

            $('.timepicker-24').timepicker({
                autoclose: true,
                minuteStep: 5,
                showSeconds: false,
                showMeridian: false
            });

            // handle input group button click
            $('.timepicker').parent('.input-group').on('click', '.input-group-btn', function (e) {
                e.preventDefault();
                $(this).parent('.input-group').find('.timepicker').timepicker('showWidget');
            });

            // Workaround to fix timepicker position on window scroll
            $(document).scroll(function () {
                $('#form_modal4 .timepicker-default, #form_modal4 .timepicker-no-seconds, #form_modal4 .timepicker-24').timepicker('place'); //#modal is the id of the modal
            });
        }
    }

    var handleDateRangePickers = function () {
        if (!jQuery().daterangepicker) {
            return;
        }

        $('#defaultrange').daterangepicker({
            opens: (App.isRTL() ? 'left' : 'right'),
            format: 'MM/DD/YYYY',
            separator: ' to ',
            startDate: moment().subtract('days', 29),
            endDate: moment(),
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract('days', 1), moment().subtract('days', 1)],
                'Last 7 Days': [moment().subtract('days', 6), moment()],
                'Last 30 Days': [moment().subtract('days', 29), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
            },
            minDate: '01/01/2012',
            maxDate: '12/31/2018',
        },
            function (start, end) {
                $('#defaultrange input').val(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            }
        );

        $('#defaultrange_modal').daterangepicker({
            opens: (App.isRTL() ? 'left' : 'right'),
            format: 'MM/DD/YYYY',
            separator: ' to ',
            startDate: moment().subtract('days', 29),
            endDate: moment(),
            minDate: '01/01/2012',
            maxDate: '12/31/2018',
        },
            function (start, end) {
                $('#defaultrange_modal input').val(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            }
        );

        // this is very important fix when daterangepicker is used in modal. in modal when daterange picker is opened and mouse clicked anywhere bootstrap modal removes the modal-open class from the body element.
        // so the below code will fix this issue.
        $('#defaultrange_modal').on('click', function () {
            if ($('#daterangepicker_modal').is(":visible") && $('body').hasClass("modal-open") == false) {
                $('body').addClass("modal-open");
            }
        });

        $('#reportrange').daterangepicker({
            opens: (App.isRTL() ? 'left' : 'right'),
            startDate: moment().subtract('days', 29),
            endDate: moment(),
            //minDate: '01/01/2012',
            //maxDate: '12/31/2014',
            dateLimit: {
                days: 60
            },
            showDropdowns: true,
            showWeekNumbers: true,
            timePicker: false,
            timePickerIncrement: 1,
            timePicker12Hour: true,
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract('days', 1), moment().subtract('days', 1)],
                'Last 7 Days': [moment().subtract('days', 6), moment()],
                'Last 30 Days': [moment().subtract('days', 29), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
            },
            buttonClasses: ['btn'],
            applyClass: 'green',
            cancelClass: 'default',
            format: 'MM/DD/YYYY',
            separator: ' to ',
            locale: {
                applyLabel: 'Apply',
                fromLabel: 'From',
                toLabel: 'To',
                customRangeLabel: 'Custom Range',
                daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
                monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                firstDay: 1
            }
        },
            function (start, end) {
                $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            }
        );
        //Set the initial state of the picker label
        $('#reportrange span').html(moment().subtract('days', 29).format('MMMM D, YYYY') + ' - ' + moment().format('MMMM D, YYYY'));
    }

    var handleDatetimePicker = function () {

        if (!jQuery().datetimepicker) {
            return;
        }

        $(".form_datetime").datetimepicker({
            autoclose: true,
            isRTL: App.isRTL(),
            format: "dd MM yyyy - hh:ii",
            pickerPosition: (App.isRTL() ? "bottom-right" : "bottom-left")
        });

        $(".form_advance_datetime").datetimepicker({
            isRTL: App.isRTL(),
            format: "dd MM yyyy - hh:ii",
            autoclose: true,
            todayBtn: true,
            startDate: "2013-02-14 10:00",
            pickerPosition: (App.isRTL() ? "bottom-right" : "bottom-left"),
            minuteStep: 10
        });

        $(".form_meridian_datetime").datetimepicker({
            isRTL: App.isRTL(),
            format: "dd MM yyyy - HH:ii P",
            showMeridian: true,
            autoclose: true,
            pickerPosition: (App.isRTL() ? "bottom-right" : "bottom-left"),
            todayBtn: true
        });

        $('body').removeClass("modal-open"); // fix bug when inline picker is used in modal

        // Workaround to fix datetimepicker position on window scroll
        $(document).scroll(function () {
            $('#form_modal1 .form_datetime, #form_modal1 .form_advance_datetime, #form_modal1 .form_meridian_datetime').datetimepicker('place'); //#modal is the id of the modal
        });
    }

    var handleClockfaceTimePickers = function () {

        if (!jQuery().clockface) {
            return;
        }

        $('.clockface_1').clockface();

        $('#clockface_2').clockface({
            format: 'HH:mm',
            trigger: 'manual'
        });

        $('#clockface_2_toggle').click(function (e) {
            e.stopPropagation();
            $('#clockface_2').clockface('toggle');
        });

        $('#clockface_2_modal').clockface({
            format: 'HH:mm',
            trigger: 'manual'
        });

        $('#clockface_2_modal_toggle').click(function (e) {
            e.stopPropagation();
            $('#clockface_2_modal').clockface('toggle');
        });

        $('.clockface_3').clockface({
            format: 'H:mm'
        }).clockface('show', '14:30');

        // Workaround to fix clockface position on window scroll
        $(document).scroll(function () {
            $('#form_modal5 .clockface_1, #form_modal5 #clockface_2_modal').clockface('place'); //#modal is the id of the modal
        });
    }

    return {
        //main function to initiate the module
        init: function () {
            handleDatePickers();
        }
    };

}();

function countdate(strDateStart,strDateEnd) {
    var dateStart = new Date(strDateStart);
    var dateEnd = new Date(strDateEnd);
    var diffDays = dateEnd.getDate() - dateStart.getDate();
    return diffDays;
}

function isEmptyOrSpaces(str) {
    debugger;
    return str === null || $.trim(str)=== null;
}

//function getFormatDateyyyyMMdd(data) {
//    var parts = data.split('/');
//    var date = new Date(parts[2], parts[1], parts[0]);
//    var year = date.getFullYear();
//    var month = (date.getMonth()).toString();
//    month = month.length > 1 ? month : '0' + month;
//    var day = date.getDate().toString();
//    day = day.length > 1 ? day : '0' + day;
//    return year + '' + month + '' + day;
//}

function getFormatDateyyyyMMdd(data) {  
    var parts = data.split('/');
    var year = parts[2];
    var month = parts[1].length > 1 ? parts[1] : '0' + parts[1];
    var day = parts[0].length > 1 ? parts[0] : '0' + parts[0];
    //  alert(year + '' + month + '' + day);
    return year + '' + month + '' + day;

}

function getFormatDatedd_MM_yyyy(data) {
    if (data != null) {
        var parts = data.split('/');
        var date = new Date(parts[2], parts[1], parts[0]);
        var year = date.getFullYear();
        var month = (date.getMonth()).toString();
        month = month.length > 1 ? month : '0' + month;
        var day = date.getDate().toString();
        day = day.length > 1 ? day : '0' + day;
        return day + '/' + month + '/' + year;
    }
    else {
        return "";
    }
}


function DateJsonToDatedd_MM_yyyy(data) {

    if (data != null) {
        var date = new Date(parseInt(data.substr(6)));
        //  var date = new date(parseInt(data.replace(/(^.*\()|([+-].*$)/g, '')));
        var year = date.getFullYear();
        var month = (date.getMonth() + 1).toString();
        month = month.length > 1 ? month : '0' + month;
        var day = date.getDate().toString();
        day = day.length > 1 ? day : '0' + day;
        return day + '/' + month + '/' + year;
    }
    else {
        return "";
    }
}

function moneyFormat(el) {
    if (el != null) {
        var toReturn = parseFloat(el.value.replace(/,/g, ""))
        .toFixed(2)
        .toString()
        .replace(/\B(?=(\d{3})+(?!\d))/g, ",");

        if (isNaN(toReturn)) {
            var toReturn = 0.00;
        }
        el.value = toReturn;
    } else {
        var toReturn = 0.00;
    }

    el.value = toReturn;
}


function numberWithComma(n) {
    return n.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,");
}

function CheckNumberValue(id) {

    var toReturn = 0;

    var value = id.val();
    if (value == '' || value == undefined) {
        value = 0;
    }
    else {
        value = value.replace(/,/g, '');
    }
    value = parseFloat(value);
    if (isNaN(value) || value == 0) {
        id.val(0);
        value = 0;
    }
    toReturn = value;

    return toReturn;
}
function showDatepicker(sender) {
    //var id = $(sender).parent().parent().find("input").attr('id');
    var id = $(sender).closest("div").find("input").attr('id');
    $('#' + id).datepicker('show');
}
