import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostDetailComponent } from './pages/post-detail/post-detail.component';
import { PostComponent } from './pages/post/post.component';
import { PageComponent } from './pages/page/page.component';
import { SharedModule } from '../../shared/shared.module';
import { RouterModule } from '@angular/router';
import { PostRoutingModule } from './post-routing.module';
import { PostRestService } from './services/post-rest.service';

@NgModule({
  declarations: [
    PageComponent,
    PostComponent,
    PostDetailComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    PostRoutingModule
  ],
  
  providers: [PostRestService]
})
export class PostModule { }
