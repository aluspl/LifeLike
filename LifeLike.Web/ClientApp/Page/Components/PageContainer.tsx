import * as React from 'react';
import ListView from '../../Components/PageList/ListView';
import EmptyListView from '../../Components/EmptyList/EmptyListView';
import LoadingView from '../../Components/Loading/LoadingView';

import Item from '../../Models/Page';

interface ListContainerState {
    loadingData: boolean,
    items: Item[]
}
interface ListContainerProps {
}

class ListContainer extends React.Component<ListContainerProps, ListContainerState> {

    private paths = {
        getList: '/Api/Page/Pages'
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
        const hasProjects = this.state.items.length > 0;

        return (
            this.state.loadingData ?
                <LoadingView Title={"Posts"}/> :
                hasProjects ?
                    <ListView items= {this.state.items} /> :  <EmptyListView Title={"Page"}/>
        )
    }
 
}

export default ListContainer;