import { Component, Input, OnInit } from '@angular/core';
import { AdminRestService } from '../../services/admin-rest.service';
import Photo from '../../../../modules/photo/models/Photo';

@Component({
  selector: 'app-photo-edit',
  templateUrl: './photo-edit.component.html',
  styleUrls: ['./photo-edit.component.scss']
})
export class PhotoEditComponent implements OnInit {
  @Input() model: Photo;
  @Input() IsEditMode: boolean;
  loading = false;

  constructor(private restService: AdminRestService) {
  }

  onSubmit() {
    this.loading = true;
    this.restService.editPhoto(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.IsEditMode = false;
      this.model=null;
    });
  }
  ngOnInit() {
  }

}
