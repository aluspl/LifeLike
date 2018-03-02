import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import Config from '../Models/Config'
import Player from '../Components/Youtube/Player'
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
        return this.state.loadingData? <h1>Loading</h1> :
            <div>
                <div className="jumbotron">
                    <h1 className='display-4'>{this.state.Item.WelcomeText}  </h1>
                </div>
            <p><Player YoutubeId={this.state.Item.WelcomeVideo} /> </p>
            <p>{this.state.Item.Rss1Url} </p>
            <p>{this.state.Item.Rss2Url} </p>

            </div>;
    }
}
