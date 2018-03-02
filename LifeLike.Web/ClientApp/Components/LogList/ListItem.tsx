import * as React from 'react';
import * as moment from 'moment';

import Item from '../../Models/Log';
import { NavLink } from 'react-router-dom';

interface ItemPros {
    key: number,
    item: Item
}

class ListItem extends React.Component<ItemPros, any> {
    
    SetupNavLink()
    {
         return '/Log/'.concat(this.props.item.Id.toString());        
    }  
    render() {
        return (    
            
            <NavLink to={this.SetupNavLink()}   exact activeClassName='active'>
              <tr className='row'>
                  <td>
                      {this.props.item.Name}
                  </td>
                  <td>
                      <span className='glyphicon glyphicon-calendar'/> {moment(this.props.item.EventTime).format("DD-MM-YYYY")}
                  </td>
                  <td>
                      {this.props.item.Messages}
                  </td>
                </tr>
            </NavLink>
        )
    }
}

export default ListItem;