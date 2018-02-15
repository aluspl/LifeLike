import * as React from 'react';
import { RouteComponentProps, RouteProps } from 'react-router';
import  PostContainer from './Components/PostContainer';

export class PostLayout extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
    }
    public render() {
        let contents = <PostContainer/>;        
        return <div>
            { contents }
        </div>;
    }
}
