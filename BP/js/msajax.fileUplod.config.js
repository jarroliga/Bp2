/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />

//este archivo es utilizado para realizar la descarga 
//de los documentos al servidor de datos.
//desarrollado por Ing. Francisco Javier Areas Rios.
//en general se utilizo msajax para el manejo de DOM en vez de jquery

var intervalID = 0;
var progressBar;
var fileUpload;
var form;
var token;
var MAXMBFILE = 20; //maximo tamano a del archivo permitido 12 MEGABYTES

function register(form, fileUpload, token) {
    //  registrar el formulario ASP.NET
    this.form = form;
    this.fileUpload = fileUpload;
    this.token = token;
}

function pageLoad() {
    $addHandler($get('upload'), 'click', onUploadClick);
    progressBar = $find('progress');
}

function onUploadClick() {

    
    var valid = fileUpload.value.length > 0;
    if (valid) 
       //chequeamos que la extension sea valida.
       PageMethods.IsDocExtensionOk(fileUpload.value, OnSucceeded, OnFailed);
   else
      onComplete('error', 'Por favor selecciona antes el documento.');

}

//se produce un error al invocar 
function OnFailed(results)
{
    alert(results.get_message());
}

function OnSucceeded(results)
{
    //si la extension de archivo esta permitida
    if (results == false) 
  {
         //  Desabilito el boton de cargar  
        $get('upload').disabled = 'disabled';

        //  actualizar el mensaje
        updateMessage('info', 'Cargando Archivo ...');

        //  enviar el form que contiene el documento
        form.submit();

        // ocultar el marco.
        Sys.UI.DomElement.addCssClass($get('uploadFrame'), 'hidden');

        //  progreso en cero
        progressBar.set_percentage(0);
        progressBar.show();

        intervalID = window.setInterval(function() {
            var request = new Sys.Net.WebRequest();
            request.set_url('UploadProgress.ashx?DJUploadStatus=' + token + '&ts=' + new Date().getTime());
            request.set_httpVerb('GET');
            request.add_completed(function(executor) {

                var e = executor.get_xml().documentElement;
                var empty = e.getAttribute('empty');

                if (!empty) {
                    var percent = e.getAttribute('progress');
                    var file = e.getAttribute('file');
                    var kbs = Math.round(parseInt(e.getAttribute('bytes')) / 1024);
                    var size = Math.round(parseInt(e.getAttribute('size')) / 1024);
                  
                    //  actualizar la barra de progreso a un nuevo valor
                    progressBar.set_percentage(percent);
                    // actualizar mensaje de porcentaje de carga
                    updateMessage('info', 'Cargando ' + file + ' ... ' + kbs + ' de ' + size + ' KB');

                    if (percent == 100) {
                        //  limpiar intervalo
                        window.clearInterval(intervalID);
                    }
                }
            });
            request.invoke();
        }, 500);
    }
 else {
        
        onComplete('error', 'No se puede cargar el documento. La extension del archivo no esta permitida.');
   }
}


function onComplete(type, msg) {
    //  limpiar intervalo de carga
    window.clearInterval(intervalID);
    //  mostrar mensaje
    updateMessage(type, msg);
    //  oculto barra de progreso
    progressBar.hide();
    progressBar.set_percentage('0');
    // rehabilitar boton
    $get('upload').disabled = '';
    // mostrar el marco
    Sys.UI.DomElement.removeCssClass($get('uploadFrame'), 'hidden');
   
}

//se realizo con jquery porque el ajax DOM daba problemas.
function updateMessage(type, value) {
    var status = $get('status');
    //status.innerText = value;
    $("#status").html(value);
    $("#status").addClass(type);
    //  remover todos los estilos
    //status.className = '';
    //Sys.UI.DomElement.addCssClass(status, type);
}

