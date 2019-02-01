import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { VideoComponent } from './pages/video/video.component';
import { VideoRoutingModule } from './video-routing.module';

@NgModule({
  declarations: [
    VideoComponent
  ],
  imports: [
    CommonModule,    
    SharedModule,
    VideoRoutingModule
  ],
 
})
export class VideoModule { }
