/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />
var Page_IsValid = true;
var execute = false;

Sys.Application.add_load(AppLoad);

function AppLoad(sender, args) 
{
  $(document).ready(function() {
    SetItems();
   });
}

//desarrollado por Francisco Areas Rios
//codigo que se aplica a todos los entitylist



 function SetItems() {
     //configuracion del tootip de ayuda
     //tooltip de navegacion superior
     $('.navigationTop a').cluetip({ splitTitle: '|', width: 250, delayedClose: 1200, cursor: 'pointer', sticky: false });
     //tooltip para el link del mapa
     $('.SiteMapa span a').cluetip({ splitTitle: '|', width: 250, delayedClose: 1200, cursor: 'pointer', sticky: false });
     
     $('.tooltip').cluetip({ splitTitle: '|',delayedClose: 1200, width: 150, cursor: 'pointer', sticky: false });
     //tooltip de los buttonfields
     $('input[type=image]').cluetip({ splitTitle: '|', attribute: 'alt', titleAttribute: 'alt',  delayedClose: 1200, width: 150, cursor: 'pointer', sticky: false });
     
     //menu popup
     $('#toplistmenu01').popupmenu({ target: "#PanelNew", time: 300 });
     $('.note').truncate({ max_length: 40, showLinks: false });
   
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
