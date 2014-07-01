function getQueryStringByName(name) {
    var result = window.location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
}

function isNumber(s) {
    if (!isNaN(s)) {
        return true;
    }
    else {
        return false;
    }
}

function isFloat(s) {
    var regu = "^([0-9]*\.?[0-9]*)|(0\.[0-9]*[1-9])$";
    var re = new RegExp(regu);
    var result = re.test(s);
    return !result;
}