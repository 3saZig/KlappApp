class CommentBox extends React.Component {
    render() {
        return (
            <div className="commentBox">
                <h1>Budget</h1>
            </div>
        );
    }
};

ReactDOM.render(
    <CommentBox />,
    document.getElementById('content')
);