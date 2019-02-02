import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { PostDetailComponent } from './pages/post-detail/post-detail.component';
import { PageComponent } from './pages/page/page.component';
import { SharedModule } from '../../shared/shared.module';
import { PostRestService } from './services/post-rest.service';
import { PageRoutingModule } from './page-routing.module';
import { PageDetailModule } from './pagedetail.module';

@NgModule({
  declarations: [
    PageComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    PageDetailModule,
    PageRoutingModule
  ],
  
  providers: [PostRestService]
})
export class PageModule { }
