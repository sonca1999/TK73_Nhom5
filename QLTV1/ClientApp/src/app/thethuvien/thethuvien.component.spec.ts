import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThethuvienComponent } from './thethuvien.component';

describe('ThethuvienComponent', () => {
  let component: ThethuvienComponent;
  let fixture: ComponentFixture<ThethuvienComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThethuvienComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThethuvienComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
