import { Component, OnInit } from '@angular/core';
import { Page } from '../../Models/Page';
import {ActivatedRoute} from '@angular/router';
import {RestService} from '../../Services/rest.service';
import { Observable } from 'rxjs/index';
import { share } from 'rxjs/operators';
import {map} from "rxjs/internal/operators";

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss']
})
export class PostDetailComponent implements OnInit {
  Page: Page;
   IsLoading: boolean;
  constructor(  private route: ActivatedRoute,
                private restService: RestService
                ) { }
  GetPage(): void {
    const id = this.route.snapshot.paramMap.get('id');
    console.log('Article ID ' + id);
   this.restService.getPageDetail(id)
     .pipe(
     map(data=> {
       this.IsLoading=false;
       console.log(data);
       return data;
     }))
     .subscribe(p=> this.Page = p);
  }
  ngOnInit() {
    this.GetPage();
  }

}
