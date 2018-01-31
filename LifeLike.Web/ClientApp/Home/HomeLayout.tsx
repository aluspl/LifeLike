import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class HomeLayout extends React.Component<RouteComponentProps<{}>, any> {
    constructor() {
        super();
        this.state = { currentCount: 0 };
    }

    public render() {
        return <div>Home</div>;
    }
}
