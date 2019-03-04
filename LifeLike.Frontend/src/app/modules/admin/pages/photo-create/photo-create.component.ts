import { Component, Input, OnInit } from '@angular/core';
import { AdminRestService } from '../../services/admin-rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import FileUpload from '../../models/FileUpload';
@Component({
  selector: 'app-photo-create',
  templateUrl: './photo-create.component.html',
  styleUrls: ['./photo-create.component.scss']
})
export class PhotoCreateComponent implements OnInit {
  model = new FileUpload();
  @Input() IsCreateMode: boolean;
  loading = false;

  onSubmit() {
    console.log(this.diagnostic);
    this.loading = true;
    this.restService.createPhoto(this.model).subscribe(p => {    
      this.loading = false;
      console.log(p);
      this.IsCreateMode = false;
    });
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private restService: AdminRestService) {
  }

  ngOnInit() {
  }

}
