import * as React from 'react';


interface LoadingViewProps {
    Title: string;
}

class LoadingView extends React.Component<LoadingViewProps, any> {

    constructor(props: LoadingViewProps) {
        super(props);
        
    }
    public render() {
        return (
            <div className="jumbotron">
                <p className="lead">Loading</p>
            </div>
        )
    }
}

export default LoadingView;