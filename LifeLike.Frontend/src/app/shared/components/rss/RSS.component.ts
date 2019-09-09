import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import Config from '../../models/Config';
import Feed from '../../models/Feed';
import FeedItem from '../../models/FeedItem';
import { FeedService } from '../../services/feed.service';

@Component({
  selector: 'rss',
  templateUrl: './template.html',
  styleUrls: ['./style.scss'],
})
export class RSSComponent implements OnInit, OnDestroy {

  @Input() config: Config;
  feed: any;
  LastFeed: FeedItem;
  sub: Subscription;
  constructor(private feedService: FeedService) {

  }
  ngOnInit() {
    this.sub = this.feedService.getFeedContent(this.config.Value)
      .subscribe((p) => {
        this.feed = p.feed;
        if (p.items.length > 0) {
          this.LastFeed = p.items[0];
        }
      });
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
