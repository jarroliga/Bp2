/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />

//Codigo Utilizado para cualquier elemento EntitytyEdit
//agregamos controlador de evento
Sys.Application.add_load(AppLoad);

function AppLoad() {
    if (!Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack()) {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
    }

//Jquery esta listo
$(document).ready(function() {
    InitializeForm();
});

}

//ajax comienza el procesamiento
function BeginRequest(sender, args) {
    var mensaje = "<h1><img src='../App_Themes/Clasico/Images/busy.gif'/>Espere por favor</h1><p>Se esta procesando la informacion,espere un momento </p>";
    $.blockUI({ message: mensaje });
}

//ajax finaliza el procesamiento,desbloqueo el div de procesamiento AJAX
function EndRequest(sender, args) {
    $.unblockUI();
}



//inicializamos los elementos del formulario de captura
function InitializeForm() {

    //establecemos los campos selectores sobre fondo
    $('#EntryForm .Get20,.Get40,.Get60,.Get80,.Get100,.GetDate,.GetCombo,.GetInt,.GetFloat2Decimal,.GetFloat4Decimal,.GetMoneyCordoba,.GetMoneyDollar,.GetMultiline').focus(function() {
        $(this).parents('li').addClass("OverFieldForEdit");
    }).blur(function() {
        $(this).parents('li').removeClass("OverFieldForEdit");
    });

    //configuramos el tooltip para los mensajes
    $('img').cluetip({ splitTitle: '|', width: 250, cursor: 'pointer', sticky: false });
    $('.SiteMapa a').cluetip({ splitTitle: '|', width: 250, cursor: 'pointer', sticky: false });

    //configuramos la captura de fecha para todos los controles que tenga la clase getfecha.
    $('#EntryForm .GetDate').datepick({ showOn: 'both', buttonImageOnly: true, buttonImage: '../Images/calendar.png' });

    //configuramos la captura de datos numericos
    $("#EntryForm .GetInt").format({ precision: 0, allow_negative: false, autofix: true });
    $("#EntryForm .GetFloat2Decimal").format({ precision: 2, allow_negative: false, decimal: '.', autofix: true });
    $("#EntryForm .GetFloat4Decimal").format({ precision: 4, allow_negative: false, decimal: '.', autofix: true });
    $("#EntryForm .GetMoneyCordoba").format({ precision: 2, allow_negative: false, decimal: '.', autofix: true });
    $("#EntryForm .GetMoneyDollar").format({ precision: 2, allow_negative: false, decimal: '.', autofix: true });

    //captura de email
    $("#EntryForm .GetEmail").format({ type: "email" });

    //capturar solo letras
    $("#EntryForm .GetOnlyLetter").format({ type: "alphabet", autofix: true });

    //funcion que al perder el foco formatea los numero
    $("#EntryForm .GetMoneyDollar,.GetFloat2Decimal,GetMoneyCordoba").blur(function() {
        var num = this.value;
        var valor = num.toString().replace(/\$|\,/g, '');
        if (!isNaN(valor)) {
            this.value = numberFormat(valor);
        }
    });

}

function numberFormat(num, symbol) {
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' +
	num.substring(num.length - (4 * i + 3));
    if (symbol != null)
        return (((sign) ? '' : '-') + '$' + num + '.' + cents);
    else
        return (((sign) ? '' : '-') + num + '.' + cents);
}