import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, Optional, SkipSelf } from '@angular/core';
import { TimingInterceptor } from './interceptors/timing.interceptor';

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
  ],
  exports: [
    CommonModule,

  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: TimingInterceptor, multi: true},
  ],
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error('CoreModule has already been loaded. Import Core modules in the AppModule only.');
    }
  }
}
