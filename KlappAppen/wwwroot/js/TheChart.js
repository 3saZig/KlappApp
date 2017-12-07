



$(document).ready(function () {
	//$.getJSON("/Home/SetBudget")
	//	.done(function (data) {
 //           console.log(data);

	var ctx = document.getElementById("doughnut").getContext('2d');

            var doughnutChart = new Chart(ctx, {

                type: 'doughnut',
                data: {
                    labels: ["name3", "jgasdlk", "dalgkj", "glkd", "aghsdlk"],
                    datasets: [
                        {
                            label: "Chart",
                            data: [1, 4, 6, 2, 7],
                            backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                        }
                    ]
                },

                //options: {
                //        cutoutPercentage: 80,
                //        animation: {
                //            animateScale: true
                //        }
                //    }

                });




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

