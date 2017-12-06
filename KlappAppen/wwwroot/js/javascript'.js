$(document).ready(function () {
    $.ajax({
        url: "/home/MainContent",
        type: "GET",
        success: function (jsonArr) {
            createTable(jsonArr);
            deletePerson ();
            addPerson();
        }
    });
});

function createTable(jsonArr) {
    let result = JSON.parse(jsonArr);
    $("#table_list").append('<div class="div_tr_th"><div class="div_th">Namn</div><div class="div_th">Present</div><div class="div_th">Pris</div></div>');
    $("#table_list").append('<div class="div_tr"><div class="div_td"><input id="textboxName" type="text"/></div><div class="div_td"><input id="textboxGift" type="text"/></div><div class="div_td"><input id="textboxPrice" type="text"/></div><div class="button"><button class="add">Lägg till</button></div></div>');
    for (let i = 0; i < result.lenght; i++) {
        let html = '<div class="div_tr"><div class="div_td">' + result[i].Name + '</div><div class="div_td">' + result[i].Gift + '</div><div class="div_td">' + result[i].Price
    }
};




       <i class="fa fa-edit"></i> Edit</button><button class="delete" value="' + result[i].Id + '"><i class="fa fa-trash-o"></i> Delete</button></td></tr>';
        $("#myTable").append(html);
    }
};

