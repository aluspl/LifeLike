import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { PostDetailComponent } from './pages/post-detail/post-detail.component';
import { PageComponent } from './pages/page/page.component';

const Route: Routes = [
  { path: '', component: PageComponent},
  { path:':id', component: PostDetailComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(Route)
  ],
  exports: [
    RouterModule
  ]
})

export class PageRoutingModule {
}
