import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import Config from '../Models/Config'
import Player from '../Components/Youtube/Player'
import LoadingView from "../Components/Loading/LoadingView";
interface IHomeState{
  Item: Config,
  loadingData: boolean

}
export class HomeLayout extends React.Component<RouteComponentProps<{}>, IHomeState> {
    constructor(props:RouteComponentProps<{}>) {
        super(props);
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
                this.setState({
                    Item: JSON.parse(data),
                    loadingData: false
                });
            });
    }
    public render() {
            return (
                <section className="resume-section">
                {
                    this.state.loadingData ? <LoadingView Title="Main Page"/> :
                        <div className="subheading">
                            LifeLike: {this.state.Item.WelcomeText}

                            <Player YoutubeId={this.state.Item.WelcomeVideo} />

                        </div>
                }
                {/*<p>{this.state.Item.Rss1Url} </p>*/}
                {/*<p>{this.state.Item.Rss2Url} </p>*/}
                
            </section>)
    }
}
