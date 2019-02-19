import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs/index';
import MenuItem from '../models/MenuItem';
import Video from '../../modules/video/models/Video';
import Config from '../models/Config';
import { AppConfig } from '../../configs/app.config';
import { LoggerService } from 'src/app/core/services/logger.service';
import UserLogin from '../models/UserLogin';

const ConfigList = AppConfig.host + '/api/Config';
const VideoList = AppConfig.host + '/api/Video/List';
const LoginLink=  AppConfig.host + '/api/Account/Login';

@Injectable()
export class RestService {
  public static httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true
  };

  public static handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
       // TODO: send the error to remote logging infrastructure
       console.error(error); // log to console instead

       // TODO: better job of transforming error for user consumption
       LoggerService.log(`${operation} failed: ${error.message}`);
 
       if (error.status >= 500) {
         throw error;
       }
 
       return of(result as T);
    };
  }

  getMenuItems(): Observable<MenuItem[]> {
    return of(AppConfig.MenuItems);
  }

  GetVideos(): Observable<Video[]> {
    return this.http
      .get<Video[]>(VideoList, RestService.httpOptions)
      .pipe(
        tap(_ => LoggerService.log(`fetched Videos`)),
        catchError(RestService.handleError<Video[]>())
      );
  }
  getConfigs(): Observable<Config[]> {
    return this.http
      .get<Config[]>(ConfigList, RestService.httpOptions )
      .pipe(
        tap(_ => LoggerService.log(`fetched Configs`)),
        catchError(RestService.handleError<Config[]>())
      );
  }
  login(login: UserLogin): Observable<any> {
    return this.http
      .post<any>(LoginLink, {login}, RestService.httpOptions )
      .pipe(
        tap(_ => LoggerService.log(`Login`)),
        catchError(RestService.handleError<any>())
      );
  }
  constructor(private http: HttpClient) {
  }
}