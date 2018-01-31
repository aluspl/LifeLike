import * as React from 'react';
import ListView from './List/ListView';
import Item from '../Models/Item';
import EmptyListView from "../../Shared/Components/EmptyListView/EmptyListView";
import LoadingView from "../../Shared/Components/LoadingView/LoadingView";

interface ListContainerState {
    loadingData: boolean,
    items: Item[]
}

class ListContainer extends React.Component<any, ListContainerState> {
   
    private paths = {
        getList: '/Api/Album/List'
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
        const hasItems = this.state.items.length > 0;
        console.log(hasItems);
        return (
            this.state.loadingData ?
                <LoadingView Title={'Albums'}/> :
                hasItems ?
                    <ListView items= {this.state.items} /> :  <EmptyListView />
        )
        
    }
}

export default ListContainer;