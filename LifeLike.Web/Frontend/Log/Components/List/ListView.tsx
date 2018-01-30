import * as React from "react";

import ListItem from './ListItem';
import Item from "../../Models/Log";

interface ListProps {
    items: Item[]
}

class ListView extends React.Component<ListProps, any> {

    render() {
        return <section className='ProjectsList row'>
            <div className='col-md-12'>
                {
                    this.props.items.map(log => {
                        return <ListItem key={log.Id} item={log}/>
                    })
                }
            </div>
        </section>
    }

}

export default ListView;