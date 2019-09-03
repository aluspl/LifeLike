import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs/index';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { AppConfig } from '../../configs/app.config';
import { LoggerService } from '../../core/services/logger.service';
import Video from '../../modules/video/models/Video';
import Config from '../models/Config';
import MenuItem from '../models/MenuItem';
import UserLogin from '../models/UserLogin';
import UserRegister from '../models/UserRegister';

const ConfigList = environment.API + '/api/Config';
const VideoList = environment.API + '/api/Video';
const LoginLink = environment.API + '/api/Account/Login';
const RegisterLink = environment.API + '/api/Account/Register';

@Injectable()
export class RestService {

  static httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };

  static handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      LoggerService.log(`${operation} failed: ${error.message}`);

      // if (error.status >= 500) {
      //   throw error;
      // }
      return of(result);
    };
  }

  getMenuItems(): Observable<MenuItem[]> {
    return of(AppConfig.MenuItems);
  }

  GetVideos(): Observable<Video[]> {
    return this.http
      .get<Video[]>(VideoList, RestService.httpOptions)
      .pipe(
        tap((_) => LoggerService.log('fetched Videos')),
      );
  }
  getConfigs(): Observable<Config[]> {
    return this.http
      .get<Config[]>(ConfigList, RestService.httpOptions)
      .pipe(
        tap((_) => LoggerService.log('fetched Configs')),
        catchError(RestService.handleError<Config[]>()),
      );
  }
  login(login: UserLogin): Observable<UserLogin> {
    return this.http
      .post<UserLogin>(LoginLink, login, RestService.httpOptions)
      .pipe(
        tap((_) => LoggerService.log('Login')),
      );
  }
  register(user: UserRegister): Observable<UserLogin> {
    return this.http
      .post<UserLogin>(RegisterLink, user, RestService.httpOptions)
      .pipe(
        tap((_) => LoggerService.log('Register')),
      );
  }
  constructor(private readonly http: HttpClient) {
  }
}
