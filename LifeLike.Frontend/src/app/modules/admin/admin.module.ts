import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatButtonModule } from '@angular/material';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminPage } from './pages/admin-page/admin-page.component';
import { LogComponent } from './pages/log/log.component';
import { LogDetailComponent } from './pages/log-detail/log-detail.component';
import { SharedModule } from '../../shared/shared.module';
import { PostCreateComponent } from './pages/post-create/post-create.component';
import { PostEditComponent } from './pages/post-edit/post-edit.component';
import { AdminRestService } from './services/admin-rest.service';
import { ConfigComponent } from './pages/config/config.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PagesComponent } from './pages/pages/pages.component';
import { PhotoCreateComponent } from './pages/photo-create/photo-create.component';
import { PhotosComponent } from './pages/photos/photos.component';
import { PhotoEditComponent } from './pages/photo-edit/photo-edit.component';
import { MyMaterialModule } from 'src/material.module';
import { VideoCreateComponent } from './pages/videos-create/video-create.component';

@NgModule({
  declarations: [
    AdminPage,
    LogComponent,
    LogDetailComponent,
    PostCreateComponent,
    PostEditComponent,
    ConfigComponent,
    PagesComponent,
    PhotoCreateComponent,
    PhotoEditComponent,
    PhotosComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    AdminRoutingModule,
    FormsModule,
    MyMaterialModule
  ],
  exports: [
    RouterModule,
  ],
  providers: [ AdminRestService ],
  entryComponents: [PhotoCreateComponent, PhotoEditComponent, PostCreateComponent, PostEditComponent, VideoCreateComponent]
})
export class AdminModule { }
