import { TestBed } from '@angular/core/testing';

import { ProtestService } from './protest.service';

describe('ProtestService', () => {
  let service: ProtestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProtestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
