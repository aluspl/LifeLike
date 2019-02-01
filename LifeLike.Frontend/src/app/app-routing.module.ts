import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageComponent } from './Pages/page/page.component';
import { PostComponent } from './Pages/post/post.component';
import { AlbumComponent } from './Pages/album/album.component';
import { VideoComponent } from './Pages/video/video.component';
import { PostDetailComponent } from './Pages/post-detail/post-detail.component';
import { AlbumDetailComponent } from './Pages/album-detail/album-detail.component';
import { PostCreateComponent } from './Pages/post-create/post-create.component';
import { LoginComponent } from './Pages/login/login.component';
import { HomeComponent } from './shared/Pages/home/home.component';

const routes: Routes = [
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
  { path: 'Page', component: PageComponent, loadChildren: './modules/admin/admin.module#AdminModule' },  
  { path: 'Home', component: HomeComponent },
  { path: 'Page', component: PageComponent },
  { path: 'Post', component: PostComponent },
  { path: 'CreatePost', component: PostCreateComponent },
  { path: 'Login', component: LoginComponent },
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
