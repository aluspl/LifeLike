import * as React from 'react';
import {NavLink} from "react-router-dom";

import Item from '../../Models/Page';
import * as moment from "moment";

interface ListItemPros {
    key: number,
    item: Item
}

class ListItem extends React.Component<ListItemPros, any> {
    SetupNavLink() {
        return ('/Post/').concat(this.props.item.ShortName);
    }

    render() {
        return (
            <NavLink className='col-sm-4' to={this.SetupNavLink()}>
                <div className='subheading'>
                    {this.props.item.FullName}
                </div>
                <div className="row">
                    <div className='col-md-6'>
                        <i className='fas fa-calendar'/> {this.props.item.ShortName}
                    </div>

                    <div className='col-md-3'>
                        <i className='fas fa-calendar'/>{moment(this.props.item.Published).format("DD-MM-YYYY")}
                    </div>
                </div>
            </NavLink>
        )
    }

}

export default ListItem;