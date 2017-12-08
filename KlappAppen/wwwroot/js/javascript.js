$(document).ready(function () {
    $.ajax({
        url: "/home/GetListJavaScript",
        type: "GET",
        success: function (jsonArr) {
            createTable(jsonArr);
            addPerson();
        }
    });
});

//listan med edit/delete
function createTable(jsonArr) {
    let result = JSON.parse(jsonArr);

    $("#table_list").html(""); //tömmer listan
    $("#table_list").append('<div class="div_tr_th"><div class="div_th">Namn</div><div class="div_th">Present</div><div class="div_th">Pris</div></div>');
    for (let i = 0; i < result.length; i++) {
        var itemId = result[i].Id;
        let html = '<div class="div_tr_person"><div id="div_td_receiver' + itemId + '">' + result[i].Receiver + '</div><div id="div_td_gift' + itemId + '">' + result[i].Name + '</div><div id="div_td_price' + itemId +'">' + result[i].Price + '</div>'
            + '<div class="div_td"><button class="edit" value="' + result[i].Id + '">Ändra</button></div><div class="div_td"><button class="delete" value="' + result[i].Id + '">Radera</button></div></div>';
        $("#table_list").append(html);
    }
    deletePerson();
    editPerson();
    addPerson();
    //Addknappen 
    $("#table_list").append('<div class="div_tr"><div id="td_button_add"><button class="button_add">Lägg till</button></div></div>');
};

function addPerson() {
    $(".button_add").click(function () {
      
        $(this).hide();
        var html = '<div><input id="input_receiver" type="text"/><input id="input_gift" type="text"/><input id="input_price" type="number"/><button class="button_savePerson">Spara</button></div>';
		$("#table_list").append(html);
		savePerson();
    }
    )
};

function deletePerson() {
    $(".delete").click(function () {
        var id = $(this).val();
        //alert(id);
        $.ajax({
            url: "/home/DeletePersonJavascript/",
            data: { "id": id },
            type: "GET",
            success: function (jsonArr) {
                $("#table_list").empty();
                createTable(jsonArr);
            }
        });
    });
};

function editPerson() {
    $(".edit").click(function () {
        $(this).hide();
        $(".delete").hide();
        var id = $(this).val();
        var html = '<div><input id="input_receiver" type="text" value="' + $("#div_td_receiver" + id).text() + '"/><input id="input_gift" type="text" value="' + $("#div_td_gift" + id).text() + '"/><input id="input_price" type="number" value="' + $("#div_td_price" + id).text() +'"/><button class="button_save">Spara</button></div>';
        $("#table_list").append(html);
        saveChanges(id);        
    });
};

function saveChanges(id) {
    $(".button_save").click(function () {
        $.ajax({
            url: "/home/SaveChangesJavascript/",
            data: { "id": id, "receiver": $("#input_receiver").val(), "gift": $("#input_gift").val(), "price": $("#input_price").val() },

            type: "POST",
            success: function (jsonArr) {
                var jsonparse = JSON.parse(jsonArr);
                createTable(jsonparse);
            }
        })

    })
};

function savePerson() {
	$(".button_savePerson").click(function () {
		$.ajax({
			url: "/home/AddPersonJavaScript/",
			data: { "receiver": $("#input_receiver").val(), "gift": $("#input_gift").val(), "price": $("#input_price").val() },

			type: "POST",
			success: function (jsonArr) {
				var jsonparse = JSON.parse(jsonArr);
				createTable(jsonparse);
			}
		})

	})
};

function addBudget() {
	$("#submitknapp").click(function () {
		$(this).hide();
		$.ajax({
			url: "/home/AddBudgetJavaScript/",
			data: { "total": $("#budgetInputTextbox").val() },
			type: "POST",
			success: function (jsonArr) {
				var jsonparse = JSON.parse(jsonArr);
				createChart(jsonparse);
			}
		})
	}
	)
};