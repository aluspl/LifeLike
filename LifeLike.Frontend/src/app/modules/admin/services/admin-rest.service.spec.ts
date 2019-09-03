import { inject, TestBed } from '@angular/core/testing';

import { AdminRestService } from './admin-rest.service';

describe('AdminRestService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AdminRestService],
    });
  });

  it('should be created', inject([AdminRestService], (service: AdminRestService) => {
    expect(service).toBeTruthy();
  }));
});
