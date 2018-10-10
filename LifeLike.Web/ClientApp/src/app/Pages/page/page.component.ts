import { Component, OnInit } from '@angular/core';
import { Page } from '../../Models/Page';
import { RestService } from '../../Services/rest.service';
import {map} from 'rxjs/internal/operators';


@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss']
})
export class PageComponent implements OnInit {
  Pages: Page[];
  IsLoading: boolean;
  ItemsCount: number;
  constructor(private restService: RestService) { }

  // Edit(page: Page): void {
  //   console.log('Edit');
  //   console.log(page);
  //   this.restService.editPost(page);
  // }
  // Remove(page: Page):  void {
  //   console.log('Remove');
  //   console.log(page);
  //   this.restService.removePost(page);
  // }

  GetPages(): void {
    this.restService.getPageList()
      .pipe(
      map(data => {
        this.IsLoading = false;
        this.ItemsCount = data.length;
        console.log(data);
        return data;
      }))
      .subscribe(p => this.Pages = p);
  }

  ngOnInit() {
    this.GetPages();
  }

}
