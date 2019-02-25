import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/internal/operators';
import Page from '../../../../shared/models/Page';
import { PostRestService } from '../../services/post-rest.service';
import { ActivatedRoute, RouterState, Router } from '@angular/router';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss']
})
export class PageComponent implements OnInit {
  [x: string]: any;
  Pages: Page[];
  IsLoading: boolean;
  Title: string;
  constructor(private restService: PostRestService, private route: Router) {
  }
  GetPosts(PostType: string): void {
    this.IsLoading = true;
    this.restService.getPostList(PostType)
      .pipe(
        map((data: Page[]) => {
          this.IsLoading = false;
          console.log(data);
          return data;
        }))
      .subscribe(p => this.Pages = p);
  }

  ngOnInit() {
    switch (this.route.url) {
      case "/Post":
        {
          this.Title = "Blog";
          this.GetPosts("Posts");

          break;
        }
      case "/Project":
        {
          this.Title = "Projects"
          this.GetPosts("Projects");
          break;
        }
      case "/Page":
        {
          this.Title = "Pages"
          this.GetPosts("Pages");
          break;

        }
    }
  }

}
