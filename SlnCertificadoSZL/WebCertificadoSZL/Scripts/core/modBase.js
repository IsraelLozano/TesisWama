var textoPlaceholder = "Dato obligatorio";


function ajaxindicatorstart(text) {
    if (jQuery('body').find('#resultLoading').attr('id') != 'resultLoading') {
        jQuery('body')
            .append('<div id="resultLoading" ' + 'style="display:none"><div><img src="' + globalRutaServidor+'Content/img/ajax-loader.gif"><div>' + text + '</div></div><div class="bg"></div></div>');
    }

    jQuery('#resultLoading').css({
        'width': '100%',
        'height': '100%',
        'position': 'fixed',
        'z-index': '10000000',
        'top': '0',
        'left': '0',
        'right': '0',
        'bottom': '0',
        'margin': 'auto'
    });

    jQuery('#resultLoading .bg').css({
        'background': '#000000',
        'opacity': '0.7',
        'width': '100%',
        'height': '100%',
        'position': 'absolute',
        'top': '0'
    });

    jQuery('#resultLoading>div:first').css({
        'width': '250px',
        'height': '75px',
        'text-align': 'center',
        'position': 'fixed',
        'top': '0',
        'left': '0',
        'right': '0',
        'bottom': '0',
        'margin': 'auto',
        'font-size': '16px',
        'z-index': '10',
        'color': '#ffffff'

    });

    jQuery('#resultLoading .bg').height('100%');
    jQuery('#resultLoading').fadeIn(300);
    jQuery('body').css('cursor', 'wait');

}

function ajaxindicatorstop() {
    jQuery('#resultLoading .bg').height('100%');
    jQuery('#resultLoading').fadeOut(300);
    jQuery('body').css('cursor', 'default');
}

//jQuery(document).ajaxStart(function () {
//    //show ajax indicator
//    ajaxindicatorstart('Procesando...por favor espere...');
//}).ajaxStop(function () {
//    //hide ajax indicator
//    ajaxindicatorstop();
//});

function InputToUpper(obj) {
    if (obj.value != "") {
        obj.value = obj.value.toUpperCase();
    }
}
$(document).ready(function ()
{
    //$("input.toupper:text").css("text-transform", "uppercase");

    $.ajaxSetup({ cache: false });

    bootbox.setDefaults({
        /**
         * @optional String
         * @default: en
         * which locale settings to use to translate the three
         * standard button labels: OK, CONFIRM, CANCEL
         */
        locale: "es",

        /**
         * @optional Boolean
         * @default: true
         * animate the dialog in and out (not supported in < IE 10)
         */
        animate: true,

        
    });

    $('body').on("click", ".modalUCP", function () {

        var url = $(this).attr('data-url');
        var divModal = $(this).attr('data-div');
        var divContenedor = $(this).attr('data-contenedor');
        var seccionModal = ".seccionModal";
        var seccionContenedor = "#contenedor";
        if (divModal) {
            seccionModal = "#" + divModal;
        }
        if (divContenedor) {
            seccionContenedor = "#" + divContenedor;
        }
        $.get(url, function (data) {
            $(seccionModal).html(data);
            $(seccionContenedor).modal('show');
            $(".modal-content").draggable({
                handle: ".modal-header",
                cursor: "move"
            });
        });
    });

$('body').on("click", ".modalUCP2", function () {
        var idcontent = "#" + $(this).attr('data-id');
        var divModal = $(this).attr('data-div');
        var divContenedor = $(this).attr('data-contenedor');
        var seccionModal = ".seccionModal";
        var seccionContenedor = "#contenedor";
        if (divModal) {
            seccionModal = "#" + divModal;
        }
        if (divContenedor) {
            seccionContenedor = "#" + divContenedor;
        }
        $(seccionModal).html($(idcontent).html());
        $(seccionContenedor).modal('show');
        $(".modal-content").draggable({
            handle: ".modal-header",
            cursor: "move"
        });
});



    $('body').on("click", ".modalSENACEUrl", function () {
        var url = $(this).attr('data-url');
        var div = $(this).attr('data-div');
        var cont = $(this).attr('data-contenedor');

        $.get(url, function (data) {
            $('.' + div).html(data);
            $('#' + cont).modal('show');
            $(".modal-content").draggable({
                handle: ".modal-header",
                cursor: "move"
            });
        });
    });



    /**
     * Controla la tacla enter para pasar el foco al siguiente cuadro de texto
     */
    $("input.next:text").on('keypress', function (e) {

        if (e.keyCode == 13) {
            var nextIndex = $('input:not([readonly="readonly"]):text').index(this) + 1;
            $('input:not([readonly="readonly"]):text')[nextIndex].focus();
        }
    });

    /**
 * Controlar el ingreso de texto en un cuadro de texto y lo convierte a mayuscula
 */
    //$("input .toupper:text").on('keyup', function () {
        
    //    debugger;
    //    $(this).val(($(this).val()).toUpperCase());
    //});

    $("input.toupper:text").on('keyup', function () {
        $(this).val(($(this).val()).toUpperCase());
    });

    //$("input[type=text]").keyup(function () {
    //    debugger;
    //    $(this).val($(this).val().toUpperCase());
    //});
  
});

function descargarDocumento(url) {

    window.location = url;
};

/**
* Funcion que genera una ventana popup
* @param {Direccion url obligatorio para levantar la pagina} url 
* @param {Parametro que define el titulo de la ventana} name 
* @param {Establece el ancho de la ventana} width 
* @param {Establece el alto de la ventana} height 
* @returns {Ejecuta el popup} 
*/
function fventanaPopup(url, name, width, height) {
    var left = (screen.width / 2) - (width / 2);
    var top = (screen.height / 2) - (height / 2);
    var settings = "toolbar=no,location=no,directories=no," +
        "status=no,menubar=no,scrollbars=yes," +
        "resizable=yes,width=" + width + ",height=" + height + ",top=" + top + ",left=" + left;
    var miVentana = window.open(url, name, settings);
    //miVentana.print();
    ///miVentana.close();
};


/**
 * Funcion que formatea una fecha, en formato corto: dd/mm/yyyy
 * @param {Parametro que es recibio por el cliente} date 
 * @returns {returno un formato de fecha en formato dd/mm/yyyy} 
 */
function FormatearFecha(date) {
    var year = date.getFullYear();
    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;
    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;
    return day + '/' + month + '/' + year;
}

//function popupDHH(idp, idl, w, z) {
//    var ww = $(window).width();
//    var wh = $(window).height();
//    var h = $('#' + idp).height();
//    var ml = ((ww / 2) - (w / 2)) - 17;
//    var mt = ((wh / 2) - (h / 2)) - 17;
//    $('#' + idl).css('display', 'block');
//    $('#' + idp).css({
//        'display': 'block',
//        'width': w + 'px',
//        'height': h + 'px',
//        'margin-left': ml + 'px',
//        'margin-top': mt + 'px',
//        'z-index': z
//    });
//}
function SoloNumeros(e) {
    var val = (document.all);
    var key = val ? e.keyCode : e.which;
    if (key > 31 && (key < 48 || key > 57)) {
        if (val)
            window.event.keyCode = 0;
        else {
            e.stopPropagation();
            e.preventDefault();
        }
    }
}


function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}


function IrPagina(url) {
    window.location = url;
}