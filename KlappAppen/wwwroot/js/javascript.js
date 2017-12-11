$(document).ready(function () {
    $.ajax({
        url: "/home/GetListJavaScript",
        type: "GET",
        success: function (jsonArr) {
            createTable(jsonArr);
            //addPerson();
            addBudget();
            createChart(jsonArr);
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
        let html = '<div class="div_tr"><div class=div_td id="div_td_receiver' + itemId + '">' + result[i].Receiver + '</div><div class=div_td id="div_td_gift' + itemId + '">' + result[i].Name + '</div><div class=div_td id="div_td_price' + itemId +'">' + result[i].Price + '</div>'
            + '<div class="div_td_button"><button class="edit" value="' + result[i].Id + '">Ändra</button></div><div class="div_td"><button class="delete" value="' + result[i].Id + '">Radera</button></div></div>';
        $("#table_list").append(html);
    }
    deletePerson();
    editPerson();
    SumAllGifts(jsonArr)
    
    //Addknappen 
    $("#table_list").append('<div class="div_tr"><div id="td_button_add"><button class="button_add">Lägg till</button></div></div>');
    addPerson();
};

function SumAllGifts(jsonArr) {
    let giftPrice = JSON.parse(jsonArr);
    let total = 0;
    for (var i = 0; i < giftPrice.length; i++) {
        total = total + giftPrice[i].Price;
    }    
    let html = '<div class="div_summa">Summa: ' + total + ' kr</div>';
    $("#table_list").append(html);
};

function addPerson() {
    $(".button_add").click(function () {        
        $(this).hide();
        var html = '<div class="div_input"><input id="input_receiver" type="text"/><input id="input_gift" type="text"/><input id="input_price" type="number"/><button class="button_savePerson">Spara</button></div>';
        $("#table_list").append(html);
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
                createChart(jsonArr);
            }
        });
    });
};

function editPerson() {
    $(".edit").click(function () {
        $(this).hide();
        $(".delete").hide();
        var id = $(this).val();
        var html = '<div class="div_input"><input id="input_receiver" type="text" value="' + $("#div_td_receiver" + id).text() + '"/><input id="input_gift" type="text" value="' + $("#div_td_gift" + id).text() + '"/><input id="input_price" type="number" value="' + $("#div_td_price" + id).text() +'"/><button class="button_save">Spara</button></div>';
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
                createChart(jsonparse);
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
                createChart(jsonArr);
            }
        })

    })
};

function addBudget() {
    $("#submitknapp").click(function () {
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

function createChart(jsonArr) {

    let result = JSON.parse(jsonArr);
    let budgetResult = JSON.parse(jsonArr)

    var colorList = ["#4d0000", "#004d00", "#003300", "#008000", "#6B8E23", "#556B2F", "#808000", "#9ACD32", "#006400", "#32CD32"];


    var budgetArray = [];
    var colorArray = [];
    var labelArray = [];
    var dataArray = [];
    for (var i = 0; i < result.length; i++) {
        colorArray.push(colorList[i]);
        labelArray.push(result[i].Name);
        dataArray.push(result[i].Price);
        budgetArray.push(result[i].Total);
    }

    var firstBudgetPost = budgetArray[0];
	let totalGiftSum = SumAllGifts(jsonArr);
	let moneyLeft = firstBudgetPost - totalGiftSum;

	dataArray.push(moneyLeft);
	labelArray.push("budget");
	colorArray.push('#922b21');

    var ctxa = document.getElementById("doughnut").getContext('2d');

    var doughnutChart = new Chart(ctxa, {

        type: 'doughnut',
        data: {
            labels: labelArray,
            datasets: [
                {
                    label: "Chart",
                    data: dataArray,
                    backgroundColor: colorArray,
                    borderColor: "#000000"
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

    });
};

$("#btn_changeColor").click(function(){
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

