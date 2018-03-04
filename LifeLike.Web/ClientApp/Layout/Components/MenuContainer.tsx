import * as React from 'react';
import LoadingView from '../../Components/Loading/LoadingView';

import Item from "../../Models/MenuItem";
import ListItem from "../../Components/MenuList/ListItem";
interface NavMenuState {
    loadingData: boolean,
    items: Item[]
}
interface NavMenuProps{
    
}

class MenuContainer extends React.Component<NavMenuProps, NavMenuState> {

    private paths = {
        getList: '/Api/Menu'
    };

    constructor(props: NavMenuProps) {
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
        return (
            <ul className='navbar-nav'>
                {
                    this.state.items.map(item => {
                        return <ListItem key={item.Id} item={item}/>
                    })
                }
            </ul>
        )
    }
 
}

export default MenuContainer;