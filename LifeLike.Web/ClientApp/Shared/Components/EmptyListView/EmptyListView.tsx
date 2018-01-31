import * as React from 'react';

import './style.scss';

class EmptyListView extends React.Component<any, any> {

    public render() {
        return (
            <section className='EmptyListWarning'>
                <section className='EmptyListWarning-textContainer'>
                    <p className='text-center'>Empty List :(</p>
                   
                </section>
            </section>
        )
    }
}

export default EmptyListView;