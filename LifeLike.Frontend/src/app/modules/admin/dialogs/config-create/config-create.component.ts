import { Component, Input, OnInit } from '@angular/core';
import { AdminRestService } from '../../services/admin-rest.service';
import { MatDialogRef } from '@angular/material';
import Config from '../../../../shared/models/Config';

@Component({
  selector: 'app-config-create',
  templateUrl: './config-create.component.html',
  styleUrls: ['./config-create.component.scss']
})
export class ConfigCreateComponent implements OnInit {
  model = new Config();
  loading = false;
  categories = ['RSS', 'Text', 'Image', 'Video', 'URL'];
  onSubmit() {
    console.log(this.diagnostic);
    this.loading = true;
    this.restService.createConfig(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.dialogRef.close();
    }, error => {
      this.loading = false;
      console.log(error);
    });
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private restService: AdminRestService,
    public dialogRef: MatDialogRef<ConfigCreateComponent> ) {

  }
  onNoClick()
  {
    this.dialogRef.close();
  }
  ngOnInit() {
  }

}
