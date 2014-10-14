function $(obj) { return document.getElementById(obj); }
/*toggle the toolbar*/
function togToolbar(toolId, DivId) {
    var myDiv = document.getElementById(DivId);
    if (myDiv != null) {
        var tools = myDiv.getElementsByTagName("input");

        for (i = 0; i < tools.length; i++)
            if (tools[i].id != toolId)
            tools[i].className = "button";
        else
            tools[i].className = "pressed";
    }
}
$(function() {
    $(".accordion").accordion({ header:"h3",active:false,alwaysOpen:false,animated:false});
});
/* DHTML date validation script. Courtesy of SmartWebby.com (http://www.smartwebby.com/dhtml/)*/
// Declaring valid date character, minimum year and maximum year

var dtCh= "/";
var minYear=1900;
var maxYear=2100;

function validateDateField(e) {
    var date = e.value;
    if (!isDate(date)) {
        //e.style.backgroundColor = "#ECC0C0";
        e.value = '';
    }
    else {
        e.style.backgroundColor = "";
    }
}
function setEditionModeDate(e) {
    e.style.backgroundColor = "#FDF6D2";
    e.select();
}
function validateNumberField(e) {
    var num = e.value;
    var valor = num.toString().replace(/\$|\,/g, '');
    if (!isNumber(valor)) {
        e.style.backgroundColor = "#ECC0C0";
        //e.style.border = "#F1CA7F solid 2px";
    } else {
        e.value = formatCurrency(valor);
        e.style.backgroundColor = "";
        //e.style.border = "";
    }
}
function validatePercentField(e) {
    var num = e.value;
    var valor = num.toString().replace(/\$|\,/g, '');
    if (!isNumber(valor)) {
        e.style.backgroundColor = "#ECC0C0";
        //e.style.border = "#F1CA7F solid 2px";
    }
    else {
        if (parseFloat(num) > 100) {
            window.alert('No puede digitar más del 100%');
            e.value = 100;
            valor = "100.00";
        }
        e.value = formatCurrency(valor);
        e.style.backgroundColor = "";
    }
}
function readOnlyNumbers(e) {
    var unicode = e.charCode ? e.charCode : e.keyCode
    if (unicode != 8) { //if the key isn't the backspace key (which we should allow)
        if (unicode < 46 || unicode > 57 || unicode == 47) //if not a number
            return false //disable key press
    }
}
function setEditionModeNumber(e) {
    e.style.backgroundColor = "#FDF6D2";
    //e.style.border = "#F1CA7F solid 2px";
    if (isNumber(e.value))
        e.value = formatCurrency(e.value);
    e.select();
}
function setEditionMode(e) {
    e.style.backgroundColor = "#FDF6D2";
    //e.style.border = "#F1CA7F solid 2px";
    //e.select();
}
function setBlurMode(e) {
    e.style.backgroundColor = "";
    //e.style.border = "";
    //e.select();
}
function isInteger(s){
	var i;
    for (i = 0; i < s.length; i++){   
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}
function isNumber(s){
	var i;
    for (i = 0; i < s.length; i++){   
        // Check that current character is number.
        var c = s.charAt(i);
        if (c == ".") return true;
        if (c == "-") return true;
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}
function stripCharsInBag(s, bag){
	var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++){   
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}
function daysInFebruary (year){
	// February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28 );
}
function DaysArray(n) {
	for (var i = 1; i <= n; i++) {
		this[i] = 31
		if (i==4 || i==6 || i==9 || i==11) {this[i] = 30}
		if (i==2) {this[i] = 29}
   } 
   return this
}
function addDaysToDate(d,dtStr){
    var unMinuto = 60 * 1000;
    var unaHora = unMinuto * 60;
    var unDia = unaHora * 24;

	var pos1=dtStr.indexOf(dtCh)
	var pos2=dtStr.indexOf(dtCh,pos1+1)
	var strDay=dtStr.substring(0,pos1)
	var strMonth=dtStr.substring(pos1+1,pos2)
	var strYear=dtStr.substring(pos2+1)
	strYr=strYear
	if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	for (var i = 1; i <= 3; i++) {
		if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	}
	month=parseInt(strMonth)
	day=parseInt(strDay)
	year=parseInt(strYr)

    var oldDate = new Date();

    oldDate.setFullYear(year,month-1,day);
    oldDate.setTime(oldDate.getTime() + unDia * d);
    
    var dia = oldDate.getDate();
    var mes = oldDate.getMonth()+1;
    var anio = oldDate.getFullYear();
    
    if (dia<10){
        dia = "0" + dia;
    }
    if (mes<10){
        mes = "0" + mes;
    }
    
    var fechatext = "" + dia + "/" + mes + "/" + anio + ""; 
    return(fechatext);
}

function isDate(dtStr){	
	var daysInMonth = DaysArray(12)
	var pos1=dtStr.indexOf(dtCh)
	var pos2=dtStr.indexOf(dtCh,pos1+1)
	var strDay=dtStr.substring(0,pos1)
	var strMonth=dtStr.substring(pos1+1,pos2)
	var strYear=dtStr.substring(pos2+1)
	strYr=strYear
	if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	for (var i = 1; i <= 3; i++) {
		if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	}
	month=parseInt(strMonth)
	day=parseInt(strDay)
	year=parseInt(strYr)
	if (pos1==-1 || pos2==-1){
//		alert("El formato de fecha debe ser: dd/mm/yyyy.")
		return false
	}
	if (strMonth.length<1 || month<1 || month>12){
//		alert("Por favor ingrese un mes valido.")
		return false
	}
	if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month]){
//		alert("Por favor ingrese un dia valido.")
		return false
	}
	if (strYear.length != 4 || year==0 || year<minYear || year>maxYear){
//		alert("Por favor ingrese un anio de 4 digitos entre " + minYear + " y " + maxYear + ".")
		return false
	}
	if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false){
//		alert("Por favor ingrese una fecha valida.")
		return false
	}
return true
}
function getFecha(){
    var fecha = new Date();
    var dia = fecha.getDate();
    var mes = fecha.getMonth()+1;
    var anio = fecha.getFullYear();
    
    if (dia<10){
        dia = "0" + dia;
    }
    if (mes<10){
        mes = "0" + mes;
    }
    var fechatext = "" + dia + "/" + mes + "/" + anio + ""; 
//            alert(fechatext);
    return fechatext;
}
function getNumber(num) {
    return num.toString().replace(/\$|\,/g,'');
}
function formatCurrency(num, symbol) {
	num = num.toString().replace(/\$|\,/g,'');
	if(isNaN(num))
	num = "0";
	sign = (num == (num = Math.abs(num)));
	num = Math.floor(num*100+0.50000000001);
	cents = num%100;
	num = Math.floor(num/100).toString();
	if(cents<10)
	cents = "0" + cents;
	for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
	num = num.substring(0,num.length-(4*i+3))+','+
	num.substring(num.length-(4*i+3));
	if (symbol != null)
		return (((sign)?'':'-') + '$' + num + '.' + cents);
	else
		return (((sign)?'':'-') + num + '.' + cents);
}
function formatInt(num) {
	num = num.toString().replace(/\$|\,/g,'');
	if(isNaN(num))
	num = "0";
	sign = (num == (num = Math.abs(num)));
	num = Math.floor(num*100+0.50000000001);
	cents = num%100;
	num = Math.floor(num/100).toString();
	if(cents<10)
	cents = "0" + cents;
	for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
	num = num.substring(0,num.length-(4*i+3))+','+
	num.substring(num.length-(4*i+3));
	
	return (((sign)?'':'-') + num);
}
function validateIntField(e) {    
    var num = e.value;
    var valor = num.toString().replace(/\$|\,/g,'');
    if (!isInteger(valor)) {
        e.style.backgroundColor = "#ECC0C0";
        e.title = "Dato inválido. Por favor ingrese un número entero.";        
        $("tt2001").style.visibility = "visible";
    } else {
        e.value = formatInt(valor);
        e.title = "";
        e.style.backgroundColor = "#FFFFFF";
    }    
}
function setEditionModeInt(e) {    
    e.style.backgroundColor = "#FDF6D2";
    if (isInteger(e.value))
        e.value = formatInt(e.value);      
    e.select();    
}
function clearList(list) {
    var lst = $(list);

    var i;
    for (i = lst.options.length - 1; i >= 0; i--) {
        lst.remove(i);
    }
}