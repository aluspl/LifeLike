import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { AdminRestService } from '../../services/admin-rest.service';
import Photo from '../../../../modules/photo/models/Photo';
import { PhotoCreateComponent } from '../photo-create/photo-create.component';
import { MatDialogConfig, MatDialog } from '@angular/material';

@Component({
  selector: 'app-admin-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.scss']
})
export class PhotosComponent implements OnInit {
  Photos: Photo[];
  SelectedPhoto: Photo;
  displayedColumns: string[] = ['Id', 'Title', 'Url', 'Created','Actions'];
  IsLoading: boolean;
  IsEditMode: boolean;
  IsCreateMode: boolean;
  error: any;
  constructor(private restService: AdminRestService, private dialog: MatDialog) { }

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
  Edit(photo: Photo): void {
    console.log('Edit');
    console.log(photo);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = photo;
    dialogConfig.width = '90%';
    dialogConfig.height = '90%';
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
   this.dialog.open(PhotoCreateComponent, dialogConfig );
  }
  Create() : void {
    console.log('Create');
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '90%';
    dialogConfig.height = '90%';
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
   this.dialog.open(PhotoCreateComponent, dialogConfig );
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
    this.IsEditMode=false;
    this.IsCreateMode=false;
  }

}
