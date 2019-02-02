import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {Observable, of} from 'rxjs/index';
import { RestService } from '../../../shared/services/rest.service';
import  Page  from '../../../shared/models/Page';
import { AppConfig } from '../../../configs/app.config';



const PageDetail = AppConfig.host + '/api/Page/Details';

const PageList = AppConfig.host + '/api/Page/Pages';
const PostList = AppConfig.host + '/api/Page/Posts';



@Injectable()
export class PostRestService {
 
  getPostList(): Observable<Page[]> {
    return this.http
      .get<Page[]>(PostList, RestService.httpOptions)
      .pipe(
        tap(_ => RestService.log(`fetched News`)),
        catchError(RestService.handleError<Page[]>())
      );
  }

  getPageList(): Observable<Page[]> {
    return this.http
      .get<Page[]>(PageList, RestService.httpOptions)
      .pipe(
        tap(_ => RestService.log(`fetched Pages`)),
        catchError(RestService.handleError<Page[]>())
      );
  }

  getPageDetail(name: string): Observable<Page> {
    const url = `${PageDetail}/${name}`;
    RestService.log(url);
    return this.http
      .get<Page>(url, RestService.httpOptions)
      .pipe(
        tap(_ => RestService.log(`fetched Page id=${name}`)),
        catchError(RestService.handleError<Page>())
      );
  }
  constructor(private http: HttpClient) {
  }
  
}
