import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostDetailComponent } from './post-detail/post-detail.component';
import { VideoComponent } from './video/video.component';
import { AlbumDetailComponent } from './album-detail/album-detail.component';
import { AlbumComponent } from './album/album.component';
import { PostComponent } from './post/post.component';
import { PageComponent } from './page/page.component';
import { LoginComponent } from './login/login.component';
import { PostCreateComponent } from './post-create/post-create.component';
import { ConfigComponent } from './config/config.component';
import { PostEditComponent } from './post-edit/post-edit.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    PageComponent,
    PostComponent,
    AlbumComponent,
    VideoComponent,
    PostDetailComponent,
    
    AlbumDetailComponent,
    PostCreateComponent,
    PostEditComponent,
    ConfigComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,    
    FormsModule,
    SharedModule
  ],
  exports: [
  ]
})
export class PagesModule { }
