import * as React from 'react';
import ListView from '../../Components/VideoList/ListView';
import EmptyListView from '../../Components/EmptyList/EmptyListView';
import LoadingView from '../../Components/Loading/LoadingView';

import Item from '../../Models/MenuItem';

interface ListContainerState {
    loadingData: boolean,
    items: Item[]
}

class ListContainer extends React.Component<any, ListContainerState> {

    private paths = {
        getList: '/Api/Video/'
    };

    constructor() {
        super();

        this.state = {
            loadingData: true,
            items: []
        };
    }
    public componentDidMount() {
        fetch(this.paths.getList, {
            credentials: 'include' })
            .then((response) => {
                return response.text();
            })
            .then((data) => {
                this.setState((state, props) => {
                    state.items = JSON.parse(data);
                    state.loadingData = false;
                    console.log(state.items);
                });
            });
    }
    public render() {
        const hasProjects = this.state.items.length > 0;

        return (
            this.state.loadingData ?
                <LoadingView Title={"Videos"}/> :
                hasProjects ?
                    <ListView items= {this.state.items} /> :  <EmptyListView />
        )
    }
 
}

export default ListContainer;