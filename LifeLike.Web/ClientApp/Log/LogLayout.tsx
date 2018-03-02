import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import LogContainer from './Components/ListContainer';


export class LogLayout extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
        this.state = { currentCount: 0 };
    }


    public render() {
        let contents = <LogContainer/>;
        return <div>
            <div className="jumbotron">
                <p className="lead">LOGS</p>
            </div>
            { contents }
        </div>;
    }
}
