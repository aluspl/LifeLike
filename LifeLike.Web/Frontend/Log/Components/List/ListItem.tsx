import * as React from 'react';
import * as moment from 'moment';

import Item from '../../Models/Log';
import './LogListItem.scss';

interface ItemPros {
    key: number,
    item: Item
}

class ListItem extends React.Component<ItemPros, any> {

    render() {
        return (            
            <a href={`/Log/Details/${this.props.item.Id}`}>
              <div className='ProjectsListItem row'>
                    <div className='col-md-12'>
                        <div className='ProjectsListItem-summary row'>
                            <div className='col-md-6 padding-none'>
                                <span className='ProjectsListItem-name'>{this.props.item.Name}</span>
                            </div>
                            <div className='col-md-6 padding-none'>
                                <span className='pull-right'>
                                    <span className='glyphicon glyphicon-calendar'/> {moment(this.props.item.EventTime).format("DD-MM-YYYY")}
                                </span>
                            </div>
                        </div>
                        <div className='row'>
                            <div className='col-md-12 padding-none'>
                                <span className='ProjectsListItem-description'>{this.props.item.Messages}</span>
                            </div>
                        </div>                      
                    </div>
                </div>
                </a>
        )
    }

}

export default ListItem;