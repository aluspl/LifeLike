import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MyMaterialModule } from 'src/material.module';
import { SharedModule } from '../../shared/shared.module';
import { VideoComponent } from './pages/video/video.component';
import { VideoRoutingModule } from './video-routing.module';

@NgModule({
  declarations: [
    VideoComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    VideoRoutingModule,
    RouterModule,
    MyMaterialModule,
  ],

})
export class VideoModule { }
