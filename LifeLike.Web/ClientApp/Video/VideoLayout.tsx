import * as React from 'react';
import { RouteComponentProps, RouteProps } from 'react-router';
import  PostContainer from './Components/ListContainer';

export class VideoLayout extends React.Component<RouteComponentProps<{}>, {}> {
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
