import { Component, OnInit } from '@angular/core';
import { Page } from '../../Models/Page';
import { RestService } from '../../Services/rest.service';
import { share } from 'rxjs/operators';
import { Observable } from 'rxjs/index';
import {map} from "rxjs/internal/operators";


@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss']
})
export class PageComponent implements OnInit {
  Pages: Page[];
   IsLoading: boolean;
  constructor(private restService: RestService) { }

  Edit(page: Page): void {
    console.log("Edit");
    console.log(page);
    this.restService.editPost(page);
  }
  Remove(page: Page):  void{
    console.log("Remove");
    console.log(page);
    this.restService.removePost(page);
  }

  GetPages(): void {
    this.restService.getPageList()
      .pipe(
      map(data=> {
        this.IsLoading=false;
        console.log(data);
        return data;
      }))
      .subscribe(p=> this.Pages = p);
  }

  ngOnInit() {
    this.GetPages();
  }

}
