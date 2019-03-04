import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import Page from '../../../../shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';
import Photo from 'src/app/modules/photo/models/Photo';

@Component({
  selector: 'app-admin-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.scss']
})
export class PhotosComponent implements OnInit {
  Photos: Photo[];
  IsLoading: boolean;
  error: any;
  constructor(private restService: AdminRestService) { }

  Remove(photo: Photo): void {
    console.log('Remove');
    console.log(photo);
    this.IsLoading= true;
    this.restService.deletePhoto(photo.Id)
      .subscribe(
        data => {
          this.IsLoading = false;
          this.GetPhotos();
      },
      error => {
          this.error = error;
          this.IsLoading = false;
      });
  }
  GetPhotos(): void {
    this.restService.getPhotos()
      .pipe(
        map((data: Photo[]) => {
          this.IsLoading = false;
          console.log(data);
          return data;
        }))
      .subscribe((p: Photo[]) => this.Photos = p);
  }
  ngOnInit() {
    this.GetPhotos();
  }

}
