// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />

//agregamos controlador de evento
var Page_IsValid = true;
var execute = false;

Sys.Application.add_load(AppLoad);

//se carga la aplicacion agregarmos los manejadores
function AppLoad() {
      Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
      Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);

      $(document).ready(function() {
          InitializeForm();
      });
}
//ajax comienza el procesamiento
function BeginRequest(sender, args) {
    //desabilitar todos los botones de envio
    $('input[type=submit]').attr('disabled', false);
}


//ajax finaliza el procesamiento
function EndRequest(sender, args) {
   //habilitarlos todos los botones de envio
    $('input[type=submit]').attr('disabled', true);
    InitializeForm();
}


//controla cuando el usuario da clic en el tab superior
//desencadenamos un evento en el servidor
function clientActiveTabChanged(sender, args) {
    __doPostBack(sender.get_id(), sender.get_activeTabIndex());
    
}            


function InitializeForm() {
    
    //establecemos los campos selectores sobre fondo
    $('#EntryForm .Get20,.Get40,.Get60,.Get80,.Get100,.GetMultiline,.GetDate,.GetCombo,.GetInt,.GetFloat2Decimal,.GetFloat4Decimal,.GetMoneyCordoba,.GetMoneyDollar').focus(function() {
        $(this).parents('li').addClass("OverFieldForEdit");
    }).blur(function() {
        $(this).parents('li').removeClass("OverFieldForEdit");
    });

       
    //configuramos el tooltip para los mensajes
    $('#EntryForm img').cluetip({ splitTitle: '|', width: 250, delayedClose: 1200, cursor: 'pointer', sticky: false });
    $('.navigationTop a').cluetip({ splitTitle: '|', width: 250, delayedClose: 1200, cursor: 'pointer', sticky: false });
    //tooltip para el link del mapa
    $('.SiteMapa span a').cluetip({ splitTitle: '|', width: 250, delayedClose: 1200, cursor: 'pointer', sticky: false });
    $('.thickbox').cluetip({ splitTitle: '|', delayedClose: 1200, width: 150, cursor: 'pointer', sticky: false });
    //tooltip de los buttonfields
    $('input[type=image]').cluetip({ splitTitle: '|', attribute: 'alt', titleAttribute: 'alt', delayedClose: 1200, width: 150, cursor: 'pointer', sticky: false });
    //Este es el menu inferior oculto.
    $('#MenuLinkNew a').cluetip({ splitTitle: '|',delayedClose: 1200, width: 250, cursor: 'pointer', sticky: false });


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

 
 
  //Metodo usado por el gridview jerarquico estilo arbol
  function fnChangeImage(ClientId,TableId)
     {
			if (document.getElementById(ClientId).getAttribute("src").indexOf("Plus.png") !=-1)
			{
				document.getElementById(ClientId).setAttribute("src","../Images/Minus.png");
			}
			else
			{
				document.getElementById(ClientId).setAttribute("src","../Images/Plus.png");
			}
			
			var aa = document.getElementById(TableId).style;
			if(aa.display=="none") aa.display="block";
			else aa.display="none";
			
			return false;
}


function SetConfirmation(buttonId, message, causesValidation) {
    //desvincular al dar click
    //necesario si es un update panel
    $("#" + buttonId)
        .unbind('click')
        .click(function(e) {
            //obtenemos el target
            var target = $(e.target);

            //chequea si el boton es buton o un link
            if (target.attr("href")) {
                callback = function() { execute = true; window.location.href = target.attr("href"); };
            }
            else {
                callback = function() { execute = true; target.click(); };
            }

            //registrar el popup y el callback
            if (!causesValidation || Page_IsValid)
                confirmPopup(message, callback);

            //si se ejecuto es verdadero llamar al callback
            var result = execute;
            execute = false;
            return result;
        });
}
function confirmPopup(message, callbackYes) {
    $('#confirm').modal({
        close: false,
        overlayId: 'confirmModalOverlay',
        containerId: 'confirmModalContainer',
        onShow: function(dialog) {
            dialog.data.find('.message').append(message);

            // el usuario dio clic en si
            dialog.data.find('.yes').click(function() {
                // call the callback
                if ($.isFunction(callbackYes)) {
                    callbackYes.apply();
                }
                // cerrar la ventana de dialogo
                $.modal.close();
            });
            window.focus();
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