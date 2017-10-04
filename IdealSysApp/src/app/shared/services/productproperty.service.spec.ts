import { TestBed, inject } from '@angular/core/testing';

import { ProductPropertyService } from './productproperty.service';

describe('ProductpropertyService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
        providers: [ProductPropertyService]
    });
  });

  it('should be created', inject([ProductPropertyService], (service: ProductPropertyService) => {
    expect(service).toBeTruthy();
  }));
});
