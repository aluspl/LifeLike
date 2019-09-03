import { HttpEventType, HttpResponseBase } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import FileUpload from '../../models/FileUpload';
import { AdminRestService } from '../../services/admin-rest.service';
@Component({
  selector: 'app-photo-create',
  templateUrl: './photo-create.component.html',
  styleUrls: ['./photo-create.component.scss'],
})
export class PhotoCreateComponent implements OnInit {
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }
  model = new FileUpload();
  loading = false;
  progress: number;
  message: string;
  submitEnabled: boolean;
  onSubmit() {
    this.loading = true;
    this.restService.createPhoto(this.model).subscribe((event) => {
      this.PhotoUpload(event);
    });
  }

  upload(files: File[]) {
    if (files.length === 0) {
      this.submitEnabled = false;
    } else {
      for (const file of files) {
        this.model.PhotoStream = file;
      }
      this.submitEnabled = true;
    }

  }

  constructor(
    private readonly restService: AdminRestService,
    public dialogRef: MatDialogRef<PhotoCreateComponent>) {
  }

  ngOnInit() {
    this.submitEnabled = false;
  }

  private PhotoUpload(event) {
    if (event.type === HttpEventType.UploadProgress) {
      this.progress = Math.round(100 * event.loaded / event.total);
    } else if (event.type === HttpEventType.Response) {
      this.loading = false;
      if (event.status == 200) {
        console.log(event);
        this.dialogRef.close();
      } else {
        console.log(event);
        this.message = event;
      }
    }
  }

}
