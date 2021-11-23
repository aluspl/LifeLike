import { inject, TestBed } from '@angular/core/testing';

import { PostRestService } from './post-rest.service';

describe('RestService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PostRestService],
    });
  });

  it('should be created', inject([PostRestService], (service: PostRestService) => {
    expect(service).toBeTruthy();
  }));
});
