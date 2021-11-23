import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import Page from '../../../../shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.scss'],
})
export class PostEditComponent implements OnInit {
  model: Page;
  loading = false;
  categories = ['App', 'Game', 'Tutorial', 'Page', 'Post'];
  returnUrl: any;

  constructor(private readonly restService: AdminRestService,
              public dialogRef: MatDialogRef<PostEditComponent>,
              @Inject(MAT_DIALOG_DATA) data) {
      this.model = data;
  }
  onNoClick() {
    this.dialogRef.close();
  }
  onSubmit() {
    this.loading = true;
    this.restService.editPost(this.model).subscribe((p) => {
      this.loading = false;
      this.dialogRef.close();
    }, () => {
      this.loading = false;
    });
  }
  ngOnInit() {
  }

}
