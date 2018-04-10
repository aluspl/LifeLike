import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { MENUITEMS } from '../mock-data/MenuItems';
import { MenuItem } from '../Models/MenuItem';
import { Page } from '../Models/Page';
import Log from '../Models/Log';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
const PageDetail = '/Api/Page/Details/';
const PageList = '/Api/Page/Pages';
const PostList = '/Api/Page/Posts';
const MenuList = '/Api/Menu';
const  AlbumList = '/Api/Album/List';
  const ConfigList = '/Api/Config';
  const LogList = '/Api/Log/List';

@Injectable()
export class RestService {


  getMenuItems(): Observable<MenuItem[]> {
    return of(MENUITEMS);
  }
  getPostList(): Observable<Page[]> {
    return this.http.get<Page[]>(PostList).pipe(
      tap(_ => this.log(`fetched News`)),
      catchError(this.handleError<Page[]>(PostList))
    );
  }
  getPageList(): Observable<Page[]> {
    return this.http.get<Page[]>(PageList)
    .pipe(
      tap(_ => this.log(`fetched Pages`)),
      catchError(this.handleError<Page[]>(PageList))
    );
  }
  getPageDetail(name: string): Observable<Page> {
    const list = PageDetail.concat(name);
    return this.http.get<Page>(list)
    .pipe(
      tap(_ => this.log(`fetched Page id=${name}`)),
      catchError(this.handleError<Page>(list))
    );
  }
  getLogList(): Observable<Log[]> {
    return this.http.get<Log[]>(LogList).pipe(
      tap(_ => this.log(`fetched Logs`)),
      catchError(this.handleError<Log[]>(LogList))
    );
  }


  private handleError<T> (operation = 'operation', result?: T) {
    return (error: string): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
this.log(error);
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
