import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import EmptyListView from "../Components/EmptyList/EmptyListView";
import LoadingView from "../Components/Loading/LoadingView";
import ListView from "../Components/AlbumList/ListView";
import Item from "../Models/Album";

interface  Props extends RouteComponentProps<any> {
    
}
interface State {
    loadingData: boolean,
    items: Item[]
}
export class AlbumLayout extends React.Component<Props, State> {
    constructor(props: Props, state: State) {
        super(props, state);
        this.state = {
            loadingData: true,
            items: []
        };
    }

    private paths = {
        getList: '/Api/Album/List'
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
        const hasItems = this.state.items.length > 0;

        return <section className="resume-section">
            <div className="subheading">
               ALBUMS
            </div>
            {
                this.state.loadingData ?
                    <LoadingView Title={'Albums'}/> :
                    hasItems ?
                        <ListView items= {this.state.items} /> :  <EmptyListView Title={"Album"} />
            }
        </section>;
    }
}
