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
import Photo from '../../photo/models/Photo';


const CreatePost = AppConfig.host + '/Api/Page';

const AllPost = AppConfig.host + '/Api/Page/All';

const ConfigApi = AppConfig.host + '/Api/Config';
const LogList = AppConfig.host + '/Api/Log/List';
const PhotoApi = AppConfig.host + '/Api/Photo';


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
  getPages(): Observable<Page[]> {
    return this.http
    .get<Page[]>(AllPost)
    .pipe(
      tap(_ => LoggerService.log(`fetched PAges`))
    );
  }

  removePost(id: number) {
    const url = `${CreatePost}/${id}`; 
    return this.http
      .delete(url, RestService.httpOptions)
      .pipe(
        tap(_ => LoggerService.log(`Remove Post`))
      );
  }

  editPost(page: Page) {
    return this.http
    .put<string>(CreatePost, page)
    .pipe(
      tap(_ => LoggerService.log(`fetched Configs`)),
    );
  }
  getPhotos(): Observable<Photo[]> {
    return this.http
    .get<Photo[]>(PhotoApi, RestService.httpOptions)
    .pipe(
      tap(_ => LoggerService.log(`fetched Photos`))
    );
  }
  createPhoto(photo: Photo) {
    return this.http
    .post<Photo[]>(PhotoApi, RestService.httpOptions)
    .pipe(
      tap(_ => LoggerService.log(`fetched Photos`))
    );
  }
  editPhoto(photo: Photo) {
    return this.http
    .put<string>(PhotoApi, photo, RestService.httpOptions)
    .pipe(
      tap(_ => LoggerService.log(`Edit Photo`)),
    );
  }
  deletePhoto(id: string) {
    const url = `${PhotoApi}/${id}`; 
    return this.http
      .delete(url, RestService.httpOptions)
      .pipe(
        tap(_ => LoggerService.log(`Delete Photo`))
      );
  }

  getConfigs(): Observable<Config[]> {
    return this.http
      .get<Config[]>(ConfigApi)
      .pipe(
        tap(_ => LoggerService.log(`Get Configs`)),
        catchError(RestService.handleError<Config[]>())
      );
  }
  editConfig(config: Config) {
    return this.http
    .put<string>(ConfigApi, config, RestService.httpOptions)
    .pipe(
      tap(_ => LoggerService.log(`Edit Config`)),
    );
  }
  deleteConfig(id: number) {
    const url = `${ConfigApi}/${id}`; 
    return this.http
      .delete(url, RestService.httpOptions)
      .pipe(
        tap(_ => LoggerService.log(`Delete Config`))
      );
  }

  constructor(private http: HttpClient) {
  }
}
