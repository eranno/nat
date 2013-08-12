var montharray = new Array("ינואר", "פברואר", "מרץ", "אפריל", "מאי", "יוני", "יולי", "אוגוסט", "ספטמבר", "אוקטובר", "נובמבר", "דצמבר");
var serverdate = new Date();

function $(id) {
    return document.getElementById(id);
}
function padlength(what) {
    var output = (what.toString().length == 1) ? "0" + what : what;
    return output;
}
function displaytime() {
    serverdate.setSeconds(serverdate.getSeconds() + 1);
    var datestring = padlength(serverdate.getDate()) + " " + montharray[serverdate.getMonth()] + " " + serverdate.getFullYear() + ",";
    var timestring = padlength(serverdate.getHours()) + ":" + padlength(serverdate.getMinutes()) + ":" + padlength(serverdate.getSeconds());
    $("time").innerHTML = datestring + " " + timestring;
}

window.onload = function () { displaytime(); };             //first
window.setInterval(function () { displaytime(); }, 1000);   //interval

