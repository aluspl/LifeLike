import * as React from 'react';
import {Link} from "react-router-dom";

import Item from '../../Models/Page';

interface ListItemPros {
    key: number,
    item: Item
}

class ListItem extends React.Component<ListItemPros, any> {
    SetupNavLink()
    {
        return ('/Page/').concat(this.props.item.ShortName);
    }
    render() {
        return (            
            <Link to={this.SetupNavLink()}>
              <div className='ListItem row'>
                    <div className='col-md-12'>
                        <div className='ListItem-summary row'>
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
                </Link>
        )
    }

}

export default ListItem;