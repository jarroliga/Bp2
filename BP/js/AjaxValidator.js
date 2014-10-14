/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />

// Ejecutar la validacion en el servidor
//ing. francisco javier areas rios
function AjaxValidatorEvaluateIsValid(val)
{
    var value = ValidatorGetValue(val.controltovalidate);
    WebForm_DoCallback(val.id, value, AjaxValidatorResult, val, AjaxValidatorError, true); 
    return true;
}


function AjaxValidatorResult(returnValue, context)
{
    if (returnValue == 'True')
        context.isvalid = true;
    else
        context.isvalid = false;
    ValidatorUpdateDisplay(context);
}

// si se produce un error mostrarlo.
function AjaxValidatorError(message)
{
    alert('Error: ' + message);
}