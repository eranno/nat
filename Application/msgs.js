
function $(id) {
    return document.getElementById(id);
}
function toggle(id) {
    var e = $("toggle_" + id);
    e.style.display = e.style.display == 'table-cell' ? 'none' : 'table-cell';
}


//window.onload = function () {};

document.addEventListener('DOMContentLoaded', function () {
    el = document.getElementsByClassName('title');
    for (var i=0; i<el.length; i++)
    {
        el[i].addEventListener('click', function () {
            toggle( this.id.substr(9) );
        });
    }
});

