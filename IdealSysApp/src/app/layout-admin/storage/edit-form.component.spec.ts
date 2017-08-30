import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StorageEditFormComponent } from './edit-form.component';

describe('EditFormComponent', () => {
    let component: StorageEditFormComponent;
    let fixture: ComponentFixture<StorageEditFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
        declarations: [StorageEditFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
      fixture = TestBed.createComponent(StorageEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
