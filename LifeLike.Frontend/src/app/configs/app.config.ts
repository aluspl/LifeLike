import { InjectionToken } from '@angular/core';

export let APP_CONFIG = new InjectionToken('app.config');

export const AppConfig: any = {
    routes: {
        admin: 'admin',
        post: 'post',

        error404: '404'
    },
    /**
     *
     */
    host: 'http://localhost',
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
            Controller: 'Photo',
            Name: 'PHOTOS',
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
            Controller: 'Project',
            Name: 'PROJECTS',
            Icon: 'code'
        },
        // {
        //     Id: 5,
        //     Action: '',
        //     Controller: 'Page',
        //     Name: 'PAGES',
        //     Icon: 'code'
        // },
        // {
        //     Id: 6,
        //     Action: 'Contact',
        //     Controller: 'Page',
        //     Name: 'CONTACT',
        //     Icon: 'at',
        // }
    ]
};
