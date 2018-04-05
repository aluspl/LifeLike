import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { MENUITEMS } from '../mock-data/MenuItems';
import { MenuItem } from '../Models/MenuItem';
import { Page } from '../Models/Page';
import Log from '../Models/Log';


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
    return this.http.get<Page[]>(this.PostList).pipe(
      tap(_ => this.log(`fetched News`)),
      catchError(this.handleError<Page[]>(this.PostList, []))
    );
  }
  getPageList(): Observable<Page[]> {
    return this.http.get<Page[]>(this.PageList)
    .pipe(
      tap(_ => this.log(`fetched Pages`)),
      catchError(this.handleError<Page[]>(this.PageList, []))
    );
  }
  getPageDetail(name: string): Observable<Page> {
    const link = this.PageDetail.concat(name);
    return this.http.get<Page>(link)
    .pipe(
      tap(_ => this.log(`fetched Page id=${name}`)),
      catchError(this.handleError<Page>(this.PageDetail))
    );
  }
  getLogList(): Observable<Log[]> {
    return this.http.get<Log[]>(this.LogList).pipe(
      tap(_ => this.log(`fetched Logs`)),
      catchError(this.handleError<Log[]>(this.LogList, []))
    );
  }


  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  private log(message: string) {
    console.log(message);
    // this.messageService.add('HeroService: ' + message);
  }
  constructor(private http: HttpClient) { }

}
