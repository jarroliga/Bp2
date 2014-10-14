/* Treeview */
treeNode = function(id, text, leaf, checkbox, loadFunction) {
    this.text = text;
    this.id = id;
    this.checkbox = checkbox;
    this.leaf = leaf;
    this.loadFunction = loadFunction;
}

function addNode(n, nh) {
    var cn = document.createElement('div');
    cn.style.display = "block";
    cn.className = 'node';
    cn.id = nh.id;

    var html = "";
    if (nh.leaf == false)
        if (nh.loadFunction != null)
        html = '<img src="/BPS/images/plus.gif" class="nimg" alt="+" onclick="' + nh.loadFunction + '(this.parentNode.id);"/>';
    else
        html = '<img src="/BPS/images/plus.gif" class="nimg" alt="+" onclick="toggleNodeByImg(this);"/>';
    else
        html = '<img src="/BPS/images/empty.gif"/>';

    if (nh.checkbox == true) {
        if (nh.leaf == true) {
            if (nh.checked == true)
                html = html + '<input type="checkbox" checked="checked" alt="leaf" onclick="checkChildNodes(this.parentNode);"/>&nbsp;';
            else
                html = html + '<input type="checkbox" alt="leaf" onclick="checkChildNodes(this.parentNode);"/>&nbsp;';
        } else {
            if (nh.checked == true)
                html = html + '<input type="checkbox" checked="checked" onclick="checkChildNodes(this.parentNode);"/>&nbsp;';
            else
                html = html + '<input type="checkbox" onclick="checkChildNodes(this.parentNode);"/>&nbsp;';
        }
    }

    html = html + nh.text;
    cn.innerHTML = html;
    n.appendChild(cn);
}

function addChildNode(n, nh) {
    var cn = getChildContainer(n.childNodes);
    if (cn == null) {
        cn = document.createElement('div');
        cn.style.display = "none";
        cn.className = 'childContainer';
        n.appendChild(cn);
    }
    addNode(cn, nh);
}

function getChildContainer(children) {
    for (var i = 0; i < children.length; i++) {
        if (children[i].className == "childContainer") {
            return (children[i]);
            break;
        }
    }
    return (null);
}

function getNodeImg(n) {
    for (var j = 0; j < n.childNodes.length; j++) {
        if (n.childNodes[j].nodeName.toUpperCase() == 'IMG') {
            var img = n.childNodes[j];
            return (img);
            break;
        }
    }
}

function toggleNodeByImg(img) {
    var obj = img.parentNode;
    var objChildren = getChildContainer(obj.childNodes);
    if (objChildren.style.display == "none" || objChildren.style.display == "")
        objChildren.style.display = "block";
    else
        objChildren.style.display = "none";

    if (img.alt == '+') {
        img.alt = '-';
        img.src = '/BPS/images/minus.gif';
    } else {
        img.alt = '+';
        img.src = '/BPS/images/plus.gif';
    }
}

function toggleNode(n) {
    var img = getNodeImg(n);
    if (img != null)
        toggleNodeByImg(img);
}

function setNodeImg(n, src) {
    var img = getNodeImg(n);
    if (img != null)
        img.src = src;
}

var ids = '';
function getCheckedNodes(tv) {
    ids = '';
    getCheckedNodesIds(tv);

    if (ids != '')
        ids = ids.substr(0, ids.length - 1);

    return (ids);
}

function getCheckedNodesIds(tv) {
    for (var i = 0; i < tv.childNodes.length; i++) {
        if (tv.childNodes[i].className == 'node') {
            var n = tv.childNodes[i];

            for (var j = 0; j < n.childNodes.length; j++) {
                if (n.childNodes[j].nodeName.toUpperCase() == 'INPUT') {
                    var check = n.childNodes[j];
                    if (check.checked && check.alt == 'leaf') {
                        ids = ids + n.id + ',';
                    }
                }
            }
            getCheckedNodesIds(n);
        } else {
            if (tv.childNodes[i].className == 'childContainer') {
                getCheckedNodesIds(tv.childNodes[i]);
            }
        }
    }
}

function checkChildNodes(nd) {
    var st = false;

    for (var j = 0; j < nd.childNodes.length; j++) {
        if (nd.childNodes[j].nodeName.toUpperCase() == 'INPUT') {
            st = nd.childNodes[j].checked;
            checkChildNodesRec(nd, st);
            break;
        }
    }
}

function checkChildNodesRec(tv, status) {
    for (var i = 0; i < tv.childNodes.length; i++) {
        if (tv.childNodes[i].className == 'node') {
            var n = tv.childNodes[i];

            for (var j = 0; j < n.childNodes.length; j++) {
                if (n.childNodes[j].nodeName.toUpperCase() == 'INPUT') {
                    var check = n.childNodes[j];
                    check.checked = status;
                }
            }
            checkChildNodesRec(n, status);
        } else {
            if (tv.childNodes[i].className == 'childContainer') {
                checkChildNodesRec(tv.childNodes[i], status);
            }
        }
    }
}

function getNodeChildrenCount(n) {
    var cc = getChildContainer(n.childNodes);
    if (cc != null)
        return (getNodeChildrenCount(cc));

    var c = 0;
    for (var j = 0; j < n.childNodes.length; j++) {
        if (n.childNodes[j].className == 'node')
            c++;
    }
    return (c);
}

function checkNode(n) {
    var img = getNodeImg(n);
    if (img != null)
        img.checked = true;
}

//Ejm: ss = getParentNode(getParentNode($get("UM")));
function getParentNode(n) {
    if (n.parentNode.parentNode != null)
        return n.parentNode.parentNode;
}
