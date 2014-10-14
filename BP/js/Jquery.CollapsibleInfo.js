/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />
var Page_IsValid = true;
var execute = false;

//Realizado por Francisco Javier Areas Rios
//simula al collapsible panel del ajaxtoolkit
//pero se utiliza jquery
//para lograrlo utilizamos el metodo toggle de jquery y un poco de css con attr
$(document).ready(function() {
    $("div.InfoContainerPanel > div.InfocollapsePanelHeader > div.InfoArrowExpand").toggle(
      
       function() {
                    $(this).parent().next("div.InfoContent").hide("fast");
                    $(this).attr("class", "InfoArrowExpand");
                },
                
       function() {
                $(this).parent().next("div.InfoContent").show("fast");
                $(this).attr("class", "InfoArrowClose");
                });
     });

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
                callback = function() { execute = true;  window.location.href = target.attr("href"); };
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
                 // callback de la funcion
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
           