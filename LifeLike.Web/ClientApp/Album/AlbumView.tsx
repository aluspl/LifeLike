import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import ListContainer from './Components/ListContainer';


export class AlbumLayout extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
        this.state = { currentCount: 0 };
    }


    public render() {
        let contents = <ListContainer/>;
        return <div>
            <h1>Albums</h1>
            { contents }
        </div>;
    }
}
