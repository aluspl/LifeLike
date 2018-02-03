import * as React from 'react';


interface LoadingViewProps {
    Title: string;
}

class LoadingView extends React.Component<any, LoadingViewProps> {

    constructor() {
        super();

        this.state = {
            Title: "Data"
        };
    }
    public render() {
        return (
            <section className='EmptyListWarning'>
                <section className='EmptyListWarning-textContainer'>
                    <p className='text-center'>Loading {this.state.Title}... </p>
                   
                </section>
            </section>
        )
    }
}

export default LoadingView;