import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageComponent } from './page/page.component';
import { PostDetailComponent } from './post-detail/post-detail.component';
import { HomeComponent } from './home/home.component';
import { PostComponent } from './post/post.component';
import { LogComponent } from './log/log.component';
import { VideoComponent } from './video/video.component';
import { LogDetailComponent } from './log-detail/log-detail.component';
import { AlbumDetailComponent } from './album-detail/album-detail.component';
import { AlbumComponent } from './album/album.component';

const routes: Routes = [
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
  { path: 'Home', component: HomeComponent },
  { path: 'Page', component: PageComponent },
  { path: 'Post', component: PostComponent },
  { path: 'Log', component: LogComponent },
  { path: 'Album', component: AlbumComponent },
  { path: 'Video', component: VideoComponent },
  { path: 'Log/:id', component: LogDetailComponent },
  { path: 'Album/:id', component: AlbumDetailComponent },
  { path: 'Page/:id', component: PostDetailComponent },
  { path: 'Post/:id', component: PostDetailComponent },
];
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
