import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import Photo from '../../models/Photo';

@Component({
  selector: 'app-photo-detail',
  templateUrl: './photo-detail.component.html',
  styleUrls: ['./photo-detail.component.scss'],
})
export class PhotoDetailComponent implements OnInit {
  @Input() photo: Photo;
  constructor(
    public dialogRef: MatDialogRef<PhotoDetailComponent>,    @Inject(MAT_DIALOG_DATA) data,
  ) {
    this.photo = data;
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
  }
  close() {
    this.dialogRef.close();
  }
}
