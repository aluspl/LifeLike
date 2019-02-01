import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/internal/operators';
import  Page  from 'src/app/shared/models/Page';
import { PostRestService } from '../../services/post-rest.service';


@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss']
})
export class PageComponent implements OnInit {
  Pages: Page[];
  IsLoading: boolean;
  constructor(private restService: PostRestService) { }

  GetPages(): void {
    this.restService.getPageList()
      .pipe(
      map((data: Page[]) => {
        this.IsLoading = false;
        console.log(data);
        return data;
      }))
      .subscribe(p => this.Pages = p);
  }

  ngOnInit() {
    this.GetPages();
  }

}
