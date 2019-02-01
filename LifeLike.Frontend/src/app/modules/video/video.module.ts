import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { VideoComponent } from './pages/video/video.component';

@NgModule({
  declarations: [
    VideoComponent
  ],
  imports: [
    CommonModule,    
    SharedModule,
  ],
 
})
export class VideoModule { }
