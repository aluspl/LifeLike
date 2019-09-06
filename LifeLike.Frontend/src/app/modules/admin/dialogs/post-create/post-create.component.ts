import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import Page from '../../../../shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.scss'],
})
export class PostCreateComponent implements OnInit {
  model = new Page();
  loading = false;
  categories = ['App', 'Game', 'Tutorial', 'Page', 'Post'];
  onSubmit() {
    this.loading = true;
    this.restService.createPost(this.model).subscribe((p) => {
      this.loading = false;
      this.dialogRef.close();
    }, () => {
      this.loading = false;
    });
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private readonly restService: AdminRestService,
    public dialogRef: MatDialogRef<PostCreateComponent>,
    @Inject(MAT_DIALOG_DATA) data) {

  }
  onNoClick() {
    this.dialogRef.close();
  }
  ngOnInit() {
  }

}
