import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/index';
import Feed from '../models/Feed';

@Injectable()
export class FeedService {
  private rssToJsonServiceBaseUrl = 'https://rss2json.com/api.json?rss_url=';

  getFeedContent(url: string): Observable<Feed> {
    return this.http.get<Feed>(this.rssToJsonServiceBaseUrl + url);
  }
  constructor(private readonly http: HttpClient) {
  }
}
