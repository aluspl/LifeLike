import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/internal/operators';
import { RestService } from '../../../../shared/services/rest.service';
import Video from '../../models/Video';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss'],
})
export class VideoComponent implements OnInit {
  Videos: Video[];
  IsLoading: boolean;

  constructor(private readonly restService: RestService) { }
  GetVideos() {
    this.IsLoading = true;
    this.restService.GetVideos()

      .subscribe((p) => {
        this.IsLoading = false;
        console.log(p);
        this.Videos = p;
      },
      (error) => {
        this.IsLoading = false;
        console.log(error);
      });
  }
  ngOnInit() {
    this.GetVideos();
  }
}
