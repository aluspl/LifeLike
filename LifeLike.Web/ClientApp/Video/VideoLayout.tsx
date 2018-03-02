import * as React from 'react';
import { RouteComponentProps, RouteProps } from 'react-router';
import  PostContainer from './Components/ListContainer';

interface  VideoLayoutProps{
    
}
export class VideoLayout extends React.Component<RouteComponentProps<VideoLayoutProps>, {}> {
    constructor(props: RouteComponentProps<VideoLayoutProps>){
        super(props);
        
    }
    public render() {
        let contents = <PostContainer/>;        
        return <div>
            <div className="jumbotron">
                <p className="lead">VIDEOS</p>
            </div>
            { contents }
        </div>;
    }
}
