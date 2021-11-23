import { HttpEventType, HttpResponseBase } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import Video from '../../../video/models/Video';
import FileUpload from '../../models/FileUpload';
import { AdminRestService } from '../../services/admin-rest.service';
@Component({
  selector: 'app-video-edit',
  templateUrl: './video-edit.component.html',
  styleUrls: ['./video-edit.component.scss'],
})
export class VideoEditComponent implements OnInit {
  loading = false;
  progress: number;
  message: string;
  submitEnabled: boolean;
  model: Video;
  categories = ['VLOG', 'TRAVEL', 'TUTORIAL', 'TRAILER'];

  onSubmit() {
    this.loading = true;
    this.restService.editVideo(this.model).subscribe((p) => {
      this.loading = false;
      this.dialogRef.close();
    }, (error) => {
      this.loading = false;
    });
  }
  onNoClick() {
    this.dialogRef.close();
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private readonly restService: AdminRestService,
    public dialogRef: MatDialogRef<VideoEditComponent>, @Inject(MAT_DIALOG_DATA) data) {
      this.model = data;
  }

  ngOnInit() {
    this.submitEnabled = false;
  }

}
