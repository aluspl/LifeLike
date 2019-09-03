import { inject, TestBed } from '@angular/core/testing';

import { RestService } from './rest.service';

describe('RestService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RestService],
    });
  });

  it('should be created', inject([RestService], (service: RestService) => {
    expect(service).toBeTruthy();
  }));
});
