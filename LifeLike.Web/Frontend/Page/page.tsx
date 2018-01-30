import * as ReactDOM from 'react-dom';
import * as React from 'react';

import '../Shared/Styles/helpers.scss';

import ListContainer from './Components/PageContainer';

ReactDOM.render(
    <ListContainer />,
    document.getElementById('react-root')
);

declare var module: any;
if (module.hot) {
    module.hot.accept();
}