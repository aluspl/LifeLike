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
                <div className="subheading">
                    Loading..
                </div>
        )
    }
}

export default LoadingView;