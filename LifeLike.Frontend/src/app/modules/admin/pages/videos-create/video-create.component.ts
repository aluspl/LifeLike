import { Component, Input, OnInit, Inject } from '@angular/core';
import { AdminRestService } from '../../services/admin-rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import FileUpload from '../../models/FileUpload';
import { HttpEventType, HttpResponseBase } from '@angular/common/http';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import Video from '../../../video/models/Video';
@Component({
  selector: 'app-video-create',
  templateUrl: './video-create.component.html',
  styleUrls: ['./video-create.component.scss']
})
export class VideoCreateComponent implements OnInit {
  loading = false;
  progress: number;
  message: string;
  submitEnabled: boolean;
  model: Video;
  onSubmit() {
    this.loading = true;
    this.restService.createVideo(this.model).subscribe(event => {
      this.VideoCreateCompleted(event);
    });
  }
  VideoCreateCompleted(event: any): any {
    this.loading = false;
    if (event.status == 200) {
      console.log(event);
      this.dialogRef.close();
    }
    else {
      console.log(event);
      this.message=event;
    }
  }

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private restService: AdminRestService,
    public dialogRef: MatDialogRef<VideoCreateComponent>) {
  }

  ngOnInit() {
    this.submitEnabled = false;
  }

}
