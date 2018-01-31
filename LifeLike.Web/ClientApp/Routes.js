import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './Layout/Layout';
import { HomeLayout } from './Home/HomeLayout';
import { PostLayout } from "./Page/PostLayout";
import { LogLayout } from './Log/LogLayout';
import { PageLayout } from "./Page/PageLayout";
import { AlbumLayout } from "./Album/AlbumView";
export var routes = React.createElement(Layout, null,
    React.createElement(Route, { exact: true, path: '/', component: HomeLayout }),
    React.createElement(Route, { path: '/Index', component: HomeLayout }),
    React.createElement(Route, { path: '/Logs', component: LogLayout }),
    React.createElement(Route, { path: '/Posts', component: PostLayout }),
    React.createElement(Route, { path: '/Photos', component: AlbumLayout }),
    React.createElement(Route, { path: '/Albums', component: AlbumLayout }),
    React.createElement(Route, { path: '/Pages', component: PageLayout }));
//# sourceMappingURL=routes.js.map