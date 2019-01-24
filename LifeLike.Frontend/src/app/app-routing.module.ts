import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { PageComponent } from './Pages/page/page.component';
import { LogComponent } from './Pages/log/log.component';
import { PostComponent } from './Pages/post/post.component';
import { AlbumComponent } from './Pages/album/album.component';
import { VideoComponent } from './Pages/video/video.component';
import { LogDetailComponent } from './Pages/log-detail/log-detail.component';
import { PostDetailComponent } from './Pages/post-detail/post-detail.component';
import { AlbumDetailComponent } from './Pages/album-detail/album-detail.component';
import { PostCreateComponent } from './Pages/post-create/post-create.component';
import {AdminPanelComponent} from './Pages/admin-panel/admin-panel.component';
import { LoginComponent } from './Pages/login/login.component';

const routes: Routes = [
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
  { path: 'Home', component: HomeComponent },
  { path: 'Page', component: PageComponent },
  { path: 'Post', component: PostComponent },
  { path: 'CreatePost', component: PostCreateComponent },
  { path: 'Log', component: LogComponent },
  { path: 'Login', component: LoginComponent },
  { path: 'Album', component: AlbumComponent },
  { path: 'Video', component: VideoComponent },
  { path: 'Log/:id', component: LogDetailComponent },
  { path: 'Album/:id', component: AlbumDetailComponent },
  { path: 'Page/:id', component: PostDetailComponent },
  { path: 'Post/:id', component: PostDetailComponent },
  { path: 'Admin', component: AdminPanelComponent },
];
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
