import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {Observable, of} from 'rxjs/index';
import { RestService } from 'src/app/shared/services/rest.service';
import { Page } from 'src/app/shared/models/Page';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

const host = "http://localhost:5000";
const PageDetail = host + '/Api/Page/Details';

const PageList = host + '/Api/Page/Pages';
const PostList = host + '/Api/Page/Posts';



@Injectable()
export class PostRestService {
 
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

  
  constructor(private http: HttpClient) {
  }
  
}
