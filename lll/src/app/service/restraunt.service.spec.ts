import { TestBed } from '@angular/core/testing';

import { RestrauntService } from './restraunt.service';

describe('RestrauntService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RestrauntService = TestBed.get(RestrauntService);
    expect(service).toBeTruthy();
  });
});
