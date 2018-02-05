import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import  PostContainer from './Components/PostContainer';
import  PostDetailView from './Components/PostDetailView';

export class PostLayout extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
    }


    public render() {
        console.log('Page Params: '+this.props.match);
        console.log('Page Params: '+this.props.match.path);

        let isDetail = this.props.match.params != null; 

        let contents = isDetail ?  <PostContainer/> : <PostDetailView Item={this.props.match.params} />;

        return <div>
            <h1>Pages</h1>
            { contents }
        </div>;
    }
}
