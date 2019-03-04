import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { PhotoRoutingModule } from './photo-routing.module';
import { PhotoRestService } from './services/photo-rest.service';
import { PhotoDetailComponent } from './components/album-detail/photo-detail.component';
import { PhotoComponent } from './pages/photo/photo.component';

@NgModule({
  declarations: [
    PhotoComponent,
    PhotoDetailComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PhotoRoutingModule
  ],
  providers:[
    PhotoRestService
  ]
})
export class PhotoModule { }
