import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

import { MENUITEMS } from './mock-data/MenuItems';
import { MenuItem } from './Models/MenuItem';
import Page from './Models/Page';
import Log from './Models/Log';

@Injectable()
export class RestService {
  PageDetail: '/Api/Page/Details/';
  PageList: '/Api/Page/Pages';
  PostList: '/Api/Page/Posts';
  MenuList: '/Api/Menu';
  AlbumList: '/Api/Album/List';
  ConfigList: '/Api/Config';
  LogList: '/Api/Log/List';


  getMenuItems(): Observable<MenuItem[]> {
    return of(MENUITEMS);
  }
  getPostList(): Observable<Page[]> {
    return this.http.get<Page[]>(this.PostList);
  }
  getPageList(): Observable<Page[]> {
    return this.http.get<Page[]>(this.PageList);
  }
  getPageDetail(name: string): Observable<Page> {
    return this.http.get<Page>(this.PageDetail.concat(name));
  }
  getLogList(name: string): Observable<Log[]> {
    return this.http.get<Log[]>(this.LogList);
  }
  constructor(private http: HttpClient) { }

}
