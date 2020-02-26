$(function ($) {
    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: '<Ant',
        nextText: 'Sig>',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['es']);
});

function popupDHH(idp, idl, w, z) {
    var ww = $(window).width();
    var wh = $(window).height();
    var h = $('#' + idp).height();
    var ml = ((ww / 2) - (w / 2)) - 17;
    var mt = ((wh / 2) - (h / 2)) - 17;
    $('#' + idl).css('display', 'block');
    $('#' + idp).css({
        'display': 'block',
        'width': w + 'px',
        'height': h + 'px',
        'margin-left': ml + 'px',
        'margin-top': mt + 'px',
        'z-index': z
    });
}

function castFechaCorta(fechaJson) {

    if (fechaJson == null) {
        return "";
    }
    var fullDate = new Date(parseInt(fechaJson.substr(6)));

    var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? '0' + (fullDate.getMonth() + 1) : (fullDate.getMonth() + 1);

    var currentDate = fullDate.getDate() + "/" + twoDigitMonth + "/" + fullDate.getFullYear();

    return currentDate;

};

$(function () {
    $('#selectMenuMain').selectpicker();
    setHeight();
});

function setHeight() {
    if (!($(window).width() <= 600)) {
        $("#menuLeft").css('height', $('#contentDocument').height() + 42);
    } else {
        $("#menuLeft").css('height', 'auto');
    }
}

$(window).resize(function () {
    var a = $("#menuLeft");

    if (a.css('position') == 'absolute') {
        setHeight();
    }
});

$(window).on('load', function () {
    $('.selectpicker').selectpicker();
});

//$(".arrowColapse").click(function () {
//    var a = $("#menuLeft");
//    var b = $("ul.menuDHH");
//    var c = $("#contentRight");
//    a.css({ 'display': 'block', 'width': '100%', 'position': 'static', 'margin': '-20px 0 20px 0', 'height': 'auto' });
//    b.css({ 'margin-top': '10px' });
//    c.css({ 'padding-left': '0' });
//});

$(document).ready(function () {

    (function ($) {
        $.fn.clickToggle = function (func1, func2) {
            var funcs = [func1, func2];
            this.data('toggleclicked', 0);
            this.click(function () {
                var data = $(this).data();
                var tc = data.toggleclicked;
                $.proxy(funcs[tc], this)();
                data.toggleclicked = (tc + 1) % 2;
            });
            return this;
        };
    }(jQuery));


    $('.arrowColapse').clickToggle(function () {
        var a = $("#menuLeft");
        var b = $("ul.menuDHH");
        var c = $("#contentRight");
        var d = $(".arrowColapse");
        a.css({ 'display': 'none', 'width': '100%', 'position': 'static', 'margin': '-20px 0 20px 0', 'height': 'auto' });
        b.css({ 'margin-top': '10px' });
        c.css({ 'padding-left': '0' });
        d.css({ 'left': '-9px' });
    },
    function () {
        var a = $("#menuLeft");
        var b = $("ul.menuDHH");
        var c = $("#contentRight");
        var d = $(".arrowColapse");
        a.css({ 'display': '', 'width': '', 'position': '', 'margin': '', 'height': '' });
        b.css({ 'margin-top': '' });
        c.css({ 'padding-left': '' });
        d.css({ 'left': '' });
        setHeight();
    });

});