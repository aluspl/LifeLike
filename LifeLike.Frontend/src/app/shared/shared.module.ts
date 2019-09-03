import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material';
import { RouterModule } from '@angular/router';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MyMaterialModule } from '../../material.module';
import { ErrorInterceptor } from '../core/interceptors/error.interceptor';
import { JwtInterceptor } from '../core/interceptors/jwt.interceptor';
import { IntroTextComponent } from './components/intro-text/intro-text.component';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { TitleComponent } from './components/title/title.component';
import { YoutubePlayerComponent } from './components/youtube-player/youtube-player.component';
import { LoginDialogComponent } from './dialogs/login/logindialog.component';
import { RegisterDialogComponent } from './dialogs/register/registerdialogcomponent';
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { AuthenticationService } from './services/authentication.service';
import { RestService } from './services/rest.service';
import { ToolbarComponent } from './toolbar/toolbar.component';

@NgModule({
  declarations: [
    SpinnerComponent,
    TitleComponent,
    MenuComponent,
    HomeComponent,
    YoutubePlayerComponent,
    IntroTextComponent,
    LoginComponent,
    RegisterComponent,
    LoginDialogComponent,
    RegisterDialogComponent,
    ToolbarComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MyMaterialModule,
  ],
  exports: [
    SpinnerComponent,
    TitleComponent,
    MenuComponent,
    YoutubePlayerComponent,
    IntroTextComponent,
    LoginDialogComponent,
    RegisterDialogComponent,
    ToolbarComponent,
  ],
  entryComponents: [LoginDialogComponent, LoginComponent, RegisterComponent,
                    RegisterDialogComponent],

  providers: [
    RestService,
    AuthenticationService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
})
export class SharedModule { }
