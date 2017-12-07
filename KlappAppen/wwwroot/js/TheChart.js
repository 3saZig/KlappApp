



$(document).ready(function () {
	$.getJSON("/Home/GetBudget")
		.done(function (data) {
			console.log(data);

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
		})
		.fail(function () { alert("FAIL!"); });



});

