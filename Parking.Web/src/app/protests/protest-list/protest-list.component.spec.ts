import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProtestListComponent } from './protest-list.component';

describe('ProtestListComponent', () => {
  let component: ProtestListComponent;
  let fixture: ComponentFixture<ProtestListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProtestListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProtestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
