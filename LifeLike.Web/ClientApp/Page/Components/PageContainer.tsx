import * as React from 'react';
import List from './List/List';
import EmptyListView from '../../Shared/Components/EmptyListView/EmptyListView';
import LoadingView from '../../Shared/Components/LoadingView/LoadingView';

import Item from '../Models/Page';

interface ListContainerState {
    loadingData: boolean,
    items: Item[]
}

class ListContainer extends React.Component<any, ListContainerState> {

    private paths = {
        getList: '/Api/Page/Pages'
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
                <LoadingView Title={"Posts"}/> :
                hasProjects ?
                    <List items= {this.state.items} /> :  <EmptyListView />
        )
    }
 
}

export default ListContainer;