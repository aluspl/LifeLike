import { Component, OnInit } from '@angular/core';
import { RestService } from '../../Services/rest.service';
import { Observable } from 'rxjs/Observable';
import { Page } from '../../Models/Page';
@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.scss']
})
export class PostCreateComponent implements OnInit {
  model = new Page();
  submitted = false;
  categories = [ 'App', 'Game', 'Tutorial', 'Page', 'Post'];

  onSubmit() { console.log(this.diagnostic), this.submitted = true; }
  addPost() {
    console.log(this.diagnostic);
    this.restService.createPost(this.model);
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(private restService: RestService) { }

  ngOnInit() {
  }

}
