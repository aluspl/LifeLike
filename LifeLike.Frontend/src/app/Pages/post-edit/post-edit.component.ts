import {Component, Input, OnInit} from '@angular/core';
import {Page} from "../../Models/Page";
import {RestService} from "../../Services/rest.service";

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.scss']
})
export class PostEditComponent implements OnInit {
  @Input() model: Page;
  @Input() EditMode: boolean;
  loading = false;
  categories = [ 'App', 'Game', 'Tutorial', 'Page', 'Post'];

  constructor(private restService: RestService) {
  }

  onSubmit() {
    this.loading = true;
    this.restService.createPost(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.EditMode = false;
    });
  }
  ngOnInit() {
  }

}
