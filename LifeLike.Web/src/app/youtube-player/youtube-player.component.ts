import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-youtube-player',
  templateUrl: './youtube-player.component.html',
  styleUrls: ['./youtube-player.component.scss']
})
export class YoutubePlayerComponent implements OnInit {

  @Input() YoutubeID: string;

  GetUrl(): string {
    return 'http://www.youtube.com/embed/'.concat(this.YoutubeID);
  }

  constructor() { }

  ngOnInit() {

  }

}
