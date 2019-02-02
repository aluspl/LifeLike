import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs/index';
import MenuItem from '../models/MenuItem';
import Video from '../../modules/video/models/Video';
import Config from '../models/Config';
import { AppConfig } from '../../configs/app.config';

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
      console.error(error);
      return new Observable<any>();
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