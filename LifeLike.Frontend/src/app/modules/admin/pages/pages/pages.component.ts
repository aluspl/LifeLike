import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import Page from '../../../../shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-admin-pages',
  templateUrl: './pages.component.html',
  styleUrls: ['./pages.component.scss']
})
export class PagesComponent implements OnInit {
  Pages: Page[];
  IsLoading: boolean;
  error: any;
  constructor(private restService: AdminRestService) { }

  Remove(page: Page): void {
    console.log('Remove');
    console.log(page);
    this.IsLoading= true;
    this.restService.removePost(page.Id)
      .subscribe(
        data => {
          this.IsLoading = false;
          this.GetPages();
      },
      error => {
          this.error = error;
          this.IsLoading = false;
      });
  }
  GetPages(): void {
    this.restService.getPages()
      .pipe(
        map((data: Page[]) => {
          this.IsLoading = false;
          console.log(data);
          return data;
        }))
      .subscribe((p: Page[]) => this.Pages = p);
  }
  ngOnInit() {
    this.GetPages();
  }

}
