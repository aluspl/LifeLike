import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'youtube-player',
  templateUrl: './youtube-player.component.html',
  styleUrls: ['./youtube-player.component.scss'],
})
export class YoutubePlayerComponent implements OnInit {

  @Input() YoutubeID: string;
  YT: any;
  video: any;
  player: any;
  GetUrl() {
    const link = 'https://www.youtube.com/embed/'.concat(this.YoutubeID);

    return this.sanitizer.bypassSecurityTrustResourceUrl(link);

  }

  constructor(private readonly sanitizer: DomSanitizer) { }

  ngOnInit() {
  }

}
