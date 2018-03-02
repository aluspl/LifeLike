import * as React from 'react';
import Item from '../../Models/Page';
import LoadingView from '../../Components/Loading/LoadingView';


interface IPostDetailLayout {
    loadingData: boolean,
    Item: Item, 
}
interface IPostDetailProps {
    Shortname: string
}
  class PostDetailView extends React.Component<IPostDetailProps, IPostDetailLayout> {   
    constructor(props: IPostDetailProps) {
        super(props);
        console.log(this.props);

        this.state = {
            loadingData: true, 
            Item:new Item,
        };
        console.log(this.state);
    }    
    private paths = {
        getList: '/Api/Page/Details/'
    };
    public componentDidMount() {
        let path=this.paths.getList.concat(this.props.Shortname)
        console.log(path);

        fetch(path, { 
            credentials: 'include' })
            .then((response) => {
                return response.text();
            })
            .then((data) => {
                this.setState((state, props) => {
                    console.log("JSON: "+data);
                    state.Item = JSON.parse(data);
                    state.loadingData = false;
                    console.log(state.Item);
                });
            });
    }
    public render() {
        return  this.state.loadingData ?  <LoadingView Title="Post"/> : 
             <div>            
                <h1>{this.state.Item.FullName}</h1>
                <h2>{this.state.Item.ShortName}</h2>
                <p> {this.state.Item.Content}</p>
                <p>{this.state.Item.Category}</p>
            </div>
    }
}
export default PostDetailView;