import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from './Components/spinner/spinner.component';
import { TitleComponent } from './Components/title/title.component';
import { IntroTextComponent } from './Components/intro-text/intro-text.component';
import { YoutubePlayerComponent } from './Components/youtube-player/youtube-player.component';
import { MenuComponent } from './menu/menu.component';

@NgModule({
  declarations: [
    SpinnerComponent,
    TitleComponent,
    MenuComponent,
    YoutubePlayerComponent,
    IntroTextComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    SpinnerComponent,
    TitleComponent,
    MenuComponent,
    YoutubePlayerComponent,
    IntroTextComponent
  ]
})
export class SharedModule { }
