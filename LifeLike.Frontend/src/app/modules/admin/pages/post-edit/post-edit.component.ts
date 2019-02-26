import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminRestService } from '../../services/admin-rest.service';
import Page from '../../../../shared/models/Page';


@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.scss']
})
export class PostEditComponent implements OnInit {
  @Input() model: Page;
  loading = false;
  categories = ['App', 'Game', 'Tutorial', 'Page', 'Post'];
  returnUrl: any;

  constructor(private restService: AdminRestService,
    private route: ActivatedRoute,
    private router: Router) {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

  }

  onSubmit() {
    this.loading = true;
    this.restService.editPost(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.router.navigate([this.returnUrl]);

    });
  }
  ngOnInit() {
  }

}
