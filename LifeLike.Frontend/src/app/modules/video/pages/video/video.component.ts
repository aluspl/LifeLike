import { Component, OnInit } from '@angular/core';
import {map} from 'rxjs/internal/operators';
import Video from '../../models/Video';
import { RestService } from '../../../../shared/services/rest.service';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss']
})
export class VideoComponent implements OnInit {
  Videos: Video[];
  IsLoading: boolean;

  constructor(private restService: RestService) { }
  GetVideos(){
    this.IsLoading=true;
    this.restService.GetVideos()

      .subscribe(p => {
        this.IsLoading=false;
        console.log(p);
        this.Videos = p
      },
      error=>
      {
        this.IsLoading=false;
        console.log(error);
      });
  }
  ngOnInit() {
    this.GetVideos();
  }
}
