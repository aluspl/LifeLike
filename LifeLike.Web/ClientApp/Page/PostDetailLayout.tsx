'use strict';

import * as React from 'react';
import {RouteComponentProps} from 'react-router';
import Item from "../Models/Page";
import LoadingView from "../Components/Loading/LoadingView";
import Detail from './PostDetailView';

interface  Props extends RouteComponentProps<any>{
    shortname: string
}

interface IPostDetailState {
    loadingData: boolean,
    Item: Item,
}

export class PostDetailLayout extends React.Component<Props, IPostDetailState> {
    constructor(props: Props) {
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
            <section className="resume-section">
                {
                    this.state.loadingData ?
                        <LoadingView Title="Post"/> : 
                        <Detail   Item={this.state.Item} />                     
                    }
                </section>
        );
    }
}
