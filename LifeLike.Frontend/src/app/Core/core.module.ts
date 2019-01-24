import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { PagesModule } from '../Pages/pages.module';

@NgModule({
  declarations: [       ],
  imports: [
    CommonModule,
    PagesModule,
    ,
  ],
  exports: [
       RouterModule  
  ]
})
export class CoreModule { }
