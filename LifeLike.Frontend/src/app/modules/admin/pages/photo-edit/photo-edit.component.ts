import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminRestService } from '../../services/admin-rest.service';
import Photo from '../../../../modules/photo/models/Photo';

@Component({
  selector: 'app-photo-edit',
  templateUrl: './photo-edit.component.html',
  styleUrls: ['./photo-edit.component.scss']
})
export class PhotoEditComponent implements OnInit {
  @Input() model: Photo;
  loading = false;
  returnUrl: any;

  constructor(private restService: AdminRestService,
    private route: ActivatedRoute,
    private router: Router) {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

  }

  onSubmit() {
    this.loading = true;
    this.restService.editPhoto(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.router.navigate([this.returnUrl]);

    });
  }
  ngOnInit() {
  }

}
