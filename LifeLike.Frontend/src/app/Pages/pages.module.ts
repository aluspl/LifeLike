import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { LogComponent } from './log/log.component';
import { PostDetailComponent } from './post-detail/post-detail.component';
import { VideoComponent } from './video/video.component';
import { LogDetailComponent } from './log-detail/log-detail.component';
import { AlbumDetailComponent } from './album-detail/album-detail.component';
import { AlbumComponent } from './album/album.component';
import { PostComponent } from './post/post.component';
import { PageComponent } from './page/page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { LoginComponent } from './login/login.component';
import { PostCreateComponent } from './post-create/post-create.component';
import { ConfigComponent } from './config/config.component';
import { PostEditComponent } from './post-edit/post-edit.component';
import { ComponentsModule } from '../Components/components.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    PageComponent,
    PostComponent,
    AlbumComponent,
    VideoComponent,
    PostDetailComponent,
    HomeComponent,
    LogComponent,
    LogDetailComponent,
    AlbumDetailComponent,
    PostCreateComponent,
    PostEditComponent,
    ConfigComponent,
    AdminPageComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,    
    ComponentsModule,     FormsModule,

  ],
  exports: [
  ]
})
export class PagesModule { }
