import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {MENUITEMS} from '../mock-data/MenuItems';
import {MenuItem} from '../Models/MenuItem';
import {Page} from '../Models/Page';
import Log from '../Models/Log';
import {Observable, of} from "rxjs/index";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
const PageDetail = '/Api/Page/Details';
const LogDetail = '/Api/Log/Detail';

const PageList = '/Api/Page/Pages';
const PostList = '/Api/Page/Posts';
const CreatePost = '/Api/Page/Create';

const MenuList = '/Api/Menu';
const AlbumList = '/Api/Album/List';
const ConfigList = '/Api/Config';
const LogList = '/Api/Log/List';
const VideoList = '/Api/Log/List';


@Injectable()
export class RestService {

  private static log(message: string) {
    console.log(message);
    // this.messageService.add('HeroService: ' + message);
  }

  private static handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getMenuItems(): Observable<MenuItem[]> {
    return of(MENUITEMS);
  }


  createPost<Data>(model: Page): Observable<string> {
    return this.http
      .post<string>(CreatePost, model, httpOptions)
      .pipe(
        tap(_ => RestService.log(`create Post`)),
        catchError(RestService.handleError<string>())
      );
  }

  getPostList<Data>(): Observable<Page[]> {
    return this.http
      .get<Page[]>(PostList)
      .pipe(
        tap(_ => RestService.log(`fetched News`)),
        catchError(RestService.handleError<Page[]>())
      );
  }

  getPageList<Data>(): Observable<Page[]> {
    return this.http
      .get<Page[]>(PageList)
      .pipe(
        tap(_ => RestService.log(`fetched Pages`)),
        catchError(RestService.handleError<Page[]>())
      );
  }

  getPageDetail<Data>(name: string): Observable<Page> {
    const url = `${PageDetail}/${name}`;
    RestService.log(url);
    return this.http
      .get<Page>(url)
      .pipe(
        tap(_ => RestService.log(`fetched Page id=${name}`)),
        catchError(RestService.handleError<Page>())
      );
  }

  getLogList<Data>(): Observable<Log[]> {
    return this.http
      .get<Log[]>(LogList)
      .pipe(
        tap(_ => RestService.log(`fetched Logs`)),
        catchError(RestService.handleError<Log[]>())
      );
  }
  GetVideos<Data>(): Observable<MenuItem[]> {
    return this.http
      .get<MenuItem[]>(VideoList)
      .pipe(
        tap(_ => RestService.log(`fetched Videos`)),
        catchError(RestService.handleError<MenuItem[]>())
      );
  }
  constructor(private http: HttpClient) {
  }


  removePost(page: Page) {

  }

  editPost(page: Page) {

  }
}
