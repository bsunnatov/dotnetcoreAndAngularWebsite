import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Myselect2Component } from './myselect2.component';

describe('Myselect2Component', () => {
  let component: Myselect2Component;
  let fixture: ComponentFixture<Myselect2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Myselect2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Myselect2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
