import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {Observable, of} from 'rxjs/index';
import Log from 'src/app/shared/models/Log';
import  Config  from 'src/app/shared/models/Config';
import { RestService } from 'src/app/shared/services/rest.service';
import  Page  from 'src/app/shared/models/Page';
import { AppConfig } from 'src/app/configs/app.config';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


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
      .post<string>(CreatePost, model, httpOptions)
      .pipe(
        tap(_ => RestService.log(`create Post`)),
        catchError(RestService.handleError<string>())
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
  getPages(): any {
    return this.http
    .get<Log[]>(LogList)
    .pipe(
      tap(_ => RestService.log(`fetched PAges`)),
      catchError(RestService.handleError<Log[]>())
    );
  }

  removePost(Id: number) {
      // return this.http.delete()
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
  constructor(private http: HttpClient) {
  }
}
