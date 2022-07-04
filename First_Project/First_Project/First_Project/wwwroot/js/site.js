// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/*const { get } = require("jquery");
*/
/*const { error } = require("jquery");*/

// Write your JavaScript code.
$('tr').dblclick(function () {
    remove_esti_id();
    remove_app_date_id();
    var id = $(this).attr('data-item-id');
    if (id % 1 == 0) {

        window.open("/ES_YDENPYO1/Edit/" + id, "_self");
    }
});
var btn_create = document.getElementById("btn_create")
if (btn_create) {
    $('#btn_create').click(function () {
        var id = $("#denpyono").val();
        var parent_id = $("#id_es1").val();
        if (id % 1 == 0) {
            window.open("/ES_YDENPYOD/Create?parent_id=" + parent_id, "_self");
        }
    });
}

$('tr').dblclick(function () {
    var id = $(this).attr('id');
    var parent_id = $("#id_es1").val();
    if (id % 1 == 0) {
        window.open("/ES_YDENPYOD/Create?id=" + id + "&parent_id=" + parent_id, "_self");
    }
});


$("#back_index").click(function () {
    delete_cookie();
})

function remove_app_date_f() {
    $("#app_date_f").removeClass("hide-date")
}

function remove_app_date_t() {
    $("#app_date_t").removeClass("hide-date")
}

function remove_doc_date_f() {
    $("#doc_date_f").removeClass("hide-date")
}

function remove_doc_date_t() {
    $("#doc_date_t").removeClass("hide-date")
}

function remove_esti_id() {
    $("#esti_id").removeClass("hide-date")
}

function remove_esti_id() {
    $("#esti_id").removeClass("hide-date")
}

function remove_app_date_id() {
    $("#app_date_id").removeClass("hide-date")
}

function remove_planned_date_id() {
    $("#planned_date_id").removeClass("hide-date")
}


function loadfromto() {
    var required_doc_id = document.getElementById("required_doc_id");
    var required_doc_date = document.getElementById("required_doc_date");
    var required_app_date = document.getElementById("required_app_date");

    if ($("#doc_id_from").val() && $("#doc_id_to").val() && (parseFloat(($("#doc_id_from")).val()) > parseFloat(($("#doc_id_to").val())))) {
        required_doc_id.textContent = "ID sau phải lớn hơn ID trước";
    }
    if ($("#doc_date_from").val() && $("#doc_date_to").val() && ($("#doc_date_from").val() > $("#doc_date_to").val())) {
        required_doc_date.textContent = "Ngày sau phải lớn hơn ngày trước";
    }
    var app_date_from = document.getElementById("app_date_from").value;
    var app_date_to = document.getElementById("app_date_to").value;
    if (app_date_from && app_date_to && (app_date_from > app_date_to)) {
        required_app_date.textContent = "Ngày tháng năm sau phải lớn hơn";
    }

}

function validate() {

    var required_vali_purpose = document.getElementById("required_vali_purpose");
    var required_vali_depart = document.getElementById("required_vali_depart");
    var required_vali_app = document.getElementById("required_vali_app");
    var required_vali_method = document.getElementById("required_vali_method");
    var required_vali_esti = document.getElementById("required_vali_esti");



    var cash_method = $("#cash_method").val();
    var esti_date = $("#esti_date").val();
    var app_date = $("#app_date").val();
    var ticket_depart_code = $("#ticket_depart_code").val();
    var purpose_trip = $("#purpose_trip").val();
    var msg_title = document.getElementById("msg_title");
    var msg_title_2 = document.getElementById("msg_title_2");
    var msg_name = document.getElementById("msg_name");


    if (!app_date) {
        required_vali_app.textContent = "Yêu cầu chọn";
    }
    else {
        required_vali_app.textContent = " ";
    }
    if (!esti_date) {
        required_vali_esti.textContent = "Yêu cầu chọn";
    }
    else {
        required_vali_esti.textContent = " ";
    }
    if (!cash_method) {
        required_vali_method.textContent = "Yêu cầu chọn";
    }
    else {
        required_vali_method.textContent = " ";
    }
    if (!purpose_trip) {
        required_vali_purpose.textContent = "Yêu cầu nhập";
    }
    else {
        required_vali_purpose.textContent = " ";
    }
    if (!ticket_depart_code) {
        required_vali_depart.textContent = "Yêu cầu nhập";
    }
    else {
        if (!/^[0-9]+$/.test(ticket_depart_code)) {
            required_vali_depart.textContent = "Chỉ nhập số";
            msg_title.textContent = "Cập nhật dữ liệu không thành công.";
            msg_name.textContent = "";
            msg_title_2.textContent = "Dữ liệu bị sai hoặc thiếu."
            return false;
        } else {
            required_vali_depart.textContent = "";
        }

    }



    if (!ticket_depart_code || !purpose_trip || !app_date || !esti_date || !cash_method) {
        msg_title.textContent = "Cập nhật dữ liệu không thành công.";
        msg_name.textContent = "";
        msg_title_2.textContent = "Dữ liệu bị sai hoặc thiếu."
        return false;
    }
    else {
        msg_title.textContent = "Cập nhật dữ liệu thành công";

        msg_title_2.textContent = " ";
        return true;
    }
}

function Validtion_planned() {
    var required_vali_planned_date = document.getElementById("required_vali_planned_date");
    var required_vali_planned_point = document.getElementById("required_vali_planned_point");
    var required_vali_planned_desti = document.getElementById("required_vali_planned_desti");
    var required_vali_planned_course = document.getElementById("required_vali_planned_course");
    var required_vali_planned_amount = document.getElementById("required_vali_planned_amount");

    var planned_date = $("#planned_date").val();
    var planned_point = $("#planned_point").val();
    var planned_desti = $("#planned_desti").val();
    var planned_course = $("#planned_course").val();
    var planned_amount = $("#planned_amount").val();

    if (!planned_date) {
        required_vali_planned_date.textContent = "Yêu cầu chọn";
    }
    else {
        required_vali_planned_date.textContent = " ";
    }
    if (!planned_point) {
        required_vali_planned_point.textContent = "Yêu cầu nhập";
    }
    else {
        required_vali_planned_point.textContent = " ";
    }
    if (!planned_desti) {
        required_vali_planned_desti.textContent = "Yêu cầu nhập";
    }
    else {
        required_vali_planned_desti.textContent = " ";
    }
    if (!planned_course) {
        required_vali_planned_course.textContent = "Yêu cầu nhập";
    }
    else {
        required_vali_planned_course.textContent = " ";
    }
    if (!planned_amount) {
        required_vali_planned_amount.textContent = "Yêu cầu nhập";
    }
    else {
        if (!/^[0-9]+$/.test(planned_amount)) {
            required_vali_planned_amount.textContent = "Chỉ nhập số";
            return false;
        } else {
            required_vali_planned_amount.textContent = "";
        }

    }
    if (!planned_date || !planned_point || !planned_desti || !planned_course || !planned_amount) {
        return false;
    }
    return true;
}

function Validate_popup() {
    var search_popup = document.getElementById("search_popup");
    var search_string_popup = $("#search_string_popup").val();
    var search_id_popup = $("#search_id_popup").val();
    var required_search_string_popup = document.getElementById("required_search_string_popup")
    var required_search_id_popup = document.getElementById("required_search_id_popup")


    if (!search_id_popup) {
        required_search_id_popup.textContent = "Yêu cầu nhập";
    }
    else {
        required_search_id_popup.textContent = " ";
    }

    if (!search_string_popup) {
        required_search_string_popup.textContent = "Yêu cầu nhập";
    }
    else {
        required_search_string_popup.textContent = " ";
    }


}

// Get the modal
var modal = document.getElementById("myModal");
var modal_edit = document.getElementById("myModal_edit");
var modal_delete = document.getElementById('myModal_delete');
var modal_delete_msg = document.getElementById("myModal_delete_msg");
var myModal_delete_cookie = document.getElementById('myModal_delete_cookie');

// Get the button that opens the modal
var btn = document.getElementById("btn-success");
var btn_edit = document.getElementById("btn-success_edit");
var btn_delete = document.getElementById('btn-delete');


// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
if (btn) {
    btn.onclick = function (e) {
        modal.style.display = "block";
        e.preventDefault();
    }
}
// When the user clicks the button, open the modal 


// When the user clicks on <span> (x), close the modal
if (span) {
    span.onclick = function () {
        modal.style.display = "none";

    }
}


// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}


if (btn) {
    $("#btn-success").click(async function (e) {
        var cre_new_id = document.getElementById("cre_new_id").value;
        var x = document.getElementById("sum_all_money").innerText;
        e.preventDefault();
        modal.style.display = "block";
        if (!validate()) {
            return;
        }
        else {
            var data = $("#form_create").serialize();
            
            await $.ajax({
                type: "POST",
                url: "/ES_YDENPYO1/Create",
                data: data,
                success: function () {
                }
            })
            var data = {};
            var sum = parseInt(getCookie("sum"));
            for (let i = 0; i <= sum; i++) {
                let data_table = JSON.parse(getCookie("table" + i));
               
                if (data_table[7].name != "ischecked") {
                    data_table[8].value = cre_new_id;
                    data_table[0].value = cre_new_id;

                    
                    $(data_table).each(function (index, obj) {
                        data[obj.name] = obj.value;
                    });                   
                        $("#id_es1").val(cre_new_id);
                         $.ajax({
                            url: "/ES_YDENPYOD/Create",
                            type: 'post',
                            data: data,
                            success: function () {

                            }
                        });
                        
                }
                $.ajax({
                    url: "/ES_YDENPYO1/Setsum?id=" + data_table[0].value + "&ss=" + x,
                    type: 'get',
                    success: function () {
                    }
                });
                
            } 
             delete_cookie();
        }

    });


    $("#Shut").click(function () {
        if (!validate()) {
            modal.style.display = "none";
        } else {
            modal.style.display = "none";
           
            window.open("Create", "_self")
        }
    });
}


if (btn_edit) {
    $("#btn-success_edit").click(function (e) {
        e.preventDefault();
        var data = {};
        var cre_new_id = document.getElementById("cre_new_id").value;
        var x = document.getElementById("sum_all_money").innerText;
        var sum = parseInt(getCookie("sum"));
        for (let i = 0; i <= sum; i++) {
            let data_table = JSON.parse(getCookie("table" + i));
            console.log(data_table);
           
            if (data_table[7].name == "ischecked" && data_table[5].value != 0) {
                
                $(data_table).each(function (index, obj) {
                    data[obj.name] = obj.value;
                });
                $.ajax({
                    url: "/ES_YDENPYO1/Edit2",
                    type: 'post',
                    data: data,
                    success: function () {
                    }
                });
            }
            $.ajax({
                url: "/ES_YDENPYO1/Setsum?id=" + data_table[0].value + "&ss=" + x,
                type: 'get',
                success: function () {
                }
            });
        } 
       
        
       
        modal_edit.style.display = "block";

        var data = {};
        var sum = parseInt(getCookie("sum"));
        for (let i = 0; i <= sum; i++) {
            let data_table = JSON.parse(getCookie("table" + i));
            console.log(data_table);
            if (data_table[7].name != "ischecked") {
                $(data_table).each(function (index, obj) {
                    data[obj.name] = obj.value;
                });
                $.ajax({
                    url: "/ES_YDENPYOD/Create",
                    type: 'post',
                    data: data,
                    success: function () {

                    }
                });
             
            }
        }

    })
    
    $("#Shut_edit").click(function () {
        var data = $("#form_create").serialize();
        var id = $('tr').attr("id");
        var dataarr = $("#form_create").serializeArray();
       
        console.log(dataarr);
        $.ajax({
            type: "POST",
            url: "/ES_YDENPYO1/Edit/" + id,
            data: data,
            success: function (response) {
                modal_edit.style.display = "none";
               
            }
        })        
       
        delete_cookie();
        window.open("/", "_self")
    })
}

if (btn_delete) {
    $("#btn-delete").click(function (e) {
        e.preventDefault();
        modal_delete.style.display = "block";
    })

    $("#btn-dialog-delete").click(function () {
        modal_delete.style.display = "none";
        modal_delete_msg.style.display = "block";

        var data = $("#delete_form").serialize();
        var id = $('tr').attr("id");
        $.ajax({
            type: "POST",
            url: "/ES_YDENPYO1/Delete/" + id,
            data: data,
            success: function () {

            }
        })
    })
    $("#Shut_delete_msg").click(function () {
        window.open("/ES_YDENPYO1", "_self")
    })
    $("#btn-dialog-cancel").click(function () {
        modal_delete.style.display = "none";
    })
}

var popup_form = document.getElementById("popup_form");
var open_popup_depart = document.getElementById("open_popup_depart");
var open_popup_esti = document.getElementById("open_popup_esti");
var open_popup_annual = document.getElementById("open_popup_annual");
var btn_popup = document.getElementById("search_popup");
var close_fill_popup = document.getElementById("close_fill_popup");
var radio_popup = document.getElementById("radio_popup");
var ticket_depart_code = document.getElementById("ticket_depart_code")
var ticket_depart_name = document.getElementById("ticket_depart_name")

var btn_dialog_delete_cookie = document.getElementById("btn_dialog_delete_cookie");
var btn_dialog_cancel_delcookie = document.getElementById("btn_dialog_cancel_delcookie");
if (open_popup_depart) {
    $("#open_popup_depart").click(function (e) {
        e.preventDefault();
        popup_form.style.display = "block";
    })
}

function closeForm() {
    popup_form.style.display = "none";
}

if (btn_popup) {
    $("#search_popup").click(function (e) {
        e.preventDefault();
        var search_string_popup = $("#search_string_popup").val();
        var search_id_popup = $("#search_id_popup").val();
        $.ajax({
            type: "GET",
            url: "/ES_YDENPYO1/Create?search_string_popup=" + search_string_popup + "&search_id_popup=" + search_id_popup,
            contentType: "html",
            success: function (data) {
                if (data) {
                    $(data).find("#Data_Search").each(function (loop, item) {
                        document.getElementById("Data_Search").innerHTML = $(item).html();
                    });
                }
            }
        });

    });
}

if (close_fill_popup) {
    $("#close_fill_popup").click(function (e) {

        var id = $('input[name = "fav_language"]:checked').attr("id");
        if (id % 1 == 0) {
            $("#ticket_depart_code").val(id);
            $("#ticket_depart_name").val(document.getElementById("item+" + id).innerText);
            popup_form.style.display = "none";
        } else {
            alert("Cần phải chọn");
        }
    });
}

if (ticket_depart_code) {
    $("#ticket_depart_code").on("keyup paste", function (e) {
        var search_id_popup = $("#ticket_depart_code").val();

        $.ajax({
            type: "GET",
            url: "/ES_YDENPYO1/GetName?id=" + search_id_popup,
            success: function (data) {
                if (data) {
                    $("#ticket_depart_name").val(data).innerText;
                }
            },
            error: function (error) {
                $("#ticket_depart_name").val(" ").innerText;
            }
        });
    });
}


/*COOKIE*/
var es_ydenpyod5 = document.getElementById("es_ydenpyod5")
function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";

}

function getCookie(cname) {
    let name = cname + "=";
    let ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return null;
}

function delete_cookie() {
    document.cookie.split(";").forEach(function (c) {
        document.cookie = c.replace(/^ +/, "").replace(/=.*/, "=;expires=" + new Date().toUTCString() + ";path=/");
    });
}

function loadTable() {
    var sum = parseInt(getCookie("sum"));
    //them moi
    for (var i = 0; i <= sum; i++) {
        var data = JSON.parse(getCookie("table" + i));
        console.log(data);
        if (data[0].value == $("#id_es1").val()) {
            var data_table = '';
            data_table += '<tr id =' + data[5].value + ' parent_id =' + data[0].value + ' > ';
            data_table += '<td>' + '</td>';
            data_table += '<td>' + data[1].value + '</td>';
            data_table += '<td>' + data[2].value + '</td>';
            data_table += '<td>' + data[3].value + '</td>';
            data_table += '<td>' + data[4].value + '</td>';
            data_table += '<td>' + data[6].value + '</td>';
            data_table += '<tr>';
            document.getElementById("es_ydenpyod5").innerHTML += data_table;
            console.log("AAAAAAa")

        }
    }
    // doi mau

    for (var i = 0; i <= sum; i++) {
        var data = JSON.parse(getCookie("table" + i));
        console.log("table" + i)
        console.log($("#id_es1").val());
       
            $('#' + data[5].value).remove();
            var data_table = '';
            data_table += '<tr id =' + data[5].value + ' parent_id =' + data[0].value + '"' + ' data=' + "table" + i + ' > ';
            data_table += '<td>' + '</td>';
            data_table += '<td>' + data[1].value + '</td>';
            data_table += '<td>' + data[2].value + '</td>';
            data_table += '<td>' + data[3].value + '</td>';
            data_table += '<td>' + data[4].value + '</td>';
            data_table += '<td>' + data[6].value + '</td>';
            data_table += '<tr>';
            document.getElementById("es_ydenpyod5").innerHTML += data_table;
            console.log("aaaaaaaaaaaaaaaaaaa")
            if (data[7].name == "ischecked") {

                $('#' + data[5].value).css("background-color", "#ced4da");
            } else {
                $('#' + data[5].value).css("background-color", "white");
            }
        

    }
    
    document.getElementById("sum_all_money").innerText = sum_money();

    $('tr').dblclick(function () {
        var id = $(this).attr('id');
        var data = $(this).attr('data');
        var parent_id = $("#id_es1").val();
        if (id != 0) {
            window.open("/ES_YDENPYOD/Create?id=" + id, "_self");
        } else if (data) {
            window.open("/ES_YDENPYOD/Create?id=" + id + "&parent_id=" + parent_id + '&data=' + data, "_self");
        }
    });

}

function load_data() {
    var url = document.location.href;
    var data1 = url.split('=')[3];
    console.log(data1);

    var data = JSON.parse(getCookie(data1));
    if (data) {
        $("#planned_date").val(data[1].value);
        $("#planned_point").val(data[2].value);
        $("#planned_desti").val(data[3].value);
        $("#planned_course").val(data[4].value);
        $("#planned_amount").val(data[6].value);
    }
}


$(function () {
    $('div[onload]').trigger('onload');
});


var btn_planed_regis = document.getElementById("btn_planed_regis");
if (btn_planed_regis) {
    $("#btn_planed_regis").click(function (e) {
        e.preventDefault();
        var name1;
        if (!Validtion_planned()) {
            return;
        }
        var url = document.location.href;
        var data1 = url.split('=')[3];
        if (data1) {
            var dt = $(this).closest('form').serializeArray();
            if (dt[7].name == "ischecked") {
                myModal_delete_cookie.style.display = "block";
                return;
            }            
            setCookie(data1, JSON.stringify($("#form_create_planned").serializeArray()), 1);
            history.go(-1);
            return;
        }
        var dt = $(this).closest('form').serializeArray();
        if (dt[7].name == "ischecked") {
            myModal_delete_cookie.style.display = "block";
            document.getElementById("gyono_dialog").textContent += $("#id_gyono").val();
            return;
        }
        if (getCookie("sum") === null) {
            name1 = 0;
        } else {
            name1 = parseInt(getCookie("sum"));
            name1++;
        }
        setCookie("table" + name1, JSON.stringify($("#form_create_planned").serializeArray()), 1);
        setCookie("sum", name1, 1);
        console.log(parseInt(getCookie("sum")));
        history.go(-1);
    });

}

if (btn_dialog_cancel_delcookie) {
    $("#btn_dialog_cancel_delcookie").click(function () {
        myModal_delete_cookie.style.display = "none";
    })
}

if (btn_dialog_delete_cookie) {
    $("#btn_dialog_delete_cookie").click(function () {
        var url = document.location.href;
        var data1 = url.split('=')[3];
        if (data1) {          
            setCookie(data1, JSON.stringify($("#form_create_planned").serializeArray()), 1);
            history.go(-1);
            return;
        }
        if (getCookie("sum") === null) {
            name1 = 0;
        } else {
            name1 = parseInt(getCookie("sum"));
            name1++;
        }
        setCookie("table" + name1, JSON.stringify($("#form_create_planned").serializeArray()), 1);
        setCookie("sum", name1, 1)
        console.log(parseInt(getCookie("sum")));
        history.go(-1);

    })
}

function sum_money() {
    var sum_all_money = document.getElementById("sum_all_money").innerText;    
    var sum = parseInt(getCookie("sum"));
    var sum_cookie = 0;
    for (var i = 0; i <= sum; i++) {
        var data = JSON.parse(getCookie("table" + i));       
        var data1 = JSON.parse(getCookie("table" + i + 1));
        if (data1) {
            if (data[5].value == data1[5].value) {
                continue;
            }
        }
        sum_cookie += parseFloat(data[6].value);     
    }
    return sum_cookie + parseFloat(sum_all_money);
}
