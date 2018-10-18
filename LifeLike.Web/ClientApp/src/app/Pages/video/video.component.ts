import { Component, OnInit } from '@angular/core';
import {RestService} from '../../Services/rest.service';
import {map} from 'rxjs/internal/operators';
import Video from '../../Models/Video';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss']
})
export class VideoComponent implements OnInit {


  Videos: Video[];
  IsLoading: boolean;
  HasValue: boolean;
  VideoCount = 0;
  constructor(private restService: RestService) { }
  GetPosts(): void {
    this.restService.GetVideos()
      .pipe(
        map(data => {
          this.IsLoading = false;
          if (data.length > 0) {
            this.HasValue = true;
            this.VideoCount = data.length;
          } else {
            this.HasValue = false;
            this.VideoCount = 0;
          }
          console.log(data);
          return data;
        }))
      .subscribe(p => this.Videos = p);
  }
  ngOnInit() {
    this.GetPosts();
  }
}
