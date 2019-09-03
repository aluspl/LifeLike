import { Component, Input, OnInit } from '@angular/core';
import  Config  from '../../models/Config';

@Component({
  selector: 'app-intro-text',
  templateUrl: './intro-text.component.html',
  styleUrls: ['./intro-text.component.scss'],
})
export class IntroTextComponent implements OnInit {
  @Input() config: Config;

  ngOnInit() {
  }

}
