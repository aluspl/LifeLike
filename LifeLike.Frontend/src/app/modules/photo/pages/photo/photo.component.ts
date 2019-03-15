import { Component, OnInit } from '@angular/core';
import Photo from '../../models/Photo';
import { map } from 'rxjs/operators';
import { PhotoRestService } from '../../services/photo-rest.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { PhotoDetailComponent } from '../../components/album-detail/photo-detail.component';

@Component({
  selector: 'app-photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.scss']
})
export class PhotoComponent implements OnInit {
  IsLoading: boolean;
  Photos: Photo[];
  CurrentPhoto: Photo;
  constructor(private restService: PhotoRestService, public dialog: MatDialog) { }
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
    this.CurrentPhoto = photo;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = photo;
    dialogConfig.width = '90%';
    dialogConfig.height = '90%';
    dialogConfig.autoFocus = true;
    this.dialog.open(PhotoDetailComponent, dialogConfig )
  }
  ngOnInit() {
    this.GetPhotos();
  }

}
