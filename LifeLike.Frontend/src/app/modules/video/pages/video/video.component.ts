import { Component, OnInit } from '@angular/core';
import {map} from 'rxjs/internal/operators';
import { Video } from 'src/app/shared/models/Video';
import { RestService } from 'src/app/shared/services/rest.service';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss']
})
export class VideoComponent implements OnInit {


  Videos: Video[];
  IsLoading: boolean;
  HasValue: boolean;
  constructor(private restService: RestService) { }
  GetPosts(): void {
    this.restService.GetVideos()
      .pipe(
        map((data: Video[]) => {
          this.IsLoading = false;
          if (data != null) {
            this.HasValue = true;
          } else {
            this.HasValue = false;
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
