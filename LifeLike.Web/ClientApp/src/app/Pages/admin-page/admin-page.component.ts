import { Component, OnInit } from '@angular/core';
import { Page } from '../../Models/Page';
import { RestService } from '../../Services/rest.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent implements OnInit {
    Pages: Page[];
    IsLoading: boolean;
    Count = 0;
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
      this.restService.GetAllPagesList()
        .pipe(
            map(data => {
            this.IsLoading = false;
            this.Count = data.length;
            console.log(data);
            return data;
          }))
        .subscribe(p => this.Pages = p);
    }
    ngOnInit() {
      this.GetPages();
    }

}
