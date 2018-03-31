import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule } from '@angular/material';
import { CdkTableModule } from '@angular/cdk/table';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { PageComponent } from './page/page.component';
import { PostComponent } from './post/post.component';
import { AlbumComponent } from './album/album.component';
import { VideoComponent } from './video/video.component';
import { RestService } from './rest.service';
import { LoginComponent } from './login/login.component';
import { AppRoutingModule } from './/app-routing.module';
import { PostDetailComponent } from './post-detail/post-detail.component';
import { HomeComponent } from './home/home.component';
import { LogComponent } from './log/log.component';
import { YoutubePlayerComponent } from './youtube-player/youtube-player.component';
import { LogDetailComponent } from './log-detail/log-detail.component';
import { AlbumDetailComponent } from './album-detail/album-detail.component';


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
    AlbumDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,

  ],
  exports: [
    CdkTableModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
  ],
  providers: [RestService],
  bootstrap: [AppComponent]
})
export class AppModule { }
