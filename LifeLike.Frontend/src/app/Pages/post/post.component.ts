import {Component, OnInit} from '@angular/core';
import {RestService} from '../../Services/rest.service';
import {Page} from '../../Models/Page';
import {map} from 'rxjs/internal/operators';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  Posts: Page[];
  IsLoading: boolean;
  CreateMode: boolean;
  ItemsCount = 0;
  constructor(private restService: RestService) { }
  GetPosts(): void {
    this.IsLoading = true;
    this.restService.getPostList()
      .pipe(
        map(data => {
          this.IsLoading = false;
          this.ItemsCount = data.length;
          console.log(data);
          return data;
        }))
      .subscribe(p => this.Posts = p);
  }
  ngOnInit() {
    this.GetPosts();
  }
}
