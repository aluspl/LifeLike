import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { AlbumComponent } from './pages/album/album.component';
import { AlbumDetailComponent } from './pages/album-detail/album-detail.component';

const routes: Routes = [
  { path: '', component: AlbumComponent},
  { path:':id', component: AlbumDetailComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})

export class PhotoRoutingModule {
}
