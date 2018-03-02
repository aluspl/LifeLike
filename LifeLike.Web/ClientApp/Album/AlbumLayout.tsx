import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import ListContainer from './Components/ListContainer';

interface Props{
    
}
export class AlbumLayout extends React.Component<RouteComponentProps<Props>, {}> {
    constructor(props: RouteComponentProps<Props>) {
        super(props);
    }


    public render() {
        let contents = <ListContainer/>;
        return <div>
            <div className="jumbotron">
                <p className="lead">ALBUMS</p>
            </div>
            { contents }
        </div>;
    }
}
