




//$(document).ready(function () {
//	$.ajax({
//		url: "/home/Budget",
//		type: "GET",
//		success: function (jsonB) {
//			createChart(jsonB);
//		}
//	});
//});

//function createChart() {
//	//let result = JSON.parse(jsonB);


//	//var colorList = ["#4d0000", "#004d00", "#003300", "#008000", "#6B8E23", "#556B2F", "#808000", "#9ACD32", "#006400", "#32CD32"];

//	//var colorArray = [];
	
//	//for (var i = 0; i < result.length; i++) {
//	//	colorArray.push(colorList[i]);
//	//}


//	var ctx = document.getElementById("pie").getContext('2d');

//	var doughnutChart = new Chart(ctx, {

//		type: 'pie',
//		data: {
//			labels: labelArray,
//			datasets: [
//				{
//					label: "Chart",
//					data: 100, 200, 500, 400,
//					backgroundColor: ["#4d0000", "#004d00", "#003300", "#008000"],
//					borderColor: "#000000"
//				}
//			]
//		},

//		options: {
//			legend: {
//				display: false,
//				cutoutPercentage: 0,
//				responsive: true,
//				maintainAspectRatio: true,
//				animation: {
//					animateScale: true
//				}
//			}
//		}

//	});
//};

////$(document).ready(function () {
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
////});





////$(document).ready(function () {
////	$.ajax({
////		url: "/home/Budget",
////		type: "GET",
////		success: function (jsonB) {
////			createBudget(jsonB);
////		}
////	});
////});

////function createBudget(jsonB) {
////	let result = JSON.parse(jsonB);

////	var colorList = ["#4d0000", "#004d00", "#003300", "#008000", "#6B8E23", "#556B2F", "#808000", "#9ACD32", "#006400", "#32CD32"];

////	var colorArray = [];
////	for (var i = 0; i < result.length; i++) {
////		colorArray.push(colorList[i]);
////	}

////	var ctx = document.getElementById("doughnut").getContext('2d');

////	var doughnutChart = new Chart(ctx, {

////		type: 'doughnut',
////		data: {
////			labels: "Totalbudget",
////			datasets: [
////				{
////					label: "Chart",
////					data: result,
////					backgroundColor: colorArray,
////					borderColor: "#000000"
////				}
////			]
////		},

////		options: {
////			legend: {
////				display: false,
////				cutoutPercentage: 20,
////				responsive: true,
////				maintainAspectRatio: true,
////				animation: {
////					animateScale: true
////				}
////			}
////		}

////	});
////};