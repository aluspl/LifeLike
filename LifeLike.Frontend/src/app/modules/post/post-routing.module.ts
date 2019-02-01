import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { PostDetailComponent } from './pages/post-detail/post-detail.component';
import { PostComponent } from './pages/post/post.component';

const heroesRoutes: Routes = [
  { path: '', component: PostComponent},
  { path:':id', component: PostDetailComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(heroesRoutes)
  ],
  exports: [
    RouterModule
  ]
})

export class PostRoutingModule {
}
