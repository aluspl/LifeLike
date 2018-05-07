import {Component, Input, OnInit} from '@angular/core';
import {Page} from "../../Models/Page";

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.scss']
})
export class PostEditComponent implements OnInit {
  @Input() model: Page;
  loading = false;
  categories = [ 'App', 'Game', 'Tutorial', 'Page', 'Post'];

  constructor() { }

  ngOnInit() {
  }

}
