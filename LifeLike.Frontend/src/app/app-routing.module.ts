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

  {
    path: 'Admin',
    loadChildren: () => import('./modules/admin/admin.module')
      .then((m) => m.AdminModule),
    canActivate: [AuthGuard],
  },
  {
    path: 'Post',
    loadChildren: () => import('./modules/post/page.module')
      .then((m) => m.PageModule),
  },
  {
    path: 'Page',
    loadChildren: () => import('./modules/post/page.module')
      .then((m) => m.PageModule),
  },
  {
    path: 'Project',
    loadChildren: () => import('./modules/post/page.module')
      .then((m) => m.PageModule),
  },

  {
    path: 'Photo',
    loadChildren: () => import('./modules/photo/photo.module')
      .then((m) => m.PhotoModule),
  },
  {
    path: 'Video',
    loadChildren: () => import('./modules/video/video.module')
      .then((m) => m.VideoModule),
  },

];
@NgModule({
  imports: [RouterModule.forRoot(routes, {
    scrollPositionRestoration: 'enabled',
    anchorScrolling: 'enabled',
  })],
  exports: [RouterModule],
})
export class AppRoutingModule { }
