import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/internal/operators';
import  Page  from '../../../../shared/models/Page';
import { PostRestService } from '../../services/post-rest.service';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss'],
})
export class PostDetailComponent implements OnInit {
  Page: Page;
  IsLoading: boolean;
  constructor(private readonly route: ActivatedRoute,
              private readonly restService: PostRestService,
                ) { }
  GetPage(): void {
    const id = this.route.snapshot.paramMap.get('id');
    console.log('Article ID ' + id);

    this.restService.getPageDetail(id)
     .pipe(map((data: Page) => {
       this.IsLoading = false;
       console.log(data);
       if (data != undefined) {
         return data;
       } else {
         return null;
       }
     }))
     .subscribe((p) => this.Page = p);
  }
  ngOnInit() {
    this.GetPage();
  }

}
