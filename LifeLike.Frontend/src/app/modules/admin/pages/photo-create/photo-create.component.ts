import { Component, Input, OnInit, Inject } from '@angular/core';
import { AdminRestService } from '../../services/admin-rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import FileUpload from '../../models/FileUpload';
import { HttpEventType, HttpResponseBase } from '@angular/common/http';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
@Component({
  selector: 'app-photo-create',
  templateUrl: './photo-create.component.html',
  styleUrls: ['./photo-create.component.scss']
})
export class PhotoCreateComponent implements OnInit {
  model = new FileUpload();
  loading = false;
  progress: number;
  message: string;
  submitEnabled: boolean;
  onSubmit() {
    this.loading = true;
    this.restService.createPhoto(this.model).subscribe(event => {
      this.PhotoUpload(event);
    });
  }

  private PhotoUpload(event) {
    if (event.type === HttpEventType.UploadProgress)
      this.progress = Math.round(100 * event.loaded / event.total);
    else if (event.type === HttpEventType.Response) {
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
  }

  upload(files: File[]) {
    if (files.length === 0)
      this.submitEnabled = false;
    else {
      for (let file of files) {
        this.model.PhotoStream = file;
      }
      this.submitEnabled = true;
    }

  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private restService: AdminRestService,
    public dialogRef: MatDialogRef<PhotoCreateComponent>) {
  }

  ngOnInit() {
    this.submitEnabled = false;
  }

}
