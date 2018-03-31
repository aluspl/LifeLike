import { Component, OnInit, Input } from '@angular/core';
import { RestService } from '../rest.service';
import Page from '../Models/Page';

@Component({
  selector: 'app-post-detail-card',
  templateUrl: './post-detail-card.component.html',
  styleUrls: ['./post-detail-card.component.scss']
})
export class PostDetailCardComponent implements OnInit {

  @Input() post: Page;

  constructor(private restService : RestService) { }

  ngOnInit() {
  }

}
