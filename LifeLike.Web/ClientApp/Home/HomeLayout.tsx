import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import Config from '../Models/Config'
interface IHomeState{
  Item: Config,
  loadingData: boolean

}
export class HomeLayout extends React.Component<RouteComponentProps<{}>, IHomeState> {
    constructor() {
        super();
        this.state = { Item: new Config, loadingData: true };
    }
    private paths = {
        getList: '/Api/Config'
    };   
    public componentDidMount() {
        fetch(this.paths.getList, { 
            credentials: 'include' })
            .then((response) => {
                return response.text();
            })
            .then((data) => {
                this.setState((state, props) => {
                    state.Item = JSON.parse(data);
                    state.loadingData = false;
                    console.log(state.Item);
                });
            });
    }
    public render() {
        return <div>
            <h1>{this.state.loadingData ? 'Welcome' : this.state.Item.WelcomeText} </h1>
            <p>{this.state.loadingData ? '' : this.state.Item.WelcomeVideo} </p>
            <p>{this.state.loadingData ?  '' : this.state.Item.Rss1Url} </p>
            <p>{this.state.loadingData ? '' : this.state.Item.Rss2Url} </p>

            </div>;
    }
}
