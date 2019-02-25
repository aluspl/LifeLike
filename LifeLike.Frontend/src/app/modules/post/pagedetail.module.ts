import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { PostDetailComponent } from './pages/post-detail/post-detail.component';
import { SharedModule } from '../../shared/shared.module';
import { PostRestService } from './services/post-rest.service';
import { PageRoutingModule } from './page-routing.module';

@NgModule({
  declarations: [
    PostDetailComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
  ],
  
  providers: [PostRestService]
})
export class PageDetailModule { }
