import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { TitleComponent } from './components/title/title.component';
import { IntroTextComponent } from './components/intro-text/intro-text.component';
import { YoutubePlayerComponent } from './components/youtube-player/youtube-player.component';
import { MenuComponent } from './menu/menu.component';
import { RestService } from './services/rest.service';
import { AuthenticationService } from './services/authentication.service';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from '../core/interceptors/jwt.interceptor';
import { ErrorInterceptor } from '../core/interceptors/error.interceptor';

@NgModule({
  declarations: [
    SpinnerComponent,
    TitleComponent,
    MenuComponent,
    HomeComponent,
    YoutubePlayerComponent,
    IntroTextComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,

    RouterModule
  ],
  exports: [
    CommonModule,
    SpinnerComponent,
    TitleComponent,
    MenuComponent,
    YoutubePlayerComponent,
    IntroTextComponent
  ],
  providers:[
    RestService, AuthenticationService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ]
})
export class SharedModule { }
