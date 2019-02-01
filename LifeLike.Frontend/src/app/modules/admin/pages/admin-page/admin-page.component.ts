import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import  Page  from 'src/app/shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPage implements OnInit {
    Pages: Page[];
    IsLoading: boolean;
    constructor(private restService: AdminRestService) { }

    Remove(page: Page):  void {
      console.log('Remove');
      console.log(page);
      this.restService.removePost(page.Id);
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
