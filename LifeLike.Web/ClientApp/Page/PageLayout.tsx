import * as React from 'react';
import {RouteComponentProps} from 'react-router';
import Item from "../Models/Page";
import LoadingView from "../Components/Loading/LoadingView";
import ListView from "../Components/PageList/ListView";
import EmptyListView from "../Components/EmptyList/EmptyListView";

interface IPostProps {
    shortname: string;
}

interface IPostState {
    loadingData: boolean,
    items: Item[]
}

export class PageLayout extends React.Component<RouteComponentProps<IPostProps>, IPostState> {
    constructor(props: RouteComponentProps<IPostProps>, state: IPostState) {
        super(props, state);
        this.state = {
            loadingData: true,
            items: []
        };
    }

    private paths = {
        getList: '/Api/Page/Pages'
    };

    public componentDidMount() {
        fetch(this.paths.getList, {
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

        return (this.state.loadingData ?
            <LoadingView Title={"Posts"}/> :
            <section className="resume-section">
                hasProjects ?
                <ListView items={this.state.items}/> :
                <EmptyListView Title={"Page"}/>
            </section>)
    }
}
