/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />

$(document).ready(function() {
    $('#EntryForm img').cluetip({ splitTitle: '|', width: 250, cursor: 'pointer', sticky: false });
   
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