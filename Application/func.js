
function $(id) {
    return document.getElementById(id);
}
function toggle(id) {
    if ($("toggle_" + id).style.display == 'block') {
        $("toggle_" + id).style.display = 'none';
        return;
    }
    for (i = 1; i <= 4; i++)
        $("toggle_" + i).style.display = 'none';
    $("toggle_" + id).style.display = 'block';

    //var e = $("toggle_"+id);
    //e.style.display = e.style.display == 'block' ? 'none' : 'block';
}

function search_opt() {
    var n = $("js_select").value;
    $("opt" + (3 - n)).style.display = 'none';
    $("opt" + (n)).style.display = 'block';
}

//window.onload = function () {};

document.addEventListener('DOMContentLoaded', function () {
    $("js_toggle_1").addEventListener('click', function () {
        toggle(1);
    });
    $("js_toggle_2").addEventListener('click', function () {
        toggle(2);
    });
    $("js_toggle_3").addEventListener('click', function () {
        toggle(3);
    });
    $("js_toggle_4").addEventListener('click', function () {
        toggle(4);
    });

    $("js_select").addEventListener('change', function () {
        search_opt();
    });
});