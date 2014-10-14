/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />
//Desarrollado por Francisco Javier Areas Rios.
//el codigo javascript hace referencia al DOM, del control de usuario MenuRight.ascx
$(document).ready(function() {

    //opciones menu01
    var winNormal = "600px";
    var winMedium = "800px";
    var winMedium2 = "1000px";
    var winMaximum = "1200px";
    //buscamos una variable oculta, y leemos el valor
    var rootApp = $("[id$='_RootAppWeb']").val();
    rootAppNOJS = '/Web'; //ruta usada en caso javascript no este habilitado
    //Menu Superior
    $("#menutop01").click(function() {
        var pag = 'Welcome.aspx';
        SetIframe(pag, winMaximum + 200);
    });
    $("#menutop03").click(function() {
        var pag = 'Login.aspx';
        SetIframe(pag, winNormal);
    });
    $("#menuanom01").click(function() {
        var pag = 'Anonimo/Iniciativas.aspx';
        SetIframe(pag, winMaximum);
    });

    $("#menuanom02").click(function() {
        var pag = 'Login.aspx';
        SetIframe(pag, winNormal);
    });
    //--MENU0101---------MENU PRINCIPAL------------------------
    //configuramos la direccion de los botones lo que debe cargar.
    $("#menu010101").click(function() {
        var pag = 'Iniciativa/ListIniciativa.aspx';
        SetIframe(pag, winMaximum);
    });
    //nuevo programa
    $("#menu010102").click(function() {
        var pag = 'Programa/NewPrograma.aspx';
        SetIframe(pag, winMedium2);
    });
    //nuevo proyecto
    $("#menu010103").click(function() {
        var pag = 'Proyecto/NewProyecto.aspx?codprograma=0&codcomponente=0&ynvinculado=0';
        SetIframe(pag, winMedium2);
    });
    //Iniciativas en registro
    $("#menu010104").click(function() {
        var pag = 'Iniciativa/RegistroIniciativa.aspx';
        SetIframe(pag, winMedium2);
    });
    //en espera de mas info
    $("#menu010105").click(function() {
        var pag = 'Iniciativa/ReadOnlyIniciativa.aspx?EstadoId=2';
        SetIframe(pag, winMedium2);
    });
    //en verificacion
    $("#menu010106").click(function() {
        var pag = 'Iniciativa/ReadOnlyIniciativa.aspx?EstadoId=3';
        SetIframe(pag, winMedium2);
    });
    //en revision
    $("#menu010107").click(function() {
        var pag = 'Iniciativa/ReadOnlyIniciativa.aspx?EstadoId=4';
        SetIframe(pag, winMedium2);
    });
    //en espera de mas informacion
    $("#menu010108").click(function() {
        var pag = 'Iniciativa/EsperaIniciativa.aspx';
        SetIframe(pag, winMedium2);
    });
    //firma
    $("#menu010109").click(function() {
        var pag = 'Iniciativa/ReadOnlyIniciativa.aspx?EstadoId=7';
        SetIframe(pag, winMedium2);
    });
    //Iniciativas dictaminadas
    $("#menu010110").click(function() {
        var pag = 'Iniciativa/Dictamen.aspx';
        SetIframe(pag, winMedium2);
    });
    //bandeja de entrada de mensajes
    $("#menu010201").click(function() {
        var pag = 'Foro/Inbox.aspx';
        SetIframe(pag, winMedium2);
    });
    //chats online
    $("#menu010202,#menu020302").click(function() {
        var pag = 'Chat/ListChat.aspx';
        SetIframe(pag, winMedium2);
    });
    $("#menu010203").click(function() {
        var pag = 'Seguridad/UsuarioCambiarClave.aspx';
        SetIframe(pag, winNormal);
    });
    $("#menu010301").click(function() {
        var pag = 'Reportes/Panel01.aspx';
        SetIframe(pag, winMaximum);
    });
    //--MENU0201----------------MENU DEL ANALISTA----------------------
    //Todas las iniciativas
    $("#menu020101,#menu020104,#menu020105,#menu020204,#menu020205").click(function() {
        var pag = "";
        var id = $(this).attr("id");
        switch (id) {
            case "menu020101": pag = 'Analista/Iniciativas.aspx?EstadoId=0'; break;
            case "menu020104": pag = 'Analista/Iniciativas.aspx?EstadoId=5'; break;
            case "menu020105": pag = 'Analista/Iniciativas.aspx?EstadoId=6'; break;
            case "menu020204": pag = 'Analista/Iniciativas.aspx?EstadoId=5&ByUser=1'; break;
            case "menu020205": pag = 'Analista/Iniciativas.aspx?EstadoId=6&ByUser=1'; break;
        }

        SetIframe(pag, winMedium);
    });
    //iniciativas en verificacion
    $("#menu020102,#menu020201").click(function() {
        var pag = "";
        var id = $(this).attr("id");
        if (id == "menu020102")
            pag = 'Analista/Verificacion.aspx';
        else
            pag = 'Analista/Verificacion.aspx?ByUser=1'; //solo los del usuario

        SetIframe(pag, winMedium);
    });

    //revision
    $("#menu020103,#menu020202").click(function() {
        var pag = "";
        var id = $(this).attr("id");
        if (id == "menu020103")
            pag = 'Analista/Revision.aspx';
        else
            pag = 'Analista/Revision.aspx?ByUser=1'; //solo los del usuario

        SetIframe(pag, winMedium);
    });

    //en firma
    $("#menu020106,#menu020206").click(function() {
        var pag = "";
        var id = $(this).attr("id");
        if (id == "menu020106")
            pag = 'Analista/Firmas.aspx';
        else
            pag = 'Analista/Firmas.aspx?ByUser=1'; //solo los del usuario

        SetIframe(pag, winMaximum);
    });
    //iniciativas dictaminadas
    $("#menu020108,#menu020208").click(function() {
        var pag = "";
        var id = $(this).attr("id");
        if (id == "menu020108")
            pag = 'Analista/Dictaminadas.aspx';
        else
            pag = 'Analista/Dictaminadas.aspx?ByUser=1';
        SetIframe(pag, winMedium);
    });

    //iniciativas dadas de baja
    $("#menu020109,#menu020209").click(function() {
        var pag = "";
        var id = $(this).attr("id");
        if (id == "menu020109")
            pag = 'Analista/Anuladas.aspx';
        else
            pag = 'Analista/Anuladas.aspx?ByUser=1';
        SetIframe(pag, winMedium);
    });

    //MENSAJES
    $("#menu020301").click(function() {
        var pag = 'Foro/Inbox.aspx';
        SetIframe(pag, winMedium2);
    });

    $("#menu010202,#menu020302").click(function() {
        var pag = 'Chat/ListChat.aspx';
        SetIframe(pag, winMedium2);
    });

    //Reportes
    $("#menu020401").click(function() {
        var pag = 'Reportes/Panel03.aspx';
        SetIframe(pag, winMaximum);
    });

    $("#menuana01").click(function() {
        var pag = 'Reportes/Panel02.aspx';
        SetIframe(pag, winMaximum);
    });

    //--MENU0301---------MENU ADMINISTRADOR------------------------
    $("#menu030101").click(function() {
        var pag = 'Admin/AsignarIniciativa.aspx';
        SetIframe(pag, winMedium);
    });
    $("#menu030102").click(function() {
        var pag = 'Admin/AnularIniciativa.aspx';
        SetIframe(pag, winMedium);
    });
    $("#menu030103").click(function() {
        var pag = 'Admin/EstadoIniciativa.aspx';
        SetIframe(pag, winMedium);
    });

    $("#menu030104").click(function() {
        var pag = 'Admin/SendFirmaIniciativa.aspx';
        SetIframe(pag, winMedium2);
    });

    //--MENU0302---------MENU ADMINISTRADOR CATALOGOS------------------------
    $("#menu030201").click(function() {
        var pag = 'Etapa/ListEtapa.aspx';
        SetIframe(pag, winMedium);
    });

    $("#menu030202").click(function() {
        var pag = 'Proceso/ListProceso.aspx';
        SetIframe(pag, winMedium);
    });


    $("#menu030203").click(function() {
        var pag = 'Tipologia/ListTipologia.aspx';
        SetIframe(pag, winMedium);
    });

    $("#menu030204").click(function() {
        var pag = 'Gasto/ListGasto.aspx';
        SetIframe(pag, winMedium);
    });

    $("#menu030205").click(function() {
        var pag = 'Costo/ListCosto.aspx';
        SetIframe(pag, winMedium);
    });

    $("#menu030206").click(function() {
        var pag = 'EstadoIniciativa/ListEstadoIniciativa.aspx';
        SetIframe(pag, winMedium);
    });

    $("#menu030207").click(function() {
        var pag = 'TipoDictamen/ListTipoDictamen.aspx';
        SetIframe(pag, winMedium);
    });

    //Menu de Seguridad
    $("#menu030301").click(function() {
        var pag = 'Seguridad/Usuarios.aspx';
        SetIframe(pag, winMedium);
    });
    $("#menu030302").click(function() {
        var pag = 'Seguridad/UsuarioRegistroNuevo.aspx';
        SetIframe(pag, winMedium);
    });


    //establecemos el iframe con la pagina y los valores de alto y ancho
    function SetIframe(pagina, ancho) {
        $("#urlshowme").html(rootApp + "/" + pagina);
        var $child = $("#centerdiv").children();
        $child[0].height = ancho;
        if (rootApp == undefined) { rootApp = rootAppNOJS }
        var $page0 = rootApp + '/' + pagina; //pagina correcta
        var $page1 = rootApp + '/' + pagina; //si se produce un error redirigirse aca
        ($child[0].src.toLowerCase().match($page1) != null) ? $child[0].src = $page0 : $child[0].src = $page1;
        // $("#urlshowme").html("Termina Proceso.");
    }

});


