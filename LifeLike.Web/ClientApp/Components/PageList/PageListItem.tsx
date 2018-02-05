import * as React from 'react';
import {NavLink} from "react-router-dom";

import Item from '../../Models/Page';

interface ListItemPros {
    key: number,
    item: Item
}

class ListItem extends React.Component<ListItemPros, any> {
    SetupNavLink()
    {
        return ('/Pages/').concat(this.props.item.ShortName);
    }
    render() {
        return (            
            <NavLink to={this.SetupNavLink()}>
              <div className='row'>
                    <div className='col-md-12'>
                        <div className='row'>
                            <div className='col-md-6 padding-none'>
                                <span className='ProjectsListItem-name'>{this.props.item.FullName}</span>
                            </div>
                            <div className='col-md-6 padding-none'>
                                <span className='pull-right'>
                                    <span className='glyphicon glyphicon-calendar'/> {this.props.item.Category}
                                </span>
                            </div>
                        </div>
                                    
                    </div>
                </div>
                </NavLink>
        )
    }

}

export default ListItem;