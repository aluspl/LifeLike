import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { MENUITEMS } from './mock-data/MenuItems';
import { MenuItem } from './Models/MenuItem';

@Injectable()
export class RestService {
  PageDetail: '/Api/Page/Details/';
  PageList: '/Api/Page/Pages/';
  PostList: '/Api/Page/Posts';
  MenuList: '/Api/Menu/';
  AlbumList: '/Api/Album/List';
  ConfigList: '/Api/Config';
  LogList: '/Api/Log/List';


  getMenuItems(): Observable<MenuItem[]> {
    return of(MENUITEMS);

  }
  constructor() { }

}
