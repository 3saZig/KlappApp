﻿



	
//	document.getElementById("submitknapp").onclick = function () {
//		var budgetInput = document.getElementById("budgetInputTextbox").value;


//		};


//});

$(document).ready(function () {
	$.ajax({
		url: "/home/CreateChart",
		type: "GET",
		success: function (jsonzzz) {
			createChart(jsonzzz);
		}
	});

	function createChart(jsonparse, jsonzzz) {

	let result = JSON.parse(jsonzzz);
	let budgetResult = JSON.parse(jsonparse);
	
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

	var moneyLeft = firstBudgetPost - dataArray;

	var ctxa = document.getElementById("doughnut").getContext('2d');

	var doughnutChart = new Chart(ctxa, {

		type: 'doughnut',
		data: {
			labels: labelArray,
			datasets: [
				{
					label: "Chart",
					data: [dataArray, moneyLeft],
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



//$(document).ready(function () {
//	//$.getJSON("/Home/SetBudget")
//	//	.done(function (data) {
// //           console.log(data);

	




//			////for (i = 0; i < data.Name.length; i++) {
//			////	var html = "<div>" + data.Name[i] + "</div>";
//			////	}
//			//	["A", "B", "C", "D", "E"];
//			//var priceArray = [1, 2, 3, 4, 5];

//			//myArray = data;
//			//// BYGG PIE
//			//var ctx = $("#myChart");
//			//var doughnut = new Chart(ctx, {

//			//	type: 'doughnut',
//			//	data: {
//			//		labels: nameArray
//			//		datasets: [
//			//			{
//			//				label: 'Example',
//			//				backgroundColor: ['#f1c40f', '#e67e22', '#16a085', '#2980b9', '#333'],
//			//				data: priceArray
//			//			}
//			//		]
//			//	},

//			//	options: {
//			//		cutoutPercentage: 80,
//			//		animation: {
//			//			animateScale: true
//			//		}
//			//	}

//			//});
//		//})
//		//.fail(function () { alert("FAIL!"); });
//});

