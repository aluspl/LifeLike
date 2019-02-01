import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { AlbumComponent } from './pages/album/album.component';
import { AlbumDetailComponent } from './pages/album-detail/album-detail.component';
import { PhotoRoutingModule } from './photo-routing.module';

@NgModule({
  declarations: [
    AlbumComponent,
    AlbumDetailComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PhotoRoutingModule
  ]
})
export class PhotoModule { }
