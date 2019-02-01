import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './shared/Pages/home/home.component';

const routes: Routes = [
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
  { path: 'Home', component: HomeComponent },
  { path: 'Admin', loadChildren: './modules/admin/admin.module#AdminModule' },  
  { path: 'Post', loadChildren: './modules/post/post.module#PostModule' },  
  { path: 'Page', loadChildren: './modules/post/post.module#PostModule' },  
  { path: 'Album', loadChildren: './modules/photo/photo.module#PhotoModule' },
  { path: 'Video', loadChildren: './modules/video/video.module#VideoModule' } 
];
@NgModule({
  imports: [  RouterModule.forRoot(routes, {
    scrollPositionRestoration: 'enabled',
    anchorScrolling: 'enabled'
  })],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
