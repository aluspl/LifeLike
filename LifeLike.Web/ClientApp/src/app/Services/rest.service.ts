import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {MENUITEMS} from '../mock-data/MenuItems';
import {MenuItem} from '../Models/MenuItem';
import {Page} from '../Models/Page';
import Log from '../Models/Log';
import {Observable, of} from 'rxjs/index';
import Video from '../Models/Video';
import {Config} from '../Models/Config';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
const PageDetail = '/Api/Page/Details';

const PageList = '/Api/Page/Pages';
const PostList = '/Api/Page/Posts';
const CreatePost = '/Api/Page/Cr';

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


  createPost(model: Page): Observable<string> {
    return this.http
      .post<string>(CreatePost, model, httpOptions)
      .pipe(
        tap(_ => RestService.log(`create Post`)),
        catchError(RestService.handleError<string>())
      );
  }

  getPostList(): Observable<Page[]> {
    return this.http
      .get<Page[]>(PostList)
      .pipe(
        tap(_ => RestService.log(`fetched News`)),
        catchError(RestService.handleError<Page[]>())
      );
  }

  getPageList(): Observable<Page[]> {
    return this.http
      .get<Page[]>(PageList)
      .pipe(
        tap(_ => RestService.log(`fetched Pages`)),
        catchError(RestService.handleError<Page[]>())
      );
  }

  getPageDetail(name: string): Observable<Page> {
    const url = `${PageDetail}/${name}`;
    RestService.log(url);
    return this.http
      .get<Page>(url)
      .pipe(
        tap(_ => RestService.log(`fetched Page id=${name}`)),
        catchError(RestService.handleError<Page>())
      );
  }

  getLogList(): Observable<Log[]> {
    return this.http
      .get<Log[]>(LogList)
      .pipe(
        tap(_ => RestService.log(`fetched Logs`)),
        catchError(RestService.handleError<Log[]>())
      );
  }
  GetVideos(): Observable<Video[]> {
    return this.http
      .get<Video[]>(VideoList)
      .pipe(
        tap(_ => RestService.log(`fetched Videos`)),
        catchError(RestService.handleError<Video[]>())
      );
  }
  constructor(private http: HttpClient) {
  }


  removePost() {

  }

  editPost() {

  }

  getConfigs(): Observable<Config[]> {
    return this.http
      .get<Config[]>(ConfigList)
      .pipe(
        tap(_ => RestService.log(`fetched Configs`)),
        catchError(RestService.handleError<Config[]>())
      );
  }
}
