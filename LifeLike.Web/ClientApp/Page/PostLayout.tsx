import * as React from 'react';
import { RouteComponentProps, RouteProps } from 'react-router';
import  PostContainer from './Components/PostContainer';

export class PostLayout extends React.Component<RouteComponentProps<{}>, {}> {
    constructor(props: RouteComponentProps<{}>) {
        super(props);
    }
    public render() {
        let contents = <PostContainer/>;        
        return <div>
            <div className="jumbotron">
                <p className="lead">NEWS</p>
            </div>
            { contents }
        </div>;
    }
}
