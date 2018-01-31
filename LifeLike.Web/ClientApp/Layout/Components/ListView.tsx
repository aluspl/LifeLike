import * as React from 'react';

import Item from '../Models/MenuItem';
import ListItem from './ListItem';

interface ListProps {
    items: Item[]
}

class ListView extends React.Component<ListProps, any> {

    public render() 
    {
       return <ul className='nav navbar-nav'>
           {
               this.props.items.map(item => {
                   return <ListItem key={item.Id} item={item}/>
               })
           }
        </ul>
    };

}

export default ListView;