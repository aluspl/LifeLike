import {InjectionToken} from '@angular/core';
import { MenuItem } from "../shared/models/MenuItem";

export let APP_CONFIG = new InjectionToken('app.config');

export const AppConfig: any = {
  routes: {
    admin: 'admin',
    post: 'post',

    error404: '404'
  },
  votesLimit: 3,
  topHeroesLimit: 4,
  snackBarDuration: 3000,
  host: 'localhost:5000',
  MenuItems: [
    {
       Id: 1,
       Action: '',
       Controller: 'Post',
       Name: 'NEWS',
       Icon: 'newspaper'
    },
    {
       Id: 2,
       Action: '',
       Controller: 'Album',
       Name: 'ALBUMS',
       Icon: 'camera-retro',
   },
   {
       Id: 3,
       Action: '',
       Controller: 'Video',
       Name: 'VIDEOS',
       Icon: 'film',
   },
   {
       Id: 4,
       Action: '',
       Controller: 'Page',
       Name: 'PROJECTS',
       Icon: 'code'
   },
   {
       Id: 6,
       Action: 'Contact',
       Controller: 'Page',
       Name: 'CONTACT',
       Icon: 'at',
   },
   {
       Id: 7,
       Action: '',
       Controller: 'Login',
       Name: 'LOGIN',
       Icon: 'sign-in-alt',
   }
   ]
};
