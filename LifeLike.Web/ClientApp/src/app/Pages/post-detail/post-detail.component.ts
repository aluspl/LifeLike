import { Component, OnInit } from '@angular/core';
import { Page } from '../../Models/Page';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss']
})
export class PostDetailComponent implements OnInit {
  page: Page;
  constructor() { }

  ngOnInit() {
  }

}
