import { Component, OnInit, Input } from '@angular/core';
import { Page } from '../../Models/Page';
import { RestService } from '../../Services/rest.service';


@Component({
  selector: 'app-post-detail-card',
  templateUrl: './post-detail-card.component.html',
  styleUrls: ['./post-detail-card.component.scss']
})
export class PostDetailCardComponent implements OnInit {

  @Input() post: Page;

  constructor(private restServices: RestService) { }

  ngOnInit() {
  }

}
