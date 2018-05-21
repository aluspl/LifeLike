import {Component, OnInit, Input} from '@angular/core';
import {DomSanitizer} from "@angular/platform-browser";

@Component({
  selector: 'app-youtube-player',
  templateUrl: './youtube-player.component.html',
  styleUrls: ['./youtube-player.component.scss']
})
export class YoutubePlayerComponent implements OnInit {

  @Input() YoutubeID: string;
  public YT: any;
  public video: any;
  public player: any;
  GetUrl() {
    let link = 'http://www.youtube.com/embed/'.concat(this.YoutubeID);
    return this.sanitizer.bypassSecurityTrustResourceUrl(link);

  }

  constructor(private sanitizer: DomSanitizer) { }
  public embed_youtube(): string {
    return this.sanitize_iframe(
      '<iframe src="https://www.youtube.com/embed/' + this.YoutubeID
    + ' frameborder="0" allowfullscreen></iframe>');
  }

  private sanitize_iframe(iframe: string): any {
    return this.sanitizer.bypassSecurityTrustHtml(iframe);
  }
  ngOnInit() {
  }

}
