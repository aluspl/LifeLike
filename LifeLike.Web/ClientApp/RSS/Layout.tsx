import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface  Props extends RouteComponentProps<any>{
    shortname: string

}
export class RSSLayout extends React.Component<Props, {}> {
    constructor(props: Props) {
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
