import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders, HttpRequest, HttpEventType, HttpResponse} from '@angular/common/http';
import {catchError, tap} from 'rxjs/operators';
import {Observable, of, Subject} from 'rxjs/index';
import Log from '../models/Log';
import  Config  from '../../../shared/models/Config';
import { RestService } from '../../../shared/services/rest.service';
import  Page  from '../../../shared/models/Page';
import { AppConfig } from '../../../configs/app.config';
import { LoggerService } from '../../../core/services/logger.service';
import Photo from '../../photo/models/Photo';
import FileUpload from '../models/FileUpload';
import { environment } from '../../../../environments/environment';


const CreatePost = environment.API + '/Api/Page';

const AllPost = environment.API + '/Api/Page/All';

const ConfigApi = environment.API + '/Api/Config';
const LogList = environment.API + '/Api/Log/List';
const PhotoApi = environment.API + '/Api/Photo';
const CreatePhotoApi = environment.API + '/Api/Photo/Create';


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
  createPhoto(file: FileUpload){    
    const formData: FormData = new FormData();
    formData.append(file.PhotoStream.name, file.PhotoStream);
    formData.append('Name', file.Name);
    formData.append('Camera', file.Camera);
    formData.append('City', file.City);
    formData.append('Tags', file.Tags);

    
    const req = new HttpRequest('POST', CreatePhotoApi, formData, {
      reportProgress: true
    });

    return this.http.request(req);
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
        tap(_ => LoggerService.log(`Get Configs`))
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
