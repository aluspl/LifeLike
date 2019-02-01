import {Component, Input, OnInit} from '@angular/core';
import { AdminRestService } from '../../services/admin-rest.service';
import  Page  from 'src/app/shared/models/Page';


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

  constructor(private restService: AdminRestService) {
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
