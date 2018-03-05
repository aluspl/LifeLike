import * as React from 'react';

interface LoadingViewProps {
    Title: string;
}

class EmptyListView extends React.Component<LoadingViewProps, any> {

    public render() {
        return (
            <div className="subheading">
                Empty List
            </div>
        )
    }
}

export default EmptyListView;