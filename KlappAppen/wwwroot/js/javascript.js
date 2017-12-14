var gifts;
var BudgetIdFromSelect;
var budgetAmount;

$(document).ready(function () {
    let myBudget;
    let jsonArr = {};
    let budgetListId = getBudgetList(jsonArr);



    $("#button_index").click(function () {
        listOfGifts();
        
    });

    $("#button_setBudget").click(function () {
        addBudget();
    });

    $('#button_myLists').click(function () {
        showMyBudgets();
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
    $("#table_list").append('<div class="div_tr_th"><div class="div_th">Namn</div><div class="div_th">Present</div><div class="div_th">Pris</div><div class="div_th">Ändra</div><div class="div_th">Radera</div></div>');
    for (let i = 0; i < result.length; i++) {
        var itemId = result[i].Id;
        let html = '<div class="div_tr"><div class=div_td id="div_td_receiver' + itemId + '">' + result[i].Receiver + '</div><div class=div_td id="div_td_gift' + itemId + '">' + result[i].Name + '</div><div class=div_td id="div_td_price' + itemId + '">' + result[i].Price + '</div>'
            + '<div class="div_td_person"><button class="edit" value="' + result[i].Id + '"></button></div><div class="div_td_person"><button class="delete" value="' + result[i].Id + '"></button></div></div>';
        $("#table_list").append(html);
    }
    $("#table_list").append('<div class="div_tr"><div id="td_button_add"><button class="button_add">Lägg till</button></div></div>');
    addPerson();
    deletePerson();
    editPerson();
    gifts = SumAllGifts(jsonArr);
    createChart(jsonArr, gifts);

    // Addknappen 
};

function SumAllGifts(jsonArr) {

    let giftPrice = JSON.parse(jsonArr);
    let total = 0;
    for (var i = 0; i < giftPrice.length; i++) {
        total = total + giftPrice[i].Price;
    }
    return total;
};

function addPerson() {
    $(".button_add").click(function () {
        $(this).hide();
        $(".delete").hide();
        $(".edit").hide();
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
                listOfGifts();
                createChart(jsonArr, gifts);
            }
        });
    });
};

function editPerson() {
    $(".edit").click(function () {
        $(".delete").hide();
        $(".edit").hide();
        var id = $(this).val();
        var html = '<div class="div_input"><input id="input_receiver" type="text" value="' + $("#div_td_receiver" + id).text() + '"/><input id="input_gift" type="text" value="' + $("#div_td_gift" + id).text() + '"/><input id="input_price" type="number" value="' + $("#div_td_price" + id).text() + '"/><button class="button_save">Spara</button></div>';
        $(html).insertAfter("#table_list");
        saveChanges(id);
    });
};

function saveChanges(id) {
    $(".button_save").click(function () {
        $(this).hide();
        $("#input_receiver").hide();
        $("#input_gift").hide();
        $("#input_price").hide();
        $.ajax({
            url: "/home/SaveChangesJavascript/",
            data: { "id": id, "receiver": $("#input_receiver").val(), "gift": $("#input_gift").val(), "price": $("#input_price").val() },
            type: "POST",
            success: function (jsonArr) {
                var jsonparse = JSON.parse(jsonArr);
                listOfGifts();
                createChart(jsonparse, gifts);
            }
        })
    })
};

function savePerson() {  
    $(".button_savePerson").click(function () {
        $(this).hide();
        $("#input_receiver").hide();
        $("#input_gift").hide();
        $("#input_price").hide();
        $.ajax({
            url: "/home/AddPersonJavaScript/",
            data: { "receiver": $("#input_receiver").val(), "name": $("#input_gift").val(), "price": $("#input_price").val(), "Id": BudgetIdFromSelect },
            type: "POST",
            success: function (jsonArr) {
                console.log(jsonArr);
                listOfGifts();
            }
        })

    })
};


//=================================================================================================
//SET BUDGET
//=================================================================================================


//plockar ut budgetvärdet från vår drop-down-meny

function addBudget() {

    $.ajax({
        url: "/home/AddBudgetJavaScript/",
        data: { "Total": $("#budgetInputTextbox").val(), "BudgetName": $("#nameInputTextbox").val() },
        type: "POST",
        success: function (jsonArr) {
            var jsonparse = JSON.parse(jsonArr);

        }
    })
};

function getBudgetList(jsonArr) {

    $.ajax({
        url: "/home/GetBudget/",
        type: "GET",
        success: function (jsonArr) {
            let budgetJson = JSON.parse(jsonArr);
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
            console.log("budgetAmount: " + budgetAmount);
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

//=================================================================================================
//MINA SIDOR
//=================================================================================================


//!Visa mina listor i lista
function showMyBudgets() {
    $.ajax({
        url: "/home/GetBudget/",
        type: "GET",
        success: function (jsonArr) {
            alert(jsonArr);

            for (var i = 0; i < jsonArr.length; i++) {
                var budgetName = jsonArr[i].BudgetName;
                let html = '<li>' + budgetName + '</li>';
                $("#ul_myBudgets").append(html);
            }


            //for (let i = 0; i < jsonArr.length; i++) {
            //    var itemId = jsonArr[i].Id;
            //    let html = '<div class="div_myPage_list">' + + '</div>';



            //        < div class="div_tr" > <div class=div_td id="div_td_receiver' + itemId + '">' +
            //        result[i].Receiver + '</div><div class=div_td id="div_td_gift' + itemId + '">' +
            //        result[i].Name + '</div><div class=div_td id="div_td_price' + itemId + '">' +
            //        result[i].Price + '</div>'
            //        + '<div class="div_td"><button class="edit" value="' + result[i].Id + '">Ändra</button></div><div class="div_td"><button class="delete" value="' + result[i].Id + '">Radera</button></div></div>';
            //    $("#table_list").append(html);
            //}
        }
    });
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
//NEDRÄKNARE TILL JULAFTON
//=================================================================================================


var before = "julafton!"
var current = "Tjohoo, idag är det julafton. God Jul!"
var montharray = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec")

function countdown(yr, m, d) {
	theyear = yr; themonth = m; theday = d
	var today = new Date()
	var todayy = today.getYear()
	if (todayy < 1000)
		todayy += 1900
	var todaym = today.getMonth()
	var todayd = today.getDate()
	var todayh = today.getHours()
	var todaymin = today.getMinutes()
	var todaysec = today.getSeconds()
	var todaystring = montharray[todaym] + " " + todayd + ", " + todayy + " " + todayh + ":" + todaymin + ":" + todaysec
	futurestring = montharray[m - 1] + " " + d + ", " + yr
	dd = Date.parse(futurestring) - Date.parse(todaystring)
	dday = Math.floor(dd / (60 * 60 * 1000 * 24) * 1)
	dhour = Math.floor((dd % (60 * 60 * 1000 * 24)) / (60 * 60 * 1000) * 1)
	dmin = Math.floor(((dd % (60 * 60 * 1000 * 24)) % (60 * 60 * 1000)) / (60 * 1000) * 1)
	dsec = Math.floor((((dd % (60 * 60 * 1000 * 24)) % (60 * 60 * 1000)) % (60 * 1000)) / 1000 * 1)
	if (dday === 0 && dhour === 0 && dmin === 0 && dsec === 1) {
		document.forms.count.count2.value = current
		return
	}
	else
		document.forms.count.count2.value = "  ...bara " + dday + " dagar och " + dhour + " timmar" /*+ dmin + " minutes, and " + dsec*/ + " kvar till " + before
	setTimeout("countdown(theyear,themonth,theday)", 1000)
}
//enter the count down date using the format year/month/day
countdown(2017, 12, 24)
	
	
	

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