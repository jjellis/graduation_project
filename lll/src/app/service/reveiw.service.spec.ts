import { TestBed } from '@angular/core/testing';

import { ReveiwService } from './reveiw.service';

describe('ReveiwService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ReveiwService = TestBed.get(ReveiwService);
    expect(service).toBeTruthy();
  });
});
