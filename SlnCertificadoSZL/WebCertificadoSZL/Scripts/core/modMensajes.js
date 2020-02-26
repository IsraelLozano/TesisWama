/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../bootbox.js" />


/*Enumerados*/
var enumClaseTipoAlertas = {
    alertaSuccess: 1,
    alertaInfo: 2,
    alertaWarning: 3,
    alertaDanger: 4
};

function RecuperarClaseAlerta(valor) {
    var clase = ''
    switch (valor) {
        case 1: clase = 'alert alert-success alert-dismissible'; break;
        case 2: clase = 'alert alert-info alert-dismissible'; break;
        case 3: clase = 'alert alert-warning alert-dismissible'; break;
        case 4: clase = 'alert alert-danger alert-dismissible'; break;
    }
    return clase;
}

function RecuperarTipoAlerta(valor) {
    var clase = ''
    switch (valor) {
        case 1: clase = 'success'; break;
        case 2: clase = 'info'; break;
        case 3: clase = 'warning'; break;
        case 4: clase = 'danger'; break;
    }
    return clase;
}

function tipoFont(valor) {
    var clase = '';
    switch (valor) {
        case 1:
        case 2:
            clase = "<i class='fa fa-info-circle fa-2x'></i>"; break;
        case 3:
        case 4:
            clase = "<i class='fa fa-exclamation-triangle fa-2x'></i>"; break;
    }
    return clase;
}

var jqMensaje = function (mensaje, callback) {
    var opciones = {
        message: mensaje,
        title: "<i class='fa fa-exclamation-triangle'></i> Confirmar acción...!"
    };

    opciones.buttons = {
        confirm: {
            label: '<i class="fa fa-check"></i> Si',
            className: 'btn-info',
            callback: function (result) {
                callback(true);
            }
        },
        cancel: {
            label: '<i class="fa fa-times"></i> No',
            className: 'btn-default',
            callback: function (result) {
                callback(false);
            }
        }
    };
    bootbox.dialog(opciones);
}

///Este es para las alertas....
var jqAlertas = function (titulo, mensaje, tipoClase, controlDiv) {

    var clase = RecuperarClaseAlerta(tipoClase);
    var font = tipoFont(tipoClase);
    var control = $(controlDiv);
    var divMensaje = "<div class='" + clase + "' role='alert'>";
    divMensaje += " <button type='button' class='close' data-dismiss='alert' aria-label='Close'>";
    divMensaje += "  <span aria-hidden='true'>&times;</span>";
    divMensaje += " </button>";
    divMensaje += font + " <strong>" + titulo + "</strong><br/>" + mensaje;
    divMensaje += " </div>";
    control.empty();
    control.hide().html(divMensaje.toString()).fadeIn(2000).delay(4000).fadeOut("slow");
    //return divMensaje;
}

///Este es para las notificaciones....
var jqGrowl = function (titulo, mensaje, tipo) {

    var clase = RecuperarTipoAlerta(tipo);
    var font = tipoFont(tipo);
    mensaje = font + "<strong> " + titulo + " </strong><br/>" + mensaje;

    $.bootstrapGrowl(mensaje, { type: clase, width: 'auto', delay: 5000 });
}