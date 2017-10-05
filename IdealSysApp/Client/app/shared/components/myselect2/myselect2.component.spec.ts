import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MySelect2Component } from './myselect2.component';

describe('Myselect2Component', () => {
    let component: MySelect2Component;
    let fixture: ComponentFixture<MySelect2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
        declarations: [MySelect2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
      fixture = TestBed.createComponent(MySelect2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
