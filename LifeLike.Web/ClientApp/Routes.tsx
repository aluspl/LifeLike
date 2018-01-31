import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './Layout/Layout';
import { HomeLayout } from './Home/HomeLayout';

import { PostLayout } from "./Page/PostLayout";
import { LogLayout } from './Log/LogLayout';

import { PageLayout } from "./Page/PageLayout";
import {AlbumLayout} from "./Album/AlbumView";

export const routes = 
    <Layout>
        <Route exact path='/' component={ HomeLayout } />
        <Route  path='/Index' component={ HomeLayout } />

        <Route path='/Logs' component={ LogLayout } />
        <Route path='/Posts' component={ PostLayout } />
        <Route path='/Photos' component={ AlbumLayout } />
        <Route path='/Albums' component={ AlbumLayout } />

        <Route path='/Pages' component={ PageLayout } />
    {/*TODO: Logs / Posts and Pages / Details */}
</Layout>;
