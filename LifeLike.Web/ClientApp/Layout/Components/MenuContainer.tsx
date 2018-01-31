import * as React from 'react';
import LoadingView from '../../Shared/Components/LoadingView/LoadingView';

import Item from "../Models/MenuItem";
import ListView from "./ListView";
interface NavMenuState {
    loadingData: boolean,
    items: Item[]
}


class MenuContainer extends React.Component<any, NavMenuState> {

    private paths = {
        getList: '/Api/Menu'
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
                });
            });
    }
    public render() {
        return (
            this.state.loadingData ?
                <LoadingView Title={"Menu"}/> :
                <ListView items={this.state.items} />
        )
    }
 
}

export default MenuContainer;