import { Component, Input, OnInit } from '@angular/core';
import Page from '../../../../shared/models/Page';
import { AdminRestService } from '../../services/admin-rest.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.scss']
})
export class PostCreateComponent implements OnInit {
  model = new Page();
  loading = false;
  categories = ['App', 'Game', 'Tutorial', 'Page', 'Post'];
  returnUrl: any;

  onSubmit() {
    console.log(this.diagnostic);
    this.loading = true;
    this.restService.createPost(this.model).subscribe(p => {
      this.loading = false;
      console.log(p);
      this.router.navigate([this.returnUrl]);

    });
  }
  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

  constructor(
    private restService: AdminRestService,
    private route: ActivatedRoute,
    private router: Router) {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

  }

  ngOnInit() {
  }

}
