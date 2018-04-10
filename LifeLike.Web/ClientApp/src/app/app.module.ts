import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './/app-routing.module';

import { HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { HomeComponent } from './Pages/home/home.component';
import { LogComponent } from './Pages/log/log.component';
import { PostDetailComponent } from './Pages/post-detail/post-detail.component';
import { VideoComponent } from './Pages/video/video.component';
import { LoginComponent } from './Pages/login/login.component';
import { LogDetailComponent } from './Pages/log-detail/log-detail.component';
import { AlbumDetailComponent } from './Pages/album-detail/album-detail.component';
import { AlbumComponent } from './Pages/album/album.component';
import { PostComponent } from './Pages/post/post.component';
import { PageComponent } from './Pages/page/page.component';
import { MenuComponent } from './Layout/menu/menu.component';
import { RestService } from './Services/rest.service';
import { PostDetailCardComponent } from './Components/post-detail-card/post-detail-card.component';
import { YoutubePlayerComponent } from './Components/youtube-player/youtube-player.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    PageComponent,
    PostComponent,
    AlbumComponent,
    VideoComponent,
    LoginComponent,
    PostDetailComponent,
    HomeComponent,
    LogComponent,
    YoutubePlayerComponent,
    LogDetailComponent,
    AlbumDetailComponent,
    PostDetailCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    HttpClientModule,
    HttpClientXsrfModule.withOptions({
      cookieName: 'My-Xsrf-Cookie',
      headerName: 'My-Xsrf-Header',
    }),
    NgbModule.forRoot(),
  ],
  exports: [
  ],
  providers: [RestService],
  bootstrap: [AppComponent]
})
export class AppModule { }
