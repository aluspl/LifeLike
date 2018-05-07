import {Component, OnInit} from '@angular/core';
import {RestService} from '../../Services/rest.service';
import {Page} from '../../Models/Page';
import { Location } from '@angular/common';

@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.scss']
})
export class PostCreateComponent implements OnInit {
  model = new Page();
  loading = false;
  categories = [ 'App', 'Game', 'Tutorial', 'Page', 'Post'];

  onSubmit() {
    console.log(this.diagnostic);
    this.loading = true;
    this.restService.createPost(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.location.back();
    });
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private restService: RestService,
    private location: Location) { }

  ngOnInit() {
  }

}
