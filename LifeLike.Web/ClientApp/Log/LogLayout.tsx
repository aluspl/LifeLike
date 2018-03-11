import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import Item from "../Models/Log";
import LoadingView from "../Components/Loading/LoadingView";
import ListView from "../Components/LogList/LogList";
import EmptyListView from "../Components/EmptyList/EmptyListView";

interface State {
    loadingData: boolean,
    items: Item[]
}
interface  Props extends RouteComponentProps<any> {
}
export class LogLayout extends React.Component<Props, State> {
    constructor(props: RouteComponentProps<{}>, state: State) {
        super(props, state);
        this.state = {
            loadingData: true,
            items: []
        };
    }
    private paths = {
        getList: '/Api/Log/List'
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
               LOGS
            </div>
            {
                this.state.loadingData ?
                    <LoadingView Title={'Logs'}/> :
                    hasItems ?
                        <ListView items= {this.state.items} /> :  <EmptyListView  Title={"Logs"}  />
            }
        </section>
    }
}
