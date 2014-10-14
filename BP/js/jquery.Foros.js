/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />

//agregamos controlador de evento
var Page_IsValid = true;
var execute = false;

Sys.Application.add_load(AppLoad);
function updated(args) {
    tb_remove();
    var btn = $find('<%= btnRefreshCosto.ClientID %>');
    __doPostBack('Refrescame', "1");
}
function cancelupdated() {
    tb_remove();
}
//se carga la aplicacion agregarmos los manejadores
function AppLoad(sender, args) {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);

    if (args.get_isPartialLoad()) {
        tb_init('.thickbox');
    }

    $(document).ready(function() {
        InitializeForm();
    });
    
}
//ajax comienza el procesamiento
function BeginRequest(sender, args) { }
//ajax finaliza el procesamiento
function EndRequest(sender, args) { InitializeForm(); }

function InitializeForm() {
    //establecemos los campos selectores sobre fondo
    $('#EntryForm .Get20,.GetForo,.Get40,.Get60,.Get80,.Get100,.GetMultiline,.GetDate,.GetCombo,.GetInt,.GetFloat2Decimal,.GetFloat4Decimal,.GetMoneyCordoba,.GetMoneyDollar').focus(function() {
        $(this).parents('li').addClass("OverFieldForEdit");
    }).blur(function() {
        $(this).parents('li').removeClass("OverFieldForEdit");
    });
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


