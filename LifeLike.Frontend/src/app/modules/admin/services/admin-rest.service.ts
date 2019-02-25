import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {Observable, of} from 'rxjs/index';
import Log from '../models/Log';
import  Config  from '../../../shared/models/Config';
import { RestService } from '../../../shared/services/rest.service';
import  Page  from '../../../shared/models/Page';
import { AppConfig } from '../../../configs/app.config';
import { LoggerService } from 'src/app/core/services/logger.service';


const CreatePost = AppConfig.host + '/Api/Page/Create';
const EditPost = AppConfig.host + '/Api/Page/Edit';

const ConfigList = AppConfig.host + '/Api/Config';
const LogList = AppConfig.host + '/Api/Log/List';


@Injectable()
export class AdminRestService {
  
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



  createPost(model: Page): Observable<string> {
    return this.http
      .post<string>(CreatePost, model, RestService.httpOptions)
      .pipe(
        tap(_ => LoggerService.log(`create Post`)),
        catchError(RestService.handleError<string>())
      );
  }
  getLogList(): Observable<Log[]> {
    return this.http
      .get<Log[]>(LogList)
      .pipe(
        tap(_ => LoggerService.log(`fetched Logs`)),
        catchError(RestService.handleError<Log[]>())
      );
  }
  getPages(): any {
    return this.http
    .get<Log[]>(LogList)
    .pipe(
      tap(_ => LoggerService.log(`fetched PAges`)),
      catchError(RestService.handleError<Log[]>())
    );
  }

  removePost(Id: number) {
      // return this.http.delete()
  }

  editPost(page: Page) {
    return this.http
    .put<Config[]>(ConfigList, page)
    .pipe(
      tap(_ => LoggerService.log(`fetched Configs`)),
      catchError(RestService.handleError<Config[]>())
    );
  }

  getConfigs(): Observable<Config[]> {
    return this.http
      .get<Config[]>(ConfigList)
      .pipe(
        tap(_ => LoggerService.log(`fetched Configs`)),
        catchError(RestService.handleError<Config[]>())
      );
  }
  constructor(private http: HttpClient) {
  }
}
