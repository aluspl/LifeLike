import { Component, Input, OnInit } from '@angular/core';
import Config from '../../models/Config';

@Component({
  selector: 'home-tile',
  templateUrl: './template.html',
  styleUrls: ['./style.scss'],
})
export class HomeTileComponent implements OnInit {

  @Input() config: Config;

  ngOnInit() {
  }

}
