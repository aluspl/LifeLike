import { Component, OnInit } from '@angular/core';
import { Page } from '../../Models/Page';
import { RestService } from '../../Services/rest.service';
import { share } from 'rxjs/operators';
import { Observable } from 'rxjs/index';


@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss']
})
export class PageComponent implements OnInit {
  Pages: Observable<Page[]>;
  constructor(private restService: RestService) { }
  GetPages(): void {
    this.Pages = this.restService.getPageList().pipe(share());
  }
  ngOnInit() {
    this.GetPages();
  }

}
