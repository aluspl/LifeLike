import { inject, TestBed } from '@angular/core/testing';

import { PhotoRestService } from './photo-rest.service';

describe('RestService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PhotoRestService],
    });
  });

  it('should be created', inject([PhotoRestService], (service: PhotoRestService) => {
    expect(service).toBeTruthy();
  }));
});
