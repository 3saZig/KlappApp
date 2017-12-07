﻿

var budgetGiftList = JsonConvert.DeserializeObject<BudgetGiftJson>(ret);


class CommentBox extends React.Component {

	componentDidMount() {
		var ctx = $("#myChart");
		var doughnut = new Chart(ctx, {

			type: 'doughnut',
			data: {
				labels: [budgetGiftList.Receiver],
				datasets: [
					{
						label: 'Example',
						backgroundColor: ['#f1c40f', '#e67e22', '#16a085', '#2980b9', '#333'],
						data: [budgetGiftList.Price]
					}
				]
			},

			options: {
				cutoutPercentage: 80,
				animation: {
					animateScale: true
				}
			}

		});
	}

	render() {
        return (
            <div className="commentBox">
				<h1>Budget</h1>
				<canvas id="myChart"></canvas>
            </div>
        );
    }
};

if ($("#content").length > 0) {
ReactDOM.render(
    <CommentBox />,
    document.getElementById('content')
);
}



