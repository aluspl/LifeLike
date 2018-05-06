import { Component, OnInit } from '@angular/core';
import {PostComponent} from "../post/post.component";
import {Page} from "../../Models/Page";
import {RestService} from "../../Services/rest.service";
import {share} from "rxjs/operators";
import {MenuItem} from "../../Models/MenuItem";
import {Observable} from "rxjs/index";

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss']
})
export class VideoComponent implements OnInit {


  Videos: Observable<MenuItem[]>;
  constructor(private restService: RestService) { }
  GetPosts(): void {
    this.Videos = this.restService.GetVideos().pipe(share());
    console.log(this.Videos);
  }
  ngOnInit() {
    this.GetPosts();
  }
}
