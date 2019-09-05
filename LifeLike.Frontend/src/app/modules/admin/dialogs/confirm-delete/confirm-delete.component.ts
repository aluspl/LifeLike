import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './template.html',
  styleUrls: ['./style.scss'],
})
export class ConfirmDeleteComponent implements OnInit {
  Info: string;

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.Info); }

  constructor(
    public dialogRef: MatDialogRef<ConfirmDeleteComponent>, @Inject(MAT_DIALOG_DATA) data) {
    this.Info = data;
  }
  onNoClick() {
    this.dialogRef.close(false);
  }
  onYesClick() {
    this.dialogRef.close(true);
  }
  ngOnInit() {
  }

}
