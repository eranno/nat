

function $(id) {
    return document.getElementById(id);
}
function toggle(id, t) {
    if (t == 0) {

        //create selection
        var select = document.createElement('select');
        select.id = "typeInput" + id;
        var option0 = document.createElement('option'); select.appendChild(option0); option0.value = "0"; option0.innerText = "";
        var option1 = document.createElement('option'); select.appendChild(option1); option1.value = "1"; option1.innerText = "sick";
        var option2 = document.createElement('option'); select.appendChild(option2); option2.value = "2"; option2.innerText = "vacation";
        var option3 = document.createElement('option'); select.appendChild(option3); option3.value = "3"; option3.innerText = "fast";
        var option4 = document.createElement('option'); select.appendChild(option4); option4.value = "4"; option4.innerText = "job";

        //mark selection
        switch ($("type" + id).innerText) {
            case "":            option0.setAttribute("selected", "selected"); break;
            case "sick":        option1.setAttribute("selected", "selected"); break;
            case "vacation":    option2.setAttribute("selected", "selected"); break;
            case "fast":        option3.setAttribute("selected", "selected"); break;
            case "job":         option4.setAttribute("selected", "selected"); break;
        }

        $("type" + id).innerHTML = "";   //clear
        $("type" + id).appendChild(select);
        select.focus();

        select.addEventListener('blur', function () {
            id = this.id.substr(9);
            var text = "";
            switch ($("typeInput" + id).value) {
                case "0": text = "";            break;
                case "1": text = "sick";        break;
                case "2": text = "vacation";    break;
                case "3": text = "fast";        break;
                case "4": text = "job";         break;
            }
            $("type" + id).innerHTML = text;

            //update on db
            ajax(location.search.substr(1), (id+1), text, 0);

            //make it clickable again
            el_type[id].addEventListener('click', function () {
                toggle(this.id.substr(4), 0);
                this.removeEventListener('click', arguments.callee);
            });

        });


    //note
    } else {

        var input = document.createElement('input');
        input.value = $("note" + id).innerText;
        input.id = "noteInput" + id;
        $("note" + id).innerHTML = "";   //clear
        $("note" + id).appendChild(input);
        input.focus();

        input.addEventListener('blur', function () {
            id = this.id.substr(9)
            $("note" + id).innerHTML = $("noteInput" + id).value;

            ajax(location.search.substr(1), (id + 1), $("note" + id).innerHTML, 1);

            //make it clickable again
            el_note[id].addEventListener('click', function () {
                toggle(this.id.substr(4), 0);
                this.removeEventListener('click', arguments.callee);
            });
        });

    }
}



var xmlHttpRequest;
function ajax(qry,day,reason,type) {
    //create XMLHttpRequest object
    xmlHttpRequest = (window.XMLHttpRequest) ?
    new XMLHttpRequest() : new ActiveXObject("Msxml2.XMLHTTP");

    //If the browser doesn't support Ajax, exit now
    if (xmlHttpRequest == null)
        return;

    //Initiate the XMLHttpRequest object
    xmlHttpRequest.open("GET", "update.aspx?"+qry+"&day="+day+"&txt="+reason+"&type="+type, true);

    //Setup the callback function
    xmlHttpRequest.onreadystatechange = StateChange;

    //Send the Ajax request to the server with the GET data
    xmlHttpRequest.send(null);
}
function StateChange() {
    if (xmlHttpRequest.readyState == 4) {
        //document.getElementById('lblTime').value = xmlHttpRequest.responseText;
    }
}


document.addEventListener('DOMContentLoaded', function () {

    //block admins
    if (getQueryString("id") != "")
        return;

    //block all but this month and past month
    if (getQueryString("year") != "" && getQueryString("month") != "") {
        var date = new Date(getQueryString("year"), (getQueryString("month")-1), 1, 1, 1, 1, 1);
        var now = new Date();

        //this month
        if (!(date.getFullYear() == now.getFullYear() && date.getMonth() == now.getMonth())) {

            //past month
            var month = date.getMonth();
            var year = date.getFullYear();
            month++;
            if (month == 12) {
                month = 0;
                year++;
            }
            
            if (!(now.getFullYear() == year && now.getMonth() == month))
                return;
        }
    }


    el_type = document.getElementsByClassName('type');
    el_note = document.getElementsByClassName('note');
    for (var i = 0; i < el_type.length; i++) {

        //type
        el_type[i].addEventListener('click', function () {
            toggle(this.id.substr(4), 0);
            this.removeEventListener('click', arguments.callee);
        });

        //note
        el_note[i].addEventListener('click', function () {

            //force type (reason) first
            if ($("type" + this.id.substr(4)).innerText == "") {
                alert("חובה לבחור סיבה לפני תיאור הנימוק!");
            } else {
                toggle(this.id.substr(4), 1);
                this.removeEventListener('click', arguments.callee);
            }
        });
    }
});


//get querystring paramters
function getQueryString(name) {
    var qry = location.search.substr(1);
    if (typeof qry !== undefined && qry !== "") {
        var keyValueArray = qry.split("&");
        for (var i = 0; i < keyValueArray.length; i++) {
            if (keyValueArray[i].indexOf(name) > -1) {
                return keyValueArray[i].split("=")[1];
            }
        }
    }
    return "";
}