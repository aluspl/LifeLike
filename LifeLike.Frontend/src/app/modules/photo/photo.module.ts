import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MyMaterialModule } from 'src/material.module';
import { SharedModule } from '../../shared/shared.module';
import { PhotoDetailComponent } from './components/album-detail/photo-detail.component';
import { PhotoComponent } from './pages/photo/photo.component';
import { PhotoRoutingModule } from './photo-routing.module';
import { PhotoRestService } from './services/photo-rest.service';

@NgModule({
  declarations: [
    PhotoComponent,
    PhotoDetailComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    PhotoRoutingModule,
    MyMaterialModule,
  ],
  providers: [
    PhotoRestService,
  ],
  entryComponents: [PhotoDetailComponent],
})
export class PhotoModule { }
