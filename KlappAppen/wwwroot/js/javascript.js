var gifts;
var BudgetIdFromSelect;
var budgetAmount;

$(document).ready(function () {
    let myBudget;
    let jsonArr = {};
    //addPerson();
    let budgetListId = getBudgetList(jsonArr);
    //createTable(jsonArr, budgetListId);
    addBudget(jsonArr);

    $("#button_index").click(function () {
        listOfGifts();
    });


});


//=================================================================================================
//KLAPPLISTAN
//=================================================================================================

// Listan med gifts
function listOfGifts() {
    BudgetIdFromSelect = $("#chooseBudget").val();

    let BudgetUrl = "/Home/GetListOfGifts/" + BudgetIdFromSelect;

    $.get(BudgetUrl).
        done(function (data) {
            createTable(data);
        })

}

//listan med edit/delete
function createTable(jsonArr) {
    let result = JSON.parse(jsonArr)

    $("#table_list").html(""); //tömmer listan
    $("#table_list").append('<div class="div_tr_th"><div class="div_th">Namn</div><div class="div_th">Present</div><div class="div_th">Pris</div><div class="div_th"></div><div class="div_th"></div></div>');
    for (let i = 0; i < result.length; i++) {
        var itemId = result[i].Id;
        let html = '<div class="div_tr"><div class=div_td id="div_td_receiver' + itemId + '">' + result[i].Receiver + '</div><div class=div_td id="div_td_gift' + itemId + '">' + result[i].Name + '</div><div class=div_td id="div_td_price' + itemId + '">' + result[i].Price + '</div>'
            + '<div class="div_td"><button class="edit" value="' + result[i].Id + '">Ändra</button></div><div class="div_td"><button class="delete" value="' + result[i].Id + '">Radera</button></div></div>';
        $("#table_list").append(html);
    }
    deletePerson();
    editPerson();
    gifts = SumAllGifts(jsonArr);
    createChart(jsonArr, gifts);
    
    // Addknappen 
    $("#table_list").append('<div class="div_tr"><div id="td_button_add"><button class="button_add">Lägg till</button></div></div>');
    addPerson();
};

function SumAllGifts(jsonArr) {

    let giftPrice = JSON.parse(jsonArr);
    let total = 0;
    for (var i = 0; i < giftPrice.length; i++) {
        total = total + giftPrice[i].Price;
    }
    return total;
};


//! Denna metod behöver modifieras så att den är anpassad efter vald budget. 
//function createSum(jsonArr, gifts) {

//	$.ajax({
//		url: "/home/GetBudget/",
//		type: "GET",
//		success: function (jsonArr) {
//			let budgetJson = JSON.parse(jsonArr);
//			let myBudget = budgetJson[budgetJson.length - 1].Total;
//			let budget = myBudget; //catchLastBudgetPost(jsonArr);
//			//let gifts = SumAllGifts(jsonArr);
//			console.log("createSum: " + budget);
//			//let money = moneyLeft2(jsonArr);
//			let html = '<div class="div_summa">Budget: ' + budget + ' kr</div><div class="div_summa">Summa: ' + gifts + ' kr</div><div class="div_summa">Kvar: ' + (budget - gifts) + ' kr</div>';
//			$("#table_budget").html("");
//			$("#table_budget").append(html);
//		}
//	});
//}



function addPerson() {
    $(".button_add").click(function () {
        $(this).hide();
        var html = '<div class="div_input"><input id="input_receiver" type="text"/><input id="input_gift" type="text"/><input id="input_price" type="number"/><button class="button_savePerson">Spara</button></div>';
        $(html).insertAfter("#table_list");
        savePerson();

    })
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
                createChart(jsonArr, gifts);
            }
        });
    });
};

function editPerson() {
    $(".edit").click(function () {
        $(this).hide();
        $(".delete").hide();
        var id = $(this).val();
        var html = '<div class="div_input"><input id="input_receiver" type="text" value="' + $("#div_td_receiver" + id).text() + '"/><input id="input_gift" type="text" value="' + $("#div_td_gift" + id).text() + '"/><input id="input_price" type="number" value="' + $("#div_td_price" + id).text() + '"/><button class="button_save">Spara</button></div>';
        $(html).insertAfter("#table_list");
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
                createChart(jsonparse, gifts);
            }
        })
    })
};

function savePerson() {
    $(".button_savePerson").click(function () {
        $.ajax({
            url: "/home/AddPersonJavaScript/",
            data: { "receiver": $("#input_receiver").val(), "name": $("#input_gift").val(), "price": $("#input_price").val() },
            type: "POST",
            success: function (jsonArr) {
                createTable(jsonArr);
                createChart(jsonArr, gifts);
            }
        })

    })
};


//=================================================================================================
//SET BUDGET
//=================================================================================================


//plockar ut budgetvärdet från vår drop-down-meny




function addBudget() {
    $("#submitknapp").click(function () {
        $.ajax({
            url: "/home/AddBudgetJavaScript/",
            data: { "total": $("#budgetInputTextbox").val() },
            type: "POST",
            success: function (jsonArr) {
                var jsonparse = JSON.parse(jsonArr);
                // $("#table_list").html(""); //tömmer listan
                createChart(jsonparse, gifts);
            }
        })
    })
};



function getBudgetList(jsonArr) {

    $.ajax({
        url: "/home/GetBudget/",
        type: "GET",
        success: function (jsonArr) {
            let budgetJson = JSON.parse(jsonArr);
            //let budgetArray = [];
            //for (var i = 0; i < budgetJson.length; i++) {
            //	budgetArray = budgetJson[i].Name;
            //}
            //let budgetArrayId = [];
            //for (var i = 0; i < budgetJson.length; i++) {
            //	budgetArrayId = budgetJson[i].Id;
            //}
            for (let i = 0; i < budgetJson.length; i++) {
                var itemId = budgetJson[i].Id;
                var itemName = budgetJson[i].BudgetName;
                let html = '<option value=' + itemId + '>' + itemName + '</option >';
                $("#chooseBudget").append(html);
            }

        }
    });


}

//=================================================================================================
//THE CHART
//=================================================================================================



function createChart(jsonArr, gifts) {
    //let myBudget;
    
    console.log("jsonArr : " + jsonArr);
    console.log("budgetIdFromSelect: " + BudgetIdFromSelect);


    $.ajax({
        url: "/home/BudgetForChart/" + BudgetIdFromSelect,
        type: "GET",
        success: function (budgetAmount) {
            console.log( "budgetAmount: " + budgetAmount);
            let budgetJson = JSON.parse(budgetAmount);

            var ctxa = document.getElementById('doughnut').getContext('2d');

            var doughnutChart = new Chart(ctxa, {
                type: 'doughnut',
                data: {
                    labels: ["total klappar", "pengar kvar"],
                    datasets: [
                        {
                            label: "Chart",
                            data: [gifts, (budgetAmount - gifts)], //(myBudget-gifts), gifts
                            backgroundColor: ["#005B00", "white"],
                            borderColor: "#000000",
                        }
                    ]
                },

                options: {
                    legend: {
                        display: false,
                        cutoutPercentage: 20,
                        responsive: true,
                        maintainAspectRatio: true,
                        animation: {
                            animateScale: true
                        }
                    }
                }

            })

        }
    });



}


//let result = JSON.parse(jsonArr);

            //let myBudget = 0;
            //for (var i = 0; i < budgetJson.length; i++) {
            //    myBudget = myBudget + budgetJson[i].Total; //lägger ihop alla budgetposter till en summa
            //}

//}



//=================================================================================================
//ÄNDRA FÄRG
//=================================================================================================



$("#btn_changeColor").click(function () {
    let RadeoButtonStatusCheck = $('form input[type=radio]:checked').val();
    changeColor(RadeoButtonStatusCheck);
});

function changeColor(backgroundcolor) {
    console.log("backgroundColor");
    switch (backgroundcolor) {
        case 'g':
            $('.backgroundColor').classList.add("green");
            break;
    }

};


//=================================================================================================
//LOGIN
//=================================================================================================



$("#button_logout").click(function () {
    $.ajax({
        url: "/home/logout/",
        type: "POST",
        success: document.location.href = "/account/register"
    })
});


//=================================================================================================
//GRAVEYARD
//=================================================================================================



//function moneyLeft2(myBudget) {
//    let gifts = SumAllGifts(myBudget);
//    let x = catchLastBudgetPost(myBudget);
//    let moneyLeftToSpend = x - gifts;
//    alert(moneyLeftToSpend);

//}


//=================================================================================================
//GRAVEYARD
//=================================================================================================

//1. HITTA DEN VALDA BUDGETEN UR DROP-DOWN-LISTAN

//function GetBudgetIdFromSelect() {

//	let e = document.getElementById("#chooseBudget");
//	let budgetIdFromSelect = e.options[e.selectedIndex].value;
//	console.log(budgetIdFromSelect);
//	return ***BUDGETIDFROMSELECT***;
//};

//2. SKICKA IN DEN BUDGETEN TILL LISTAN
//function createTable(jsonArr, ***BUDGETIDFROMSELECT***) {
//	let result = JSON.parse(jsonArr);

//	$("#table_list").html(""); //tömmer listan
//	$("#table_list").append('<div class="div_tr_th"><div class="div_th">Namn</div><div class="div_th">Present</div><div class="div_th">Pris</div><div class="div_th"></div><div class="div_th"></div></div>');
//	for (let i = 0; i < result.length; i++) {
//		var itemId = result[i].Id;
//		let html = '<div class="div_tr"><div class=div_td id="div_td_receiver' + itemId + '">' + result[i].Receiver + '</div><div class=div_td id="div_td_gift' + itemId + '">' + result[i].Name + '</div><div class=div_td id="div_td_price' + itemId + '">' + result[i].Price + '</div>'
//			+ '<div class="div_td"><button class="edit" value="' + result[i].Id + '">Ändra</button></div><div class="div_td"><button class="delete" value="' + result[i].Id + '">Radera</button></div></div>';
//		$("#table_list").append(html);
//	}
//	deletePerson();
//	editPerson();
//	let gifts = SumAllGifts(jsonArr);
//	createChart(jsonArr, gifts);
//	createSum(jsonArr, gifts);
//	// SumAllGifts(jsonArr);

//	//Addknappen 
//	$("#table_list").append('<div class="div_tr"><div id="td_button_add"><button class="button_add">Lägg till</button></div></div>');
//	addPerson();
//};