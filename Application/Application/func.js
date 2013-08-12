
function $(id) {
    return document.getElementById(id);
}
function toggle() {
    var e = $("js_toggle").childNodes[3];
    e.style.display = e.style.display == 'block' ? 'none' : 'block';
}

//window.onload = function () {};

document.addEventListener('DOMContentLoaded', function () {
    $("js_toggle").childNodes[1].addEventListener('click', function () {
        toggle();
    });
});