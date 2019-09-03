import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MyMaterialModule } from 'src/material.module';
import { SharedModule } from '../../shared/shared.module';
import { AdminRoutingModule } from './admin-routing.module';
import { UploadFileComponent } from './components/upload-file/upload-files.component';
import { ConfigCreateComponent } from './dialogs/config-create/config-create.component';
import { ConfigEditComponent } from './dialogs/config-edit/config-edit.component';
import { LogDetailComponent } from './dialogs/log-detail/log-detail.component';
import { PhotoCreateComponent } from './dialogs/photo-create/photo-create.component';
import { PhotoEditComponent } from './dialogs/photo-edit/photo-edit.component';
import { PostCreateComponent } from './dialogs/post-create/post-create.component';
import { PostEditComponent } from './dialogs/post-edit/post-edit.component';
import { VideoCreateComponent } from './dialogs/videos-create/video-create.component';
import { VideoEditComponent } from './dialogs/videos-edit/video-edit.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { ConfigComponent } from './pages/config/config.component';
import { LogComponent } from './pages/log/log.component';
import { PhotosComponent } from './pages/photos/photos.component';
import { PostsComponent } from './pages/posts/posts.component';
import { VideosComponent } from './pages/videos/videos.component';
import { AdminRestService } from './services/admin-rest.service';

@NgModule({
  declarations: [
    AdminPageComponent,
    LogComponent,
    LogDetailComponent,
    PostCreateComponent,
    PostEditComponent,
    ConfigComponent,
    PostsComponent,
    PhotoCreateComponent,
    PhotoEditComponent,
    PhotosComponent,
    VideosComponent,
    VideoEditComponent,
    VideoCreateComponent,
    ConfigCreateComponent,
    ConfigEditComponent,
    UploadFileComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    AdminRoutingModule,
    FormsModule,
    MyMaterialModule,
  ],
  exports: [
    RouterModule,
  ],
  providers: [AdminRestService],
  entryComponents: [PhotoCreateComponent,
    PhotoEditComponent, PostCreateComponent,
    PostEditComponent, VideoCreateComponent, VideoEditComponent, ConfigEditComponent, ConfigCreateComponent],
})
export class AdminModule { }
