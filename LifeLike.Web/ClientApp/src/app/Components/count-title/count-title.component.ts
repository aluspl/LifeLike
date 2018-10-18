import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-count-title',
  templateUrl: './count-title.component.html',
  styleUrls: ['./count-title.component.scss']
})
export class CountTitleComponent implements OnInit {
  @Input() Title = 0;
  GetTitle(): string {
    return this.Title + ' items';
  }
  constructor() { }
  ngOnInit() {
  }
}
