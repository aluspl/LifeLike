import { Component, OnInit, Inject } from '@angular/core';
import { AdminRestService } from '../../services/admin-rest.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import Config from '../../../../shared/models/Config';


@Component({
  selector: 'app-config-edit',
  templateUrl: './config-edit.component.html',
  styleUrls: ['./config-edit.component.scss']
})
export class ConfigEditComponent implements OnInit {
  model: Config;


  loading = false;
  categories = ['RSS', 'Text', 'Image', 'Video', 'URL'];
  returnUrl: any;

  constructor(private restService: AdminRestService,
    public dialogRef: MatDialogRef<ConfigEditComponent>,
    @Inject(MAT_DIALOG_DATA) data) {
      this.model=data
  }
  onNoClick()
  {
    this.dialogRef.close();
  }
  onSubmit() {
    this.loading = true;
    this.restService.editConfig(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.dialogRef.close();
    },error=>
    {
      this.loading = false;
      console.log(error);
    });
  }
  ngOnInit() {
  }

}
