import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { map } from 'rxjs/operators';
import Video from '../../../../modules/video/models/Video';
import Photo from '../../../photo/models/Photo';
import { VideoCreateComponent } from '../../dialogs/videos-create/video-create.component';
import { VideoEditComponent } from '../../dialogs/videos-edit/video-edit.component';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-videos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.scss'],
})
export class VideosComponent implements OnInit {
  Videos: Video[];
  displayedColumns: string[] = ['Id', 'Name', 'Url', 'Created', 'Actions'];
  IsLoading: boolean;
  error: any;
  constructor(private readonly restService: AdminRestService,
              private readonly dialog: MatDialog) { }

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
        (error) => {
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
    const dialogRef = this.dialog.open(VideoEditComponent, dialogConfig);
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
    const dialogRef = this.dialog.open(VideoCreateComponent, dialogConfig);
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
