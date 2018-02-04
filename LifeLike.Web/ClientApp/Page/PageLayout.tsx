import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import PageContainer from './Components/PageContainer';
import PageDetailView from './Components/PageDetailView';

export class PageLayout extends React.Component<RouteComponentProps<string>, {}> {
    constructor() {
        super();
    }
    public render() {
        console.log('Page Params: '+this.props.match.params)
        let isDetail = this.props.match.params != null; 

      //  let contents = isDetail ?  <PageContainer/> : <PageDetailView Item={this.props.match.params} />;
        
        return <div>
            <h1>Posts</h1>
            {  <PageContainer/>  }
        </div>;
    }
}
