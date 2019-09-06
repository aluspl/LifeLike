import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { map } from 'rxjs/operators';
import Photo from '../../../../modules/photo/models/Photo';
import { ConfirmDeleteComponent } from '../../dialogs/confirm-delete/confirm-delete.component';
import { PhotoCreateComponent } from '../../dialogs/photo-create/photo-create.component';
import { PhotoEditComponent } from '../../dialogs/photo-edit/photo-edit.component';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-admin-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.scss'],
})
export class PhotosComponent implements OnInit {
  Photos: Photo[];
  SelectedPhoto: Photo;
  displayedColumns: string[] = ['Id', 'Title', 'Url', 'Created', 'Actions'];
  IsLoading: boolean;
  IsEditMode: boolean;
  IsCreateMode: boolean;
  error: any;
  constructor(private readonly restService: AdminRestService, private readonly dialog: MatDialog) { }

  Remove(photo: Photo): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = photo.Title;
    dialogConfig.autoFocus = true;
    const dialogRef = this.dialog.open(ConfirmDeleteComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.IsLoading = true;
        this.restService.deletePhoto(photo.Id)
          .subscribe(
            () => {
              this.IsLoading = false;
              this.GetPhotos();
          },
          (error) => {
              this.error = error;
              this.IsLoading = false;
          });
      }
    });
  }
  Edit(photo: Photo): void {

    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = photo;
    dialogConfig.width = '90%';

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    const dialogRef = this.dialog.open(PhotoEditComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      this.GetPhotos();
    });
  }
  Create(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.width = '90%';
    dialogConfig.autoFocus = true;
    const dialogRef = this.dialog.open(PhotoCreateComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      this.GetPhotos();
    });
  }

  GetPhotos(): void {
    this.restService.getPhotos()
      .pipe(
        map((data: Photo[]) => {
          this.IsLoading = false;
          return data;
        }))
      .subscribe((p: Photo[]) => this.Photos = p);
  }
  ngOnInit() {
    this.GetPhotos();
    this.IsEditMode = false;
    this.IsCreateMode = false;
  }

}
