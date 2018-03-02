import * as React from 'react';
import * as moment from 'moment';
import { RouteComponentProps } from 'react-router';
import LogContainer from './Components/ListContainer';
import Log from '../Models/Log';

interface LogContainerState {
    loadingData: boolean,
    item : Log
}
interface ILogDetailParam {
    shortname: string
}
export class LogDetailLayout extends React.Component<RouteComponentProps<ILogDetailParam>, LogContainerState> {
    private paths = {
        getList: '/Api/Log/Detail/'
    };
    constructor() {
        super();

        this.state = {
            loadingData: true,
            item: new Log
        };
    }
    public componentDidMount() {
        fetch(this.paths.getList.concat(this.props.match.params.shortname), { 
            credentials: 'include' })
            .then((response) => {
                return response.text();
            })
            .then((data) => {
                this.setState((state, props) => {
                    state.item = JSON.parse(data);
                    state.loadingData = false;
                    console.log(state.item);
                });
            });
    }

    public render() {
        return this.state.loadingData ? <h1>Loading</h1> :  
        <div className='row'>
            <div className='col-md-12'>
                <div className='row'>
                    <div className='col-md-6'>
                        <h1>{this.state.item.Name}</h1>
                    </div>
                    <div className='col-md-6'>
                            <span className='glyphicon glyphicon-calendar'/> {moment(this.state.item.EventTime).format("DD-MM-YYYY")}
                    </div>
                </div>
                <div className='row'>
                    <div className='col-md-12'>
                        <span>{this.state.item.Messages}</span>
                    </div>
                </div>   
                <div className='row'>
                    <div className='col-md-12'>
                        <span>{this.state.item.StackTrace}</span>
                    </div>
                </div>                         
            </div>
        </div>
    }
}
