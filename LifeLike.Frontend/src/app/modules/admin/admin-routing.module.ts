import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { LogComponent } from './pages/log/log.component';
import { LogDetailComponent } from './pages/log-detail/log-detail.component';
import { PostCreateComponent } from './pages/post-create/post-create.component';
import { AdminPage } from './pages/admin-page/admin-page.component';
import { ConfigComponent } from './pages/config/config.component';

const heroesRoutes: Routes = [
  { path: '', component: AdminPage },
  { path: 'createpost', component: PostCreateComponent },
  { path: 'editpost', component: PostCreateComponent },
  { path: 'config', component: ConfigComponent },
  { path: 'log', component: LogComponent },
  { path: 'log:id', component: LogDetailComponent },

];

@NgModule({
  imports: [
    RouterModule.forChild(heroesRoutes)
  ],
  exports: [
    RouterModule
  ]
})

export class AdminRoutingModule {
}