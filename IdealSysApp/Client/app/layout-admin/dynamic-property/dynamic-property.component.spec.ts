import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DynamicPropertyComponent } from './dynamic-property.component';

describe('DynamicPropertyComponent', () => {
  let component: DynamicPropertyComponent;
  let fixture: ComponentFixture<DynamicPropertyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DynamicPropertyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DynamicPropertyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
