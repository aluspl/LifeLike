import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import LogContainer from './Components/ListContainer';

interface LogLayoutProps
{
    
}

export class LogLayout extends React.Component<RouteComponentProps<LogLayoutProps>, {}> {
    public render() {
        let contents = <LogContainer/>;
        return <div>
            <h1>Logs</h1>
            { contents }
        </div>;
    }
}
