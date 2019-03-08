import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {Observable, of} from 'rxjs/index';
import { RestService } from '../../../shared/services/rest.service';
import  Page  from '../../../shared/models/Page';
import { AppConfig } from '../../../configs/app.config';
import { LoggerService } from '../../../core/services/logger.service';
import { environment } from '../../../../environments/environment';



const PageDetail = environment.API + '/api/Page/Details';
const ProjectList = environment.API + '/api/Page/Projects';
const PostList = environment.API + '/api/Page/Posts';
const PageList = environment.API + '/api/Page/All';



@Injectable()
export class PostRestService {
 
  getPostList(PostType: string): Observable<Page[]> {
    var link = null;
    switch(PostType)
    {
      case "Projects":
      {
        link = ProjectList;
        break;
      }
      case "Pages":
      {
        link = PageList;
        break;
      }
      case "Posts":
      {
        link = PostList;
        break;
      }
    }
    return this.http
      .get<Page[]>(link, RestService.httpOptions)
      .pipe(
        tap(_ => LoggerService.log("Fetched "+PostType)),
        catchError(RestService.handleError<Page[]>())
      );
  }

  getPageList(): Observable<Page[]> {
    return this.http
      .get<Page[]>(PageList, RestService.httpOptions)
      .pipe(
        tap(_ => LoggerService.log(`fetched Pages`)),
        catchError(RestService.handleError<Page[]>())
      );
  }

  getPageDetail(name: string): Observable<Page> {
    const url = `${PageDetail}/${name}`;
    LoggerService.log(url);
    return this.http
      .get<Page>(url, RestService.httpOptions)
      .pipe(
        tap(_ => LoggerService.log(`fetched Page id=${name}`)),
        catchError(RestService.handleError<Page>())
      );
  }
  constructor(private http: HttpClient) {
    console.log(environment);
  }
  
}
