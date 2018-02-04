import * as React from 'react';
import "../../Styles/ListItem.scss";
import Item from '../../Models/Page';

interface ListItemPros {
    key: number,
    item: Item
}

class ListItem extends React.Component<ListItemPros, any> {

    render() {
        return (            
            <a href={`/Post/${this.props.item.ShortName}`}>
              <div className='ListItem row'>
                    <div className='col-md-12'>
                        <div className='ListItem-summary row'>
                            <div className='col-md-6 padding-none'>
                                <span className='ListItem-name'>{this.props.item.FullName}</span>
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