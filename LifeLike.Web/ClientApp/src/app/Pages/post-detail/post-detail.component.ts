import { Component, OnInit } from '@angular/core';
import { Page } from '../../Models/Page';
import {ActivatedRoute} from '@angular/router';
import {RestService} from '../../Services/rest.service';
import { Observable } from 'rxjs/Observable';
import { share } from 'rxjs/operators';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss']
})
export class PostDetailComponent implements OnInit {
  Page: Observable<Page>;
  constructor(  private route: ActivatedRoute,
                private restService: RestService
                ) { }
  GetPage(): void {
    const id = this.route.snapshot.paramMap.get('id');
    console.log('Article ID ' + id);
    this.Page = this.restService.getPageDetail(id).pipe(share());
  }
  ngOnInit() {
    this.GetPage();
  }

}
