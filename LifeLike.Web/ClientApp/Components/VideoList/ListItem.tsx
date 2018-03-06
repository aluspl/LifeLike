import * as React from 'react';
import {NavLink} from "react-router-dom";
import Player from '../Youtube/Player'
import Item from '../../Models/MenuItem';

interface ListItemPros {
    key: number,
    item: Item
}

class ListItem extends React.Component<ListItemPros, any> {
   
    render() {
        return (  
            <div className="col-md-6">
                <Player YoutubeId={this.props.item.YoutubeID} />
            </div>
        );
    }
}

export default ListItem;