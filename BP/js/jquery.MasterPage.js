/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />
//Funciones Personalizadas de Jquery
//Francisco Javier Areas
$(document).ready(function() {

// configuracion del acordion jquery UI
$("#accordion").accordion({ header: "h3" });

//expandir el primero
$("#VerColMenu1 > li > a").not(":first").find("+ ul").slideUp("fast");
// expandir o colapsar
$("#VerColMenu1 > li > a").click(function() {
    $(this).find("+ ul").slideToggle("fast");
});

//expandir el segundo menu
$("#VerColMenu2 > li > a").not(":first").find("+ ul").slideUp("fast");
// expandir o colapsar
$("#VerColMenu2 > li > a").click(function() {
    $(this).find("+ ul").slideToggle("fast");
});

//expandir el tercer menu
$("#VerColMenu3 > li > a").not(":first").find("+ ul").slideUp("fast");
// expandir o colapsar
$("#VerColMenu3 > li > a").click(function() {
    $(this).find("+ ul").slideToggle("fast");
});
 

 
});


