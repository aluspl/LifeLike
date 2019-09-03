import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { NgxMdModule } from 'ngx-md';
import { MyMaterialModule } from 'src/material.module';
import { SharedModule } from '../../shared/shared.module';
import { PageRoutingModule } from './page-routing.module';
import { PageDetailModule } from './pagedetail.module';
import { PageComponent } from './pages/page/page.component';
import { PostRestService } from './services/post-rest.service';

@NgModule({
  declarations: [
    PageComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    PageDetailModule,
    PageRoutingModule,
    MyMaterialModule,

  ],

  providers: [PostRestService],
})
export class PageModule { }
