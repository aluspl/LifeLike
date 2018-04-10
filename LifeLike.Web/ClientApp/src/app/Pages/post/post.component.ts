import { Component, OnInit } from '@angular/core';
import { debug } from 'util';
import { RestService } from '../../Services/rest.service';
import { Page } from '../../Models/Page';
import { share } from 'rxjs/operators';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  Posts: Observable<Page[]>;
  constructor(private restService: RestService) { }
  GetPosts(): void {
    this.Posts = this.restService.getPostList().pipe(share());
  }
  ngOnInit() {
    this.GetPosts();
  }
}
