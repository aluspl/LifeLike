import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {of} from 'rxjs/observable/of';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {MENUITEMS} from '../mock-data/MenuItems';
import {MenuItem} from '../Models/MenuItem';
import {Page} from '../Models/Page';
import Log from '../Models/Log';

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

@Injectable()
export class RestService {


  private static handleError(error: Response | any) {
    console.error('ApiService::handleError', error);
    return Observable.throw(error);
  }
  getMenuItems(): Observable<MenuItem[]> {
    return of(MENUITEMS);
  }

  private static log(message: string) {
    console.log(message);
    // this.messageService.add('HeroService: ' + message);
  }

  createPost(model: Page): Observable<string> {
    return this.http
      .post<string>(CreatePost, model, httpOptions)
      .pipe(
        tap(_ => RestService.log(`create Post`)),
        catchError(RestService.handleError)
      );
  }

  getPostList(): Observable<Page[]> {
    return this.http
      .get<Page[]>(PostList)
      .pipe(
        tap(_ => RestService.log(`fetched News`)),
        catchError(RestService.handleError)
    );
  }

  getPageList(): Observable<Page[]> {
    return this.http
      .get<Page[]>(PageList)
      .pipe(
        tap(_ => RestService.log(`fetched Pages`)),
        catchError(RestService.handleError)
    );
  }

  getPageDetail(name: string): Observable<Page> {
    const url = `${PageDetail}/${name}`;

    RestService.log(url);
    return this.http
      .get<Page>(url)
      .pipe(
        tap(_ => RestService.log(`fetched Page id=${name}`)),
        catchError(RestService.handleError)
    );
  }

  getLogList(): Observable<Log[]> {
    return this.http
      .get<Log[]>(LogList)
      .pipe(
        tap(_ => RestService.log(`fetched Logs`)),
        catchError(RestService.handleError)
    );
  }
  constructor(private http: HttpClient) { }

}
