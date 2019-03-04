import { Component, OnInit } from '@angular/core';
import Photo from '../../models/Photo';
import { map } from 'rxjs/operators';
import { PhotoRestService } from '../../services/photo-rest.service';

@Component({
  selector: 'app-photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.scss']
})
export class PhotoComponent implements OnInit {
  IsLoading: boolean;
  IsOpen: boolean;
  Photos: Photo[];
  CurrentPhoto: Photo;
  constructor(private restService: PhotoRestService) { }
  GetPhotos() {
    this.IsLoading = true;
    this.restService.GetPhotos()
      .pipe(
        map((data: Photo[]) => {
          this.IsLoading = false;
          console.log(data);
          return data;
        }))
      .subscribe((p: Photo[]) => this.Photos = p);
  }
  OpenPhoto(photo: Photo)
  {
    this.IsOpen = true;
    this.CurrentPhoto = photo;
  }
  ngOnInit() {
    this.IsOpen = false;
    this.GetPhotos();
  }

}
