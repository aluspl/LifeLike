import * as React from 'react';


import Item from '../../Models/MenuItem';
import ListItem from './ListItem';

interface ListProps {
    items: Item[]
}

class ListView extends React.Component<ListProps, any> {

    render() {
        return  <section className='row'>
                        {
                            this.props.items.map(item => {
                                return <ListItem key={item.Id} item={item}/>
                            })
                        }
                </section>
    }
}

export default ListView;