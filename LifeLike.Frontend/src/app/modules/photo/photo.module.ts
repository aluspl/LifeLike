import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { PhotoRoutingModule } from './photo-routing.module';
import { PhotoRestService } from './services/photo-rest.service';
import { PhotoDetailComponent } from './components/album-detail/photo-detail.component';
import { PhotoComponent } from './pages/photo/photo.component';
import { MyMaterialModule } from 'src/material.module';

@NgModule({
  declarations: [
    PhotoComponent,
    PhotoDetailComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PhotoRoutingModule,
    MyMaterialModule
  ],
  providers:[
    PhotoRestService
  ],
  entryComponents: [PhotoDetailComponent]
})
export class PhotoModule { }
