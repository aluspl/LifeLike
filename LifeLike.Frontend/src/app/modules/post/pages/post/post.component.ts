import {Component, OnInit} from '@angular/core';
import {map} from 'rxjs/internal/operators';
import { PostRestService } from '../../services/post-rest.service';
import  Page  from 'src/app/shared/models/Page';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  Posts: Page[];
  IsLoading: boolean;
  CreateMode: boolean;
  constructor(private restService: PostRestService) { }
  GetPosts(): void {
    this.IsLoading = true;
    this.restService.getPostList()
      .pipe(
        map((data: Page[]) => {
          this.IsLoading = false;
          console.log(data);
          return data;
        }))
      .subscribe(p => this.Posts = p);
  }
  ngOnInit() {
    this.GetPosts();
  }
}
