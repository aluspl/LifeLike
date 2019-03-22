import { Component, Input, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminRestService } from '../../services/admin-rest.service';
import Page from '../../../../shared/models/Page';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';


@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.scss']
})
export class PostEditComponent implements OnInit {
  model: Page;
  loading = false;
  categories = ['App', 'Game', 'Tutorial', 'Page', 'Post'];
  returnUrl: any;

  constructor(private restService: AdminRestService,
    public dialogRef: MatDialogRef<PostEditComponent>,
    @Inject(MAT_DIALOG_DATA) data) {
      this.model=data
  }
  onNoClick()
  {
    this.dialogRef.close();
  }
  onSubmit() {
    this.loading = true;
    this.restService.editPost(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.dialogRef.close();
    },error=>
    {
      this.loading = false;
      console.log(error);
    });
  }
  ngOnInit() {
  }

}
