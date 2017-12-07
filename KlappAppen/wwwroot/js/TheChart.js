$(document).ready(function () {
	$.ajax({
		url: "/home/CreateChart",
		type: "GET",
		success: function (jsonzzz) {
			createChart(jsonzzz);
		}
	});
});

function createChart(jsonzzz) {
	let result = JSON.parse(jsonzzz);
	console.log(result);

	var colorList = ["#4d0000", "#004d00", "#003300", "#008000"];

	var colorArray = [];
	var labelArray = [];
	var dataArray = [];
	for (var i = 0; i < result.length; i++) {
		colorArray.push(colorList[i]);
		labelArray.push(result[i].Name);
		dataArray.push(result[i].Price);
	}
	

	var ctx = document.getElementById("doughnut").getContext('2d');

	var doughnutChart = new Chart(ctx, {

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

$(document).ready(function () {
	//$.getJSON("/Home/SetBudget")
	//	.done(function (data) {
 //           console.log(data);

	




			////for (i = 0; i < data.Name.length; i++) {
			////	var html = "<div>" + data.Name[i] + "</div>";
			////	}
			//	["A", "B", "C", "D", "E"];
			//var priceArray = [1, 2, 3, 4, 5];

			//myArray = data;
			//// BYGG PIE
			//var ctx = $("#myChart");
			//var doughnut = new Chart(ctx, {

			//	type: 'doughnut',
			//	data: {
			//		labels: nameArray
			//		datasets: [
			//			{
			//				label: 'Example',
			//				backgroundColor: ['#f1c40f', '#e67e22', '#16a085', '#2980b9', '#333'],
			//				data: priceArray
			//			}
			//		]
			//	},

			//	options: {
			//		cutoutPercentage: 80,
			//		animation: {
			//			animateScale: true
			//		}
			//	}

			//});
		//})
		//.fail(function () { alert("FAIL!"); });
});

