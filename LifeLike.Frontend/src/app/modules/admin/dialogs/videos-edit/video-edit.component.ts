import { Component, Input, OnInit, Inject } from '@angular/core';
import { AdminRestService } from '../../services/admin-rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import FileUpload from '../../models/FileUpload';
import { HttpEventType, HttpResponseBase } from '@angular/common/http';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import Video from '../../../video/models/Video';
@Component({
  selector: 'app-video-edit',
  templateUrl: './video-edit.component.html',
  styleUrls: ['./video-edit.component.scss']
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
    this.restService.editVideo(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.dialogRef.close();
    }, error => {
      this.loading = false;
      console.log(error);
    });
  }
  onNoClick()
  {
    this.dialogRef.close();
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private restService: AdminRestService,
    public dialogRef: MatDialogRef<VideoEditComponent>, @Inject(MAT_DIALOG_DATA) data) {
      this.model=data;
  }

  ngOnInit() {
    this.submitEnabled = false;
  }

}
