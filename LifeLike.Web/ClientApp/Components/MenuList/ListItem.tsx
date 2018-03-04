import * as React from 'react';
import { Router } from "react-router";
import Item from '../../Models/MenuItem';
import {NavLink} from "react-router-dom";

interface ListItemPros {
    key: number,
    item: Item
}

class ListItem extends React.Component<ListItemPros, any> {
    SetupNavLink()
    {
         return '/'.concat(this.props.item.Controller).concat('/').concat(this.props.item.Action);        
    }
    SetupGlyph()
    {
         return'fas fa-'.concat(this.props.item.IconName);        
    }
    render() {
        return (
            <li className="nav-item">
                <NavLink className="nav-link"  to={this.SetupNavLink()}   exact activeClassName='active'>
                    <i className={this.SetupGlyph()}/>  {this.props.item.Name}
                </NavLink>
            </li>
        )
    }
}

export default ListItem;