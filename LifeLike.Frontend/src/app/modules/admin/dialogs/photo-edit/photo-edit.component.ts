import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import Photo from '../../../../modules/photo/models/Photo';
import { AdminRestService } from '../../services/admin-rest.service';

@Component({
  selector: 'app-photo-edit',
  templateUrl: './photo-edit.component.html',
  styleUrls: ['./photo-edit.component.scss'],
})
export class PhotoEditComponent implements OnInit {
  model: Photo;
  loading = false;

  constructor(private readonly restService: AdminRestService,
              public dialogRef: MatDialogRef<PhotoEditComponent>,
              @Inject(MAT_DIALOG_DATA) data) {
      this.model = data;
  }

  onSubmit() {
    this.loading = true;
    this.restService.editPhoto(this.model).subscribe((p) => {
      this.loading = false;
      console.log(p);
      this.dialogRef.close();
    }, (error) => {
      this.loading = false;
      console.log(error);
    });
  }
  ngOnInit() {
  }

}
