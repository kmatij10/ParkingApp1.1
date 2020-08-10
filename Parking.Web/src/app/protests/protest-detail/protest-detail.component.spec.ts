import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProtestDetailComponent } from './protest-detail.component';

describe('ProtestDetailComponent', () => {
  let component: ProtestDetailComponent;
  let fixture: ComponentFixture<ProtestDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProtestDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProtestDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
