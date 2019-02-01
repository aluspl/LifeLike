import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { VideoComponent } from './pages/video/video.component';
const routes: Routes = [
  { path: '', component: VideoComponent},
  { path:':id', component: VideoComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})

export class VideoRoutingModule {
}
