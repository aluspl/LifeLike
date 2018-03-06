import * as React from 'react';
import * as moment from 'moment';
import {RouteComponentProps} from 'react-router';
import Log from '../Models/Log';

interface LogContainerState {
    loadingData: boolean,
    item: Log
}

interface ILogDetailParam {
    shortname: string
}

export class LogDetailLayout extends React.Component<RouteComponentProps<ILogDetailParam>, LogContainerState> {
    private paths = {
        getList: '/Api/Log/Detail/'
    };

    constructor(props: RouteComponentProps<ILogDetailParam>) {
        super(props);

        this.state = {
            loadingData: true,
            item: new Log
        };
    }

    public componentDidMount() {
        fetch(this.paths.getList.concat(this.props.match.params.shortname), {
            credentials: 'include'
        })
            .then((response) => {
                return response.text();
            })
            .then((data) => {
                this.setState({
                    item: JSON.parse(data),
                    loadingData: false
                });
            });
    }

    public render() {
        return this.state.loadingData ? <h1>Loading</h1> :
            <section className="resume-section">
                <div className="subheading">
                    {this.state.item.Name}
                </div>
                <div className='row'>
                    <div className='col-md'>
                        <div className='row'>
                            <div className='col-md'>
                                <span   className='fas fe-calendar'/> 
                                {moment(this.state.item.EventTime).format("DD-MM-YYYY")}
                            </div>
                        </div>
                        <div className='row'>
                            <div className='col-md'>
                                <span>{this.state.item.Messages}</span>
                            </div>
                        </div>
                        <div className='row'>
                            <div className='col-md'>
                                <span>{this.state.item.StackTrace}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
    }
}
