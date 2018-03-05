import * as React from 'react';
import { RouteComponentProps, RouteProps } from 'react-router';
import Item from "../Models/MenuItem";
import LoadingView from "../Components/Loading/LoadingView";
import EmptyListView from "../Components/EmptyList/EmptyListView";
import ListView from "../Components/VideoList/ListView";

interface  VideoLayoutProps{
    
}
interface ListContainerState {
    loadingData: boolean,
    items: Item[]
}
export class VideoLayout extends React.Component<RouteComponentProps<VideoLayoutProps>, ListContainerState> {
    constructor(props: RouteComponentProps<VideoLayoutProps>, state: ListContainerState){
        super(props, state);
        this.state = {
            loadingData: true,
            items: []
        };
    }
    private paths = {
        getList: '/Api/Video/'
    };

    public componentDidMount() {
        fetch(this.paths.getList, {
            credentials: 'include' })
            .then((response) => {
                return response.text();
            })
            .then((data) => {
                this.setState({
                    items: JSON.parse(data),
                    loadingData: false
                });
            });
    }
    
    public render() {
        const hasProjects = this.state.items.length > 0;

        return <section className="resume-section">
            <div className="subheading">
               VIDEOS
            </div>
            {
                this.state.loadingData ?
                    <LoadingView Title={"Videos"}/> :
                    hasProjects ?
                        <ListView items={this.state.items}/> :  <EmptyListView Title={"Videos"}/>
            }
        </section>;
    }
}
