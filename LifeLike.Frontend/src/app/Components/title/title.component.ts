import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {

  @Input() Title = '';
  GetTitle(): string {
    return this.Title;
  }
  constructor() { }
  ngOnInit() {
  }

}
