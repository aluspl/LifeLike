import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { AdminRestService } from '../../services/admin-rest.service';
import Photo from '../../../photo/models/Photo';
import { MatDialogConfig, MatDialog } from '@angular/material';
import Video from '../../../../modules/video/models/Video';
import { VideoCreateComponent } from '../../dialogs/videos-create/video-create.component';
import { VideoEditComponent } from '../../dialogs/videos-edit/video-edit.component';

@Component({
  selector: 'app-videos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.scss']
})
export class VideosComponent implements OnInit {
  Videos: Video[];
  displayedColumns: string[] = ['Id', 'Name', 'Url', 'Created', 'Actions'];
  IsLoading: boolean;
  error: any;
  constructor(private restService: AdminRestService,
    private dialog: MatDialog) { }

  Remove(video: Video): void {
    console.log('Remove');
    console.log(video);
    this.IsLoading = true;
    this.restService.removeVideo(video.Id)
      .subscribe(
        () => {
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
    let dialogRef = this.dialog.open(VideoEditComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(() => {
      this.GetVideos();
    });
  }
  Create(): void {
    console.log('Create');
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '90%';
    let dialogRef = this.dialog.open(VideoCreateComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(() => {
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
  }
}
