import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './shared/pages/home/home.component';
import { LoginComponent } from './shared/pages/login/login.component';
import { RegisterComponent } from './shared/pages/register/register.component';
import { AuthGuard } from './shared/services/AuthGuard';

const routes: Routes = [
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
  { path: 'Home', component: HomeComponent },
  { path: 'Login', component: LoginComponent },  
  { path: 'Register', component: RegisterComponent },  

  { path: 'Admin', loadChildren: './modules/admin/admin.module#AdminModule', canActivate: [AuthGuard] },  
  { path: 'Post', loadChildren: './modules/post/page.module#PageModule' },  
  { path: 'Page', loadChildren: './modules/post/page.module#PageModule' },  
  { path: 'Project', loadChildren: './modules/post/page.module#PageModule' },  

  { path: 'Photo', loadChildren: './modules/photo/photo.module#PhotoModule' },
  { path: 'Video', loadChildren: './modules/video/video.module#VideoModule' },

];
@NgModule({
  imports: [  RouterModule.forRoot(routes, {
    scrollPositionRestoration: 'enabled',
    anchorScrolling: 'enabled'
  })],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
