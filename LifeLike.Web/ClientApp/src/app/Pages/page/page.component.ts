import { Component, OnInit } from '@angular/core';
import { Page } from '../../Models/Page';
import { RestService } from '../../Services/rest.service';


@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss']
})
export class PageComponent implements OnInit {

  Pages: Page[];
  constructor(private restService: RestService) { }
  GetPages(): void {
    this.restService.getPageList().subscribe(posts => this.Pages = posts);
  }
  ngOnInit() {
    this.GetPages();
  }

}
