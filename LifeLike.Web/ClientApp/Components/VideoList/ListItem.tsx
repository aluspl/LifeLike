import * as React from 'react';
import {NavLink} from "react-router-dom";

import Item from '../../Models/MenuItem';

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
         return'glyphicon glyphicon-'.concat(this.props.item.IconName);        
    }
    render() {
        return (
            <li>
                <NavLink to={this.SetupNavLink()}   exact activeClassName='active'>
                    <span className={this.SetupGlyph()}> </span> {this.props.item.Name}
                </NavLink>
            </li>
        )
    }
}

export default ListItem;