import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import PageListView from './Components/PageContainer';
export class PageLayout extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
    }


    public render() {
        let contents = <PageListView/>;
        return <div>
            <h1>Logs</h1>
            { contents }
        </div>;
    }
}
