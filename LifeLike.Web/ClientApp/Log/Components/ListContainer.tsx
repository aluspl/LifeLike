import * as React from 'react';
import ListView from '../../Components/LogList/LogList';
import EmptyListView from '../../Components/EmptyList/EmptyListView';
import LoadingView from '../../Components/Loading/LoadingView';
import Item from '../../Models/Log';

interface ListContainerState {
    loadingData: boolean,
    items: Item[]
}
interface ListContainerProps {
}

class ListContainer extends React.Component<ListContainerProps, ListContainerState> {
   
    private paths = {
        getList: '/Api/Log/List'
    };

    constructor(props: ListContainerProps) {
        super(props);

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
        return (
            this.state.loadingData ?
                <LoadingView Title={'Logs'}/> :
                hasItems ? 
                    <ListView items= {this.state.items} /> :  <EmptyListView  Title={"Logs"}  />
        )
    }
}

export default ListContainer;