import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostDetailComponent } from './pages/post-detail/post-detail.component';
import { PostComponent } from './pages/post/post.component';
import { PageComponent } from './pages/page/page.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    PageComponent,
    PostComponent,
    PostDetailComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class PostModule { }
