import { TestBed } from '@angular/core/testing';

import { ProdcutApiService } from './prodcut-service.service';

describe('ProdcutServiceService', () => {
  let service: ProdcutApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProdcutApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
