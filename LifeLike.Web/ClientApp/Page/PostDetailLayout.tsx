import * as React from 'react';
import { RouteComponentProps, RouteProps } from 'react-router';
import PostDetailView  from './Components/PostDetailView';


interface IPostDetailParam {
    shortname: string

} 
 export class PostDetailLayout extends React.Component<RouteComponentProps<IPostDetailParam>, {}> {
     constructor(props: RouteComponentProps<IPostDetailParam>) {
         super(props);
     }
    public render() {
        console.log(this.props.match);
        let contents =  <PostDetailView Shortname={this.props.match.params.shortname}/>
        return   <div>
                     { contents }
                 </div>
    }
}
