import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LayoutFrontendComponent } from './layout-frontend.component';

describe('LayoutFrontendComponent', () => {
  let component: LayoutFrontendComponent;
  let fixture: ComponentFixture<LayoutFrontendComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LayoutFrontendComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LayoutFrontendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
