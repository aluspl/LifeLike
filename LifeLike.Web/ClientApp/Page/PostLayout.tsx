import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import PostContainer from './Components/PostContainer';

export class PostLayout extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
    }


    public render() {
        let contents = <PostContainer/>;
        return <div>
            <h1>Logs</h1>
            { contents }
        </div>;
    }
}
