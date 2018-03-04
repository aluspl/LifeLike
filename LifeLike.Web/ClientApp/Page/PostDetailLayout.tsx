import * as React from 'react';
import {RouteComponentProps, RouteProps} from 'react-router';
import Item from "../Models/Page";
import LoadingView from "../Components/Loading/LoadingView";


interface IPostDetailParam {
    shortname: string
}

interface IPostDetailState {
    loadingData: boolean,
    Item: Item,
}

export class PostDetailLayout extends React.Component<RouteComponentProps<IPostDetailParam>, IPostDetailState> {
    constructor(props: RouteComponentProps<IPostDetailParam>, state: IPostDetailState) {
        super(props);
        this.state = {
            loadingData: true,
            Item: new Item,
        };
        console.log(this.state);
    }

    private paths = {
        getList: '/Api/Page/Details/'
    };

    public componentDidMount() {
        let path = this.paths.getList.concat(this.props.match.params.shortname);
        console.log(path);

        fetch(path, {
            credentials: 'include'
        })
            .then((response) => {
                return response.text();
            })
            .then((data) => {
                this.setState({
                    Item: JSON.parse(data),
                    loadingData: false
                });
            });
    }

    public render() {
        return (
            this.state.loadingData ?
                <LoadingView Title="Post"/> :
                <section className="resume-section">
                    <div className="jumbotron">
                        <h1 className="lead">{this.state.Item.FullName}</h1>
                        <p className="lead">{this.state.Item.ShortName}</p>
                    </div>
                    <p> {this.state.Item.Content}</p>
                    <p>{this.state.Item.Category}</p>
                </section>);
    }
}
