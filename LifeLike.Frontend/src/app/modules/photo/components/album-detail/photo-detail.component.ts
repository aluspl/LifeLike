import { Component, OnInit, Input } from '@angular/core';
import Photo from '../../models/Photo';

@Component({
  selector: 'app-photo-detail',
  templateUrl: './photo-detail.component.html',
  styleUrls: ['./photo-detail.component.scss']
})
export class PhotoDetailComponent implements OnInit {
  @Input() photo: Photo;

  constructor() { }

  ngOnInit() {
  }
}
