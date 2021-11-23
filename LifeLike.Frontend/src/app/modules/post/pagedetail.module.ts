import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SharedModule } from '../../shared/shared.module';
import { PostDetailComponent } from './pages/post-detail/post-detail.component';
import { PostRestService } from './services/post-rest.service';

@NgModule({
  declarations: [
    PostDetailComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
  ],

  providers: [PostRestService],
})
export class PageDetailModule { }
