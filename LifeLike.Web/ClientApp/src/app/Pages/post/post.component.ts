import { Component, OnInit } from '@angular/core';
import { debug } from 'util';
import { RestService } from '../../Services/rest.service';
import { Page } from '../../Models/Page';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  Posts: Page[];
  constructor(private restService: RestService) { }
  GetPosts(): void {
    this.restService.getPostList().subscribe(posts => this.Posts = posts);
  }
  ngOnInit() {
    this.GetPosts();
  }

}
