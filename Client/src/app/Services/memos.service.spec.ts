import { TestBed } from '@angular/core/testing';

import { MemosService } from './memos.service';

describe('MemosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MemosService = TestBed.get(MemosService);
    expect(service).toBeTruthy();
  });
});
