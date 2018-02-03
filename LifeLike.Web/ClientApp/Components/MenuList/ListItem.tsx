import * as React from 'react';

import Item from '../../Models/MenuItem';
import {NavLink} from "react-router-dom";

interface ListItemPros {
    key: number,
    item: Item
}

class ListItem extends React.Component<ListItemPros, any> {

    render() {
        return (
            <li>
                <NavLink to={ this.props.item.Controller } exact activeClassName='active'>
                    <span className='glyphicon glyphicon-name${this.props.item.IconName}'>{this.props.item.Name}</span> 
                </NavLink>
            </li>
        )
    }

}

export default ListItem;