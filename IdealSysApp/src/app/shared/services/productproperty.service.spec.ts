import { TestBed, inject } from '@angular/core/testing';

import { ProductpropertyService } from './productproperty.service';

describe('ProductpropertyService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductpropertyService]
    });
  });

  it('should be created', inject([ProductpropertyService], (service: ProductpropertyService) => {
    expect(service).toBeTruthy();
  }));
});
