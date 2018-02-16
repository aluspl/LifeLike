import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import PageContainer from './Components/PageContainer';

interface IPostProps{
    shortname: string;
}
export class PageLayout extends React.Component<RouteComponentProps<IPostProps>, {}>{
    constructor() {
        super();
    }
    public render() {
        let contents =   <PageContainer/>;

        return <div>
            { contents }
        </div>;
    }
}
