import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import Item from '../../Models/Page';


interface IPageDetailLayout {
    loadingData: boolean,
    item: Item
} 
 class PageDetailView   extends React.Component<any, IPageDetailLayout>{
    constructor() {
        super();

        this.state = {
            loadingData: true,
            item: new Item()
        };
    }

    public render() {
        return <div>
           
            <h1>Page  {this.props.match.params} </h1>
        </div>;
    }
}
export default PageDetailView;