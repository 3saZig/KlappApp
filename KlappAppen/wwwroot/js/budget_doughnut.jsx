

class CommentBox extends React.Component {

	componentDidMount() {
		var ctx = $("#myChart");
		console.log(ctx);
	}

	render() {
		
		//var doughnut = new Chart(ctx, {

		//	type: 'doughnut',
		//	data: {
		//		labels: ['Resa', 'Bio', 'Mat', 'Nöje', 'Whatever'],
		//		datasets: [
		//			{
		//				label: 'Example',
		//				backgroundColor: ['#f1c40f', '#e67e22', '#16a085', '#2980b9'],
		//				data: [2, 5, 1, 7, 8]
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

        return (
            <div className="commentBox">
				<h1>Budget</h1>
				<div id='myChart'></div>
            </div>
        );
    }
};

ReactDOM.render(
    <CommentBox />,
    document.getElementById('content')
);