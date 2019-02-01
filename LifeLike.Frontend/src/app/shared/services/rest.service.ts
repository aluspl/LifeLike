import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import MenuItem from '../Models/MenuItem';
import { Observable, of } from 'rxjs/index';
import Video from '../Models/Video';
import Config from '../Models/Config';
import { AppConfig } from '../../configs/app.config';



const ConfigList = AppConfig.host + '/api/Config';
const VideoList = AppConfig.host + '/api/Video/List';


@Injectable()
export class RestService {
  public static log(message: string) {
    console.log(message);
  }

  public static handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

  getMenuItems(): Observable<MenuItem[]> {
    return of(AppConfig.MenuItems);
  }

  GetVideos(): Observable<Video[]> {
    return this.http
      .get<Video[]>(VideoList)
      .pipe(
        tap(_ => RestService.log(`fetched Videos`)),
        catchError(RestService.handleError<Video[]>())
      );
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