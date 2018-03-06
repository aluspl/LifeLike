import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import LogContainer from './Components/ListContainer';

interface Props {
    shortname: string

}
export class RSSLayout extends React.Component<RouteComponentProps<Props>, {}> {
    constructor(props: RouteComponentProps<Props>) {
        super(props);
    }


    public render() {
        return <section className="resume-section">
            <div className="subheading">
               {this.props.match.params.shortname}
            </div>
        </section>;
    }
}
