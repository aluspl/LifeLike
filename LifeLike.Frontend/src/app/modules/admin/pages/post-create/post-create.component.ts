import {Component, Input, OnInit} from '@angular/core';
import  Page  from 'src/app/shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.scss']
})
export class PostCreateComponent implements OnInit {
  model = new Page();
  @Input() CreateMode: boolean;
  loading = false;
  categories = [ 'App', 'Game', 'Tutorial', 'Page', 'Post'];

  onSubmit() {
    console.log(this.diagnostic);
    this.loading = true;
    this.restService.createPost(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.CreateMode = false;
    });
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private restService: AdminRestService) { }

  ngOnInit() {
  }

}
