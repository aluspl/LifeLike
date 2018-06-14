import {Component, Input, OnInit} from '@angular/core';
import {Config} from "../../Models/Config";

@Component({
  selector: 'app-intro-rss',
  templateUrl: './intro-rss.component.html',
  styleUrls: ['./intro-rss.component.scss']
})
export class IntroRSSComponent implements OnInit {

  constructor() { }
  @Input() config: Config;

  ngOnInit() {
  }

}
