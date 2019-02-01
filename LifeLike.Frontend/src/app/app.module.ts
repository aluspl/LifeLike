import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { PLATFORM_ID, APP_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { SharedModule } from './shared/shared.module';
import { APP_CONFIG, AppConfig } from './configs/app.config';

@NgModule({
  declarations: [
    AppComponent, 
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'lifelike' }),
    SharedModule,
    AppRoutingModule,
    HttpClientModule,
    HttpClientXsrfModule.withOptions({
      cookieName: 'My-Xsrf-Cookie',
      headerName: 'My-Xsrf-Header',
    }),
  ],
  exports: [
  ],
  providers: [  
     {provide: APP_CONFIG, useValue: AppConfig},
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(
    @Inject(PLATFORM_ID) platformId: Object,
    @Inject(APP_ID) appId: string) {
    const platform = isPlatformBrowser(platformId) ?
      'in the browser' : 'on the server';
    console.log(`Running ${platform} with appId=${appId}`);
  }
}
