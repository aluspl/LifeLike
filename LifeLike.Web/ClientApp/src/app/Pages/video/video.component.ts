import { Component, OnInit } from '@angular/core';
import {RestService} from "../../Services/rest.service";
import {map} from "rxjs/internal/operators";
import Video from "../../Models/Video";

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss']
})
export class VideoComponent implements OnInit {


  Videos: Video[];
   IsLoading: boolean;
  constructor(private restService: RestService) { }
  GetPosts(): void {
    this.restService.GetVideos()
      .pipe(
        map(data=> {
          this.IsLoading=false;
          console.log(data);
          return data;
        }))
      .subscribe(p=> this.Videos = p);
    console.log(this.Videos);
  }
  ngOnInit() {
    this.GetPosts();
  }
}
