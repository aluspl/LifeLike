import * as React from 'react';
import { NavLink } from 'react-router-dom';
import Item from "../Models/MenuItem";
import ListItem from "../Components/MenuList/ListItem";

interface NavMenuState {
    loadingData: boolean,
    items: Item[]
}
interface NavMenuProps{

}

export class NavMenu extends React.Component<NavMenuProps, NavMenuState> {
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
            <nav className="navbar navbar-expand-lg navbar-dark bg-primary fixed-top" id="sideNav">
                <NavLink className="navbar-brand" to="/">
                    <span className="d-block d-lg-none">LifeLike</span>
                    <span className="d-none d-lg-block">
                        <img className="img-fluid img-profile rounded mx-auto mb-2" src="images/logo.png" alt=""/>
                    </span>
                </NavLink>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"/>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className='navbar-nav'>
                        {
                            this.state.items.map(item => {
                                return <ListItem key={item.Id} item={item}/>
                            })
                        }
                    </ul>
                </div>
            </nav>
    );
    }
}
