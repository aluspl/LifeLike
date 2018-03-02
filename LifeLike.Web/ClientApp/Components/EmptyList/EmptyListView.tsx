import * as React from 'react';

interface LoadingViewProps {
    Title: string;
}

class EmptyListView extends React.Component<LoadingViewProps, any> {

    public render() {
        return (
            <div className="jumbotron">
                <p className="lead">Empty List</p>
            </div>
        )
    }
}

export default EmptyListView;