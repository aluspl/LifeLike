import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs/index';
import MenuItem from '../models/MenuItem';
import Video from '../../modules/video/models/Video';
import Config from '../models/Config';
import { AppConfig } from '../../configs/app.config';
import { LoggerService } from 'src/app/core/services/logger.service';

const ConfigList = AppConfig.host + '/api/Config';
const VideoList = AppConfig.host + '/api/Video/List';


@Injectable()
export class RestService {
  public static httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true
  };
  public static log(message: string) {
    console.log(message);
  }

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
        tap(_ => RestService.log(`fetched Videos`)),
        catchError(RestService.handleError<Video[]>())
      );
  }
  getConfigs(): Observable<Config[]> {
    return this.http
      .get<Config[]>(ConfigList, RestService.httpOptions )
      .pipe(
        tap(_ => RestService.log(`fetched Configs`)),
        catchError(RestService.handleError<Config[]>())
      );
  }

  constructor(private http: HttpClient) {
  }
}