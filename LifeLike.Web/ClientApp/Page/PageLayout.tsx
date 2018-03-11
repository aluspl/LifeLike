'use strict';

import * as React from 'react';
import {RouteComponentProps} from 'react-router';
import Item from "../Models/Page";
import LoadingView from "../Components/Loading/LoadingView";
import ListView from "../Components/PageList/ListView";
import EmptyListView from "../Components/EmptyList/EmptyListView";

interface  Props extends RouteComponentProps<any>{
    Params: string;
}

interface IPostState {
    loadingData: boolean,
    items: Item[]
}

export class PageLayout extends React.Component<Props, IPostState> {
    constructor(props: Props, state: IPostState) {
        super(props, state);
        this.state = {
            loadingData: true,
            items: []
        };
    }

    private paths = {
        All: '/Api/Page/Pages',
    };

    public componentDidMount() {
        fetch(this.paths.All, {
            credentials: 'include'
        })
            .then((response) => {
                return response.text();
            })
            .then((data) => {
                this.setState({
                    items: JSON.parse(data),
                    loadingData: false
                });
            });
    }

    public render() {
        const hasProjects = this.state.items.length > 0;

        return (
            <section className="resume-section">
                <div className="subheading">
                    Dev Projects
                </div>
                {
                    this.state.loadingData ?
                    <LoadingView Title={"Posts"}/> :
                     hasProjects ?
                    <ListView items={this.state.items}/> :  <EmptyListView Title={"Posts"}/>
                }
            </section>
        )
                    
           
    }
}
