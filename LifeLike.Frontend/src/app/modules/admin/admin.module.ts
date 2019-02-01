import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogDetailComponent } from './log-detail/log-detail.component';
import { LogComponent } from './log/log.component';
import { AdminPage } from './admin-page/admin-page.component';

@NgModule({
  declarations: [
    AdminPage,
    LogComponent,
    LogDetailComponent,
  ],
  imports: [
    CommonModule
  ]
})
export class AdminModule { }
