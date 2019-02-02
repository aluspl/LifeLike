import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { PostComponent } from './pages/post/post.component';
import { SharedModule } from '../../shared/shared.module';
import { PostRoutingModule } from './post-routing.module';
import { PostRestService } from './services/post-rest.service';
import { PageDetailModule } from './pagedetail.module';

@NgModule({
  declarations: [
    PostComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    PageDetailModule,
    PostRoutingModule
  ],
  
  providers: [PostRestService]
})
export class PostModule { }
