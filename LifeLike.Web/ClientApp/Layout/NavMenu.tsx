import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';
import MenuList from "./Components/MenuContainer";


export class NavMenu extends React.Component<{}, {}> {
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
                    <MenuList />
                </div>
            </nav>
    );
    }
}
