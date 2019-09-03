import { isPlatformBrowser } from '@angular/common';
import { HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { APP_ID, Inject, PLATFORM_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxMdModule } from 'ngx-md';
import { MyMaterialModule } from '../material.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_CONFIG, AppConfig } from './configs/app.config';
import { CustomErrorHandler } from './core/custom.errorhandler';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'lifelike-web' }),

    SharedModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    HttpClientXsrfModule.withOptions({
      cookieName: 'My-Xsrf-Cookie',
      headerName: 'My-Xsrf-Header',
    }),
    MyMaterialModule,

  ],
  exports: [
  ],
  providers: [
     {provide: APP_CONFIG, useValue: AppConfig},
     {provide: ErrorHandler, useClass: CustomErrorHandler},
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(
    @Inject(PLATFORM_ID) platformId: string,
    @Inject(APP_ID) appId: string) {
    const platform = isPlatformBrowser(platformId) ?
      'in the browser' : 'on the server';
  }
}
