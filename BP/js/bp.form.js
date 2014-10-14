// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />

Sys.Application.add_load(AppLoad);

//se carga la aplicacion agregarmos los manejadores
function AppLoad(sender, args) {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
}
//ajax comienza el procesamiento
function BeginRequest(sender, args) {
    $('input[type=submit]').attr('disabled', true);
}
//ajax finaliza el procesamiento
//function EndRequest(sender, args) {
    //$('input[type=submit]').attr('disabled', false);
    //InitializeForm();
//}