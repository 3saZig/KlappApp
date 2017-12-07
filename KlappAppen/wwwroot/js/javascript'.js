$(document).ready(function () {
    $.ajax({
        url: "/home/GetAll", //kolla vad metoden heter imon
        type: "GET",
        success: function (jsonArr) {
            createTable(jsonArr);
            deletePerson();
            addPerson();
        }
    });
});

//listan med edit/delete
function createTable(jsonArr) {
    let result = JSON.parse(jsonArr);
    $("#table_list").append('<div class="div_tr_th"><div class="div_th">Namn</div><div class="div_th">Present</div><div class="div_th">Pris</div></div>');
    for (let i = 0; i < result.lenght; i++) {
        let html = '<div class="div_tr"><div class="div_td">' + result[i].Name + '</div><div class="div_td">' + result[i].Gift + '</div><div class="div_td">' + result[i].Price
            + '<div class="div_td"><button class="edit" value="' + result[i].id + '">Edit</button><button class="delete" value="' + result[i].Id + '"></div><div class="div_td">Delete</button></div></div>';
        $("#table_list").append(html);
    }
    //Addknappen 
    $("#table_list").append('<div class="div_tr"><div id="td_button_add"><button class="button_add">Lägg till</button></div></div>');
};

function addPerson() {
    $("#button_add").click(function () {
        $("#table_list").append('<div class="div_tr"><div class="div_td"><input id="textboxName" type="text" /></div> <div class="div_td"><input id="textboxGift" type="text" /></div> <div class="div_td"><input id="textboxPrice" type="text" /></div><button class="button_confirm_add">Lägg till</button></div></div>');
    }     
)};

function confirmAddPerson() {
    $("#button_confirm_add").click(function () {
        $.ajax({
            url: "/home/ConfirmAddPerson",
            data: { "": $("#textboxName").val(), "": $("#textboxGift").val(), "": $("#textboxPrice").val },
            type: "GET",
            success: function (result) {
                confirmAddPerson(); //är detta rätt???
                let html = '<div class="div_tr"><div class="div_td">' + result[i].Name + '</div><div class="div_td">' + result[i].Gift + '</div><div class="div_td">' + result[i].Price
                    + '<div class="div_td"><button class="edit" value="' + result[i].id + '">Edit</button><button class="delete" value="' + result[i].Id + '"></div><div class="div_td">Delete</button></div></div>',
                $("#table_list").append(html),
            };

        });
    });
};

function deletePerson() {
    $(".delete").click(function () {
        var id = $(this).val();
        $.ajax({
            url: "home/deletePerson" + id, //why id??
            type: "GET",
            success: function (jsonArr) {
                $("#table_list").empty();
                createTable(jsonArr);
                deletePerson();
            }
        });
    });
};





