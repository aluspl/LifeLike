import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from '../../../../environments/environment';
import { AppConfig } from '../../../configs/app.config';
import { LoggerService } from '../../../core/services/logger.service';
import { RestService } from '../../../shared/services/rest.service';
import Photo from '../models/Photo';

const PhotoList = environment.API + '/api/Photo';
const PhotoCreate = environment.API + '/api/Photo/Create';

@Injectable()
export class PhotoRestService {

  // getPageList(): Observable<Page[]> {
  //   return this.http
  //     .get<Page[]>(PageList, RestService.httpOptions)
  //     .pipe(
  //       tap(_ => LoggerService.log(`fetched Pages`)),
  //       catchError(RestService.handleError<Page[]>())
  //     );
  // }
PostPhoto(photo: Photo) {
  return this.http
  .post<any>(PhotoCreate, photo, RestService.httpOptions)
  .pipe(
    tap((_) => LoggerService.log('fetched Photos')),
  );
}
GetPhotos(): Observable<Photo[]> {
  return this.http
  .get<Photo[]>(PhotoList, RestService.httpOptions)
  .pipe(
    tap((_) => LoggerService.log('fetched Photos')),
  );
}

  // getPageDetail(name: string): Observable<Page> {
  //   const url = `${PageDetail}/${name}`;
  //   LoggerService.log(url);
  //   return this.http
  //     .get<Page>(url, RestService.httpOptions)
  //     .pipe(
  //       tap(_ => LoggerService.log(`fetched Page id=${name}`)),
  //       catchError(RestService.handleError<Page>())
  //     );
  // }
constructor(private readonly http: HttpClient) {
    console.log(environment);
  }

}
