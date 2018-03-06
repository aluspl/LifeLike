import * as React from "react";

import ListItem from './ListItem';
import Item from "../../Models/Log";

interface ListProps {
    items: Item[]
}

class ListView extends React.Component<ListProps, any> {

    render() {
        return <div>
            <table className='table'>
            <thead>
            <tr>
                <th scope="col">Name</th>
                <th scope="col">Date</th>
                <th scope="col">Message</th>
                <th scope="col">Action</th>

            </tr>
            </thead>
            <tbody>
                {
                    this.props.items.map(log => {
                        return <ListItem key={log.Id} item={log}/>
                    })
                }
            </tbody>
        </table>
        </div>
    }

}

export default ListView;