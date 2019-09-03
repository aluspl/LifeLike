import { HttpEventType, HttpResponseBase } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import Video from '../../../video/models/Video';
import FileUpload from '../../models/FileUpload';
import { AdminRestService } from '../../services/admin-rest.service';
@Component({
  selector: 'app-video-create',
  templateUrl: './video-create.component.html',
  styleUrls: ['./video-create.component.scss'],
})
export class VideoCreateComponent implements OnInit {
  loading = false;
  progress: number;
  message: string;
  submitEnabled: boolean;
  model = new Video();
  categories = ['VLOG', 'TRAVEL', 'TUTORIAL', 'TRAILER'];

  onSubmit() {
    this.loading = true;
    this.restService.createVideo(this.model).subscribe((p) => {
      this.loading = false;
      console.log(p);
      this.dialogRef.close();
    }, (error) => {
      this.loading = false;
      console.log(error);
    });
  }
  onNoClick() {
    this.dialogRef.close();
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private readonly restService: AdminRestService,
    public dialogRef: MatDialogRef<VideoCreateComponent>) {
  }

  ngOnInit() {
    this.submitEnabled = false;
  }

}
