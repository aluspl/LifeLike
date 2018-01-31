import * as React from 'react';

import Item from '../../Models/Page';
import './ListItem.scss';

interface ListItemPros {
    key: number,
    item: Item
}

class ListItem extends React.Component<ListItemPros, any> {

    render() {
        return (            
            <a href={`/Page/${this.props.item.ShortName}`}>
              <div className='ProjectsListItem row'>
                    <div className='col-md-12'>
                        <div className='ProjectsListItem-summary row'>
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
                </a>
        )
    }

}

export default ListItem;