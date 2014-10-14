/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />

//abrir una ventana centrada
function openCentered (url, windowName, width, height, featureString)
{
  if (!windowName) windowName = '';
  
  if (!featureString)
    featureString = '';
  else
    featureString = ',' + featureString;
  
  var x = Math.round((screen.availWidth - width) / 2);
  var y = Math.round((screen.availHeight - height) / 2);
  featureString = 'left=' + x + ',top=' + y + ',width=' + width + ',height=' + height + featureString;
  
  return open (url, windowName, featureString);
}

//abrir ventana maximizada
function openMaximised(url, windowName, featureString)
{
	var w = screen.width;
	var h = screen.height;
	var winHandle;
	
	if (!windowName) windowName = '';
	if (!featureString) featureString = '';
	
    featureString = 'screenX=0,screenY=0,left=0,top=0,width=' + w + ',height=' + h + ',' + featureString;
	
	winHandle = open(url, windowName, featureString);
	
	winHandle.moveTo(0, 0);
	winHandle.resizeTo(window.screen.availWidth, window.screen.availHeight)
	
//	return winHandle;
}

//abrir la ventana minimizada
function openMinimised(url, windowName)
{
	var winHandle;
	
	if (!windowName) windowName = '';
	
    featureString = 'screenX=0,screenY=0,left=0,top=0,width=0,height=0';
	
	open(url, windowName, featureString);
}

function hideControl(obj)
{
    var el = document.getElementById(obj);
    el.style.display = 'none';
}

function showControl(obj) 
{
	var el = document.getElementById(obj);
	el.style.display = '';
}

//ventana
function modalWin(url) {
    var features = "";
    if (window.screen) {
        var myLeft = (screen.width - 600) / 2;
        var myTop = (screen.height - 400) / 2;
        features = ',left=' + myLeft + ',top=' + myTop;
    }
    if (window.showModalDialog) {
        var win = window.showModalDialog(url, "name", "dialogWidth:600px;dialogHeight:400px;" + features);
        //win.focus();
    }
    else {
        var win = window.open(url, 'name', 'height=600,width=400,toolbar=no,directories=no,status=no,linemenubar=no,scrollbars=no,resizable=no ,modal=yes,' + features);
        //win.focus(); 
    }
} 