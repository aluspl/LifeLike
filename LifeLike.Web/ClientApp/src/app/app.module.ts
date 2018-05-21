
import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppComponent} from './app.component';
import {AppRoutingModule} from './app-routing.module';

import {HttpClientModule, HttpClientXsrfModule} from '@angular/common/http';
import {HomeComponent} from './Pages/home/home.component';
import {LogComponent} from './Pages/log/log.component';
import {PostDetailComponent} from './Pages/post-detail/post-detail.component';
import {VideoComponent} from './Pages/video/video.component';
import {LogDetailComponent} from './Pages/log-detail/log-detail.component';
import {AlbumDetailComponent} from './Pages/album-detail/album-detail.component';
import {AlbumComponent} from './Pages/album/album.component';
import {PostComponent} from './Pages/post/post.component';
import {PageComponent} from './Pages/page/page.component';
import {MenuComponent} from './Layout/menu/menu.component';
import {RestService} from './Services/rest.service';
import {YoutubePlayerComponent} from './Components/youtube-player/youtube-player.component';
import {FormsModule} from '@angular/forms';
import {AuthService} from './Services/auth.service';
import {PostCreateComponent} from './Pages/post-create/post-create.component';
import { TitleComponent } from './Components/title/title.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatAutocompleteModule,
  MatBadgeModule, MatBottomSheetModule,
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
  MatSlideToggleModule, MatSnackBarModule, MatSortModule,
  MatStepperModule, MatTableModule, MatTabsModule,
  MatToolbar,
  MatToolbarModule, MatTooltipModule, MatTreeModule
} from "@angular/material";
import {CdkTableModule} from "@angular/cdk/table";
import {PostEditComponent} from "./Pages/post-edit/post-edit.component";
import { PostListComponent } from './Components/post-list/post-list.component';
import { AdminPanelComponent } from './Pages/admin-panel/admin-panel.component';
import { IntroTextComponent } from './Components/intro-text/intro-text.component';
import { IntroRSSComponent } from './Components/intro-rss/intro-rss.component';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    PageComponent,
    PostComponent,
    AlbumComponent,
    VideoComponent,
    PostDetailComponent,
    HomeComponent,
    LogComponent,
    YoutubePlayerComponent,
    LogDetailComponent,
    AlbumDetailComponent,
    PostCreateComponent,
    TitleComponent,
    PostEditComponent,
    PostListComponent,
    AdminPanelComponent,
    IntroTextComponent,
    IntroRSSComponent,
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
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatProgressSpinnerModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
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
    MatTooltipModule,
    MatTreeModule,
  ],
  exports: [
    CdkTableModule,
    MatToolbarModule,    MatButtonModule,
    MatProgressSpinnerModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
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
    MatTooltipModule,
    MatTreeModule,

  ],
  providers: [RestService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
