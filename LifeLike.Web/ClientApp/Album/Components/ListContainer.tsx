import * as React from 'react';
import ListView from '../../Components/AlbumList/ListView';
import EmptyListView from '../../Components/EmptyList/EmptyListView';
import LoadingView from '../../Components/Loading/LoadingView';

import Item from '../../Models/Album';

interface ListContainerState {
    loadingData: boolean,
    items: Item[]
}
interface ListContainerProps {
}

class ListContainer extends React.Component<ListContainerProps, ListContainerState> {
   
    private paths = {
        getList: '/Api/Album/List'
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
                this.setState({ 
                    items: JSON.parse(data),
                    loadingData: false
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
                    <ListView items= {this.state.items} /> :  <EmptyListView Title={"Album"} />
        )
        
    }
}

export default ListContainer;