//manejo de Combos y Listboxes
function clearList(list) {
    var lst = $(list);

    var i;
    for (i = lst.options.length - 1; i >= 0; i--) {
        lst.remove(i);
    }
}

function setCboValue(objName, theValue) {
    var cbo = $(objName);

    for (var i = 0; i < cbo.options.length; i++) {
        if (cbo.options[i].value == theValue) {
            cbo.selectedIndex = i;
            return;
        }
    }
}

function setCboText(objName, theText) {
    var cbo = $(objName);

    for (var i = 0; i < cbo.options.length; i++) {
        if (cbo.options[i].text == theText) {
            cbo.selectedIndex = i;
            return;
        }
    }
}

function getCboValue(objName) {
    var cbo = $(objName);

    if (cbo.options.length == 0)
        return ("");
    else
        return (cbo.options[cbo.selectedIndex].value);
}

function getCboText(objName) {
    var cbo = $(objName);

    if (cbo.options.length == 0)
        return ("");
    else
        return (cbo.options[cbo.selectedIndex].text);
}

function addListItem(listName, value, text) {
    var lst = $(listName);

    var myEle = document.createElement("option");
    myEle.setAttribute('value', value);
    var txt = document.createTextNode(text);
    myEle.appendChild(txt)

    lst.appendChild(myEle)
}

function setRadio(radioFld, val) {
    // set 'radioFld' button with value == val and return 'true' (if not disabled!)
    for (var i = 0; i < radioFld.length; i++)
        if (radioFld[i].value == val)
        if (!radioFld[i].disabled) {
        radioFld[i].checked = true;
        return true;
    }
    return false;
}

function getRadio(radioFld) {
    // return value of selected 'radioFld' button
    var st = "";
    for (var i = 0; i < radioFld.length; i++)
        if (radioFld[i].checked) {
        st = radioFld[i].value;
        break;
    }
    return st;
}

function Left(str, n) {
    if (n <= 0)
        return "";
    else if (n > String(str).length)
        return str;
    else
        return String(str).substring(0, n);
}

function Right(str, n) {
    if (n <= 0)
        return "";
    else if (n > String(str).length)
        return str;
    else {
        var iLen = String(str).length;
        return String(str).substring(iLen, iLen - n);
    }
}

function getCurrentDate() {
    var dt = new Date();
    var y = dt.getYear();
    var m = dt.getMonth();
    var d = dt.getDate();

    return Right("00" + d, 2) + "/" + Right("00" + m, 2) + "/" + y;
}

function rand(inferior, superior) {
    numPosibilidades = superior - inferior + 1;
    aleat = Math.random() * numPosibilidades;
    aleat = Math.floor(aleat);
    return parseInt(inferior) + aleat;
}