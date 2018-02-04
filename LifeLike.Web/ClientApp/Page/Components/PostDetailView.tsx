import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import Item from '../../Models/Page';


interface IPostDetailLayout {
    loadingData: boolean,
    Item: Item
} 
class PostDetailView extends React.Component<any, IPostDetailLayout> {
    constructor() {
        super();

        this.state = {
            loadingData: true,
            Item: new Item()
        };
    }

    public render() {
        return <div>
            <h1>Post:  {this.props.match.params} </h1>
            </div>;
    }
}
export default PostDetailView;