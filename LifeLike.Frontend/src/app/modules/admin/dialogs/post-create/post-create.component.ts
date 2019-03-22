import { Component, Input, OnInit, Inject } from '@angular/core';
import Page from '../../../../shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.scss']
})
export class PostCreateComponent implements OnInit {
  model = new Page();
  loading = false;
  categories = ['App', 'Game', 'Tutorial', 'Page', 'Post'];
  onSubmit() {
    console.log(this.diagnostic);
    this.loading = true;
    this.restService.createPost(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.dialogRef.close();
    }, error => {
      this.loading = false;
      console.log(error);
    });
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private restService: AdminRestService,
    public dialogRef: MatDialogRef<PostCreateComponent>,
    @Inject(MAT_DIALOG_DATA) data ) {

  }
  onNoClick()
  {
    this.dialogRef.close();
  }
  ngOnInit() {
  }

}
