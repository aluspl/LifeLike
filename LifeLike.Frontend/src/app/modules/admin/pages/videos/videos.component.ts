import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { AdminRestService } from '../../services/admin-rest.service';
import Photo from '../../../photo/models/Photo';
import { PhotoCreateComponent } from '../photo-create/photo-create.component';
import { MatDialogConfig, MatDialog } from '@angular/material';
import Video from '../../../../modules/video/models/Video';
import { VideoCreateComponent } from '../videos-create/video-create.component';

@Component({
  selector: 'app-admin-videos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.scss']
})
export class VideosComponent implements OnInit {
  Videos: Video[];
  displayedColumns: string[] = ['Id', 'Title', 'Url', 'Created', 'Actions'];
  IsLoading: boolean;
  IsEditMode: boolean;
  IsCreateMode: boolean;
  error: any;
  constructor(private restService: AdminRestService, private dialog: MatDialog) { }

  Remove(photo: Photo): void {
    console.log('Remove');
    console.log(photo);
    this.IsLoading = true;
    this.restService.deletePhoto(photo.Id)
      .subscribe(
        data => {
          this.IsLoading = false;
          this.GetVideos();
        },
        error => {
          this.error = error;
          this.IsLoading = false;
        });
  }
  Edit(model: Video): void {
    console.log('Edit');
    console.log(model);
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = model;
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    let dialogRef = this.dialog.open(VideoCreateComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.GetVideos();
    });
  }
  Create(): void {
    console.log('Create');
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    let dialogRef = this.dialog.open(VideoCreateComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.GetVideos();
    });
  }

  GetVideos(): void {
    this.restService.getVideos()
      .pipe(
        map((data: Video[]) => {
          this.IsLoading = false;
          console.log(data);
          return data;
        }))
      .subscribe((p: Video[]) => this.Videos = p);
  }
  ngOnInit() {
    this.GetVideos();
    this.IsEditMode = false;
    this.IsCreateMode = false;
  }

}
