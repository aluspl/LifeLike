import * as React from 'react';
import {RouteComponentProps, RouteProps} from 'react-router';
import Item from "../Models/Page";
import EmptyListView from "../Components/EmptyList/EmptyListView";
import ListView from "../Components/PageList/ListView";
import LoadingView from "../Components/Loading/LoadingView";

interface  Props extends RouteComponentProps<any>{
    shortname: string;
}


interface IPostState {
    loadingData: boolean,
    items: Item[]
}

export class PostLayout extends React.Component<Props, IPostState> {
    constructor(props:Props, state: IPostState) {
        super(props, state);
        this.state = {
            loadingData: true,
            items: []
        };
    }

    private paths = {
        getList: '/Api/Page/Posts'
    };

    public componentDidMount() {
        fetch(this.paths.getList, {
            credentials: 'include'
        })
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

        return (
            <section className="resume-section">
                    <div className="subheading">
                      News
                    </div>
                {
                    this.state.loadingData ?                  
                        <LoadingView Title={"News"}/> :
                    hasProjects ? 
                        <ListView items={this.state.items}/> : <EmptyListView Title={"News"}/>
                }
            </section>
        );
    }
}
