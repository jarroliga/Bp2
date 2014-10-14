/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />
//ing.francisco javier areas rios.

//Configuracion de la ventana de mensajes de alertas
$(document).ready(function() {
    $('#msgnotifchat').notificationmsg();
    $("#msgnotifchat").draggable();
    $('#closebutton').click(function() { $('#msgnotifchat').notificationmsg('hide'); });
     SetLogon();
    //Establece el tiempo que estara chequeando en segundo plano
    //si hay o no mensajes para el usuario
    window.setInterval(function() { CheckForMessage($('#msgnotifchat')); }, 20000);
});


//Funcion encargada de verificar si hay mensajes disponibles para el usuario
function CheckForMessage(e) {
    $.ajax({
        type: "POST",
        url: "Default.aspx/HasMessage",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg) {
            //Si el usuario tiene mensajes notificarle.
            if (msg.d == "1") {
                var animStyle = 'slide'
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/GetMessages",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg, status) {
                        $("#notif01").html(msg.d.Username);      
                        $("#notif02").html(msg.d.Nombre);
                        $("#notif03").html(msg.d.Institucion);
                        $("#modalok1").attr('href', msg.d.UrlOk + "&responde=1" );
                        $("#modalok2").attr('href', msg.d.UrlCancel + "&responde=0");
                        $('#msgnotifchat').notificationmsg({ animation: animStyle });
                        $('#msgnotifchat').notificationmsg('show');
                    },
                    error: function(xhr, msg, e) {
                        $.growlUI('Error en Notificacion', msg.message); 
                    }
                });
            } //fin if
        }, //fin function sucess
       error: function(xhr, msg, e) { $.growlUI('Error en Ajax Chequeando Buz&oacute;n', msg); }
    });
}
     
  
 //Esta funcion es encargada de cambiar el titulo del login y logout
//usamos ajax dado que no es un control de servidor y no estan habilitados los servicios ajax de seguridad
//debido a que el seguridad es propietaria.
function SetLogon() 
{
    $.ajax({
        type: "POST",
        url: "Default.aspx/IsLogeado",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg) {
            //Si el usuario tiene mensajes notificarle.
        if (msg.d == "1") 
            {
                $("#menutop03").text("LogOut");
            }
            else 
            {
                $("#menutop03").text("LogIn");
            } //fin if
        }, //fin function sucess
        error: function(xhr, msg, e) { $.growlUI('Error al autentificar usuario', msg); }
    }); 
}   