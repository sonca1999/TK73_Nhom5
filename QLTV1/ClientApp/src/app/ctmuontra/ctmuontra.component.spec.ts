import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CtmuontraComponent } from './ctmuontra.component';

describe('CtmuontraComponent', () => {
  let component: CtmuontraComponent;
  let fixture: ComponentFixture<CtmuontraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CtmuontraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CtmuontraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
