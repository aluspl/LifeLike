import * as React from 'react';

import Item from '../../Models/Page';

interface ItemListProps {
    items: Item[]
}

class ListSummary extends React.Component<ItemListProps, any> {
    
    render() {
        return <div className='row'>
            <div className='ProjectsList-summary col-md-12'>
                <div className='row'>
                    <div className='col-md-12'>
                        <p>Number of projects: <strong>{this.props.items.length}</strong></p>
                    </div>
                </div>
            </div>
        </div>
    }

}

export default ListSummary;