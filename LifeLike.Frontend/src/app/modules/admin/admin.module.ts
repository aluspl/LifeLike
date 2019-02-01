import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminPage } from './pages/admin-page/admin-page.component';
import { LogComponent } from './pages/log/log.component';
import { LogDetailComponent } from './pages/log-detail/log-detail.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { PostCreateComponent } from './pages/post-create/post-create.component';
import { PostEditComponent } from './pages/post-edit/post-edit.component';
import { AdminRestService } from './services/admin-rest.service';
import { ConfigComponent } from './pages/config/config.component';

@NgModule({
  declarations: [
    AdminPage,
    LogComponent,
    LogDetailComponent,
    PostCreateComponent,
    PostEditComponent,
    ConfigComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    AdminRoutingModule,
  ],
  providers: [ AdminRestService ]
})
export class AdminModule { }
